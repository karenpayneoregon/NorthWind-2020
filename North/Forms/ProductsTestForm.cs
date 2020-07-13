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
    public partial class ProductsTestForm : Form
    {
        public ProductsTestForm()
        {
            InitializeComponent();

            ProductsDataGridView.AutoGenerateColumns = false;

            Shown += ProductsTestForm_Shown;
        }


        private async void  ProductsTestForm_Shown(object sender, EventArgs e)
        {
            var categories = await CategoryTestOperations.CategoryItems();
            CategoryComboBox.DataSource = categories;
        }

        private void LoadProductsButton_Click(object sender, EventArgs e)
        {
            if (CategoryComboBox.DataSource == null)
            {
                return;
            }

            var categoryIdentifier = ((CategoryItem) CategoryComboBox.SelectedItem).CategoryID;

            ProductsDataGridView.DataSource = ProductsTestOperations.GetProductsByCategory(categoryIdentifier);

            for (int rowIndex = 0; rowIndex < ProductsDataGridView.Rows.Count; rowIndex++)
            {
                if (((ProductItem)ProductsDataGridView.Rows[rowIndex].DataBoundItem).Discontinued)
                {
                    ProductsDataGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

        }
    }
}
