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
    public class PhieuNhapBUS
    {
        public readonly PhieuNhapDAO pnDAO = PhieuNhapDAO.getInstance();
        private BindingList<PhieuNhapDTO> listPN;

        public BindingList<PhieuNhapDTO> getListPN()
        {
            listPN = pnDAO.SelectAll();
            return listPN;
        }

        public PhieuNhapBUS()
        {
            listPN = pnDAO.SelectAll();
        }

        public Boolean removePhieuNhap(int maPhieu)
        {
            PhieuNhapDTO pnXoa = pnDAO.SelectById(maPhieu);
            Boolean result = pnDAO.Delete(maPhieu) != 0;
            if (result)
            {
                listPN.Remove(pnXoa);
            }
            return result;
        }

        public Boolean insertPhieuNhap(PhieuNhapDTO pn)
        {
            Boolean result = pnDAO.Insert(pn) != 0;
            if (result)
            {
                listPN.Add(pn);
            }
            return result;
        }

        public int getAutoMaPhieuNhap()
        {
            // Lấy mã lớn nhất hiện có và +1
            //if (listPN != null && listPN.Count > 0)
            //{
            //    int maxMaPhieu = listPN.Max(pn => pn.Maphieu);
            //    return maxMaPhieu + 1;
            //}
            //else
            //{
            //    // Nếu không có phiếu nào, trả về 1
            //    return 1;
            //}
            return pnDAO.GetAutoIncrement();
        }

        public PhieuNhapDTO getPhieuNhapById(int maPhieu)
        {
            PhieuNhapDTO pn = pnDAO.SelectById(maPhieu);
            return pn;
        }

        public Boolean updatePhieuNhap(PhieuNhapDTO pnSua)
        {
            Boolean result = pnDAO.Update(pnSua) != 0;
            if (result)
            {
                foreach (PhieuNhapDTO pn in listPN)
                {
                    if (pn.Maphieu == pnSua.Maphieu)
                    {
                        pn.Manv = pnSua.Manv;
                        pn.Mancc = pnSua.Mancc;
                        pn.Thoigiantao = pnSua.Thoigiantao;
                        pn.Tongtien = pnSua.Tongtien;
                        pn.Trangthai = pnSua.Trangthai;
                        return result;
                    }
                }
            }
            return result;
        }

        public BindingList<PhieuNhapDTO> SearchPhieuNhap(string search)
        {
            BindingList<PhieuNhapDTO> result = new BindingList<PhieuNhapDTO>();
            foreach (PhieuNhapDTO pn in listPN)
            {
                if (pn.Maphieu.ToString().Contains(search) ||
                    pn.Manv.ToString().Contains(search) ||
                    pn.Mancc.ToString().Contains(search) ||
                    pn.Tongtien.ToString().Contains(search) ||
                    pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss").Contains(search))
                {
                    result.Add(pn);
                }
            }
            return result;
        }


    }
}