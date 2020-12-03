using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DailyWork
{
    public partial class Form2 : Form
    {
        Form1 form1;

        public Form2()
        {
            InitializeComponent();
            InitVariables();
            initWork();
            this.buttonWorkRegSave.Click += buttonWorkRegSave_Click;
        }
        public Form2(Form1 form)
        {
            InitializeComponent();
            InitVariables();
            initWork();
            form1 = form;
        }

        public void InitVariables()
        {
            this.dateTimePickerInsertWork.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerInsertWork.CustomFormat = "yyyy-MM-dd";

            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.CustomFormat = "HH:mm";

            this.dateTimePickerEndTime.ShowUpDown = true;
            this.dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.CustomFormat = "HH:mm";

        }
        public void initWork()
        {
            /*
            string query = "SELECT MainCategory.name, MiddleCategory.name FROM MainCategory " +
                "join MiddleCategory ON MainCategory.id = MiddleCategory.Mid_maincategory_id;";
            */
            string query_main = "SELECT name FROM MainCategory";
            MySqlDataReader rdr_m = DBManager.GetInstace().Select(query_main);
            while (rdr_m.Read())
            {
                string maincategory = (string)rdr_m["name"];
                comboBoxMainCate.Items.Add(maincategory);
            }
            rdr_m.Close();

        }
        private void comboBoxMainCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMiddleCate.Items.Clear();
            comboBoxSubCate.Items.Clear();
            string query = "SELECT id FROM MainCategory WHERE name = '" + comboBoxMainCate.Text + "'";
            MySqlDataReader rdr = DBManager.GetInstace().Select(query);
            int main_id = 0;
            while (rdr.Read())
            {
                main_id = (int)rdr["id"];
            }
            rdr.Close();

            string query_middle = "SELECT name FROM MiddleCategory WHERE Mid_maincategory_id = '" + main_id + "'";
            MySqlDataReader rdr_m = DBManager.GetInstace().Select(query_middle);
            while (rdr_m.Read())
            {
                string middlecategory = (string)rdr_m["name"];
                comboBoxMiddleCate.Items.Add(middlecategory);
            }
            rdr_m.Close();
        }
        private void comboBoxMiddleCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSubCate.Items.Clear();
            string query = "SELECT id, Mid_maincategory_id FROM MiddleCategory WHERE name = '" + comboBoxMiddleCate.Text + "'";
            MySqlDataReader rdr = DBManager.GetInstace().Select(query);
            int main_id = 0;
            int middle_id = 0;
            while (rdr.Read())
            {
                main_id = (int)rdr["Mid_maincategory_id"];
                middle_id = (int)rdr["id"];
            }
            rdr.Close();

            string query_sub = "SELECT name FROM SubCategory WHERE maincategory_id = '" + main_id + "' AND middlecategory_id = '"+middle_id+"'";
            MySqlDataReader rdr_m = DBManager.GetInstace().Select(query_sub);
            while (rdr_m.Read())
            {
                string subcategory = (string)rdr_m["name"];

                comboBoxSubCate.Items.Add(subcategory);
            }
            rdr_m.Close();
        }
        private void buttonWorkRegSave_Click(object sender, EventArgs e)
        {
            AddWork();
            AddListView(); 
        }
        public void AddWork()
        {
            var day = dateTimePickerInsertWork.Value.ToString("yyyy-MM-dd");
            var start_time = dateTimePickerStartTime.Text;
            var end_time = dateTimePickerEndTime.Text;
            var maincategory = comboBoxMainCate.Text;
            var middlecategory = comboBoxMiddleCate.Text;
            var subcategory = comboBoxSubCate.Text;

            int main_id = 0;
            int middle_id = 0;
            int sub_id = 0;

            string query_id = "SELECT id, maincategory_id, middlecategory_id FROM SubCategory WHERE name = '" + comboBoxSubCate.Text + "'";
            MySqlDataReader rdr = DBManager.GetInstace().Select(query_id);

            while (rdr.Read())
            {
                main_id = (int)rdr["maincategory_id"];
                middle_id = (int)rdr["middlecategory_id"];
                sub_id = (int)rdr["id"];
            }
            rdr.Close();

            string query = "INSERT INTO Task(Task_maincategory_id, Task_middlecategory_id, Task_subcategory_id, taskstarttime, taskendtime, date) " +
                "VALUES('" + main_id + "', '" + middle_id + "','" + sub_id + "','" + start_time + "','" + end_time + "','" + day + "')";
            if (maincategory == "대분류" || middlecategory == "중분류" || subcategory == "소분류")//세가지 모두 선택해야 저장
            {
                MessageBox.Show("모든 항목을 선택하세요");
            }
            else
            {
                TimeOverlap(query);
            }
        }

        public List<WorkCategory> LoadWork()
        {
            List<WorkCategory> worklist = new List<WorkCategory>();

            string query = "SELECT * FROM Task";
            MySqlDataReader rdr = DBManager.GetInstace().Select(query);
            while (rdr.Read())
            {
                WorkCategory workcategory = new WorkCategory();
                workcategory.id = (int)rdr["id"];
                workcategory.maindcategory_id = (int)rdr["Task_maincategory_id"];
                workcategory.middlecategory_id = (int)rdr["Task_middlecategory_id"];
                workcategory.subcategory_id = (int)rdr["Task_subcategory_id"];
                workcategory.start_time = (string)rdr["taskstarttime"];
                workcategory.end_time = (string)rdr["taskendtime"];
                workcategory.day = Convert.ToString((DateTime)rdr["date"]);
                //workcategory.day = (string)rdr["date"];

                worklist.Add(workcategory);
            }
            rdr.Close();
            return worklist;
        }

        public void AddListView()
        {
            if (form1.listViewWorkList.Items.Count > 0)//listview에 아이템 있으면 지우고 로드
            {
                form1.listViewWorkList.Items.Clear();
            }
            List<WorkCategory> worklist = LoadWork();
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
                    query = "SELECT name FROM MainCategory WHERE id = '"+task_id+"'";
                    break;
                case 2:
                    query = "SELECT name FROM MiddleCategory WHERE id = '" + task_id + "'";
                    break;
                case 3:
                    query = "SELECT name FROM SubCategory WHERE id = '" + task_id + "'";
                    break;
            }
            MySqlDataReader rdr = DBManager.GetInstace().Select(query);

            while (rdr.Read())
            {
                taskname = (string)rdr["name"];
            }
            rdr.Close();

            return taskname;

        }
        public void TimeOverlap(string query)
        {
            int start_hour = dateTimePickerStartTime.Value.Hour;
            int end_hour = dateTimePickerEndTime.Value.Hour;
            int start_minute = dateTimePickerStartTime.Value.Minute;
            int end_minute = dateTimePickerEndTime.Value.Minute;

            List<WorkCategory> worklist = LoadWork();

            int i = 0;
            int j = 0;
            while (i < worklist.Count)//listview에 삽입
            {
                WorkCategory workcategory = new WorkCategory();
                workcategory = worklist[i];
                DateTime work_start_time = Convert.ToDateTime(workcategory.start_time);
                DateTime work_end_time = Convert.ToDateTime(workcategory.end_time);

                //등록 시간이 시작 시간과 종료시간 사이일때
                if (start_hour > work_start_time.Hour && start_hour < work_end_time.Hour)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (end_hour > work_start_time.Hour && end_hour < work_end_time.Hour)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (start_hour >= work_start_time.Hour && start_hour < work_end_time.Hour && start_minute > work_start_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (start_hour > work_start_time.Hour && start_hour <= work_end_time.Hour && start_minute < work_end_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (end_hour >= work_start_time.Hour && end_hour < work_end_time.Hour && end_minute > work_start_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (end_hour > work_start_time.Hour && end_hour <= work_end_time.Hour && end_minute < work_end_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (start_hour == work_start_time.Hour && start_minute >= work_start_time.Minute && start_hour != work_end_time.Hour)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (start_hour == work_end_time.Hour && start_minute <= work_end_time.Minute && start_hour != work_start_time.Hour)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (start_hour == work_start_time.Hour && start_hour == work_end_time.Hour && start_minute >= work_start_time.Minute && start_minute <= work_end_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (start_hour == work_start_time.Hour && start_hour == work_end_time.Hour && end_hour == work_end_time.Hour && end_minute <= work_end_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }
                else if (end_hour == work_start_time.Hour && end_hour == work_end_time.Hour && end_hour == work_end_time.Hour && end_minute >= work_start_time.Minute && end_minute <= work_end_time.Minute)
                {
                    MessageBox.Show("다른 업무가 있습니다! 등록 할 수 없습니다.");
                    j = 1;
                    this.Close();
                    break;
                }

                i++;
            }
            if(j == 1)
            {
                this.Close();
            }
            else
            {
                DBManager.GetInstace().DBquery(query);
                this.Close();

            }

        }

    }
}
