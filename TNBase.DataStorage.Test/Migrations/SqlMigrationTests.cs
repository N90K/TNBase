using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using TNBase.DataStorage.Migrations;

namespace TNBase.DataStorage.Test.Migrations
{
    [TestClass]
    public class SqlMigrationTests
    {
        [TestMethod]
        public void Version_ReturnsVersionNumberFromClassName()
        {
            var migration = new _123_TestSqlMigration(new SQLiteConnection());
            Assert.AreEqual(123, migration.Version);
        }

        [TestMethod]
        public void Version_ReturnsMigrationNameFromClassName()
        {
            var migration = new _123_TestSqlMigration(new SQLiteConnection());
            Assert.AreEqual("TestSqlMigration", migration.Name);
        }

        private class _123_TestSqlMigration : SqlMigration
        {
            public _123_TestSqlMigration(SQLiteConnection connection) : base(connection)
            {
            }

            public override void Up()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
