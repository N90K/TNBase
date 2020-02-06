using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TNBase.DataStorage.Test.Migrations
{
    [TestClass]
    public class DatabaseUpdaterTests
    {
        [TestMethod]
        public void Update_ShouldCreateMigrationsTable_WhenNotExists()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder.Build();
                updater.Update();

                Assert.IsTrue(builder.DatabaseMigrationsTableExists());
            }
        }

        [TestMethod]
        public void Update_ShouldSkipCreatingMigrationsTable_WhenOneExists()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder
                    .WithDatabaseMigrationsTable()
                    .Build();
                updater.Update();
            }
        }

        [TestMethod]
        public void Update_ShouldApplyAllMigrations_WhenNoneApplied()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder.Build();
                updater.Update();

                var migrations = builder.GetDatabaseMigrations();
                Assert.AreEqual(3, migrations.Count());
            }
        }

        [TestMethod]
        public void Update_ShouldApplyMigrationsInCorrectOrder()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder.Build();
                updater.Update();

                var migrations = builder.GetDatabaseMigrations();
                Assert.AreEqual(1, migrations.ElementAt(0).Version);
                Assert.AreEqual(2, migrations.ElementAt(1).Version);
                Assert.AreEqual(10, migrations.ElementAt(2).Version);
            }
        }

        [TestMethod]
        public void Update_ShouldApplyCorrectMigrationName()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder.Build();
                updater.Update();

                var migrations = builder.GetDatabaseMigrations();
                Assert.AreEqual("TestSqlMigrationOne", migrations.ElementAt(0).Name);
                Assert.AreEqual("TestSqlMigrationTwo", migrations.ElementAt(1).Name);
                Assert.AreEqual("TestSqlMigrationTen", migrations.ElementAt(2).Name);
            }
        }

        [TestMethod]
        public void Update_ShouldUseCurrentTime_WhenApplyingMigration()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder.Build();

                var before = DateTime.UtcNow;
                updater.Update();
                var after = DateTime.UtcNow;

                var migrations = builder.GetDatabaseMigrations();
                Assert.IsTrue(before <= migrations.ElementAt(0).CreateDate, "Date is greater or equal to before");
                Assert.IsTrue(after >= migrations.ElementAt(0).CreateDate, "Date is less or equal to after");
            }
        }

        [TestMethod]
        public void Update_ShouldApplyOnlyNewMigrations_WhenSomeAreApplied()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder
                    .WithDatabaseMigrationsTable()
                    .WithMigrations(1, "TestSqlMigrationOne")
                    .WithMigrations(2, "TestSqlMigrationTwo")
                    .WithMigrationTestTable()
                    .Build();
                updater.Update();

                var migrations = builder.GetDatabaseMigrations();
                Assert.AreEqual(3, migrations.Count());
                Assert.AreEqual(10, migrations.Last().Version);
            }
        }

        [TestMethod]
        public void Update_ShouldDoNothing_WhenDatabaseUpToDate()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder
                    .WithDatabaseMigrationsTable()
                    .WithMigrations(12, "TestSqlMigrationTwelve")
                    .WithMigrationTestTable()
                    .Build();
                updater.Update();

                var migrations = builder.GetDatabaseMigrations();
                Assert.AreEqual(1, migrations.Count());
            }
        }

        [TestMethod]
        public void Update_ShouldExecuteUpMethod_WhenApplyingMigration()
        {
            using (var builder = new DatabaseUpdaterBuilder())
            {
                var updater = builder.Build();
                updater.Update();

                var testData = builder.ReadMigrationTestTable();
                Assert.AreEqual("Migration 2 Applied", testData.Test1);
                Assert.AreEqual("Migration 10 Applied", testData.Test2);
            }
        }
    }
}
