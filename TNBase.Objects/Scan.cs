using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Type { get; set; }

        public ScanTypes ScanType
        {
            get
            {
                Enum.TryParse<ScanTypes>(Type, out var scanType);
                return scanType;
            }
            set
            {
                Type = value.ToString();
            }
        }

        public WalletTypes WalletType
        {
            get
            {
                Enum.TryParse<WalletTypes>(WalletTypeValue, out var walletType);
                return walletType;
            }
            set
            {
                WalletTypeValue = value.ToString();
            }
        }
        public DateTime Recorded { get; set; }

        public string WalletTypeValue { get; set; }
    }
}
