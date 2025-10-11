using QuanLyKho_CSharp.DTO.ThongKeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.BUS
{
    internal class ThongKeBUS
    {
        private PhieuNhapBUS phieuNhapBUS = new PhieuNhapBUS();
        private PhieuXuatBUS phieuXuatBUS = new PhieuXuatBUS();

        public BindingList<ThongKeTungNgayTrongThangDTO> thongKe7NgayGanDay()
        {
            BindingList<ThongKeTungNgayTrongThangDTO> result = new BindingList<ThongKeTungNgayTrongThangDTO>();
            DateTime homNay = DateTime.Today;
            for(int i=6; i>=0; i--)
            {
                DateTime date = homNay.AddDays(-i);
                // lay danh sach ra roi tinh tong tien, lol trung ngu tien ma de int
                int chiphi = phieuNhapBUS.getListPN().Where(pn => pn.Thoigiantao.Date == date).Sum(pn => pn.Tongtien);
                int doanhThu = phieuXuatBUS.getListPX().Where(px=>px.Thoigiantao.Date == date).Sum(px=> px.Tongtien);
                int loiNhuan = doanhThu - chiphi;
                result.Add(new ThongKeTungNgayTrongThangDTO
                {
                    Ngay = date,
                    Chiphi = chiphi,
                    Doanhthu = doanhThu,
                    Loinhuan = loiNhuan
                }
                );
            }
            return result;
        }

    }
}
