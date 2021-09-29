using System;
using System.Linq;
using TNBase.Objects;
using Xunit;

namespace TNBase.Repository.UnitTests
{
    public class DatabaseUpdaterTests
    {
        [Fact]
        public void Update_ShouldCreateMigrationsTable_WhenNotExists()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder.Build();

            updater.Update();

            Assert.True(builder.DatabaseMigrationsTableExists());
        }

        [Fact]
        public void Update_ShouldSkipCreatingMigrationsTable_WhenOneExists()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder
                .WithDatabaseMigrationsTable()
                .Build();

            updater.Update();

            // Should not throw an exception
        }

        [Fact]
        public void Update_ShouldApplyAllMigrations_WhenNoneApplied()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder.Build();

            updater.Update();

            var migrations = builder.GetDatabaseMigrations();
            Assert.Equal(3, migrations.Count());
        }

        [Fact]
        public void Update_ShouldApplyMigrationsInCorrectOrder()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder.Build();

            updater.Update();

            var migrations = builder.GetDatabaseMigrations();
            Assert.Equal(1, migrations.ElementAt(0).Version);
            Assert.Equal(2, migrations.ElementAt(1).Version);
            Assert.Equal(10, migrations.ElementAt(2).Version);
        }

        [Fact]
        public void Update_ShouldApplyCorrectMigrationName()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder.Build();

            updater.Update();

            var migrations = builder.GetDatabaseMigrations();
            Assert.Equal("TestSqlMigrationOne", migrations.ElementAt(0).Name);
            Assert.Equal("TestSqlMigrationTwo", migrations.ElementAt(1).Name);
            Assert.Equal("TestSqlMigrationTen", migrations.ElementAt(2).Name);
        }

        [Fact]
        public void Update_ShouldUseCurrentTime_WhenApplyingMigration()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder.Build();

            var before = DateTime.UtcNow.TruncateMilliseconds();
            updater.Update();
            var after = DateTime.UtcNow;

            var migrations = builder.GetDatabaseMigrations();
            Assert.True(before <= migrations.ElementAt(0).CreateDate, "Date is greater or equal to before");
            Assert.True(after >= migrations.ElementAt(0).CreateDate, "Date is less or equal to after");
        }

        [Fact]
        public void Update_ShouldApplyOnlyNewMigrations_WhenSomeAreApplied()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder
                .WithDatabaseMigrationsTable()
                .WithMigration(1, "TestSqlMigrationOne")
                .WithMigration(2, "TestSqlMigrationTwo")
                .WithMigrationTestTable()
                .Build();

            updater.Update();

            var migrations = builder.GetDatabaseMigrations();
            Assert.Equal(3, migrations.Count());
            Assert.Equal(10, migrations.Last().Version);
        }

        [Fact]
        public void Update_ShouldDoNothing_WhenDatabaseUpToDate()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder
                .WithDatabaseMigrationsTable()
                .WithMigration(12, "TestSqlMigrationTwelve")
                .WithMigrationTestTable()
                .Build();

            updater.Update();

            var migrations = builder.GetDatabaseMigrations();
            Assert.Single(migrations);
        }

        [Fact]
        public void Update_ShouldExecuteUpMethod_WhenApplyingMigration()
        {
            using var builder = new DatabaseUpdaterBuilder();
            var updater = builder.Build();

            updater.Update();

            var testData = builder.ReadMigrationTestTable();
            Assert.Equal("Migration 2 Applied", testData.Test1);
            Assert.Equal("Migration 10 Applied", testData.Test2);
        }
    }
}
