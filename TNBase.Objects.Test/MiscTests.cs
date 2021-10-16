using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void DateTime_Sat_Test()
        {
            DateTime dt = DateTime.ParseExact("28/01/2017", "dd/MM/yyyy", null);
            Assert.AreEqual(DayOfWeek.Saturday, dt.DayOfWeek);
        }
    }
}
