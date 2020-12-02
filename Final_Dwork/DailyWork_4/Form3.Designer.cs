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
            this.buttonWorkModSave.Location = new System.Drawing.Point(179, 305);
            this.buttonWorkModSave.Name = "buttonWorkModSave";
            this.buttonWorkModSave.Size = new System.Drawing.Size(87, 33);
            this.buttonWorkModSave.TabIndex = 3;
            this.buttonWorkModSave.Text = "저장";
            this.buttonWorkModSave.UseVisualStyleBackColor = true;
            this.buttonWorkModSave.Click += new System.EventHandler(this.buttonWorkModSave_Click);
            // 
            // comboBoxSubCateMod
            // 
            this.comboBoxSubCateMod.FormattingEnabled = true;
            this.comboBoxSubCateMod.Items.AddRange(new object[] {
            "근퇴확인",
            "급여정산",
            "개발",
            "회의"});
            this.comboBoxSubCateMod.Location = new System.Drawing.Point(164, 222);
            this.comboBoxSubCateMod.Name = "comboBoxSubCateMod";
            this.comboBoxSubCateMod.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSubCateMod.TabIndex = 2;
            this.comboBoxSubCateMod.Text = "소분류";
            // 
            // comboBoxMiddleCateMod
            // 
            this.comboBoxMiddleCateMod.FormattingEnabled = true;
            this.comboBoxMiddleCateMod.Items.AddRange(new object[] {
            "정기업무",
            "단기업무"});
            this.comboBoxMiddleCateMod.Location = new System.Drawing.Point(164, 146);
            this.comboBoxMiddleCateMod.Name = "comboBoxMiddleCateMod";
            this.comboBoxMiddleCateMod.Size = new System.Drawing.Size(121, 20);
            this.comboBoxMiddleCateMod.TabIndex = 1;
            this.comboBoxMiddleCateMod.Text = "중분류";
            // 
            // comboBoxMainCateMod
            // 
            this.comboBoxMainCateMod.FormattingEnabled = true;
            this.comboBoxMainCateMod.Items.AddRange(new object[] {
            "인사부서",
            "개발부서",
            "홍보부서"});
            this.comboBoxMainCateMod.Location = new System.Drawing.Point(164, 82);
            this.comboBoxMainCateMod.Name = "comboBoxMainCateMod";
            this.comboBoxMainCateMod.Size = new System.Drawing.Size(121, 20);
            this.comboBoxMainCateMod.TabIndex = 0;
            this.comboBoxMainCateMod.Text = "대분류";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 371);
            this.Controls.Add(this.buttonWorkModSave);
            this.Controls.Add(this.comboBoxSubCateMod);
            this.Controls.Add(this.comboBoxMiddleCateMod);
            this.Controls.Add(this.comboBoxMainCateMod);
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