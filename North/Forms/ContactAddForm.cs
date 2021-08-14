using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using North.Contexts;
using North.Models;

namespace North.Forms
{
    public partial class ContactAddForm : Form
    {

        private BindingList<Contacts> _bindingList;
        private readonly BindingSource _bindingSource = new BindingSource();

        public ContactAddForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            Shown += OnShown;
        }

        public static async Task<List<Contacts>> LoadContacts()
        {
            return await Task.Run(async () =>
            {
                using (var context = new NorthwindContext())
                {
                    return await context.Contacts.ToListAsync();

                }
            });

        }
        private async void OnShown(object sender, EventArgs e)
        {
            _bindingList = new BindingList<Contacts>(await LoadContacts());
            _bindingSource.DataSource = _bindingList;
            dataGridView1.DataSource = _bindingSource;

            _bindingSource.MoveLast();

            button1.Enabled = true;
            CurrentContactButton.Enabled = true;
            
        }

        private void AddNewContactButton_Click(object sender, EventArgs e)
        {
            // hard coded contact
            var newContact = new Contacts()
            {
                FirstName = "Karen",
                LastName = "Payne",
                ContactTypeIdentifier = 1
            };

            // add to list and display in DataGridView
            _bindingList.Add(newContact);

            // save changes
            using (var context = new NorthwindContext())
            {
                context.Add(newContact).State = EntityState.Added;
                context.SaveChanges();
            }

            // See new primary key
            MessageBox.Show("Id " + newContact.ContactId.ToString());
        }

        private void CurrentContactButton_Click(object sender, EventArgs e)
        {
            Contacts current = _bindingList[_bindingSource.Position];
            MessageBox.Show($"{current.ContactId}, {current.FirstName}, {current.LastName}");
        }
    }
}
