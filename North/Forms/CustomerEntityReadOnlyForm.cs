using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using North.Classes;

namespace North.Forms
{
    public partial class CustomerEntityReadOnlyForm : Form
    {
        private CustomerEntity _customerEntity;
        public CustomerEntityReadOnlyForm()
        {
            InitializeComponent();
        }
        public CustomerEntityReadOnlyForm(CustomerEntity customerEntity)
        {
            InitializeComponent();

            _customerEntity = customerEntity;

            Shown += CustomerEntityReadOnlyForm_Shown;
        }

        private void CustomerEntityReadOnlyForm_Shown(object sender, EventArgs e)
        {
            CustomerIdentifierTextBox.Text = _customerEntity.CustomerIdentifier.ToString();
            CompanyNameTextBox.Text = _customerEntity.CompanyName;
            ContactIdentifierTextBox.Text = _customerEntity.ContactIdentifier.ToString();
            ContactFullNameTextBox.Text = _customerEntity.ContactName;
            ContactTypeIdentifierTextBox.Text = _customerEntity.ContactTypeIdentifier.ToString();
            ContactTitleTextBox.Text = _customerEntity.ContactTitle;
            StreetTextBox.Text = _customerEntity.Street;
            CityTextBox.Text = _customerEntity.City;
            PostalTextBox.Text = _customerEntity.PostalCode;
            CountryIdentifier.Text = _customerEntity.CountryIdentifier.ToString();
            CountryNameTextBox.Text = _customerEntity.CountryName;
        }

        private async void ViewContactButton_Click(object sender, EventArgs e)
        {
            var contactForm = new ContactSingleViewForm(
                await ContactTestOperations.GetContactForViewAsync(_customerEntity.ContactIdentifier));

            try
            {
                contactForm.ShowDialog();
            }
            finally
            {
                contactForm.Dispose();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
