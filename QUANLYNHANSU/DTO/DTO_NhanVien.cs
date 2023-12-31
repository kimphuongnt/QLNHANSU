using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_NhanVien
    {
        string manv;
        string mapb;
        string macv;
        string hoten;
        DateTime ngaysinh;
        string gioitinh;
        string cmnd;
        string sodienthoai;
        string quequan;
        string dantoc;
        string mucluong;
        string matdhv;
        Image hinh;
        string tinhtranghonnhan;
        string manguoiquanly;
      
        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }

        public string MaPB
        {
            get { return mapb; }
            set { mapb = value; }
        }

        public string MaCV
        {
            get { return macv; }
            set { macv = value; }
        }

        public string HoTen
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        public string GioiTinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string CMND
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        public string SoDienThoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }

        public string QueQuan
        {
            get { return quequan; }
            set { quequan = value; }
        }

        public string DanToc
        {
            get { return dantoc; }
            set { dantoc = value; }
        }

        public string MucLuong
        {
            get { return mucluong; }
            set { mucluong = value; }
        }

        public string MaTDHV
        {
            get { return matdhv; }
            set { matdhv = value; }
        }

        public Image Hinh
        {
            get { return hinh; }
            set { hinh = value; }
        }

        public string TinhTrangHonNhan
        {
            get { return tinhtranghonnhan; }
            set { tinhtranghonnhan = value; }
        }

        public string MaNguoiQuanLy
        {
            get { return manguoiquanly; }
            set { manguoiquanly = value; }
        }
        public DTO_NhanVien()
        {

        }
        public DTO_NhanVien(string maNV, string maPB, string maCV, string hoTen, DateTime ngaySinh, string gioiTinh, string cMND, string soDienThoai, string queQuan, string danToc, string mucLuong, string maTDHV, Image hinh, string tinhTrangHonNhan, string maNguoiQuanLy)
        {
            MaNV = maNV;
            MaPB = maPB;
            MaCV = maCV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            CMND = cMND;
            SoDienThoai = soDienThoai;
            QueQuan = queQuan;
            DanToc = danToc;
            MucLuong = mucLuong;
            MaTDHV = maTDHV;
            Hinh = hinh;
            TinhTrangHonNhan = tinhTrangHonNhan;
            MaNguoiQuanLy = maNguoiQuanLy;
        }

      
    }
}
