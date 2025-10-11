using QuanLyKho_CSharp.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using SeriesCollection = LiveCharts.SeriesCollection;
using Axis = LiveCharts.Wpf.Axis;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    public partial class UCTongQuan : UserControl
    {
        ThongKeBUS tkBUS = new ThongKeBUS();
        SanPhamBUS spBUS = new SanPhamBUS();
        KhachHangBUS khBUS = new KhachHangBUS();
        PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        PhieuXuatBUS pxBUS = new PhieuXuatBUS();
        public UCTongQuan()
        {
            InitializeComponent();
        }
        private void UCTongQuan_Load(object sender, EventArgs e)
        {

            //LoadChart();
            LoadChartLiveCharts();
            //LoadTable();
            LoadTongSo();
            LoadBieuDoLoaiSP();
        }


        //private void LoadChart()
        //{
        //    var data = tkBUS.thongKe7NgayGanDay();

        //    chartDoanhThu7ngayGanDay.Series.Clear();
        //    chartDoanhThu7ngayGanDay.ChartAreas[0].AxisX.Title = "Ngày";
        //    chartDoanhThu7ngayGanDay.ChartAreas[0].AxisY.Title = "Đơn vị: Triệu đồng";
        //    chartDoanhThu7ngayGanDay.ChartAreas[0].AxisY.Interval = 2_000_000;
        //    chartDoanhThu7ngayGanDay.ChartAreas[0].AxisY.Minimum = 0;
        //    chartDoanhThu7ngayGanDay.ChartAreas[0].AxisY.Maximum = 20_000_000;

        //    var von = new Series("Vốn") { ChartType = SeriesChartType.Column, Color = Color.SkyBlue };
        //    var doanhThu = new Series("Doanh thu") { ChartType = SeriesChartType.Column, Color = Color.SeaGreen };
        //    var loiNhuan = new Series("Lợi nhuận") { ChartType = SeriesChartType.Column, Color = Color.OrangeRed };

        //    foreach (var item in data)
        //    {
        //        string label = item.Ngay.ToString("dd/MM");
        //        von.Points.AddXY(label, item.Chiphi);
        //        doanhThu.Points.AddXY(label, item.Doanhthu);
        //        loiNhuan.Points.AddXY(label, item.Loinhuan);
        //    }

        //    chartDoanhThu7ngayGanDay.Series.Add(von);
        //    chartDoanhThu7ngayGanDay.Series.Add(doanhThu);
        //    chartDoanhThu7ngayGanDay.Series.Add(loiNhuan);
        //}

        private void LoadChartLiveCharts()
        {
           
            var data = tkBUS.thongKe7NgayGanDay();


            //tao du lieu
            var vonValues = new ChartValues<double>();
            var doanhThuValues = new ChartValues<double>();
            var loiNhuanValues = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var item in data)
            {
                labels.Add(item.Ngay.ToString("dd/MM"));
                vonValues.Add(item.Chiphi / 1_000_000.0);     // chuyen sang trieu
                doanhThuValues.Add(item.Doanhthu / 1_000_000.0);
                loiNhuanValues.Add(item.Loinhuan / 1_000_000.0);
            }

            //xoa cau hinh cu
            bieuDoDoanhThuTheoNgay.Series.Clear();
            bieuDoDoanhThuTheoNgay.AxisX.Clear();
            bieuDoDoanhThuTheoNgay.AxisY.Clear();

            // gan du lieu
            bieuDoDoanhThuTheoNgay.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Vốn",
                    Values = vonValues,
                    Fill = System.Windows.Media.Brushes.SkyBlue
                },
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = doanhThuValues,
                    Fill = System.Windows.Media.Brushes.SeaGreen
                },
                new ColumnSeries
                {
                    Title = "Lợi nhuận",
                    Values = loiNhuanValues,
                    Fill = System.Windows.Media.Brushes.OrangeRed
                }
            };

           
            bieuDoDoanhThuTheoNgay.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = labels,
                LabelsRotation = 0, // xoay nhãn nếu cần (0 hoặc 45)
                Separator = new Separator
                {
                    Step = 1,              
                    IsEnabled = false      
                }
            });

            bieuDoDoanhThuTheoNgay.AxisY.Add(new Axis
            {
                Title = "Đơn vị: Triệu đồng",
                LabelFormatter = value => value.ToString("N0")
            });

            bieuDoDoanhThuTheoNgay.LegendLocation = LegendLocation.Right;
           

        }


        private void LoadTongSo()
        {
            string tongSanPham = spBUS.getListSP().Count().ToString();
            btnTinhHangTon.Text = $"Sản Phẩm\n {tongSanPham}";
            btnTinhHangTon.Font = new Font("Segoe UI", 15, FontStyle.Bold); 
            btnTinhHangTon.ForeColor = Color.White; 
            btnTinhHangTon.FlatStyle = FlatStyle.Flat;
            btnTinhHangTon.FlatAppearance.BorderSize = 0; 
            btnTinhHangTon.Cursor = Cursors.Hand; 

            string tongKhachHang = khBUS.getListKH().Count().ToString();
            btnTinhKhachHang.Text = $"Khách Hàng\n {tongKhachHang}";
            btnTinhKhachHang.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            btnTinhKhachHang.ForeColor = Color.White;
            btnTinhKhachHang.FlatStyle = FlatStyle.Flat;
            btnTinhKhachHang.FlatAppearance.BorderSize = 0;
            btnTinhKhachHang.Cursor = Cursors.Hand;

            string tongPhieuNhap = pnBUS.getListPN().Count().ToString();
            btnTinhPhieuNhap.Text = $"Phiếu Nhập\n {tongPhieuNhap}";
            btnTinhPhieuNhap.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            btnTinhPhieuNhap.ForeColor = Color.White;
            btnTinhPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnTinhPhieuNhap.FlatAppearance.BorderSize = 0;
            btnTinhPhieuNhap.Cursor = Cursors.Hand;

            string tongPhieuXuat = pxBUS.getListPX().Count().ToString();
            btnTinhPhieuXuat.Text = $"Phiếu Xuất\n {tongPhieuXuat}";
            btnTinhPhieuXuat.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            btnTinhPhieuXuat.ForeColor = Color.White;
            btnTinhPhieuXuat.FlatStyle = FlatStyle.Flat;
            btnTinhPhieuXuat.FlatAppearance.BorderSize = 0;
            btnTinhPhieuXuat.Cursor = Cursors.Hand;

        }

        private void LoadBieuDoLoaiSP()
        {
            // ====== Giả lập dữ liệu ======
            var data = new List<(string TenLoai, int SoLuong)>
        {
            ("Sách giáo khoa", 120),
            ("Truyện tranh", 80),
            ("Tiểu thuyết", 50),
            ("Khác", 30)
        };

            // Xóa dữ liệu cũ
            chartLoaiSP.Series.Clear();
            chartLoaiSP.ChartAreas.Clear();
            chartLoaiSP.Legends.Clear();

            // ====== Tạo chart area ======
            ChartArea area = new ChartArea("MainArea");
            chartLoaiSP.ChartAreas.Add(area);

            // ====== Tạo legend ======
            Legend legend = new Legend("Legend");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartLoaiSP.Legends.Add(legend);

            // ====== Tạo series dạng Pie ======
            Series series = new Series("Loại sản phẩm");
            series.ChartType = SeriesChartType.Pie;
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            series.IsValueShownAsLabel = true; // hiện số lượng hoặc %
            series.LabelForeColor = Color.White;

            // Gán dữ liệu
            foreach (var item in data)
            {
                series.Points.AddXY(item.TenLoai, item.SoLuong);
            }

            // Hiển thị dạng phần trăm
            series.Label = "#PERCENT{P1}%";  // hoặc "#VALX: #PERCENT{P1}%"
            series.LegendText = "#VALX";

            // Thêm series vào chart
            chartLoaiSP.Series.Add(series);

            // ====== Tùy chỉnh giao diện ======
            chartLoaiSP.Titles.Clear();
            chartLoaiSP.Titles.Add("TỈ LỆ LOẠI SẢN PHẨM TRONG KHO");
            chartLoaiSP.Titles[0].Font = new Font("Segoe UI", 14, FontStyle.Bold);
            chartLoaiSP.BackColor = Color.WhiteSmoke;
            area.BackColor = Color.White;

            // Làm tròn góc và 3D nhẹ
            area.Area3DStyle.Enable3D = true;
        }
        private void btnTinhHangTon_Click(object sender, EventArgs e)
        {
            
        }
    }
}
