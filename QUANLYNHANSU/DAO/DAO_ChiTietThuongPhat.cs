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
    public class DAO_ChiTietThuongPhat
    {
        DataTable dt_thuongphat;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_ChiTietThuongPhat()
        {
            dB = new DBConnection();
            dt_thuongphat = new DataTable();
            adapter = new SqlDataAdapter("select * from CHITIETTHUONGPHAT", dB.GetConnection());
            adapter.Fill(dt_thuongphat);
        }
        public List<DTO_ChiTietThuongPhat> getAll()
        {
            List<DTO_ChiTietThuongPhat> lst = new List<DTO_ChiTietThuongPhat>();
            foreach (DataRow row in dt_thuongphat.Rows)
            {
                DTO_ChiTietThuongPhat thuongPhat = new DTO_ChiTietThuongPhat(row["MaCTTP"].ToString(), row["MaNV"].ToString(), row["MaTP"].ToString(),
                    float.Parse(row["Tien"].ToString()), row["LyDo"].ToString(), Convert.ToDateTime(row["Ngay"].ToString()));
                lst.Add(thuongPhat);
            }
            return lst;
        }
        public bool KiemTraTrungMa(string MaCTTP, string maNV)
        {
            dB.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CHITIETTHUONGPHAT WHERE MaCTTP = @MaCTTP", dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaCTTP", MaCTTP);

            int count = (int) cmd.ExecuteScalar();
            if (count > 0)
                return false;
            else
                return true;
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

        public bool delete(DTO_ChiTietThuongPhat chiTietThuongPhat)
        {
            DataRow[] deleterows = dt_thuongphat.Select($"MaCTTP = '{chiTietThuongPhat.MaCTTP}'");
            foreach (DataRow row in deleterows)
            {
                row.Delete();
            }
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_thuongphat);
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool insert(DTO_ChiTietThuongPhat chiTietThuongPhat)
        {
            DataRow newRow = dt_thuongphat.NewRow();
            newRow["MaCTTP"] = chiTietThuongPhat.MaCTTP;
            newRow["MaNV"] = chiTietThuongPhat.MaNV;
            newRow["MaTP"] = chiTietThuongPhat.MaTP;
            newRow["LyDo"] = chiTietThuongPhat.LyDo;
            newRow["Ngay"] = chiTietThuongPhat.Ngay;
            newRow["Tien"] = chiTietThuongPhat.Tien;

            dt_thuongphat.Rows.Add(newRow);

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_thuongphat);
            if (kq > 0)
            {
                return true;
            }
            else { return false; }
        }
        public bool update(DTO_ChiTietThuongPhat chiTietThuongPhat)
        {
            string query = "UPDATE CHITIETTHUONGPHAT SET MaTP = @matp, LyDo = @lyDo, Ngay = @ngay, Tien = @tien" +
                " where MaCTTP = @MaCTTP";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaCTTP", chiTietThuongPhat.MaCTTP);
            cmd.Parameters.AddWithValue("@matp", chiTietThuongPhat.MaTP);
            cmd.Parameters.AddWithValue("@maNV", chiTietThuongPhat.MaNV);
            cmd.Parameters.AddWithValue("@lyDo", chiTietThuongPhat.LyDo);
            cmd.Parameters.AddWithValue("@ngay", chiTietThuongPhat.Ngay);
            cmd.Parameters.AddWithValue("@TIEN", chiTietThuongPhat.Tien);
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
        public List<DTO_ChiTietThuongPhat> TimTheoNgay(DateTime ngay)
        {
            List<DTO_ChiTietThuongPhat> filterChiTietThuongPhat = new List<DTO_ChiTietThuongPhat>();

            string query = "SELECT * FROM CHITIETTHUONGPHAT WHERE CONVERT(date, Ngay) = @Ngay";
            SqlCommand command = new SqlCommand(query, dB.GetConnection());
            command.Parameters.AddWithValue("@Ngay", ngay);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                DTO_ChiTietThuongPhat cthd = new DTO_ChiTietThuongPhat(
                    row["MaCTTP"].ToString(),
                    row["MaNV"].ToString(),
                    row["MaTP"].ToString(),
                    float.Parse(row["Tien"].ToString()),
                    row["LyDo"].ToString(),
                    Convert.ToDateTime(row["Ngay"])
                );
                filterChiTietThuongPhat.Add(cthd);
            }

            return filterChiTietThuongPhat;
        }
    }
}
