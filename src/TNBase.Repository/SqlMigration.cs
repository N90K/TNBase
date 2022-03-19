using Microsoft.Data.Sqlite;
using NLog;
using System;

namespace TNBase.Repository
{
    public abstract class SqlMigration : ISqlMigration
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();
        protected readonly SqliteConnection connection;

        public SqlMigration(SqliteConnection connection)
        {
            this.connection = connection;
            SetVersionAndName();
        }

        public int Version { get; private set; }

        public string Name { get; private set; }

        protected void Sql(string query)
        {
            log.Debug("Executing query: " + query);
            using var command = connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
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
