using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TNBase.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collectors",
                columns: table => new
                {
                    Key = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Forename = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Postcodes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectors", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Listeners",
                columns: table => new
                {
                    Wallet = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Forename = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Addr1 = table.Column<string>(type: "TEXT", nullable: true),
                    Addr2 = table.Column<string>(type: "TEXT", nullable: true),
                    Town = table.Column<string>(type: "TEXT", nullable: true),
                    County = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true),
                    Magazine = table.Column<byte[]>(type: "BOOLEAN", nullable: true),
                    MemStickPlayer = table.Column<byte[]>(type: "BOOLEAN", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    Joined = table.Column<byte[]>(type: "DATE", nullable: true),
                    Birthday = table.Column<byte[]>(type: "DATE", nullable: true),
                    Info = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true, defaultValueSql: "'Active'"),
                    StatusInfo = table.Column<string>(type: "TEXT", nullable: true),
                    In1 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In2 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In3 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In4 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In5 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In6 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In7 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    In8 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out1 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out2 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out3 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out4 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out5 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out6 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out7 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    Out8 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    DeletedDate = table.Column<byte[]>(type: "DATE", nullable: true),
                    Stock = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "3"),
                    LastIn = table.Column<byte[]>(type: "DATE", nullable: true),
                    LastOut = table.Column<byte[]>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listeners", x => x.Wallet);
                });

            migrationBuilder.CreateTable(
                name: "Scans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Wallet = table.Column<long>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Recorded = table.Column<byte[]>(type: "DATE", nullable: true, defaultValueSql: "CURRENT_DATE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekStats",
                columns: table => new
                {
                    WeekNumber = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScannedIn = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    ScannedOut = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    PausedCount = table.Column<long>(type: "INTEGER", nullable: false, defaultValueSql: "'0'"),
                    TotalListeners = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    Date = table.Column<byte[]>(type: "DATE", nullable: true, defaultValueSql: "CURRENT_DATE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekStats", x => x.WeekNumber);
                });

            migrationBuilder.CreateTable(
                name: "YearStats",
                columns: table => new
                {
                    Year = table.Column<long>(type: "INTEGER", nullable: false),
                    StartListeners = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    EndListeners = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    NewListeners = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    DeletedListeners = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    AverageListeners = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    InactiveTotal = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    MagazineTotal = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    AverageSent = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    SentTotal = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    MagazinesSent = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    PercentSent = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    MemStickPlayerLoanTotal = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    PausedTotal = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    AveragePaused = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'"),
                    DeletedTotal = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearStats", x => x.Year);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scans_Id",
                table: "Scans",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YearStats_Year",
                table: "YearStats",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collectors");

            migrationBuilder.DropTable(
                name: "Listeners");

            migrationBuilder.DropTable(
                name: "Scans");

            migrationBuilder.DropTable(
                name: "WeekStats");

            migrationBuilder.DropTable(
                name: "YearStats");
        }
    }
}
