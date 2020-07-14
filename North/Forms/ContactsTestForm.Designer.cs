namespace North
{
    partial class ContactsTestForm
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
            this.ContactsListBox = new System.Windows.Forms.ListBox();
            this.ConactTypeTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.OfficePhoneTextBox = new System.Windows.Forms.TextBox();
            this.ContactIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomersDemoButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.HomePhoneTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CellPhoneNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ContactsListBox
            // 
            this.ContactsListBox.FormattingEnabled = true;
            this.ContactsListBox.Location = new System.Drawing.Point(12, 12);
            this.ContactsListBox.Name = "ContactsListBox";
            this.ContactsListBox.Size = new System.Drawing.Size(224, 420);
            this.ContactsListBox.TabIndex = 2;
            // 
            // ConactTypeTextBox
            // 
            this.ConactTypeTextBox.Location = new System.Drawing.Point(330, 78);
            this.ConactTypeTextBox.Name = "ConactTypeTextBox";
            this.ConactTypeTextBox.Size = new System.Drawing.Size(225, 20);
            this.ConactTypeTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(330, 113);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(225, 20);
            this.NameTextBox.TabIndex = 4;
            // 
            // OfficePhoneTextBox
            // 
            this.OfficePhoneTextBox.Location = new System.Drawing.Point(330, 148);
            this.OfficePhoneTextBox.Name = "OfficePhoneTextBox";
            this.OfficePhoneTextBox.Size = new System.Drawing.Size(225, 20);
            this.OfficePhoneTextBox.TabIndex = 5;
            // 
            // ContactIdTextBox
            // 
            this.ContactIdTextBox.Location = new System.Drawing.Point(330, 43);
            this.ContactIdTextBox.Name = "ContactIdTextBox";
            this.ContactIdTextBox.Size = new System.Drawing.Size(225, 20);
            this.ContactIdTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Office phone";
            // 
            // CustomersDemoButton
            // 
            this.CustomersDemoButton.Location = new System.Drawing.Point(436, 409);
            this.CustomersDemoButton.Name = "CustomersDemoButton";
            this.CustomersDemoButton.Size = new System.Drawing.Size(119, 23);
            this.CustomersDemoButton.TabIndex = 11;
            this.CustomersDemoButton.Text = "Customers demo";
            this.CustomersDemoButton.UseVisualStyleBackColor = true;
            this.CustomersDemoButton.Click += new System.EventHandler(this.CustomersDemoButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Home phone";
            // 
            // HomePhoneTextBox
            // 
            this.HomePhoneTextBox.Location = new System.Drawing.Point(330, 183);
            this.HomePhoneTextBox.Name = "HomePhoneTextBox";
            this.HomePhoneTextBox.Size = new System.Drawing.Size(225, 20);
            this.HomePhoneTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Cell phone";
            // 
            // CellPhoneNumber
            // 
            this.CellPhoneNumber.Location = new System.Drawing.Point(330, 218);
            this.CellPhoneNumber.Name = "CellPhoneNumber";
            this.CellPhoneNumber.Size = new System.Drawing.Size(225, 20);
            this.CellPhoneNumber.TabIndex = 14;
            // 
            // ContactsTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CellPhoneNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HomePhoneTextBox);
            this.Controls.Add(this.CustomersDemoButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContactIdTextBox);
            this.Controls.Add(this.OfficePhoneTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ConactTypeTextBox);
            this.Controls.Add(this.ContactsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContactsTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ContactsListBox;
        private System.Windows.Forms.TextBox ConactTypeTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox OfficePhoneTextBox;
        private System.Windows.Forms.TextBox ContactIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CustomersDemoButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox HomePhoneTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CellPhoneNumber;
    }
}

