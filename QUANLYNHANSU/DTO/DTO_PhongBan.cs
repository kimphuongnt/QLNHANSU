using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_PhongBan
    {
        string mapb;
        string tenpb;
        string diachi;
        string sodienthoai;
        public string MaPB
        {
            get { return mapb; }
            set { mapb = value; }
        }
        public string TenPB
        {
            get { return tenpb; }
            set { tenpb = value; }
        }
        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public string SoDienThoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }
        public DTO_PhongBan()
        {

        }
        public DTO_PhongBan(string maPB, string tenPB, string diaChi, string soDienThoai)
        {
            MaPB = maPB;
            TenPB = tenPB;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }
    }
}
