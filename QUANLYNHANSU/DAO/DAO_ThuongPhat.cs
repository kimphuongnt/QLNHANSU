using QUANLYNHANSU.DBC;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAO
{
    public class DAO_ThuongPhat
    {
        DataTable dt_thuongphat;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_ThuongPhat()
        {
            dB = new DBConnection();
            dt_thuongphat = new DataTable();
            adapter = new SqlDataAdapter("select * from THUONGPHAT", dB.GetConnection());
            adapter.Fill(dt_thuongphat);
        }
        public List<DTO_ThuongPhat> getAll()
        {
            List<DTO_ThuongPhat> lst = new List<DTO_ThuongPhat>();
            foreach (DataRow row in dt_thuongphat.Rows)
            {
                DTO_ThuongPhat thuongPhat = new DTO_ThuongPhat(row["MaTP"].ToString(), row["Loai"].ToString());
                lst.Add(thuongPhat);
            }
            return lst;
        }
    }
}
