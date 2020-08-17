
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeLibrary.Models;
using static System.Configuration.ConfigurationManager;

namespace TimeLibrary.Contexts
{
    public partial class DateTimeContext : DbContext
    {
        public DateTimeContext()
        {
        }

        public DateTimeContext(DbContextOptions<DateTimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<TimeTable> TimeTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString =
                    $"Data Source={AppSettings["DatabaseServer"]};" +
                    $"Initial Catalog={AppSettings["Catalog"]};" +
                    "Integrated Security=True";

                optionsBuilder.UseSqlServer(connectionString,
                    sqlOptions =>
                    {
                        // https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventsConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
