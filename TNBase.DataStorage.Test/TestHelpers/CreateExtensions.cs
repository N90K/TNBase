using TNBase.Objects;
using System;

namespace TNBase.DataStorage.Test.TestHelpers
{
    /// <summary>
    /// Test methods to create dummy data
    /// </summary>
    public static class CreateExtensions
    {
        /// <summary>
        /// Generate a dummy listener
        /// </summary>
        /// <returns></returns>
        public static Listener DummyListener()
        {
            Listener temp = new Listener()
            {
                Wallet = 1,
                Title = "Mr",
                Forename = "Test",
                Surname = "Er", 
                Addr1 = "1 Test Street", 
                Addr2 = "Test Av", 
                County = "Test County",
                Postcode = "CF13 3TS",
                Magazine = true,
                MemStickPlayer = true,
                Status = ListenerStates.ACTIVE,
                Telephone = "01234 234 242", 
                Town = "Test Town",
                StatusInfo = "",
                Info = "Some test listener",
                inOutRecords = new InOutRecords(),
                Birthday = DateTime.Parse("01/01/2010")
            };
            return temp;
        }

        /// <summary>
        /// Generate a collector
        /// </summary>
        /// <returns></returns>
        public static Collector DummyCollector()
        {
            Collector temp = new Collector()
            {
                ID = 1,
                Forename = "Martin",
                Surname = "Garix",
                Number = "23131 2313 232",
                Postcodes = "CF14 6pa, cf24"
            };
            return temp;
        }

        /// <summary>
        /// Create dummy week stats
        /// </summary>
        /// <returns></returns>
        public static WeeklyStats DummyWeekStats()
        {
            WeeklyStats temp = new WeeklyStats()
            {
                WeekNumber = 1,
                WeekDate = DateTime.Parse("10/10/01"),
                ScannedIn = 1,
                ScannedOut = 2,
                PausedCount = 4,
                TotalListeners = 10
            };
            return temp;
        }

        /// <summary>
        /// Create dummy year stats
        /// </summary>
        /// <returns></returns>
        public static YearStats DummyYearStats()
        {
            YearStats temp = new YearStats()
            {
                AverageSent = 1,
                AvListeners = 2,
                AveragePaused = 3,
                EndListeners = 4,
                InactiveTotal = 5,
                MagazinesSent = 6,
                MagazineTotal = 7,
                NewListeners = 8,
                DeletedListeners = 9,
                DeletedTotal = 10,
                PercentSent = 11,
                SentTotal = 12,
                StartListeners = 13,
                PausedTotal = 14,
                MemStickPlayerLoanTotal = 15,
                Year = 2016
            };
            return temp;
        }
    }
}
