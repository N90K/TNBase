using TNBase.Objects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TNBase.DataStorage
{
    public interface IRepositoryLayer
    {
        List<Listener> GetListeners(SQLiteConnection conn);
        void UpdateListener(SQLiteConnection conn, Listener listener);
        int InsertListener(SQLiteConnection conn, Listener listener);
        void DeleteListener(SQLiteConnection conn, Listener listener);

        List<Collector> GetCollectors(SQLiteConnection conn);
        void UpdateCollector(SQLiteConnection conn, Collector collector);
        void InsertCollector(SQLiteConnection conn, Collector collector);
        void DeleteCollector(SQLiteConnection conn, Collector collector);

        List<WeeklyStats> GetWeeklyStats(SQLiteConnection conn);
        void UpdateWeeklyStats(SQLiteConnection conn, WeeklyStats weeklyStats);
        void InsertWeeklyStats(SQLiteConnection conn, WeeklyStats weeklyStats);
        void DeleteWeeklyStats(SQLiteConnection conn, WeeklyStats weeklyStats);

        List<YearStats> GetYearStats(SQLiteConnection conn);
        void UpdateYearStats(SQLiteConnection conn, YearStats yearStats);
        void InsertYearStats(SQLiteConnection conn, YearStats yearStats);
        void DeleteYearStats(SQLiteConnection conn, YearStats yearStats);

        List<Scan> GetScanRecords(SQLiteConnection conn);
        void InsertScan(SQLiteConnection conn, Scan scan);
        void DeleteScans(SQLiteConnection conn, int wallet);

        int CalculateNextFreeWallet(SQLiteConnection conn);

        void ClearListeners(SQLiteConnection conn);
        void ClearCollectors(SQLiteConnection conn);
        void ClearWeeklyStats(SQLiteConnection conn);
        void ClearYearStats(SQLiteConnection conn);
        void ClearAllData(SQLiteConnection conn);

        void RunCommand(SQLiteConnection conn, String command);
    }
}
