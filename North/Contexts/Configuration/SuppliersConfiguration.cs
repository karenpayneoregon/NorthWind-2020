using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using North.Classes.Base;
using North.Models;

namespace North.Contexts.Configuration
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
    {
        public void Configure(EntityTypeBuilder<Suppliers> builder)
        {
            builder.HasKey(e => e.SupplierID);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.CompanyName).HasMaxLength(15).IsRequired().HasMaxLength(40);
            builder.Property(e => e.ContactName).HasMaxLength(30);
            builder.Property(e => e.ContactTitle).HasMaxLength(30);
            builder.Property(e => e.Fax).HasMaxLength(24);
            builder.Property(e => e.HomePage).HasColumnType("ntext");
            builder.Property(e => e.Phone).HasMaxLength(24);
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);
            builder.Property(e => e.Street).HasMaxLength(60);
            builder.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Suppliers_Countries");
        }
    }
}
