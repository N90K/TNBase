using System.Data.Entity;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public interface ITNBaseContext
    {
        DbSet<Listener> Listeners { get; set; }
        DbSet<Scan> Scans { get; set; }

        int SaveChanges();
    }
}