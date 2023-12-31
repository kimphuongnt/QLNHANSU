using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_ThuongPhat
    {
        string matp;
        string loai;
        public string MaTP
        {
            get { return matp; }
            set { matp = value; }
        }
        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }
        public DTO_ThuongPhat()
        {
            
        }
        public DTO_ThuongPhat(string maTP, string loai)
        {
            MaTP = maTP;
            Loai = loai;
        }
    }
}
