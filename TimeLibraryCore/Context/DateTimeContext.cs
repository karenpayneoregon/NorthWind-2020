
using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using TimeLibraryCore.Classes;
using TimeLibraryCore.Models;

namespace TimeLibraryCore.Context
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

                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
                var applicationSettings = JsonConvert.DeserializeObject<ApplicationSettings>(File.ReadAllText(fileName));

                optionsBuilder.UseSqlServer(applicationSettings
                    .Connections
                    .FirstOrDefault(x => x.Name == applicationSettings.DefaultConnection).Value);
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
