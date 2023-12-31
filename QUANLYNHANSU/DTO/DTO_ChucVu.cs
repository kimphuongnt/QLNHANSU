using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_ChucVu
    {
        string macv;
        string tencv;
        public string MaCV
        {
            get { return macv; }
            set { macv = value; }
        }
        public string TenCV
        {
            get { return tencv; }
            set { tencv = value; }
        }
        public DTO_ChucVu()
        {

        }
        public DTO_ChucVu(string maCV, string tenCV)
        {
            MaCV = maCV;
            TenCV = tenCV;
        }
    }
}
