using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWithConfiguration.Models;


namespace NorthWithConfiguration.Contexts.Configuration
{
    public class PhoneTypeConfiguration : IEntityTypeConfiguration<PhoneType>
    {
        public void Configure(EntityTypeBuilder<PhoneType> builder)
        {
            builder.HasKey(e => e.PhoneTypeIdenitfier);
        }
    }
}
