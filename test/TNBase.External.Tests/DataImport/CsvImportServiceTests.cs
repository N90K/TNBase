using System;
using System.Collections.Generic;
using System.Linq;
using TNBase.External.DataImport;
using TNBase.Objects;
using TNBase.Repository;
using Xunit;

namespace TNBase.External.Tests.DataImport
{
    public class CsvImportServiceTests
    {
        [Fact]
        public void ImportListeners_ShouldThrowInvalidDataException_WhenNoData()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"";

            Assert.Throws<InvalidImportDataException>(() =>
                service.ImportListeners(importData)
            );
        }

        [Fact]
        public void ImportListeners_ShouldDoNothing_WhenNoRecords()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname";

            service.ImportListeners(importData);

            Assert.Empty(context.Listeners);
        }

        [Fact]
        public void ImportListeners_ShouldCreateListener_WhenContainsSingleRecord()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker";

            service.ImportListeners(importData);

            Assert.Single(context.Listeners);
        }

        [Fact]
        public void ImportListeners_ShouldCreateMultipleListeners_WhenContainsMultipleRecords()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,Tom,Shaw
3,Fred,Gray";

            service.ImportListeners(importData);

            Assert.Equal(3, context.Listeners.Count());
        }

        [Fact]
        public void ImportListeners_ShouldRequireForename()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,,Shaw
3,Fred,Gray";

            var result = service.ImportListeners(importData);

            var faildedRecords = result.Records.Where(x => x.HasError).ToList();
            Assert.Single(faildedRecords);
            Assert.Equal(3, faildedRecords.First().Row);
            Assert.Equal("Forename", faildedRecords.First().Error.FieldName);
            Assert.Equal("Forename is required", faildedRecords.First().Error.ErrorMessage);
        }

        [Fact]
        public void ImportListeners_ShouldRequireSurname()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,Tom,
3,Fred,Gray";

            var result = service.ImportListeners(importData);

            var faildedRecords = result.Records.Where(x => x.HasError).ToList();
            Assert.Single(faildedRecords);
            Assert.Equal(3, faildedRecords.First().Row);
            Assert.Equal("Surname", faildedRecords.First().Error.FieldName);
            Assert.Equal("Surname is required", faildedRecords.First().Error.ErrorMessage);
        }

        [Fact]
        public void ImportListeners_ShouldAddListenerWithNewWalletNumbers_WhenWalletFieldNotSpecified()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            context.Listeners.Add(new Listener
            {
                Wallet = 1,
                Forename = "Jason",
                Surname = "Bourne",
                InOutRecords = new InOutRecords { Wallet = 1 }
            });
            context.SaveChanges();

            var service = new CsvImportService(context);

            var importData = @"Forename,Surname
Bob,Baker
Tom,Shaw";

            var result = service.ImportListeners(importData);

            Assert.Equal(2, context.Listeners.Single(x => x.Forename == "Bob").Wallet);
            Assert.Equal(3, context.Listeners.Single(x => x.Forename == "Tom").Wallet);
        }

        [Fact]
        public void ImportListeners_ShouldNotReplaceExistingListener_WhenListenerWithSpecifiedWalletExists()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            context.Listeners.Add(new Listener
            {
                Wallet = 2,
                Forename = "Jason",
                Surname = "Bourne",
                InOutRecords = new InOutRecords { Wallet = 2 }
            });
            context.SaveChanges();

            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,Tom,Shaw
3,Fred,Gray";

            var result = service.ImportListeners(importData);

            Assert.Equal(3, context.Listeners.Count());

            var existingListener = context.Listeners.Single(x => x.Wallet == 2);
            Assert.Equal("Jason", existingListener.Forename);
            Assert.Equal("Bourne", existingListener.Surname);

            Assert.False(context.Listeners.Any(x => x.Forename == "Tom" || x.Surname == "Shaw"));
        }

        [Fact]
        public void ImportListeners_ShouldReturnErrorForRecord_WhenListenerWithSpecifiedWalletExists()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            context.Listeners.Add(new Listener
            {
                Wallet = 2,
                Forename = "Jason",
                Surname = "Bourne",
                InOutRecords = new InOutRecords { Wallet = 2 }
            });
            context.SaveChanges();

            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,Tom,Shaw
3,Fred,Gray";

            var result = service.ImportListeners(importData);

            var faildedRecords = result.Records.Where(x => x.HasError).ToList();
            Assert.Single(faildedRecords);
            Assert.Equal(3, faildedRecords.First().Row);
            Assert.Equal("Wallet", faildedRecords.First().Error.FieldName);
            Assert.Equal("Listener with wallet number 2 already exists", faildedRecords.First().Error.ErrorMessage);
        }

        [Fact]
        public void ImportListeners_ShouldReturnErrorForRecord_WhenListenerWithSameWalletWasAlreadyAdded()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();

            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker
2,Tom,Shaw
1,Fred,Gray";

            var result = service.ImportListeners(importData);

            var faildedRecords = result.Records.Where(x => x.HasError).ToList();
            Assert.Single(faildedRecords);
            Assert.Equal(4, faildedRecords.First().Row);
            Assert.Equal("Wallet", faildedRecords.First().Error.FieldName);
            Assert.Equal("Duplicate wallet number. Wallet '1' was imported at row number '2'", faildedRecords.First().Error.ErrorMessage);
        }

        [Fact]
        public void ImportListeners_ShouldFail_WhenRequiredColumnIsMissing()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Surname
1,Baker
2,Shaw
3,Gray";

            var ex = Assert.Throws<InvalidImportDataException>(() =>
                service.ImportListeners(importData)
            );

            Assert.Equal("Field with name 'Forename' does not exist", ex.Message);
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithCorrectDetails()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Title,Forename,Surname,Addr1,Addr2,Town,County,Postcode,Telephone,BirthdayDay,BirthdayMonth,Information
1,Mr,Tom,Baker,189 Queens Court,High St,Ramsgate,Kent,CT11 9TP,01843 851077,4,10,Test Info
5,Miss,Ashley,Robertson,Matlock St,,Bakewell,Derbyshire,DE45 1EE,01629 814692,28,3,";

            service.ImportListeners(importData);

            var listeners = context.Listeners.OrderBy(x => x.Wallet).ToList();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listeners.First().Wallet),
                new ("Mr", listeners.First().Title),
                new ("Tom", listeners.First().Forename),
                new ("Baker", listeners.First().Surname),
                new ("189 Queens Court", listeners.First().Addr1),
                new ("High St", listeners.First().Addr2),
                new ("Ramsgate", listeners.First().Town),
                new ("Kent", listeners.First().County),
                new ("CT11 9TP", listeners.First().Postcode),
                new ("01843 851077", listeners.First().Telephone),
                new (4, listeners.First().BirthdayDay),
                new (10, listeners.First().BirthdayMonth),
                new ("Test Info", listeners.First().Info),

                new (5, listeners.Last().Wallet),
                new ("Miss", listeners.Last().Title),
                new ("Ashley", listeners.Last().Forename),
                new ("Robertson", listeners.Last().Surname),
                new ("Matlock St", listeners.Last().Addr1),
                new ("", listeners.Last().Addr2),
                new ("Bakewell", listeners.Last().Town),
                new ("Derbyshire", listeners.Last().County),
                new ("DE45 1EE", listeners.Last().Postcode),
                new ("01629 814692", listeners.Last().Telephone),
                new (28, listeners.Last().BirthdayDay),
                new (3, listeners.Last().BirthdayMonth),
                new ("", listeners.Last().Info)
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithDefaultDetails_WhenValuesNotSet()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Title,Forename,Surname,Addr1,Addr2,Town,County,Postcode,Telephone,BirthdayDay,BirthdayMonth,Information
,,Tom,Baker,,,,,,,,,";

            service.ImportListeners(importData);

            var listener = context.Listeners.First();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listener.Wallet),
                new ("", listener.Title),
                new ("Tom", listener.Forename),
                new ("Baker", listener.Surname),
                new ("", listener.Addr1),
                new ("", listener.Addr2),
                new ("", listener.Town),
                new ("", listener.County),
                new ("", listener.Postcode),
                new ("", listener.Telephone),
                new (null, listener.BirthdayDay),
                new (null, listener.BirthdayMonth),
                new ("", listener.Info),
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithCorrectSettings()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname,OnlineOnly,ReceivesMagazine,HasPlayerIssued,NumberOfNewsIssued,NewsStock,NumberOfMagazinesIssued,MagazineStock
1,Tom,Baker,0,1,1,3,2,1,0,Contact: John Baker (father) 01843 851088
2,Ashley,Robertson,0,0,1,3,3,0,0,
3,Rebecca,Shaw,1,0,0,0,0,0,0,";

            service.ImportListeners(importData);

            var listeners = context.Listeners.OrderBy(x => x.Wallet).ToList();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listeners[0].Wallet),
                new (false, listeners[0].OnlineOnly),
                new (true, listeners[0].Magazine),
                new (true, listeners[0].MemStickPlayer),
                new (3, listeners[0].NewsWalletsIssued),
                new (2, listeners[0].Stock),
                new (1, listeners[0].MagazineWalletsIssued),
                new (0, listeners[0].MagazineStock),

                new (2, listeners[1].Wallet),
                new (false, listeners[1].OnlineOnly),
                new (false, listeners[1].Magazine),
                new (true, listeners[1].MemStickPlayer),
                new (3, listeners[1].NewsWalletsIssued),
                new (3, listeners[1].Stock),
                new (0, listeners[1].MagazineWalletsIssued),
                new (0, listeners[1].MagazineStock),

                new (3, listeners[2].Wallet),
                new (true, listeners[2].OnlineOnly),
                new (false, listeners[2].Magazine),
                new (false, listeners[2].MemStickPlayer),
                new (0, listeners[2].NewsWalletsIssued),
                new (0, listeners[2].Stock),
                new (0, listeners[2].MagazineWalletsIssued),
                new (0, listeners[2].MagazineStock)
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithDefaultSettings_WhenValuesNotSet()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname,OnlineOnly,ReceivesMagazine,HasPlayerIssued,NumberOfNewsIssued,NewsStock,NumberOfMagazinesIssued,MagazineStock
,Tom,Baker,,,,,,,,";

            service.ImportListeners(importData);

            var listener = context.Listeners.First();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listener.Wallet),
                new (false, listener.OnlineOnly),
                new (false, listener.Magazine),
                new (false, listener.MemStickPlayer),
                new (0, listener.NewsWalletsIssued),
                new (0, listener.Stock),
                new (0, listener.MagazineWalletsIssued),
                new (0, listener.MagazineStock),
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithCorrectJoinedDate()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname,JoinedDate
1,Tom,Baker,25/03/2018
2,Ashley,Robertson,09/12/2020
3,Rebecca,Shaw,18/10/2021";

            service.ImportListeners(importData);

            var listeners = context.Listeners.OrderBy(x => x.Wallet).ToList();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listeners[0].Wallet),
                new (new DateTime(2018, 03, 25), listeners[0].Joined),

                new (2, listeners[1].Wallet),
                new (new DateTime(2020, 12, 09), listeners[1].Joined),

                new (3, listeners[2].Wallet),
                new (new DateTime(2021, 10, 18), listeners[2].Joined)
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithDefaultJoinedDate_WhenValuesNotSet()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname,JoinedDate
,Tom,Baker,";

            service.ImportListeners(importData);

            var listener = context.Listeners.First();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listener.Wallet),
                new (null, listener.Joined),
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithCorrectStatus()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname,Status,PauseStartDate,PauseEndDate
1,Tom,Baker,PAUSED,15/06/2020,15/08/2020
2,Ashley,Robertson,Paused,23/10/2021,
3,Rebecca,Shaw,active,,
4,Bill,Snow,ACTIVE,15/08/2019,";

            service.ImportListeners(importData);

            var listeners = context.Listeners.OrderBy(x => x.Wallet).ToList();

            Assert.Equal(4, listeners.Count);

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listeners[0].Wallet),
                new (ListenerStates.PAUSED, listeners[0].Status),
                new ("15/06/2020,15/08/2020", listeners[0].StatusInfo),

                new (2, listeners[1].Wallet),
                new (ListenerStates.PAUSED, listeners[1].Status),
                new ("23/10/2021,UFN", listeners[1].StatusInfo),

                new (3, listeners[2].Wallet),
                new (ListenerStates.ACTIVE, listeners[2].Status),
                new ("", listeners[2].StatusInfo),

                new (4, listeners[3].Wallet),
                new (ListenerStates.ACTIVE, listeners[3].Status),
                new ("", listeners[3].StatusInfo)
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldSaveListenerWithDefaultStatus_WhenValueNotSet()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname,Status,PauseStartDate,PauseEndDate
,Tom,Baker,,,";

            service.ImportListeners(importData);

            var listener = context.Listeners.First();

            Assert.All(new List<Tuple<object, object>>
            {
                new (1, listener.Wallet),
                new (ListenerStates.ACTIVE, listener.Status),
                new ("", listener.StatusInfo),
            }, pair => Assert.Equal(pair.Item1, pair.Item2));
        }

        [Fact]
        public void ImportListeners_ShouldIncludeHeaderStringInResult()
        {
            using var context = new TNBaseContext("Data Source=:memory:");
            context.UpdateDatabase();
            var service = new CsvImportService(context);

            var importData = @"Wallet,Forename,Surname
1,Bob,Baker";

            var result = service.ImportListeners(importData);

            Assert.Equal("Wallet,Forename,Surname", result.RawHeader);
        }
    }
}
