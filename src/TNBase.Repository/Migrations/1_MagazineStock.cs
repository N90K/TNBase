using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Add magazine wallet type
    /// </summary>
    public class _1_MagazineStock : SqlMigration
    {
        public _1_MagazineStock(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"ALTER TABLE Listeners ADD MagazineStock BIGINT DEFAULT 0";
            command.ExecuteNonQuery();

            command.CommandText = $"ALTER TABLE Scans ADD WalletType TEXT NOT NULL DEFAULT 'News'";
            command.ExecuteNonQuery();
        }
    }
}
