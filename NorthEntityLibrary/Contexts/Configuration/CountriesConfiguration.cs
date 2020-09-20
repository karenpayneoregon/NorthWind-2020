using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthClassLibrary.Models;
using NorthEntityLibrary.Models;

namespace NorthEntityLibrary.Contexts.Configuration
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
            builder.HasKey(e => e.CountryIdentifier);
        }
    }
}
