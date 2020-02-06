using TNBase.Objects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace TNBase.DataStorage
{
    public class ServiceLayer : IServiceLayer, IDisposable
    {
        // Logging instance
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        // Variables
        SQLiteConnection connection;
        IRepositoryLayer repoLayer;

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceLayer(string databasePath, IRepositoryLayer rLayerParam = null)
        {
            // Open the connection
            connection = new SQLiteConnection(DBUtils.GenConnectionString(databasePath));
            connection.Open();

            // Create the repo layer
            repoLayer = (rLayerParam == null ? new RepositoryLayer() : rLayerParam);
        }

        /// <summary>
        /// Used for unit tests
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// Is it connected?
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }

        /// <summary>
        /// Get the listeners by name
        /// </summary>
        /// <param name="forename"></param>
        /// <param name="surname"></param>
        /// <param name="title"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get weekly stats for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<WeeklyStats> GetWeeklyStatsForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetAlphabeticList()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED)).OrderBy(x => x.Surname).ToList();
        }

        /// <summary>
        /// Get birthdays next week (doesn't include deleted listeners)
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetNextWeekBirthdays()
        {
            List<Listener> list = repoLayer.GetListeners(connection).Where(x => x.Birthday.HasValue && !x.Status.Equals(ListenerStates.DELETED)).ToList();
            List<Listener> results = new List<Listener>();

            // Logic duplicated in print birthday form!
            DateTime nowDate;
            DateTime weekDate;
            if ((System.DateTime.Now.Month == 12 & System.DateTime.Now.Day >= 8 & System.DateTime.Now.Day <= 14))
            {
                nowDate = System.DateTime.Now.AddDays(9);
                weekDate = DateTime.Now.AddDays(29);
            }
            else if ((System.DateTime.Now.Month == 12 & System.DateTime.Now.Day >= 15 & System.DateTime.Now.Day <= 25))
            {
                nowDate = System.DateTime.Now.AddDays(23);
                weekDate = DateTime.Now.AddDays(29);
            }
            else
            {
                nowDate = System.DateTime.Now.AddDays(9);
                weekDate = DateTime.Now.AddDays(15);
            }

            foreach (Listener l in list)
            {
                DateTime birthdayThisYear = l.BirthdayThisYear();
                if (birthdayThisYear >= nowDate && birthdayThisYear <= weekDate)
                {
                    results.Add(l);
                }
            }
            return results;
        }

        /// <summary>
        /// Clean up titles so we dont get errors on forms
        /// </summary>
        public void CleanUpTitles()
        {
            List<Listener> listeners = GetListeners();

            // Loop through
            foreach (Listener listener in listeners)
            {
                // Remove any .'s
                if (listener.Title.Contains("."))
                {
                    log.Debug("Listener with wallet " + listener.Wallet + " had a '.' in their title, removing it!");
                    listener.Title = listener.Title.Replace(".", "");
                    UpdateListener(listener);
                }
            }
        }

        /// <summary>
        /// Clean up all dates so we dont get errors on forms
        /// </summary>
        /// <returns></returns>
        public void CleanUpDates()
        {
            List<Listener> listeners = GetListeners();

            // Loop through
            foreach (Listener listener in listeners)
            {
                bool updated = false;

                // Clean birthdays
                if (listener.Birthday.HasValue)
                {
                    if (listener.Birthday.Value >= DateTime.MaxValue || listener.Birthday.Value <= DBUtils.AppMinDate())
                    {
                        log.Debug("Listener with id: " + listener.Wallet + " has invalid Birthday, removing it.");
                        listener.Birthday = null;
                        updated = true;
                    }
                }

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

        /// <summary>
        /// Get inactive listeners (that have been deleted but the wallet id isnt free)
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetInactiveListeners()
        {
            return GetListenersByStatus(ListenerStates.DELETED);
        }

        /// <summary>
        /// Get unsent listeners
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetUnsentListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.inOutRecords.Out8.Equals(0) && !x.Status.Equals(ListenerStates.DELETED)).ToList();
        }

        /// <summary>
        /// Get recently added listeners
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetRecentlyAddedListeners()
        {
            DateTime fewDaysBack = DateTime.Today.AddDays(-6);

            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.Joined > fewDaysBack && x.Joined <= DateTime.Now).ToList();
        }

        /// <summary>
        /// Get recently deleted listeners
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetRecentlyDeletedListeners()
        {
            DateTime fewDaysBack = DateTime.Today.AddDays(-6);

            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate > fewDaysBack && x.DeletedDate <= DateTime.Now).ToList();
        }

        /// <summary>
        /// Restore paused listeners
        /// </summary>
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

        /// <summary>
        /// Get stopped listeners
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetStoppedListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.PAUSED)).ToList();
        }

        /// <summary>
        /// Get unreturned speaker list
        /// (anyone who is deleted with a memory stick player
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetUnreturnedSpeakerListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED) && x.MemStickPlayer).ToList();
        }

        /// <summary>
        /// Get the active listeners who have not been scanned in and have stock
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetActiveListenersNotScannedIn()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.inOutRecords.In7.Equals(0) && x.Stock > 0).ToList();
        }

        /// <summary>
        /// Add a collector
        /// </summary>
        /// <param name="collector"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update a collector
        /// </summary>
        /// <param name="collector"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all collectors
        /// </summary>
        /// <returns></returns>
        public List<Collector> GetCollectors()
        {
            return repoLayer.GetCollectors(connection);
        }

        /// <summary>
        /// Get a listener by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Listener GetListenerById(int id)
        {
            return repoLayer.GetListeners(connection).SingleOrDefault(x => x.Wallet.Equals(id));
        }

        /// <summary>
        /// Add a listener
        /// </summary>
        /// <param name="listener"></param>
        /// <returns>The wallet id</returns>
        public int AddListener(Listener listener)
        {
            int result = repoLayer.InsertListener(connection, listener);
            log.Info("Added new listener: " + listener.Forename + " " + listener.Surname + ", Wallet: " + result);
            return result;
        }

        /// <summary>
        /// Update a listener
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool UpdateListener(Listener listener)
        {
            repoLayer.UpdateListener(connection, listener);
            log.Info("Updated listener: " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
            return true;
        }

        /// <summary>
        /// Delete a listener
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool SoftDeleteListener(Listener listener, string reason)
        {
            listener.Status = ListenerStates.DELETED;
            listener.StatusInfo = reason;
            listener.DeletedDate = DateTime.Now;

            repoLayer.UpdateListener(connection, listener);
            log.Info("Deleted listener (soft): " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
            return true;
        }

        /// <summary>
        /// Get listeners
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetListeners()
        {
            return repoLayer.GetListeners(connection);
        }

        /// <summary>
        /// Delete a collector
        /// </summary>
        /// <param name="collector"></param>
        /// <returns></returns>
        public bool DeleteCollector(Collector collector)
        {
            repoLayer.DeleteCollector(connection, collector);
            log.Info("Deleted collector: " + collector.Forename + " " + collector.Surname);
            return true;
        }

        /// <summary>
        /// Get the highest year number
        /// </summary>
        /// <returns></returns>
        public int GetHighestYearNumber()
        {
            return repoLayer.GetYearStats(connection).Max(x => x.Year);
        }

        /// <summary>
        /// Get the highest week number
        /// </summary>
        /// <returns></returns>
        public int GetHighestWeekNumber()
        {
            List<WeeklyStats> weeklyStats = repoLayer.GetWeeklyStats(connection);

            return weeklyStats.Count == 0 ? 0 : weeklyStats.Max(x => x.WeekNumber);
        }

        /// <summary>
        /// Get the minimum year
        /// </summary>
        /// <returns></returns>
        public int GetMinimumYear()
        {
            return repoLayer.GetYearStats(connection).Min(x => x.Year);
        }

        /// <summary>
        /// Get a collector by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Collector GetCollector(int id)
        {
            return repoLayer.GetCollectors(connection).SingleOrDefault(x => x.ID.Equals(id));
        }

        /// <summary>
        /// Is it a new stats week
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get the next free wallet index
        /// </summary>
        /// <returns></returns>
        public int CalculateNextFreeIndex()
        {
            return repoLayer.CalculateNextFreeWallet(connection);
        }

        /// <summary>
        /// Clear listeners
        /// </summary>
        public void ClearListeners()
        {
            repoLayer.ClearListeners(connection);
        }

        /// <summary>
        /// Clear collectors
        /// </summary>
        public void ClearCollectors()
        {
            repoLayer.ClearCollectors(connection);
        }

        /// <summary>
        /// Clear weekly stats
        /// </summary>
        public void ClearWeeklyStats()
        {
            repoLayer.ClearWeeklyStats(connection);
        }

        /// <summary>
        /// Clear yearly stats
        /// </summary>
        public void ClearYearlyStats()
        {
            repoLayer.ClearYearStats(connection);
        }

        /// <summary>
        /// Get listeners of a status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Listener> GetListenersByStatus(ListenerStates status)
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(status)).ToList();
        }

        /// <summary>
        /// Get all week stats
        /// </summary>
        /// <returns></returns>
        public List<WeeklyStats> GetAllWeeklyStats()
        {
            return repoLayer.GetWeeklyStats(connection);
        }

        /// <summary>
        /// Get all year stats
        /// </summary>
        /// <returns></returns>
        public List<YearStats> GetAllYearlyStats()
        {
            return repoLayer.GetYearStats(connection);
        }

        /// <summary>
        /// Save some year stats
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public bool SaveYearStats(YearStats stats)
        {
            repoLayer.InsertYearStats(connection, stats);
            return true;
        }

        /// <summary>
        /// Insert some weekly stats
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public bool SaveWeekStats(WeeklyStats stats)
        {
            repoLayer.InsertWeeklyStats(connection, stats);
            return true;
        }

        /// <summary>
        /// Does the weekly stat exist for a given week
        /// </summary>
        /// <param name="weekNumber"></param>
        /// <returns></returns>
        public bool WeeklyStatExistsForWeek(int weekNumber)
        {
            return (repoLayer.GetWeeklyStats(connection).Where(x => x.WeekNumber == weekNumber).Count() > 0);
        }

        /// <summary>
        /// Restore some listener
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public bool RestoreListener(Listener listener)
        {
            listener.Status = ListenerStates.ACTIVE;
            listener.StatusInfo = "";
            listener.DeletedDate = null;

            repoLayer.UpdateListener(connection, listener);
            return true;
        }

        /// <summary>
        /// Get listeners with birthdays
        /// </summary>
        /// <returns></returns>
        public List<Listener> GetListenersWithBirthdays()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Birthday.HasValue).ToList();
        }

        /// <summary>
        /// Update the year stats
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public bool UpdateYearStats(YearStats stats)
        {
            repoLayer.UpdateYearStats(connection, stats);
            return true;
        }

        /// <summary>
        /// Get a collector for a listener
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update some weekly stats
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public bool UpdateWeeklyStats(WeeklyStats stats)
        {
            repoLayer.UpdateWeeklyStats(connection, stats);
            return true;
        }

        /// <summary>
        /// Get the next listener
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public Listener GetNextListener(Listener current)
        {
            return repoLayer.GetListeners(connection).Where(x => x.Wallet > current.Wallet).OrderBy(x => x.Wallet).FirstOrDefault();
        }

        /// <summary>
        /// Get the previous listener
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public Listener GetPreviousListener(Listener current)
        {
            return repoLayer.GetListeners(connection).Where(x => x.Wallet < current.Wallet).OrderByDescending(x => x.Wallet).FirstOrDefault();
        }

        /// <summary>
        /// Update all listener in outs
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Clear all data
        /// </summary>
        public void ClearAllData()
        {
            repoLayer.ClearAllData(connection);
        }

        /// <summary>
        /// Get year stats for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public YearStats GetYearStats(int year)
        {
            return repoLayer.GetYearStats(connection).SingleOrDefault(x => x.Year.Equals(year));
        }

        /// <summary>
        /// Delete overdue listeners
        /// </summary>
        /// <param name="months">The number of months before they are classed as overdue.</param>
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

        /// <summary>
        /// Get listeners ordered by waller or surname
        /// </summary>
        /// <param name="ordering"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update the year stats
        /// </summary>
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

        /// <summary>
        /// Get the listeners that have been inactive for over 3 months (used in stats)
        /// </summary>
        /// <returns></returns>
        public int Get3MonthInactiveListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.LastOut.HasValue && x.LastOut < DateTime.Now.AddMonths(-3)).Count();
        }

        /// <summary>
        /// Get the listeners that have been inactive for over 1 months.
        /// </summary>
        /// <returns></returns>
        public List<Listener> Get1MonthDormantListeners()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.LastOut.HasValue && x.LastOut < DateTime.Now.AddMonths(-1)).ToList();
        }

        /// <summary>
        /// Get the listeners at the year start.
        /// </summary>
        /// <remarks>To calculate this get the last weekly stats for the previous year and use the total count</remarks>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the number of memory sticks on loan
        /// </summary>
        /// <returns></returns>
        public int GetMemorySticksOnLoan()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.MemStickPlayer).Count();
        }

        /// <summary>
        /// Get the number of inactive wallets
        /// </summary>
        /// <returns></returns>
        public int GetInactiveWalletNumbers()
        {
            return repoLayer.GetListeners(connection).Where(x => x.Status.Equals(ListenerStates.DELETED)).Count();
        }

        /// <summary>
        /// Get new listeners for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNewListenersForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return repoLayer.GetListeners(connection).Where(x => x.Joined >= yearStart && x.Joined <= yearEnd && x.Status != ListenerStates.DELETED).Count();
        }

        /// <summary>
        /// Get the lost listeners for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetLostListenersForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return repoLayer.GetListeners(connection).Where(x => x.Status == ListenerStates.DELETED && x.DeletedDate >= yearStart && x.DeletedDate <= yearEnd).Count();
        }

        /// <summary>
        /// Get new listeners for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetNetListenersForYear(int year)
        {
            return GetNewListenersForYear(year) - GetLostListenersForYear(year);
        }

        /// <summary>
        /// Get average listeners for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get average dispatched wallets
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get average paused listener count
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get wallets dispatched for a year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetWalletsDispatchedForYear(int year)
        {
            DateTime yearStart = DateTime.Parse("01/01/" + year);
            DateTime yearEnd = DateTime.Parse("31/12/" + year);

            return (int)repoLayer.GetWeeklyStats(connection).Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Sum(x => x.ScannedOut + x.ScannedIn);
        }

        /// <summary>
        /// Get the current week number
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get a new week number
        /// </summary>
        /// <returns></returns>
        public int GetNewWeekNumber()
        {
            return GetCurrentWeekNumber() + 1;
        }

        /// <summary>
        /// Get the current listener count
        /// Get the count of active or paused listeners (basically not deleted!
        /// </summary>
        /// <returns></returns>
        public int GetCurrentListenerCount()
        {
            return repoLayer.GetListeners(connection).Where(x => !x.Status.Equals(ListenerStates.DELETED)).Count();
        }

        /// <summary>
        /// Clear all data except the collectors (for import etc)
        /// </summary>
        public void ClearAllDataExceptCollectors()
        {
            ClearListeners();
            ClearWeeklyStats();
            ClearYearlyStats();
        }

        /// <summary>
        /// Run a command directly!
        /// </summary>
        /// <param name="sqlCommand"></param>
        public void RunCommand(string sqlCommand)
        {
            repoLayer.RunCommand(connection, sqlCommand);
        }

        /// <summary>
        /// Get the current week stats
        /// </summary>
        /// <returns></returns>
        public WeeklyStats GetCurrentWeekStats()
        {
            int currentWeekNumber = GetCurrentWeekNumber();
            WeeklyStats forTheWeek = repoLayer.GetWeeklyStats(connection).ToList().Where(x => x.WeekNumber == currentWeekNumber).FirstOrDefault();

            return (forTheWeek != null ? forTheWeek : new WeeklyStats());
        }

        /// <summary>
        /// Clean deleted dates from non deleted listeners
        /// </summary>
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

        /// <summary>
        /// Record some scan in the database
        /// </summary>
        /// <param name="wallet">The wallet id</param>
        /// <param name="scanType">The scan type</param>
        /// <returns></returns>
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
