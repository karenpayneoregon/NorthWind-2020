using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using North.Interfaces;

namespace NorthClassLibrary.Models
{
    public partial class Customers : INotifyPropertyChanged, IModelBaseEntity
    {
        private int? _countryIdentifier;

        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id => CustomerIdentifier;
        /// <summary>
        /// Id
        /// </summary>
        public int CustomerIdentifier { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// ContactId
        /// </summary>
        public int? ContactId { get; set; }
        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// CountryIdentifier
        /// </summary>
        public int? CountryIdentifier
        {
            get => _countryIdentifier;
            set
            {
                _countryIdentifier = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// ContactTypeIdentifier
        /// </summary>
        public int? ContactTypeIdentifier { get; set; }
        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        public virtual Countries CountryIdentifierNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}