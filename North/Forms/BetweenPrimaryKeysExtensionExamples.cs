using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCoreExtensions;
using Microsoft.EntityFrameworkCore;
using North.Contexts;
using North.Models;

namespace North.Forms
{
    public partial class BetweenPrimaryKeysExtensionExamples : Form
    {
        public BetweenPrimaryKeysExtensionExamples()
        {
            InitializeComponent();

            CompanyDataGridView.AutoGenerateColumns = false;

            Shown += BetweenPrimaryKeysExtensionExamples_Shown;
        }

        private void BetweenPrimaryKeysExtensionExamples_Shown(object sender, EventArgs e)
        {
            using (var context = new NorthwindContext())
            {
                var countries = context.Countries.Select(country => country).ToList();

                countries.Insert(0, new Countries() { CountryIdentifier = -1, Name = "Select" });
                CountryComboBox.DataSource = countries;
                CountryComboBox.SelectedIndex = CountryComboBox.FindString("UK");
            }
        }

        private void Execute1Button_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(StartTextBox.Text, out var startValue) || !int.TryParse(EndTextBox.Text, out var endValue)) return;

            using (var context = new NorthwindContext())
            {
                var customerList = context.
                    Customers.Include(country => country.CountryIdentifierNavigation)
                    .Between(cust => cust.CustomerIdentifier, startValue, endValue)
                    .Select(cust => new CustomerCountry()
                    {
                        Name = cust.CompanyName,
                        Country = cust.CountryIdentifierNavigation.Name
                    })
                    .Where(item => item.Country == CountryComboBox.Text)
                    .ToList();

                CompanyDataGridView.DataSource = customerList;

            }
        }

        private void Execute2Button_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(StartTextBox.Text, out var startValue) || !int.TryParse(EndTextBox.Text, out var endValue)) return;

            using (var context = new NorthwindContext())
            {
                var customerList = context.
                    Customers.Include(country => country.CountryIdentifierNavigation)
                    .Between(cust => cust.CustomerIdentifier, startValue, endValue)
                    .Select(cust => new CustomerCountry()
                    {
                        Name = cust.CompanyName,
                        Country = cust.CountryIdentifierNavigation.Name
                    })
                    .ToList();

                if (CountryComboBox.Text != "Select")
                {
                    customerList = customerList.Where(cust => cust.Country == CountryComboBox.Text).ToList();
                }

                CompanyDataGridView.DataSource = customerList;

            }
        }
    }

    public class CustomerCountry
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
