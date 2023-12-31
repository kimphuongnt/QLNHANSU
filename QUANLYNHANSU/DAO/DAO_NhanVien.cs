using QUANLYNHANSU.DBC;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QUANLYNHANSU.DAO
{
    public class DAO_NhanVien
    {
        DataTable dt_nhanvien;
        SqlDataAdapter adapter;
        private DBConnection dB;

        public DAO_NhanVien()
        {
            dB = new DBConnection();
            dt_nhanvien = new DataTable();
            adapter = new SqlDataAdapter("select * from NHANVIEN", dB.GetConnection());
            adapter.Fill(dt_nhanvien);
        }

        public List<DTO_NhanVien> getAll()
        {
            List<DTO_NhanVien> lst = new List<DTO_NhanVien>();
            foreach (DataRow row in dt_nhanvien.Rows)
            {
                DTO_NhanVien nhanVien = new DTO_NhanVien
                {
                    MaNV = row["MaNV"].ToString(),
                    MaPB = row["MaPB"].ToString(),
                    MaCV = row["MaCV"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    GioiTinh = row["GioiTinh"].ToString(),
                    CMND = row["CMND"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    QueQuan = row["QueQuan"].ToString(),
                    DanToc = row["DanToc"].ToString(),
                    MucLuong = row["MucLuong"].ToString(),
                    MaTDHV = row["MaTDHV"].ToString(),
                    Hinh = row["Hinh"] is DBNull ? null : ByteArrayToImage((byte[]) row["Hinh"]),
                    TinhTrangHonNhan = row["TTHN"].ToString(),
                    MaNguoiQuanLy = row["MaNQL"].ToString()
                };
                lst.Add(nhanVien);

            }

            return lst;
        }

        byte[] ImageToArry(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        public bool themAnh(string maNV, Image img)
        {
            byte[] hinh = ImageToArry(img);
            SqlCommand cmd = new SqlCommand("UPDATE NHANVIEN SET HINH = @hinh WHERE MaNV = @MaNV;", dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@hinh", hinh);
            int kq = cmd.ExecuteNonQuery();

            if (kq != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool kiemTraQuanLy(string nhanVien)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from NHANVIEN where MaNQL = @MaNV", dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaNV", nhanVien);
            int kq = (int) cmd.ExecuteScalar();

            if (kq == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool delete(DTO_NhanVien nhanVien)
        {
            DataRow[] deleterow = dt_nhanvien.Select("MaNV='" + nhanVien.MaNV + "'");
            foreach (DataRow row in deleterow)
            {
                row.Delete();
            }
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_nhanvien);

            if (kq != 0)
                return true;
            else
                return false;
        }
        public bool insert(DTO_NhanVien nhanVien)
        {
            DataRow newRow = dt_nhanvien.NewRow();
            newRow["MaNV"] = nhanVien.MaNV;
            newRow["MaPB"] = nhanVien.MaPB;
            newRow["MaCV"] = nhanVien.MaCV;
            newRow["HoTen"] = nhanVien.HoTen;
            newRow["NgaySinh"] = nhanVien.NgaySinh;
            newRow["GioiTinh"] = nhanVien.GioiTinh;
            newRow["CMND"] = nhanVien.CMND;
            newRow["SoDienThoai"] = nhanVien.SoDienThoai;
            newRow["QueQuan"] = nhanVien.QueQuan;
            newRow["DanToc"] = nhanVien.DanToc;
            newRow["MucLuong"] = nhanVien.MucLuong;
            newRow["MaTDHV"] = nhanVien.MaTDHV;
            newRow["TTHN"] = nhanVien.TinhTrangHonNhan;
            if (nhanVien.Hinh != null)
            {
                newRow["Hinh"] = ImageToArry(nhanVien.Hinh);
            }
            else
            {
                newRow["Hinh"] = DBNull.Value;
            }

            if (nhanVien.MaNguoiQuanLy != null)
            {
                newRow["MaNQL"] = nhanVien.MaNguoiQuanLy;
            }
            else
            {
                newRow["MaNQL"] = DBNull.Value;
            }

            dt_nhanvien.Rows.Add(newRow);

            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            int kq = adapter.Update(dt_nhanvien);
            if (kq > 0)
                return true;
            else
                return false;
        }


        public bool update(DTO_NhanVien nhanVien)
        {
            string query = "UPDATE NHANVIEN SET MaPB = @MaPB, MaCV = @MaCV, HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, CMND = @CMND, SoDienThoai = @SoDienThoai, QueQuan = @QueQuan, DanToc = @DanToc, MucLuong = @MucLuong, MaTDHV = @MaTDHV, TTHN = @TinhTrangHonNhan, MaNQL = @MaNguoiQuanLy";

            if (nhanVien.Hinh != null)
            {
                query += ", Hinh = @Hinh";
            }

            query += " WHERE MaNV = @MaNV";

            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
            cmd.Parameters.AddWithValue("@MaPB", nhanVien.MaPB);
            cmd.Parameters.AddWithValue("@MaCV", nhanVien.MaCV);
            cmd.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
            cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
            cmd.Parameters.AddWithValue("@CMND", nhanVien.CMND);
            cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
            cmd.Parameters.AddWithValue("@QueQuan", nhanVien.QueQuan);
            cmd.Parameters.AddWithValue("@DanToc", nhanVien.DanToc);
            cmd.Parameters.AddWithValue("@MucLuong", nhanVien.MucLuong);
            cmd.Parameters.AddWithValue("@MaTDHV", nhanVien.MaTDHV);
            cmd.Parameters.AddWithValue("@TinhTrangHonNhan", nhanVien.TinhTrangHonNhan);

            if (nhanVien.MaNguoiQuanLy != null)
            {
                cmd.Parameters.AddWithValue("@MaNguoiQuanLy", nhanVien.MaNguoiQuanLy);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MaNguoiQuanLy", DBNull.Value);
            }

            if (nhanVien.Hinh != null)
            {
                cmd.Parameters.AddWithValue("@Hinh", ImageToArry(nhanVien.Hinh));
            }

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

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                return Image.FromStream(stream);
            }
        }

        public List<DTO_NhanVien> layPhongBanCBO(string maPB)
        {
            dB.Open();
            List<DTO_NhanVien> lst = new List<DTO_NhanVien>();
            SqlCommand cmd = new SqlCommand("Select * from NHANVIEN where MaPB = @phongban", dB.GetConnection());
            cmd.Parameters.AddWithValue("@phongban", maPB);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DTO_NhanVien nhanVien = new DTO_NhanVien
                {
                    MaNV = reader["MaNV"].ToString(),
                    MaPB = reader["MaPB"].ToString(),
                    MaCV = reader["MaCV"].ToString(),
                    HoTen = reader["HoTen"].ToString(),
                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                    GioiTinh = reader["GioiTinh"].ToString(),
                    CMND = reader["CMND"].ToString(),
                    SoDienThoai = reader["SoDienThoai"].ToString(),
                    QueQuan = reader["QueQuan"].ToString(),
                    DanToc = reader["DanToc"].ToString(),
                    MucLuong = reader["MucLuong"].ToString(),
                    MaTDHV = reader["MaTDHV"].ToString(),
                    TinhTrangHonNhan = reader["TTHN"].ToString(),
                    MaNguoiQuanLy = reader["MaNQL"].ToString(),
                    Hinh = reader["Hinh"] is DBNull ? null : ByteArrayToImage((byte[]) reader["Hinh"])
                };
                lst.Add(nhanVien);
            }

            dB.Close();
            return lst;
        }

        public bool KiemTraTrungMa(string maNV)
        {
            dB.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV", dB.GetConnection());
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            int count = (int) cmd.ExecuteScalar();
            if (count > 0)
                return false;
            else
                return true;
        }
    }
}










