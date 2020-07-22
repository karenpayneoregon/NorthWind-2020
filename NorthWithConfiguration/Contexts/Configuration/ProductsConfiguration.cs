using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWithConfiguration.Models;


namespace NorthWithConfiguration.Contexts.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductName).IsRequired().HasMaxLength(40);
            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            builder.Property(e => e.UnitPrice).HasColumnType("money");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Suppliers");

        }
    }
}
