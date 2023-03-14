using System;
using System.Linq;
using TNBase.External.DataExport;
using TNBase.Infrastructure.Helpers;
using TNBase.Objects;
using TNBase.Repository;
using Xunit;

namespace TNBase.External.Tests.DataExport
{
    public class CsvExportServiceTests

    {
        private const string Header = "Forename,Surname,Wallet,Title,Addr1,Addr2,Town,County,Postcode,OnlineOnly,ReceivesMagazine,HasPlayerIssued,Telephone,JoinedDate,BirthdayDay,BirthdayMonth,Status,PauseStartDate,PauseEndDate,NewsStock,NumberOfNewsIssued,MagazineStock,NumberOfMagazinesIssued,Information,WarnOfAddressChange,DeletedDate,LastIn,LastOut,Wallet,In1,In2,In3,In4,In5,In6,In7,In8,Out1,Out2,Out3,Out4,Out5,Out6,Out7,Out8";

        private Listener CreateListener1()
        {
            Listener listener = new Listener();

            listener.Title = "Mr";
            listener.Forename = "Ted";
            listener.Surname = "Baker";
            listener.Addr1 = "29 Baker Street";
            listener.Addr2 = "";
            listener.Postcode = "N193HH";
            listener.BirthdayDay = 1;
            listener.BirthdayMonth = 1;
            listener.County = "Londonshire";
            listener.InOutRecords = new InOutRecords();
            listener.MemStickPlayer = true;
            listener.LastIn = DateTime.ParseExact("21/02/2015", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.LastOut = null;
            listener.Joined = DateTime.ParseExact("01/01/2015", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.Magazine = false;
            listener.Status = ListenerStates.ACTIVE;
            listener.Telephone = "01234567890";
            listener.Town = "London";
            listener.Wallet = 0;
            listener.Stock = 3;

            return listener;
        }

        private Listener CreateListener2()
        {
            Listener listener = new Listener();

            listener.Title = "Mrs";
            listener.Forename = "Sarah";
            listener.Surname = "Turner";
            listener.Addr1 = "3 High Street";
            listener.Addr2 = "near, here";
            listener.Postcode = "WS2 4TF";
            listener.County = "Shropshire";
            listener.InOutRecords = new InOutRecords();
            listener.MemStickPlayer = false;
            listener.LastIn = DateTime.ParseExact("21/07/2020", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.LastOut = null;
            listener.Joined = DateTime.ParseExact("01/12/2019", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.Magazine = false;
            listener.Status = ListenerStates.ACTIVE;
            listener.Telephone = "124";
            listener.Town = "Walsall";
            listener.Wallet = 1;
            listener.Stock = 2;

            return listener;
        }

        [Fact]
        public void ExportListeners_ShouldHeaderOnly_WhenNoRecords()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal(Header + Environment.NewLine, result);
        }

        [Fact]
        public void ExportListeners_ShouldTwoLines_WhenOneRecord()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.Listeners.Add(CreateListener1());
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal(3, result.Split(Environment.NewLine).Length);
            Assert.Equal(Header, result.Split(Environment.NewLine)[0]);
            Assert.NotEqual(Header, result.Split(Environment.NewLine)[1]);
        }

        [Fact]
        public void ExportListeners_CorrectLine_WhenOneRecord()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.Listeners.Add(CreateListener1());
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal("Ted,Baker,0,Mr,29 Baker Street,,London,Londonshire,N193HH,False,False,True,01234567890,01/01/2015,1,1,ACTIVE,,,3,0,0,0,,False,,21/02/2015,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", result.Split(Environment.NewLine)[1]);
        }

        [Fact]
        public void ExportListeners_CorrectLine_WhenOneRecordPaused()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            var listener = CreateListener1();
            listener.Pause(new DateTime(2016, 3, 1), new DateTime(2016, 9, 13));
            context.Listeners.Add(listener);
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal("Ted,Baker,0,Mr,29 Baker Street,,London,Londonshire,N193HH,False,False,True,01234567890,01/01/2015,1,1,PAUSED,01/03/2016,13/09/2016,3,0,0,0,,False,,21/02/2015,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", result.Split(Environment.NewLine)[1]);
        }

        [Fact]
        public void ExportListeners_CorrectLine_WhenOneRecordDeleted()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            var listener = CreateListener1();
            listener.Delete("not needed");
            listener.DeletedDate = new DateTime(2023, 3, 4);
            context.Listeners.Add(listener);
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal("Ted,Baker,0,Mr,29 Baker Street,,London,Londonshire,N193HH,False,False,True,01234567890,01/01/2015,1,1,DELETED,,,3,0,0,0,,False,04/03/2023,21/02/2015,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", result.Split(Environment.NewLine)[1]);
        }

        [Fact]
        public void ExportListeners_CorrectLine_WhenOneRecordScanOut()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            var listener = CreateListener1();
            listener.Scan(ScanTypes.OUT, WalletTypes.News);
            context.Listeners.Add(listener);
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal("Ted,Baker,0,Mr,29 Baker Street,,London,Londonshire,N193HH,False,False,True,01234567890,01/01/2015,1,1,ACTIVE,,,2,0,0,0,,False,,21/02/2015,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", result.Split(Environment.NewLine)[1]);
        }

        [Fact]
        public void ExportListeners_CorrectLine_WhenTwoRecords()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.Listeners.Add(CreateListener1());
            context.Listeners.Add(CreateListener2());
            context.UpdateDatabase();
            var service = new CsvExportService();

            string result = service.ExportListeners(context.Listeners.Local.ToList());

            Assert.Equal(Header, result.Split(Environment.NewLine)[0]);
            Assert.Equal("Ted,Baker,0,Mr,29 Baker Street,,London,Londonshire,N193HH,False,False,True,01234567890,01/01/2015,1,1,ACTIVE,,,3,0,0,0,,False,,21/02/2015,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", result.Split(Environment.NewLine)[1]);
            Assert.Equal("Sarah,Turner,0,Mrs,3 High Street,\"near, here\",Walsall,Shropshire,WS2 4TF,False,False,False,124,01/12/2019,,,ACTIVE,,,2,0,0,0,,False,,21/07/2020,,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0", result.Split(Environment.NewLine)[2]);
        }
    }
}
