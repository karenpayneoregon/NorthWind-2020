using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using North.Models;

namespace North.Contexts.Configuration
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(e => e.CustomerIdentifier)
                .HasName("PK_Customers_1");

            builder.Property(e => e.CustomerIdentifier).HasComment("Id");

            builder.Property(e => e.City)
                .HasMaxLength(15)
                .HasComment("City");

            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Company");

            builder.Property(e => e.ContactId).HasComment("ContactId");

            builder.Property(e => e.ContactTypeIdentifier).HasComment("ContactTypeIdentifier");

            builder.Property(e => e.CountryIdentifier).HasComment("CountryIdentifier");

            builder.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasComment("Fax");

            builder.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Modified Date");

            builder.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasComment("Phone");

            builder.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasComment("Postal Code");

            builder.Property(e => e.Region)
                .HasMaxLength(15)
                .HasComment("Region");

            builder.Property(e => e.Street)
                .HasMaxLength(60)
                .HasComment("Street");

            builder.HasOne(d => d.Contact)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Customers_Contacts");

            builder.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Customers_ContactType");

            builder.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Customers_Countries");
        }
    }
}
