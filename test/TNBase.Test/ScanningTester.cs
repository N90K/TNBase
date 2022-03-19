using Microsoft.VisualStudio.TestTools.UnitTesting;
using TNBase.Infrastructure;

namespace TNBase.Test
{
    [TestClass]
    public class ScanningTester
    {
        [TestMethod]
        public void Scanning_ScanInOutTest()
        {
            // Simple test.
            ModuleScanning.setScannedIn(100);
            ModuleScanning.setScannedOut(100);

            Assert.IsTrue(ModuleScanning.getScannedIn() == 100 && ModuleScanning.getScannedOut() == 100);
        }

        [TestMethod]
        public void Scanning_ScanInOutBelowZero()
        {
            // Test negatives are handled.
            ModuleScanning.setScannedIn(-2);
            ModuleScanning.setScannedOut(-400);

            Assert.IsTrue(ModuleScanning.getScannedIn() == 0 && ModuleScanning.getScannedOut() == 0);
        }
    }
}
