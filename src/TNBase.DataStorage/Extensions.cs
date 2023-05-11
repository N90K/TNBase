using System;
using TNBase.Infrastructure.Helpers;

namespace TNBase.DataStorage
{
    public static class Extensions
    {
        /// <summary>
        /// Ensure the date is at least the min date
        /// </summary>
        /// <returns></returns>
        public static DateTime EnsureMinDate(this DateTime dateTime)
        {
            var minDate = DateTime.ParseExact("01/01/1900", DateHelpers.DEFAULT_DATE_FORMAT, null);
            if (dateTime < minDate)
            {
                return minDate;
            }
            return dateTime;
        }
    }
}
