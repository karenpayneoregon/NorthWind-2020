using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthClassLibrary.Models;

namespace NorthClassLibrary.Contexts.Configuration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(e => e.CategoryID);

            builder.Property(e => e.CategoryID).HasComment("Primary key");

            builder.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15)
                .HasComment("Name");

            builder.Property(e => e.Description).HasColumnType("ntext");

            builder.Property(e => e.Picture)
                .HasColumnType("image")
                .HasComment("Image");
        }
    }
}
