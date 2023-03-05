using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using NLog;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase.External.DataExport
{
    public class CsvExportService
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();

        public CsvExportService()
        {
        }

        public string ExportListeners(List<Listener> listeners)
        {
            string result;

            var dataWriter = new StringWriter();

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);

            using (var csv = new CsvWriter(dataWriter, configuration))
            {
                csv.Context.RegisterClassMap<ListenerCsvMap>();
                csv.Context.TypeConverterCache.AddConverter<ListenerStates>(new EnumConverter(typeof(ListenerStates)));
                csv.Context.TypeConverterOptionsCache.GetOptions<ListenerStates>().EnumIgnoreCase = true;
                log.Debug("Listener Export: configuration complete");

                csv.WriteRecords(listeners);
            }

            result = dataWriter.ToString();

            return result;
        }
    }
}
