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
    public partial class FrmDailyMod : Form
    {
        FrmDailyMain form1;
        public FrmDailyMod()
        {
            InitializeComponent();
            InitVariables();
            initWork();
            this.buttonWorkModSave.Click += buttonWorkModSave_Click;
        }
        public FrmDailyMod(FrmDailyMain form)
        {
            InitializeComponent();
            InitVariables();
            initWork();
            form1 = form;
        }
        public void InitVariables()
        {
            /*
            DateTime end_time = Convert.ToDateTime(form1.listViewWorkList.SelectedItems[0].SubItems[3].Text);

            this.dateTimePickerInsertWorkMod.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerInsertWorkMod.CustomFormat = "yyyy-MM-dd";

            this.dateTimePickerStartTimeMod.ShowUpDown = true;
            this.dateTimePickerStartTimeMod.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerStartTimeMod.CustomFormat = "HH:mm";

            this.dateTimePickerEndTimeMod.ShowUpDown = true;
            this.dateTimePickerEndTimeMod.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerEndTimeMod.CustomFormat = "HH:mm";
            this.dateTimePickerEndTimeMod.Value = new DateTime(end_time.Hour, end_time.Minute);
            */
           
        }
        public void initWork()
        {
            string query_main = "SELECT name FROM MainCategory";
            MySqlDataReader rdr_m = DailyTaskDBManager.GetInstace().Select(query_main);
            while (rdr_m.Read())
            {
                string maincategory = (string)rdr_m["name"];
                comboBoxMainCateMod.Items.Add(maincategory);
            }
            rdr_m.Close();

        }

        private void buttonWorkModSave_Click(object sender, EventArgs e)
        {
            FrmDailyAdd form2 = new FrmDailyAdd();
            ModWork();
            AddListView();
        }
        
        public void ModWork()
        {
            FrmDailyAdd form2 = new FrmDailyAdd();
            int indexnum = Convert.ToInt32(form1.listViewWorkList.FocusedItem.Text);

            string maincategory = comboBoxMainCateMod.Text;
            string middlecategory = comboBoxMiddleCateMod.Text;
            string subcategory = comboBoxSubCateMod.Text;

            int main_id = 0;
            int middle_id = 0;
            int sub_id = 0;

            string query_id = "SELECT id, maincategory_id, middlecategory_id FROM SubCategory WHERE name = '" + comboBoxSubCateMod.Text + "'";
            MySqlDataReader rdr = DailyTaskDBManager.GetInstace().Select(query_id);

            while (rdr.Read())
            {
                main_id = (int)rdr["maincategory_id"];
                middle_id = (int)rdr["middlecategory_id"];
                sub_id = (int)rdr["id"];
            }
            rdr.Close();

            string query = "UPDATE Task SET Task_maincategory_id = @main_id, Task_middlecategory_id = " +
                "@middle_id, Task_subcategory_id = @sub_id WHERE id='"+indexnum+"'";

            if (maincategory == "대분류" || middlecategory == "중분류" || subcategory == "소분류")
            {
                MessageBox.Show("항목을 수정해 주세요");
            }
            else
            {
                DailyTaskDBManager.GetInstace().Update(query, main_id, middle_id, sub_id);
                this.Close();
            }
        }
        public void AddListView()
        {
            FrmDailyAdd form2 = new FrmDailyAdd();
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
                item.SubItems.Add(Convert.ToString(workcategory.day.ToString("yyyy-MM-dd")));
                item.SubItems.Add(workcategory.start_time);
                item.SubItems.Add(workcategory.end_time);
                item.SubItems.Add(AddTaskName(workcategory.maindcategory_id, 1));
                item.SubItems.Add(AddTaskName(workcategory.middlecategory_id, 2));
                item.SubItems.Add(AddTaskName(workcategory.subcategory_id, 3));

                form1.listViewWorkList.Items.Add(item);

                i++;
            }
            form1.listViewWorkList.EndUpdate();
        }
        public string AddTaskName(int task_id, int i)
        {
            string query = "";
            string taskname = "";
            switch (i)
            {
                case 1:
                    query = "SELECT name FROM MainCategory WHERE id = '" + task_id + "'";
                    break;
                case 2:
                    query = "SELECT name FROM MiddleCategory WHERE id = '" + task_id + "'";
                    break;
                case 3:
                    query = "SELECT name FROM SubCategory WHERE id = '" + task_id + "'";
                    break;
            }
            MySqlDataReader rdr = DailyTaskDBManager.GetInstace().Select(query);

            while (rdr.Read())
            {
                taskname = (string)rdr["name"];
            }
            rdr.Close();

            return taskname;

        }

        private void comboBoxMainCateMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMiddleCateMod.Items.Clear();
            comboBoxSubCateMod.Items.Clear();
            string query = "SELECT id FROM MainCategory WHERE name = '" + comboBoxMainCateMod.Text + "'";
            MySqlDataReader rdr = DailyTaskDBManager.GetInstace().Select(query);
            int main_id = 0;
            while (rdr.Read())
            {
                main_id = (int)rdr["id"];
            }
            rdr.Close();

            string query_middle = "SELECT name FROM MiddleCategory WHERE Mid_maincategory_id = '" + main_id + "'";
            MySqlDataReader rdr_m = DailyTaskDBManager.GetInstace().Select(query_middle);
            while (rdr_m.Read())
            {
                string middlecategory = (string)rdr_m["name"];
                comboBoxMiddleCateMod.Items.Add(middlecategory);
            }
            rdr_m.Close();
        }

        private void comboBoxMiddleCateMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSubCateMod.Items.Clear();
            string query = "SELECT id, Mid_maincategory_id FROM MiddleCategory WHERE name = '" + comboBoxMiddleCateMod.Text + "'";
            MySqlDataReader rdr = DailyTaskDBManager.GetInstace().Select(query);
            int main_id = 0;
            int middle_id = 0;
            while (rdr.Read())
            {
                main_id = (int)rdr["Mid_maincategory_id"];
                middle_id = (int)rdr["id"];
            }
            rdr.Close();

            string query_sub = "SELECT name FROM SubCategory WHERE maincategory_id = '" + main_id + "' AND middlecategory_id = '" + middle_id + "'";
            MySqlDataReader rdr_m = DailyTaskDBManager.GetInstace().Select(query_sub);
            while (rdr_m.Read())
            {
                string subcategory = (string)rdr_m["name"];

                comboBoxSubCateMod.Items.Add(subcategory);
            }
            rdr_m.Close();
        }
    }
}
