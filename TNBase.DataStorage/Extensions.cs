using TNBase.DataStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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
