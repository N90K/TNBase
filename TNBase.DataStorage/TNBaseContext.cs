using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public class TNBaseContextOld : DbContext, ITNBaseContext
    {
        //public TNBaseContextOld(string connectionString) : base(new SQLiteConnection() { ConnectionString = connectionString }, true)
        //{ }

        //public TNBaseContextOld(SQLiteConnection connection) : base(connection, true)
        //{ }

        public DbSet<Scan> Scans { get; set; }
        public DbSet<Listener> Listeners { get; set; }
    }
}