using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_DangNhap
    {
        string manv;
        string tendn;
        string matkhau;
        string vaitro;

        public string MaNV
        {
            get { return manv; }
            set
            {
                manv = value;
            }
        }
        public string TenDN
        {
            get { return tendn; }
            set { tendn = value; }
        }
        public string MatKhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
        public string Vaitro
        {
            get { return vaitro; }
            set { vaitro = value; }
        }
        public DTO_DangNhap()
        {
             
        }
        public DTO_DangNhap(string maNV, string tenDN, string matKhau, string vaitro)
        {
            Vaitro = vaitro;
            MaNV = maNV;
            TenDN = tenDN;
            MatKhau = matKhau;
            Vaitro = vaitro;
        }
    }
}
