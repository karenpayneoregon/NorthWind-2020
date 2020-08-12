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
    public partial class ModelPropertyDescriptionForm : Form
    {
        public ModelPropertyDescriptionForm()
        {
            InitializeComponent();
            Shown += ExperimentsForm_Shown;
        }

        private void ExperimentsForm_Shown(object sender, EventArgs e)
        {
            ModelNamesListBox.SelectedIndexChanged += ModelNamesListBox_SelectedIndexChanged;
            ModelNamesListBox.DataSource = ContactTestOperations.ModelNameList();
        }

        private void ModelNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnDescriptionsListView.Items.Clear();
            var results = ContactTestOperations.IPropertyGetColumnDescriptions(ModelNamesListBox.Text);
            foreach (var sqlColumn in results)
            {
                ColumnDescriptionsListView.Items.Add(new ListViewItem(sqlColumn.ItemArray));
            }

            ColumnDescriptionsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            ColumnDescriptionsListView.FocusedItem = ColumnDescriptionsListView.Items[0];
            ColumnDescriptionsListView.Items[0].Selected = true;

        }

        private void IPropertyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
