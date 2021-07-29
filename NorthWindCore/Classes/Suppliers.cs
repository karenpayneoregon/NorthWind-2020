namespace NorthWindCore.Models
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
