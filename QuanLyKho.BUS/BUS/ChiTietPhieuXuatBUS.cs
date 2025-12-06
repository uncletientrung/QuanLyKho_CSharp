using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;


namespace QuanLyKho.BUS
{
    public class ChiTietPhieuXuatBUS
    {
        public readonly ChiTietPhieuXuatDAO ctpxDAO = ChiTietPhieuXuatDAO.getInstance();
        private readonly SanPhamDAO spDAO = SanPhamDAO.getInstance();
        private BindingList<ChiTietPhieuXuatDTO> listCTPX;

        public BindingList<ChiTietPhieuXuatDTO> getListCTPX()
        {
            listCTPX = ctpxDAO.SelectAll();
            return listCTPX;
        }

        public ChiTietPhieuXuatBUS()
        {
            listCTPX = ctpxDAO.SelectAll();
        }

        public Boolean insertChiTietPhieuXuat(BindingList<ChiTietPhieuXuatDTO> listCTPX)
        {
            int result = ctpxDAO.Insert(listCTPX);
            foreach(ChiTietPhieuXuatDTO ctpx in listCTPX)
            {
                int soluongTru = -(ctpx.Soluong);
                spDAO.updateSoLuongTon(ctpx.Masp, soluongTru);
            }
            return result == listCTPX.Count;
        }

        public Boolean insertSingleChiTietPhieuXuat(ChiTietPhieuXuatDTO ctpx)
        {
            Boolean result = ctpxDAO.InsertSingle(ctpx) != 0;
            if (result)
            {
                listCTPX.Add(ctpx);
            }
            return result;
        }

        public Boolean updateChiTietPhieuXuat(BindingList<ChiTietPhieuXuatDTO> listCTPX, int maPhieuXuat)
        {
            int result = ctpxDAO.Update(listCTPX, maPhieuXuat);
            return result == listCTPX.Count;
        }

        public Boolean deleteChiTietPhieuXuat(int maPhieuXuat)
        {
            return ctpxDAO.Delete(maPhieuXuat) != 0;
        }

        public BindingList<ChiTietPhieuXuatDTO> getChiTietByMaPhieuXuat(int maPhieuXuat)
        {
            return ctpxDAO.SelectAll(maPhieuXuat);
        }

        public Boolean updateTrangThaiHoanHang(ChiTietPhieuXuatDTO ctpx)
        {
            Boolean result =ctpxDAO.UpdateSingle(ctpx) != 0;
            if (result)
            {
                int soLuongCong = ctpx.Soluong;
                spDAO.updateSoLuongTon(ctpx.Masp, soLuongCong);
            }
            return result;
        }

        public Boolean deleteByMaPhieuXuatAndMaSP(int maPhieuXuat, int maSP)
        {
            return ctpxDAO.DeleteByMaPhieuXuatAndMaSP(maPhieuXuat, maSP) != 0;
        }



        // thêm hàm để xử lý logic riêng trong HoanHangGUI
        public DataTable getChiTietByMaPhieu(int maPhieuXuat)
        {
            var list = ctpxDAO.SelectAll(maPhieuXuat);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP", typeof(int));
            dt.Columns.Add("TenSP", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(decimal)); 

            SanPhamBUS spBUS = new SanPhamBUS();

            foreach (var ct in list)
            {
                string tenSP = spBUS.getNamebyID(ct.Masp);
                dt.Rows.Add(ct.Masp, tenSP, ct.Soluong, ct.Dongia); 
            }

            return dt;
        }
        public BindingList<ChiTietPhieuXuatDTO> getCTPXByMaPX(int mapx)
        {
            return ctpxDAO.SelectAll(mapx);
        }


    }
}