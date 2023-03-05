using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using TNBase.Objects;

namespace TNBase.External.TypeConverters
{
    public class StatusInfoConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var isPaused = row.GetField<string>("Status").ToLowerInvariant() == ListenerStates.PAUSED.ToString().ToLowerInvariant();
            if (!isPaused) return "";

            var hasStartDate = DateTime.TryParseExact(row.GetField<string>("PauseStartDate"), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var startDate);
            var hasEndDate = DateTime.TryParseExact(row.GetField<string>("PauseEndDate"), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var endDate);

            if (!hasStartDate && !hasEndDate) return "";

            var startDateString = hasStartDate ? startDate.ToString("dd/MM/yyyy") : "";
            var endDateString = hasEndDate ? endDate.ToString("dd/MM/yyyy") : "UFN";
            var info = $"{startDateString},{endDateString}";
            return info;
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            var info = (string)value;
            
            if (string.IsNullOrEmpty(info) || info.IndexOf(",") == -1)
            {
                return string.Empty;
            }

            if (memberMapData.Names[0] == "PauseStartDate")
            {
                return info.Substring(0, info.IndexOf(','));
            }
            else
            {
                return info.Substring(info.IndexOf(',') + 1);
            }
        }
    }
}