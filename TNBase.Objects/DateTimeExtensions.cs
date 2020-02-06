using System;

namespace TNBase.Objects
{
    public static class DateTimeExtensions
    {
        public const string DEFAULT_FORMAT = "dd/MM/yyyy";
        public const string BIRTHDAY_FORMAT = "dd/MM"; // No year

        /// <summary>
        /// Convert a nullable datetime to a nice format string
        /// </summary>
        /// <param name="dateTime">The nullable datetime</param>
        /// <param name="format">Optional format. Default: dd/MM/yyyy</param>
        /// <returns>the formatted date or N/a if its null</returns>
        public static string ToNullableNaString(this Nullable<DateTime> dateTime, string format = DEFAULT_FORMAT)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString(format);
            }
            else
            {
                return "N/a";
            }
        }
    }
}
