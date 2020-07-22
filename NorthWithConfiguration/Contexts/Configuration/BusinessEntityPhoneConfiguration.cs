using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWithConfiguration.Models;

namespace NorthWithConfiguration.Contexts.Configuration
{
    public class BusinessEntityPhoneConfiguration : IEntityTypeConfiguration<BusinessEntityPhone>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityPhone> builder)
        {
            builder.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        }
    }
}
