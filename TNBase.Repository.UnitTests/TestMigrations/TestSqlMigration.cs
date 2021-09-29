using Microsoft.Data.Sqlite;

namespace TNBase.Repository.UnitTests.TestMigrations
{
    public abstract class TestSqlMigration : ISqlMigration
    {
        protected readonly SqliteConnection connection;

        public TestSqlMigration(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public abstract int Version { get; }

        public abstract string Name { get; }

        public abstract void Up();
    }
}
