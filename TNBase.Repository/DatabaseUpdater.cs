using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TNBase.Objects;

namespace TNBase.Repository
{
    public class DatabaseUpdater<T> where T : class, ISqlMigration
    {
        private readonly SqliteConnection connection;

        public DatabaseUpdater(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public void Update(int? version = null)
        {
            CreateMigrationsTableIfNotExist();
            var lastMigration = GetLastMigration();

            using var transaction = connection.BeginTransaction();
            foreach (var migration in GetMigrations(lastMigration))
            {
                migration.Up();
                AddMigration(migration);
            }

            transaction.Commit();
        }

        private void AddMigration(ISqlMigration migration)
        {
            using var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO DatabaseMigrations(Version, Name, CreateDate) VALUES($Version, $Name, $CreateDate)";
            command.Parameters.Add("$Version", SqliteType.Integer).Value = migration.Version;
            command.Parameters.Add("$Name", SqliteType.Text).Value = migration.Name;
            command.Parameters.Add("$CreateDate", SqliteType.Text).Value = DateTime.UtcNow.ToSQLiteUtcString();
            command.ExecuteNonQuery();
        }

        private void CreateMigrationsTableIfNotExist()
        {
            using var command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS DatabaseMigrations(Id INTEGER PRIMARY KEY, Version INT, Name TEXT, CreateDate DATE)";
            command.ExecuteNonQuery();
        }

        private int GetLastMigration()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT Version FROM DatabaseMigrations ORDER BY Version DESC LIMIT 1";
                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    return Convert.ToInt32(reader[0]);
                }
            }

            return -1;
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
