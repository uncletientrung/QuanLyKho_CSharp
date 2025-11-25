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
    public class PhieuXuatBUS
    {
        public readonly PhieuXuatDAO pxDAO = PhieuXuatDAO.getInstance();
        private BindingList<PhieuXuatDTO> listPX;

        public BindingList<PhieuXuatDTO> getListPX()
        {
            listPX = pxDAO.SelectAll();
            return listPX;
        }

        public PhieuXuatBUS()
        {
            listPX = pxDAO.SelectAll();
        }

        public Boolean removePhieuXuat(int maPhieu)
        {
            PhieuXuatDTO pxXoa = pxDAO.SelectById(maPhieu);
            Boolean result = pxDAO.Delete(maPhieu) != 0;
            if (result)
            {
                listPX.Remove(pxXoa);
            }
            return result;
        }

        public Boolean insertPhieuXuat(PhieuXuatDTO px)
        {
            Boolean result = pxDAO.Insert(px) != 0;
            if (result)
            {
                listPX.Add(px);
            }
            return result;
        }

        public int getAutoMaPhieuXuat()
        {
            // Lấy mã lớn nhất hiện có và +1
            if (listPX != null && listPX.Count > 0)
            {
                int maxMaPhieu = listPX.Max(pn => pn.Maphieu);
                return maxMaPhieu + 1;
            }
            else
            {
                // Nếu không có phiếu nào, trả về 1
                return 1;
            }
        }

        public PhieuXuatDTO getPhieuXuatById(int maPhieu)
        {
            PhieuXuatDTO px = pxDAO.SelectById(maPhieu);
            return px;
        }

        public Boolean updatePhieuXuat(PhieuXuatDTO pxSua)
        {
            Boolean result = pxDAO.Update(pxSua) != 0;
            if (result)
            {
                foreach (PhieuXuatDTO px in listPX)
                {
                    if (px.Maphieu == pxSua.Maphieu)
                    {
                        px.Manv = pxSua.Manv;
                        px.Makh = pxSua.Makh;
                        px.Thoigiantao = pxSua.Thoigiantao;
                        px.Tongtien = pxSua.Tongtien;
                        px.Trangthai = pxSua.Trangthai;
                        return result;
                    }
                }
            }
            return result;
        }

        public BindingList<PhieuXuatDTO> SearchPhieuXuat(string search)
        {
            BindingList<PhieuXuatDTO> result = new BindingList<PhieuXuatDTO>();
            foreach (PhieuXuatDTO px in listPX)
            {
                if (px.Maphieu.ToString().Contains(search) ||
                    px.Manv.ToString().Contains(search) ||
                    px.Makh.ToString().Contains(search) ||
                    px.Tongtien.ToString().Contains(search) ||
                    px.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss").Contains(search))
                {
                    result.Add(px);
                }
            }
            return result;
        }
    }
}