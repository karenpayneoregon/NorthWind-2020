﻿namespace North.Forms
{
    partial class ModelPropertyDescriptionForm
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
            this.ModelNamesListBox = new System.Windows.Forms.ListBox();
            this.ColumnDescriptionsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.identifierLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModelNamesListBox
            // 
            this.ModelNamesListBox.FormattingEnabled = true;
            this.ModelNamesListBox.Location = new System.Drawing.Point(26, 19);
            this.ModelNamesListBox.Name = "ModelNamesListBox";
            this.ModelNamesListBox.Size = new System.Drawing.Size(167, 342);
            this.ModelNamesListBox.TabIndex = 1;
            // 
            // ColumnDescriptionsListView
            // 
            this.ColumnDescriptionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ColumnDescriptionsListView.FullRowSelect = true;
            this.ColumnDescriptionsListView.HideSelection = false;
            this.ColumnDescriptionsListView.Location = new System.Drawing.Point(205, 22);
            this.ColumnDescriptionsListView.MultiSelect = false;
            this.ColumnDescriptionsListView.Name = "ColumnDescriptionsListView";
            this.ColumnDescriptionsListView.Size = new System.Drawing.Size(303, 339);
            this.ColumnDescriptionsListView.TabIndex = 2;
            this.ColumnDescriptionsListView.UseCompatibleStateImageBehavior = false;
            this.ColumnDescriptionsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.identifierLabel);
            this.groupBox1.Controls.Add(this.ColumnDescriptionsListView);
            this.groupBox1.Controls.Add(this.ModelNamesListBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 414);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Column descriptions";
            // 
            // identifierLabel
            // 
            this.identifierLabel.AutoSize = true;
            this.identifierLabel.Location = new System.Drawing.Point(211, 377);
            this.identifierLabel.Name = "identifierLabel";
            this.identifierLabel.Size = new System.Drawing.Size(122, 13);
            this.identifierLabel.TabIndex = 3;
            this.identifierLabel.Text = "Primary key place holder";
            // 
            // ModelPropertyDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 443);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModelPropertyDescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get model column descriptions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ModelNamesListBox;
        private System.Windows.Forms.ListView ColumnDescriptionsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label identifierLabel;
    }
}