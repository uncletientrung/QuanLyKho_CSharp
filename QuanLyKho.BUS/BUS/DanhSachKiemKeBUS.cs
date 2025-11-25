using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.ComponentModel;

namespace QuanLyKho_CSharp.BUS
{
    public class DanhSachKiemKeBUS
    {
        private readonly DanhSachKiemKeDAO kkDAO = DanhSachKiemKeDAO.getInstance();
        private BindingList<DanhSachKiemKeDTO> listKiemKe;

        // Constructor: load danh sách kiểm kê khi khởi tạo
        public DanhSachKiemKeBUS()
        {
            listKiemKe = kkDAO.SelectAll();
        }

        // Lấy toàn bộ danh sách
        public BindingList<DanhSachKiemKeDTO> getListKiemKe()
        {
            listKiemKe = kkDAO.SelectAll();
            return listKiemKe;
        }

        // Thêm phiếu kiểm kê
        public bool insertKiemKe(DanhSachKiemKeDTO kk)
        {
            bool result = kkDAO.Insert(kk) != 0;
            if (result)
            {
                listKiemKe.Add(kk);
            }
            return result;
        }

        // Xóa phiếu kiểm kê
        public bool removeKiemKe(int maPhieuNhap)
        {
            DanhSachKiemKeDTO kkXoa = kkDAO.SelectById(maPhieuNhap);
            bool result = kkDAO.Delete(maPhieuNhap) != 0;
            if (result && kkXoa != null)
            {
                listKiemKe.Remove(kkXoa);
            }
            return result;
        }

        // Cập nhật phiếu kiểm kê
        public bool updateKiemKe(DanhSachKiemKeDTO kkSua)
        {
            bool result = kkDAO.Update(kkSua) != 0;
            if (result)
            {
                foreach (DanhSachKiemKeDTO kk in listKiemKe)
                {
                    if (kk.Maphieukiemke == kkSua.Maphieukiemke)
                    {
                        kk.Ngaynhap = kkSua.Ngaynhap;
                        kk.Nhacungcap = kkSua.Nhacungcap;
                        kk.Tenmathang = kkSua.Tenmathang;
                        kk.Soluongbaocao = kkSua.Soluongbaocao;
                        kk.Soluongthucnhap = kkSua.Soluongthucnhap;
                        kk.Chenhlech = kkSua.Chenhlech;
                        kk.Ghichu = kkSua.Ghichu;
                        break;
                    }
                }
            }
            return result;
        }

        // Lấy phiếu kiểm kê theo ID
        public DanhSachKiemKeDTO getKiemKeById(int maPhieuNhap)
        {
            return kkDAO.SelectById(maPhieuNhap);
        }

        // Tìm kiếm phiếu kiểm kê (theo mã phiếu, nhà cung cấp, tên hàng)
        public BindingList<DanhSachKiemKeDTO> SearchKiemKe(string search)
        {
            BindingList<DanhSachKiemKeDTO> result = new BindingList<DanhSachKiemKeDTO>();
            foreach (DanhSachKiemKeDTO kk in listKiemKe)
            {
                if (kk.Maphieunhap.ToString().Contains(search) ||
                    kk.Nhacungcap.ToLower().Contains(search.ToLower()) ||
                    kk.Tenmathang.ToLower().Contains(search.ToLower()))
                {
                    result.Add(kk);
                }
            }
            return result;
        }
    }
}
