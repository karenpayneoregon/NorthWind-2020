namespace North.Forms
{
    partial class CustomersDataGridViewTestForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CustomersDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CurrentCustomerDetails = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CurrentCustomerDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 56);
            this.panel1.TabIndex = 0;
            // 
            // CustomersDataGridView
            // 
            this.CustomersDataGridView.AllowUserToAddRows = false;
            this.CustomersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyNameColumn,
            this.FirstNameColumn,
            this.LastNameColumn,
            this.TitleColumn,
            this.AddressColumn,
            this.CityColumn,
            this.PostalColumn,
            this.CountryColumn});
            this.CustomersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.CustomersDataGridView.Name = "CustomersDataGridView";
            this.CustomersDataGridView.Size = new System.Drawing.Size(870, 394);
            this.CustomersDataGridView.TabIndex = 1;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First name";
            this.FirstNameColumn.Name = "FirstNameColumn";
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last name";
            this.LastNameColumn.Name = "LastNameColumn";
            // 
            // TitleColumn
            // 
            this.TitleColumn.HeaderText = "Title";
            this.TitleColumn.Name = "TitleColumn";
            // 
            // AddressColumn
            // 
            this.AddressColumn.DataPropertyName = "Street";
            this.AddressColumn.HeaderText = "Street";
            this.AddressColumn.Name = "AddressColumn";
            this.AddressColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AddressColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CityColumn
            // 
            this.CityColumn.DataPropertyName = "City";
            this.CityColumn.HeaderText = "City";
            this.CityColumn.Name = "CityColumn";
            // 
            // PostalColumn
            // 
            this.PostalColumn.DataPropertyName = "PostalCode";
            this.PostalColumn.HeaderText = "Zip code";
            this.PostalColumn.Name = "PostalColumn";
            // 
            // CountryColumn
            // 
            this.CountryColumn.HeaderText = "Country";
            this.CountryColumn.Name = "CountryColumn";
            // 
            // CurrentCustomerDetails
            // 
            this.CurrentCustomerDetails.Location = new System.Drawing.Point(12, 21);
            this.CurrentCustomerDetails.Name = "CurrentCustomerDetails";
            this.CurrentCustomerDetails.Size = new System.Drawing.Size(129, 23);
            this.CurrentCustomerDetails.TabIndex = 0;
            this.CurrentCustomerDetails.Text = "Current details";
            this.CurrentCustomerDetails.UseVisualStyleBackColor = true;
            // 
            // CustomersDataGridViewTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.CustomersDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "CustomersDataGridViewTestForm";
            this.Text = "Customers DataGridView Test";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView CustomersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn CountryColumn;
        private System.Windows.Forms.Button CurrentCustomerDetails;
    }
}