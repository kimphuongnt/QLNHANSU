using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_TinhLuong
    {
        DAO_TinhLuong tinhLuongDAO;
        public BUS_TinhLuong()
        {
            tinhLuongDAO = new DAO_TinhLuong();
        }
        public List<DTO_TinhLuong> getAll()
        {
            return tinhLuongDAO.getAll();
        }
        public bool insert(DTO_TinhLuong tinhLuong)
        {
            return tinhLuongDAO.insert(tinhLuong);
        }
        public string LayTenNhanVienTuMa(string maNV)
        {
            return tinhLuongDAO.LayTenNhanVienTheoMa(maNV);
        }
        public string LayNgaySinhNhanVienTuMa(string maNV)
        {
            return tinhLuongDAO.LayNgaySinhNhanVienTheoMa(maNV);
        }
        public string LaySDTNhanVienTuMa(string maNV)
        {
            return tinhLuongDAO.LaySDTNhanVienTheoMa(maNV);
        }
        public string LayTenCV(string maNV)
        {
            return tinhLuongDAO.LayTenChucVu(maNV);
        }
        public void TinhNgayCong(string maNV, int thang, int nam)
        {
            tinhLuongDAO.TinhNgayCong(maNV, thang, nam);
        }
        public bool TinhTienThuongPhat(string maNV, int thang, int nam)
        {
            return tinhLuongDAO.TinhTienThuongPhat(maNV, thang, nam);
        }
        public float TinhTongLuong(string maNV, int thang, int nam)
        {
            return tinhLuongDAO.TinhTongLuong(maNV, thang, nam);
        }
        public bool updateNutTinhLuong(string maNV, int thang, int nam, int soNgayCong, float tienThuongPhat, float tongLuong)
        {
            return tinhLuongDAO.updateNutTinhLuong(maNV, thang, nam, soNgayCong, tienThuongPhat, tongLuong);
        }
        public bool delete(DTO_TinhLuong tl)
        {
            return tinhLuongDAO.delete(tl);

        }
        public bool update(DTO_TinhLuong tl)
        {
            return tinhLuongDAO.update(tl);
        }
        public List<DTO_TinhLuong> filter(string maNV, int thang, int nam)
        {
            List<DTO_TinhLuong> allTL = tinhLuongDAO.getAll();

            if (maNV == "Tất cả")
            {
                return allTL.Where(emp => emp.Thang == thang && emp.Nam == nam).ToList();
            }
            else
            {
                return allTL.Where(emp => emp.Thang == thang && emp.Nam == nam && emp.MaNV == maNV).ToList();
            }

        }
    }
}
