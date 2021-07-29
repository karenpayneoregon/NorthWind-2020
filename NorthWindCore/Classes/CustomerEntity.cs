using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using North.Models;
using NorthWindCore.Classes.Base;
using NorthWindCore.Models;

namespace NorthWindCore.Classes
{
    public class CustomerEntity : BaseEntity, INotifyPropertyChanged
    {
        private int _customerIdentifier;
        private string _companyName;
        private int? _contactIdentifier;
        private string _firstName;
        private string _lastName;
        private int _contactTypeIdentifier;
        private string _contactTitle;
        private string _address;
        private string _city;
        private string _postalCode;
        private int? _countryIdentifier;
        private string _countyName;
        private Contacts _contacts;

        public int CustomerIdentifier
        {
            get => _customerIdentifier;
            set
            {
                _customerIdentifier = value;
                OnPropertyChanged();
            }
        }
        [Required]
        public string CompanyName
        {
            get => _companyName;
            set
            {
                _companyName = value;
                OnPropertyChanged();
            }
        }

        public int? ContactIdentifier
        {
            get => _contactIdentifier;
            set
            {
                _contactIdentifier = value;
                OnPropertyChanged();
            }
        }

        public Contacts Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string ContactName => $"{FirstName} {LastName}";

        public int? ContactTypeIdentifier
        {
            get => _contactTypeIdentifier;
            set
            {
                _contactTypeIdentifier = (int) value;
                OnPropertyChanged();
            }
        }

        public string ContactTitle
        {
            get => _contactTitle;
            set
            {
                _contactTitle = value;
                OnPropertyChanged();
            }
        }

        public string Street
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get => _postalCode;
            set
            {
                _postalCode = value;
                OnPropertyChanged();
            }
        }

        public int? CountryIdentifier
        {
            get => _countryIdentifier;
            set
            {
                _countryIdentifier = value;
                OnPropertyChanged();
            }
        }

        public string CountryName
        {
            get => _countyName;
            set
            {
                _countyName = value;
                OnPropertyChanged();
            }
        }

        public int? ContactId { get; set; }
        public Countries CountryNavigation { get; set; }

        public override string ToString()
        {
            return CustomerIdentifier.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      
    }
}
