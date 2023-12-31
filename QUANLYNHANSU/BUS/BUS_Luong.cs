using QUANLYNHANSU.DAO;
using QUANLYNHANSU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYNHANSU.BUS
{
    public class BUS_Luong
    {
        DAO_Luong luongDAO;
        public BUS_Luong()
        {
            luongDAO = new DAO_Luong();
        }
        public List<DTO_Luong> getAll()
        {
            return luongDAO.getAll();
        }
    }
}
