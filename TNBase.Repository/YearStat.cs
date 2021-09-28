#nullable disable

namespace TNBase.Repository
{
    public partial class YearStat
    {
        public long Year { get; set; }
        public long? StartListeners { get; set; }
        public long? EndListeners { get; set; }
        public long? NewListeners { get; set; }
        public long? DeletedListeners { get; set; }
        public long? AverageListeners { get; set; }
        public long? InactiveTotal { get; set; }
        public long? MagazineTotal { get; set; }
        public long? AverageSent { get; set; }
        public long? SentTotal { get; set; }
        public long? MagazinesSent { get; set; }
        public long? PercentSent { get; set; }
        public long? MemStickPlayerLoanTotal { get; set; }
        public long? PausedTotal { get; set; }
        public long? AveragePaused { get; set; }
        public long? DeletedTotal { get; set; }
    }
}
