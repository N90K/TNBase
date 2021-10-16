using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TNBase.Infrastructure.Helpers;

namespace TNBase.DataStorage.Test
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void Extensions_EnsureMinDate()
        {
            DateTime original = DateTime.ParseExact("01/01/1888", DateHelpers.DEFAULT_DATE_FORMAT, null);
            DateTime second = original.EnsureMinDate();

            Assert.IsTrue(second > original, "Expected the date to be uplifted");
        }
    }
}
