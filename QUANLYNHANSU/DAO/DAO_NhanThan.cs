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
    public class DAO_NhanThan
    {
        DataTable dt_nhanthan;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_NhanThan()
        {
            dB = new DBConnection();
            dt_nhanthan = new DataTable();
            adapter = new SqlDataAdapter("select * from THONGTINNHANTHAN", dB.GetConnection());
            adapter.Fill(dt_nhanthan);
        }
        public List<DTO_NhanThan> getAll()
        {
            List<DTO_NhanThan> lst = new List<DTO_NhanThan>();
            foreach (DataRow row in dt_nhanthan.Rows)
            {
                DTO_NhanThan nhanThan = new DTO_NhanThan(
                    row["MaNT"].ToString(), row["MaNV"].ToString(), row["Ten"].ToString(), row["QuanHe"].ToString(),
                    Convert.ToDateTime(row["NgaySinh"].ToString()), row["SoDienThoai"].ToString(), row["NgheNghiep"].ToString());
                lst.Add(nhanThan);
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
        public bool KiemTraTrungMa(string maNT, string maNV)
        {
            dB.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from THONGTINNHANTHAN where MaNT = @maNT and MaNV = @maNV", dB.GetConnection());
            cmd.Parameters.AddWithValue("@maNT", maNT);
            cmd.Parameters.AddWithValue("@maNV", maNV);

            int count = (int) cmd.ExecuteScalar();
            if (count > 0)
            {
                return false;
            }
            else
                return true;
        }
        public bool insert(DTO_NhanThan nhanThan)
        {
            DataRow row = dt_nhanthan.NewRow();
            row["MaNT"] = nhanThan.MaNT;
            row["MaNV"] = nhanThan.MaNV;
            row["Ten"] = nhanThan.Ten;
            row["QuanHe"] = nhanThan.QuanHe;
            row["NgaySinh"] = nhanThan.NgaySinh;
            row["SoDienThoai"] = nhanThan.SoDienThoai;
            row["NgheNghiep"] = nhanThan.NgheNghiep;

            dt_nhanthan.Rows.Add(row);

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_nhanthan);
            if (kq > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool update(DTO_NhanThan nhanThan)
        {
            string query = "update THONGTINNHANTHAN set Ten = @tennt, QuanHe = @quanhe, " +
                "NgaySinh = @ngaysinh, SoDienThoai = @sodienthoai, NgheNghiep = @nghenghiep " +
                "where MaNT = @mant and MaNV = @manv ";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@mant", nhanThan.MaNT);
            cmd.Parameters.AddWithValue("@manv", nhanThan.MaNV);
            cmd.Parameters.AddWithValue("@tennt", nhanThan.Ten);
            cmd.Parameters.AddWithValue("@quanhe", nhanThan.QuanHe);
            cmd.Parameters.AddWithValue("@ngaysinh", nhanThan.NgaySinh);
            cmd.Parameters.AddWithValue("@sodienthoai", nhanThan.SoDienThoai);
            cmd.Parameters.AddWithValue("@nghenghiep", nhanThan.NgheNghiep);

            dB.Open();
            int kq = cmd.ExecuteNonQuery();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool delete(DTO_NhanThan nhanThan)
        {
            DataRow[] deleterow = dt_nhanthan.Select($"MaNT = '{nhanThan.MaNT}' and MaNV = '{nhanThan.MaNV}'");
            foreach(DataRow row in deleterow)
            {
                row.Delete();
            }
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_nhanthan);
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
