using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DTO
{
    public class DTO_TrinhDoHocVan
    {
        string maTDHV;
        string ttdhv;
        public string MaTDHV
        {
            get { return maTDHV; }
            set { maTDHV = value; }
        }
        public string TTDHV
        {
            get { return ttdhv; }
            set { ttdhv = value; }
        }

        public DTO_TrinhDoHocVan()
        {
            
        }
        public DTO_TrinhDoHocVan(string maTDHV, string tDHV)
        {
            MaTDHV = maTDHV;
            TTDHV = tDHV;
        }
    }
}
