using System;
using TNBase.Infrastructure.Helpers;

namespace TNBase.DataStorage
{
    public static class DBUtils
    {
        /// <summary>
        /// Generate the connection string
        /// </summary>
        /// <returns></returns>
        public static string GenConnectionString(string databasePath)
        {
            return $"Data Source={databasePath}";
        }

        /// <summary>
        /// Copy a database from a path to another
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        /// <returns></returns>
        public static bool CopyDatabase(string oldPath, string newPath)
        {
            System.IO.File.Copy(oldPath, newPath, true);

            // Check the copied file exists.
            return (System.IO.File.Exists(newPath));
        }

        /// <summary>
        /// Copy a database from a path to another
        /// </summary>
        /// <param name="newPath"></param>
        /// <returns></returns>
        public static bool RestoreDatabase(string backupPath, string newPath)
        {
            return CopyDatabase(backupPath, newPath);
        }

        /// <summary>
        /// Get the min date time
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime AppMinDate()
        {
            return DateTime.ParseExact("01/01/1900", DateHelpers.DEFAULT_DATE_FORMAT, null);
        }
    }
}
