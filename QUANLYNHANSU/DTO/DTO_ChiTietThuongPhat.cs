using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_ChiTietThuongPhat
    {
        string macttp;
        string manv;
        string matp;
        string loai;
        float tien;
        string lydo;
        DateTime ngay;
        public string MaCTTP
        {
            get { return macttp; }
            set { macttp = value; }
        }

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        public string MaTP
        {
            get { return matp; }
            set { matp = value; }
        }
        public float Tien
        {
            get { return tien; }
            set { tien = value; }
        }
        public string LyDo
        {
            get { return lydo; }
            set { lydo = value; }
        }
        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        public DTO_ChiTietThuongPhat()
        {

        }
        public DTO_ChiTietThuongPhat(string maCTTP, string maNV, string maTP, float tien, string lyDo, DateTime ngay)
        {
            MaCTTP = maCTTP;
            MaNV = maNV;
            MaTP = maTP;
            Tien = tien;
            LyDo = lyDo;
            Ngay = ngay;
        }
    }
}
