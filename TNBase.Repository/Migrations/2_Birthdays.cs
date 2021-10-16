
using Microsoft.Data.Sqlite;

namespace TNBase.Repository.Migrations
{
    /// <summary>
    /// This migration replaces Birthday date column of the Listeners table 
    /// to two separate BirthdayDate and BirthdayMonth comumns of integer type
    /// </summary>
    public class _2_Birthdays : SqlMigration
    {
        public _2_Birthdays(SqliteConnection connection) : base(connection)
        { }

        public override void Up()
        {
            using var command = connection.CreateCommand();

            command.CommandText = @"CREATE TEMPORARY TABLE [Listeners_Backup] (
                                              [Wallet] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
                                            , [Title] text NULL
                                            , [Forename] text NOT NULL
                                            , [Surname] text NOT NULL
                                            , [Addr1] text NULL
                                            , [Addr2] text NULL
                                            , [Town] text NULL
                                            , [County] text NULL
                                            , [Postcode] text NULL
                                            , [Magazine] bit NULL
                                            , [MemStickPlayer] bit NULL
                                            , [Telephone] text NULL
                                            , [Joined] date NULL
                                            , [Birthday] date NULL
                                            , [Info] text NULL
                                            , [Status] text DEFAULT ('Active') NULL
                                            , [StatusInfo] text NULL
                                            , [In1] bigint DEFAULT (0) NULL
                                            , [In2] bigint DEFAULT (0) NULL
                                            , [In3] bigint DEFAULT (0) NULL
                                            , [In4] bigint DEFAULT (0) NULL
                                            , [In5] bigint DEFAULT (0) NULL
                                            , [In6] bigint DEFAULT (0) NULL
                                            , [In7] bigint DEFAULT (0) NULL
                                            , [In8] bigint DEFAULT (0) NULL
                                            , [Out1] bigint DEFAULT (0) NULL
                                            , [Out2] bigint DEFAULT (0) NULL
                                            , [Out3] bigint DEFAULT (0) NULL
                                            , [Out4] bigint DEFAULT (0) NULL
                                            , [Out5] bigint DEFAULT (0) NULL
                                            , [Out6] bigint DEFAULT (0) NULL
                                            , [Out7] bigint DEFAULT (0) NULL
                                            , [Out8] bigint DEFAULT (0) NULL
                                            , [DeletedDate] date NULL
                                            , [Stock] bigint DEFAULT (3) NULL
                                            , [LastIn] date NULL
                                            , [LastOut] date NULL
                                            , [MagazineStock] bigint DEFAULT (0) NULL
                                        );
                                        INSERT INTO [Listeners_Backup] SELECT [Wallet]
                                            ,[Title]
                                            ,[Forename]
                                            ,[Surname]
                                            ,[Addr1]
                                            ,[Addr2]
                                            ,[Town]
                                            ,[County]
                                            ,[Postcode]
                                            ,[Magazine]
                                            ,[MemStickPlayer]
                                            ,[Telephone]
                                            ,[Joined]
                                            ,[Birthday]
                                            ,[Info]
                                            ,[Status]
                                            ,[StatusInfo]
                                            ,[In1]
                                            ,[In2]
                                            ,[In3]
                                            ,[In4]
                                            ,[In5]
                                            ,[In6]
                                            ,[In7]
                                            ,[In8]
                                            ,[Out1]
                                            ,[Out2]
                                            ,[Out3]
                                            ,[Out4]
                                            ,[Out5]
                                            ,[Out6]
                                            ,[Out7]
                                            ,[Out8]
                                            ,[DeletedDate]
                                            ,[Stock]
                                            ,[LastIn]
                                            ,[LastOut]
                                            ,[MagazineStock]
                                        FROM [Listeners];
                                        DROP TABLE [Listeners];
                                        CREATE TABLE [Listeners] (
                                              [Wallet] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
                                            , [Title] text NULL
                                            , [Forename] text NOT NULL
                                            , [Surname] text NOT NULL
                                            , [Addr1] text NULL
                                            , [Addr2] text NULL
                                            , [Town] text NULL
                                            , [County] text NULL
                                            , [Postcode] text NULL
                                            , [Magazine] bit NULL
                                            , [MemStickPlayer] bit NULL
                                            , [Telephone] text NULL
                                            , [Joined] date NULL
                                            , [Info] text NULL
                                            , [Status] text DEFAULT ('Active') NULL
                                            , [StatusInfo] text NULL
                                            , [In1] bigint DEFAULT (0) NULL
                                            , [In2] bigint DEFAULT (0) NULL
                                            , [In3] bigint DEFAULT (0) NULL
                                            , [In4] bigint DEFAULT (0) NULL
                                            , [In5] bigint DEFAULT (0) NULL
                                            , [In6] bigint DEFAULT (0) NULL
                                            , [In7] bigint DEFAULT (0) NULL
                                            , [In8] bigint DEFAULT (0) NULL
                                            , [Out1] bigint DEFAULT (0) NULL
                                            , [Out2] bigint DEFAULT (0) NULL
                                            , [Out3] bigint DEFAULT (0) NULL
                                            , [Out4] bigint DEFAULT (0) NULL
                                            , [Out5] bigint DEFAULT (0) NULL
                                            , [Out6] bigint DEFAULT (0) NULL
                                            , [Out7] bigint DEFAULT (0) NULL
                                            , [Out8] bigint DEFAULT (0) NULL
                                            , [DeletedDate] date NULL
                                            , [Stock] bigint DEFAULT (3) NULL
                                            , [LastIn] date NULL
                                            , [LastOut] date NULL
                                            , [MagazineStock] bigint DEFAULT (0) NULL
                                            , [BirthdayDay] int DEFAULT (null) NULL
                                            , [BirthdayMonth] int DEFAULT (null) NULL
                                        );
                                        INSERT INTO [Listeners] SELECT [Wallet]
                                            ,[Title]
                                            ,[Forename]
                                            ,[Surname]
                                            ,[Addr1]
                                            ,[Addr2]
                                            ,[Town]
                                            ,[County]
                                            ,[Postcode]
                                            ,[Magazine]
                                            ,[MemStickPlayer]
                                            ,[Telephone]
                                            ,[Joined]
                                            ,[Info]
                                            ,[Status]
                                            ,[StatusInfo]
                                            ,[In1]
                                            ,[In2]
                                            ,[In3]
                                            ,[In4]
                                            ,[In5]
                                            ,[In6]
                                            ,[In7]
                                            ,[In8]
                                            ,[Out1]
                                            ,[Out2]
                                            ,[Out3]
                                            ,[Out4]
                                            ,[Out5]
                                            ,[Out6]
                                            ,[Out7]
                                            ,[Out8]
                                            ,[DeletedDate]
                                            ,[Stock]
                                            ,[LastIn]
                                            ,[LastOut]
                                            ,[MagazineStock]
                                            ,SUBSTR([Birthday], 9, 2)
                                            ,SUBSTR([Birthday], 6, 2)
                                        FROM Listeners_Backup;
                                        DROP TABLE Listeners_Backup;";
            command.ExecuteNonQuery();
        }
    }
}
