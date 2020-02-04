using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public class ScanService
    {
        private readonly ITNBaseContext context;

        public ScanService(ITNBaseContext context)
        {
            this.context = context;
        }

        public SQLiteConnection Connection { get; }

        public void AddScans(IEnumerable<Scan> scans)
        {
            foreach (var scan in scans)
            {
                var listener = context.Listeners.FirstOrDefault(x => x.Wallet == scan.Wallet);
                if (listener != null)
                {
                    UpdateListenerStock(listener, scan.ScanType, scan.WalletType);
                }

                context.Scans.Add(new Scan
                {
                    Wallet = scan.Wallet,
                    ScanType = scan.ScanType,
                    WalletType = scan.WalletType,
                    Recorded = DateTime.UtcNow
                });
            }

            context.SaveChanges();
        }

        private void UpdateListenerStock(Listener listener, ScanTypes scanType, WalletTypes walletType)
        {
            var increment = scanType == ScanTypes.OUT ? -1 : 1;

            switch (walletType)
            {
                case WalletTypes.News:
                    listener.Stock += increment;
                    break;
                case WalletTypes.Magazine:
                    listener.MagazineStock += increment;
                    break;
                default:
                    break;
            }
        }
    }
}
