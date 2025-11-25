using Google.Protobuf.Collections;
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
    public class KhachHangBUS 
    {
        public readonly KhachHangDAO khDAO=KhachHangDAO.getInstance();
        private BindingList<KhachHangDTO> listKH;
        public BindingList<KhachHangDTO> getListKH()
        {
            listKH = khDAO.SelectAll();
            return listKH;
        }

        public KhachHangBUS()
        {
            listKH=khDAO.SelectAll();
        }
        public string getNamebyID(int maKH)
        {
            KhachHangDTO nv = listKH.FirstOrDefault(x => x.Makh == maKH);

            if (nv != null)
            {
                return nv.Tenkhachhang;
            }

            return "Không tìm thấy";
        }

        public KhachHangDTO getKHById(int maKH)
        {
            KhachHangDTO kh = khDAO.SelectById(maKH);
            return kh;
        }

        public Boolean removeKhachHang(int maKH) 
        {
            KhachHangDTO khXoa=khDAO.SelectById(maKH);
            Boolean result = khDAO.Delete(maKH) != 0;
            if (result)
            {
                listKH.Remove(khXoa);
            }
            return result;
        }

        public Boolean insertKhachHang(KhachHangDTO KH)
        {
            Boolean result = khDAO.Insert(KH) != 0;
            if (result)
            {
                listKH.Add(KH);
            }
            return true;
        }

        public int getAutoMaKH()
        {
            return khDAO.GetAutoIncrement();
        }

        public Boolean updateKhachHang(KhachHangDTO khSua)
        {
            Boolean result = khDAO.Update(khSua) != 0;
            if (result)
            {
                foreach(KhachHangDTO kh in listKH)
                {
                    if (kh.Makh == khSua.Makh)
                    {
                        kh.Tenkhachhang = khSua.Tenkhachhang;
                        kh.Email = khSua.Email;
                        kh.Sdt = khSua.Sdt;
                        kh.Ngaysinh = khSua.Ngaysinh;
                        break;
                    }
                }
            }
            return result;
        }

        public BindingList<KhachHangDTO> SearchKhachHang(string search)
        {
            BindingList<KhachHangDTO> result = new BindingList<KhachHangDTO>();
            foreach (KhachHangDTO kh in listKH)
            {
                if (kh.Tenkhachhang.ToLower().Contains(search.ToLower()) ||
                    kh.Makh.ToString().Contains(search) ||
                    kh.Sdt.ToLower().Contains(search.ToLower()))
                {
                    result.Add(kh);
                }
            }
            return result;
        }

    }
}
