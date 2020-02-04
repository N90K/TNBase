using System;
using System.Globalization;

namespace TNBase.Extensions
{
    public static class DateTimeExtensions
    {
        public static int WeekOfYear(this DateTime dateTime)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(dateTime);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime.AddDays(4 - (day == 0 ? 7 : day)), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime WeekStart(this DateTime dateTime)
        {
            var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(dateTime);
            day = AdjustForWeekStartOnMonday(day);
            return dateTime.Date.AddDays(-1 * day);
        }

        public static DateTime NextWeekStart(this DateTime dateTime)
        {
            return dateTime.WeekStart().AddDays(7);
        }

        private static int AdjustForWeekStartOnMonday(int day)
        {
            return (day == 0 ? 7 : day) - 1;
        }
    }
}
