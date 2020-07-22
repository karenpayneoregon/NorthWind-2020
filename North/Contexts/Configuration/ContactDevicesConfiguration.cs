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
    public class ContactDevicesConfiguration : IEntityTypeConfiguration<ContactDevices>
    {
        public void Configure(EntityTypeBuilder<ContactDevices> builder)
        {
            builder.HasOne(d => d.Contact)
                .WithMany(p => p.ContactDevices)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_ContactDevices_Contacts1");

            builder.HasOne(d => d.PhoneTypeIdentifierNavigation)
                .WithMany(p => p.ContactDevices)
                .HasForeignKey(d => d.PhoneTypeIdentifier)
                .HasConstraintName("FK_ContactDevices_PhoneType");
        }
    }
}
