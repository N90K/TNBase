using Microsoft.EntityFrameworkCore;
using TNBase.DataStorage;
using TNBase.Objects;

#nullable disable

namespace TNBase.Repository
{
    public class TNBaseContext : DbContext, ITNBaseContext
    {
        private readonly TNBaseContextOptions options;

        public TNBaseContext(string connectionString)
        {
            this.options = new TNBaseContextOptions { ConnectionString = connectionString };
        }

        public TNBaseContext(TNBaseContextOptions options)
        {
            this.options = options;
        }

        public TNBaseContext(DbContextOptions<TNBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Listener> Listeners { get; set; }
        public virtual DbSet<Scan> Scans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=C:\\Users\\Audrius\\Documents\\Code\\TNBase\\Listeners.s3db");
                optionsBuilder.UseSqlite(options.ConnectionString);
            }
        }
    }
}
