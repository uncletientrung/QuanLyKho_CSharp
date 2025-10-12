using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace QuanLyKho_CSharp.BUS
{
    public class ChiTietPhieuXuatBUS
    {
        public readonly ChiTietPhieuXuatDAO ctpxDAO = ChiTietPhieuXuatDAO.getInstance();
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

        public Boolean updateSingleChiTietPhieuXuat(ChiTietPhieuXuatDTO ctpx)
        {
            return ctpxDAO.UpdateSingle(ctpx) != 0;
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
            dt.Columns.Add("TenSP");
            dt.Columns.Add("SoLuong");

            SanPhamBUS spBUS = new SanPhamBUS();

            foreach (var ct in list)
            {
                string tenSP = spBUS.getNamebyID(ct.Masp);
                dt.Rows.Add(tenSP, ct.Soluong);
            }

            return dt;
        }


    }
}