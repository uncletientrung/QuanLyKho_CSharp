using MySqlX.XDevAPI.Common;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BUS
{
    public class NhaCungCapBUS
    {
        public readonly NhaCungCapDAO nccDAO = NhaCungCapDAO.getInstance();
        private BindingList<NhaCungCapDTO> listNCC;

        public BindingList<NhaCungCapDTO> getListNCC()
        {
            listNCC = nccDAO.SelectAll();
            return listNCC;
        }
        public NhaCungCapBUS()
        {
            listNCC = nccDAO.SelectAll();
        }
        public string getNamebyID(int maNCC)
        {
            NhaCungCapDTO ncc = listNCC.FirstOrDefault(x => x.Mancc == maNCC);
            if (ncc != null)
            {
                return ncc.Tenncc;
            }
            return "Không tìm thấy";
        }
        public Boolean removeNhaCungCap(int maNCC) // Xóa trong database trước rồi xóa list
        {
            NhaCungCapDTO nccXoa = nccDAO.SelectById(maNCC);
            Boolean result = nccDAO.Delete(maNCC) != 0;
            if (result)
            {
                listNCC.Remove(nccXoa);
            }
            return result;
        }
        public Boolean insertNhaCungCap(NhaCungCapDTO NCC)
        {
            Boolean result = nccDAO.Insert(NCC) != 0;
            if (result)
            {
                listNCC.Add(NCC);
            }
            return true;
        }
        public int getAutoMaNCC()
        {
            return nccDAO.GetAutoIncrement();
        }
        public NhaCungCapDTO getNCCById(int maNCC)
        {
            NhaCungCapDTO ncc = nccDAO.SelectById(maNCC);
            return ncc;
        }
        public Boolean updateNhaCungCap(NhaCungCapDTO nccSua)
        {
            Boolean result = nccDAO.Update(nccSua) != 0;
            if (result)
            {
                NhaCungCapDTO ncc = listNCC.FirstOrDefault(x => x.Mancc == nccSua.Mancc);
                if (ncc != null)
                {
                    ncc.Tenncc = nccSua.Tenncc;
                    ncc.Diachincc = nccSua.Diachincc;
                    ncc.Sdt = nccSua.Sdt;
                    ncc.Email = nccSua.Email;
                    return result;
                }
            }
            return result;
        }
        public BindingList<NhaCungCapDTO> searchNhaCungCap(string search)
        {
            List<NhaCungCapDTO> result = listNCC.Where(ncc => ncc.Tenncc.ToLower().Contains(search.ToLower()) ||
                      ncc.Mancc.ToString().Contains(search) ||
                      ncc.Sdt.ToLower().Contains(search.ToLower())).ToList();
            return new BindingList<NhaCungCapDTO>(result);
        }
    }
}
