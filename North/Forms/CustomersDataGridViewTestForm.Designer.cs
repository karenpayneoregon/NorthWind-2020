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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersDataGridViewTestForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CurrentCustomerDetails = new System.Windows.Forms.Button();
            this.CustomersDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactTitleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomersBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingNavigator)).BeginInit();
            this.CustomersBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveChangesButton);
            this.panel1.Controls.Add(this.CurrentCustomerDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 56);
            this.panel1.TabIndex = 0;
            // 
            // CurrentCustomerDetails
            // 
            this.CurrentCustomerDetails.Enabled = false;
            this.CurrentCustomerDetails.Location = new System.Drawing.Point(12, 21);
            this.CurrentCustomerDetails.Name = "CurrentCustomerDetails";
            this.CurrentCustomerDetails.Size = new System.Drawing.Size(129, 23);
            this.CurrentCustomerDetails.TabIndex = 0;
            this.CurrentCustomerDetails.Text = "Current details";
            this.CurrentCustomerDetails.UseVisualStyleBackColor = true;
            this.CurrentCustomerDetails.Click += new System.EventHandler(this.CurrentCustomerDetails_Click);
            // 
            // CustomersDataGridView
            // 
            this.CustomersDataGridView.AllowUserToAddRows = false;
            this.CustomersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyNameColumn,
            this.FirstNameColumn,
            this.LastNameColumn,
            this.ContactTitleColumn,
            this.AddressColumn,
            this.CityColumn,
            this.PostalColumn,
            this.CountryColumn});
            this.CustomersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersDataGridView.Location = new System.Drawing.Point(0, 25);
            this.CustomersDataGridView.Name = "CustomersDataGridView";
            this.CustomersDataGridView.Size = new System.Drawing.Size(870, 369);
            this.CustomersDataGridView.TabIndex = 1;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.Frozen = true;
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
            // ContactTitleColumn
            // 
            this.ContactTitleColumn.HeaderText = "Title";
            this.ContactTitleColumn.Name = "ContactTitleColumn";
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
            // CustomersBindingNavigator
            // 
            this.CustomersBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.CustomersBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.CustomersBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.CustomersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.CustomersBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.CustomersBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.CustomersBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.CustomersBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.CustomersBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.CustomersBindingNavigator.Name = "CustomersBindingNavigator";
            this.CustomersBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.CustomersBindingNavigator.Size = new System.Drawing.Size(870, 25);
            this.CustomersBindingNavigator.TabIndex = 2;
            this.CustomersBindingNavigator.Text = "Customers Binding Navigator";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.Enabled = false;
            this.SaveChangesButton.Location = new System.Drawing.Point(147, 21);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(129, 23);
            this.SaveChangesButton.TabIndex = 1;
            this.SaveChangesButton.Text = "Save changes";
            this.SaveChangesButton.UseVisualStyleBackColor = true;
            this.SaveChangesButton.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // CustomersDataGridViewTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.CustomersDataGridView);
            this.Controls.Add(this.CustomersBindingNavigator);
            this.Controls.Add(this.panel1);
            this.Name = "CustomersDataGridViewTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers DataGridView Test";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersBindingNavigator)).EndInit();
            this.CustomersBindingNavigator.ResumeLayout(false);
            this.CustomersBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView CustomersDataGridView;
        private System.Windows.Forms.Button CurrentCustomerDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ContactTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostalColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn CountryColumn;
        private System.Windows.Forms.BindingNavigator CustomersBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button SaveChangesButton;
    }
}