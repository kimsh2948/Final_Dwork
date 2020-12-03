namespace DailyWork
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.comboBoxMainCate = new System.Windows.Forms.ComboBox();
            this.comboBoxMiddleCate = new System.Windows.Forms.ComboBox();
            this.comboBoxSubCate = new System.Windows.Forms.ComboBox();
            this.buttonWorkRegSave = new System.Windows.Forms.Button();
            this.dateTimePickerInsertWork = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMainCate
            // 
            this.comboBoxMainCate.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxMainCate, "comboBoxMainCate");
            this.comboBoxMainCate.Name = "comboBoxMainCate";
            this.comboBoxMainCate.SelectedIndexChanged += new System.EventHandler(this.comboBoxMainCate_SelectedIndexChanged);
            // 
            // comboBoxMiddleCate
            // 
            this.comboBoxMiddleCate.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxMiddleCate, "comboBoxMiddleCate");
            this.comboBoxMiddleCate.Name = "comboBoxMiddleCate";
            this.comboBoxMiddleCate.SelectedIndexChanged += new System.EventHandler(this.comboBoxMiddleCate_SelectedIndexChanged);
            // 
            // comboBoxSubCate
            // 
            this.comboBoxSubCate.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxSubCate, "comboBoxSubCate");
            this.comboBoxSubCate.Name = "comboBoxSubCate";
            // 
            // buttonWorkRegSave
            // 
            resources.ApplyResources(this.buttonWorkRegSave, "buttonWorkRegSave");
            this.buttonWorkRegSave.Name = "buttonWorkRegSave";
            this.buttonWorkRegSave.UseVisualStyleBackColor = true;
            this.buttonWorkRegSave.Click += new System.EventHandler(this.buttonWorkRegSave_Click);
            // 
            // dateTimePickerInsertWork
            // 
            this.dateTimePickerInsertWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.dateTimePickerInsertWork, "dateTimePickerInsertWork");
            this.dateTimePickerInsertWork.Name = "dateTimePickerInsertWork";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.dateTimePickerStartTime, "dateTimePickerStartTime");
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            resources.ApplyResources(this.dateTimePickerEndTime, "dateTimePickerEndTime");
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.ShowUpDown = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.dateTimePickerInsertWork);
            this.Controls.Add(this.buttonWorkRegSave);
            this.Controls.Add(this.comboBoxSubCate);
            this.Controls.Add(this.comboBoxMiddleCate);
            this.Controls.Add(this.comboBoxMainCate);
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMainCate;
        private System.Windows.Forms.ComboBox comboBoxMiddleCate;
        private System.Windows.Forms.ComboBox comboBoxSubCate;
        private System.Windows.Forms.Button buttonWorkRegSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerInsertWork;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}