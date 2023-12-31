using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_ChiTietThuongPhat
    {
        DAO_ChiTietThuongPhat chiTietThuongPhatBUS;
        public BUS_ChiTietThuongPhat()
        {
            chiTietThuongPhatBUS = new DAO_ChiTietThuongPhat();
        }
        public List<DTO_ChiTietThuongPhat> getAll()
        {
            return chiTietThuongPhatBUS.getAll();
        }
        public bool KiemTraTrungMa(string maNP, string maNV)
        {
            return chiTietThuongPhatBUS.KiemTraTrungMa(maNP, maNV);
        }
        public string LayTenNhanVienTuMa(string maNV)
        {
            return chiTietThuongPhatBUS.LayTenNhanVienTheoMa(maNV);
        }
        public string LayNgaySinhNhanVienTuMa(string maNV)
        {
            return chiTietThuongPhatBUS.LayNgaySinhNhanVienTheoMa(maNV);
        }
        public string LaySDTNhanVienTuMa(string maNV)
        {
            return chiTietThuongPhatBUS.LaySDTNhanVienTheoMa(maNV);
        }
        public string LayTenCV(string maNV)
        {
            return chiTietThuongPhatBUS.LayTenChucVu(maNV);
        }
        public bool delete(DTO_ChiTietThuongPhat chiTietThuongPhat)
        {
            return chiTietThuongPhatBUS.delete(chiTietThuongPhat);
        }
        public bool insert(DTO_ChiTietThuongPhat chiTietThuongPhat)
        {
            return chiTietThuongPhatBUS.insert(chiTietThuongPhat);
        }
        public bool update(DTO_ChiTietThuongPhat chiTietThuongPhat)
        {
            return chiTietThuongPhatBUS.update(chiTietThuongPhat);
        }
        public List<DTO_ChiTietThuongPhat> filter(string maNV, string maTP)
        {
            List<DTO_ChiTietThuongPhat> allTP = chiTietThuongPhatBUS.getAll();
            List<DTO_ChiTietThuongPhat> filterTP = allTP
                .Where(emp => (maTP == "" || emp.MaTP == maTP) && (maNV == "" || emp.MaNV == maNV)).ToList();
            return filterTP;
        }
        public List<DTO_ChiTietThuongPhat> searchMaTP(string keyMa)
        {
            List<DTO_ChiTietThuongPhat> ketQua = new List<DTO_ChiTietThuongPhat>();
            foreach (DTO_ChiTietThuongPhat TP in getAll())
            {
                if (TP.MaCTTP.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(TP);
                }
            }
            return ketQua;
        }
        public List<DTO_ChiTietThuongPhat> TimTheoNgay(DateTime ngay)
        {
            return chiTietThuongPhatBUS.TimTheoNgay(ngay);
        }
    }
}
