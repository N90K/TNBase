
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Field to indicate that the user should be warned of the address change
    /// </summary>
    public class _5_WarnOfAddressChange : SqlMigration
    {
        public _5_WarnOfAddressChange(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = $"ALTER TABLE Listeners ADD WarnOfAddressChange BIT DEFAULT 0";
            command.ExecuteNonQuery();
        }
    }
}
