using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using North.Classes;
using North.Contexts;
using North.Models;


namespace North
{
    public partial class ContactsTestForm : Form
    {
        public ContactsTestForm()
        {
            InitializeComponent();
            CustomersDemoButton.Enabled = false;
            Shown += Form1_Shown;
        }
        /// <summary>
        /// Get all contacts 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Shown(object sender, EventArgs e)
        {

            var contactItemList = ContactTestOperations.GetContactsAsync();
            ContactsListBox.DataSource = await contactItemList;
            CustomersDemoButton.Enabled = true;
            ContactsListBox.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            DisplayCurrentContact();
        }
        /// <summary>
        /// Invoke method to display contact details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCurrentContact();
        }
        /// <summary>
        /// Display current contact details
        /// </summary>
        private void DisplayCurrentContact()
        {
            var currentContactItem = ((ContactItem)ContactsListBox.SelectedItem);

            ContactIdTextBox.Text = $@"{currentContactItem.Id}";
            NameTextBox.Text = currentContactItem.ContactName;
            ConactTypeTextBox.Text = currentContactItem.ContactType;
            OfficePhoneTextBox.Text = currentContactItem.OfficePhone;
            HomePhoneTextBox.Text = currentContactItem.HomePhone;
            CellPhoneNumber.Text = currentContactItem.CellPhone;
        }
        /// <summary>
        /// Example for article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CustomersDemoButton_Click(object sender, EventArgs e)
        {
            var test = await CustomersTestOperations.GetCustomersAsync();
            var test1 = await CustomersTestOperations.GetCustomersWithProjectionAsync();
            Console.WriteLine(@"Place breakpoint here");

        }
    }


}

