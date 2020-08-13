namespace ValidationMocked
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
            this.Validate1Button = new System.Windows.Forms.Button();
            this.Validate2Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Validate1Button
            // 
            this.Validate1Button.Location = new System.Drawing.Point(31, 27);
            this.Validate1Button.Name = "Validate1Button";
            this.Validate1Button.Size = new System.Drawing.Size(176, 23);
            this.Validate1Button.TabIndex = 0;
            this.Validate1Button.Text = "Validate 1";
            this.Validate1Button.UseVisualStyleBackColor = true;
            this.Validate1Button.Click += new System.EventHandler(this.Validate1Button_Click);
            // 
            // Validate2Button
            // 
            this.Validate2Button.Location = new System.Drawing.Point(31, 56);
            this.Validate2Button.Name = "Validate2Button";
            this.Validate2Button.Size = new System.Drawing.Size(176, 23);
            this.Validate2Button.TabIndex = 1;
            this.Validate2Button.Text = "Validate 2";
            this.Validate2Button.UseVisualStyleBackColor = true;
            this.Validate2Button.Click += new System.EventHandler(this.Validate2Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 100);
            this.Controls.Add(this.Validate2Button);
            this.Controls.Add(this.Validate1Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mocked validation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Validate1Button;
        private System.Windows.Forms.Button Validate2Button;
    }
}

