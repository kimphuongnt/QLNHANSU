using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_HopDong
    {
        DAO_HopDong hopDongDAO;
        public BUS_HopDong()
        {
            hopDongDAO = new DAO_HopDong();
        }
        public List<DTO_HopDong> getAll()
        {
            return hopDongDAO.getAll();
        }
        public string LayTenNhanVienTuMa(string maNV)
        {
            return hopDongDAO.LayTenNhanVienTheoMa(maNV);
        }
        public string LayNgaySinhNhanVienTuMa(string maNV)
        {
            return hopDongDAO.LayNgaySinhNhanVienTheoMa(maNV);
        }
        public string LaySDTNhanVienTuMa(string maNV)
        {
            return hopDongDAO.LaySDTNhanVienTheoMa(maNV);
        }
        public string LayTenCV(string maNV)
        {
            return hopDongDAO.LayTenChucVu(maNV);
        }
        public bool insert(DTO_HopDong hopDong)
        {
            return hopDongDAO.insert(hopDong);
        }
        public bool update(DTO_HopDong hopDong)
        {
            return hopDongDAO.update(hopDong);
        }
        public bool CapNhatTinhTrang()
        {
            return hopDongDAO.CapNhatTinhTrang();
        }
        public bool delete(DTO_HopDong hopDong)
        {
            return hopDongDAO.delete(hopDong);
        }
        public List<DTO_HopDong> filter(string maNV, bool conHan, bool hetHan)
        {
            List<DTO_HopDong> allHopDong = hopDongDAO.getAll();
            List<DTO_HopDong> filterHopDong = allHopDong
                .Where(
                emp => (maNV == "" || emp.MaNV == maNV) && ((conHan && emp.TinhTrang == "Còn hạn") || (hetHan && emp.TinhTrang == "Hết hạn"))
                )
                .ToList();
            return filterHopDong;
        }
        public List<DTO_HopDong> searchMaHD(string keyMa)
        {
            List<DTO_HopDong> ketQua = new List<DTO_HopDong>();
            foreach(DTO_HopDong hopDong in getAll())
            {
                if(hopDong.MaHD.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(hopDong);
                }
            }
            return ketQua;
        }
        public List<DTO_HopDong> searchLoaiHD(string keyMa)
        {
            List<DTO_HopDong> ketQua = new List<DTO_HopDong>();
            foreach (DTO_HopDong hopDong in getAll())
            {
                if (hopDong.LoaiHD.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(hopDong);
                }
            }
            return ketQua;
        }
        public bool KiemTraTrungMa(string maHD, string maNV)
        {
            return hopDongDAO.KiemTraTrungMa(maHD, maNV);
        }
        public List<DTO_HopDong> TimHopDongTheoNgay(DateTime ngayBatDau)
        {
            return hopDongDAO.TimHopDongTheoNgay(ngayBatDau);
        }
    }
}
