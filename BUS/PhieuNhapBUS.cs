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
    public class PhieuNhapBUS
    {
        public readonly PhieuNhapDAO pnDAO = PhieuNhapDAO.getInstance();
        private BindingList<PhieuNhapDTO> listPN;

        public BindingList<PhieuNhapDTO> getListPN()
        {
            listPN = pnDAO.SelectAll();
            return listPN;
        }

        public PhieuNhapBUS()
        {
            listPN = pnDAO.SelectAll();
        }
    }
}