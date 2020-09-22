using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthEntityLibrary.Classes
{
    public class DuplicateItem
    {
        public DuplicateItem(int identifier, string companyName, int? contactId, string contactName, string contactTitle, string address, string city, string postalCode, int? countryIdentifier)
        {
            Identifier = identifier;
            CompanyName = companyName;
            ContactId = contactId;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            PostalCode = postalCode;
            CountryIdentifier = countryIdentifier;
        }

        public int Counter { get; set; }
        public int Identifier { get; set; }
        public string CompanyName { get; set; }
        public int? ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
    }
}
