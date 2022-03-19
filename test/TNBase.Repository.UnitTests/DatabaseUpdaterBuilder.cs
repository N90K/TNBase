using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using TNBase.Repository.UnitTests.TestMigrations;

namespace TNBase.Repository.UnitTests
{
    public class DatabaseUpdaterBuilder : IDisposable
    {
        private const string DatabaseMigrationsTable = "DatabaseMigrations";
        private const string MigrationTestTable = "MigrationTest";
        private readonly SqliteConnection connection;

        public DatabaseUpdaterBuilder()
        {
            connection = new SqliteConnection("Data Source=:memory:");
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

        public DatabaseUpdaterBuilder WithMigration(int version, string name)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO DatabaseMigrations(Version, Name, CreateDate) VALUES($Version, $Name, $CreateDate)";
                command.Parameters.Add("$Version", SqliteType.Integer).Value = version;
                command.Parameters.Add("$Name", SqliteType.Text).Value = name;
                command.Parameters.Add("$CreateDate", SqliteType.Text).Value = DateTime.UtcNow;
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
