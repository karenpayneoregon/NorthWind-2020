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
using NorthClassLibrary.Models;

namespace ModelPropertiesWindowsForms
{
    public partial class Form1 : Form
    {
        private readonly NorthwindContext _northWindContext = new NorthwindContext();
        public Form1()
        {
            InitializeComponent();

            GetCommentsButton.Enabled = false;
            columnHeader1.DisplayIndex = 1;
            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            
            ModelNamesListBox.SelectedIndexChanged += ModelNamesListBox_SelectedIndexChanged;

            var modelNames = await HelperOperations.ModelNameList();
            ModelNamesListBox.DataSource = modelNames;
            GetCommentsButton.Enabled = true;
        }

        private void ModelNamesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColumnDescriptionsListView.Items.Clear();

            var results = _northWindContext.GetEntityProperties(ModelNamesListBox.Text);

            foreach (var sqlColumn in results)
            {
                ColumnDescriptionsListView.Items.Add(new ListViewItem(sqlColumn.ItemArray));
            }

            ColumnDescriptionsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            ColumnDescriptionsListView.FocusedItem = ColumnDescriptionsListView.Items[0];
            ColumnDescriptionsListView.Items[0].Selected = true;

        }

        private void GetCommentsButton_Click(object sender, EventArgs e)
        {
            using (var context = new NorthwindContext())
            {
                var comments = context.Comments(ModelNamesListBox.Text).Select(x => x.Full).ToList(); 
                var commentForm = new ModelCommentsForm(comments, ModelNamesListBox.Text);

                try
                {
                    commentForm.ShowDialog();
                }
                finally
                {
                    commentForm.Dispose();
                }
                
            }
        }
    }
}
