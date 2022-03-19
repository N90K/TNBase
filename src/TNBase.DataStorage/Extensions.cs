using System;

namespace TNBase.DataStorage
{
    /// <summary>
    /// Some extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Ensure the date is at least the min date
        /// </summary>
        /// <returns></returns>
        public static DateTime EnsureMinDate(this DateTime dateTime)
        {
            if (dateTime < DBUtils.AppMinDate())
            {
                return DBUtils.AppMinDate();
            }
            return dateTime;
        }
    }
}
