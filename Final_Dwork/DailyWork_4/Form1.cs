using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyWork
{
    public partial class Form1 : Form
    {

        public Form1()
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
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        private void buttonWorkMod_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
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
            Form2 form2 = new Form2();
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
                item.SubItems.Add(workcategory.day);
                item.SubItems.Add(workcategory.start_time);
                item.SubItems.Add(workcategory.end_time);
                item.SubItems.Add(workcategory.MainCategory);
                item.SubItems.Add(workcategory.MiddleCategory);
                item.SubItems.Add(workcategory.SubCategory);

                listViewWorkList.Items.Add(item);
                i++;
            }
            listViewWorkList.EndUpdate();
        }

        private void buttonWorkDel_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            int indexnum = Convert.ToInt32(listViewWorkList.FocusedItem.Text);
            if (MessageBox.Show("선택하신 업무가 삭제됩니다", "업무 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM dailywork WHERE id = '" + indexnum + "'";
                DBManager.GetInstace().DBquery(query);
                DelList(indexnum);
            }
            else
            {
                MessageBox.Show("삭제를 취소하셨습니다.");
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
            Form4 form4 = new Form4(this);
            form4.Show();
        }
    }
}
