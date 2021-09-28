using System.Data.SQLite;
using Xunit;

namespace TNBase.DatabaseMigrations.UnitTests
{
    public class SqlMigrationTests
    {
        [Fact]
        public void Version_ReturnsVersionNumberFromClassName()
        {
            var migration = new _123_TestSqlMigration(new SQLiteConnection());
            Assert.Equal(123, migration.Version);
        }

        [Fact]
        public void Version_ReturnsMigrationNameFromClassName()
        {
            var migration = new _123_TestSqlMigration(new SQLiteConnection());
            Assert.Equal("TestSqlMigration", migration.Name);
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
