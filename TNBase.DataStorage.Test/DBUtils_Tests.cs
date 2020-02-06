using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TNBase.DataStorage.Test
{
    [TestClass]
    public class DBUtils_Tests
    {
        [TestMethod]
        public void DBUtils_CopyAndRestoreDB()
        {
            string backupName = "Listeners.s3db";

            DBUtils.CopyDatabase(backupName, "new.db");
            DBUtils.RestoreDatabase("new.db", backupName);
        }

        [TestMethod]
        public void DBUtils_ConnString()
        {
            Assert.IsTrue(DBUtils.GenConnectionString("test").Contains("test"));
        }
    }
}
