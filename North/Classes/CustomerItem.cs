namespace North.Classes
{
    public class CustomerItem
    {
        public int CustomerIdentifier { get; set; }
        public string CompanyName { get; set; }
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string Phone { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactName => $"{FirstName} {LastName}";
        public string ContactTitle { get; set; }
        public string OfficePhoneNumber { get; set; }
        public int PhoneTypeIdentifier { get; set; }
        public override string ToString() => CompanyName;

    }
}
