namespace DailyWork
{
    partial class Form4
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
            this.textBoxInputKeyword = new System.Windows.Forms.TextBox();
            this.buttonWorkSerchOn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInputKeyword
            // 
            this.textBoxInputKeyword.Location = new System.Drawing.Point(98, 100);
            this.textBoxInputKeyword.Name = "textBoxInputKeyword";
            this.textBoxInputKeyword.Size = new System.Drawing.Size(181, 21);
            this.textBoxInputKeyword.TabIndex = 0;
            // 
            // buttonWorkSerchOn
            // 
            this.buttonWorkSerchOn.Location = new System.Drawing.Point(320, 100);
            this.buttonWorkSerchOn.Name = "buttonWorkSerchOn";
            this.buttonWorkSerchOn.Size = new System.Drawing.Size(75, 23);
            this.buttonWorkSerchOn.TabIndex = 1;
            this.buttonWorkSerchOn.Text = "검색";
            this.buttonWorkSerchOn.UseVisualStyleBackColor = true;
            this.buttonWorkSerchOn.Click += new System.EventHandler(this.buttonWorkSerchOn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 229);
            this.Controls.Add(this.buttonWorkSerchOn);
            this.Controls.Add(this.textBoxInputKeyword);
            this.Name = "Form4";
            this.Text = "검색";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInputKeyword;
        private System.Windows.Forms.Button buttonWorkSerchOn;
    }
}