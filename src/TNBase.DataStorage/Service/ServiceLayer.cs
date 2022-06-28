using TNBase.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using TNBase.Infrastructure.Extensions;
using System.Data.Entity;
using TNBase.Infrastructure.Helpers;

namespace TNBase.DataStorage
{
    public class ServiceLayer : IServiceLayer
    {
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        private readonly ITNBaseContext context;

        public ServiceLayer(ITNBaseContext context)
        {
            this.context = context;
        }

        public List<Listener> GetListenersByName(string forename, string surname, string title = null)
        {
            List<Listener> results = null;

            if (string.IsNullOrEmpty(forename) || forename.Equals("*"))
            {
                results = context.Listeners.Where(x => x.Surname.ToLower().Equals(surname.ToLower())).ToList();
            }
            else if (string.IsNullOrEmpty(surname) || surname.Equals("*"))
            {
                results = context.Listeners.Where(x => x.Forename.ToLower().Equals(forename.ToLower())).ToList();
            }
            else
            {
                results = context.Listeners.Where(
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
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            return context.WeeklyStats.Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).ToList();
        }

        public List<Listener> GetAlphabeticList()
        {
            return context.Listeners.Where(x => !x.Status.Equals(ListenerStates.DELETED)).OrderBy(x => x.Surname).ToList();
        }

        public List<Listener> GetOnlineOnlyListenersOrderedBySurname()
        {
            return context.Listeners.Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.OnlineOnly).OrderBy(x => x.Surname).ToList();
        }

        public List<Listener> GetNextWeekBirthdays()
        {
            var list = context.Listeners.ToList().Where(x =>
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

        public List<Listener> GetInactiveListeners()
        {
            return GetListenersByStatus(ListenerStates.DELETED);
        }

        public List<Listener> GetUnsentListeners()
        {
            return context.Listeners.ToList().Where(x => x.InOutRecords.Out8.Equals(0) && x.Status.Equals(ListenerStates.ACTIVE) && !x.OnlineOnly).ToList();
        }

        public List<Listener> GetRecentlyAddedListeners()
        {
            DateTime fewDaysBack = DateTime.Today.AddDays(-6);

            return context.Listeners.ToList().Where(x => x.Status.Equals(ListenerStates.ACTIVE) && x.Joined > fewDaysBack && x.Joined <= DateTime.Now).ToList();
        }

        public List<Listener> GetRecentlyDeletedListeners()
        {
            DateTime fewDaysBack = DateTime.Today.AddDays(-6);

            return context.Listeners.ToList().Where(x => x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate > fewDaysBack && x.DeletedDate <= DateTime.Now).ToList();
        }

        public void ResumePausedListeners()
        {
            log.Debug("Resuming paused listeners!");

            var listeners = GetStoppedListeners();

            foreach (var listener in listeners)
            {
                if (listener.HasPausePeriodElapsed)
                {
                    listener.Resume();
                    UpdateListener(listener);
                }
            }
        }

        public List<Listener> GetStoppedListeners()
        {
            return context.Listeners.ToList().Where(x => x.Status == ListenerStates.PAUSED).ToList();
        }

        public List<Listener> GetUnreturnedSpeakerListeners()
        {
            return context.Listeners.Where(x => (x.Status.Equals(ListenerStates.DELETED) || x.OnlineOnly) && x.MemStickPlayer).ToList();
        }

        public List<Listener> GetActiveListenersNotScannedIn()
        {
            return context.Listeners.ToList().Where(x =>
                x.Status.Equals(ListenerStates.ACTIVE) &&
                !x.OnlineOnly &&
                x.InOutRecords.In7.Equals(0) &&
                x.Stock > 0).ToList();
        }

        public bool AddCollector(Collector collector)
        {
            try
            {
                context.Collectors.Add(collector);
                context.SaveChanges();

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
                context.Collectors.Attach(collector);
                context.SaveChanges();

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
            return context.Collectors.ToList();
        }

        public Listener GetListenerById(int id)
        {
            return context.Listeners.Include(x => x.InOutRecords).SingleOrDefault(x => x.Wallet.Equals(id));
        }

        public int AddListener(Listener listener)
        {
            context.Listeners.Add(listener);
            context.SaveChanges();

            log.Info("Added new listener: " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
            return listener.Wallet;
        }

        public void UpdateListener(Listener listener)
        {
            context.Listeners.Attach(listener);
            context.SaveChanges();
            log.Info("Updated listener: " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
        }

        public void SoftDeleteListener(Listener listener, string reason)
        {
            listener.Status = ListenerStates.DELETED;
            listener.StatusInfo = reason;
            listener.DeletedDate = DateTime.Now;

            context.Listeners.Attach(listener);
            context.SaveChanges();
            log.Info("Deleted listener (soft): " + listener.Forename + " " + listener.Surname + ", Wallet: " + listener.Wallet);
        }

        public List<Listener> GetListeners()
        {
            return context.Listeners.ToList();
        }

        public List<Listener> GetPostListeners()
        {
            return context.Listeners.Where(x => !x.OnlineOnly).ToList();
        }

        public bool DeleteCollector(Collector collector)
        {
            context.Collectors.Remove(collector);
            context.SaveChanges();

            log.Info("Deleted collector: " + collector.Forename + " " + collector.Surname);
            return true;
        }

        public int GetHighestYearNumber()
        {
            return context.YearStats.Max(x => x.Year);
        }

        public int GetHighestWeekNumber()
        {
            return context.WeeklyStats.Count() == 0 ? 0 : context.WeeklyStats.Max(x => x.WeekNumber);
        }

        public int GetMinimumYear()
        {
            return context.YearStats.Min(x => x.Year);
        }

        public Collector GetCollector(int id)
        {
            return context.Collectors.SingleOrDefault(x => x.Id.Equals(id));
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

            WeeklyStats stats = context.WeeklyStats.SingleOrDefault(x => x.WeekNumber.Equals(highestWeekNumber));

            // If we are in a later year, its an easy decision
            if (DateTime.Today.Year > stats.WeekDate.Year)
            {
                return true;
            }

            // Is it within the last few days?
            return (DateTime.Today.DayOfYear > (stats.WeekDate.DayOfYear + 5));
        }

        public List<Listener> GetListenersByStatus(ListenerStates status)
        {
            return context.Listeners.ToList().Where(x => x.Status.Equals(status)).ToList();
        }

        public List<Listener> GetPostListenersByStatus(ListenerStates status)
        {
            return context.Listeners.ToList().Where(x => x.Status.Equals(status) && !x.OnlineOnly).ToList();
        }

        public List<WeeklyStats> GetAllWeeklyStats()
        {
            return context.WeeklyStats.ToList();
        }

        public List<YearStats> GetAllYearlyStats()
        {
            return context.YearStats.ToList();
        }

        public bool SaveYearStats(YearStats stats)
        {
            context.YearStats.Add(stats);
            context.SaveChanges();
            return true;
        }

        public bool SaveWeekStats(WeeklyStats stats)
        {
            context.WeeklyStats.Add(stats);
            context.SaveChanges();
            return true;
        }

        public bool WeeklyStatExistsForWeek(int weekNumber)
        {
            return context.WeeklyStats.Where(x => x.WeekNumber == weekNumber).Any();
        }

        public bool RestoreListener(Listener listener)
        {
            listener.Status = ListenerStates.ACTIVE;
            listener.StatusInfo = "";
            listener.DeletedDate = null;

            context.Listeners.Attach(listener);
            context.SaveChanges();
            return true;
        }

        public List<Listener> GetListenersWithBirthdays()
        {
            return context.Listeners.Where(x => x.BirthdayDay.HasValue && x.BirthdayMonth.HasValue).ToList();
        }

        public bool UpdateYearStats(YearStats stats)
        {
            context.YearStats.Attach(stats);
            context.SaveChanges();
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

            List<Collector> alist = context.Collectors.ToList();

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
            context.WeeklyStats.Attach(stats);
            context.SaveChanges();
            return true;
        }

        public Listener GetNextListener(Listener current)
        {
            return context.Listeners.Where(x => x.Wallet > current.Wallet).OrderBy(x => x.Wallet).FirstOrDefault();
        }

        public Listener GetPreviousListener(Listener current)
        {
            return context.Listeners.Where(x => x.Wallet < current.Wallet).OrderByDescending(x => x.Wallet).FirstOrDefault();
        }

        public bool UpdateListenerInOuts()
        {
            log.Debug("Updating IN/OUT values for listeners...");

            List<Listener> listeners = GetListeners();

            // TODO (M) Optimise as a query and create a test?!?
            foreach (Listener l in listeners)
            {
                l.InOutRecords.In1 = l.InOutRecords.In2;
                l.InOutRecords.In2 = l.InOutRecords.In3;
                l.InOutRecords.In3 = l.InOutRecords.In4;
                l.InOutRecords.In4 = l.InOutRecords.In5;
                l.InOutRecords.In5 = l.InOutRecords.In6;
                l.InOutRecords.In6 = l.InOutRecords.In7;
                l.InOutRecords.In7 = l.InOutRecords.In8;
                l.InOutRecords.In8 = 0;

                l.InOutRecords.Out1 = l.InOutRecords.Out2;
                l.InOutRecords.Out2 = l.InOutRecords.Out3;
                l.InOutRecords.Out3 = l.InOutRecords.Out4;
                l.InOutRecords.Out4 = l.InOutRecords.Out5;
                l.InOutRecords.Out5 = l.InOutRecords.Out6;
                l.InOutRecords.Out6 = l.InOutRecords.Out7;
                l.InOutRecords.Out7 = l.InOutRecords.Out8;
                l.InOutRecords.Out8 = 0;

                // If they are active we wont read them out but will send.
                if (l.Status.Equals(ListenerStates.ACTIVE))
                {
                    if (l.InOutRecords.In7 >= 1)
                    {
                        l.InOutRecords.Out8 = 1;
                    }
                }

            }

            context.SaveChanges();
            log.Debug("Finished updating IN/OUT values for listeners...");

            return true;
        }

        public YearStats GetYearStats(int year)
        {
            return context.YearStats.SingleOrDefault(x => x.Year.Equals(year));
        }

        public void DeleteOverdueDeletedListeners(int months)
        {
            List<Listener> listeners = context.Listeners.ToList().Where(x => x.Status.Equals(ListenerStates.DELETED) && x.DeletedDate < DateTime.Now.AddMonths(-months)).ToList();

            foreach (Listener l in listeners)
            {
                log.Info("Purging listener with id: " + l.Wallet + " as they have been marked as deleted for over " + months + " months.");
                context.Listeners.Remove(l);
            }

            context.SaveChanges();
        }

        public List<Listener> GetOrderedListeners(OrderVar ordering)
        {
            if (ordering.Equals(OrderVar.SURNAME))
            {
                return context.Listeners.OrderBy(x => x.Surname).ToList();
            }
            else
            {
                return context.Listeners.OrderBy(x => x.Wallet).ToList();
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
                    AverageListeners = GetAverageListenersForYear(lastYear),
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

                context.YearStats.Add(newStats);
                context.SaveChanges();
            }
        }

        public int Get3MonthInactiveListeners()
        {
            return context.Listeners.Where(x =>
                !x.Status.Equals(ListenerStates.DELETED) &&
                !x.OnlineOnly &&
                x.LastOut.HasValue &&
                x.LastOut < DateTime.Now.AddMonths(-3)
            ).Count();
        }

        public List<Listener> Get1MonthDormantListeners()
        {
            return context.Listeners.Where(x =>
                x.Status.Equals(ListenerStates.ACTIVE) &&
                !x.OnlineOnly &&
                x.LastOut.HasValue &&
                x.LastOut < DateTime.Now.AddMonths(-1)
            ).ToList();
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
            return context.Listeners.ToList().Where(x => !x.Status.Equals(ListenerStates.DELETED) && x.MemStickPlayer).Count();
        }

        public int GetInactiveWalletNumbers()
        {
            return context.Listeners.ToList().Where(x => x.Status.Equals(ListenerStates.DELETED) && !x.OnlineOnly).Count();
        }

        public int GetNewListenersForYear(int year)
        {
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            return context.Listeners.ToList().Where(x => x.Joined >= yearStart && x.Joined <= yearEnd && x.Status != ListenerStates.DELETED).Count();
        }

        public int GetLostListenersForYear(int year)
        {
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            return context.Listeners.ToList().Where(x => x.Status == ListenerStates.DELETED && x.DeletedDate >= yearStart && x.DeletedDate <= yearEnd).Count();
        }

        public int GetNetListenersForYear(int year)
        {
            return GetNewListenersForYear(year) - GetLostListenersForYear(year);
        }

        public int GetAverageListenersForYear(int year)
        {
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            int defaultRet = 0;
            try
            {
                defaultRet = (int)context.WeeklyStats.Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Average(x => x.TotalListeners);
            }
            catch (Exception e)
            {
                log.Warn(e, "Couldnt calculate average listeners for year: " + year);
            }
            return defaultRet;
        }

        public int GetAverageDispatchedWallets(int year)
        {
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            int defaultRet = 0;
            try
            {
                IEnumerable<WeeklyStats> weeklyStats = context.WeeklyStats.Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd);
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
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            int defaultRet = 0;
            try
            {
                defaultRet = (int)context.WeeklyStats.Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Average(x => x.PausedCount);
            }
            catch (Exception e)
            {
                log.Warn(e, "Couldnt calculate average paused wallets for year: " + year);
            }
            return defaultRet;
        }

        public int GetWalletsDispatchedForYear(int year)
        {
            DateTime yearStart = DateTime.ParseExact("01/01/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime yearEnd = DateTime.ParseExact("31/12/" + year, DateHelpers.DEFAULT_DATE_FORMAT, null);

            return (int)context.WeeklyStats.Where(x => x.WeekDate >= yearStart && x.WeekDate <= yearEnd).Sum(x => x.ScannedOut + x.ScannedIn);
        }

        public int GetCurrentWeekNumber()
        {
            // Gets the latest weekly stats.
            WeeklyStats myStats = context.WeeklyStats.OrderByDescending(x => x.WeekNumber).FirstOrDefault();

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

        public int GetCurrentListenerCount()
        {
            return context.Listeners.ToList().Where(x => !x.Status.Equals(ListenerStates.DELETED)).Count();
        }

        public WeeklyStats GetCurrentWeekStats()
        {
            int currentWeekNumber = GetCurrentWeekNumber();
            WeeklyStats forTheWeek = context.WeeklyStats.ToList().Where(x => x.WeekNumber == currentWeekNumber).FirstOrDefault();

            return (forTheWeek != null ? forTheWeek : new WeeklyStats { WeekNumber = currentWeekNumber });
        }

        public void RecordScan(int wallet, ScanTypes scanType)
        {
            var scan = new Scan
            {
                Wallet = wallet,
                ScanType = scanType,
                Recorded = DateTime.UtcNow
            };

            context.Scans.Add(scan);
            context.SaveChanges();
        }
    }
}
