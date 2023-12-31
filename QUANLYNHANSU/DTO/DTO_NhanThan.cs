using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_NhanThan
    {
        string mant;
        string manv;
        string ten;
        string quanhe;
        DateTime ngaysinh;
        string sodienthoai;
        string nghenghiep;

        public string MaNT
        {
            get { return mant; }
            set { mant = value; }
        }
        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        public string QuanHe
        {
            get { return quanhe; }
            set { quanhe = value; }
        }
        public DateTime NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public string SoDienThoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }
        public string NgheNghiep
        {
            get { return nghenghiep; }
            set { nghenghiep = value; }
        }
        public DTO_NhanThan()
        {

        }
        public DTO_NhanThan(string maNT, string maNV, string ten, string quanHe, DateTime ngaySinh, string soDienThoai, string ngheNghiep)
        {
            MaNT = maNT;
            MaNV = maNV;
            Ten = ten;
            QuanHe = quanHe;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            NgheNghiep = ngheNghiep;
        }
    }
}
