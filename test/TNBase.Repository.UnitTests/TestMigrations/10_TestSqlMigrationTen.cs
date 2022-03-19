using Microsoft.Data.Sqlite;

namespace TNBase.Repository.UnitTests.TestMigrations
{
    public class _10_TestSqlMigrationTen : TestSqlMigration
    {
        public _10_TestSqlMigrationTen(SqliteConnection connection) : base(connection)
        { }

        public override int Version => 10;

        public override string Name => "TestSqlMigrationTen";

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"UPDATE MigrationTest SET Test2=$Test2 WHERE Id=1";
                command.Parameters.Add("$Test2", SqliteType.Text).Value = "Migration 10 Applied";
                command.ExecuteNonQuery();
            }
        }
    }
}
