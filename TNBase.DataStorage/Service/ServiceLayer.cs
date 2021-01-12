using TNBase.Objects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TNBase.Infrastructure.Extensions;

namespace TNBase.DataStorage
{
    public class ServiceLayer : IServiceLayer, IDisposable
    {
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        SQLiteConnection connection;
        IRepositoryLayer repoLayer;

        public ServiceLayer(string databasePath, IRepositoryLayer rLayerParam = null)
        {
            connection = new SQLiteConnection(DBUtils.GenConnectionString(databasePath));
            connection.Open();

            repoLayer = (rLayerParam == null ? new RepositoryLayer() : rLayerParam);
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }

        public bool IsConnected()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }

        public List<Listener> GetListenersByName(string forename, string surname, string title = null)
        {
            List<Listener> results = null;

            if (String.IsNullOrEmpty(forename) || forename.Equals("*"))
            {
                results = repoLayer.GetListeners(connection).Where(x => x.Surname.ToLower().Equals(surname.ToLower())).ToList();
            }
            else if (String.IsNullOrEmpty(surname) || surname.Equals("*"))
            {
                results = repoLayer.GetListeners(connection).Where(x => x.Forename.ToLower().Equals(forename.ToLower())).ToList();
            }
            else
            {
                results = repoLayer.GetListeners(connection).Where(
                    x => x.Forename.ToLower().Equals(forename.ToLower()) &&
                        x.Surname.ToLower().Equals(surname.ToLower())).ToList();
            }


            if (title != null)
            {
                results = results.Where(x => x.Title.Equals(title)).ToList();
            }

            return results;
        }

        public List<WeeklyStats> GetWeeklyStatsForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).ToList();
        }

        public List<Listener> GetAlphabeticList()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED)).OrderBy(x => x.Surname).ToList();
        }

        public List<Listener> GetNextWeekBirthdays()
        {
            var list = repoLayer.GetListeners(connection).Where(x =>
                x.HasBirthday &&
                !x.Status.Equals(ListenerStates.DELETED))
            .ToList();

            var currentWeek = DateTime.Now.WeekOfYear();

            var lastRecordingWeek = GetLastRecordingWeekOfYear();
            var weeksThisYear = new DateTime(DateTime.Now.Year, 12, 31).WeekOfYear() == 53 ? 53 : 52; // can be 52, 53 or 1

            var weekOffset = currentWeek == lastRecordingWeek ? 4 : currentWeek == 53 ? 1 : 2;

            var weekToInclude = (currentWeek + weekOffset) % weeksThisYear;

            var nextWeeks = new List<int> { weekToInclude };
            if (currentWeek == lastRecordingWeek - 1)
            {
                nextWeeks.Add(weekToInclude + 1);
            }

            return list.Where(x => nextWeeks.Contains(x.NextBirthdayDate.Value.WeekOfYear())).ToList();
        }

        private int GetLastRecordingWeekOfYear()
        {
            var lastRecordingInDecember = 25; // TODO Put it in config
            var recordingDayOfWeek = 6; // TODO Put it in config

            var lastRecordingDay = new DateTime(DateTime.Now.Year, 12, lastRecordingInDecember);

            var weekOffset = lastRecordingDay.DayNumberOfWeek() >= recordingDayOfWeek ? 0 : 1;
            return lastRecordingDay.WeekOfYear() - weekOffset;
        }

        public void CleanUpTitles()
        {
            List<Listener> listeners = GetListeners();

            foreach (Listener listener in listeners)
            {
                if (listener.Title.Contains("."))
                {
                    log.Debug("Listener with wallet " + listener.Wallet + " had a '.' in their title, removing it!");
                    listener.Title = listener.Title.Replace(".", "");
                    UpdateListener(listener);
                }
            }
        }

        public void CleanUpDates()
        {
            List<Listener> listeners = GetListeners();

            // Loop through
            foreach (Listener listener in listeners)
            {
                bool updated = false;

                // Clean deleted dates.
                if (listener.DeletedDate.HasValue)
                {
                    if (listener.DeletedDate.Value >= DateTime.MaxValue || listener.DeletedDate.Value <= DBUtils.AppMinDate())
                    {
                        log.Debug("Listener with id: " + listener.Wallet + " has invalid DeletedDate, removing it.");
                        listener.DeletedDate = null;
                        updated = true;
                    }
                }

                // Clean last in dates.
                if (listener.LastIn.HasValue)
                {
                    if (listener.LastIn.Value >= DateTime.MaxValue || listener.LastIn.Value <= DBUtils.AppMinDate())
                    {
                        log.Debug("Listener with id: " + listener.Wallet + " has invalid LastIn, removing it.");
                        listener.LastIn = null;
                        updated = true;
                    }
                }

                // Clean last in dates.
                if (listener.LastOut.HasValue)
                {
                    if (listener.LastOut.Value >= DateTime.MaxValue || listener.LastOut.Value <= DBUtils.AppMinDate())
                    {
                        log.Debug("Listener with id: " + listener.Wallet + " has invalid LastOut, removing it.");
                        listener.LastOut = null;
                        updated = true;
                    }
                }

                // Update the listener if changes were made.
                if (updated)
                {
                    UpdateListener(listener);
                }
            }
        }

        public List<Listener> GetInactiveListeners()
        {
            return GetListenersByStatus(ListenerStates.DELETED);
        }

        public List<Listener> GetUnsentListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.inOutRecords.Out8.Equals(0) && !x.Status.Equals(ListenerStates.DELETED)).ToList();
        }

        public List<Listener> GetRecentlyAddedListeners()
        {
            DateTime fewDaysBack = DateTime.Today.AddDays(-6);

            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.Joined > fewDaysBack && x.Joined <= DateTime.Now).ToList();
        }

        public List<Listener> GetRecentlyDeletedListeners()
        {
            DateTime fewDaysBack = DateTime.Today.AddDays(-6);

            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate > fewDaysBack && x.DeletedDate <= DateTime.Now).ToList();
        }

        public void ResumePausedListeners()
        {
            log.Debug("Resuming paused listeners!");

            // Get all paused listeners.
            List<Listener> theListeners = new List<Listener>();
            theListeners = GetStoppedListeners();

            // Resume paused listeners.
            foreach (Listener tListener in theListeners)
            {
                // If they are past the resume date
                DateTime? resumeDate = Listener.GetResumeDate(tListener);
                if (resumeDate.HasValue)
                {
                    if (resumeDate.Value < DateTime.Now)
                    {
                        tListener.Status = ListenerStates.ACTIVE;
                        tListener.StatusInfo = "";

                        if (!UpdateListener(tListener))
                        {
                            log.Error("Failed to maintain (resume paused) listeners.");
                        }
                    }
                }
            }
        }

        public List<Listener> GetStoppedListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.PAUSED)).ToList();
        }

        public List<Listener> GetUnreturnedSpeakerListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED) && x.MemStickPlayer).ToList();
        }

        public List<Listener> GetActiveListenersNotScannedIn()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.inOutRecords.In7.Equals(0) && x.Stock > 0).ToList();
        }

        public bool AddCollector(Collector collector)
        {
            try
            {
                repoLayer.InsertCollector(connection, collector);
                log.Info("Added new collector: " + collector.Forename + " " + collector.Surname);
                return true;
            }
            catch (Exception e)
            {
                log.Error(e, "Error on call.");
            }
            return false;
        }

        public bool UpdateCollector(Collector collector)
        {
            try
            {
                repoLayer.UpdateCollector(connection, collector);
                log.Info("Updated collector: " + collector.Forename + " " + collector.Surname);
                return true;
            }
            catch (Exception e)
            {
                log.Error(e, "Error on call.");
            }
            return false;
        }

        public List<Collector> GetCollectors()
        {
            return repoLayer.GetCollectors(connection);
        }

        public Listener GetListenerById(int id)
        {
            return repoLayer.GetListeners(connection).SingleOrDefault(x => x.Wallet.Equals(id));
        }

        public int AddListener(Listener listener)
        {
            int result = repoLayer.InsertListener(connection, listener);
            log.Info("Added new listener: " + listener.Forename + " " + listener.Surname + ", Wallet: " + result);
            return result;
        }

        public bool UpdateListener(Listener listener)
        {
            repoLayer.UpdateListener(connection, listener);
            log.Info("Updated listener: " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
            return true;
        }

        public bool SoftDeleteListener(Listener listener, string reason)
        {
            listener.Status = ListenerStates.DELETED;
            listener.StatusInfo = reason;
            listener.DeletedDate = DateTime.Now;

            repoLayer.UpdateListener(connection, listener);
            log.Info("Deleted listener (soft): " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
            return true;
        }

        public List<Listener> GetListeners()
        {
            return repoLayer.GetListeners(connection);
        }

        public bool DeleteCollector(Collector collector)
        {
            repoLayer.DeleteCollector(connection, collector);
            log.Info("Deleted collector: " + collector.Forename + " " + collector.Surname);
            return true;
        }

        public int GetHighestYearNumber()
        {
            return repoLayer.GetYearStats(connection).Max(x => x.Year);
        }

        public int GetHighestWeekNumber()
        {
            List<WeeklyStats> weeklyStats = repoLayer.GetWeeklyStats(connection);

            return weeklyStats.Count == 0 ? 0 : weeklyStats.Max(x => x.WeekNumber);
        }

        public int GetMinimumYear()
        {
            return repoLayer.GetYearStats(connection).Min(x => x.Year);
        }

        public Collector GetCollector(int id)
        {
            return repoLayer.GetCollectors(connection).SingleOrDefault(x => x.ID.Equals(id));
        }

        public bool IsNewStatsWeek()
        {
            // Get the latest one!
            int highestWeekNumber = GetHighestWeekNumber();

            // If we have no week number, it must be the first usage
            if (highestWeekNumber == 0)
            {
                return true;
            }

            WeeklyStats stats = repoLayer.GetWeeklyStats(connection).SingleOrDefault(x => x.WeekNumber.Equals(highestWeekNumber));

            // If we are in a later year, its an easy decision
            if (DateTime.Today.Year > stats.WeekDate.Year)
            {
                return true;
            }

            // Is it within the last few days?
            return (DateTime.Today.DayOfYear > (stats.WeekDate.DayOfYear + 5));
        }

        public int CalculateNextFreeIndex()
        {
            return repoLayer.CalculateNextFreeWallet(connection);
        }

        public void ClearListeners()
        {
            repoLayer.ClearListeners(connection);
        }

        public void ClearCollectors()
        {
            repoLayer.ClearCollectors(connection);
        }

        public void ClearWeeklyStats()
        {
            repoLayer.ClearWeeklyStats(connection);
        }

        public void ClearYearlyStats()
        {
            repoLayer.ClearYearStats(connection);
        }

        public List<Listener> GetListenersByStatus(ListenerStates status)
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(status)).ToList();
        }

        public List<WeeklyStats> GetAllWeeklyStats()
        {
            return repoLayer.GetWeeklyStats(connection);
        }

        public List<YearStats> GetAllYearlyStats()
        {
            return repoLayer.GetYearStats(connection);
        }

        public bool SaveYearStats(YearStats stats)
        {
            repoLayer.InsertYearStats(connection, stats);
            return true;
        }

        public bool SaveWeekStats(WeeklyStats stats)
        {
            repoLayer.InsertWeeklyStats(connection, stats);
            return true;
        }

        public bool WeeklyStatExistsForWeek(int weekNumber)
        {
            return (repoLayer.GetWeeklyStats(connection).Where(x => x.WeekNumber == weekNumber).Count() > 0);
        }

        public bool RestoreListener(Listener listener)
        {
            listener.Status = ListenerStates.ACTIVE;
            listener.StatusInfo = "";
            listener.DeletedDate = null;

            repoLayer.UpdateListener(connection, listener);
            return true;
        }

        public List<Listener> GetListenersWithBirthdays()
        {
            return repoLayer.GetListeners(connection).Where(x => x.BirthdayDay.HasValue && x.BirthdayMonth.HasValue).ToList();
        }

        public bool UpdateYearStats(YearStats stats)
        {
            repoLayer.UpdateYearStats(connection, stats);
            return true;
        }

        public Collector GetCollectorForListener(Listener listener)
        {
            Collector dummy = new Collector();
            dummy.Forename = "Unknown";
            dummy.Surname = "";
            dummy.Number = "";
            dummy.Postcodes = "Unknown";

            var postcode = listener.Postcode;
            // Remove spaces and convert to upper case.
            postcode = postcode.ToUpper();
            postcode = postcode.Replace(" ", "");

            List<Collector> alist = repoLayer.GetCollectors(connection);

            // Keep going until we find something with a minimum of 2 letters match
            for (int letterCount = 0; letterCount <= 5; letterCount++)
            {
                for (int index = 0; index <= alist.Count - 1; index++)
                {
                    Collector col = alist[index];
                    List<string> results = col.Postcodes.Split(',').ToList();

                    try
                    {
                        foreach (string theRes in results)
                        {
                            string second = Utils.removeSurnameSpecifier(theRes);

                            if (second.Equals(postcode.Substring(0, Math.Max(postcode.Length - letterCount, 2))))
                            {
                                if (Utils.postcodeValidForSurname(theRes, listener.Surname))
                                {
                                    return col;
                                }
                                else
                                {
                                    log.Debug("Found collector match but surname specifier didn't match.");
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        log.Warn(e, "Failed to find collector for postcode: '" + postcode + "'.");
                    }
                }
            }

            return dummy;
        }

        public bool UpdateWeeklyStats(WeeklyStats stats)
        {
            repoLayer.UpdateWeeklyStats(connection, stats);
            return true;
        }

        public Listener GetNextListener(Listener current)
        {
            return repoLayer.GetListeners(connection).Where(x => x.Wallet > current.Wallet).OrderBy(x => x.Wallet).FirstOrDefault();
        }

        public Listener GetPreviousListener(Listener current)
        {
            return repoLayer.GetListeners(connection).Where(x => x.Wallet < current.Wallet).OrderByDescending(x => x.Wallet).FirstOrDefault();
        }

        public bool UpdateListenerInOuts()
        {
            log.Debug("Updating IN/OUT values for listeners...");

            List<Listener> listeners = GetListeners();

            // TODO (M) Optimise as a query and create a test?!?
            foreach (Listener l in listeners)
            {
                l.inOutRecords.In1 = l.inOutRecords.In2;
                l.inOutRecords.In2 = l.inOutRecords.In3;
                l.inOutRecords.In3 = l.inOutRecords.In4;
                l.inOutRecords.In4 = l.inOutRecords.In5;
                l.inOutRecords.In5 = l.inOutRecords.In6;
                l.inOutRecords.In6 = l.inOutRecords.In7;
                l.inOutRecords.In7 = l.inOutRecords.In8;
                l.inOutRecords.In8 = 0;

                l.inOutRecords.Out1 = l.inOutRecords.Out2;
                l.inOutRecords.Out2 = l.inOutRecords.Out3;
                l.inOutRecords.Out3 = l.inOutRecords.Out4;
                l.inOutRecords.Out4 = l.inOutRecords.Out5;
                l.inOutRecords.Out5 = l.inOutRecords.Out6;
                l.inOutRecords.Out6 = l.inOutRecords.Out7;
                l.inOutRecords.Out7 = l.inOutRecords.Out8;
                l.inOutRecords.Out8 = 0;

                // If they are active we wont read them out but will send.
                if (l.Status.Equals(ListenerStates.ACTIVE))
                {
                    if (l.inOutRecords.In7 >= 1)
                    {
                        l.inOutRecords.Out8 = 1;
                    }
                }

                repoLayer.UpdateListener(connection, l);
            }
            log.Debug("Finished updating IN/OUT values for listeners...");

            return true;
        }

        public void ClearAllData()
        {
            repoLayer.ClearAllData(connection);
        }

        public YearStats GetYearStats(int year)
        {
            return repoLayer.GetYearStats(connection).SingleOrDefault(x => x.Year.Equals(year));
        }

        public void DeleteOverdueDeletedListeners(int months)
        {
            List<Listener> listeners = repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate < DateTime.Now.AddMonths(-months)).ToList();

            // Delete old deleted listener
            foreach (Listener l in listeners)
            {
                log.Info("Deleting listener with id: " + l.Wallet + ". Name: " + l.GetNiceName() + " as they have been deleted for over " + months + " months.");
                repoLayer.DeleteListener(connection, l);
            }
        }

        public List<Listener> GetOrderedListeners(OrderVar ordering)
        {
            if (ordering.Equals(OrderVar.SURNAME))
            {
                return repoLayer.GetListeners(connection).OrderBy(x => x.Surname).ToList();
            }
            else
            {
                return repoLayer.GetListeners(connection).OrderBy(x => x.Wallet).ToList();
            }
        }

        public void UpdateYearStatsInternal()
        {
            DateTime currentDate = DateTime.Today;
            int lastYear = currentDate.Year - 1;

            // If there are no stats for last year, so this will only run if a new year occurs!
            YearStats lastYearStats = GetYearStats(lastYear);
            if (lastYearStats == null)
            {
                YearStats newStats = new YearStats()
                {
                    Year = lastYear,
                    StartListeners = GetListenersAtYearStart(lastYear),
                    EndListeners = GetListenersByStatus(ListenerStates.ACTIVE).Count,
                    NewListeners = GetNewListenersForYear(lastYear),
                    AverageSent = GetAverageDispatchedWallets(lastYear),
                    AveragePaused = GetAveragePausedWallets(lastYear),
                    AvListeners = GetAverageListenersForYear(lastYear),
                    InactiveTotal = GetInactiveWalletNumbers(),
                    DeletedListeners = GetLostListenersForYear(lastYear),
                    MagazinesSent = 0, // TODO (L) Fill this MagazinesSent feld in?
                    MagazineTotal = 0, // TODO (L) Fill this MagazineTotal feld in?
                    DeletedTotal = GetListenersByStatus(ListenerStates.DELETED).Count,
                    MemStickPlayerLoanTotal = GetMemorySticksOnLoan(),
                    SentTotal = GetWalletsDispatchedForYear(lastYear),
                    PausedTotal = GetListenersByStatus(ListenerStates.PAUSED).Count,
                    PercentSent = 0 // TODO (L) Fill this PercentSent feld in?
                };
                repoLayer.InsertYearStats(connection, newStats);
            }
        }

        public int Get3MonthInactiveListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.LastOut.HasValue && x.LastOut < DateTime.Now.AddMonths(-3)).Count();
        }

        public List<Listener> Get1MonthDormantListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.LastOut.HasValue && x.LastOut < DateTime.Now.AddMonths(-1)).ToList();
        }

        public int GetListenersAtYearStart(int year)
        {
            List<WeeklyStats> lastStats = GetWeeklyStatsForYear(year - 1).OrderBy(x => x.WeekDate).ToList();
            if (lastStats.Count > 0)
            {
                return lastStats.Last().TotalListeners;
            }

            log.Warn("No weekly stats found for year: " + year);
            return 0;
        }

        public int GetMemorySticksOnLoan()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.MemStickPlayer).Count();
        }

        public int GetInactiveWalletNumbers()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED)).Count();
        }

        public int GetNewListenersForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return repoLayer.GetListeners(connection).Where(x => x.Joined >= yearStart && x.Joined <= yearEnd && x.Status != ListenerStates.DELETED).Count();
        }

        public int GetLostListenersForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return repoLayer.GetListeners(connection).Where(x => x.Status == ListenerStates.DELETED && x.DeletedDate >= yearStart && x.DeletedDate <= yearEnd).Count();
        }

        public int GetNetListenersForYear(int year)
        {
            return GetNewListenersForYear(year) - GetLostListenersForYear(year);
        }

        public int GetAverageListenersForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            int defaultRet = 0;
            try
            {
                defaultRet = (int)repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Average(x => x.TotalListeners);
            }
            catch (Exception e)
            {
                log.Warn(e, "Couldnt calculate average listeners for year: " + year);
            }
            return defaultRet;
        }

        public int GetAverageDispatchedWallets(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            int defaultRet = 0;
            try
            {
                IEnumerable<WeeklyStats> weeklyStats = repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd);
                if (weeklyStats.Count() > 0)
                {
                    defaultRet = (int)weeklyStats.Average(x => x.ScannedOut);
                }
            }
            catch (Exception e)
            {
                log.Warn(e, "Couldnt calculate average dispatched wallets for year: " + year);
            }
            return defaultRet;
        }

        public int GetAveragePausedWallets(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            int defaultRet = 0;
            try
            {
                defaultRet = (int)repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Average(x => x.PausedCount);
            }
            catch (Exception e)
            {
                log.Warn(e, "Couldnt calculate average paused wallets for year: " + year);
            }
            return defaultRet;
        }

        public int GetWalletsDispatchedForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return (int)repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Sum(x => x.ScannedOut + x.ScannedIn);
        }

        public int GetCurrentWeekNumber()
        {
            // Gets the latest weekly stats.
            WeeklyStats myStats = repoLayer.GetWeeklyStats(connection).OrderByDescending(x => x.WeekNumber).FirstOrDefault();

            // Safegaurd
            if (myStats == null) { return 1; }

            // Get the week number.
            int weekNumber = myStats.WeekNumber;
            DateTime nowDate = DateTime.Now;
            try
            {
                // Parse the date.
                DateTime weekDate = myStats.WeekDate;

                //if (addnewbit)
                //{
                // Is it within the current week if so dont add a new bit
                if (nowDate.AddDays(-5) > weekDate)
                {
                    return weekNumber + 1;
                }
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex, "Tried to check weekly stats. Are there any?");
            }
            return weekNumber;
        }

        public int GetNewWeekNumber()
        {
            return GetCurrentWeekNumber() + 1;
        }

        public int GetCurrentListenerCount()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED)).Count();
        }

        public void ClearAllDataExceptCollectors()
        {
            ClearListeners();
            ClearWeeklyStats();
            ClearYearlyStats();
        }

        public void RunCommand(string sqlCommand)
        {
            repoLayer.RunCommand(connection, sqlCommand);
        }

        public WeeklyStats GetCurrentWeekStats()
        {
            int currentWeekNumber = GetCurrentWeekNumber();
            WeeklyStats forTheWeek = repoLayer.GetWeeklyStats(connection).ToList().Where(x => x.WeekNumber == currentWeekNumber).FirstOrDefault();

            return (forTheWeek != null ? forTheWeek : new WeeklyStats());
        }

        public void CleanDeletedDates()
        {
            // Get listeners that are not deleted but have a deleted date
            List<Listener> listenersToClean = repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate != null).ToList();

            foreach (Listener listener in listenersToClean)
            {
                log.Warn("Listener " + listener.GetNiceName() + ", Wallet: " + listener.Wallet + " is " + listener.Status + " but has a deleted date. Removing it!");
                listener.DeletedDate = null;
                UpdateListener(listener);
            }
        }

        public bool RecordScan(int wallet, ScanTypes scanType)
        {
            Scan tempScan = new Scan();
            tempScan.Wallet = wallet;
            tempScan.ScanType = scanType;

            repoLayer.InsertScan(connection, tempScan);
            return true;
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
