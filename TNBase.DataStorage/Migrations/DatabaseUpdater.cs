using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;

namespace TNBase.DataStorage.Migrations
{
    public class DatabaseUpdater<T> where T : class, ISqlMigration
    {
        private readonly SQLiteConnection connection;

        public DatabaseUpdater(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public void Update(int? version = null)
        {
            CreateMigrationsTableIfNotExist();
            var lastMigration = GetLastMigration();

            using (var transaction = connection.BeginTransaction())
            {
                foreach (var migration in GetMigrations(lastMigration))
                {
                    migration.Up();
                    AddMigration(migration);
                }

                transaction.Commit();
            }

        }

        private void AddMigration(ISqlMigration migration)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO DatabaseMigrations(Version, Name, CreateDate) VALUES($Version, $Name, $CreateDate)";
                command.Parameters.Add("$Version", DbType.Int32).Value = migration.Version;
                command.Parameters.Add("$Name", DbType.String).Value = migration.Name;
                command.Parameters.Add("$CreateDate", DbType.DateTime).Value = DateTime.UtcNow;
                command.ExecuteNonQuery();
            }
        }

        private void CreateMigrationsTableIfNotExist()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='DatabaseMigrations'";
                using (var reader = command.ExecuteReader())
                {
                    var tableExists = reader.HasRows;
                    reader.Close();

                    if (!tableExists)
                    {
                        command.CommandText = @"CREATE TABLE DatabaseMigrations(Id INTEGER PRIMARY KEY, Version INT, Name TEXT, CreateDate DATE)";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private int GetLastMigration()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Version FROM DatabaseMigrations ORDER BY Version DESC LIMIT 1";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return Convert.ToInt32(reader[0]);
                    }
                }
            }

            return 0;
        }

        private List<T> GetMigrations(int from)
        {
            return Assembly.GetAssembly(typeof(T)).GetTypes()
                 .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                 .Select(x => (T)Activator.CreateInstance(x, connection))
                 .Where(x => x.Version > from)
                 .OrderBy(x => x.Version)
                 .ToList();
        }

        private class DatabaseMigration
        {
            public int Version { get; set; }
            public string Name { get; set; }
            public DateTime CreateDate { get; set; }
        }
    }
}
