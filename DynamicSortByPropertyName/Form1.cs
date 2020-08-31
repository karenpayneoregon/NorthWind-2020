using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicSortByPropertyName.Classes;
using DynamicSortByPropertyName.LanguageExtensions;
using Equin.ApplicationFramework;

namespace DynamicSortByPropertyName
{
    public partial class Form1 : Form
    {
        private BindingListView<CustomerItem> _customerView;
        private readonly BindingSource _bindingSource = new BindingSource();
        private const string _primaryKey = "CustomerIdentifier";
        public Form1()
        {
            InitializeComponent();

            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var colName = "CompanyName";

            _customerView = new BindingListView<CustomerItem>(
                await CustomerOperations.CustomerSort(colName));

            _bindingSource.DataSource = _customerView;
            dataGridView1.DataSource = _bindingSource;

            // ReSharper disable once PossibleNullReferenceException
            dataGridView1.Columns[_primaryKey].Visible = false;

            dataGridView1.ExpandColumns("Name");

            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];

            var properties = typeof(CustomerItem).GetProperties();

            ColumnNameComboBox.DataSource = properties
                .Where(prop => !prop.Name.ContainsIgnoreCase("id"))
                .Select(prop => prop.Name)
                .ToList();

            ColumnNameComboBox.SelectedIndex = ColumnNameComboBox.FindString(colName);
            ColumnNameComboBox.SelectedIndexChanged += ColumnNameComboBox_SelectedIndexChanged;

            foreach (var radioButton in Controls.OfType<RadioButton>())
            {
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
            }

        }
        /// <summary>
        /// Perform sort if current row in DataGridView is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    PerformSort();
                }
            }
        }

        /// <summary>
        /// Perform sort if current row in DataGridView is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSort();
        }
        /// <summary>
        /// Sort by property string and reposition to the current row prior to the sort
        /// </summary>
        private void PerformSort()
        {
            if (dataGridView1.CurrentRow != null)
            {
                var customerView = _customerView[dataGridView1.CurrentRow.Index];
                var currentIdentifier = customerView.Object.CustomerIdentifier;

                _customerView = new BindingListView<CustomerItem>(((List<CustomerItem>) _customerView.DataSource)
                    .SortByPropertyname(
                        ColumnNameComboBox.Text,
                        AscendingRadioButton.Checked ? SortDirection.Ascending : SortDirection.Descending));

                _bindingSource.DataSource = _customerView;
                dataGridView1.DataSource = _bindingSource;

                var position = _bindingSource.Find(_primaryKey, currentIdentifier);

                if (position > -1)
                {
                    _bindingSource.Position = position;
                }
            }
        }
    }
}
