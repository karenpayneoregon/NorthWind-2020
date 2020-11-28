namespace North.Forms
{
    partial class BetweenPrimaryKeysExtensionExamples
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
            this.label1 = new System.Windows.Forms.Label();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.Execute1Button = new System.Windows.Forms.Button();
            this.CompanyDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.Execute2Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start";
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(23, 31);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartTextBox.TabIndex = 1;
            this.StartTextBox.Text = "12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End";
            // 
            // EndTextBox
            // 
            this.EndTextBox.Location = new System.Drawing.Point(178, 31);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(100, 20);
            this.EndTextBox.TabIndex = 3;
            this.EndTextBox.Text = "23";
            // 
            // Execute1Button
            // 
            this.Execute1Button.Image = global::North.Properties.Resources.Execute_16x;
            this.Execute1Button.Location = new System.Drawing.Point(23, 57);
            this.Execute1Button.Name = "Execute1Button";
            this.Execute1Button.Size = new System.Drawing.Size(299, 23);
            this.Execute1Button.TabIndex = 4;
            this.Execute1Button.UseVisualStyleBackColor = true;
            this.Execute1Button.Click += new System.EventHandler(this.Execute1Button_Click);
            // 
            // CompanyDataGridView
            // 
            this.CompanyDataGridView.AllowUserToAddRows = false;
            this.CompanyDataGridView.AllowUserToDeleteRows = false;
            this.CompanyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyNameColumn,
            this.CountryNameColumn});
            this.CompanyDataGridView.Location = new System.Drawing.Point(23, 131);
            this.CompanyDataGridView.Name = "CompanyDataGridView";
            this.CompanyDataGridView.ReadOnly = true;
            this.CompanyDataGridView.RowHeadersVisible = false;
            this.CompanyDataGridView.Size = new System.Drawing.Size(301, 159);
            this.CompanyDataGridView.TabIndex = 5;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "Name";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            this.CompanyNameColumn.ReadOnly = true;
            // 
            // CountryNameColumn
            // 
            this.CountryNameColumn.DataPropertyName = "Country";
            this.CountryNameColumn.HeaderText = "Country";
            this.CountryNameColumn.Name = "CountryNameColumn";
            this.CountryNameColumn.ReadOnly = true;
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(337, 31);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(170, 21);
            this.CountryComboBox.TabIndex = 6;
            // 
            // Execute2Button
            // 
            this.Execute2Button.Image = global::North.Properties.Resources.Execute_16x;
            this.Execute2Button.Location = new System.Drawing.Point(25, 86);
            this.Execute2Button.Name = "Execute2Button";
            this.Execute2Button.Size = new System.Drawing.Size(299, 23);
            this.Execute2Button.TabIndex = 7;
            this.Execute2Button.UseVisualStyleBackColor = true;
            this.Execute2Button.Click += new System.EventHandler(this.Execute2Button_Click);
            // 
            // BetweenPrimaryKeysExtensionExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 302);
            this.Controls.Add(this.Execute2Button);
            this.Controls.Add(this.CountryComboBox);
            this.Controls.Add(this.CompanyDataGridView);
            this.Controls.Add(this.Execute1Button);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BetweenPrimaryKeysExtensionExamples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Between Primary Keys Examples";
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EndTextBox;
        private System.Windows.Forms.Button Execute1Button;
        private System.Windows.Forms.DataGridView CompanyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryNameColumn;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.Button Execute2Button;
    }
}