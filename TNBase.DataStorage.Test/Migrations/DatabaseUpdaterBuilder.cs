using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using TNBase.DataStorage.Migrations;
using TNBase.DataStorage.Test.Migrations.TestMigrations;

namespace TNBase.DataStorage.Test.Migrations
{
    public class DatabaseUpdaterBuilder : IDisposable
    {
        private const string DatabaseMigrationsTable = "DatabaseMigrations";
        private const string MigrationTestTable = "MigrationTest";
        private SQLiteConnection connection;

        public DatabaseUpdaterBuilder()
        {
            connection = new SQLiteConnection(DBUtils.GenConnectionString(":memory:"));
            connection.Open();
        }

        public DatabaseUpdater<TestSqlMigration> Build()
        {
            return new DatabaseUpdater<TestSqlMigration>(connection);
        }

        internal bool DatabaseMigrationsTableExists()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{DatabaseMigrationsTable}'";
                using (var reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        public DatabaseUpdaterBuilder WithDatabaseMigrationsTable()
        {
            CreateTable(DatabaseMigrationsTable);
            return this;
        }

        private void CreateTable(string tableName)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE {tableName}(Id INTEGER PRIMARY KEY, Version INT, Name TEXT, CreateDate DATE)";
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DatabaseMigration> GetDatabaseMigrations()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {DatabaseMigrationsTable}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new DatabaseMigration
                        {
                            Version = Convert.ToInt32(reader["Version"]),
                            Name = Convert.ToString(reader["Name"]),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"])
                        };
                    }
                }
            }
        }

        public DatabaseUpdaterBuilder WithMigrations(int version, string name)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO DatabaseMigrations(Version, Name, CreateDate) VALUES($Version, $Name, $CreateDate)";
                command.Parameters.Add("$Version", DbType.Int32).Value = version;
                command.Parameters.Add("$Name", DbType.String).Value = name;
                command.Parameters.Add("$CreateDate", DbType.DateTime).Value = DateTime.UtcNow;
                command.ExecuteNonQuery();
            }

            return this;
        }

        public MigrationTestData ReadMigrationTestTable()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM MigrationTest";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new MigrationTestData
                    {
                        Test1 = Convert.ToString(reader["Test1"]),
                        Test2 = Convert.ToString(reader["Test2"])
                    };
                }
            }
        }

        public DatabaseUpdaterBuilder WithMigrationTestTable()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE {MigrationTestTable}(Id INTEGER PRIMARY KEY, Test1 TEXT, Test2 TEXT)";
                command.ExecuteNonQuery();
            }
            return this;
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
