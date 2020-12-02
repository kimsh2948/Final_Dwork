using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DailyWork
{
    public partial class Form3 : Form
    {
        Form1 form1;
        public Form3()
        {
            InitializeComponent();
            InitVariables();
            this.buttonWorkModSave.Click += buttonWorkModSave_Click;
        }
        public Form3(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }
        public void InitVariables()
        {

        }

        private void buttonWorkModSave_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            ModWork();
            AddListView();
        }
        
        public void ModWork()
        {
            Form2 form2 = new Form2();
            int indexnum = Convert.ToInt32(form1.listViewWorkList.FocusedItem.Text);

            string maincategory = comboBoxMainCateMod.Text;
            string middlecategory = comboBoxMiddleCateMod.Text;
            string subcategory = comboBoxSubCateMod.Text; 
            string query = "UPDATE dailywork SET MainCategory = @maincategory, MiddleCategory = " +
                "@middlecategory, SubCategory = @subcategory WHERE id='"+indexnum+"'";

            if (maincategory == "대분류" || middlecategory == "중분류" || subcategory == "소분류")
            {
                MessageBox.Show("항목을 수정해 주세요");
            }
            else
            {
                DBManager.GetInstace().Update(query, maincategory, middlecategory, subcategory);
                this.Close();
            }
        }
        public void AddListView()
        {
            Form2 form2 = new Form2();
            if (form1.listViewWorkList.Items.Count > 0)//listview에 아이템 있으면 지우고 로드
            {
                form1.listViewWorkList.Items.Clear();
            }
            List<WorkCategory> worklist = form2.LoadWork();
            form1.listViewWorkList.BeginUpdate();
            ListViewItem item;
            int i = 0;
            while (i < worklist.Count)//listview에 삽입
            {
                WorkCategory workcategory = new WorkCategory();
                workcategory = worklist[i];
                item = new ListViewItem(Convert.ToString(workcategory.id));
                item.SubItems.Add(workcategory.day);
                item.SubItems.Add(workcategory.start_time);
                item.SubItems.Add(workcategory.end_time);
                item.SubItems.Add(workcategory.MainCategory);
                item.SubItems.Add(workcategory.MiddleCategory);
                item.SubItems.Add(workcategory.SubCategory);

                form1.listViewWorkList.Items.Add(item);

                i++;
            }
            form1.listViewWorkList.EndUpdate();
        }

    }
}
