using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataValidationWindowsForms.Classes;
using LanguageExtensions;
using North.Classes;
using North.Classes.Components;
using North.Classes.Validators;
using North.LanguageExtensions;
using North.Models;
using static North.Classes.Helpers.Dialogs;
using static North.LanguageExtensions.CueBannerTextCode;

namespace North.Forms
{
    public partial class CustomersDataGridViewTestForm : Form
    {
        private SortableBindingList<CustomerEntity> _customerView;
        private SortableBindingList<CustomerEntity> _customerViewFilter;
        private BindingSource _customerBindingSource = new BindingSource();
        private bool _filtered = false;

        public CustomersDataGridViewTestForm()
        {
            InitializeComponent();

            CustomersDataGridView.AutoGenerateColumns = false;
            toolTip1.SetToolTip(CurrentCustomerDetails,"View customer information\nUsing multiple dialogs.");

            Shown += CustomersDataGridViewTestForm_Shown;
            CompanyNameStartsWithTextBox.TextChanged += CompanyNameStartsWithTextBox_TextChanged;
            SetCueText(CompanyNameStartsWithTextBox," company starts with");
        }

        private void CompanyNameStartsWithTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CompanyNameStartsWithTextBox.Text))
            {
                _customerBindingSource.DataSource = _customerView;
                _filtered = false;
            }
            else
            {
                try
                {
                    var filter = CompanyNameStartsWithTextBox.Text.Trim();
                    _customerViewFilter = new SortableBindingList<CustomerEntity>(_customerView.Where(customerEntity =>
                        customerEntity.CompanyName.ToLower().StartsWith(filter)).ToList());

                    _customerBindingSource.DataSource = _customerViewFilter;

                    _filtered = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async void CustomersDataGridViewTestForm_Shown(object sender, EventArgs e)
        {
            var customerEntities = await CustomersTestOperations.AllCustomersForDataGridViewAsync();

            _customerView = new SortableBindingList<CustomerEntity>(customerEntities);
            _customerBindingSource.DataSource = _customerView;

            CountryColumn.DisplayMember = "Name";
            CountryColumn.ValueMember = "CountryIdentifier";
            CountryColumn.DataPropertyName = "CountryIdentifier";
            CountryColumn.DataSource = CustomersTestOperations.CountryList();
            CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;


            ContactTitleColumn.DisplayMember = "ContactTitle";
            ContactTitleColumn.ValueMember = "ContactTypeIdentifier";
            ContactTitleColumn.DataPropertyName = "ContactTypeIdentifier";
            ContactTitleColumn.DataSource = CustomersTestOperations.ContactTypeList();
            ContactTitleColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            CustomersDataGridView.DataSource = _customerBindingSource;
            CustomersDataGridView.ExpandColumns();

            CustomersBindingNavigator.BindingSource = _customerBindingSource;
            CurrentCustomerDetails.Enabled = true;
            SaveChangesButton.Enabled = true;
            CompanyNameStartsWithTextBox.Enabled = true;

            CustomersDataGridView.CellValueChanged += CustomersDataGridView_CellValueChanged;
            CustomersDataGridView.UserDeletingRow += CustomersDataGridView_UserDeletingRow;
            _customerView.ListChanged += _customerView_ListChanged;

        }

        /// <summary>
        /// Performs simple validation and setting property values so on any changes
        /// they are updated immediately.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _customerView_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor != null)
            {

                //
                // Get current customer in current DataGridView row
                //
                CustomerEntity currentCustomer = _customerView.CurrentCustomer(_customerBindingSource.Position);

                //
                // Assert if there are changes to the current row in the DataGridView
                //
                if (e.ListChangedType == ListChangedType.ItemChanged)
                {

                    //
                    // Get data residing in the database table
                    //
                    Customers customerItem = CustomersTestOperations
                        .Context
                        .Customers
                        .FirstOrDefault((customer) => customer.CustomerIdentifier == currentCustomer.CustomerIdentifier);

                    if (customerItem != null)
                    {

                        /*
                         * Did contact first or last name change?
                         * If so we need to update the contact.
                         */
                        if (e.PropertyDescriptor.DisplayName == "FirstName" || e.PropertyDescriptor.DisplayName == "LastName")
                        {
                            customerItem.Contact.FirstName = currentCustomer.FirstName;
                            customerItem.Contact.LastName = currentCustomer.LastName;
                        }
                        
                        var customerEntry = CustomersTestOperations.Context.Entry(customerItem);
                        customerEntry.CurrentValues.SetValues(currentCustomer);

                        //
                        // Setup validation on current row data
                        //
                        var validation = ValidationHelper.ValidateEntity(customerItem);
                        

                        //
                        // If there are validation error present them to the user
                        //
                        if (validation.HasError)
                        {

                            var errorItems = string.Join(Environment.NewLine, 
                                validation.Errors.Select((containerItem) => containerItem.ErrorMessage).ToArray());

                            MessageBox.Show(errorItems + Environment.NewLine + @"Customer has been reset!!!", @"Corrections needed");

                            //
                            // Read current values from database
                            //
                            Customers originalCustomer = CustomersTestOperations.CustomerFirstOrDefault(customerItem.CustomerIdentifier);

                            //
                            // reset current item both in Customer object and CustomerEntity object
                            // (there are other ways to deal with this but are dependent on business logic)
                            //
                            customerEntry.CurrentValues.SetValues(originalCustomer);
                            _customerView[_customerBindingSource.Position] = originalCustomer;

                        }
                        else
                        {
                            CustomersTestOperations.Context.SaveChanges();
                        }
                    }
                }

            }

        }
        /// <summary>
        /// Handle properties in DataGridViewComboBox columns
        /// Note in each case the name value, CountryName and ContactTitle
        /// need no be set, they are set here for use in getting the current
        /// customer to view in a button click event only.
        ///
        /// Also we could have a BindingList for each column which means no
        /// touching DataGridView cells.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomersDataGridView.DataSource == null) return;

            CustomerEntity customerEntity = _customerView.CurrentCustomer(_customerBindingSource.Position);
            Customers customer = CustomersTestOperations.Context.Customers.FirstOrDefault(c => c.CustomerIdentifier == customerEntity.CustomerIdentifier);

            if (CustomersDataGridView.Columns[e.ColumnIndex].Name == "CountryColumn")
            {
                customerEntity.CountryIdentifier = Convert.ToInt32(CustomersDataGridView.Rows[e.RowIndex].Cells["CountryColumn"].Value);
                customer.CountryIdentifier = customerEntity.CountryIdentifier;
                customerEntity.CountryName = CustomersDataGridView.Rows[e.RowIndex].Cells["CountryColumn"].FormattedValue?.ToString();
            }

            if (CustomersDataGridView.Columns[e.ColumnIndex].Name == "ContactTitleColumn")
            {
                customerEntity.ContactTypeIdentifier = Convert.ToInt32(CustomersDataGridView.Rows[e.RowIndex].Cells["ContactTitleColumn"].Value);
                customer.ContactTypeIdentifier = customerEntity.ContactTypeIdentifier;
                customerEntity.ContactTitle = CustomersDataGridView.Rows[e.RowIndex].Cells["ContactTitleColumn"].FormattedValue?.ToString();
            }

            Console.WriteLine(CustomersTestOperations.Context.SaveChanges());
        }

        private void CurrentCustomerDetails_Click(object sender, EventArgs e)
        {
            
            CustomerEntity customerEntity;

            try
            {
                customerEntity = _filtered ? _customerViewFilter.CurrentCustomer(_customerBindingSource.Position) : _customerView.CurrentCustomer(_customerBindingSource.Position);

                var displayCustomerForm = new CustomerEntityReadOnlyForm(customerEntity);

                try
                {
                    displayCustomerForm.ShowDialog();
                }
                finally
                {
                    displayCustomerForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Note not rigged up to save when filtered as there are two BindingList while there
        /// is a solution it's a matter of juggling between the two BindingList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CustomersTestOperations.Context.SaveChanges());
        }
        /// <summary>
        /// In this case removal of a customer means we need cascading rule to
        /// orders and order details. A better idea is to perform a soft delete
        /// which keeps the customer history but also means outside of the app
        /// all queries will need to filter out inactive customers. In code
        /// Entity Framework core can perform a globe filter on active/inactive
        /// customers.
        ///
        /// See the following Microsoft TechNet article for implementing
        /// a globe filter with Entity Framework Core.
        /// 
        /// https://social.technet.microsoft.com/wiki/contents/articles/53834.entity-framework-core-3-x-global-query-filters-c.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCustomerBindingNavigatorButton_Click(object sender, EventArgs e)
        {
            if (_customerView.Count <= 0) return;

            CustomerEntity customer = _customerView.CurrentCustomer(_customerBindingSource.Position);

            if (Question($"Remove {customer.CompanyName}"))
            {
                MessageBox.Show(@"Removal goes here");
            }
            else
            {
                MessageBox.Show(@"Removal aborted");
            }

        }
        private void CustomersDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_customerView.Count <= 0) return;

            CustomerEntity customer = _customerView.CurrentCustomer(_customerBindingSource.Position);

            if (Question($"Remove {customer.CompanyName}"))
            {
                MessageBox.Show(@"Removal goes here");
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show(@"Removal aborted");
            }
        }
    }
}
