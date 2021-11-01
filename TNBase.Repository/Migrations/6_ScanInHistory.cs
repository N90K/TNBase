
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Fix ScanIn history record data issue
    /// </summary>
    public class _6_ScanInHistory : SqlMigration
    {
        public _6_ScanInHistory(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"UPDATE WeekStats SET ScannedIn = ScannedIn/2";
            command.ExecuteNonQuery();
        }
    }
}
