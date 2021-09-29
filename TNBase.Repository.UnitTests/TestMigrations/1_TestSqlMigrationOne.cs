﻿
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.UnitTests.TestMigrations
{
    public class _1_TestSqlMigrationOne : TestSqlMigration
    {
        public _1_TestSqlMigrationOne(SqliteConnection connection) : base(connection)
        { }

        public override int Version => 1;

        public override string Name => "TestSqlMigrationOne";

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"CREATE TABLE MigrationTest(Id INTEGER PRIMARY KEY, Test1 TEXT, Test2 TEXT)";
                command.ExecuteNonQuery();
            }
        }
    }
}
