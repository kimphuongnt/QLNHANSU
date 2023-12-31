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
    public class DAO_DangNhap
    {
        private DBConnection dB;
        public DAO_DangNhap()
        {
            dB = new DBConnection();
        }
        public DTO_DangNhap DangNhap(string username, string password)
        {
            DTO_DangNhap dangNhapDTO = null;
            string query = "SELECT * FROM QUYEN WHERE TENDN = @Username AND MATKHAU = @Password";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dangNhapDTO = new DTO_DangNhap
                {
                    MaNV = reader["MANV"].ToString(),
                    TenDN = reader["TENDN"].ToString(),
                    MatKhau = reader["MATKHAU"].ToString(),
                    Vaitro = reader["VAITRO"].ToString()
                };
            }
            dB.Close();
            return dangNhapDTO;

        }
        public bool CapNhatMatKhau(string maNV, string tendn, string mkMoi)
        {
            string query = "UPDATE Quyen SET MatKhau = @NewPassword WHERE MaNV = @MaNV and TENDN = @tendn";
            SqlCommand cmd = new SqlCommand(query, dB.GetConnection());
            cmd.Parameters.AddWithValue("@NewPassword", mkMoi);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@tendn", tendn);

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

