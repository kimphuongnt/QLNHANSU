using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QUANLYNHANSU.DBC
{
    public class DBConnection
    {
        public static string conStr = "Data Source=ACER\\FUANG;Initial Catalog=QL_NHANSU;Integrated Security=True";
        public SqlConnection conn = new SqlConnection();
        public DBConnection()
        {
            conn = new SqlConnection(conStr);
        }
        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            Open();
            return conn;
        }
    }
}
