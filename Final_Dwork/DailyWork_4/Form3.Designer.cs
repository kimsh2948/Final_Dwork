namespace DailyWork
{
    partial class Form3
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
            this.buttonWorkModSave = new System.Windows.Forms.Button();
            this.comboBoxSubCateMod = new System.Windows.Forms.ComboBox();
            this.comboBoxMiddleCateMod = new System.Windows.Forms.ComboBox();
            this.comboBoxMainCateMod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonWorkModSave
            // 
            this.buttonWorkModSave.Location = new System.Drawing.Point(205, 381);
            this.buttonWorkModSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonWorkModSave.Name = "buttonWorkModSave";
            this.buttonWorkModSave.Size = new System.Drawing.Size(99, 41);
            this.buttonWorkModSave.TabIndex = 3;
            this.buttonWorkModSave.Text = "저장";
            this.buttonWorkModSave.UseVisualStyleBackColor = true;
            this.buttonWorkModSave.Click += new System.EventHandler(this.buttonWorkModSave_Click);
            // 
            // comboBoxSubCateMod
            // 
            this.comboBoxSubCateMod.FormattingEnabled = true;
            this.comboBoxSubCateMod.Location = new System.Drawing.Point(187, 278);
            this.comboBoxSubCateMod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxSubCateMod.Name = "comboBoxSubCateMod";
            this.comboBoxSubCateMod.Size = new System.Drawing.Size(138, 23);
            this.comboBoxSubCateMod.TabIndex = 2;
            this.comboBoxSubCateMod.Text = "소분류";
            // 
            // comboBoxMiddleCateMod
            // 
            this.comboBoxMiddleCateMod.FormattingEnabled = true;
            this.comboBoxMiddleCateMod.Location = new System.Drawing.Point(187, 182);
            this.comboBoxMiddleCateMod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxMiddleCateMod.Name = "comboBoxMiddleCateMod";
            this.comboBoxMiddleCateMod.Size = new System.Drawing.Size(138, 23);
            this.comboBoxMiddleCateMod.TabIndex = 1;
            this.comboBoxMiddleCateMod.Text = "중분류";
            this.comboBoxMiddleCateMod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMiddleCateMod_SelectedIndexChanged);
            // 
            // comboBoxMainCateMod
            // 
            this.comboBoxMainCateMod.FormattingEnabled = true;
            this.comboBoxMainCateMod.Location = new System.Drawing.Point(187, 102);
            this.comboBoxMainCateMod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxMainCateMod.Name = "comboBoxMainCateMod";
            this.comboBoxMainCateMod.Size = new System.Drawing.Size(138, 23);
            this.comboBoxMainCateMod.TabIndex = 0;
            this.comboBoxMainCateMod.Text = "대분류";
            this.comboBoxMainCateMod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMainCateMod_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 464);
            this.Controls.Add(this.buttonWorkModSave);
            this.Controls.Add(this.comboBoxSubCateMod);
            this.Controls.Add(this.comboBoxMiddleCateMod);
            this.Controls.Add(this.comboBoxMainCateMod);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.Text = "업무수정";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWorkModSave;
        private System.Windows.Forms.ComboBox comboBoxSubCateMod;
        private System.Windows.Forms.ComboBox comboBoxMiddleCateMod;
        private System.Windows.Forms.ComboBox comboBoxMainCateMod;
    }
}