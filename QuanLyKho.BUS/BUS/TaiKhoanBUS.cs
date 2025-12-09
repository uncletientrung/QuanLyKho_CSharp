using MySqlX.XDevAPI.Common;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.BUS
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
        public Boolean DeleteTK(int id)
        {
            Boolean result = tkDAO.Delete(id) != 0;
            if (result)
            {
                listTK.Remove(getTKById(id));
            }
            return result;
        }
        public Boolean UpdateTK(TaiKhoanDTO tkUpdate)
        {
            Boolean result= tkDAO.Update(tkUpdate) != 0;
            if (result)
            {
                var tk = listTK.FirstOrDefault(item => item.Manv == tkUpdate.Manv);
                if(tk != null)
                {
                    tk.Tendangnhap = tkUpdate.Tendangnhap;
                    tk.Matkhau = tkUpdate.Matkhau;
                    tk.Manhomquyen = tkUpdate.Manhomquyen;
                }
            }
            return result;
        }
        public BindingList<TaiKhoanDTO> SearchTaiKhoan(string text)
        {
            var result = listTK.Where(
                                    item => item.Tendangnhap.ToLower().Contains(text.ToLower()) ||
                                    item.Manv.ToString().ToLower().Contains(text.ToLower())).ToList();
            return new BindingList<TaiKhoanDTO>(result);

        }
        public int getIdNQByIdNV(int manv)
        {
            return listTK.FirstOrDefault(tk => tk.Manv == manv).Manhomquyen;  
        }
    }
}
