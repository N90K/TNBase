using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Xml.Serialization;
using TNBase.Infrastructure.Extensions;

namespace TNBase.Objects
{
    [Table("Listeners")]
    public class Listener
    {
        public const string NEVER_END_PAUSE_STRING = "UFN";
        public const int DEFAULT_STOCK = 3;

        public Listener()
        {
            Joined = DateTime.Now;
            Stock = DEFAULT_STOCK;
            Status = ListenerStates.ACTIVE;
        }

        [Key]
        public int Wallet { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public bool MemStickPlayer { get; set; }
        public bool Magazine { get; set; }
        public int? BirthdayDay { get; set; }
        public int? BirthdayMonth { get; set; }


        [NotMapped]
        public bool HasBirthday => BirthdayDay.HasValue && BirthdayMonth.HasValue;

        [NotMapped]
        public string BirthdayText => HasBirthday ? $"{BirthdayDay.Value.WithSuffix()} {DateTimeFormatInfo.CurrentInfo.GetMonthName(BirthdayMonth.Value)}" : "N/A";

        [NotMapped]
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
                
                if(!DateTime.IsLeapYear(year) && BirthdayDay == 29 && BirthdayMonth == 2)
                {
                    return new DateTime(year, 3, 1); // move birthday forward by a day if not leap year
                }

                return new DateTime(year, BirthdayMonth.Value, BirthdayDay.Value);
            }
        }

        [XmlIgnore]
        public DateTime Joined { get; set; }
        public string Info { get; set; }
        [Column("Status")]
        public string State { get; set; }
        [NotMapped]
        public ListenerStates Status
        {
            get
            {
                Enum.TryParse<ListenerStates>(State, out var status);
                return status;
            }
            set
            {
                State = value.ToString();
            }
        }
        public string StatusInfo { get; set; }
        [Required]
        public virtual InOutRecords inOutRecords { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int Stock { get; set; }
        public DateTime? LastIn { get; set; }
        public DateTime? LastOut { get; set; }
        public int MagazineStock { get; set; }

        public string GetDebugString()
        {
            return "Wallet: " + this.Wallet + Environment.NewLine + "Name: " + GetNiceName() + Environment.NewLine + "Addr1: " + this.Addr1 + Environment.NewLine + "Addr2: " + this.Addr2 + Environment.NewLine + "Town: " + this.Town + Environment.NewLine + "County: " + this.County + Environment.NewLine + "Postcode: " + this.Postcode + Environment.NewLine + "Birthday: " + this.BirthdayDay + "/" + this.BirthdayMonth + Environment.NewLine + "Info: " + this.Info + Environment.NewLine + "Joined: " + this.Joined + Environment.NewLine + "LastIn: " + this.LastIn + Environment.NewLine + "LastOut: " + this.LastOut + Environment.NewLine + "Stock: " + this.Stock + Environment.NewLine + "DeletedDate: " + this.DeletedDate + Environment.NewLine + "Telephone: " + this.Telephone + Environment.NewLine + "StatusInfo: " + this.StatusInfo + Environment.NewLine + "Status: " + this.Status + Environment.NewLine + "MemStickPlayer: " + this.MemStickPlayer + Environment.NewLine + "Magazine: " + this.Magazine + Environment.NewLine;
        }

        public string GetNiceName()
        {
            string start = "";

            // Remove spaces.
            start = start.Replace(" ", "");

            // Do they have a title?
            if (!string.IsNullOrEmpty(this.Title))
            {
                start = this.Title;

                // Add a dot if its not there.
                if (!start.EndsWith("."))
                {
                    start += ".";
                }
                start += " ";
            }

            // Return the result.
            return start + this.Forename + " " + this.Surname;
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

        public static DateTime GetStoppedDate(Listener theListener)
        {
            DateTime adate = DateTime.Now;

            if (theListener.Status == ListenerStates.PAUSED)
            {
                string firstStr = theListener.StatusInfo.Substring(0, theListener.StatusInfo.IndexOf(","));
                adate = DateTime.Parse(firstStr);
            }

            return adate;
        }

        public void Pause(DateTime startDate, DateTime? endDate = null)
        {
            // We can only pause the listener if they are not deleted!
            if (Status == ListenerStates.DELETED)
            {
                throw new ListenerStateChangeException();
            }
            Status = ListenerStates.PAUSED;

            string myDateStr = "";
            if (endDate == null)
            {
                myDateStr = Listener.NEVER_END_PAUSE_STRING;
            }
            else
            {
                myDateStr = endDate.Value.ToNiceStr();
            }

            StatusInfo = startDate.ToNiceStr() + "," + myDateStr;
        }

        public void Resume()
        {
            // We can only resume the listener if they are paused!
            if (Status != ListenerStates.PAUSED)
            {
                throw new ListenerStateChangeException();
            }

            Status = ListenerStates.ACTIVE;
            StatusInfo = "";
        }

        public static DateTime? GetResumeDate(Listener theListener)
        {
            DateTime? adate = null;

            if (theListener.Status == ListenerStates.PAUSED)
            {
                string secondStr = theListener.StatusInfo.Substring(theListener.StatusInfo.IndexOf(",") + 1);
                if ((secondStr != NEVER_END_PAUSE_STRING))
                {
                    // Try and read the end date.
                    adate = DateTime.Parse(secondStr);
                }

            }

            return adate;
        }

        public static string GetResumeDateString(Listener theListener)
        {
            DateTime? result = GetResumeDate(theListener);

            if (!result.HasValue)
            {
                return NEVER_END_PAUSE_STRING;
            }
            else
            {
                return result.Value.ToNiceStr();
            }
        }

        //public DateTime BirthdayThisYear()
        //{
        //    DateTime copy = Birthday.Value;
        //    copy = copy.AddYears(DateTime.Now.Year - Birthday.Value.Year);
        //    return copy;
        //}

        public static string FormatListenerData(Listener theListener)
        {
            string resultStr = null;

            // Create a data string adding content only if it exists.
            resultStr = theListener.Title + " " + theListener.Forename + " " + theListener.Surname + Environment.NewLine;
            if (!(theListener.Addr1 == null))
            {
                resultStr += theListener.Addr1;
                if (!(theListener.Addr2 == null))
                {
                    resultStr += ", " + theListener.Addr2;
                }
                resultStr += Environment.NewLine;

                if (!(theListener.Town == null))
                {
                    resultStr += theListener.Town;
                    if (!(theListener.County == null))
                    {
                        resultStr += ", " + theListener.County;
                    }
                    resultStr += Environment.NewLine;
                }

                if (!(theListener.Postcode == null))
                {
                    resultStr += theListener.Postcode + Environment.NewLine;
                }
            }

            // Return the result.
            return resultStr;
        }
    }
}
