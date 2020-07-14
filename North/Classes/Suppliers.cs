using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North.Models
{
    public partial class Suppliers
    {
        public string[] ItemArray => new[]
        {
            CompanyName,
            ContactTitle,
            ContactName,
            Street,
            City,
            PostalCode,
            CountryIdentifierNavigation.Name,
            Phone,
            Fax
        };
    }
}
