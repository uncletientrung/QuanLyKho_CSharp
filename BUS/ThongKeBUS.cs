using QuanLyKho_CSharp.DTO;
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
        private ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
        private SanPhamBUS spBUS = new SanPhamBUS();

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

        public List<(string TenSP, int TongSoLuong)> GetTop3SanPhamXuatNhieuNhatTrongThang()
        {
            // Lấy tháng hiện tại
            DateTime now = DateTime.Now;
            int thang = now.Month;
            int nam = now.Year;

            // Lấy danh sách phiếu xuất trong tháng hiện tại
            var listPhieuXuat = phieuXuatBUS.getListPX()
                .Where(px => px.Thoigiantao.Month == thang && px.Thoigiantao.Year == nam)
                .ToList();

            // Lấy danh sách chi tiết phiếu xuất
            var listCTPX = ctpxBUS.getListCTPX();

            // Join CTPX với PX theo MaPX để chỉ lấy chi tiết của các phiếu trong tháng này
            var chiTietTrongThang = from ct in listCTPX
                                    join px in listPhieuXuat
                                    on ct.Maphieuxuat equals px.Maphieu
                                    select ct;

            // Gom nhóm theo mã sản phẩm và tính tổng số lượng xuất
            var top3 = chiTietTrongThang
                .GroupBy(ct => ct.Masp)
                .Select(g => new
                {
                    MaSP = g.Key,
                    TongSoLuong = g.Sum(x => x.Soluong)
                })
                .OrderByDescending(x => x.TongSoLuong)
                .Take(3)
                .ToList();

            // Lấy tên sản phẩm từ BUS
            var listSP = spBUS.getListSP();

            // Ánh xạ sang dạng (TenSP, TongSoLuong)
            var result = top3
                .Select(t => (
                    TenSP: listSP.FirstOrDefault(sp => sp.Masp == t.MaSP)?.Tensp ?? "Không xác định",
                    TongSoLuong: t.TongSoLuong
                ))
                .ToList();

            return result;
        }



    }
}
