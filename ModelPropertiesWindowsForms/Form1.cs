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
using NorthClassLibrary.Classes.Utility;
using NorthClassLibrary.Contexts;

namespace ModelPropertiesWindowsForms
{
    public partial class Form1 : Form
    {
        private readonly NorthwindContext _northwindContext = new NorthwindContext();
        public Form1()
        {
            InitializeComponent();

            columnHeader1.DisplayIndex = 1;
            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            ModelNamesListBox.SelectedIndexChanged += ModelNamesListBox_SelectedIndexChanged;

            var modelNames = await HelperOperations.ModelNameList();
            ModelNamesListBox.DataSource = modelNames;
        }

        private void ModelNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnDescriptionsListView.Items.Clear();

            var results = _northwindContext.GetEntityProperties(ModelNamesListBox.Text);

            foreach (var sqlColumn in results)
            {
                ColumnDescriptionsListView.Items.Add(new ListViewItem(sqlColumn.ItemArray));
            }

            ColumnDescriptionsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            ColumnDescriptionsListView.FocusedItem = ColumnDescriptionsListView.Items[0];
            ColumnDescriptionsListView.Items[0].Selected = true;
        }
    }
}
