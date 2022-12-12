
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Fix ScanIn history record data issue
    /// </summary>
    public class _8_NumberOfIssuedWallets : SqlMigration
    {
        public _8_NumberOfIssuedWallets(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"ALTER TABLE Listeners ADD NewsWalletsIssued INT DEFAULT 3";
            command.ExecuteNonQuery();

            command.CommandText = $"ALTER TABLE Listeners ADD MagazineWalletsIssued INT DEFAULT 0";
            command.ExecuteNonQuery();

            command.CommandText = $"UPDATE Listeners SET NewsWalletsIssued = CASE WHEN OnlineOnly = 1 THEN 0 ELSE 3 END";
            command.ExecuteNonQuery();

            command.CommandText = $"UPDATE Listeners SET MagazineWalletsIssued = CASE WHEN Magazine = 1 THEN 1 ELSE 0 END";
            command.ExecuteNonQuery();
        }
    }
}
