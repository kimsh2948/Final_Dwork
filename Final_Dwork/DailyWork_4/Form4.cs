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
    public partial class Form4 : Form
    {
        Form1 form1;

        public Form4()
        {
            InitializeComponent();
            this.buttonWorkSerchOn.Click += buttonWorkSerchOn_Click;
        }
        public Form4(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void buttonWorkSerchOn_Click(object sender, EventArgs e)
        {
            SearchWork();
        }

        public void SearchWork()
        {
            if (form1.listViewWorkList.Items.Count > 0)
                {
                    form1.listViewWorkList.Items.Clear();
                }
            Form2 form2 = new Form2();
            int i = 0;
            List<WorkCategory> worklist = SearchLoad();

            form1.listViewWorkList.BeginUpdate();
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

                form1.listViewWorkList.Items.Add(item);
                i++;
            }
            form1.listViewWorkList.EndUpdate();
            if (form1.listViewWorkList.Items.Count == 0)
                MessageBox.Show("검색결과가 없습니다.");
            else
                this.Close();
        }
        public List<WorkCategory> SearchLoad()
        {
            List<WorkCategory> worklist = new List<WorkCategory>();

            string keyword = textBoxInputKeyword.Text;

            string query = "SELECT * FROM dailywork WHERE Day LIKE'%" + keyword + "%' " +
                "OR MainCategory LIKE'%" + keyword + "%' OR MiddleCategory LIKE'%" + keyword + "%' OR SubCategory LIKE'%" + keyword + "%'";
            //OR WHERE MiddleCategory = '" + keyword + "' OR WHERE SubCategory = '" + keyword + "'
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
    }
}
