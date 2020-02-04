using NLog;
using System;
using System.Data.SQLite;

namespace TNBase.DataStorage.Migrations
{
    public abstract class SqlMigration : ISqlMigration
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        protected readonly SQLiteConnection connection;

        public SqlMigration(SQLiteConnection connection)
        {
            this.connection = connection;
            SetVersionAndName();
        }

        public int Version { get; private set; }

        public string Name { get; private set; }

        protected void Sql(string query)
        {
            log.Debug("Executing query: " + query);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }

        public abstract void Up();

        private void SetVersionAndName()
        {
            var name = GetType().Name;

            if (name.StartsWith("_"))
                name = name.Substring(1);

            var separatorIndex = name.IndexOf('_');

            Version = Convert.ToInt32(name.Substring(0, separatorIndex));
            Name = name.Substring(separatorIndex + 1);
        }
    }
}
