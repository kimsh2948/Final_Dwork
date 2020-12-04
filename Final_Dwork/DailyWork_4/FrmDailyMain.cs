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
    public partial class FrmDailyMain : Form
    {

        public FrmDailyMain()
        {
            InitializeComponent();
            InitListView();
        }
        public void InitListView()
        {
            listViewWorkList.View = View.Details;
            listViewWorkList.GridLines = true;
            listViewWorkList.FullRowSelect = true;

            listViewWorkList.Columns.Add("번호", 40);
            listViewWorkList.Columns.Add("날짜", 93);
            listViewWorkList.Columns.Add("시작 시간", 93);
            listViewWorkList.Columns.Add("종료 시간", 93);
            listViewWorkList.Columns.Add("대분류", 93);
            listViewWorkList.Columns.Add("중분류", 93);
            listViewWorkList.Columns.Add("소분류", 93);
        }

        private void buttonWorkReg_Click(object sender, EventArgs e)
        {
            FrmDailyAdd form2 = new FrmDailyAdd(this);
            form2.Show();
        }
        private void buttonWorkMod_Click(object sender, EventArgs e)
        {
            FrmDailyMod form3 = new FrmDailyMod(this);
            if (listViewWorkList.SelectedIndices.Count > 0)
            {
                form3.Show();
            }
            else
            {
                MessageBox.Show("항목을 선택해 주세요");
            }

        }

        private void buttonLoadWorkList_Click(object sender, EventArgs e)
        {
            FrmDailyAdd form2 = new FrmDailyAdd();
            int i = 0;
            List<WorkCategory> worklist = form2.LoadWork();
            if (listViewWorkList.Items.Count > 0) {
                listViewWorkList.Items.Clear();
            }
            listViewWorkList.BeginUpdate();
            ListViewItem item;
            while (i < worklist.Count)
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

                listViewWorkList.Items.Add(item);
                i++;
            }
            listViewWorkList.EndUpdate();
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

        private void buttonWorkDel_Click(object sender, EventArgs e)
        {
            FrmDailyAdd form2 = new FrmDailyAdd();
            int indexnum = 0;
            if (listViewWorkList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("항목을 선택해 주세요");
            }
            else
            {
                if (MessageBox.Show("선택하신 업무가 삭제됩니다", "업무 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    indexnum = Convert.ToInt32(listViewWorkList.FocusedItem.Text);
                    string query = "DELETE FROM Task WHERE id = '" + indexnum + "'";
                    DailyTaskDBManager.GetInstace().DBquery(query);
                    DelList(indexnum);
                }
                else
                {
                    MessageBox.Show("삭제를 취소하셨습니다.");
                }
            }

        }
        public void DelList(int indexnum)
        {
            listViewWorkList.BeginUpdate();
            listViewWorkList.FocusedItem.Remove();
            listViewWorkList.EndUpdate();
        }

        private void buttonWorkSerch_Click(object sender, EventArgs e)
        {
            FrmDailySearch form4 = new FrmDailySearch(this);
            form4.Show();
        }
    }
}
