#nullable disable

namespace TNBase.Repository
{
    public partial class WeekStat
    {
        public long WeekNumber { get; set; }
        public long? ScannedIn { get; set; }
        public long? ScannedOut { get; set; }
        public long PausedCount { get; set; }
        public long? TotalListeners { get; set; }
        public byte[] Date { get; set; }
    }
}
