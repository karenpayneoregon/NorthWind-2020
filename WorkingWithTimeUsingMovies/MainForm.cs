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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var movies = await MovieOperations.GetMovies();

            // ReSharper disable once PossibleInvalidOperationException - 
            var sorted = movies.OrderBy(x => x.Duration.Value.Hours);

            foreach (var movie in sorted)
            {
                MoviesListView.Items.Add(new ListViewItem(movie.ItemArray));
            }

            MoviesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MoviesListView.FocusedItem = MoviesListView.Items[0];
            MoviesListView.Items[0].Selected = true;
        }

        private void AddMovieButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddMovieForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (MovieOperations.AddMovie(addForm.Movie))
                {
                    try
                    {
                        MoviesListView.Items.Add(new ListViewItem(addForm.Movie.ItemArray));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Encountered the following issue\n{ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to add movie");
                }
            }
            // ReSharper disable once RedundantIfElseBlock
            else
            {
                // user cancelled
            }
        }
    }
}
