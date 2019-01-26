using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNBase.DataStorage.Test
{
    [DeploymentItem(@"x86\SQLite.Interop.dll", "x86")] // this is the key
    [DeploymentItem("Listeners.s3db")]
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
