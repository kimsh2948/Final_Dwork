using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DailyWork
{
    class DBManager
    {
        private static DBManager instace = new DBManager();
        string strConn = "Server=49.50.174.201;Database=s5414043;Uid=s5414043;Pwd=rlatjdgns12;Charset=utf8";

        public static DBManager GetInstace() { return instace; }
        private DBManager()
        {

        }

        public void DBquery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(string query, string maincategory, string middlecategory, string subcategory)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maincategory", maincategory);
                cmd.Parameters.AddWithValue("@middlecategory", middlecategory);
                cmd.Parameters.AddWithValue("@subcategory", subcategory);
                cmd.ExecuteNonQuery();
            }
        }
        public MySqlDataReader Select(string query)
        {
            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }
}
