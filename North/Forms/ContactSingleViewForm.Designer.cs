namespace North.Forms
{
    partial class ContactSingleViewForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.CellPhoneNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HomePhoneTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContactIdTextBox = new System.Windows.Forms.TextBox();
            this.OfficePhoneTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ConactTypeTextBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Cell phone";
            // 
            // CellPhoneNumber
            // 
            this.CellPhoneNumber.Location = new System.Drawing.Point(86, 187);
            this.CellPhoneNumber.Name = "CellPhoneNumber";
            this.CellPhoneNumber.Size = new System.Drawing.Size(225, 20);
            this.CellPhoneNumber.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Home phone";
            // 
            // HomePhoneTextBox
            // 
            this.HomePhoneTextBox.Location = new System.Drawing.Point(86, 152);
            this.HomePhoneTextBox.Name = "HomePhoneTextBox";
            this.HomePhoneTextBox.Size = new System.Drawing.Size(225, 20);
            this.HomePhoneTextBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Office phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Id";
            // 
            // ContactIdTextBox
            // 
            this.ContactIdTextBox.Location = new System.Drawing.Point(86, 12);
            this.ContactIdTextBox.Name = "ContactIdTextBox";
            this.ContactIdTextBox.Size = new System.Drawing.Size(225, 20);
            this.ContactIdTextBox.TabIndex = 19;
            // 
            // OfficePhoneTextBox
            // 
            this.OfficePhoneTextBox.Location = new System.Drawing.Point(86, 117);
            this.OfficePhoneTextBox.Name = "OfficePhoneTextBox";
            this.OfficePhoneTextBox.Size = new System.Drawing.Size(225, 20);
            this.OfficePhoneTextBox.TabIndex = 18;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(86, 82);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(225, 20);
            this.NameTextBox.TabIndex = 17;
            // 
            // ConactTypeTextBox
            // 
            this.ConactTypeTextBox.Location = new System.Drawing.Point(86, 47);
            this.ConactTypeTextBox.Name = "ConactTypeTextBox";
            this.ConactTypeTextBox.Size = new System.Drawing.Size(225, 20);
            this.ConactTypeTextBox.TabIndex = 16;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(236, 215);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 28;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ContactSingleViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 250);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CellPhoneNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HomePhoneTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContactIdTextBox);
            this.Controls.Add(this.OfficePhoneTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ConactTypeTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContactSingleViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CellPhoneNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox HomePhoneTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ContactIdTextBox;
        private System.Windows.Forms.TextBox OfficePhoneTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox ConactTypeTextBox;
        private System.Windows.Forms.Button CloseButton;
    }
}