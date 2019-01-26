using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNBase.DataStorage.Test
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void Extensions_EnsureMinDate()
        {
            DateTime original = DateTime.Parse("01/01/1888");
            DateTime second = original.EnsureMinDate();

            Assert.IsTrue(second > original, "Expected the date to be uplifted");
        }
    }
}
