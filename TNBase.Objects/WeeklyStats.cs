using System;

namespace TNBase.Objects
{
    /// <summary>
    /// Stores the statistics for a week
    /// </summary>
    public class WeeklyStats
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WeeklyStats() 
        {
            WeekDate = DateTime.Now;
        }

        /// <summary>
        /// The week number - this is used for reports etc.
        /// </summary>
        public int WeekNumber;

        /// <summary>
        /// The number of wallets scanned in - e.g. recieved back.
        /// </summary>
        public int ScannedIn;

        /// <summary>
        /// The number of wallets scanned out - e.g. sent to Listeners.
        /// </summary>
        public int ScannedOut;

        /// <summary>
        /// The number of Paused Listeners
        /// </summary>
        public int PausedCount;

        /// <summary>
        /// The Total number of Listeners
        /// </summary>
        public int TotalListeners;

        /// <summary>
        /// The date for the week
        /// </summary>
        public DateTime WeekDate;

        /// <summary>
        /// Are there scanning results
        /// </summary>
        /// <returns>true or false</returns>
        public bool hasScanningResults()
        {
            return ScannedIn > 0 || ScannedOut > 0;
        }

    }
}
