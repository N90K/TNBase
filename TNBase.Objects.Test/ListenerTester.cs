using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class ListenerTester
    {
        /// <summary>
        /// Create a valid dummy listener for testing.
        /// </summary>
        /// <returns>the dummy listener.</returns>
        public static Listener CreateValidListener()
        {
            Listener listener = new Listener();

            listener.Title = "Mr";
            listener.Forename = "Ted";
            listener.Surname = "Baker";
            listener.Addr1 = "29 Baker Street";
            listener.Addr2 = "";
            listener.Postcode = "N193HH";
            listener.County = "Londonshire";
            listener.inOutRecords = new InOutRecords();
            listener.MemStickPlayer = true;
            listener.LastIn = DateTime.Now;
            listener.LastOut = null;
            listener.Joined = DateTime.Parse("01/01/2015");
            listener.Magazine = false;
            listener.Status = ListenerStates.ACTIVE;
            listener.DeletedDate = DateTime.Parse("01/01/2015");
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
            Assert.AreEqual(startDate.DayOfYear, Listener.GetStoppedDate(dummy).DayOfYear);
            // Not expecting a resume date.
            Assert.AreEqual(null, Listener.GetResumeDate(dummy));

            // Now pause them with an end date (+10 days).
            DateTime endDate = startDate.AddDays(10);
            dummy.Pause(startDate, endDate);

            Assert.AreEqual(ListenerStates.PAUSED, dummy.Status);
            Assert.AreEqual(startDate.DayOfYear, Listener.GetStoppedDate(dummy).DayOfYear);
            // Not expecting a resume date.
            Assert.AreEqual(endDate.DayOfYear, Listener.GetResumeDate(dummy).Value.DayOfYear);
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
        public void Listener_NiceNameForListenerNoTitle()
        {
            Listener listener = CreateValidListener();
            listener.Title = "";
            listener.Forename = "Bob";
            listener.Surname = "Builder";

            Assert.AreEqual("Bob Builder", listener.GetNiceName());
        }

        [TestMethod]
        public void Listener_NiceNameForListenerNoDotTitle()
        {
            Listener listener = CreateValidListener();
            listener.Title = "Dr";
            listener.Forename = "Bob";
            listener.Surname = "Builder";

            Assert.AreEqual("Dr. Bob Builder", listener.GetNiceName());
        }

        [TestMethod]
        public void Listener_NiceNameForListenerDotTitle()
        {
            Listener listener = CreateValidListener();
            listener.Title = "Master";
            listener.Forename = "Bob";
            listener.Surname = "Builder";

            Assert.AreEqual("Master. Bob Builder", listener.GetNiceName());
        }
    }
}
