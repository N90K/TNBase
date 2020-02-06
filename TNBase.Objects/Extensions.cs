using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TNBase.Objects
{
    /// <summary>
    /// Some extension methods
    /// </summary>
    public static class Extensions
    {
        // SQL Date format
        public const string SQL_DATE_FORMAT = "yyyy-MM-dd";
        public const string NICE_FORMAT = "dd/MM/yyyy";

        /// <summary>
        /// Get the sqlite format datetime string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToSQLiteStr(this DateTime dateTime)
        {
            return dateTime.ToString(SQL_DATE_FORMAT);
        }

        /// <summary>
        /// Get the sqlite format datetime string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToNiceStr(this DateTime dateTime)
        {
            return dateTime.ToString(NICE_FORMAT);
        }

        /// <summary>
        /// Format a nullable datetime nicely
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>an empty string of nicely formatted string</returns>
        public static string ToSQLiteInsertStr(this Nullable<DateTime> dateTime) 
        {
            string result = "NULL";
            if (dateTime.HasValue)
            {
                result = "date('" + dateTime.Value.ToSQLiteStr() + "')";
            }
            return result;
        }

        /// <summary>
        /// Format a nullable datetime nicely
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>an empty string of nicely formatted string</returns>
        public static string ToSQLiteInsertStr(this DateTime dateTime)
        {
            return "date('" + dateTime.ToSQLiteStr() + "')";
        }

        /// <summary>
        /// Serialize some object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
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
