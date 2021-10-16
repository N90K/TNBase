using Microsoft.EntityFrameworkCore;
using TNBase.Objects;

namespace TNBase.DataStorage
{
    public interface ITNBaseContext
    {
        DbSet<Collector> Collectors { get; set; }
        DbSet<Listener> Listeners { get; set; }
        DbSet<Scan> Scans { get; set; }
        DbSet<WeeklyStats> WeeklyStats { get; set; }
        DbSet<YearStats> YearStats { get; set; }
        DbSet<InOutRecords> InOutRecords { get; set; }

        int SaveChanges();
    }
}