using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_DangNhap
    {
        DAO_DangNhap dangNhapDAO;
        public BUS_DangNhap()
        {
            dangNhapDAO = new DAO_DangNhap();
        }
        public DTO_DangNhap DangNhap(string username, string password)
        {
            return dangNhapDAO.DangNhap(username, password);
        }
        public bool DoiMatKhau(string manv, string tendn, string mkMoi)
        {
            return dangNhapDAO.CapNhatMatKhau(manv, tendn, mkMoi);
        }

    }
}
