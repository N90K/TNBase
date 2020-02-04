using System;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public class _1_Initial : SqlMigration
    {
        public _1_Initial(SQLiteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"ALTER TABLE Listeners ADD MagazineStock BIGINT DEFAULT 0";
                command.ExecuteNonQuery();

                command.CommandText = $"ALTER TABLE Scans ADD WalletType TEXT NOT NULL DEFAULT 'News'";
                command.ExecuteNonQuery();
            }
        }
    }
}
