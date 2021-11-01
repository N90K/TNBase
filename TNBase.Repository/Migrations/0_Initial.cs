
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// Create initial database
    /// </summary>
    public class _0_Initial : SqlMigration
    {
        public _0_Initial(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [Collectors] ([Key] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Forename] text NULL, 
                    [Surname] text NULL, [Telephone] text NULL, [Postcodes] text NULL)";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [Listeners] ([Wallet] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Title] text NULL, 
                    [Forename] text NOT NULL, [Surname] text NOT NULL, [Addr1] text NULL, [Addr2] text NULL, [Town] text NULL, [County] text NULL, 
                    [Postcode] text NULL, [Magazine] bit NULL, [MemStickPlayer] bit NULL, [Telephone] text NULL, [Joined] date NULL, 
                    [Birthday] date NULL, [Info] text NULL, [Status] text DEFAULT('Active') NULL, [StatusInfo] text NULL, [In1] bigint DEFAULT(0) NULL, 
                    [In2] bigint DEFAULT(0) NULL, [In3] bigint DEFAULT(0) NULL, [In4] bigint DEFAULT(0) NULL, [In5] bigint DEFAULT(0) NULL, 
                    [In6] bigint DEFAULT(0) NULL, [In7] bigint DEFAULT(0) NULL, [In8] bigint DEFAULT(0) NULL, [Out1] bigint DEFAULT(0) NULL, 
                    [Out2] bigint DEFAULT(0) NULL, [Out3] bigint DEFAULT(0) NULL, [Out4] bigint DEFAULT(0) NULL, [Out5] bigint DEFAULT(0) NULL, 
                    [Out6] bigint DEFAULT(0) NULL, [Out7] bigint DEFAULT(0) NULL, [Out8] bigint DEFAULT(0) NULL, [DeletedDate] date NULL, 
                    [Stock] bigint DEFAULT(3) NULL, [LastIn] date NULL, [LastOut] date NULL)";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [Scans] ([Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Wallet] bigint NOT NULL, 
                    [Type] text NOT NULL, [Recorded] date DEFAULT(CURRENT_DATE) NULL)";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE UNIQUE INDEX IF NOT EXISTS [Scans_sqlite_autoindex_Scans_1] ON [Scans] ([Id] ASC)";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [WeekStats] ([WeekNumber] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                    [ScannedIn] bigint DEFAULT('0') NULL, [ScannedOut] bigint DEFAULT('0') NULL, [PausedCount] bigint DEFAULT('0') NOT NULL, 
                    [TotalListeners] bigint DEFAULT('0') NULL, [Date] date DEFAULT(CURRENT_DATE) NULL)";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS [YearStats] ([Year] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                    [StartListeners] bigint DEFAULT('0') NULL, [EndListeners] bigint DEFAULT('0') NULL, [NewListeners] bigint DEFAULT('0') NULL, 
                    [DeletedListeners] bigint DEFAULT('0') NULL, [AverageListeners] bigint DEFAULT('0') NULL, [InactiveTotal] bigint DEFAULT('0') NULL, 
                    [MagazineTotal] bigint DEFAULT('0') NULL, [AverageSent] bigint DEFAULT('0') NULL, [SentTotal] bigint DEFAULT('0') NULL, 
                    [MagazinesSent] bigint DEFAULT('0') NULL, [PercentSent] bigint DEFAULT('0') NULL, [MemStickPlayerLoanTotal] bigint DEFAULT('0') NULL, 
                    [PausedTotal] bigint DEFAULT('0') NULL, [AveragePaused] bigint DEFAULT('0') NULL, [DeletedTotal] bigint DEFAULT('0') NULL)";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE UNIQUE INDEX IF NOT EXISTS [YearStats_sqlite_autoindex_YearStats_1] ON [YearStats] ([Year] ASC)";
            command.ExecuteNonQuery();
        }
    }
}
