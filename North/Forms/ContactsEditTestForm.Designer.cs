namespace North.Forms
{
    partial class ContactsEditTestForm
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
            this.CellPhoneNumber = new System.Windows.Forms.TextBox();
            this.HomePhoneTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContactIdTextBox = new System.Windows.Forms.TextBox();
            this.OfficePhoneTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.ContactTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ContactsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CellPhoneNumber
            // 
            this.CellPhoneNumber.Location = new System.Drawing.Point(96, 238);
            this.CellPhoneNumber.Name = "CellPhoneNumber";
            this.CellPhoneNumber.Size = new System.Drawing.Size(225, 20);
            this.CellPhoneNumber.TabIndex = 6;
            // 
            // HomePhoneTextBox
            // 
            this.HomePhoneTextBox.Location = new System.Drawing.Point(96, 203);
            this.HomePhoneTextBox.Name = "HomePhoneTextBox";
            this.HomePhoneTextBox.Size = new System.Drawing.Size(225, 20);
            this.HomePhoneTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Id";
            // 
            // ContactIdTextBox
            // 
            this.ContactIdTextBox.Location = new System.Drawing.Point(96, 63);
            this.ContactIdTextBox.Name = "ContactIdTextBox";
            this.ContactIdTextBox.Size = new System.Drawing.Size(225, 20);
            this.ContactIdTextBox.TabIndex = 0;
            // 
            // OfficePhoneTextBox
            // 
            this.OfficePhoneTextBox.Location = new System.Drawing.Point(96, 168);
            this.OfficePhoneTextBox.Name = "OfficePhoneTextBox";
            this.OfficePhoneTextBox.Size = new System.Drawing.Size(225, 20);
            this.OfficePhoneTextBox.TabIndex = 4;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(96, 133);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(97, 20);
            this.FirstNameTextBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Cell phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Home phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Office phone";
            // 
            // button2
            // 
            this.button2.Image = global::North.Properties.Resources.Exit_16x;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(246, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = " Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Image = global::North.Properties.Resources.Save_16x;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(26, 278);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveCurrentContactButton_Click);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(224, 132);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(97, 20);
            this.LastNameTextBox.TabIndex = 3;
            // 
            // ContactTypeComboBox
            // 
            this.ContactTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContactTypeComboBox.FormattingEnabled = true;
            this.ContactTypeComboBox.Location = new System.Drawing.Point(96, 91);
            this.ContactTypeComboBox.Name = "ContactTypeComboBox";
            this.ContactTypeComboBox.Size = new System.Drawing.Size(225, 21);
            this.ContactTypeComboBox.TabIndex = 30;
            // 
            // ContactsComboBox
            // 
            this.ContactsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContactsComboBox.FormattingEnabled = true;
            this.ContactsComboBox.Location = new System.Drawing.Point(96, 12);
            this.ContactsComboBox.Name = "ContactsComboBox";
            this.ContactsComboBox.Size = new System.Drawing.Size(225, 21);
            this.ContactsComboBox.TabIndex = 31;
            // 
            // ContactsEditTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 313);
            this.Controls.Add(this.ContactsComboBox);
            this.Controls.Add(this.ContactTypeComboBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SaveButton);
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
            this.Controls.Add(this.FirstNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContactsEditTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts Edit Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CellPhoneNumber;
        private System.Windows.Forms.TextBox HomePhoneTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ContactIdTextBox;
        private System.Windows.Forms.TextBox OfficePhoneTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.ComboBox ContactTypeComboBox;
        private System.Windows.Forms.ComboBox ContactsComboBox;
    }
}