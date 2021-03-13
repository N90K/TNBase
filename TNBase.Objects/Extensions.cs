using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TNBase.Objects
{
    public static class Extensions
    {
        public const string SQL_DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
        public const string SQL_DATE_FORMAT = "yyyy-MM-dd";
        public const string NICE_FORMAT = "dd/MM/yyyy";

        public static string ToSQLiteStr(this DateTime dateTime)
        {
            return dateTime.ToString(SQL_DATE_FORMAT);
        }

        public static string ToSQLiteUtcString(this DateTime dateTime)
        {
            return dateTime.ToString(SQL_DATE_TIME_FORMAT);
        }

        public static DateTime TruncateMilliseconds(this DateTime dateTime)
        {
            return dateTime.AddMilliseconds(-dateTime.Millisecond);
        }

        public static string ToNiceStr(this DateTime dateTime)
        {
            return dateTime.ToString(NICE_FORMAT);
        }

        public static string ToSQLiteInsertStr(this Nullable<DateTime> dateTime)
        {
            string result = "NULL";
            if (dateTime.HasValue)
            {
                result = "date('" + dateTime.Value.ToSQLiteStr() + "')";
            }
            return result;
        }

        public static string ToSQLiteInsertStr(this DateTime dateTime)
        {
            return "date('" + dateTime.ToSQLiteStr() + "')";
        }

        public static string Serialize<T>(this T value)
        {
            if (value == null) { return string.Empty; }

            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();

            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);
                return stringWriter.ToString();
            }
        }
    }
}
