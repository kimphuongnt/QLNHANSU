using QUANLYNHANSU.DBC;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.DAO
{
    public class DAO_TrinhDoHocVan
    {
        DataTable dt_tdhv;
        SqlDataAdapter adapter;
        private DBConnection dB;
        public DAO_TrinhDoHocVan()
        {
            dB = new DBConnection();
            dt_tdhv = new DataTable();
            adapter = new SqlDataAdapter("select * from TRINHDOHOCVAN", dB.GetConnection());
            adapter.Fill(dt_tdhv);
        }
        public List<DTO_TrinhDoHocVan> getAll()
        {
            List<DTO_TrinhDoHocVan> lst = new List<DTO_TrinhDoHocVan>();
            foreach (DataRow row in dt_tdhv.Rows)
            {
                DTO_TrinhDoHocVan trinhDo = new DTO_TrinhDoHocVan(row["MaTDHV"].ToString(), row["TTDHV"].ToString());
                lst.Add(trinhDo);
            }
            return lst;
        }
    }
}
