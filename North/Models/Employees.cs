
using System;
using System.Collections.Generic;
using North.Interfaces;

namespace North.Models
{
    public partial class Employees : IModelBaseEntity
    {
        public Employees()
        {
            InverseReportsToNavigation = new HashSet<Employees>();
            Orders = new HashSet<Orders>();
        }

        public int Id => EmployeeID;
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? ContactTypeIdentifier { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }

        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        public virtual Countries CountryIdentifierNavigation { get; set; }
        public virtual Employees ReportsToNavigation { get; set; }
        public virtual ICollection<Employees> InverseReportsToNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}