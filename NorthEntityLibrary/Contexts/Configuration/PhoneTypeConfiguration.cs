using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Contexts.Configuration
{
    public class PhoneTypeConfiguration : IEntityTypeConfiguration<PhoneType>
    {
        public void Configure(EntityTypeBuilder<PhoneType> builder)
        {
            builder.HasKey(e => e.PhoneTypeIdenitfier);
        }
    }
}
