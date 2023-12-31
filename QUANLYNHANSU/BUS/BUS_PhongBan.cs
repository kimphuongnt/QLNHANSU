using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_PhongBan
    {
        DAO_PhongBan phongBanDAO;
        public BUS_PhongBan() 
        {
            phongBanDAO = new DAO_PhongBan();
        }
        public List<DTO_PhongBan> getAll()
        {
            return phongBanDAO.getAll();
        }
        public bool insert(DTO_PhongBan pb)
        {
            return phongBanDAO.insert(pb);
        }
        public bool delete(DTO_PhongBan pb)
        {
            return phongBanDAO.delete(pb);
        }
        public bool update(DTO_PhongBan pb)
        {
            return phongBanDAO.update(pb);
        }
        public List<DTO_PhongBan> search(string keyTen)
        {
            List<DTO_PhongBan> ketQua = new List<DTO_PhongBan>();
            foreach (DTO_PhongBan phongBan in getAll())
            {
                if (phongBan.TenPB.ToLower().Contains(keyTen.ToLower()))
                {
                    ketQua.Add(phongBan);
                }
            }
            return ketQua;
        }
        public List<DTO_PhongBan> searchMa(string keyTen)
        {
            List<DTO_PhongBan> ketQua = new List<DTO_PhongBan>();
            foreach (DTO_PhongBan phongBan in getAll())
            {
                if (phongBan.MaPB.ToLower().Contains(keyTen.ToLower()))
                {
                    ketQua.Add(phongBan);
                }
            }
            return ketQua;
        }
        public int tinhTongNhanVienTrongPhongBan(string maPB)
        {
            return phongBanDAO.tinhTongNhanVienTrongPhongBan(maPB);

        }
    }
}
