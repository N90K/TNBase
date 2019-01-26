using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TNBase.Objects.Test
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void ValidPostcode_NoSurnameSpec()
        {
            Utils.validatePostcode("CF14");
        }

        [TestMethod]
        public void ValidPostcode_SurnameSpec()
        {
            Utils.validatePostcode("CF145DD [A-H]");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidPostcode()
        {
            Utils.validatePostcode("CF4344!");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidPostcode_TooLong()
        {
            Utils.validatePostcode("CF4344d3");
        }

        [TestMethod]
        public void PostcodeValidForSurname()
        {
            Assert.IsTrue(Utils.postcodeValidForSurname("CF14 [A-F]", "Francis"));
            Assert.IsFalse(Utils.postcodeValidForSurname("CF14 [A-F]", "Zoric"));
            Assert.IsTrue(Utils.postcodeValidForSurname("CJ24 4D [J-Z]", "Zoric"));
            Assert.IsTrue(Utils.postcodeValidForSurname("CJ24 4D", "Zoric"));
        }

        [TestMethod]
        public void RemoveSurnameSpec_Multiple()
        {
            Assert.AreEqual("CF146DD", Utils.removeSurnameSpecifier("CF14 6DD [A-H]"));
            Assert.AreEqual("CF1", Utils.removeSurnameSpecifier("CF1 [A-H]"));
            Assert.AreEqual("CF1CH", Utils.removeSurnameSpecifier("Cf1ch [A-H]"));
        }
    }
}
