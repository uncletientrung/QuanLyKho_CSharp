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
        public Boolean removeNhanVien(int maNV) // Xóa trong database trước rồi xóa list
        {
            NhanVienDTO nvXoa=nvDAO.SelectById(maNV);
            Boolean result = nvDAO.Delete(maNV) !=0;
            if (result)
            {
                foreach(NhanVienDTO nv in listNV)
                {
                    if (nv.Equals(nvXoa)){
                        listNV.Remove(nv);
                        return result;
                    }
                }
            }
            return result;

        }
        public Boolean insertNhanVien(NhanVienDTO NV)
        {
            Boolean result = nvDAO.Insert(NV) !=0;
            if (result)
            {
                listNV.Add(NV);
            }
            return true;
        }
        public int getAutoMaNV()
        {
            return nvDAO.GetAutoIncrement();
        }
    }
}
