using System.Collections.Generic;
using North.Interfaces;

namespace NorthEntityLibrary.Models
{
    public partial class Suppliers: IModelBaseEntity
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        public int Id => SupplierID;
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual Countries CountryIdentifierNavigation { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}