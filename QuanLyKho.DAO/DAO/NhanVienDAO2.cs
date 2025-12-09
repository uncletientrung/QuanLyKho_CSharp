using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyKho.DAO.DAO
{
    public class NhanVienDAO2
    {
        private EntityDbContext db = new EntityDbContext();
        public List<NhanVienDTO> GetAll()
        {
            return db.NhanVienDTOs.ToList();
        }
    }
}
