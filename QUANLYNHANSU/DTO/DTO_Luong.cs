using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_Luong
    {
        string mucluong;
        float luongcb;
        public string MucLuong
        {
            get { return mucluong; }
            set { mucluong = value; }
        }
        public float LuongCB 
        { 
            get { return luongcb; } 
            set { luongcb = value; } 
        }
        public DTO_Luong()
        {
            
        }
        public DTO_Luong(string mucLuong, float luongCB)
        {
            MucLuong = mucLuong;
            LuongCB = luongCB;
        }
    }
}
