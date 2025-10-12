﻿using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO.ThongKeDTO;
using SkiaSharp;
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
using Axis = LiveCharts.Wpf.Axis;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using SeriesCollection = LiveCharts.SeriesCollection;




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

   
            LoadChartLiveCharts();
            setUpColumnAndData();
            LoadTongSo();
            LoadBieuDoLoaiSP();
            LoadTop3SanPhamXuat();
           
        }


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

            bieuDoDoanhThuTheoNgay.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Đơn vị: Triệu đồng",
                LabelFormatter = value => value.ToString("N0"),
                MaxValue = 20 // max 20 cu
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
            
            var data = spBUS.TinhSoLuongTungLoai();
       

           
            chartLoaiSP.Series.Clear();
            chartLoaiSP.ChartAreas.Clear();
            chartLoaiSP.Legends.Clear();

            
            ChartArea area = new ChartArea("MainArea");
            chartLoaiSP.ChartAreas.Add(area);

           
            Legend legend = new Legend("Legend");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartLoaiSP.Legends.Add(legend);

          
            Series series = new Series("Loại sản phẩm");
            series.ChartType = SeriesChartType.Pie;
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            series.IsValueShownAsLabel = true; // hiện số lượng hoặc %
            series.LabelForeColor = Color.White;

            // Gán dữ liệu
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);//key la ten loai, value la so luong
            }
        

            //hien thi theo kieu %
            series.Label = "#PERCENT{P1}%"; 
            series.LegendText = "#VALX";

            
            chartLoaiSP.Series.Add(series);

        }

        public void setUpColumnAndData()
        {
            try
            {
                dgvDoanhThu7ngay.AutoGenerateColumns = false;

                dgvDoanhThu7ngay.Columns.Clear();
                dgvDoanhThu7ngay.Columns.Add("Date", "Ngày");
                dgvDoanhThu7ngay.Columns.Add("Chiphi", "Vốn");
                dgvDoanhThu7ngay.Columns.Add("Doanhthu", "Doanh thu");
                dgvDoanhThu7ngay.Columns.Add("Loinhuan", "Lợi nhuận");
                dgvDoanhThu7ngay.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                foreach (DataGridViewColumn col in dgvDoanhThu7ngay.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgvDoanhThu7ngay.Columns["Date"].FillWeight = 25;
                dgvDoanhThu7ngay.Columns["Chiphi"].FillWeight = 25;
                dgvDoanhThu7ngay.Columns["Doanhthu"].FillWeight = 25;
                dgvDoanhThu7ngay.Columns["Loinhuan"].FillWeight = 25;
                dgvDoanhThu7ngay.RowTemplate.Height = 40;
                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndData: {ex.Message}", "Debug Error");
            }
        }

        public void LoadDataToGrid()
        {
            try
            {
                BindingList<ThongKeTungNgayTrongThangDTO> listThongKe7ngay = tkBUS.thongKe7NgayGanDay();
                dgvDoanhThu7ngay.Rows.Clear();
                foreach(ThongKeTungNgayTrongThangDTO tk in listThongKe7ngay)
                {
                    

                    dgvDoanhThu7ngay.Rows.Add(
                        tk.Ngay,
                        tk.Chiphi,
                        tk.Doanhthu,
                        tk.Loinhuan
                    );
                }
                dgvDoanhThu7ngay.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }


        private void LoadTop3SanPhamXuat()
        {
            var top3 = tkBUS.GetTop3SanPhamXuatNhieuNhatTrongThang();

            
            tableTop3SP.Controls.Clear();
            tableTop3SP.RowCount = 0;

            
            Label tieuDe1 = new Label()
            {
                Text = "Tên sản phẩm",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGray
            };
            Label tieuDe2 = new Label()
            {
                Text = "Số lượng",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor= Color.LightGray
            };

            tableTop3SP.Controls.Add(tieuDe1, 0, 0);
            tableTop3SP.Controls.Add(tieuDe2, 1, 0);
            tableTop3SP.RowCount++;



            foreach (var sp in top3)
            {
                Label lblTenSP = new Label()
                {
                    Text = sp.TenSP,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Label lblSoLuong = new Label()
                {
                    Text = sp.TongSoLuong.ToString(),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.SeaGreen
                };

                tableTop3SP.Controls.Add(lblTenSP, 0, tableTop3SP.RowCount);
                tableTop3SP.Controls.Add(lblSoLuong, 1, tableTop3SP.RowCount);
                tableTop3SP.RowCount++;
            }
        }


        private void btnTinhHangTon_Click(object sender, EventArgs e)
        {
            
        }
    }
}
