using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWithConfiguration.Models;


namespace NorthWithConfiguration.Contexts.Configuration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.HasKey(e => e.ContactTypeIdentifier);
        }
    }
}
