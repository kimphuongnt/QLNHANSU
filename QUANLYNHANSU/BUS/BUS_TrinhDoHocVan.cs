using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_TrinhDoHocVan
    {
        DAO_TrinhDoHocVan trinhdoDAO;
        public BUS_TrinhDoHocVan()
        {
            trinhdoDAO = new DAO_TrinhDoHocVan();
        }
        public List<DTO_TrinhDoHocVan> getAll()
        {
            return trinhdoDAO.getAll();
        }
    }
}
