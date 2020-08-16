using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLibrary.Models;

namespace WorkingWithTimeUsingMovies
{
    public partial class AddMovieForm : Form
    {
        private Movies _movie;
        public Movies Movie => _movie;
        public AddMovieForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _movie = new Movies()
            {
                Title = TitleTextBox.Text,
                Duration = new TimeSpan(0, HoursTextBox.AsInt, MinutesTextBox.AsInt,0)
            };

            DialogResult = DialogResult.OK;
        }
    }
}
