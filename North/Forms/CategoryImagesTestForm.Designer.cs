namespace North.Forms
{
    partial class CategoryImagesTestForm
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
            this.CategoryListBox = new System.Windows.Forms.ListBox();
            this.CategoryPictureBox = new System.Windows.Forms.PictureBox();
            this.CategoryDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoryListBox
            // 
            this.CategoryListBox.FormattingEnabled = true;
            this.CategoryListBox.Location = new System.Drawing.Point(12, 14);
            this.CategoryListBox.Name = "CategoryListBox";
            this.CategoryListBox.Size = new System.Drawing.Size(208, 212);
            this.CategoryListBox.TabIndex = 0;
            // 
            // CategoryPictureBox
            // 
            this.CategoryPictureBox.Location = new System.Drawing.Point(239, 11);
            this.CategoryPictureBox.Name = "CategoryPictureBox";
            this.CategoryPictureBox.Size = new System.Drawing.Size(214, 214);
            this.CategoryPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CategoryPictureBox.TabIndex = 1;
            this.CategoryPictureBox.TabStop = false;
            // 
            // CategoryDescriptionLabel
            // 
            this.CategoryDescriptionLabel.AutoSize = true;
            this.CategoryDescriptionLabel.Location = new System.Drawing.Point(12, 248);
            this.CategoryDescriptionLabel.Name = "CategoryDescriptionLabel";
            this.CategoryDescriptionLabel.Size = new System.Drawing.Size(103, 13);
            this.CategoryDescriptionLabel.TabIndex = 2;
            this.CategoryDescriptionLabel.Text = "Category description";
            // 
            // CategoryImagesTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 297);
            this.Controls.Add(this.CategoryDescriptionLabel);
            this.Controls.Add(this.CategoryPictureBox);
            this.Controls.Add(this.CategoryListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CategoryImagesTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category Images Test";
            ((System.ComponentModel.ISupportInitialize)(this.CategoryPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox CategoryListBox;
        private System.Windows.Forms.PictureBox CategoryPictureBox;
        private System.Windows.Forms.Label CategoryDescriptionLabel;
    }
}