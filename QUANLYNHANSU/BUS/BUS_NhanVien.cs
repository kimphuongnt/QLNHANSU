using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QUANLYNHANSU.BUS
{
    public class BUS_NhanVien
    {
        DAO_NhanVien nhanVienDAO;
        public BUS_NhanVien()
        {
            nhanVienDAO = new DAO_NhanVien();
        }
        public List<DTO_NhanVien> getAll()
        {
            return nhanVienDAO.getAll();
        }

        public bool themAnh(string maNV, System.Drawing.Image img)
        {
            return nhanVienDAO.themAnh(maNV, img);
        }

        public bool kiemTraQuanLy(string maNV)
        {
            return nhanVienDAO.kiemTraQuanLy(maNV);
        }
        public bool delete(DTO_NhanVien nhanVien)
        {
            return nhanVienDAO.delete(nhanVien);
        }
        public bool insert(DTO_NhanVien nhanVien)
        {
            return nhanVienDAO.insert(nhanVien);
        }
        public bool update(DTO_NhanVien nhanVien)
        {
            return nhanVienDAO.update(nhanVien);
        }
        public List<DTO_NhanVien> search(string keyTen)
        {
            List<DTO_NhanVien> ketQua = new List<DTO_NhanVien>();
            foreach (DTO_NhanVien nhanVien in getAll())
            {
                if (nhanVien.HoTen.ToLower().Contains(keyTen.ToLower()))
                {
                    ketQua.Add(nhanVien);
                }
            }
            return ketQua;
        }
        public List<DTO_NhanVien> searchMa(string keyMa)
        {
            List<DTO_NhanVien> ketQua = new List<DTO_NhanVien>();
            foreach (DTO_NhanVien nhanVien in getAll())
            {
                if (nhanVien.MaNV.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(nhanVien);
                }
            }
            return ketQua;
        }
        public List<DTO_NhanVien> layNhanVienPhongBan(string maPB)
        {
            return nhanVienDAO.layPhongBanCBO(maPB);
        }

        public List<DTO_NhanVien> filter(string maPhongBan, string maChucVu, string maTrinhDo, string mucLuong, string maNguoiQuanLy, bool isMale, bool isFemale)
        {
            List<DTO_NhanVien> allEmployees = nhanVienDAO.getAll();

            List<DTO_NhanVien> filteredEmployees = allEmployees
                .Where(emp =>
                    (maPhongBan == "" || emp.MaPB == maPhongBan) &&
                    (maChucVu == "" || emp.MaCV == maChucVu) &&
                    (maTrinhDo == "" || emp.MaTDHV == maTrinhDo) &&
                    (mucLuong == "" || emp.MucLuong == mucLuong) &&
                    (string.IsNullOrEmpty(maNguoiQuanLy) || emp.MaNguoiQuanLy == maNguoiQuanLy) &&
                    ((isMale && emp.GioiTinh == "Nam") || (isFemale && emp.GioiTinh == "Nữ"))
                )
                .ToList();
            return filteredEmployees;
        }

        public bool KiemTraTrungMa(string maNV)
        {
            return nhanVienDAO.KiemTraTrungMa(maNV);
        }
    }
}
