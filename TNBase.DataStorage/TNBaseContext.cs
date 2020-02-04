using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public class TNBaseContext : DbContext, ITNBaseContext
    {
        public TNBaseContext(string connectionString) : base(new SQLiteConnection() { ConnectionString = connectionString }, true)
        { }

        public TNBaseContext(SQLiteConnection connection) : base(connection, true)
        { }

        public DbSet<Scan> Scans { get; set; }
        public DbSet<Listener> Listeners { get; set; }
    }
}
