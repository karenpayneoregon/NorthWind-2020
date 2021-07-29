using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using North.Models;
using NorthWindCore.Classes;

namespace NorthWindCore.Contexts.Configuration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(e => e.CategoryID);

            builder.Property<int>(e => e.CategoryID).HasComment("Primary key");

            builder.Property<string>(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property<string>(e => e.Description).HasColumnType("ntext");

            builder.Property<byte[]>(e => e.Picture).HasColumnType("image");
        }
    }
}
