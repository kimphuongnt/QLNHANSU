using QUANLYNHANSU.DBC;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.DAO
{
    public class DAO_PhongBan
    {
        DataTable dt_phongban;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_PhongBan()
        {
            dB = new DBConnection();
            dt_phongban = new DataTable();
            adapter = new SqlDataAdapter("select * from PHONGBAN", dB.GetConnection());
            adapter.Fill(dt_phongban);
        }
        public bool insert(DTO_PhongBan phongBan)
        {
            DataRow newRow = dt_phongban.NewRow();
            newRow["MaPB"] = phongBan.MaPB;
            newRow["TenPB"] = phongBan.TenPB;
            newRow["DiaChi"] = phongBan.DiaChi;
            newRow["SDTPB"] = phongBan.SoDienThoai;
            dt_phongban.Rows.Add(newRow);

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_phongban);
            if (kq != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool delete(DTO_PhongBan phongBan)
        {
            DataRow[] deleteRow = dt_phongban.Select("MaPB = '" + phongBan.MaPB + "'");
            foreach (DataRow row in deleteRow)
            {
                row.Delete();
            }

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_phongban);

            if (kq != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool update(DTO_PhongBan phongBan)
        {
            DataRow updateRow = dt_phongban.Select("MaPB = '" + phongBan.MaPB + "'").FirstOrDefault();

            if (updateRow != null)
            {
                updateRow["TenPB"] = phongBan.TenPB;
                updateRow["DiaChi"] = phongBan.DiaChi;
                updateRow["SDTPB"] = phongBan.SoDienThoai;

                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                int kq = adapter.Update(dt_phongban);
                return kq != 0;
            }
            return false;
        }


        public List<DTO_PhongBan> getAll()
        {
            List<DTO_PhongBan> lst = new List<DTO_PhongBan>();
            foreach (DataRow row in dt_phongban.Rows)
            {
                DTO_PhongBan phongBan = new DTO_PhongBan(row["MaPB"].ToString(), row["TenPB"].ToString(),
                    row["DiaChi"].ToString(), row["SDTPB"].ToString());
                lst.Add(phongBan);
            }
            return lst;
        }

        public int tinhTongNhanVienTrongPhongBan(string maPB)
        {
            int soNhanVien = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NHANVIEN WHERE MaPB = @MaPB", dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaPB", maPB);
            soNhanVien = (int) cmd.ExecuteScalar();
            return soNhanVien;
        }

    }
}
