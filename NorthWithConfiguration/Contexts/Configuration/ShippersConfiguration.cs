using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWithConfiguration.Models;


namespace NorthWithConfiguration.Contexts.Configuration
{
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.HasKey(e => e.ShipperId);
            builder.Property(e => e.ShipperId).ValueGeneratedNever();
            builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}
