using Google.Protobuf.Collections;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Datatypes.Scalar.Types;


namespace QuanLyKho.BUS
{
    public class SanPhamBUS
    {
        public readonly SanPhamDAO spDAO = SanPhamDAO.getInstance();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<LoaiDTO> listLoai;
        private LoaiBUS loaiBUS= new LoaiBUS();
       

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

        // thêm hàm này để sử lý logic riêng trong HoanHangGUI
        public int getIDbyName(string tenSP)
        {
            SanPhamDTO sp = listSP.FirstOrDefault(x => x.Tensp.Equals(tenSP, StringComparison.OrdinalIgnoreCase));
            if (sp != null)
            {
                return sp.Masp;
            }
            return -1;
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


        public Dictionary<string, int> TinhSoLuongTungLoai()
        {
            listLoai = loaiBUS.getLoaiList();
            return listSP
                .GroupBy(sp => sp.Maloai)
                .ToDictionary(
                    g => listLoai.FirstOrDefault(l => l.Maloai == g.Key)?.Tenloai ?? "Không xác định",
                    g => g.Sum(sp => sp.Soluong)
                );
        }

        //GroupBy: gom các sản phẩm theo mã loại

        //Sum: tính tổng số lượng trong từng nhóm

        //ToDictionary: tạo dictionary với key = tên loại, value = tổng số lượng




        // thm hàm cập nhật số lượng tồn cho HoanHangBUS
        public bool updateSoLuongTon(int maSP, int soLuongThem)
        {
            return spDAO.updateSoLuongTon(maSP, soLuongThem);
        }


    }

}

