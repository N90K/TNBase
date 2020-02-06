using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using TNBase.DataStorage.Test.TestHelpers;
using TNBase.Objects;
using System.Collections.Generic;

namespace TNBase.DataStorage.Test
{
    [TestClass]
    public class RepoStorage_Tests
    {
        SQLiteConnection connection = null;
        RepositoryLayer repoLayer = new RepositoryLayer();

        [TestInitialize]
        public void Setup()
        {
            // setup connection
            if (connection == null)
            {
                connection = new SQLiteConnection(DBUtils.GenConnectionString(":memory:"));
                connection.Open();
                DatabaseHelper.CreateDatabase(connection);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        [TestMethod]
        public void Repo_Listener_Tests()
        {
            Listener toInsert = CreateExtensions.DummyListener();

            // Insert the listener
            int retWallet = repoLayer.InsertListener(connection, toInsert);
            Assert.AreEqual(1, retWallet);

            // Edit and re-insert.
            toInsert.Forename = "New";
            toInsert.Surname = "Man";
            toInsert.Wallet = 2;
            retWallet = repoLayer.InsertListener(connection, toInsert);
            Assert.AreEqual(2, retWallet);

            // Check the results
            List<Listener> results = repoLayer.GetListeners(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyListener().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            toInsert.Forename = "Updated";
            repoLayer.UpdateListener(connection, toInsert);

            // Check the results
            results = repoLayer.GetListeners(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyListener().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteListener(connection, results[0]);

            // Check the results
            results = repoLayer.GetListeners(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(toInsert.Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_Collector_Tests()
        {
            Collector toInsert = CreateExtensions.DummyCollector();

            // Insert the collector
            repoLayer.InsertCollector(connection, toInsert);

            // Edit and re-insert.
            toInsert.Forename = "New";
            toInsert.Surname = "Man";
            toInsert.ID = 2;
            repoLayer.InsertCollector(connection, toInsert);

            // Check the results
            List<Collector> results = repoLayer.GetCollectors(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyCollector().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            results[1].Forename = "Updated";
            Collector updated = results[1];
            repoLayer.UpdateCollector(connection, updated);

            // Check the results
            results = repoLayer.GetCollectors(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyCollector().Serialize(), results[0].Serialize());
            Assert.AreEqual(updated.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteCollector(connection, results[1]);

            // Check the results
            results = repoLayer.GetCollectors(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(CreateExtensions.DummyCollector().Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_YearStats_Tests()
        {
            YearStats toInsert = CreateExtensions.DummyYearStats();

            // Insert the year stats
            repoLayer.InsertYearStats(connection, toInsert);

            // Edit and re-insert.
            toInsert.MemStickPlayerLoanTotal = 1000;
            toInsert.Year = 2017;
            repoLayer.InsertYearStats(connection, toInsert);

            // Check the results
            List<YearStats> results = repoLayer.GetYearStats(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyYearStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            results[1].AvListeners = 19;
            YearStats updated = results[1];
            repoLayer.UpdateYearStats(connection, updated);

            // Check the results
            results = repoLayer.GetYearStats(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyYearStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(updated.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteYearStats(connection, results[1]);

            // Check the results
            results = repoLayer.GetYearStats(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(CreateExtensions.DummyYearStats().Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_WeekStats_Tests()
        {
            WeeklyStats toInsert = CreateExtensions.DummyWeekStats();

            // Insert the weekly stats
            repoLayer.InsertWeeklyStats(connection, toInsert);

            // Edit and re-insert.
            toInsert.TotalListeners = 1000;
            toInsert.WeekNumber = 2;
            repoLayer.InsertWeeklyStats(connection, toInsert);

            // Check the results
            List<WeeklyStats> results = repoLayer.GetWeeklyStats(connection);
            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(CreateExtensions.DummyWeekStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(toInsert.Serialize(), results[1].Serialize());

            // Update one of the listeners
            results[1].ScannedOut = 19;
            WeeklyStats updated = results[1];
            repoLayer.UpdateWeeklyStats(connection, updated);

            // Check the results
            results = repoLayer.GetWeeklyStats(connection);
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(CreateExtensions.DummyWeekStats().Serialize(), results[0].Serialize());
            Assert.AreEqual(updated.Serialize(), results[1].Serialize());

            // Delete a listener
            repoLayer.DeleteWeeklyStats(connection, results[1]);

            // Check the results
            results = repoLayer.GetWeeklyStats(connection);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(CreateExtensions.DummyWeekStats().Serialize(), results[0].Serialize());
        }

        [TestMethod]
        public void Repo_NextFreeIndex_Tests()
        {
            Listener toInsert = CreateExtensions.DummyListener();
            toInsert.Wallet = 1;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 2;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 3;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 4;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 5;
            repoLayer.InsertListener(connection, toInsert);

            Assert.AreEqual(6, repoLayer.CalculateNextFreeWallet(connection));

            toInsert.Wallet = 6;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 8;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 9;
            repoLayer.InsertListener(connection, toInsert);
            toInsert.Wallet = 11;
            repoLayer.InsertListener(connection, toInsert);

            Assert.AreEqual(7, repoLayer.CalculateNextFreeWallet(connection));
        }

        [TestMethod]
        public void Repo_ClearAllData()
        {
            repoLayer.InsertCollector(connection, CreateExtensions.DummyCollector());
            repoLayer.InsertListener(connection, CreateExtensions.DummyListener());
            repoLayer.InsertWeeklyStats(connection, CreateExtensions.DummyWeekStats());
            repoLayer.InsertYearStats(connection, CreateExtensions.DummyYearStats());

            Assert.AreEqual(1, repoLayer.GetListeners(connection).Count);
            Assert.AreEqual(1, repoLayer.GetCollectors(connection).Count);
            Assert.AreEqual(1, repoLayer.GetWeeklyStats(connection).Count);
            Assert.AreEqual(1, repoLayer.GetYearStats(connection).Count);

            repoLayer.ClearAllData(connection);

            Assert.AreEqual(0, repoLayer.GetListeners(connection).Count);
            Assert.AreEqual(0, repoLayer.GetCollectors(connection).Count);
            Assert.AreEqual(0, repoLayer.GetWeeklyStats(connection).Count);
            Assert.AreEqual(0, repoLayer.GetYearStats(connection).Count);
        }

        [TestMethod]
        public void Repo_TestScans()
        {
            Assert.AreEqual(0, repoLayer.GetScanRecords(connection).Count);

            Scan temp = new Scan();
            temp.Wallet = 10;
            temp.ScanType = ScanTypes.OUT;
            temp.WalletType = WalletTypes.Magazine;

            repoLayer.InsertScan(connection, temp);

            Assert.AreEqual(1, repoLayer.GetScanRecords(connection).Count);

            Assert.AreEqual(10, repoLayer.GetScanRecords(connection)[0].Wallet);
            Assert.AreEqual(ScanTypes.OUT, repoLayer.GetScanRecords(connection)[0].ScanType);
            Assert.AreEqual(WalletTypes.Magazine, repoLayer.GetScanRecords(connection)[0].WalletType);

            repoLayer.DeleteScans(connection, 10);

            Assert.AreEqual(0, repoLayer.GetScanRecords(connection).Count);
        }
    }
}
