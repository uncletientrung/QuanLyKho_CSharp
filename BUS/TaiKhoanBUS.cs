 using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.BUS
{
    public class TaiKhoanBUS
    {
        public readonly TaiKhoanDAO tkDAO= TaiKhoanDAO.getInstance();
        private BindingList<TaiKhoanDTO> listTK;
        public TaiKhoanBUS()
        {
            listTK= tkDAO.SelectAll(); 
        }
        public BindingList<TaiKhoanDTO> getListTK()
        {
            listTK = tkDAO.SelectAll();
            return listTK;
        }
        public TaiKhoanDTO getTKById(int id)
        {
            TaiKhoanDTO result = new TaiKhoanDTO();
            result= tkDAO.SelectById(id);
            return result;
        }
        public Boolean InsertTK(TaiKhoanDTO tk)
        {
            Boolean result = tkDAO.Insert(tk) !=0;
            if (result)
            {
                listTK.Add(tk);
            }
            return result;
        }
        
    }
}
