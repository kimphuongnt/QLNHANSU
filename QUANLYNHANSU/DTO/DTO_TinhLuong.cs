using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_TinhLuong
    {
        string manv;
        float tienthuongphat;
        int thang;
        int nam;
        int songaycong;
        float tongluong;
        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        public float TienThuongPhat
        {
            get { return tienthuongphat; }
            set { tienthuongphat = value; }
        }
        public int Thang
        {
            get { return thang; }
            set { thang = value; }
        }
        public int Nam
        {
            get { return nam; }
            set { nam = value; }
        }

        public int SoNgayCong
        {
            get { return songaycong; }
            set { songaycong = value; }
        }
        public float Tongluong
        {
            get { return tongluong; }
            set { tongluong = value; }
        }
        public DTO_TinhLuong()
        {
        }
        public DTO_TinhLuong(string maNV, float tienthuongphat, int thang, int nam, int soNgayCong, float tongluong)
        {
            MaNV = maNV;
            TienThuongPhat = tienthuongphat;
            Thang = thang;
            Nam = nam;
            SoNgayCong = soNgayCong;
            Tongluong = tongluong;
        }
    }
}

