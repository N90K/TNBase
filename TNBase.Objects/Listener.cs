using System;
using System.Xml.Serialization;

namespace TNBase.Objects
{
    /// <summary>
    /// Represents a Listener
    /// </summary>
    public class Listener
    {
        /// <summary>
        /// String used to indicate a never ending time
        /// </summary>
        public const string NEVER_END_PAUSE_STRING = "UFN";
        /// <summary>
        /// How much stock does a new listener get
        /// </summary>
        public const int DEFAULT_STOCK = 3;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Listener() 
        {
            Joined = DateTime.Now;
            Stock = DEFAULT_STOCK;
            inOutRecords = new InOutRecords();
        }
        
        /// <summary>
        /// The wallet number for the Listener
        /// </summary>
        public int Wallet;

        /// <summary>
        /// Title for the Listener e.g. Mr
        /// </summary>
        public string Title;
        /// <summary>
        /// Listener Forename
        /// </summary>
        public string Forename;
        /// <summary>
        /// Listener Surname
        /// </summary>
        public string Surname;

        /// <summary>
        /// Address Line 1
        /// </summary>
        public string Addr1;
        /// <summary>
        /// Address Line 2
        /// </summary>
        public string Addr2;
        /// <summary>
        /// Town
        /// </summary>
        public string Town;
        /// <summary>
        /// County
        /// </summary>
        public string County;
        /// <summary>
        /// Postcode
        /// </summary>
        public string Postcode;
        /// <summary>
        /// Telephone Number
        /// </summary>
        public string Telephone;

        /// <summary>
        /// Does the Listener have a memory stick on loan?
        /// </summary>
        public bool MemStickPlayer;
        /// <summary>
        /// Does the listener use magazines?
        /// TODO (L) Remove Magazine field if not used
        /// </summary>
        public bool Magazine;

        /// <summary>
        /// The Listeners Birthday
        /// </summary>
        public DateTime? Birthday;

        /// <summary>
        /// The Date in which the Listener joined
        /// </summary>
        [XmlIgnore]
        public DateTime Joined;

        /// <summary>
        /// Freetext info field
        /// </summary>
        public string Info;

        /// <summary>
        /// The Listeners Status
        /// </summary>
        public ListenerStates Status;
        /// <summary>
        /// Some more status info used internally
        /// </summary>
        public string StatusInfo;

        /// <summary>
        /// In / Out numbers
        /// </summary>
        public InOutRecords inOutRecords;

        /// <summary>
        /// The deleted date for the listener (if they are deleted)
        /// </summary>
        public DateTime? DeletedDate;

        /// <summary>
        /// The Listener Stock Level
        /// </summary>
        public int Stock;
        /// <summary>
        /// The date a wallet last came in for the Listener
        /// </summary>
        public DateTime? LastIn;
        /// <summary>
        /// The date a wallet last went out for the Listener
        /// </summary>
        public DateTime? LastOut;

        /// <summary>
        /// Get the debug string for the listener
        /// </summary>
        /// <returns></returns>
        public string GetDebugString()
        {
            return "Wallet: " + this.Wallet + Environment.NewLine + "Name: " + GetNiceName() + Environment.NewLine + "Addr1: " + this.Addr1 + Environment.NewLine + "Addr2: " + this.Addr2 + Environment.NewLine + "Town: " + this.Town + Environment.NewLine + "County: " + this.County + Environment.NewLine + "Postcode: " + this.Postcode + Environment.NewLine + "Birthday: " + this.Birthday + Environment.NewLine + "Info: " + this.Info + Environment.NewLine + "Joined: " + this.Joined + Environment.NewLine + "LastIn: " + this.LastIn + Environment.NewLine + "LastOut: " + this.LastOut + Environment.NewLine + "Stock: " + this.Stock + Environment.NewLine + "DeletedDate: " + this.DeletedDate + Environment.NewLine + "Telephone: " + this.Telephone + Environment.NewLine + "StatusInfo: " + this.StatusInfo + Environment.NewLine + "Status: " + this.Status + Environment.NewLine + "MemStickPlayer: " + this.MemStickPlayer + Environment.NewLine + "Magazine: " + this.Magazine + Environment.NewLine;
        }

        /// <summary>
        /// Get the nice name for a listener
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get the days until a birthday
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int DaysUntilBirthday(DateTime birthday)
        {
            var nextBirthday = birthday.AddYears(DateTime.Today.Year - birthday.Year);
            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            return (nextBirthday - DateTime.Today).Days;
        }

        /// <summary>
        /// Get the stop date for a listener
        /// </summary>
        /// <param name="theListener"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Pause the listener
        /// </summary>
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

        /// <summary>
        /// Resume a paused listener.
        /// </summary>
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

        /// <summary>
        /// Get the resume date for a listener
        /// </summary>
        /// <param name="theListener"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get the stop date string.
        /// </summary>
        /// <param name="theListener">The listener</param>
        /// <returns>the string</returns>
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

        /// <summary>
        /// Get the listeners birthday day this year
        /// </summary>
        /// <returns>The birthday date this year</returns>
        public DateTime BirthdayThisYear()
        {
            DateTime copy = Birthday.Value;
            copy = copy.AddYears(DateTime.Now.Year - Birthday.Value.Year);
            return copy;
        }

        /// <summary>
        /// Get listener data string
        /// </summary>
        /// <param name="theListener"></param>
        /// <returns></returns>
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
