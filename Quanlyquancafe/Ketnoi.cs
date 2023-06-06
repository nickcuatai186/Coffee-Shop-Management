using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quanlyquancafe
{
    public class Ketnoi
    {
        private string connectString = @"Data Source = LAPTOP-HSCJSNH7\SQLEXPRESS;
            Initial Catalog = Quanlyquancafe;Integrated Security = True";
        public SqlConnection getConnect()
        {
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            return conn;
        }
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection ketnoi = new SqlConnection(connectString))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                data = thucthi.ExecuteNonQuery();
                ketnoi.Close();
            }
            return data;
        }
        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection ketnoi = new SqlConnection(connectString))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                SqlDataAdapter laydulieu = new SqlDataAdapter(thucthi);
                laydulieu.Fill(dt);
                ketnoi.Close();
            }
            return dt;
        }
    }
}
