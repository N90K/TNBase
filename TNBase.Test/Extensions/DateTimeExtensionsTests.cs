using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TNBase.Extensions;

namespace TNBase.Test.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void WeekOfYear_ShouldGetWeekNumber()
        {
            var date = new DateTime(2014, 1, 1);
            var weekNumber = date.WeekOfYear();
            Assert.AreEqual(1, weekNumber);
        }

        [TestMethod]
        public void WeekOfYear_ShouldGetCorrectIso8601WeekNumberForLeapYear()
        {
            var date = new DateTime(2013, 12, 31);
            var weekNumber = date.WeekOfYear();
            Assert.AreEqual(1, weekNumber);
        }

        [TestMethod]
        public void WeekStart_ShouldGetMondayZeroHours_WhenMonday()
        {
            var date = new DateTime(2020, 1, 13, 10, 15, 30);
            var weekStart = date.WeekStart();
            Assert.AreEqual(new DateTime(2020, 1, 13, 0, 0, 0), weekStart);
        }

        [TestMethod]
        public void WeekStart_ShouldGetMondayZeroHours_WhenSunday()
        {
            var date = new DateTime(2020, 1, 19, 10, 15, 30);
            var weekStart = date.WeekStart();
            Assert.AreEqual(new DateTime(2020, 1, 13, 0, 0, 0), weekStart);
        }

        [TestMethod]
        public void NextWeekStart_ShouldGetNextWeeksMondayZeroHours_WhenMonday()
        {
            var date = new DateTime(2020, 1, 13, 10, 15, 30);
            var nextWeekStart = date.NextWeekStart();
            Assert.AreEqual(new DateTime(2020, 1, 20, 0, 0, 0), nextWeekStart);
        }

        [TestMethod]
        public void NextWeekStart_ShouldGetNextWeeksMondayZeroHours_WhenSunday()
        {
            var date = new DateTime(2020, 1, 19, 10, 15, 30);
            var nextWeekStart = date.NextWeekStart();
            Assert.AreEqual(new DateTime(2020, 1, 20, 0, 0, 0), nextWeekStart);
        }
    }
}
