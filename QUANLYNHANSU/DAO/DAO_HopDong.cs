using Microsoft.Win32.SafeHandles;
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
    public class DAO_HopDong
    {
        DataTable dt_hopdong;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_HopDong()
        {
            dB = new DBConnection();
            dt_hopdong = new DataTable();
            adapter = new SqlDataAdapter("select * from HOPDONGLAODONG", dB.GetConnection());
            adapter.Fill(dt_hopdong);
        }
        public List<DTO_HopDong> getAll()
        {
            List<DTO_HopDong> lst = new List<DTO_HopDong>();
            foreach (DataRow row in dt_hopdong.Rows)
            {
                DTO_HopDong hopDong = new DTO_HopDong(
                    row["MaHD"].ToString(),
                    row["LoaiHD"].ToString(),
                    row["MaNV"].ToString(),
                   Convert.ToDateTime(row["TuNgay"]),
                   Convert.ToDateTime(row["DenNgay"]),
                   row["TinhTrang"].ToString()
                    );
                lst.Add(hopDong);
            }
            return lst;
        }
        public string LayTenNhanVienTheoMa(string maNV)
        {
            dB.Open();
            string tenNV = string.Empty;
            SqlCommand cmd = new SqlCommand("SELECT HoTen FROM NHANVIEN WHERE MaNV = @manv", dB.GetConnection());
            cmd.Parameters.AddWithValue("@manv", maNV);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                tenNV = reader["HoTen"].ToString();
            }

            dB.Close();
            return tenNV;
        }
        public string LayNgaySinhNhanVienTheoMa(string maNV)
        {
            dB.Open();
            string ngaySinh = string.Empty;
            SqlCommand cmd = new SqlCommand("SELECT NgaySinh FROM NHANVIEN WHERE MaNV = @manv", dB.GetConnection());
            cmd.Parameters.AddWithValue("@manv", maNV);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ngaySinh = reader["NgaySinh"].ToString();
            }

            dB.Close();
            return ngaySinh;
        }
        public string LaySDTNhanVienTheoMa(string maNV)
        {
            dB.Open();
            string SDT = string.Empty;
            SqlCommand cmd = new SqlCommand("SELECT SoDienThoai FROM NHANVIEN WHERE MaNV = @manv", dB.GetConnection());
            cmd.Parameters.AddWithValue("@manv", maNV);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                SDT = reader["SoDienThoai"].ToString();
            }

            dB.Close();
            return SDT;
        }
        public string LayTenChucVu(string maNV)
        {
            dB.Open();
            string tenCV = string.Empty;
            SqlCommand cmd = new SqlCommand("SELECT CHUCVU.TenCV FROM NHANVIEN INNER JOIN CHUCVU ON NHANVIEN.MaCV = CHUCVU.MaCV WHERE NHANVIEN.MaNV = @maNV", dB.GetConnection());
            cmd.Parameters.AddWithValue("@maNV", maNV);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                tenCV = reader["TenCV"].ToString();
            }

            dB.Close();
            return tenCV;
        }
        public bool insert(DTO_HopDong hopDong)
        {
            DataRow newRow = dt_hopdong.NewRow();
            newRow["MaHD"] = hopDong.MaHD;
            newRow["MaNV"] = hopDong.MaNV;
            newRow["LoaiHD"] = hopDong.LoaiHD;
            newRow["TuNgay"] = hopDong.TuNgay;
            newRow["DenNgay"] = hopDong.DenNgay;
            newRow["TinhTrang"] = hopDong.TinhTrang;

            dt_hopdong.Rows.Add(newRow);

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_hopdong);
            if (kq > 0)
            {
                return true;
            }
            else { return false; }
        }
        public bool update(DTO_HopDong hopDong)
        {
            string query = "UPDATE HOPDONGLAODONG SET LoaiHD = @loaiHD, TuNgay = @ngayBD, DenNgay = @ngayKT" +
                " where MaHD = @maHD and MaNV = @maNV";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@maHD", hopDong.MaHD);
            cmd.Parameters.AddWithValue("@maNV", hopDong.MaNV);
            cmd.Parameters.AddWithValue("@loaiHD", hopDong.LoaiHD);
            cmd.Parameters.AddWithValue("@ngayBD", hopDong.TuNgay);
            cmd.Parameters.AddWithValue("@ngayKT", hopDong.DenNgay);
            dB.Open();
            int kq = cmd.ExecuteNonQuery();
            dB.Close();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CapNhatTinhTrang()
        {
            string query = @"
                    UPDATE HOPDONGLAODONG
                    SET TinhTrang = 
                        CASE
                            WHEN DenNgay < GETDATE() THEN N'Hết hạn'
                            ELSE N'Còn hạn'
                        END";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            int kq = cmd.ExecuteNonQuery();
            dB.Close();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool delete(DTO_HopDong hopDong)
        {
            DataRow[] deleteRows = dt_hopdong.Select($"MaHD = '{hopDong.MaHD}' AND MaNV = '{hopDong.MaNV}'");
            foreach (DataRow row in deleteRows)
            {
                row.Delete();
            }
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_hopdong);
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool KiemTraTrungMa(string maHD, string maNV)
        {
            dB.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HOPDONGLAODONG WHERE MaHD = @MaHD AND MaNV = @MaNV", dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaHD", maHD);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            int count = (int) cmd.ExecuteScalar();
            if (count > 0)
                return false;
            else
                return true;
        }
        public List<DTO_HopDong> TimHopDongTheoNgay(DateTime ngayBatDau)
        {
            List<DTO_HopDong> filterHopDong = new List<DTO_HopDong>();

            string query = "SELECT * FROM HOPDONGLAODONG WHERE CONVERT(date, TuNgay) = @NgayBatDau";
            SqlCommand command = new SqlCommand(query, dB.GetConnection());
            command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                DTO_HopDong hopDong = new DTO_HopDong(
                    row["MaHD"].ToString(),
                    row["MaNV"].ToString(),
                    row["LoaiHD"].ToString(),
                    Convert.ToDateTime(row["TuNgay"]),
                    Convert.ToDateTime(row["DenNgay"]),
                    row["TinhTrang"].ToString()
                );
                filterHopDong.Add(hopDong);
            }

            return filterHopDong;
        }
    }
}
