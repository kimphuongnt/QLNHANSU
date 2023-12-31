using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_NhanThan
    {
        DAO_NhanThan nhanThanDAO;
        public BUS_NhanThan()
        {
            nhanThanDAO = new DAO_NhanThan();
        }
        public List<DTO_NhanThan> getAll()
        {
            return nhanThanDAO.getAll();
        }
        public string LayTenNhanVienTuMa(string maNV)
        {
            return nhanThanDAO.LayTenNhanVienTheoMa(maNV);
        }
        public string LayNgaySinhNhanVienTuMa(string maNV)
        {
            return nhanThanDAO.LayNgaySinhNhanVienTheoMa(maNV);
        }
        public string LaySDTNhanVienTuMa(string maNV)
        {
            return nhanThanDAO.LaySDTNhanVienTheoMa(maNV);
        }
        public string LayTenCV(string maNV)
        {
            return nhanThanDAO.LayTenChucVu(maNV);
        }
        public bool KiemTraTrungMa(string maNT, string maNV)
        {
            return nhanThanDAO.KiemTraTrungMa(maNT, maNV);
        }
        public bool insert(DTO_NhanThan nhanThan)
        {
            return nhanThanDAO.insert(nhanThan);
        }
        public bool delete(DTO_NhanThan nhanThan)
        {
            return nhanThanDAO.delete(nhanThan);
        }
        public bool update(DTO_NhanThan nhanThan)
        {
            return nhanThanDAO.update(nhanThan);
        }
        public List<DTO_NhanThan> filter(string maNV)
        {
            List<DTO_NhanThan> allNT = nhanThanDAO.getAll();
            List<DTO_NhanThan> filterNT = allNT
                .Where(emp => (maNV == "" || emp.MaNV == maNV)).ToList();
            return filterNT;
        }
        public List<DTO_NhanThan> searchMaNT(string keyMa)
        {
            List<DTO_NhanThan> ketQua = new List<DTO_NhanThan>();
            foreach (DTO_NhanThan nt in getAll())
            {
                if (nt.MaNT.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(nt);
                }
            }
            return ketQua;
        }
        public List<DTO_NhanThan> searchTenNT(string keyMa)
        {
            List<DTO_NhanThan> ketQua = new List<DTO_NhanThan>();
            foreach (DTO_NhanThan nt in getAll())
            {
                if (nt.Ten.ToLower().Contains(keyMa.ToLower()))
                {
                    ketQua.Add(nt);
                }
            }
            return ketQua;
        }
    }
}
