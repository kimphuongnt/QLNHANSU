using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_HopDong
    {
        string maHD;
        string maNV;
        string loaiHD;
        DateTime tuNgay;
        DateTime denNgay;
        string tinhTrang;
        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public string LoaiHD
        {
            get { return loaiHD; }
            set { loaiHD = value; }
        }
        public DateTime TuNgay
        {
            get { return tuNgay; }
            set { tuNgay = value; }
        }
        public DateTime DenNgay
        {
            get { return denNgay; }
            set { denNgay = value; }
        }
        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        public DTO_HopDong()
        {

        }
        public DTO_HopDong(string mahd, string loaihd, string manv, DateTime tungay, DateTime denngay, string tinhtrang)
        {
            MaHD = mahd;
            LoaiHD = loaihd;
            MaNV = manv;
            TuNgay = tungay;
            DenNgay = denngay;
            TinhTrang = tinhtrang;
        }
    }
}
