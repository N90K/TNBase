using System.Data.SQLite;
using TNBase.DataStorage.Migrations;

namespace TNBase.DataStorage.Test.Migrations.TestMigrations
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
