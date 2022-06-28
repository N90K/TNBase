
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Fix ScanIn history record data issue
    /// </summary>
    public class _7_OnlineOnly : SqlMigration
    {
        public _7_OnlineOnly(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"ALTER TABLE Listeners ADD OnlineOnly BIT DEFAULT 0";
            command.ExecuteNonQuery();
        }
    }
}
