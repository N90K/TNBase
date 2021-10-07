using Microsoft.Data.Sqlite;

namespace TNBase.Repository.UnitTests.TestMigrations
{
    public class _2_TestSqlMigrationTwo : TestSqlMigration
    {
        public _2_TestSqlMigrationTwo(SqliteConnection connection) : base(connection)
        { }

        public override int Version => 2;

        public override string Name => "TestSqlMigrationTwo";

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"INSERT INTO MigrationTest(Test1) VALUES($Test1)";
                command.Parameters.Add("$Test1", SqliteType.Text).Value = "Migration 2 Applied";
                command.ExecuteNonQuery();
            }
        }
    }
}
