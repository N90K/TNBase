using TNBase.Objects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TNBase.DataStorage
{
    public class RepositoryLayer : IRepositoryLayer
    {
        // Logging instance
        static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the weekly stats from a database object
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        public static WeeklyStats WeeklyStatsFromObject(SQLiteDataReader myReader)
        {
            WeeklyStats tempStats = new WeeklyStats();

            tempStats.ScannedIn = (int)(long)myReader["ScannedIn"];
            tempStats.ScannedOut = (int)(long)myReader["ScannedOut"];
            tempStats.PausedCount = (int)(long)myReader["PausedCount"];
            tempStats.TotalListeners = (int)(long)myReader["TotalListeners"];
            tempStats.WeekNumber = (int)(long)myReader["WeekNumber"];
            tempStats.WeekDate = (DateTime)myReader["Date"];

            return tempStats;
        }

        /// <summary>
        /// Get the year stats from a database object
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        private static YearStats YearlyStatsFromObject(SQLiteDataReader myReader)
        {
            YearStats tempStats = new YearStats();

            tempStats.Year = (int)(long)myReader["Year"];
            tempStats.StartListeners = (int)(long)myReader["StartListeners"];
            tempStats.EndListeners = (int)(long)myReader["EndListeners"];
            tempStats.NewListeners = (int)(long)myReader["NewListeners"];
            tempStats.DeletedListeners = (int)(long)myReader["DeletedListeners"];
            tempStats.AvListeners = (int)(long)myReader["AverageListeners"];
            tempStats.InactiveTotal = (int)(long)myReader["InactiveTotal"];
            tempStats.MagazineTotal = (int)(long)myReader["MagazineTotal"];
            tempStats.AverageSent = (int)(long)myReader["AverageSent"];
            tempStats.SentTotal = (int)(long)myReader["SentTotal"];
            tempStats.MagazinesSent = (int)(long)myReader["MagazinesSent"];
            tempStats.PercentSent = (int)(long)myReader["PercentSent"];
            tempStats.MemStickPlayerLoanTotal = (int)(long)myReader["MemStickPlayerLoanTotal"];
            tempStats.PausedTotal = (int)(long)myReader["PausedTotal"];
            tempStats.AveragePaused = (int)(long)myReader["AveragePaused"];
            tempStats.DeletedTotal = (int)(long)myReader["DeletedTotal"];

            return tempStats;
        }

        /// <summary>
        /// Create a collector for a database object
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        private static Collector CollectorFromObjReader(SQLiteDataReader myReader)
        {
            Collector tempCollector = new Collector();
            tempCollector.ID = (int)(long)myReader["Key"];
            tempCollector.Forename = (string)myReader["Forename"];
            tempCollector.Surname = (string)myReader["Surname"];
            tempCollector.Number = (string)myReader["Telephone"];
            tempCollector.Postcodes = (string)myReader["Postcodes"];

            return tempCollector;
        }

        /// <summary>
        /// Create a scan for a database object
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        public static Scan ScanFromObjReader(SQLiteDataReader myReader)
        {
            Scan tempScan = new Scan();
            tempScan.Wallet = (int)((long)myReader["Wallet"]);
            tempScan.Recorded = (DateTime)myReader["Recorded"];

            Enum.TryParse(myReader["Type"].ToString(), true, out ScanTypes scanType);
            tempScan.ScanType = scanType;

            Enum.TryParse(myReader["WalletType"].ToString(), true, out WalletTypes walletType);
            tempScan.WalletType = walletType;

            return tempScan;
        }

        /// <summary>
        /// Create a listener for a database object
        /// </summary>
        /// <param name="myReader"></param>
        /// <returns></returns>
        private static Listener ListenerFromObjReader(SQLiteDataReader myReader)
        {
            Listener tempListener = new Listener();
            tempListener.Wallet = (int)((long)myReader["Wallet"]);
            tempListener.Title = (string)myReader["Title"];
            tempListener.Forename = (string)myReader["Forename"];
            tempListener.Surname = (string)myReader["Surname"];
            if (!(myReader["Addr1"] is DBNull))
            {
                tempListener.Addr1 = (string)myReader["Addr1"];
            }
            if (!(myReader["Addr2"] is DBNull))
            {
                tempListener.Addr2 = (string)myReader["Addr2"];
            }
            if (!(myReader["Town"] is DBNull))
            {
                tempListener.Town = (string)myReader["Town"];
            }
            if (!(myReader["County"] is DBNull))
            {
                tempListener.County = (string)myReader["County"];
            }
            if (!(myReader["Postcode"] is DBNull))
            {
                tempListener.Postcode = (string)myReader["Postcode"];
            }
            if (!(myReader["Birthday"] is DBNull))
            {
                tempListener.Birthday = (DateTime)myReader["Birthday"];
            }
            if (!(myReader["Joined"] is DBNull))
            {
                tempListener.Joined = (DateTime)myReader["Joined"];
            }
            tempListener.Telephone = (string)myReader["Telephone"];
            tempListener.MemStickPlayer = (bool)myReader["MemStickPlayer"];
            tempListener.Magazine = (bool)myReader["Magazine"];
            tempListener.Info = (string)myReader["Info"];
            tempListener.Status = (ListenerStates)Enum.Parse(typeof(ListenerStates), (string)myReader["Status"], true);
            if (!(myReader["StatusInfo"] is DBNull))
            {
                tempListener.StatusInfo = (string)myReader["StatusInfo"];
            }

            tempListener.inOutRecords = new InOutRecords();
            tempListener.inOutRecords.In1 = (int)(long)myReader["In1"];
            tempListener.inOutRecords.In2 = (int)(long)myReader["In2"];
            tempListener.inOutRecords.In3 = (int)(long)myReader["In3"];
            tempListener.inOutRecords.In4 = (int)(long)myReader["In4"];
            tempListener.inOutRecords.In5 = (int)(long)myReader["In5"];
            tempListener.inOutRecords.In6 = (int)(long)myReader["In6"];
            tempListener.inOutRecords.In7 = (int)(long)myReader["In7"];
            tempListener.inOutRecords.In8 = (int)(long)myReader["In8"];
            tempListener.inOutRecords.Out1 = (int)(long)myReader["Out1"];
            tempListener.inOutRecords.Out2 = (int)(long)myReader["Out2"];
            tempListener.inOutRecords.Out3 = (int)(long)myReader["Out3"];
            tempListener.inOutRecords.Out4 = (int)(long)myReader["Out4"];
            tempListener.inOutRecords.Out5 = (int)(long)myReader["Out5"];
            tempListener.inOutRecords.Out6 = (int)(long)myReader["Out6"];
            tempListener.inOutRecords.Out7 = (int)(long)myReader["Out7"];
            tempListener.inOutRecords.Out8 = (int)(long)myReader["Out8"];

            if (!(myReader["DeletedDate"] is DBNull))
            {
                tempListener.DeletedDate = (DateTime)myReader["DeletedDate"];
            }
            tempListener.Stock = (int)(long)myReader["Stock"];
            tempListener.MagazineStock = (int)(long)myReader["MagazineStock"];
            if (!(myReader["LastIn"] is DBNull))
            {
                tempListener.LastIn = (DateTime)myReader["LastIn"];
            }
            if (!(myReader["LastOut"] is DBNull))
            {
                tempListener.LastOut = (DateTime)myReader["LastOut"];
            }

            return tempListener;
        }

        /// <summary>
        /// Do no result query
        /// </summary>
        /// <param name="theQuery"></param>
        /// <returns></returns>
        public static bool DoNoResultQuery(SQLiteConnection objConn, string theQuery)
        {
            SQLiteCommand objCommand = null;
            SQLiteDataReader objReader = null;

            try
            {
                //Create a new SQL command to read all records from the customer table
                objCommand = objConn.CreateCommand();
                objCommand.CommandText = theQuery;
                log.Debug("QUERY: " + objCommand.CommandText);

                //Execute the command returning a reader object
                objReader = objCommand.ExecuteReader();

                return true;
            }
            finally
            {
                //Cleanup and close the connection
                if ((objReader != null))
                {
                    objReader.Close();
                }
                if ((objCommand != null))
                {
                    objCommand.Dispose();
                }
            }
        }

        /// <summary>
        /// Get all listeners
        /// </summary>
        /// <param name="objConn"></param>
        /// <returns></returns>
        public List<Listener> GetListeners(SQLiteConnection objConn)
        {
            List<Listener> theListeners = new List<Listener>();
            SQLiteCommand objCommand = null;
            SQLiteDataReader objReader = null;

            try
            {
                //Create a new SQL command to read all records from the customer table
                objCommand = objConn.CreateCommand();
                objCommand.CommandText = "SELECT * FROM Listeners";
                log.Debug("QUERY: " + objCommand.CommandText);

                //Execute the command returning a reader object
                objReader = objCommand.ExecuteReader();

                //Iterate through the rows in the reader, if we have one, we have a match!
                while ((objReader.Read()))
                {
                    Listener tempListener = ListenerFromObjReader(objReader);
                    theListeners.Add(tempListener);
                }

                objReader.Close();
            }
            finally
            {
                //Cleanup and close the connection
                if ((objReader != null))
                {
                    objReader.Close();
                }
                if ((objCommand != null))
                {
                    objCommand.Dispose();
                }
            }

            // Return the listeners.
            return theListeners;
        }

        /// <summary>
        /// Update some listener
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="listener"></param>
        public void UpdateListener(SQLiteConnection objConn, Listener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            // Convert booleans to mysql storage.
            int magazineInt = listener.Magazine ? 1 : 0;
            int memStickInt = listener.MemStickPlayer ? 1 : 0;

            string birthdayStr = listener.Birthday.ToSQLiteInsertStr();
            string deletedStr = listener.DeletedDate.ToSQLiteInsertStr();
            string lastInStr = listener.LastIn.ToSQLiteInsertStr();
            string lastOutStr = listener.LastOut.ToSQLiteInsertStr();

            string inString = ", In1 = " + listener.inOutRecords.In1 + ", In2 = " + listener.inOutRecords.In2 + ", In3 = " + listener.inOutRecords.In3 + ", In4 = " + listener.inOutRecords.In4 + ", In5 = " + listener.inOutRecords.In5 + ", In6 = " + listener.inOutRecords.In6 + ", In7= " + listener.inOutRecords.In7 + ", In8 = " + listener.inOutRecords.In8;
            string outString = ", Out1 = " + listener.inOutRecords.Out1 + ", Out2 = " + listener.inOutRecords.Out2 + ", Out3 = " + listener.inOutRecords.Out3 + ", Out4 = " + listener.inOutRecords.Out4 + ", Out5 = " + listener.inOutRecords.Out5 + ", Out6 = " + listener.inOutRecords.Out6 + ", Out7 = " + listener.inOutRecords.Out7 + ", Out8 = " + listener.inOutRecords.Out8;

            // Now run the query with the strings we have created.
            DoNoResultQuery(objConn, "UPDATE Listeners SET Title = '" + listener.Title + "', Forename = '" + listener.Forename + "', Surname = '" + listener.Surname + "', Addr1 = '" + listener.Addr1 + "', Addr2 = '" + listener.Addr2 + "', Town = '" + listener.Town + "', County = '" + listener.County + "', Postcode = '" + listener.Postcode + "', Birthday = " + birthdayStr + ", MemStickPlayer = " + memStickInt + ", Magazine = " + magazineInt + ", Telephone = '" + listener.Telephone + "', Info = '" + listener.Info + "', Status ='" + listener.Status + "', StatusInfo = '" + listener.StatusInfo + "'" + inString + outString + ", DeletedDate = " + deletedStr + ", Stock = " + listener.Stock + ", MagazineStock = " + listener.MagazineStock + ", LastIn = " + lastInStr + ", LastOut = " + lastOutStr + " WHERE Wallet = " + listener.Wallet);
        }

        /// <summary>
        /// Insert a listener
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="listener"></param>
        public int InsertListener(SQLiteConnection objConn, Listener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            // Convert variables to mysql storage.
            int magazineInt = listener.Magazine ? 1 : 0;
            int memStickInt = listener.MemStickPlayer ? 1 : 0;
            string birthdayStr = listener.Birthday.ToSQLiteInsertStr();
            string joinedStr = listener.Joined.ToSQLiteInsertStr();
            string deletedStr = listener.DeletedDate.ToSQLiteInsertStr();
            string lastInStr = listener.LastIn.ToSQLiteInsertStr();
            string lastOutStr = listener.LastOut.ToSQLiteInsertStr();

            int result = 0;
            string WalletStrValue = "";
            if (listener.Wallet == 0)
            {
                // If we see 0, we are finding the next available slot.
                result = CalculateNextFreeWallet(objConn);
                WalletStrValue = "" + result + ", ";
            }
            else
            {
                // It might already be set if we are doing an import!
                result = listener.Wallet;
                WalletStrValue = "" + result + ", ";
            }

            // Add in/out records if they are available.
            string inoutFields = "";
            string inoutValues = "";
            if (listener.inOutRecords != null)
            {
                inoutFields = ", In1, In2, In3, In4, In5, In6, In7, In8, Out1, Out2, Out3, Out4, Out5, Out6, Out7, Out8";
                inoutValues = ", " + listener.inOutRecords.In1 + ", " + listener.inOutRecords.In2 + ", " + listener.inOutRecords.In3 + ", " + listener.inOutRecords.In4 + ", " + listener.inOutRecords.In5 + ", " + listener.inOutRecords.In6 + ", " + listener.inOutRecords.In7 + ", " + listener.inOutRecords.In8;
                inoutValues = inoutValues + ", " + listener.inOutRecords.Out1 + ", " + listener.inOutRecords.Out2 + ", " + listener.inOutRecords.Out3 + ", " + listener.inOutRecords.Out4 + ", " + listener.inOutRecords.Out5 + ", " + listener.inOutRecords.Out6 + ", " + listener.inOutRecords.Out7 + ", " + listener.inOutRecords.Out8;
            }

            string sql = "INSERT INTO Listeners (Wallet, Title, Forename, Surname, Addr1, Addr2, Town, County, Postcode, Birthday, MemStickPlayer, Magazine, Telephone, Info, Status, StatusInfo, DeletedDate" + inoutFields + ", Joined, LastIn, LastOut, Stock) VALUES  (" + WalletStrValue + "'" + listener.Title + "', '" + listener.Forename + "', '" + listener.Surname + "', '" + listener.Addr1 + "', '" + listener.Addr2 + "', '" + listener.Town + "', '" + listener.County + "', '" + listener.Postcode + "', " + birthdayStr + ", " + memStickInt + ", " + magazineInt + ", '" + listener.Telephone + "', '" + listener.Info + "', '" + listener.Status + "', '" + listener.StatusInfo + "', " + deletedStr + inoutValues + ", " + joinedStr + ", " + lastInStr + ", " + lastOutStr + ", " + listener.Stock + ");";
            DoNoResultQuery(objConn, sql);

            return result;
        }

        /// <summary>
        /// Delete a listener
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="listener"></param>
        public void DeleteListener(SQLiteConnection objConn, Listener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            DoNoResultQuery(objConn, "DELETE FROM Listeners WHERE Wallet = " + listener.Wallet);
            DeleteScans(objConn, listener.Wallet);
        }

        /// <summary>
        /// Get all collectors
        /// </summary>
        /// <param name="objConn"></param>
        /// <returns></returns>
        public List<Collector> GetCollectors(SQLiteConnection objConn)
        {
            List<Collector> theCollectors = new List<Collector>();
            SQLiteCommand objCommand = null;
            SQLiteDataReader objReader = null;

            try
            {
                //Create a new SQL command to read all records from the customer table
                objCommand = objConn.CreateCommand();
                objCommand.CommandText = "SELECT * FROM Collectors";
                log.Debug("QUERY: " + objCommand.CommandText);

                //Execute the command returning a reader object
                objReader = objCommand.ExecuteReader();

                //Iterate through the rows in the reader, if we have one, we have a match!
                while ((objReader.Read()))
                {
                    Collector tempCollector = CollectorFromObjReader(objReader);
                    theCollectors.Add(tempCollector);
                }

                objReader.Close();
            }
            finally
            {
                //Cleanup and close the connection
                if ((objReader != null))
                {
                    objReader.Close();
                }
                if ((objCommand != null))
                {
                    objCommand.Dispose();
                }
            }

            // Return the collectors.
            return theCollectors;
        }

        /// <summary>
        /// Update some collector
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="collector"></param>
        public void UpdateCollector(SQLiteConnection objConn, Collector collector)
        {
            if (collector == null)
            {
                throw new ArgumentNullException("collector");
            }

            string sql = "UPDATE Collectors SET Forename = '" + collector.Forename + "', Surname = '" + collector.Surname + "', Telephone = '" + collector.Number + "', Postcodes = '" + collector.Postcodes + "' WHERE Key = " + collector.ID;
            DoNoResultQuery(objConn, sql);
        }

        /// <summary>
        /// Insert a collector
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="collector"></param>
        public void InsertCollector(SQLiteConnection objConn, Collector collector)
        {
            if (collector == null)
            {
                throw new ArgumentNullException("collector");
            }

            DoNoResultQuery(objConn, "INSERT INTO Collectors (Forename, Surname, Telephone, Postcodes) VALUES  ('" + collector.Forename + "', '" + collector.Surname + "', '" + collector.Number + "', '" + collector.Postcodes + "');");
        }

        /// <summary>
        /// Delete a collector
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="collector"></param>
        public void DeleteCollector(SQLiteConnection objConn, Collector collector)
        {
            if (collector == null)
            {
                throw new ArgumentNullException("collector");
            }

            DoNoResultQuery(objConn, "DELETE FROM Collectors WHERE Key = " + collector.ID);
        }

        /// <summary>
        /// Get all weekly stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <returns></returns>
        public List<WeeklyStats> GetWeeklyStats(SQLiteConnection objConn)
        {
            List<WeeklyStats> theWeeklyStats = new List<WeeklyStats>();
            SQLiteCommand objCommand = null;
            SQLiteDataReader objReader = null;

            try
            {
                //Create a new SQL command to read all records from the customer table
                objCommand = objConn.CreateCommand();
                objCommand.CommandText = "SELECT * FROM WeekStats";
                log.Debug("QUERY: " + objCommand.CommandText);

                //Execute the command returning a reader object
                objReader = objCommand.ExecuteReader();

                //Iterate through the rows in the reader, if we have one, we have a match!
                while ((objReader.Read()))
                {
                    WeeklyStats tempStats = WeeklyStatsFromObject(objReader);
                    theWeeklyStats.Add(tempStats);
                }

                objReader.Close();
            }
            finally
            {
                //Cleanup and close the connection
                if ((objReader != null))
                {
                    objReader.Close();
                }
                if ((objCommand != null))
                {
                    objCommand.Dispose();
                }
            }

            // Return the weekly stats.
            return theWeeklyStats;
        }

        /// <summary>
        /// Update some week stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="weeklyStats"></param>
        public void UpdateWeeklyStats(SQLiteConnection objConn, WeeklyStats weeklyStats)
        {
            if (weeklyStats == null)
            {
                throw new ArgumentNullException("weeklyStats");
            }

            // Note: previosly this used the following style; 'ScannedIn = ScannedIn + .'
            DoNoResultQuery(objConn, "UPDATE WeekStats SET ScannedIn = " + weeklyStats.ScannedIn + ", ScannedOut = " + weeklyStats.ScannedOut + ", PausedCount = " + weeklyStats.PausedCount + ", TotalListeners = " + weeklyStats.TotalListeners + " WHERE WeekNumber = " + weeklyStats.WeekNumber + ";");
        }

        /// <summary>
        /// Insert the weekly stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="weeklyStats"></param>
        public void InsertWeeklyStats(SQLiteConnection objConn, WeeklyStats weeklyStats)
        {
            if (weeklyStats == null)
            {
                throw new ArgumentNullException("weeklyStats");
            }

            string dateString = weeklyStats.WeekDate.ToSQLiteStr();

            DoNoResultQuery(objConn, "INSERT INTO WeekStats (WeekNumber, ScannedIn, ScannedOut, PausedCount, TotalListeners, Date) VALUES  (" + weeklyStats.WeekNumber + ", " + weeklyStats.ScannedIn + ", " + weeklyStats.ScannedOut + ", " + weeklyStats.PausedCount + ", " + weeklyStats.TotalListeners + ", date('" + dateString + "'));");
        }

        /// <summary>
        /// Delete from weekly stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="weeklyStats"></param>
        public void DeleteWeeklyStats(SQLiteConnection objConn, WeeklyStats weeklyStats)
        {
            if (weeklyStats == null)
            {
                throw new ArgumentNullException("weeklyStats");
            }

            DoNoResultQuery(objConn, "DELETE FROM WeekStats WHERE WeekNumber = " + weeklyStats.WeekNumber);
        }

        /// <summary>
        /// Get all year stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <returns></returns>
        public List<YearStats> GetYearStats(SQLiteConnection objConn)
        {
            List<YearStats> theYearStats = new List<YearStats>();
            SQLiteCommand objCommand = null;
            SQLiteDataReader objReader = null;

            try
            {
                //Create a new SQL command to read all records from the customer table
                objCommand = objConn.CreateCommand();
                objCommand.CommandText = "SELECT * FROM YearStats";
                log.Debug("QUERY: " + objCommand.CommandText);

                //Execute the command returning a reader object
                objReader = objCommand.ExecuteReader();

                //Iterate through the rows in the reader, if we have one, we have a match!
                while ((objReader.Read()))
                {
                    YearStats tempStats = YearlyStatsFromObject(objReader);
                    theYearStats.Add(tempStats);
                }

                objReader.Close();
            }
            finally
            {
                //Cleanup and close the connection
                if ((objReader != null))
                {
                    objReader.Close();
                }
                if ((objCommand != null))
                {
                    objCommand.Dispose();
                }
            }

            // Return the year stats.
            return theYearStats;
        }

        /// <summary>
        /// Update some year stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="yearStats"></param>
        public void UpdateYearStats(SQLiteConnection objConn, YearStats yearStats)
        {
            if (yearStats == null)
            {
                throw new ArgumentNullException("yearStats");
            }

            string sql = "UPDATE YearStats SET StartListeners = " + yearStats.StartListeners + ", EndListeners = " + yearStats.EndListeners + ", NewListeners = " + yearStats.NewListeners + ", DeletedListeners = " + yearStats.DeletedListeners + ", AverageListeners = " + yearStats.AvListeners + ", InactiveTotal = " + yearStats.InactiveTotal + ", MagazineTotal = " + yearStats.MagazineTotal + ", AverageSent = " + yearStats.AverageSent + ", SentTotal = " + yearStats.SentTotal + ", MagazinesSent = " + yearStats.MagazinesSent + ", PercentSent = " + yearStats.PercentSent + ", MemStickPlayerLoanTotal = " + yearStats.MemStickPlayerLoanTotal + ", PausedTotal = " + yearStats.PausedTotal + ", AveragePaused = " + yearStats.AveragePaused + ", DeletedTotal = " + yearStats.DeletedTotal + " WHERE Year = " + yearStats.Year;
            DoNoResultQuery(objConn, sql);
        }

        /// <summary>
        /// Insert into the year stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="yearStats"></param>
        public void InsertYearStats(SQLiteConnection objConn, YearStats yearStats)
        {
            if (yearStats == null)
            {
                throw new ArgumentNullException("yearStats");
            }

            DoNoResultQuery(objConn, "INSERT INTO YearStats (Year, StartListeners, EndListeners, NewListeners, DeletedListeners, AverageListeners, InactiveTotal, MagazineTotal, AverageSent, SentTotal, MagazinesSent, PercentSent, MemStickPlayerLoanTotal, PausedTotal, AveragePaused, DeletedTotal) VALUES  (" + yearStats.Year + ", " + yearStats.StartListeners + ", " + yearStats.EndListeners + ", " + yearStats.NewListeners + ", " + yearStats.DeletedListeners + ", " + yearStats.AvListeners + ", " + yearStats.InactiveTotal + ", " + yearStats.MagazineTotal + ", " + yearStats.AverageSent + ", " + yearStats.SentTotal + ", " + yearStats.MagazinesSent + ", " + yearStats.PercentSent + ", " + yearStats.MemStickPlayerLoanTotal + ", " + yearStats.PausedTotal + ", " + yearStats.AveragePaused + ", " + yearStats.DeletedTotal + ");");
        }

        /// <summary>
        /// Delete yearly stats
        /// </summary>
        /// <param name="objConn"></param>
        /// <param name="yearStats"></param>
        public void DeleteYearStats(SQLiteConnection objConn, YearStats yearStats)
        {
            if (yearStats == null)
            {
                throw new ArgumentNullException("yearStats");
            }

            DoNoResultQuery(objConn, "DELETE FROM YearStats WHERE Year = " + yearStats.Year);
        }

        /// <summary>
        /// Calculate the next free wallet number
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int CalculateNextFreeWallet(SQLiteConnection objConn)
        {
            List<Listener> listeners = GetListeners(objConn);
            int nextFreeWallet = 0;

            // Loop through listeners.
            foreach (Listener listener in listeners)
            {
                // If the next listener is more than 1 above, we have found a gap!.
                if (listener.Wallet > (nextFreeWallet + 1))
                {
                    return nextFreeWallet + 1;
                }
                // Update the next free wallet and carry on looping through
                nextFreeWallet = listener.Wallet;
            }

            // Return one past the last current wallet
            return nextFreeWallet + 1;
        }

        /// <summary>
        /// Clear all data from database
        /// </summary>
        /// <param name="objConn"></param>
        public void ClearAllData(SQLiteConnection objConn)
        {
            ClearListeners(objConn);
            ClearCollectors(objConn);
            ClearWeeklyStats(objConn);
            ClearYearStats(objConn);
        }

        /// <summary>
        /// Clear listeners
        /// </summary>
        /// <param name="conn"></param>
        public void ClearListeners(SQLiteConnection conn)
        {
            DoNoResultQuery(conn, "DELETE FROM Listeners;");
        }

        /// <summary>
        /// Clear collectors
        /// </summary>
        /// <param name="conn"></param>
        public void ClearCollectors(SQLiteConnection conn)
        {
            DoNoResultQuery(conn, "DELETE FROM Collectors;");
        }

        /// <summary>
        /// Clear weekly stats
        /// </summary>
        /// <param name="conn"></param>
        public void ClearWeeklyStats(SQLiteConnection conn)
        {
            DoNoResultQuery(conn, "DELETE FROM WeekStats;");
        }

        /// <summary>
        /// Clear yearly stats
        /// </summary>
        /// <param name="conn"></param>
        public void ClearYearStats(SQLiteConnection conn)
        {
            DoNoResultQuery(conn, "DELETE FROM YearStats;");
        }

        /// <summary>
        /// Run a specific command on the database
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="command">The command</param>
        public void RunCommand(SQLiteConnection conn, string command)
        {
            DoNoResultQuery(conn, command);
        }

        /// <summary>
        /// Get all the scan records
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<Scan> GetScanRecords(SQLiteConnection conn)
        {
            List<Scan> theScans = new List<Scan>();
            SQLiteCommand objCommand = null;
            SQLiteDataReader objReader = null;

            try
            {
                //Create a new SQL command to read all records from the customer table
                objCommand = conn.CreateCommand();
                objCommand.CommandText = "SELECT * FROM Scans";
                log.Debug("QUERY: " + objCommand.CommandText);

                //Execute the command returning a reader object
                objReader = objCommand.ExecuteReader();

                //Iterate through the rows in the reader, if we have one, we have a match!
                while ((objReader.Read()))
                {
                    Scan tempScan = ScanFromObjReader(objReader);
                    theScans.Add(tempScan);
                }

                objReader.Close();
            }
            finally
            {
                //Cleanup and close the connection
                if ((objReader != null))
                {
                    objReader.Close();
                }
                if ((objCommand != null))
                {
                    objCommand.Dispose();
                }
            }

            // Return the scans.
            return theScans;
        }

        /// <summary>
        /// Insert a scan record
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="scan"></param>
        public void InsertScan(SQLiteConnection conn, Scan scan)
        {
            string sql = $"INSERT INTO Scans (Wallet, Type, WalletType) VALUES ('{scan.Wallet}', '{scan.ScanType.ToString()}', '{scan.WalletType.ToString()}');";
            DoNoResultQuery(conn, sql);

        }

        /// <summary>
        /// Delete scan records for a listener
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="scan"></param>
        public void DeleteScans(SQLiteConnection conn, int wallet)
        {
            DoNoResultQuery(conn, "DELETE FROM Scans WHERE Wallet = " + wallet + ";");
        }
    }
}
