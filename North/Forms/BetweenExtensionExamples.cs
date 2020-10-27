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
using North.Classes;
using North.Contexts;
using North.LanguageExtensions;

namespace North.Forms
{
    public partial class BetweenExtensionExamples : Form
    {
        public BetweenExtensionExamples()
        {
            InitializeComponent();
            Shown += BetweenExtensionExamples_Shown;

            CustomerNamesCheckedListBox.ItemCheck += CheckedListBox1_ItemCheck;
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && CustomerNamesCheckedListBox.CheckedItems.Count >= 2)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }
        /// <summary>
        /// Only permit two selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BetweenExtensionExamples_Shown(object sender, EventArgs e)
        {
            var customerNames = await CustomersTestOperations.CustomerNames();
            customerNames.ForEach(customerName => CustomerNamesCheckedListBox.Items.Add(customerName));

            ExecuteButton.Enabled = true;
        }
        /// <summary>
        /// perform between on customer name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (CustomerNamesCheckedListBox.CheckedItems.Count == 2)
            {
                var customerNamesList = CustomerNamesCheckedListBox.CheckedItems.Cast<string>().ToList();

                using (var context = new NorthwindContext())
                {
                    var customerList = context
                        .Customers
                        .Between(customer => customer.CompanyName, 
                            customerNamesList[0], 
                            customerNamesList[1])
                        .ToList();

                    ResultsDataGridView.Rows.Clear();

                    foreach (var customer in customerList)
                    {
                        ResultsDataGridView.Rows.Add(customer.CustomerIdentifier, customer.CompanyName);
                    }

                }
            }
            else
            {
                MessageBox.Show("Requires two company names");
            }
        }
    }
}
