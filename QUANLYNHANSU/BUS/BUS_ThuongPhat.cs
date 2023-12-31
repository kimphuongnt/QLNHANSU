using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_ThuongPhat
    {
        DAO_ThuongPhat thuongPhatDAO;
        public BUS_ThuongPhat()
        {
            thuongPhatDAO = new DAO_ThuongPhat();
        }
        public List<DTO_ThuongPhat> getAll()
        {
            return thuongPhatDAO.getAll();
        }
    }
}
