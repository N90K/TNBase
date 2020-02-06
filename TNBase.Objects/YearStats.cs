namespace TNBase.Objects
{
    public class YearStats
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public YearStats() { }

        /// <summary>
        /// The year.
        /// </summary>
        public int Year;

        /// <summary>
        /// Listeners at the start of the year.
        /// </summary>
        public int StartListeners;

        /// <summary>
        /// Listeners at the end of the year.
        /// </summary>
        public int EndListeners;

        /// <summary>
        /// The number of new listeners this year.
        /// </summary>
        public int NewListeners;

        /// <summary>
        /// The number of deleted listeners this year
        /// </summary>
        public int DeletedListeners;

        /// <summary>
        /// Average listeners for the year.
        /// </summary>
        public int AvListeners;

        /// <summary>
        /// Number of inactive listeners at the end of the year.
        /// </summary>
        public int InactiveTotal;

        /// <summary>
        /// Total number of magazines.
        /// TODO: (L) remove MagazineTotal if not used?
        /// </summary>
        public int MagazineTotal;

        /// <summary>
        /// The average number of sent wallets for a year
        /// </summary>
        public int AverageSent;

        /// <summary>
        /// The sent total for a year.
        /// </summary>
        public int SentTotal;

        /// <summary>
        /// The number of magazines sent in a year.
        /// TODO: (L) remove MagazinesSent if not used?
        /// </summary>
        public int MagazinesSent;

        /// <summary>
        /// The percentage of eligable wallets sent in a year.
        /// </summary>
        public int PercentSent;

        /// <summary>
        /// The number of memory stick players on loan at year end.
        /// </summary>
        public int MemStickPlayerLoanTotal;

        /// <summary>
        /// The total number of Paused Listeners for the year end.
        /// </summary>
        public int PausedTotal;

        /// <summary>
        /// The average number of Paused Listeners for the year.
        /// </summary>
        public int AveragePaused;

        /// <summary>
        /// The total number of Deleted Listeners at year end.
        /// </summary>
        public int DeletedTotal;
    }
}