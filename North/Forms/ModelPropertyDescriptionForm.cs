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
using North.Interfaces;
using North.LanguageExtensions;
using North.Models;

namespace North.Forms
{
    public partial class ModelPropertyDescriptionForm : Form
    {
        public ModelPropertyDescriptionForm()
        {
            InitializeComponent();
            columnHeader1.DisplayIndex = 1;
            Shown += ExperimentsForm_Shown;
        }

        private async void ExperimentsForm_Shown(object sender, EventArgs e)
        {
            ModelNamesListBox.SelectedIndexChanged += ModelNamesListBox_SelectedIndexChanged;
            var modelNames = await ContactTestOperations.ModelNameList();
            
            ModelNamesListBox.DataSource = modelNames;
        }

        private void ModelNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnDescriptionsListView.Items.Clear();

            var results = ContactTestOperations.Context.GetEntityProperties(ModelNamesListBox.Text);

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
