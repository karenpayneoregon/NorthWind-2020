namespace WorkingWithTimeUsingMovies
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoviesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddMovieButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MoviesListView
            // 
            this.MoviesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.MoviesListView.FullRowSelect = true;
            this.MoviesListView.HideSelection = false;
            this.MoviesListView.Location = new System.Drawing.Point(12, 12);
            this.MoviesListView.MultiSelect = false;
            this.MoviesListView.Name = "MoviesListView";
            this.MoviesListView.Size = new System.Drawing.Size(234, 128);
            this.MoviesListView.TabIndex = 0;
            this.MoviesListView.UseCompatibleStateImageBehavior = false;
            this.MoviesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hours";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Minutes";
            // 
            // AddMovieButton
            // 
            this.AddMovieButton.Location = new System.Drawing.Point(12, 146);
            this.AddMovieButton.Name = "AddMovieButton";
            this.AddMovieButton.Size = new System.Drawing.Size(234, 23);
            this.AddMovieButton.TabIndex = 1;
            this.AddMovieButton.Text = "Add new movie";
            this.AddMovieButton.UseVisualStyleBackColor = true;
            this.AddMovieButton.Click += new System.EventHandler(this.AddMovieButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 180);
            this.Controls.Add(this.AddMovieButton);
            this.Controls.Add(this.MoviesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movies duration using Time(7) type";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MoviesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button AddMovieButton;
    }
}

