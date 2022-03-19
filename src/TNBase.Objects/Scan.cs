using System;

namespace TNBase.Objects
{
    public class Scan
    {
        public Scan()
        {
            ScanType = ScanTypes.IN;
            WalletType = WalletTypes.News;
        }

        public int Id { get; set; }

        public int Wallet { get; set; }

        public ScanTypes ScanType { get; set; }

        public WalletTypes WalletType { get; set; }

        public DateTime Recorded { get; set; }
    }
}
