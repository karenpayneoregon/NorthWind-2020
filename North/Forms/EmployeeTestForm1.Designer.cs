namespace North.Forms
{
    partial class EmployeeTestForm1
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
            this.AllEmployeeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllEmployeeButton
            // 
            this.AllEmployeeButton.Location = new System.Drawing.Point(11, 210);
            this.AllEmployeeButton.Name = "AllEmployeeButton";
            this.AllEmployeeButton.Size = new System.Drawing.Size(166, 23);
            this.AllEmployeeButton.TabIndex = 0;
            this.AllEmployeeButton.Text = "Get all";
            this.AllEmployeeButton.UseVisualStyleBackColor = true;
            this.AllEmployeeButton.Click += new System.EventHandler(this.AllEmployeeButton_Click);
            // 
            // EmployeeTestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 257);
            this.Controls.Add(this.AllEmployeeButton);
            this.Name = "EmployeeTestForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AllEmployeeButton;
    }
}