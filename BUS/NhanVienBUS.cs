using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.BUS
{
    public class NhanVienBUS
    {
        public readonly NhanVienDAO nvDAO=NhanVienDAO.getInstance();
        private BindingList<NhanVienDTO> listNV;

        public BindingList<NhanVienDTO> getListNV()
        {
            return listNV;
        }
        public NhanVienBUS()
        {
            listNV=nvDAO.SelectAll();
        }
    }
}
