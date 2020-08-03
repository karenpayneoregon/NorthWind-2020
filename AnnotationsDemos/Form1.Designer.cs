namespace AnnotationsDemos
{
    partial class Form1
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
            this.CustomerNameRequiredButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerNameRequiredButton
            // 
            this.CustomerNameRequiredButton.Location = new System.Drawing.Point(25, 12);
            this.CustomerNameRequiredButton.Name = "CustomerNameRequiredButton";
            this.CustomerNameRequiredButton.Size = new System.Drawing.Size(192, 23);
            this.CustomerNameRequiredButton.TabIndex = 0;
            this.CustomerNameRequiredButton.Text = "Customer name required";
            this.CustomerNameRequiredButton.UseVisualStyleBackColor = true;
            this.CustomerNameRequiredButton.Click += new System.EventHandler(this.CustomerNameRequiredButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 168);
            this.Controls.Add(this.CustomerNameRequiredButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data annotations with EF Core";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CustomerNameRequiredButton;
    }
}

