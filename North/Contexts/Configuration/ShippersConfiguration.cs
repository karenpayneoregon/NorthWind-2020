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
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.HasKey(e => e.ShipperID);
            builder.Property(e => e.ShipperID).ValueGeneratedNever();
            builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}
