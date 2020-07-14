namespace North.Forms
{
    partial class EmployeeTestForm
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
            this.EmployeeWithManagersDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeWithManagersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeeWithManagersDataGridView
            // 
            this.EmployeeWithManagersDataGridView.AllowUserToAddRows = false;
            this.EmployeeWithManagersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeWithManagersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeWithManagersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.EmployeeWithManagersDataGridView.Name = "EmployeeWithManagersDataGridView";
            this.EmployeeWithManagersDataGridView.Size = new System.Drawing.Size(800, 450);
            this.EmployeeWithManagersDataGridView.TabIndex = 0;
            // 
            // EmployeeTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EmployeeWithManagersDataGridView);
            this.Name = "EmployeeTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee with managers Test";
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeWithManagersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView EmployeeWithManagersDataGridView;
    }
}