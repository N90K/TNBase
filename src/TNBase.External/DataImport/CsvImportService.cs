using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using NLog;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TNBase.DataStorage;
using TNBase.Objects;

namespace TNBase.External.DataImport
{
    public class CsvImportService
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly ITNBaseContext context;

        public CsvImportService(ITNBaseContext context)
        {
            this.context = context;
        }

        public ImportResult ImportListeners(string importData)
        {
            log.Debug("Listener Import: started");
            if (string.IsNullOrWhiteSpace(importData))
            {
                log.Debug($"Listener Import: {nameof(importData)} parameter is null or empty");
                throw new InvalidImportDataException("No records found");
            }

            var resultItems = new Dictionary<int, ImportResultItem>();

            var dataReader = new StringReader(importData);

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ReadingExceptionOccurred = c =>
                {
                    log.Debug($"Listener Import: ReadingExceptionOccured for line {c.Exception.Context.Parser.Row}", c.Exception);
                    if (c.Exception is MissingFieldException missingFieldException)
                    {
                        var message = missingFieldException.Message.Split('.')[0];
                        log.Warn($"Listener Import: MissingFieldException - '{message}'");
                        throw new InvalidImportDataException(message);
                    }

                    var resultItem = resultItems[c.Exception.Context.Parser.Row];
                    if (c.Exception.InnerException is FieldValidationException validationException)
                    {
                        log.Warn($"Listener Import: FieldValidationException - '{validationException.Message}'");
                        resultItem.SetError(validationException.FieldName, validationException.Message, c.Exception.Context.Parser.RawRecord);
                    }
                    return false;
                }
            };

            var isDirty = false;
            using var csv = new CsvReader(dataReader, configuration);
            csv.Context.RegisterClassMap<ListenerCsvMap>();
            csv.Context.TypeConverterCache.AddConverter<ListenerStates>(new EnumConverter(typeof(ListenerStates)));
            csv.Context.TypeConverterOptionsCache.GetOptions<ListenerStates>().EnumIgnoreCase = true;
            log.Debug("Listener Import: configuration complete");

            csv.Read();
            csv.ReadHeader();
            csv.ValidateHeader<Listener>();
            var rawHeader = csv.Parser.RawRecord.Replace(System.Environment.NewLine, "");
            log.Debug("Listener Import: header validated");
            var wallets = new Dictionary<int, int>();

            while (csv.Read())
            {
                log.Debug($"Listener Import: reading line {csv.Parser.Row}");
                resultItems.Add(csv.Parser.Row, new ImportResultItem(csv.Parser.Row));
                var listener = csv.GetRecord<Listener>();
                if (listener != null)
                {
                    log.Debug($"Listener Import: listener parsed");
                    var existingListener = context.Listeners.SingleOrDefault(x => x.Wallet == listener.Wallet);
                    if (existingListener != null)
                    {
                        log.Warn($"Listener Import: listener with wallet number {listener.Wallet} already exists");
                        var resultItem = resultItems[csv.Context.Parser.Row];
                        resultItem.SetError("Wallet", $"Listener with wallet number {listener.Wallet} already exists", csv.Context.Parser.RawRecord);
                    }
                    else
                    {
                        if (listener.Wallet > 0)
                        {
                            if (wallets.ContainsKey(listener.Wallet))
                            {
                                var resultItem = resultItems[csv.Context.Parser.Row];
                                resultItem.SetError("Wallet", 
                                    $"Duplicate wallet number. Wallet '{listener.Wallet}' was imported at row number '{wallets[listener.Wallet]}'", 
                                    csv.Context.Parser.RawRecord);
                                continue;
                            }
                            wallets.Add(listener.Wallet, csv.Parser.Row);
                        }

                        context.Listeners.Add(listener);
                        isDirty = true;
                        log.Debug($"Listener Import: listener with wallet number {csv.Parser.Row} has been imported");
                    }
                }
            }

            if (isDirty)
            {
                log.Debug("Listener Import: saving changes");
                context.SaveChanges();
            }

            var succeeded = resultItems.Count(x => !x.Value.HasError);
            var failed = resultItems.Count(x => x.Value.HasError);
            var total = resultItems.Count();
            log.Debug($"Listener Import: complete. Succeeded: {succeeded}, failed: {failed}, total: {total}.");
            return new ImportResult { Records = resultItems.Values, RawHeader = rawHeader };
        }
    }
}
