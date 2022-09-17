using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TNBase.Infrastructure.Helpers;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class ListenerTests
    {
        private Listener CreateValidListener()
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
            listener.LastIn = DateTime.Now;
            listener.LastOut = null;
            listener.Joined = DateTime.ParseExact("01/01/2015", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.Magazine = false;
            listener.Status = ListenerStates.ACTIVE;
            listener.DeletedDate = DateTime.ParseExact("01/01/2015", DateHelpers.DEFAULT_DATE_FORMAT, null);
            listener.Telephone = "01234567890";
            listener.Town = "London";
            listener.Wallet = 0;

            return listener;
        }

        [TestMethod]
        public void Listener_DaysBeforeBirthday()
        {
            DateTime dateTime = DateTime.Now.AddDays(5);
            Assert.AreEqual(5, Listener.DaysUntilBirthday(dateTime));

            dateTime = DateTime.Now.AddDays(67);
            Assert.AreEqual(67, Listener.DaysUntilBirthday(dateTime));
        }

        [TestMethod]
        public void Listener_PauseTest()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.ACTIVE;

            // Pause with a never end date.
            DateTime startDate = DateTime.Now;
            dummy.Pause(startDate);

            Assert.AreEqual(ListenerStates.PAUSED, dummy.Status);
            Assert.AreEqual(startDate.DayOfYear, dummy.GetStoppedDate().DayOfYear);
            // Not expecting a resume date.
            Assert.AreEqual(null, dummy.GetResumeDate());

            // Now pause them with an end date (+10 days).
            DateTime endDate = startDate.AddDays(10);
            dummy.Pause(startDate, endDate);

            Assert.AreEqual(ListenerStates.PAUSED, dummy.Status);
            Assert.AreEqual(startDate.DayOfYear, dummy.GetStoppedDate().DayOfYear);
            // Not expecting a resume date.
            Assert.AreEqual(endDate.DayOfYear, dummy.GetResumeDate().Value.DayOfYear);
        }

        [TestMethod]
        public void Listener_ResumeTest()
        {
            Listener dummy = CreateValidListener();
            dummy.Pause(DateTime.Now);
            dummy.Resume();

            Assert.AreEqual(ListenerStates.ACTIVE, dummy.Status);
            Assert.IsTrue(string.IsNullOrEmpty(dummy.StatusInfo), "Expected empty or null status info string.");
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void Listener_ResumeActive()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.ACTIVE;

            dummy.Resume();
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void Listener_PauseDeletedListener()
        {
            Listener dummy = CreateValidListener();
            dummy.Status = ListenerStates.DELETED;

            dummy.Pause(DateTime.Now);
        }

        [TestMethod]
        public void MagazineStock_ShouldBeSetToZero_WhenNewListenerIsCreated()
        {
            var listener = new Listener();

            Assert.AreEqual(0, listener.MagazineStock);
        }

        [TestMethod]
        public void GetNiceName_ReturnsName_WhenNoTitle()
        {
            var listener = new Listener
            {
                Title = "",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.GetNiceName();

            Assert.AreEqual("Bob Builder", result);
        }

        [TestMethod]
        public void GetNiceName_ReturnsNameWithTitle_WhenTitleProvided()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.GetNiceName();

            Assert.AreEqual("Mr. Bob Builder", result);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsOnlyListenerNiceName_WhenNoAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder"
            };

            var result = listener.FormatListenerData();

            Assert.AreEqual("Mr. Bob Builder", result);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsFirstLineAddressInSecondLine_WhenHasFirstLineAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test House", lines[1]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsSecondLineAddressInSecondLine_WhenHasSecondLineAddress()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test House, Test Street", lines[1]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsTownInThirdLine_WhenHasTown()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test Town", lines[2]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsCountyInThirdLine_WhenHasCounty()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town",
                County = "Test County"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test Town, Test County", lines[2]);
        }

        [TestMethod]
        public void FormatListenerData_ReturnsPostcodeInFourthLine_WhenHasPostcode()
        {
            var listener = new Listener
            {
                Title = "Mr.",
                Forename = "Bob",
                Surname = "Builder",
                Addr1 = "Test House",
                Addr2 = "Test Street",
                Town = "Test Town",
                County = "Test County",
                Postcode = "Test Postcode"
            };

            var result = listener.FormatListenerData();

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual("Test Postcode", lines[3]);
        }

        [TestMethod]
        public void Delete_SetStatusToDeleted_WhenPlayerIsNotReturned()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.Delete("");
            Assert.AreEqual(ListenerStates.DELETED, listener.Status);
        }

        [TestMethod]
        public void Delete_SetStatusToDeleted_WhenListenerHoldsNewsWallet()
        {
            var listener = new Listener
            {
                Stock = 0,
            };

            listener.Delete("");
            Assert.AreEqual(ListenerStates.DELETED, listener.Status);
        }

        [TestMethod]
        public void Delete_SetStatusToDeleted_WhenListenerHoldsMagazineWallet()
        {
            var listener = new Listener
            {
                Stock = 3,
                Magazine = true,
                MagazineStock = 0
            };

            listener.Delete("");
            Assert.AreEqual(ListenerStates.DELETED, listener.Status);
        }

        [TestMethod]
        public void Delete_ClearsListenersPersonalInformation_WhenListenerIsPurged()
        {
            var listener = new Listener
            {
                Title = "Title",
                Forename = "Forename",
                Surname = "Surname",
                Addr1 = "Address1",
                Addr2 = "Address2",
                Town = "Town",
                County = "County",
                Postcode = "Postcode",
                Telephone = "123456789",
                BirthdayDay = 5,
                BirthdayMonth = 12,
                Info = "Test Info",
                StatusInfo = "Test Status Info"
            };

            listener.Delete("");

            Assert.AreEqual("N/A", listener.Title);
            Assert.AreEqual("Deleted", listener.Forename);
            Assert.AreEqual("Deleted", listener.Surname);
            Assert.IsNull(listener.Addr1);
            Assert.IsNull(listener.Addr2);
            Assert.IsNull(listener.Town);
            Assert.IsNull(listener.County);
            Assert.IsNull(listener.Postcode);
            Assert.IsNull(listener.Telephone);
            Assert.IsNull(listener.BirthdayDay);
            Assert.IsNull(listener.BirthdayMonth);
            Assert.IsNull(listener.Info);
            Assert.IsNull(listener.StatusInfo);
        }

        [TestMethod]
        public void Delete_MaintainsListenersPersonalInformation_WhenListenerIsDeleted()
        {
            var joinDate = DateTime.Now;

            var listener = new Listener
            {
                MemStickPlayer = true,
                Title = "Title",
                Forename = "Forename",
                Surname = "Surname",
                Addr1 = "Address1",
                Addr2 = "Address2",
                Town = "Town",
                County = "County",
                Postcode = "Postcode",
                Telephone = "123456789",
                Joined = joinDate,
                BirthdayDay = 5,
                BirthdayMonth = 12,
                Info = "Test Info"
            };

            listener.Delete("");

            Assert.AreEqual("Title", listener.Title);
            Assert.AreEqual("Forename", listener.Forename);
            Assert.AreEqual("Surname", listener.Surname);
            Assert.AreEqual("Address1", listener.Addr1);
            Assert.AreEqual("Address2", listener.Addr2);
            Assert.AreEqual("Town", listener.Town);
            Assert.AreEqual("County", listener.County);
            Assert.AreEqual("Postcode", listener.Postcode);
            Assert.AreEqual("123456789", listener.Telephone);
            Assert.AreEqual(joinDate, listener.Joined);
            Assert.AreEqual(5, listener.BirthdayDay);
            Assert.AreEqual(12, listener.BirthdayMonth);
            Assert.AreEqual("Test Info", listener.Info);
        }

        [TestMethod]
        public void Delete_SetsCorrectDeletedDate_WhenListenerIsDeleted()
        {
            var listener = new Listener();

            var before = DateTime.UtcNow;
            listener.Delete("");
            var after = DateTime.UtcNow;

            Assert.IsTrue(before <= listener.DeletedDate, "Date is greater or equal to before");
            Assert.IsTrue(after >= listener.DeletedDate, "Date is less or equal to after");
        }

        [TestMethod]
        public void Delete_SetsCorrectDeletedDate_WhenListenerIsPurged()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            var before = DateTime.UtcNow;
            listener.Delete("");
            var after = DateTime.UtcNow;

            Assert.IsTrue(before <= listener.DeletedDate, "Date is greater or equal to before");
            Assert.IsTrue(after >= listener.DeletedDate, "Date is less or equal to after");
        }

        [TestMethod]
        public void Delete_SetsReason_WhenListenerIsDeleted()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.Delete("Delete reason");

            Assert.AreEqual("Delete reason", listener.StatusInfo);
        }

        [TestMethod]
        public void Delete_SetsReason_WhenListenerIsPurged()
        {
            var listener = new Listener
            {
                MemStickPlayer = true
            };

            listener.Delete("Delete reason");

            Assert.AreEqual("Delete reason", listener.StatusInfo);
        }

        [TestMethod]
        public void Restore_SetsStatusToActive_WhenListenerIsDeleted()
        {
            var listener = new Listener
            {
                Status = ListenerStates.DELETED
            };

            listener.Restore();

            Assert.AreEqual(ListenerStates.ACTIVE, listener.Status);
        }

        [TestMethod]
        public void Restore_ClearsStatusInfo()
        {
            var listener = new Listener
            {
                Status = ListenerStates.DELETED,
                StatusInfo = "Deleted"
            };

            listener.Restore();

            Assert.AreEqual("", listener.StatusInfo);
        }

        [TestMethod]
        public void Restore_ClearsDeletedDate()
        {
            var listener = new Listener
            {
                Status = ListenerStates.DELETED,
                DeletedDate = DateTime.UtcNow
            };

            listener.Restore();

            Assert.IsNull(listener.DeletedDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void Restore_ThrowsSatusChangeException_WhenListenerIsActive()
        {
            var listener = new Listener
            {
                Status = ListenerStates.ACTIVE
            };

            listener.Restore();
        }

        [TestMethod]
        [ExpectedException(typeof(ListenerStateChangeException))]
        public void Restore_ThrowsSatusChangeException_WhenListenerIsPaused()
        {
            var listener = new Listener
            {
                Status = ListenerStates.PAUSED
            };

            listener.Restore();
        }

        [TestMethod]
        public void SentNewsWallets_ReturnsZero_WhenAllNewsWalletsAreInStock()
        {
            var listener = new Listener { Stock = 3 };

            Assert.AreEqual(0, listener.SentNewsWallets);
        }

        [TestMethod]
        public void SentNewsWallets_ReturnsNumberOfSentWallets_WhenNotAllNewsWalletsAreInStock()
        {
            var listener = new Listener { Stock = 1 };

            Assert.AreEqual(2, listener.SentNewsWallets);
        }

        [TestMethod]
        public void SentMagazineWallets_ReturnsZero_WhenMagazineWalletIsInStock()
        {
            var listener = new Listener { MagazineStock = 1, Magazine = true };

            Assert.AreEqual(0, listener.SentMagazineWallets);
        }

        [TestMethod]
        public void SentMagazineWallets_ReturnsNumberOfSentWallets_WhenNoMagazineWalletIsInStock()
        {
            var listener = new Listener { MagazineStock = 0, Magazine = true };

            Assert.AreEqual(1, listener.SentMagazineWallets);
        }

        [TestMethod]
        public void SentMagazineWallets_ReturnsZero_WhenMagazineOptionIsNotSet()
        {
            var listener = new Listener { MagazineStock = 0, Magazine = false };

            Assert.AreEqual(0, listener.SentMagazineWallets);
        }

        [TestMethod]
        public void Scan_PurgesListener_WhenDeletedListenerLastNewsWalletIsReturned()
        {
            var listener = new Listener
            {
                Forename = "Listener",
                Stock = 2,
                Status = ListenerStates.DELETED
            };

            listener.Scan(ScanTypes.IN, WalletTypes.News);

            Assert.IsTrue(listener.IsPurged);
        }

        [TestMethod]
        public void Scan_PurgesListener_WhenDeletedListenerLastMagazineWalletIsReturned()
        {
            var listener = new Listener
            {
                Forename = "Listener",
                Magazine = true,
                MagazineStock = 0,
                Status = ListenerStates.DELETED
            };

            listener.Scan(ScanTypes.IN, WalletTypes.Magazine);

            Assert.IsTrue(listener.IsPurged);
        }
    }
}
