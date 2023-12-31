using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANSU.BUS
{
    public class BUS_NghiPhep
    {
        DAO_NghiPhep nghiPhepDAO;
        public BUS_NghiPhep()
        {
            nghiPhepDAO = new DAO_NghiPhep();
        }
        public List<DTO_NghiPhep> getAll()
        {
            return nghiPhepDAO.getAll();
        }
        public bool KiemTraTrungMa(string maNP)
        {
            return nghiPhepDAO.KiemTraTrungMa(maNP);
        }
        public string LayTenNhanVienTuMa(string maNV)
        {
            return nghiPhepDAO.LayTenNhanVienTheoMa(maNV);
        }
        public string LayNgaySinhNhanVienTuMa(string maNV)
        {
            return nghiPhepDAO.LayNgaySinhNhanVienTheoMa(maNV);
        }
        public string LaySDTNhanVienTuMa(string maNV)
        {
            return nghiPhepDAO.LaySDTNhanVienTheoMa(maNV);
        }
        public string LayTenCV(string maNV)
        {
            return nghiPhepDAO.LayTenChucVu(maNV);
        }
        public bool delete(DTO_NghiPhep nghiPhep)
        {
            return nghiPhepDAO.delete(nghiPhep);
        }
        public bool insert(DTO_NghiPhep nghiPhep)
        {
            return nghiPhepDAO.insert(nghiPhep);
        }
        public bool update(DTO_NghiPhep nghiPhep)
        {
            return nghiPhepDAO.update(nghiPhep);
        }
        public List<DTO_NghiPhep> filter(string maNV, bool chuaDuyet, bool daDuyet)
        {
            List<DTO_NghiPhep> allnghiPhep = nghiPhepDAO.getAll();
            List<DTO_NghiPhep> filternghiPhep = allnghiPhep
                .Where(
                emp => (maNV == "" || emp.MaNV == maNV) && ((chuaDuyet && emp.TinhTrang == "Chưa duyệt") || (daDuyet && emp.TinhTrang == "Đã duyệt"))
                )
                .ToList();
            return filternghiPhep;
        }
        public List<DTO_NghiPhep> searchMaNP(string keyMa)
        {
            List<DTO_NghiPhep> ketQua = new List<DTO_NghiPhep>();
            foreach (DTO_NghiPhep nghiPhep in getAll())
            {
                if (nghiPhep.MaNP.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(nghiPhep);
                }
            }
            return ketQua;
        }
        public List<DTO_NghiPhep> TimNghiPhepTheoNgay(DateTime ngayBatDau)
        {
            return nghiPhepDAO.TimNghiPhepTheoNgay(ngayBatDau);
        }


    }
}
