using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Contexts.Configuration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.HasKey(e => e.ContactTypeIdentifier);
        }
    }
}
