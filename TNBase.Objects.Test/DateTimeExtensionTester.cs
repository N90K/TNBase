using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class DateTimeExtensionTester
    {
        [TestMethod]
        public void NullableDateTimeTests()
        {
            Nullable<DateTime> dateTime = null;
            Assert.AreEqual("N/a", dateTime.ToNullableNaString());

            dateTime = new DateTime(1999, 1, 2);
            Assert.AreEqual("02/01/1999", dateTime.ToNullableNaString());
        } 
    }
}
