using Microsoft.VisualStudio.TestTools.UnitTesting;
using TNBase.DataStorage.Test.TestHelpers;
using TNBase.Objects;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace TNBase.DataStorage.Test
{
    [TestClass]
    public class ServiceLayer_Tests
    {
        ServiceLayer serviceLayer;
        IRepositoryLayer repoLayer;

        [TestInitialize]
        public void Setup()
        {
            repoLayer = new RepositoryLayer();
            serviceLayer = new ServiceLayer(":memory:", repoLayer);
            DatabaseHelper.CreateDatabase(serviceLayer.GetConnection());
            // Insert some data.
            InsertListeners();
            InsertCollectors();
            InsertWeeklyStats();
            InsertYearStats();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clear data
            repoLayer.ClearAllData(serviceLayer.GetConnection());
            serviceLayer.GetConnection().Close();
        }

        /// <summary>
        /// Insert example year stats
        /// </summary>
        private void InsertYearStats()
        {
            YearStats y1 = new YearStats() { AveragePaused = 1, AverageSent = 2, AvListeners = 3, DeletedListeners = 4, DeletedTotal = 5, EndListeners = 6, InactiveTotal = 7, MagazinesSent = 8, MagazineTotal = 9, MemStickPlayerLoanTotal = 10, NewListeners = 11, PausedTotal = 12, PercentSent = 13, SentTotal = 14, StartListeners = 15, Year = 2016 };
            serviceLayer.SaveYearStats(y1);
            YearStats y2 = new YearStats() { AveragePaused = 21, AverageSent = 22, AvListeners = 23, DeletedListeners = 24, DeletedTotal = 25, EndListeners = 26, InactiveTotal = 27, MagazinesSent = 28, MagazineTotal = 29, MemStickPlayerLoanTotal = 30, NewListeners = 31, PausedTotal = 32, PercentSent = 33, SentTotal = 34, StartListeners = 35, Year = 2017 };
            serviceLayer.SaveYearStats(y2);
        }

        /// <summary>
        /// Insert example weekly stats.
        /// </summary>
        private void InsertWeeklyStats()
        {
            // Add past stats
            WeeklyStats p1 = new WeeklyStats() { WeekNumber = 1, PausedCount = 4, ScannedIn = 4, ScannedOut = 4, TotalListeners = 4, WeekDate = DateTime.Parse("01/01/2009") };
            serviceLayer.SaveWeekStats(p1);
            WeeklyStats p2 = new WeeklyStats() { WeekNumber = 2, PausedCount = 5, ScannedIn = 5, ScannedOut = 4, TotalListeners = 5, WeekDate = DateTime.Parse("12/12/2009") };
            serviceLayer.SaveWeekStats(p2);

            // Add some stats
            WeeklyStats w1 = new WeeklyStats() { WeekNumber = 3, PausedCount = 1, ScannedIn = 10, ScannedOut = 10, TotalListeners = 15, WeekDate = DateTime.Now };
            serviceLayer.SaveWeekStats(w1);
            WeeklyStats w2 = new WeeklyStats() { WeekNumber = 4, PausedCount = 2, ScannedIn = 15, ScannedOut = 12, TotalListeners = 16, WeekDate = DateTime.Now };
            serviceLayer.SaveWeekStats(w2);
            WeeklyStats w3 = new WeeklyStats() { WeekNumber = 5, PausedCount = 3, ScannedIn = 20, ScannedOut = 14, TotalListeners = 17, WeekDate = DateTime.Now };
            serviceLayer.SaveWeekStats(w3);
        }

        /// <summary>
        /// Insert example collectors
        /// </summary>
        private void InsertCollectors()
        {
            // Add some collectors
            Collector c1 = new Collector() { ID = 1, Number = "01234", Forename = "Ted", Surname = "Dob", Postcodes = "N7N [A-C],N78 [S-T]" };
            serviceLayer.AddCollector(c1);
            Collector c2 = new Collector() { ID = 1, Number = "02324", Forename = "Yov", Surname = "Vid", Postcodes = "N1BB,N192 [A-C]" };
            serviceLayer.AddCollector(c2);
        }

        /// <summary>
        /// Insert exaple listeners
        /// </summary>
        private void InsertListeners()
        {
            // Add some active listeners
            Listener l1 = new Listener() { Title = "Mr", Forename = "John", Surname = "Biddle", Addr1 = "1 Park Avenue", Addr2 = "", County = "London", Postcode = "N7 NDF", Town = "Camden", Telephone = "01234 423 232", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = false, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-2), Wallet = 1, inOutRecords = new InOutRecords() };
            serviceLayer.AddListener(l1);
            Listener l2 = new Listener() { Title = "Miss", Forename = "Sarah", Surname = "Jones", Addr1 = "40 Camden Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 2, inOutRecords = new InOutRecords() };
            serviceLayer.AddListener(l2);

            // Add a deleted listener
            Listener l3 = new Listener() { Title = "Doctor", Forename = "Nigel", Surname = "Sarage", Addr1 = "4 Bad Lane", Addr2 = "Topal", County = "Coart", Postcode = "N7 8DD", Town = "Rhywr", Telephone = "01435 643633", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 3, inOutRecords = new InOutRecords() };
            // TODO (L) Improve/Change the delete method!
            serviceLayer.SoftDeleteListener(l3, "Test");
            serviceLayer.AddListener(l3);

            // Add a paused listener
            Listener l4 = new Listener() { Title = "Mrs", Forename = "Lazy", Surname = "Bones", Addr1 = "4 Bone Road", Addr2 = "Scel", County = "Etal", Postcode = "N19 2DD", Town = "Death", Telephone = "01435 643433", Stock = 3, Info = "", Joined = DateTime.Now.AddDays(-425), MemStickPlayer = false, Magazine = false, Status = ListenerStates.ACTIVE, StatusInfo = "", Wallet = 4, inOutRecords = new InOutRecords() };
            l4.Pause(DateTime.Now);
            serviceLayer.AddListener(l4);
        }

        /// <summary>
        /// Get the listeners at some year start
        /// </summary>
        [TestMethod]
        public void Stats_GetListenersAtYearStart()
        {
            serviceLayer.GetListenersAtYearStart(2010).Should().Be(5);
        }

        /// <summary>
        /// Get the weekly listeners as of today
        /// </summary>
        [TestMethod]
        public void Stats_WeeklyListenersToday()
        {
            serviceLayer.GetCurrentListenerCount().Should().Be(3);
        }

        /// <summary>
        /// Test the new listeners this year
        /// </summary>
        [TestMethod]
        public void Stats_NewListenersThisYear()
        {
            // Two of the listeners joined today
            serviceLayer.GetNewListenersForYear(DateTime.Now.Year).Should().Be(2);
        }

        /// <summary>
        /// Test the unsent wallets
        /// </summary>
        [TestMethod]
        public void Stats_UnsentWallets()
        {
            serviceLayer.GetUnsentListeners().Count.Should().Be(3);
        }

        /// <summary>
        /// Inactive wallets (not available for use)
        /// </summary>
        [Ignore]
        [TestMethod]
        public void Stats_InactiveWallets()
        {
            // TODO (L) Implement Stats_InactiveWallets
            throw new NotImplementedException();
        }

        /// <summary>
        /// Test the deleted listeners this year
        /// </summary>
        [TestMethod]
        public void Stats_DeletedListenersThisYear()
        {
            serviceLayer.GetLostListenersForYear(DateTime.Now.Year).Should().Be(1);
        }

        /// <summary>
        /// Test the net change of listeners this year
        /// </summary>
        [TestMethod]
        public void Stats_NetListenersThisYear()
        {
            serviceLayer.GetNetListenersForYear(DateTime.Now.Year).Should().Be(1);
        }

        /// <summary>
        /// Test the current week number method
        /// </summary>
        [TestMethod]
        public void GetCurrentWeekNumber()
        {
            serviceLayer.GetCurrentWeekNumber().Should().Be(5);
        }

        /// <summary>
        /// Test the current week number (should be new week) method
        /// </summary>
        [TestMethod]
        public void GetCurrentWeekNumber_ShouldBeNewWeek()
        {
            List<WeeklyStats> stats = repoLayer.GetWeeklyStats(serviceLayer.GetConnection());
            repoLayer.ClearWeeklyStats(serviceLayer.GetConnection());

            foreach (WeeklyStats stat in stats)
            {
                stat.WeekDate = stat.WeekDate.AddDays(-8);
                repoLayer.InsertWeeklyStats(serviceLayer.GetConnection(), stat);
            }

            serviceLayer.GetCurrentWeekNumber().Should().Be(6);
        }

        /// <summary>
        /// Test the paused wallets count
        /// </summary>
        [TestMethod]
        public void Stats_TotalStoppedWallets()
        {
            serviceLayer.GetStoppedListeners().Count.Should().Be(1);
        }

        /// <summary>
        /// Get the average number of stopped wallets
        /// </summary>
        [TestMethod]
        public void Stats_AverageStoppedWallets()
        {
            serviceLayer.GetAveragePausedWallets(DateTime.Now.Year).Should().Be(2);
        }

        /// <summary>
        /// Gets the inactive listeners (Listeners that have been inactive for over 3 months)
        /// </summary>
        [TestMethod]
        public void Stats_InactiveListeners()
        {
            serviceLayer.Get3MonthInactiveListeners().Should().Be(1);
        }

        /// <summary>
        /// Get a count of the memory stick players on loans
        /// </summary>
        [TestMethod]
        public void Stats_MemoryStickPlayersOnLoan()
        {
            serviceLayer.GetMemorySticksOnLoan().Should().Be(1);
        }

        /// <summary>
        /// Test the average wallets sent per week
        /// </summary>
        [TestMethod]
        public void Stats_AverageWalletsSentPerWeek()
        {
            serviceLayer.GetAverageDispatchedWallets(DateTime.Now.Year).Should().Be(12);
        }

        /// <summary>
        /// Total wallets dispatched (sent) for a year.
        /// </summary>
        [TestMethod]
        public void Stats_TotalWalletsSentForYear()
        {
            serviceLayer.GetWalletsDispatchedForYear(DateTime.Now.Year).Should().Be(81);
        }

        /// <summary>
        /// Get the average listeners per week
        /// </summary>
        [TestMethod]
        public void Stats_AverageListenersPerWeek()
        {
            serviceLayer.GetAverageListenersForYear(DateTime.Now.Year).Should().Be(16);
        }

        // TODO (H) Implement Stats other tests.

        /// <summary>
        /// Test the memory sticks on loan
        /// </summary>
        [TestMethod]
        public void Stats_MemorySticksOnLoan()
        {
            serviceLayer.GetMemorySticksOnLoan().Should().Be(1);
        }

        /// <summary>
        /// Test the current listener count
        /// </summary>
        [TestMethod]
        public void Stats_CurrentListenerCount()
        {
            serviceLayer.GetCurrentListenerCount().Should().Be(3);
        }

        /// <summary>
        /// Get listener by name tests.
        /// </summary>
        [TestMethod]
        public void ServiceLayer_GetListenerByName()
        {
            Listener l5 = new Listener() { Title = "Miss", Forename = "Other", Surname = "Jones", Addr1 = "40 Camden Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 5 };
            serviceLayer.AddListener(l5);

            Assert.AreEqual(1, serviceLayer.GetListenersByName("John", "Biddle").Count);
            Assert.AreEqual(0, serviceLayer.GetListenersByName("John", "Biddle", "Master").Count);
            Assert.AreEqual(1, serviceLayer.GetListenersByName("Sarah", "Jones", "Miss").Count);
            Assert.AreEqual(2, serviceLayer.GetListenersByName("*", "Jones").Count);
        }

        /// <summary>
        /// Get birthdays next week test.
        /// </summary>
        [TestMethod]
        public void ServiceLayer_GetNextWeeksBirthdays()
        {
            Assert.AreEqual(0, serviceLayer.GetNextWeekBirthdays().Count);
        }

        /// <summary>
        /// Test our cleanup works.
        /// </summary>
        [TestMethod]
        public void ServiceLayer_CleanUpDates()
        {
            // Insert a listener with a invalid dates
            int listenerId = 332;
            Listener l2 = new Listener() { Title = "Miss", Forename = "Clean", Surname = "Dates", Addr1 = "40 Clean Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = false, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", Wallet = listenerId, Birthday = DateTime.Parse("01/01/1000"), DeletedDate = DateTime.Parse("01/01/1000"), LastIn = DateTime.Parse("01/01/1000"), LastOut = DateTime.Parse("01/01/1000") };
            repoLayer.InsertListener(serviceLayer.GetConnection(), l2);

            // Get the listener.
            Listener retrieved = serviceLayer.GetListenerById(listenerId);

            // Check the dates are invalid!
            Assert.IsTrue(retrieved.Birthday.Value < DBUtils.AppMinDate());
            Assert.IsTrue(retrieved.DeletedDate.Value < DBUtils.AppMinDate());
            Assert.IsTrue(retrieved.LastOut.Value < DBUtils.AppMinDate());
            Assert.IsTrue(retrieved.LastIn.Value < DBUtils.AppMinDate());

            // Clean them up
            serviceLayer.CleanUpDates();

            // Get the updated listener.
            Listener updated = serviceLayer.GetListenerById(listenerId);

            // Check they are now valid
            Assert.IsFalse(updated.Birthday.HasValue);
            Assert.IsFalse(updated.DeletedDate.HasValue);
            Assert.IsFalse(updated.LastOut.HasValue);
            Assert.IsFalse(updated.LastIn.HasValue);
        }

        /// <summary>
        /// Test the in/out updating!
        /// </summary>
        [TestMethod]
        public void ServiceLayer_UpdateInOuts()
        {
            Listener l1 = serviceLayer.GetListenerById(1);
            l1.inOutRecords.In8 = 1;
            l1.inOutRecords.In4 = 1;
            l1.inOutRecords.Out5 = 1;
            repoLayer.UpdateListener(serviceLayer.GetConnection(), l1);

            // Refresh
            l1 = serviceLayer.GetListenerById(1);

            Assert.AreEqual(1, l1.inOutRecords.In8);
            Assert.AreEqual(0, l1.inOutRecords.In7);
            Assert.AreEqual(0, l1.inOutRecords.In6);
            Assert.AreEqual(0, l1.inOutRecords.In5);
            Assert.AreEqual(1, l1.inOutRecords.In4);
            Assert.AreEqual(0, l1.inOutRecords.In3);
            Assert.AreEqual(0, l1.inOutRecords.In2);
            Assert.AreEqual(0, l1.inOutRecords.In1);
            Assert.AreEqual(0, l1.inOutRecords.Out8);
            Assert.AreEqual(0, l1.inOutRecords.Out7);
            Assert.AreEqual(0, l1.inOutRecords.Out6);
            Assert.AreEqual(1, l1.inOutRecords.Out5);
            Assert.AreEqual(0, l1.inOutRecords.Out4);
            Assert.AreEqual(0, l1.inOutRecords.Out3);
            Assert.AreEqual(0, l1.inOutRecords.Out2);
            Assert.AreEqual(0, l1.inOutRecords.Out1);

            serviceLayer.UpdateListenerInOuts();

            // Refresh
            l1 = serviceLayer.GetListenerById(1);

            Assert.AreEqual(0, l1.inOutRecords.In8);
            Assert.AreEqual(1, l1.inOutRecords.In7);
            Assert.AreEqual(0, l1.inOutRecords.In6);
            Assert.AreEqual(0, l1.inOutRecords.In5);
            Assert.AreEqual(0, l1.inOutRecords.In4);
            Assert.AreEqual(1, l1.inOutRecords.In3);
            Assert.AreEqual(0, l1.inOutRecords.In2);
            Assert.AreEqual(0, l1.inOutRecords.In1);
            Assert.AreEqual(1, l1.inOutRecords.Out8); // Will be 1 as they are an active listener
            Assert.AreEqual(0, l1.inOutRecords.Out7);
            Assert.AreEqual(0, l1.inOutRecords.Out6);
            Assert.AreEqual(0, l1.inOutRecords.Out5);
            Assert.AreEqual(1, l1.inOutRecords.Out4);
            Assert.AreEqual(0, l1.inOutRecords.Out3);
            Assert.AreEqual(0, l1.inOutRecords.Out2);
            Assert.AreEqual(0, l1.inOutRecords.Out1);
        }

        [TestMethod]
        public void ServiceLayer_RunCommand()
        {
            int firstCount = serviceLayer.GetListeners().Count;
            serviceLayer.RunCommand("DELETE FROM Listeners WHERE Wallet = 1;");
            Assert.AreEqual(firstCount - 1, serviceLayer.GetListeners().Count);
        }

        /// <summary>
        /// Get the collector for a listener.
        /// </summary>
        [TestMethod]
        public void ServiceLayer_CollectorForListener()
        {
            Listener l1 = serviceLayer.GetListenerById(1);
            Listener l2 = serviceLayer.GetListenerById(2);
            Listener l3 = serviceLayer.GetListenerById(3);
            Collector c1 = serviceLayer.GetCollectorForListener(l1);
            Assert.AreEqual("Ted", c1.Forename);
            Collector c2 = serviceLayer.GetCollectorForListener(l2);
            Assert.AreEqual("Unknown", c2.Forename);
            Collector c3 = serviceLayer.GetCollectorForListener(l3);
            Assert.AreEqual("Ted", c3.Forename);

            Listener l4 = new Listener() { Title = "Miss", Forename = "Clean", Surname = "Dates", Addr1 = "40 Clean Road", Addr2 = "", County = "London", Postcode = "N192DB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = false, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", Wallet = 55, Birthday = DateTime.Parse("01/01/1000"), DeletedDate = DateTime.Parse("01/01/1000"), LastIn = DateTime.Parse("01/01/1000"), LastOut = DateTime.Parse("01/01/1000") };
            Collector c4 = serviceLayer.GetCollectorForListener(l4);
            Assert.AreEqual("Unknown", c4.Forename);
        }

        /// <summary>
        /// Clean up titles from any dots.
        /// </summary>
        [TestMethod]
        public void ServiceLayer_CleanUpTitles()
        {
            int listenerId = 333;
            Listener l2 = new Listener() { Title = "Miss.", Forename = "Clean", Surname = "Dates", Addr1 = "40 Clean Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = false, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", Wallet = listenerId, Birthday = DateTime.Parse("01/01/1000"), DeletedDate = DateTime.Parse("01/01/1000"), LastIn = DateTime.Parse("01/01/1000"), LastOut = DateTime.Parse("01/01/1000") };
            repoLayer.InsertListener(serviceLayer.GetConnection(), l2);

            serviceLayer.CleanUpTitles();

            Listener result = serviceLayer.GetListenerById(333);
            Assert.AreEqual("Miss", result.Title);
        }

        /// <summary>
        /// Get weekly stats for the current (but new) week
        /// </summary>
        [TestMethod]
        public void ServiceLayer_GetWeeklyStatsForNewWeek()
        {
            serviceLayer.ClearWeeklyStats();
            WeeklyStats stats = serviceLayer.GetCurrentWeekStats();

            Assert.IsNotNull(stats);
        }

        /// <summary>
        /// Get weekly stats for the current week
        /// </summary>
        [TestMethod]
        public void ServiceLayer_GetWeeklyStatsForWeek()
        {
            WeeklyStats stats = serviceLayer.GetCurrentWeekStats();

            Assert.IsNotNull(stats);
            Assert.AreEqual(20, stats.ScannedIn);
            Assert.AreEqual(14, stats.ScannedOut);
            Assert.AreEqual(17, stats.TotalListeners);
            Assert.AreEqual(3, stats.PausedCount);
            Assert.AreEqual(5, stats.WeekNumber);
        }

        [TestMethod]
        public void ServiceLayer_CleanDeletedDate()
        {
            Listener l5 = new Listener() { Title = "Miss", Forename = "Other", Surname = "Jones", Addr1 = "40 Camden Road", Addr2 = "", County = "London", Postcode = "N7 8AB", Town = "Camden", Telephone = "07843434343", Stock = 3, Info = "", Joined = DateTime.Now, MemStickPlayer = true, Magazine = true, Status = ListenerStates.ACTIVE, StatusInfo = "", LastOut = DateTime.Now.AddMonths(-4), Wallet = 5, DeletedDate = DateTime.Now.AddDays(-5) };
            serviceLayer.AddListener(l5);

            serviceLayer.CleanDeletedDates();
            Listener result = serviceLayer.GetListenerById(l5.Wallet);

            Assert.IsNull(result.DeletedDate);
        }
    }
}
