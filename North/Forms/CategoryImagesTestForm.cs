using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using North.Classes.Helpers;
using North.Contexts;
using North.Models;

namespace North.Forms
{
    public partial class CategoryImagesTestForm : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        public CategoryImagesTestForm()
        {
            InitializeComponent();
            Shown += CategoryImagesTestForm_Shown;
        }
        private async void CategoryImagesTestForm_Shown(object sender, EventArgs e)
        {

            await Task.Run(async () =>
            {
                using (var context = new NorthwindContext())
                {
                    _bindingSource.DataSource = await context.Categories.AsNoTracking().ToListAsync();
                }
            });

            CategoryListBox.DataSource = _bindingSource;

            CategoryDescriptionLabel.DataBindings.Add("Text", _bindingSource, "Description");
            _bindingSource.PositionChanged += _bindingSource_PositionChanged;
            DisplayCategoryImage();

        }
        private void _bindingSource_PositionChanged(object sender, EventArgs e) => DisplayCategoryImage();
        private void DisplayCategoryImage()
        {
            CategoryPictureBox.Image = ImageHelpers.ByteArrayToImage(((Categories) CategoryListBox.SelectedItem).Picture);
        }
    }
}
