using System.Data;
using System.Data.SQLite;

namespace TNBase.DataStorage.Test.Migrations.TestMigrations
{
    public class _10_TestSqlMigrationTen : TestSqlMigration
    {
        public _10_TestSqlMigrationTen(SQLiteConnection connection) : base(connection)
        { }

        public override int Version => 10;

        public override string Name => "TestSqlMigrationTen";

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"UPDATE MigrationTest SET Test2=$Test2 WHERE Id=1";
                command.Parameters.Add("$Test2", DbType.String).Value = "Migration 10 Applied";
                command.ExecuteNonQuery();
            }
        }
    }
}
