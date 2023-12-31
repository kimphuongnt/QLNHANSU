using QUANLYNHANSU.DBC;
using QUANLYNHANSU.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAO
{
    public class DAO_TinhLuong
    {
        DataTable dt_tinhluong;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_TinhLuong()
        {
            dB = new DBConnection();
            dt_tinhluong = new DataTable();
            adapter = new SqlDataAdapter("select * from TINHLUONG", dB.GetConnection());
            adapter.Fill(dt_tinhluong);
        }
        public List<DTO_TinhLuong> getAll()
        {
            List<DTO_TinhLuong> lst = new List<DTO_TinhLuong>();
            foreach (DataRow row in dt_tinhluong.Rows)
            {
                DTO_TinhLuong tinhLuong = new DTO_TinhLuong();
                tinhLuong.MaNV = row["MaNV"].ToString();
                int songaycong;
                if (int.TryParse(row["SoNgayCong"].ToString(), out songaycong))
                {
                    tinhLuong.SoNgayCong = songaycong;
                }
                else
                {
                    tinhLuong.SoNgayCong = 0;
                }
                float tienThuongPhat;
                if (float.TryParse(row["TienThuongPhat"].ToString(), out tienThuongPhat))
                {
                    tinhLuong.TienThuongPhat = tienThuongPhat;
                }
                else
                {
                    tinhLuong.TienThuongPhat = 0.0f;
                }

                int thang;
                if (int.TryParse(row["Thang"].ToString(), out thang))
                {
                    tinhLuong.Thang = thang;
                }
                else
                {
                    tinhLuong.Thang = 0;
                }

                int nam;
                if (int.TryParse(row["Nam"].ToString(), out nam))
                {
                    tinhLuong.Nam = nam;
                }
                else
                {
                    tinhLuong.Nam = 0;
                }

                float tongLuong;
                if (float.TryParse(row["TongLuong"].ToString(), out tongLuong))
                {
                    tinhLuong.Tongluong = tongLuong;
                }
                else
                {
                    tinhLuong.Tongluong = 0.0f;
                }

                lst.Add(tinhLuong);
            }
            return lst;
        }
        public void TinhNgayCong(string maNV, int thang, int nam)
        {
            SqlCommand cmd = new SqlCommand("TinhNgayCong", dB.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            dB.Open();
            cmd.ExecuteNonQuery();
            dB.Close();
        }
        public bool TinhTienThuongPhat(string maNV, int thang, int nam)
        {
            string query = "UPDATE TINHLUONG SET TienThuongPhat = dbo.fn_TongTienThuongPhat(MaNV, Thang, Nam)";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
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
        public float TinhTongLuong(string maNV, int thang, int nam)
        {
            TinhNgayCong(maNV, thang, nam);
            string procedureName = "TinhTongLuong";

            SqlCommand cmd = new SqlCommand(procedureName, dB.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            dB.Open();
            cmd.ExecuteNonQuery();
            dB.Close();

            float tongLuong = LayTongLuong(maNV, thang, nam);

            return tongLuong;

        }
        private float LayTongLuong(string maNV, int thang, int nam)
        {
            string query = "SELECT ISNULL(TongLuong, 0) FROM TINHLUONG WHERE MaNV = @MaNV AND Thang = @Thang AND Nam = @Nam";

            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@Thang", thang);
            cmd.Parameters.AddWithValue("@Nam", nam);

            dB.Open();
            object result = cmd.ExecuteScalar();
            dB.Close();

            float tongLuong = Convert.ToSingle(result);

            return tongLuong;
        }
        public bool insert(DTO_TinhLuong tinhLuong)
        {
            string insertsql = "INSERT INTO TINHLUONG (MaNV, Thang, Nam) VALUES (@MaNV, @Thang, @Nam)";

            SqlCommand cmd = new SqlCommand(insertsql, dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaNV", tinhLuong.MaNV);
            cmd.Parameters.AddWithValue("@Thang", tinhLuong.Thang);
            cmd.Parameters.AddWithValue("@Nam", tinhLuong.Nam);

            dB.Open();
            int kq = cmd.ExecuteNonQuery();
            dB.Close();

            if (kq > 0)
            {
                bool kqTinhTienThuongPhat = TinhTienThuongPhat(tinhLuong.MaNV, tinhLuong.Thang, tinhLuong.Nam);

                return kqTinhTienThuongPhat;
            }
            else
            {
                return false;
            }
        }
        public string LayTenNhanVienTheoMa(string maNV)
        {

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
        public bool updateNutTinhLuong(string maNV, int thang, int nam, int soNgayCong, float tienThuongPhat, float tongLuong)
        {
            string updateQuery = "UPDATE TINHLUONG " +
                                 "SET SoNgayCong = @SoNgayCong, TienThuongPhat = @TienThuongPhat, TongLuong = @TongLuong " +
                                 "WHERE MaNV = @MaNV AND Thang = @Thang AND Nam = @Nam";

            SqlCommand updateCmd = new SqlCommand(updateQuery, dB.GetConnection());

            updateCmd.Parameters.AddWithValue("@MaNV", maNV);
            updateCmd.Parameters.AddWithValue("@Thang", thang);
            updateCmd.Parameters.AddWithValue("@Nam", nam);
            updateCmd.Parameters.AddWithValue("@SoNgayCong", soNgayCong);
            updateCmd.Parameters.AddWithValue("@TienThuongPhat", tienThuongPhat);
            updateCmd.Parameters.AddWithValue("@TongLuong", tongLuong);

            int kqupdate = updateCmd.ExecuteNonQuery();
            if (kqupdate > 0)
                return true;
            else
                return false;
        }
        public bool delete(DTO_TinhLuong tl)
        {
            DataRow[] deleterows = dt_tinhluong.Select($"MaNV = '{tl.MaNV}' AND Thang = {tl.Thang} AND Nam = {tl.Nam}");
            foreach (DataRow row in deleterows)
            {
                row.Delete();
            }
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_tinhluong);
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool update(DTO_TinhLuong tinhLuong)
        {
            string query = "UPDATE TINHLUONG " +
                           "SET SoNgayCong = @SoNgayCong, TienThuongPhat = @TienThuongPhat, TongLuong = @TongLuong " +
                           "WHERE MaNV = @MaNV AND Thang = @Thang AND Nam = @Nam";

            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());

            cmd.Parameters.AddWithValue("@MaNV", tinhLuong.MaNV);
            cmd.Parameters.AddWithValue("@Thang", tinhLuong.Thang);
            cmd.Parameters.AddWithValue("@Nam", tinhLuong.Nam);
            cmd.Parameters.AddWithValue("@SoNgayCong", tinhLuong.SoNgayCong);
            cmd.Parameters.AddWithValue("@TienThuongPhat", tinhLuong.TienThuongPhat);
            cmd.Parameters.AddWithValue("@TongLuong", tinhLuong.Tongluong);

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
    }
}
