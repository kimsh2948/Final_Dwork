﻿using System;
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
                item.SubItems.Add(AddTaskName(workcategory.maindcategory_id, 1));
                item.SubItems.Add(AddTaskName(workcategory.middlecategory_id, 2));
                item.SubItems.Add(AddTaskName(workcategory.subcategory_id, 3));

                form1.listViewWorkList.Items.Add(item);
                i++;
            }
            form1.listViewWorkList.EndUpdate();
            if (form1.listViewWorkList.Items.Count == 0)
                MessageBox.Show("검색결과가 없습니다.");
            else
                this.Close();
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
            MySqlDataReader rdr = DBManager.GetInstace().Select(query);

            while (rdr.Read())
            {
                taskname = (string)rdr["name"];
            }
            rdr.Close();

            return taskname;

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
                workcategory.maindcategory_id = (int)rdr["Task_maincategory_id"];
                workcategory.middlecategory_id = (int)rdr["Task_middlecategory_id"];
                workcategory.subcategory_id = (int)rdr["Task_subcategory_id"];
                workcategory.start_time = (string)rdr["taskstarttime"];
                workcategory.end_time = (string)rdr["taskendtime"];
                workcategory.day = (string)rdr["date"];

                worklist.Add(workcategory);
            }
            rdr.Close();
            return worklist;
        }
    }
}
