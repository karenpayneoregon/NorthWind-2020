using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Contexts.Configuration
{
    public class BusinessEntityPhoneConfiguration : IEntityTypeConfiguration<BusinessEntityPhone>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityPhone> builder)
        {
            builder.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        }
    }
}
