using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using North.Models;

namespace North.Contexts.Configuration
{
    public class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder.HasKey(e => e.ContactId);
            builder.Property(e => e.ContactId).HasComment("Id");
            builder.Property(e => e.FirstName).HasComment("First name");
            builder.Property(e => e.LastName).HasComment("Last name");
            builder.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Contacts_ContactType");
        }
    }
}
