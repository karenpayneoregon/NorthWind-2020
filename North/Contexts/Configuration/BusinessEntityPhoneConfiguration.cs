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
    public class BusinessEntityPhoneConfiguration : IEntityTypeConfiguration<BusinessEntityPhone>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityPhone> builder)
        {
            builder.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
        }
    }
}
