using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using North.Interfaces;
using NorthClassLibrary.Models;

namespace NorthEntityLibrary.Models
{
    public partial class Countries : INotifyPropertyChanged, IModelBaseEntity
    {
        private string _name;
        private int _countryIdentifier;

        public Countries()
        {
            Customers = new HashSet<Customers>();
            Employees = new HashSet<Employees>();
            Suppliers = new HashSet<Suppliers>();
        }

        public int Id => CountryIdentifier;

        public int CountryIdentifier    
        {
            get => _countryIdentifier;
            set
            {
                _countryIdentifier = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Suppliers> Suppliers { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}