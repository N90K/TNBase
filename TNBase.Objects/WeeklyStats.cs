using System;

namespace TNBase.Objects
{
    public class WeeklyStats
    {
        public WeeklyStats() 
        {
            WeekDate = DateTime.Now;
        }

        public int WeekNumber { get; set; }
        public int ScannedIn { get; set; }
        public int ScannedOut { get; set; }
        public int PausedCount { get; set; }
        public int TotalListeners { get; set; }
        public DateTime WeekDate { get; set; }

        public bool HasScanningResults()
        {
            return ScannedIn > 0 || ScannedOut > 0;
        }

    }
}
