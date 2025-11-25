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
    public class ChiTietPhieuNhapBUS
    {
        public readonly ChiTietPhieuNhapDAO ctpnDAO = ChiTietPhieuNhapDAO.getInstance();
        private BindingList<ChiTietPhieuNhapDTO> listCTPN;

        public BindingList<ChiTietPhieuNhapDTO> getListCTPN()
        {
            listCTPN = ctpnDAO.SelectAll();
            return listCTPN;
        }

        public ChiTietPhieuNhapBUS()
        {
            listCTPN = ctpnDAO.SelectAll();
        }

        public Boolean insertChiTietPhieuNhap(BindingList<ChiTietPhieuNhapDTO> listCTPN)
        {
            int result = ctpnDAO.Insert(listCTPN);
            return result == listCTPN.Count;
        }

        public Boolean insertSingleChiTietPhieuNhap(ChiTietPhieuNhapDTO ctpn)
        {
            Boolean result = ctpnDAO.InsertSingle(ctpn) != 0;
            if (result)
            {
                listCTPN.Add(ctpn);
            }
            return result;
        }

        public Boolean updateChiTietPhieuNhap(BindingList<ChiTietPhieuNhapDTO> listCTPN, int maPhieuNhap)
        {
            int result = ctpnDAO.Update(listCTPN, maPhieuNhap);
            return result == listCTPN.Count;
        }

        public Boolean deleteChiTietPhieuNhap(int maPhieuNhap)
        {
            return ctpnDAO.Delete(maPhieuNhap) != 0;
        }

        public BindingList<ChiTietPhieuNhapDTO> getChiTietByMaPhieuNhap(int maPhieuNhap)
        {
            return ctpnDAO.SelectAll(maPhieuNhap);
        }

        public Boolean updateSingleChiTietPhieuNhap(ChiTietPhieuNhapDTO ctpn)
        {
            return ctpnDAO.UpdateSingle(ctpn) != 0;
        }

        public Boolean deleteByMaPhieuNhapAndMaSP(int maPhieuNhap, int maSP)
        {
            return ctpnDAO.DeleteByMaPhieuNhapAndMaSP(maPhieuNhap, maSP) != 0;
        }
    }
}