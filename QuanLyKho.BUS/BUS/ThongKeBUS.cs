using Microsoft.Office.Interop.Excel;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho.DTO.ThongKeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BUS
{
    public class ThongKeBUS
    {
        private PhieuNhapBUS phieuNhapBUS = new PhieuNhapBUS();
        private PhieuXuatBUS phieuXuatBUS = new PhieuXuatBUS();
        private ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
        private ChiTietPhieuNhapBUS ctpnBUS = new ChiTietPhieuNhapBUS();
        private SanPhamBUS spBUS = new SanPhamBUS();
        private KhachHangBUS khBUS = new KhachHangBUS();
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();


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

        public BindingList<ThongKeTonKhoDTO> ThongKeTonKho(int thang, int nam)
        {
            BindingList<ThongKeTonKhoDTO> result = new BindingList<ThongKeTonKhoDTO>();

            var listSP = spBUS.getListSP();
            var listPN = phieuNhapBUS.getListPN();
            var listPX = phieuXuatBUS.getListPX();
            var listCTPN = ctpnBUS.getListCTPN();
            var listCTPX = ctpxBUS.getListCTPX();

            int stt = 1;

            foreach (var sp in listSP)
            {
                ThongKeTonKhoDTO tk = new ThongKeTonKhoDTO();
                tk.Stt = stt++;
                tk.Masp = sp.Masp;
                tk.Tensp = sp.Tensp;

                
                int nhapTruoc = (
                    from pn in listPN
                    join ctpn in listCTPN on pn.Maphieu equals ctpn.Maphieunhap
                    where pn.Thoigiantao.Year == nam && pn.Thoigiantao.Month < thang && ctpn.Masp == sp.Masp
                    select ctpn.Soluong
                ).Sum();

                int xuatTruoc = (
                    from px in listPX
                    join ctpx in listCTPX on px.Maphieu equals ctpx.Maphieuxuat
                    where px.Thoigiantao.Year == nam && px.Thoigiantao.Month < thang && ctpx.Masp == sp.Masp
                    select ctpx.Soluong
                ).Sum();

                tk.TonDauKy = nhapTruoc - xuatTruoc;

                
                tk.NhapTrongKy = (
                    from pn in listPN
                    join ctpn in listCTPN on pn.Maphieu equals ctpn.Maphieunhap
                    where pn.Thoigiantao.Year == nam && pn.Thoigiantao.Month == thang && ctpn.Masp == sp.Masp
                    select ctpn.Soluong
                ).Sum();

                
                tk.XuatTrongKy = (
                    from px in listPX
                    join ctpx in listCTPX on px.Maphieu equals ctpx.Maphieuxuat
                    where px.Thoigiantao.Year == nam && px.Thoigiantao.Month == thang && ctpx.Masp == sp.Masp
                    select ctpx.Soluong
                ).Sum();

                
                tk.TonCuoiKy = tk.TonDauKy + tk.NhapTrongKy - tk.XuatTrongKy;

                result.Add(tk);
            }

            return result;
        }

        public BindingList<ThongKeKhachHangDTO> thongKeKhachHangList()
        {
            BindingList<ThongKeKhachHangDTO> result = new BindingList<ThongKeKhachHangDTO>();

            var listPX = phieuXuatBUS.getListPX();
            var listKH = khBUS.getListKH();
            int stt = 1;

            foreach (var kh in listKH)
            {
                
                var phieuCuaKhachNay = listPX.Where(px => px.Makh == kh.Makh).ToList();

                
                if (phieuCuaKhachNay.Count == 0)
                    continue;

                ThongKeKhachHangDTO khach = new ThongKeKhachHangDTO();
                khach.Stt = stt++;
                khach.Makh = kh.Makh;
                khach.Tenkh = kh.Tenkhachhang;
                khach.Soluongphieu = phieuCuaKhachNay.Count;
                khach.Tongtien = phieuCuaKhachNay.Sum(px => px.Tongtien);

                result.Add(khach);
            }

            return result;


        }

        public BindingList<ThongKeNhaCungCapDTO> thongKeNhaCungCapList()
        {
            BindingList<ThongKeNhaCungCapDTO> result = new BindingList<ThongKeNhaCungCapDTO> ();
            var listPN= phieuNhapBUS.getListPN();
            var listNCC=nccBUS.getListNCC();
            int stt = 1;

            foreach(var ncc in listNCC)
            {
                var phieuCuaNccNay = listPN.Where(pn=>pn.Mancc==ncc.Mancc).ToList();//danhsach tat ca phieu nhap cua nha cc nay
                if(phieuCuaNccNay.Count==0)
                    continue;

                ThongKeNhaCungCapDTO nhacc = new ThongKeNhaCungCapDTO();
                nhacc.Stt = stt++;
                nhacc.Mancc=ncc.Mancc;
                nhacc.Tenncc = ncc.Tenncc;
                nhacc.Soluong = phieuCuaNccNay.Count;
                nhacc.Tongtien=phieuCuaNccNay.Sum(pn=>pn.Tongtien);
                result.Add(nhacc);


            }
            return result;
        }

        public BindingList<ThongKeDoanhThuDTO> thongKeDoanhThuTheoNam(int namBatDau, int namKethuc)
        {
            BindingList<ThongKeDoanhThuDTO> result = new BindingList<ThongKeDoanhThuDTO>();
            var danhSachPN = phieuNhapBUS.getListPN();
            var danhSachPX = phieuXuatBUS.getListPX();
            //lay ra tat ca nam co trong pn va phieu xuat
            var cacNam = danhSachPN.Select(pn => pn.Thoigiantao.Year)
                .Union(danhSachPX.Select(px => px.Thoigiantao.Year))//union dung de ket hop 2 danh sach, loai bo nhung nam bi trung
                .Where(nam => nam >= namBatDau && nam <= namKethuc)
                .OrderBy(nam => nam);///sap xep danh sach nam lay ra tang dan

            foreach(var nam in cacNam)
            {
                int tongVon = danhSachPN.Where(pn => pn.Thoigiantao.Year == nam).Sum(pn => pn.Tongtien);
                int tongLoiNhuan = danhSachPX.Where(px => px.Thoigiantao.Year == nam).Sum(px => px.Tongtien);
                int tongDoanhThuCuaNam = tongLoiNhuan - tongVon;
                result.Add(new ThongKeDoanhThuDTO(nam, tongVon, tongLoiNhuan,tongDoanhThuCuaNam));
            }

            return result;
        }

        public BindingList<ThongKeTheoThangDTO> thongKeDoanhThuTheoThang(int nam)
        {
            BindingList<ThongKeTheoThangDTO> result = new BindingList<ThongKeTheoThangDTO>();

           
            BindingList<PhieuNhapDTO> danhSachPN = phieuNhapBUS.getListPN();
            BindingList<PhieuXuatDTO> danhSachPX = phieuXuatBUS.getListPX();

           
            for (int thang = 1; thang <= 12; thang++)
            {
               
                int tongVon = danhSachPN
                    .Where(pn => pn.Thoigiantao.Year == nam && pn.Thoigiantao.Month == thang)
                    .Sum(pn => (int)pn.Tongtien);

              
                int tongDoanhThu = danhSachPX
                    .Where(px => px.Thoigiantao.Year == nam && px.Thoigiantao.Month == thang)
                    .Sum(px => (int)px.Tongtien);

               
                int loiNhuan = tongDoanhThu - tongVon;

              
                result.Add(new ThongKeTheoThangDTO
                {
                    Thang = thang,
                    Chiphi = tongVon,
                    Doanhthu = tongDoanhThu,
                    Loinhuan = loiNhuan
                });
            }

            return result;
        }

        public BindingList<ThongKeTungNgayTrongThangDTO2> thongKeDoanhThuTheoNgay(int nam, int thang)
        {
            BindingList<ThongKeTungNgayTrongThangDTO2> result = new BindingList<ThongKeTungNgayTrongThangDTO2>();

           
            BindingList<PhieuNhapDTO> danhSachPN = phieuNhapBUS.getListPN();
            BindingList<PhieuXuatDTO> danhSachPX = phieuXuatBUS.getListPX();

          
            int soNgay = DateTime.DaysInMonth(nam, thang);

          
            for (int ngay = 1; ngay <= soNgay; ngay++)
            {
                
                int tongVon = danhSachPN
                    .Where(pn => pn.Thoigiantao.Year == nam
                              && pn.Thoigiantao.Month == thang
                              && pn.Thoigiantao.Day == ngay)
                    .Sum(pn => (int)pn.Tongtien);

               
                int tongDoanhThu = danhSachPX
                    .Where(px => px.Thoigiantao.Year == nam
                              && px.Thoigiantao.Month == thang
                              && px.Thoigiantao.Day == ngay)
                    .Sum(px => (int)px.Tongtien);

              
                int loiNhuan = tongDoanhThu - tongVon;

               
                result.Add(new ThongKeTungNgayTrongThangDTO2
                {
                    Ngay = ngay,
                    Chiphi = tongVon,
                    Doanhthu = tongDoanhThu,
                    Loinhuan = loiNhuan
                });
            }

            return result;
        }

        public BindingList<ThongKeTungNgayTrongThangDTO> thongKeDoanhThuTuNgayDenNgay(DateTime NgayBD, DateTime NgayKT)
        {
            BindingList<ThongKeTungNgayTrongThangDTO> result = new BindingList<ThongKeTungNgayTrongThangDTO>();
            BindingList<PhieuNhapDTO> danhSachPN = phieuNhapBUS.getListPN();
            BindingList<PhieuXuatDTO> danhSachPX = phieuXuatBUS.getListPX();

 
            for (DateTime date = NgayBD.Date; date <= NgayKT.Date; date = date.AddDays(1))
            {
               
                int tongVon = danhSachPN
                    .Where(pn => pn.Thoigiantao.Date == date)
                    .Sum(pn => (int)pn.Tongtien);

           
                int tongDoanhThu = danhSachPX
                    .Where(px => px.Thoigiantao.Date == date)
                    .Sum(px => (int)px.Tongtien);

                int loiNhuan = tongDoanhThu - tongVon;

                result.Add(new ThongKeTungNgayTrongThangDTO
                {
                    Ngay = date,
                    Chiphi = tongVon,
                    Doanhthu = tongDoanhThu,
                    Loinhuan = loiNhuan
                });
            }

            return result;
        }




    }
}
