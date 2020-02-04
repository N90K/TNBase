using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public interface IServiceLayer
    {
        /// <summary>
        /// Utility
        /// </summary>
        bool IsConnected();

        /// <summary>
        /// Generic
        /// </summary>
        int GetMinimumYear();
        int CalculateNextFreeIndex();
        int GetHighestWeekNumber();
        int GetHighestYearNumber();
        int GetCurrentWeekNumber();
        bool IsNewStatsWeek();
        int GetNewWeekNumber();
        bool UpdateListenerInOuts();
        int GetMemorySticksOnLoan();
        void DeleteOverdueDeletedListeners(int months);

        /// <summary>
        /// Clear methods
        /// </summary>
        void ClearListeners();
        void ClearCollectors();
        void ClearWeeklyStats();
        void ClearYearlyStats();
        void ClearAllData();
        void ClearAllDataExceptCollectors();
        
        /// <summary>
        /// Listener Calls
        /// </summary>
        Listener GetListenerById(int id);
        Listener GetNextListener(Listener current);
        Listener GetPreviousListener(Listener current);
        List<Listener> GetListeners();
        List<Listener> GetAlphabeticList();
        List<Listener> GetInactiveListeners();
        List<Listener> GetRecentlyAddedListeners();
        List<Listener> GetRecentlyDeletedListeners();
        List<Listener> GetListenersWithBirthdays();
        List<Listener> GetUnsentListeners();
        List<Listener> GetStoppedListeners();
        List<Listener> GetUnreturnedSpeakerListeners();
        List<Listener> GetActiveListenersNotScannedIn();
        List<Listener> Get1MonthDormantListeners();
        List<Listener> GetNextWeekBirthdays();
        List<Listener> GetListenersByName(string forename, string surname, string title = null);
        List<Listener> GetListenersByStatus(ListenerStates status);
        List<Listener> GetOrderedListeners(OrderVar ordering);
        int AddListener(Listener listener);
        bool UpdateListener(Listener listener);
        bool SoftDeleteListener(Listener listener, string reason);
        bool RestoreListener(Listener listener);
        void ResumePausedListeners();
        // Cleanup methods
        void CleanUpDates();
        void CleanUpTitles();

        /// <summary>
        /// Year stats calls
        /// </summary>
        YearStats GetYearStats(int year);
        bool SaveYearStats(YearStats stats);
        bool UpdateYearStats(YearStats stats);
        void UpdateYearStatsInternal();
        List<YearStats> GetAllYearlyStats();

        /// <summary>
        /// Week stats calls.
        /// </summary>
        bool SaveWeekStats(WeeklyStats stats);
        bool UpdateWeeklyStats(WeeklyStats stats);
        bool WeeklyStatExistsForWeek(int weekNumber);
        List<WeeklyStats> GetAllWeeklyStats();
        List<WeeklyStats> GetWeeklyStatsForYear(int year);
        WeeklyStats GetCurrentWeekStats();

        /// <summary>
        /// Stats
        /// </summary>
        int GetCurrentListenerCount();
        int GetAveragePausedWallets(int year);
        int GetWalletsDispatchedForYear(int year);
        int GetAverageDispatchedWallets(int year);
        int GetLostListenersForYear(int year);
        int GetAverageListenersForYear(int year);
        int GetNetListenersForYear(int year);
        int GetInactiveWalletNumbers();
        int GetNewListenersForYear(int year);
        int GetListenersAtYearStart(int year);
        int Get3MonthInactiveListeners();

        /// <summary>
        /// Collector methods
        /// </summary>
        bool AddCollector(Collector collector);
        bool UpdateCollector(Collector collector);
        bool DeleteCollector(Collector collector);
        List<Collector> GetCollectors();
        Collector GetCollector(int id);
        Collector GetCollectorForListener(Listener listener);

        /// <summary>
        /// Scan methods
        /// </summary>
        bool RecordScan(int wallet, ScanTypes scanType);

        /// <summary>
        /// Support methods
        /// </summary>
        void RunCommand(String sqlCommand);
        void CleanDeletedDates();
    }
}
