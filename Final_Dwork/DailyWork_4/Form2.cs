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
            this.buttonWorkRegSave.Click += buttonWorkRegSave_Click;
        }
        public Form2(Form1 form)
        {
            InitializeComponent();
            InitVariables();
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
        private void buttonWorkRegSave_Click(object sender, EventArgs e)
        {
            AddWork();
            AddListView(); 
        }
        public void AddWork()
        {
            var day = dateTimePickerInsertWork.Text;
            var start_time = dateTimePickerStartTime.Text;
            var end_time = dateTimePickerEndTime.Text;
            var maincategory = comboBoxMainCate.Text;
            var middlecategory = comboBoxMiddleCate.Text;
            var subcategory = comboBoxSubCate.Text;
            string query = "INSERT INTO dailywork(Day, StartTime, EndTime, MainCategory, MiddleCategory, SubCategory) " +
                "VALUES('" + day + "','" + start_time + "','" + end_time + "','" + maincategory + "', '" + middlecategory + "','" + subcategory + "')";
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

            string query = "SELECT * FROM dailywork";
            MySqlDataReader rdr = DBManager.GetInstace().Select(query);
            while (rdr.Read())
            {
                WorkCategory workcategory = new WorkCategory();
                workcategory.id = (int)rdr["id"];
                workcategory.day = (string)rdr["Day"];
                workcategory.start_time = (string)rdr["StartTime"];
                workcategory.end_time = (string)rdr["EndTime"];
                workcategory.MainCategory = (string)rdr["MainCategory"];
                workcategory.MiddleCategory = (string)rdr["MiddleCategory"];
                workcategory.SubCategory = (string)rdr["SubCategory"];

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
                item.SubItems.Add(workcategory.MainCategory);
                item.SubItems.Add(workcategory.MiddleCategory);
                item.SubItems.Add(workcategory.SubCategory);

                form1.listViewWorkList.Items.Add(item);

                i++;
            }
            form1.listViewWorkList.EndUpdate();
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
