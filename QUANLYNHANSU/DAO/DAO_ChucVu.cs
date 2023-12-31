using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QUANLYNHANSU.DBC;
using QUANLYNHANSU.DTO;

namespace QUANLYNHANSU.DAO
{
    public class DAO_ChucVu
    {
        DataTable dt_chucvu;
        SqlDataAdapter adapter;
        private DBConnection dB;

        public DAO_ChucVu()
        {
            dB = new DBConnection();
            dt_chucvu = new DataTable();
            adapter = new SqlDataAdapter("select * from CHUCVU", dB.GetConnection());
            adapter.Fill(dt_chucvu);
        }
        public List<DTO_ChucVu> getAll()
        {
            List<DTO_ChucVu> lst = new List<DTO_ChucVu>();
            foreach (DataRow row in dt_chucvu.Rows)
            {
                DTO_ChucVu chucVu = new DTO_ChucVu(row["MaCV"].ToString(), row["TenCV"].ToString());
                lst.Add(chucVu);
            }
            return lst;
        }
        //public string layTenChucVuTuMa(string maChucVu)
        //{
        //    string query = "select TenCV from CHUCVU where MaCV = @MaCV";
        //    SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
        //    cmd.Parameters.AddWithValue("@MaCV", maChucVu);
        //    object kq = cmd.ExecuteScalar();
        //    if (kq != null)
        //    {
        //        return kq.ToString();
        //    }

        //    { return ""; }
        //}
    }
}
