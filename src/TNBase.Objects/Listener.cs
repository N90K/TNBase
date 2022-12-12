using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TNBase.Infrastructure.Extensions;

namespace TNBase.Objects
{
    public class Listener
    {
        public const string NEVER_END_PAUSE_STRING = "UFN";
        //public const int DEFAULT_NEWS_STOCK = 3;
        //public const int DEFAULT_MAGAZINE_STOCK = 1;

        public Listener()
        {
            Joined = DateTime.Now;
            Status = ListenerStates.ACTIVE;
        }

        [Key, ForeignKey("Listener")]
        public int Wallet { get; set; }

        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public bool WarnOfAddressChange { get; set; }
        public string Telephone { get; set; }
        public bool OnlineOnly { get; set; }
        public bool MemStickPlayer { get; set; }
        public bool Magazine { get; set; }
        public int? BirthdayDay { get; set; }
        public int? BirthdayMonth { get; set; }

        public bool HasBirthday => BirthdayDay.HasValue && BirthdayMonth.HasValue;

        public string BirthdayText => HasBirthday ? $"{BirthdayDay.Value.WithSuffix()} {DateTimeFormatInfo.CurrentInfo.GetMonthName(BirthdayMonth.Value)}" : "N/A";

        public DateTime? NextBirthdayDate
        {
            get
            {
                if (!HasBirthday)
                {
                    return null;
                }

                var now = DateTime.Now;
                var isNextYear = BirthdayMonth.Value < now.Month || (BirthdayDay < now.Day && BirthdayMonth == now.Month);
                var year = isNextYear ? now.Year + 1 : now.Year;

                if (!DateTime.IsLeapYear(year) && BirthdayDay == 29 && BirthdayMonth == 2)
                {
                    return new DateTime(year, 3, 1); // move birthday forward by a day if not leap year
                }

                return new DateTime(year, BirthdayMonth.Value, BirthdayDay.Value);
            }
        }

        [XmlIgnore]
        public DateTime? Joined { get; set; }

        public string Info { get; set; }

        public ListenerStates Status { get; set; }

        public string StatusInfo { get; set; }

        public virtual InOutRecords InOutRecords { get; set; }

        public DateTime? DeletedDate { get; set; }
        public int Stock { get; set; }
        public DateTime? LastIn { get; set; }
        public DateTime? LastOut { get; set; }
        public int MagazineStock { get; set; }

        public int NewsWalletsIssued { get; set; }
        public int MagazineWalletsIssued { get; set; }

        public int SentNewsWallets => NewsWalletsIssued - Stock;
        public int SentMagazineWallets => Magazine ? MagazineWalletsIssued - MagazineStock : 0;
        public bool OwnsWalletsOrEquipment => MemStickPlayer || SentNewsWallets != 0 || SentMagazineWallets != 0;

        public bool CanEdit => Status == ListenerStates.ACTIVE || Status == ListenerStates.PAUSED || Status == ListenerStates.DELETED;
        public bool CanPause => Status == ListenerStates.ACTIVE && !OnlineOnly;
        public bool CanResume => Status == ListenerStates.PAUSED;
        public bool CanDelete => Status != ListenerStates.DELETED;
        public bool CanRestore => Status == ListenerStates.DELETED;
        public bool CanPurge => Status == ListenerStates.DELETED && !OwnsWalletsOrEquipment;
        public bool IsPurged => Forename == "Deleted" && Surname == "Deleted";

        public string GetDebugString()
        {
            return "Wallet: " + this.Wallet + Environment.NewLine + "Name: " + GetNiceName() + Environment.NewLine + "Addr1: " + this.Addr1 + Environment.NewLine + "Addr2: " + this.Addr2 + Environment.NewLine + "Town: " + this.Town + Environment.NewLine + "County: " + this.County + Environment.NewLine + "Postcode: " + this.Postcode + Environment.NewLine + "Birthday: " + this.BirthdayDay + "/" + this.BirthdayMonth + Environment.NewLine + "Info: " + this.Info + Environment.NewLine + "Joined: " + this.Joined + Environment.NewLine + "LastIn: " + this.LastIn + Environment.NewLine + "LastOut: " + this.LastOut + Environment.NewLine + "Stock: " + this.Stock + Environment.NewLine + "DeletedDate: " + this.DeletedDate + Environment.NewLine + "Telephone: " + this.Telephone + Environment.NewLine + "StatusInfo: " + this.StatusInfo + Environment.NewLine + "Status: " + this.Status + Environment.NewLine + "MemStickPlayer: " + this.MemStickPlayer + Environment.NewLine + "Magazine: " + this.Magazine + Environment.NewLine;
        }

        public string GetNiceName()
        {
            var nameParts = new List<string> { Title, Forename, Surname }
                .Where(x => !string.IsNullOrWhiteSpace(x));
            return string.Join(" ", nameParts);
        }

        public static int DaysUntilBirthday(DateTime birthday)
        {
            var nextBirthday = birthday.AddYears(DateTime.Today.Year - birthday.Year);
            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            return (nextBirthday - DateTime.Today).Days;
        }

        public void Scan(ScanTypes scanType, WalletTypes walletType)
        {
            var increment = scanType == ScanTypes.OUT ? -1 : 1;

            switch (walletType)
            {
                case WalletTypes.News:
                    Stock += increment;
                    break;
                case WalletTypes.Magazine:
                    MagazineStock += increment;
                    break;
                default:
                    break;
            }

            if (Status == ListenerStates.DELETED && !OwnsWalletsOrEquipment)
            {
                Purge();
            }
        }

        public DateTime GetStoppedDate()
        {
            if (Status == ListenerStates.PAUSED)
            {
                var stoppedDate = StatusInfo.Substring(0, StatusInfo.IndexOf(","));
                return DateTime.ParseExact(stoppedDate, "dd/MM/yyyy", null);
            }

            return DateTime.Now;
        }

        public void Pause(DateTime startDate, DateTime? endDate = null)
        {
            if (Status == ListenerStates.DELETED)
            {
                throw new ListenerStateChangeException($"Cannot pause listener {Wallet} as it's state is {Status}");
            }

            Status = ListenerStates.PAUSED;

            var myDateStr = endDate == null ? NEVER_END_PAUSE_STRING : endDate.Value.ToNiceStr();
            StatusInfo = startDate.ToNiceStr() + "," + myDateStr;
        }

        public void Resume()
        {
            if (!CanResume)
            {
                throw new ListenerStateChangeException($"Cannot resume listener {Wallet} as it's state is {Status}");
            }

            Status = ListenerStates.ACTIVE;
            StatusInfo = "";
        }

        public DateTime? GetResumeDate()
        {
            if (Status == ListenerStates.PAUSED)
            {
                string resumeDate = StatusInfo.Substring(StatusInfo.IndexOf(",") + 1);
                if (resumeDate != NEVER_END_PAUSE_STRING)
                {
                    return DateTime.ParseExact(resumeDate, "dd/MM/yyyy", null);
                }
            }

            return null;
        }

        public string GetResumeDateString()
        {
            var result = GetResumeDate();
            return result.HasValue ? result.Value.ToNiceStr() : NEVER_END_PAUSE_STRING;
        }

        public bool HasPausePeriodElapsed
        {
            get
            {
                var resumeDate = GetResumeDate();
                return resumeDate.HasValue && resumeDate.Value < DateTime.Now;
            }
        }

        public void Delete(string reason)
        {
            if (!CanDelete)
            {
                throw new ListenerStateChangeException($"Cannot delete listener {Wallet} as it's state is {Status}");
            }

            Status = ListenerStates.DELETED;
            DeletedDate = DateTime.UtcNow;
            StatusInfo = reason;

            if (!OwnsWalletsOrEquipment)
            {
                Purge();
            }
        }

        public void Purge()
        {
            if (!CanPurge)
            {
                throw new ListenerStateChangeException($"Cannot purge listener {Wallet} as it's state is {Status}");
            }

            Title = "N/A";
            Forename = "Deleted";
            Surname = "Deleted";
            Addr1 = null;
            Addr2 = null;
            Town = null;
            County = null;
            Postcode = null;
            Telephone = null;
            BirthdayDay = null;
            BirthdayMonth = null;
            Info = null;
            StatusInfo = null;
        }

        public string FormatListenerData()
        {
            var builder = new StringBuilder();
            builder.Append(GetNiceName());

            if (Addr1 != null)
            {
                builder.AppendLine();
                builder.Append(FormatAddress());
            }

            return builder.ToString();
        }

        private string FormatAddress()
        {
            var builder = new StringBuilder();
            if (Addr1 != null)
            {
                var address = Addr1;
                if (Addr2 != null)
                {
                    address += ", " + Addr2;
                }
                builder.AppendLine(address);

                if (Town != null)
                {
                    var addressScondLine = Town;
                    if (County != null)
                    {
                        addressScondLine += ", " + County;
                    }
                    builder.AppendLine(addressScondLine);
                }

                if (Postcode != null)
                {
                    builder.AppendLine(Postcode);
                }
            }
            return builder.ToString();
        }

        public void Restore()
        {
            if (!CanRestore)
            {
                throw new ListenerStateChangeException($"Cannot restore listener {Wallet} as it's state is {Status}");
            }

            Status = ListenerStates.ACTIVE;
            StatusInfo = "";
            DeletedDate = null;
        }
    }
}
