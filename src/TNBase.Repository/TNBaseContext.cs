using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TNBase.DataStorage;
using TNBase.Objects;

#nullable disable

namespace TNBase.Repository
{
    public partial class TNBaseContext : DbContext, ITNBaseContext
    {
        private readonly SqliteConnection connection;

        public TNBaseContext(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
            connection.Open();
        }

        public virtual DbSet<Collector> Collectors { get; set; }
        public virtual DbSet<InOutRecords> InOutRecords { get; set; }
        public virtual DbSet<Listener> Listeners { get; set; }
        public virtual DbSet<Scan> Scans { get; set; }
        public virtual DbSet<WeeklyStats> WeeklyStats { get; set; }
        public virtual DbSet<YearStats> YearStats { get; set; }

        public void UpdateDatabase()
        {
            new DatabaseUpdater<SqlMigration>(connection).Update();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connection);
            }

            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collector>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Key");

                entity.Property(e => e.Number)
                    .HasColumnName("Telephone");
            });

            modelBuilder.Entity<Listener>(entity =>
            {
                entity.ToTable("Listeners");

                entity.HasKey(e => e.Wallet);

                entity.HasOne(e => e.InOutRecords)
                    .WithOne()
                    .HasForeignKey<Listener>(e => e.Wallet)
                    .IsRequired();

                entity.Property(e => e.Addr1).HasColumnType("text");

                entity.Property(e => e.Addr2).HasColumnType("text");

                entity.Property(e => e.BirthdayDay).HasColumnType("int");

                entity.Property(e => e.BirthdayMonth).HasColumnType("int");

                entity.Property(e => e.County).HasColumnType("text");

                entity.Property(e => e.DeletedDate).HasColumnType("date");

                entity.Property(e => e.Forename)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Joined).HasColumnType("date");

                entity.Property(e => e.LastIn).HasColumnType("date");

                entity.Property(e => e.LastOut).HasColumnType("date");

                entity.Property(e => e.Magazine).HasColumnType("bit");

                entity.Property(e => e.MagazineStock)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MemStickPlayer).HasColumnType("bit");

                entity.Property(e => e.Postcode).HasColumnType("text");

                entity.Property(e => e.WarnOfAddressChange).HasColumnType("bit");

                entity.Property(e => e.Status)
                    .HasConversion<string>();

                entity.Property(e => e.StatusInfo).HasColumnType("text");

                entity.Property(e => e.Stock)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("3");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Telephone).HasColumnType("text");

                entity.Property(e => e.Title).HasColumnType("text");

                entity.Property(e => e.Town).HasColumnType("text");
            });

            //modelBuilder.Entity<Listener>()
            //    .Ignore(e => e.Status)
            //    .HasOne(e=>e.InOutRecords)
            //    .WithOne(e=)
            //    .HasForeignKey<Listener>(e => e.Wallet)
            //    .IsRequired();

            modelBuilder.Entity<InOutRecords>(entity =>
            {
                entity.ToTable("Listeners");

                entity.HasKey(e => e.Wallet);

                //entity.HasOne(e => e.Listener)
                //    .WithOne(e => e.InOutRecords)
                //    .HasForeignKey<Listener>(e => e.Wallet)
                //    .IsRequired();

                entity.Property(e => e.In1)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In2)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In3)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In4)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In5)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In6)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In7)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.In8)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out1)
                   .HasColumnType("bigint")
                   .HasDefaultValueSql("0");

                entity.Property(e => e.Out2)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out3)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out4)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out5)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out6)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out7)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Out8)
                    .HasColumnType("bigint")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Scan>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Scans_Id")
                    .IsUnique();

                entity.Property(e => e.Recorded)
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.ScanType)
                    .HasColumnName("Type")
                    .HasConversion<string>();

                entity.Property(e => e.WalletType)
                    .HasConversion<string>();
            });

            //modelBuilder.Entity<Scan>()
            //    .Ignore(e => e.ScanType)
            //    .Ignore(e => e.WalletType);

            modelBuilder.Entity<WeeklyStats>(entity =>
            {
                entity.ToTable("WeekStats");

                entity.HasKey(e => e.WeekNumber);

                entity.Property(e => e.WeekDate)
                    .HasColumnName("Date")
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.PausedCount).HasDefaultValueSql("'0'");

                entity.Property(e => e.ScannedIn).HasDefaultValueSql("'0'");

                entity.Property(e => e.ScannedOut).HasDefaultValueSql("'0'");

                entity.Property(e => e.TotalListeners).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<YearStats>(entity =>
            {
                entity.HasKey(e => e.Year);

                entity.HasIndex(e => e.Year, "IX_YearStats_Year")
                    .IsUnique();

                entity.Property(e => e.Year).ValueGeneratedNever();

                entity.Property(e => e.AverageListeners).HasDefaultValueSql("'0'");

                entity.Property(e => e.AveragePaused).HasDefaultValueSql("'0'");

                entity.Property(e => e.AverageSent).HasDefaultValueSql("'0'");

                entity.Property(e => e.DeletedListeners).HasDefaultValueSql("'0'");

                entity.Property(e => e.DeletedTotal).HasDefaultValueSql("'0'");

                entity.Property(e => e.EndListeners).HasDefaultValueSql("'0'");

                entity.Property(e => e.InactiveTotal).HasDefaultValueSql("'0'");

                entity.Property(e => e.MagazineTotal).HasDefaultValueSql("'0'");

                entity.Property(e => e.MagazinesSent).HasDefaultValueSql("'0'");

                entity.Property(e => e.MemStickPlayerLoanTotal).HasDefaultValueSql("'0'");

                entity.Property(e => e.NewListeners).HasDefaultValueSql("'0'");

                entity.Property(e => e.PausedTotal).HasDefaultValueSql("'0'");

                entity.Property(e => e.PercentSent).HasDefaultValueSql("'0'");

                entity.Property(e => e.SentTotal).HasDefaultValueSql("'0'");

                entity.Property(e => e.StartListeners).HasDefaultValueSql("'0'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Add some logging with log4net here


                // Throw a new DbEntityValidationException with the improved exception message.
                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }
        }
    }
}
