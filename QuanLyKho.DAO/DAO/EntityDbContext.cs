using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DAO.DAO
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext() : base("AppDbContext")
        {
        }

        public DbSet<NhanVienDTO> NhanVienDTOs { get; set; }
    }
}
