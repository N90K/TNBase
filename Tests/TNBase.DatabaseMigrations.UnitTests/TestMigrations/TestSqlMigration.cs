using System.Data.SQLite;

namespace TNBase.DatabaseMigrations.UnitTests.TestMigrations
{
    public abstract class TestSqlMigration : ISqlMigration
    {
        protected readonly SQLiteConnection connection;

        public TestSqlMigration(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public abstract int Version { get; }

        public abstract string Name { get; }

        public abstract void Up();
    }
}
