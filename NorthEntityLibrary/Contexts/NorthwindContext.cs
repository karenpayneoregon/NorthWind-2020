using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Contexts.Configuration;
using NorthEntityLibrary.Models;
using static System.Configuration.ConfigurationManager;
using static Microsoft.Extensions.Logging.LoggerFactory;

namespace NorthEntityLibrary.Contexts 
{
    public partial class NorthwindContext : DbContext
    {

        
        /// <summary>
        /// Set Console logging on or off
        /// </summary>
        public bool LoggingDiagnostics { get; set; }

        /// <summary>
        /// Configure logging for app
        /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging?tabs=v3
        /// https://github.com/dotnet/EntityFramework.Docs/blob/master/entity-framework/core/miscellaneous/logging.md
        /// </summary>
        public static readonly ILoggerFactory ConsoleLoggerFactory = Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                .AddConsole();


        });
        /// <summary>
        /// Determine if logging will be used
        /// </summary>
        /// <param name="log"></param>
        public NorthwindContext(bool log)
        {
            LoggingDiagnostics = log;
        }


        public NorthwindContext()
        {
            if (AppSettings["UsingLogging"] == null) return;

            if (bool.TryParse(AppSettings["UsingLogging"], out var value))
            {
                LoggingDiagnostics = value;
            }
        }

        public void DisplayTrackedEntities(ChangeTracker changeTracker)
        {
            Console.WriteLine("");


            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Status: {0}", entry.State);
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }


        public virtual DbSet<BusinessEntityPhone> BusinessEntityPhone { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ContactDevices> ContactDevices { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString =
                    $"Data Source={AppSettings["DatabaseServer"]};" +
                    $"Initial Catalog={AppSettings["NorthWinCatalog"]};" +
                    "Integrated Security=True";

                //optionsBuilder.EnableSensitiveDataLogging()
                //    .UseSqlServer(connectionString)
                //    .AddInterceptors(new HintCommandInterceptor());

                if (LoggingDiagnostics)
                {
                    optionsBuilder
                        .UseSqlServer(connectionString)
                        .UseLoggerFactory(ConsoleLoggerFactory)
                        .EnableSensitiveDataLogging()
                        .AddInterceptors(new ReadCommandInterceptor(), new TransactionInterceptor());
                }
                else
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BusinessEntityPhoneConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new ContactDevicesConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactsConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new ShippersConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

    public class TransactionInterceptor : DbTransactionInterceptor
    {
        public override void TransactionCommitted(DbTransaction transaction, TransactionEndEventData eventData)
        {
            base.TransactionCommitted(transaction, eventData);
        }
    }

    public class ReadCommandInterceptor : DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            return result;
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            return base.ReaderExecuted(command, eventData, result);
        }
        
    }

}