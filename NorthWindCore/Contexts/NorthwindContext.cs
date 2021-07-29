using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using North.Models;
using NorthWindCore.Contexts.Configuration;
using NorthWindCore.Models;

using Customers = NorthWindCore.Models.Customers;
using static System.Configuration.ConfigurationManager;

namespace NorthWindCore.Contexts
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
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

                optionsBuilder.UseSqlServer(connectionString);

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

        /// <summary>
        /// For learning purposes used in ContactsEditTestForm
        /// 
        /// * Shows how to get original and current value for each property
        ///   for each contact.
        /// </summary>
        /// <returns>
        /// first and last name of each contact
        /// </returns>
        /// <remarks>
        /// </remarks>
        public string GetChangedContactsToContactEditForm()
        {
            var contactNamesBuilder = new System.Text.StringBuilder();

            ChangeTracker.DetectChanges();

            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Contacts contact)
                    {
                        contactNamesBuilder.AppendLine($"'{contact.FirstName}' '{contact.LastName}'");
                        Console.WriteLine($@"Primary key: {GetEntityPrimaryKeyValue(entry.Entity)}");
                        foreach (var propertyInfo in entry.Entity.GetType().GetTypeInfo().DeclaredProperties)
                        {
                            if (!propertyInfo.GetGetMethod().IsVirtual)
                            {
                                /*
                                 * Show property name, original and current values
                                 */
                                Console.WriteLine(
                                    $@"Name: {propertyInfo.Name} original " +
                                    $@"'{entry.Property(propertyInfo.Name).OriginalValue}' " +
                                    $@"current '{entry.Property(propertyInfo.Name).CurrentValue}'");
                            }

                        }

                        Console.WriteLine();

                    }

                }
            }

            return contactNamesBuilder.ToString();
        }

        /// <summary>
        /// Obtain a primary key value for an entity
        /// </summary>
        /// <typeparam name="T">Entity type in the current context</typeparam>
        /// <param name="entity">The actual entity</param>
        /// <returns></returns>
        protected virtual int GetEntityPrimaryKeyValue<T>(T entity)
        {
            var itemType = entity.GetType();
            var keyName = Model.FindEntityType(itemType).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            var primaryKeyValue = (int)entity.GetType().GetProperty(keyName)?.GetValue(entity, null);

            if (primaryKeyValue < 0)
            {
                return -1;
            }

            return primaryKeyValue;
        }

    }
}