using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCore.Models;

namespace NorthWindCore.Contexts.Configuration
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(e => e.EmployeeID);

            builder.Property(e => e.EmployeeID).ValueGeneratedNever();

            builder.Property(e => e.Address).HasMaxLength(60).HasComment("Street"); 

            builder.Property(e => e.BirthDate).HasColumnType("datetime");

            builder.Property(e => e.City).HasMaxLength(15);

            builder.Property(e => e.Extension).HasMaxLength(4);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.HireDate).HasColumnType("datetime");

            builder.Property(e => e.HomePhone).HasMaxLength(24);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.PostalCode).HasMaxLength(10);

            builder.Property(e => e.Region).HasMaxLength(15);

            builder.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

            builder.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Employees_ContactType");

            builder.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Employees_Countries");

            builder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employees_Employees");
        }
    }
}
