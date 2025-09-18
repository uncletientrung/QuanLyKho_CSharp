using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.ComponentModel;

namespace QuanLyKho_CSharp.BUS
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAO khDAO = KhachHangDAO.getInstance();
        private BindingList<KhachHangDTO> listKH;

        // Constructor: load danh sách khách hàng khi khởi tạo
        public KhachHangBUS()
        {
            listKH = khDAO.SelectAll();
        }

        // Lấy toàn bộ danh sách
        public BindingList<KhachHangDTO> getListKH()
        {
            listKH = khDAO.SelectAll();
            return listKH;
        }

        // Thêm khách hàng
        public bool insertKhachHang(KhachHangDTO kh)
        {
            bool result = khDAO.Insert(kh) != 0;
            if (result)
            {
                listKH.Add(kh);
            }
            return result;
        }

        // Xóa khách hàng (mềm)
        public bool removeKhachHang(int maKH)
        {
            KhachHangDTO khXoa = khDAO.SelectById(maKH);
            bool result = khDAO.Delete(maKH) != 0;
            if (result && khXoa != null)
            {
                listKH.Remove(khXoa);
            }
            return result;
        }

        // Cập nhật khách hàng
        public bool updateKhachHang(KhachHangDTO khSua)
        {
            bool result = khDAO.Update(khSua) != 0;
            if (result)
            {
                foreach (KhachHangDTO kh in listKH)
                {
                    if (kh.Makh == khSua.Makh)
                    {
                        kh.Tenkhachhang = khSua.Tenkhachhang;
                        kh.Email = khSua.Email;
                        kh.Ngaysinh = khSua.Ngaysinh;
                        kh.Sdt = khSua.Sdt;
                        kh.Trangthai = khSua.Trangthai;
                        break;
                    }
                }
            }
            return result;
        }

        // Lấy mã khách hàng AUTO_INCREMENT
        public int getAutoMaKH()
        {
            return khDAO.GetAutoIncrement();
        }

        // Lấy khách hàng theo ID
        public KhachHangDTO getKHById(int maKH)
        {
            return khDAO.SelectById(maKH);
        }

        // Tìm kiếm khách hàng (theo tên, mã KH, sdt, email)
        public BindingList<KhachHangDTO> SearchKhachHang(string search)
        {
            BindingList<KhachHangDTO> result = new BindingList<KhachHangDTO>();
            foreach (KhachHangDTO kh in listKH)
            {
                if (kh.Tenkhachhang.ToLower().Contains(search.ToLower()) ||
                    kh.Makh.ToString().Contains(search) ||
                    kh.Sdt.ToLower().Contains(search.ToLower()) ||
                    kh.Email.ToLower().Contains(search.ToLower()))
                {
                    result.Add(kh);
                }
            }
            return result;
        }
    }
}
