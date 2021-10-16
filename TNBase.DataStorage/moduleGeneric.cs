using System;
using TNBase.Infrastructure;
using TNBase.Infrastructure.Helpers;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public static class ModuleGeneric
    {
        // This is the path to the database!
        public static string DATABASE_NAME = "Listeners.s3db";
        public static string DATABASE_PATH = "Resource\\" + DATABASE_NAME;

        // Formatting consts and defaults.
        public const string DATE_FORMAT = "dd/MM/yyyy";

        public const string TIME_FORMAT = "HH:mm:ss";

        // Variables
        private static DateTime startTime;

        private static DateTime endTime;
        // Save start time.
        public static void SaveStartTime()
        {
            startTime = DateTime.Now;
        }

        // Save end time.
        public static void saveEndTime()
        {
            endTime = DateTime.Now;
        }

        public static string getAppShortName()
        {
            return "TNBase";
        }

        // Get start time.
        public static string getElapsedTimeString()
        {
            TimeSpan elapsedTime = default(TimeSpan);
            elapsedTime = endTime.Subtract(startTime);
            return string.Format("{0:00}:{1:00}:{2:00}", elapsedTime.TotalHours, elapsedTime.Minutes, elapsedTime.Seconds);
        }

        // Get elapsed time.
        public static string getStartTimeString()
        {
            return startTime.ToString(TIME_FORMAT);
        }

        // Get end time.
        public static string getEndTimeString()
        {
            return endTime.ToString(TIME_FORMAT);
        }

        //// Get version number printable string.
        //public static string getVersionString()
        //{
        //    return "V " + Application.ProductVersion;
        //}


        // Get the application path.
        public static string getStartPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Get the database path.
        /// </summary>
        /// <returns></returns>
        public static string GetDatabasePath()
        {
            return getStartPath() + "\\" + DATABASE_PATH;
        }

        /// <summary>
        /// Get the log file path!
        /// </summary>
        /// <returns></returns>
        public static string GetLogFilePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + getAppShortName() + "\\Debug.log";
        }

        /// <summary>
        /// Update weekly stats
        /// </summary>
        public static void UpdateStatsWeek(IServiceLayer DBServiceLayer, bool updateInOuts = false)
        {
            WeeklyStats stats = DBServiceLayer.GetCurrentWeekStats();
            stats.WeekNumber = DBServiceLayer.GetCurrentWeekNumber();
            stats.ScannedIn = stats.ScannedIn + ModuleScanning.getScannedIn();
            stats.ScannedOut = stats.ScannedOut + ModuleScanning.getScannedOut();
            stats.TotalListeners = DBServiceLayer.GetCurrentListenerCount();
            stats.PausedCount = DBServiceLayer.GetListenersByStatus(ListenerStates.PAUSED).Count;

            // Just update it if it already exists
            if (DBServiceLayer.WeeklyStatExistsForWeek(stats.WeekNumber))
            {
                DBServiceLayer.UpdateWeeklyStats(stats);
            }
            else
            {
                DBServiceLayer.SaveWeekStats(stats);
            }

            // Update the in/outs if required
            if (updateInOuts)
            {
                // Update in/out stats.
                DBServiceLayer.UpdateListenerInOuts();
            }
        }
    }
}
