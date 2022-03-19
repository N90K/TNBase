namespace TNBase.Objects
{
    public class YearStats
    {
        public int Year { get; set; }
        public int StartListeners { get; set; }
        public int EndListeners { get; set; }
        public int NewListeners { get; set; }
        public int DeletedListeners { get; set; }
        public int AverageListeners { get; set; }
        public int InactiveTotal { get; set; }
        public int MagazineTotal { get; set; }
        public int AverageSent { get; set; }
        public int SentTotal { get; set; }
        public int MagazinesSent { get; set; }
        public int PercentSent { get; set; }
        public int MemStickPlayerLoanTotal { get; set; }
        public int PausedTotal { get; set; }
        public int AveragePaused { get; set; }
        public int DeletedTotal { get; set; }
    }
}