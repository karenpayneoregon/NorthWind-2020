﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using NorthWithFoldersAnnotations.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWithFoldersAnnotations.Models;

namespace NorthWithFoldersAnnotations.Contexts
{
    public partial class Northwind2020Context : DbContext
    {
        public Northwind2020Context()
        {
        }

        public Northwind2020Context(DbContextOptions<Northwind2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessEntityPhone> BusinessEntityPhones { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactDevice> ContactDevices { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessEntityPhone>(entity =>
            {
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasComment("Primary key");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ContactTypeIdentifier)
                    .HasConstraintName("FK_Contacts_ContactType");
            });

            modelBuilder.Entity<ContactDevice>(entity =>
            {
                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.ContactDevices)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_ContactDevices_Contacts1");

                entity.HasOne(d => d.PhoneTypeIdentifierNavigation)
                    .WithMany(p => p.ContactDevices)
                    .HasForeignKey(d => d.PhoneTypeIdentifier)
                    .HasConstraintName("FK_ContactDevices_PhoneType");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerIdentifier)
                    .HasName("PK_Customers_1");

                entity.Property(e => e.CustomerIdentifier).HasComment("Id");

                entity.Property(e => e.City).HasComment("City");

                entity.Property(e => e.CompanyName).HasComment("Company");

                entity.Property(e => e.ContactId).HasComment("ContactId");

                entity.Property(e => e.ContactTypeIdentifier).HasComment("ContactTypeIdentifier");

                entity.Property(e => e.CountryIdentifier).HasComment("CountryIdentifier");

                entity.Property(e => e.Fax).HasComment("Fax");

                entity.Property(e => e.ModifiedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Modified Date");

                entity.Property(e => e.Phone).HasComment("Phone");

                entity.Property(e => e.PostalCode).HasComment("Postal Code");

                entity.Property(e => e.Region).HasComment("Region");

                entity.Property(e => e.Street).HasComment("Street");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Customers_Contacts");

                entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactTypeIdentifier)
                    .HasConstraintName("FK_Customers_ContactType");

                entity.HasOne(d => d.CountryIdentifierNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryIdentifier)
                    .HasConstraintName("FK_Customers_Countries");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.ContactTypeIdentifierNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ContactTypeIdentifier)
                    .HasConstraintName("FK_Employees_ContactType");

                entity.HasOne(d => d.CountryIdentifierNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CountryIdentifier)
                    .HasConstraintName("FK_Employees_Countries");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.CustomerIdentifierNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerIdentifier)
                    .HasConstraintName("FK_Orders_Customers2");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.ShipperId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasOne(d => d.CountryIdentifierNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CountryIdentifier)
                    .HasConstraintName("FK_Suppliers_Countries");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}