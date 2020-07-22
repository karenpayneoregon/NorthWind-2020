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

            builder.HasOne(d => d.ContactTypeIdentifierNavigation)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeIdentifier)
                .HasConstraintName("FK_Contacts_ContactType");
        }
    }
}
