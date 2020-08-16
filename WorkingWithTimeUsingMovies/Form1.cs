using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLibrary.Classes;

namespace WorkingWithTimeUsingMovies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var movies = await MovieOperations.GetMovies();

            var sorted = movies.OrderBy(x => x.Duration.Value.Hours);

            foreach (var movie in sorted)
            {
                MoviesListView.Items.Add(new ListViewItem(movie.ItemArray));
            }

            MoviesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MoviesListView.FocusedItem = MoviesListView.Items[0];
            MoviesListView.Items[0].Selected = true;
        }
    }
}
