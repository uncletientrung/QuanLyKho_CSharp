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
    public class NhomQuyenBUS
    {
        public readonly NhomQuyenDAO nqDAO= NhomQuyenDAO.getInstance();
        public BindingList<NhomQuyenDTO> listNQ;
        
        public NhomQuyenBUS()
        {
            listNQ=nqDAO.SelectAll();
        }
        public BindingList<NhomQuyenDTO> getListNQ()
        {
            listNQ = nqDAO.SelectAll();
            return listNQ;
        }
        public NhomQuyenDTO getNQById(int id)
        {
            NhomQuyenDTO result = new NhomQuyenDTO();
            result=nqDAO.SelectById(id);
            return result;
        }

    }
}
