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
    public class DAO_Luong
    {
        DataTable dt_luong;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_Luong()
        {
            dB = new DBConnection();
            dt_luong = new DataTable();
            adapter = new SqlDataAdapter("select * from LUONG", dB.GetConnection());
            adapter.Fill(dt_luong);
        }
        public List<DTO_Luong> getAll()
        {
            List<DTO_Luong> lst = new List<DTO_Luong>();
            foreach (DataRow row in dt_luong.Rows)
            {
                DTO_Luong luong = new DTO_Luong(row["MucLuong"].ToString(), float.Parse(row["LuongCB"].ToString()));
                lst.Add(luong);
            }
            return lst;
        }
    }
}
