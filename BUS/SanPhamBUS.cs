using Google.Protobuf.Collections;
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
    public class SanPhamBUS
    {
        public readonly SanPhamDAO spDAO = SanPhamDAO.getInstance();
        private BindingList<SanPhamDTO> listSP;
       

        public BindingList<SanPhamDTO> getListSP()
        {
            listSP = spDAO.SelectAll();
            return listSP;
        }
        public SanPhamBUS()
        {
            listSP = spDAO.SelectAll();
        }
        public Boolean removeSanPham(int maSp) // Xoa db
        {
            SanPhamDTO spXoa = spDAO.SelectById(maSp);
            Boolean result = spDAO.Delete(maSp) != 0;
            if (result)
            {
                foreach (SanPhamDTO sp in listSP)
                {
                    if (sp.Equals(spXoa))
                    {
                        listSP.Remove(sp);
                        return result;
                    }
                }
            }
            return result;
        }
        public Boolean insertSanPham(SanPhamDTO sp)
        {
            Boolean result = spDAO.Insert(sp) != 0;
            if (result)
            {
                listSP.Add(sp);
            }
            return true;
        }
        public int getAutoMaSP()
        {
            return spDAO.GetAutoIncrement();
        }
        public SanPhamDTO getSPById(int masp)
        {
            SanPhamDTO sp = spDAO.SelectById(masp);
            return sp;
        }

        public string getNamebyID(int maSP)
        {
            SanPhamDTO sp = listSP.FirstOrDefault(x => x.Masp == maSP);
            if (sp != null)
            {
                return sp.Tensp;
            }
            return "Không tìm thấy";
        }

        public Boolean updateSanPham(SanPhamDTO sp)
        {
            Boolean result = spDAO.Update(sp) != 0;
            if (result)
            {
                foreach (SanPhamDTO sanpham in listSP)
                {
                    if (sanpham.Masp == sp.Masp)
                    {
                        sanpham.Tensp = sp.Tensp;
                        sanpham.Hinhanh = sp.Hinhanh;
                        sanpham.Soluong = sp.Soluong;
                        sanpham.Dongia = sp.Dongia;
                        sanpham.Machatlieu = sp.Machatlieu;
                        sanpham.Maloai = sp.Maloai;
                        sanpham.Makhuvuc = sp.Makhuvuc;
                        sanpham.Masize = sp.Masize;
                        return result;
                    }
                }
            }
            return result;
        }

        public BindingList<SanPhamDTO> TimkiemSanPham(string searchString)
        {
            BindingList<SanPhamDTO> result = new BindingList<SanPhamDTO> ();
            foreach (SanPhamDTO sp in listSP) {
                if (sp.Tensp.ToLower().Contains(searchString.ToLower()) ||
                    sp.Maloai.ToString().Contains(searchString) ||
                    sp.Makhuvuc.ToString().Contains(searchString) ||
                    sp.Dongia.ToString().Contains(searchString))
                {
                    result.Add(sp);
                }
            }
            return result;
        }


        
    }

}

