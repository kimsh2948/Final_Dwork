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
        string strConn = "Server=49.50.174.201;Database=AJW1234;Uid=AJW1234;Pwd=AJW1234!@;Charset=utf8";

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
        public void Update(string query, int maincategory, int middlecategory, int subcategory)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@main_id", maincategory);
                cmd.Parameters.AddWithValue("@middle_id", middlecategory);
                cmd.Parameters.AddWithValue("@sub_id", subcategory); 
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
