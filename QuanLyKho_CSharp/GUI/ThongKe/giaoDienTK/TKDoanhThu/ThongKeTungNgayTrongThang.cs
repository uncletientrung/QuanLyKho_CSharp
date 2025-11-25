using LiveCharts;
using QuanLyKho.DTO.ThongKeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.UninterpretedOption.Types;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using QuanLyKho.BUS;
using SkiaSharp;
using System.Windows.Forms.DataVisualization.Charting;
using Axis = LiveCharts.Wpf.Axis;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu
{
    public partial class ThongKeTungNgayTrongThang : UserControl
    {
        ThongKeBUS tkBUS = new ThongKeBUS();   
        public ThongKeTungNgayTrongThang()
        {
            InitializeComponent();
        }

        public void load_UC(object sender, EventArgs e)
        {
            chonThang.Format = DateTimePickerFormat.Custom;
            chonThang.CustomFormat = "MM";
            chonThang.ShowUpDown = true;

            chonNam.Format = DateTimePickerFormat.Custom;
            chonNam.CustomFormat = "yyyy";
            chonNam.ShowUpDown = true;

            loadDataChart();
            setUpColumnAndData();

        }


        private void loadDataChart()
        {
            // Xóa dữ liệu cũ nếu có
            bieuDoThongKeTungNgayTrongThang.Series.Clear();
            bieuDoThongKeTungNgayTrongThang.AxisX.Clear();
            bieuDoThongKeTungNgayTrongThang.AxisY.Clear();

            // ve X
            bieuDoThongKeTungNgayTrongThang.AxisX.Add(new Axis
            {
                Title = "Ngày",
                Labels = new List<string>(),
                LabelsRotation = 0,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });

            // va truc y
            bieuDoThongKeTungNgayTrongThang.AxisY.Add(new Axis
            {
                Title = "Đơn vị: Triệu đồng",
                LabelFormatter = value => value.ToString("N0"),
                Separator = new Separator
                {
                    Step = 10, // Mỗi vạch cách nhau 10 đơn vị
                    IsEnabled = true,
                    StrokeThickness = 0.7,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection { 3 },
                    Stroke = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(180, 180, 180)
                    )
                }
            });

            bieuDoThongKeTungNgayTrongThang.LegendLocation = LegendLocation.Right;
        }


        public void setUpColumnAndData()
        {
            try
            {

                dgvThongKeTungNgayTrongThang.Columns.Clear();
                dgvThongKeTungNgayTrongThang.Columns.Add("Ngay", "Ngày");
                dgvThongKeTungNgayTrongThang.Columns.Add("Chiphi", "Vốn");
                dgvThongKeTungNgayTrongThang.Columns.Add("Doanhthu", "Doanh thu");
                dgvThongKeTungNgayTrongThang.Columns.Add("Loinhuan", "Lợi nhuận");
                dgvThongKeTungNgayTrongThang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                foreach (DataGridViewColumn col in dgvThongKeTungNgayTrongThang.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgvThongKeTungNgayTrongThang.Columns["Ngay"].FillWeight = 25;
                dgvThongKeTungNgayTrongThang.Columns["Chiphi"].FillWeight = 25;
                dgvThongKeTungNgayTrongThang.Columns["Doanhthu"].FillWeight = 25;
                dgvThongKeTungNgayTrongThang.Columns["Loinhuan"].FillWeight = 25;
                dgvThongKeTungNgayTrongThang.RowTemplate.Height = 40;
                dgvThongKeTungNgayTrongThang.RowHeadersVisible = false;//tat cot du voi hang du
                dgvThongKeTungNgayTrongThang.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndData: {ex.Message}", "Debug Error");
            }
        }

        public void LoadDataToGrid(int nam, int thang)
        {

            try
            {
                BindingList<ThongKeTungNgayTrongThangDTO2> listThongKeTheoThang = tkBUS.thongKeDoanhThuTheoNgay(nam,thang);
                dgvThongKeTungNgayTrongThang.Rows.Clear();
                foreach (ThongKeTungNgayTrongThangDTO2 tk in listThongKeTheoThang)
                {


                    dgvThongKeTungNgayTrongThang.Rows.Add(
                        tk.Ngay,
                        tk.Chiphi,
                        tk.Doanhthu,
                        tk.Loinhuan
                    );
                }
                dgvThongKeTungNgayTrongThang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }


        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int nam = chonNam.Value.Year;
            int thang = chonThang.Value.Month;

            var dataDoanhThuTungNgayTrongThang = tkBUS.thongKeDoanhThuTheoNgay(nam, thang);

            // Tạo dữ liệu cho các cột
            var von = new ChartValues<double>();
            var doanhThu = new ChartValues<double>();
            var loiNhuan = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var item in dataDoanhThuTungNgayTrongThang)
            {
                labels.Add(item.Ngay.ToString());
                von.Add(item.Chiphi / 1_000_000.0);
                doanhThu.Add(item.Doanhthu / 1_000_000.0);
                loiNhuan.Add(item.Loinhuan / 1_000_000.0);
            }

            // xoa du lieu cu
            bieuDoThongKeTungNgayTrongThang.Series.Clear();

            // ve truc x trong rong
            bieuDoThongKeTungNgayTrongThang.AxisX[0].Labels = labels;

            // them cac cot du lieu
            bieuDoThongKeTungNgayTrongThang.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Vốn",
                    Values = von,
                    Fill = System.Windows.Media.Brushes.BlueViolet
                },
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = doanhThu,
                    Fill = System.Windows.Media.Brushes.Green
                },
                new ColumnSeries
                {
                    Title = "Lợi nhuận",
                    Values = loiNhuan,
                    Fill = System.Windows.Media.Brushes.Red
                }
            };

            LoadDataToGrid(nam, thang);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {

                chonNam.Value = DateTime.Now;
                chonThang.Value = DateTime.Now;
                bieuDoThongKeTungNgayTrongThang.Series.Clear();
                loadDataChart();
                setUpColumnAndData();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới: {ex.Message}", "Debug Error");
            }
        }
    }
}
