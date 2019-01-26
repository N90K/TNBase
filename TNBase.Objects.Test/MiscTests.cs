using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void DateTime_Sat_Test()
        {
            DateTime dt = DateTime.Parse("28/01/2017");
            Assert.AreEqual(DayOfWeek.Saturday, dt.DayOfWeek);
        }
    }
}
