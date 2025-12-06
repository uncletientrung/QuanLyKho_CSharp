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
    public partial class ThongKeTuNgayDenNgay : UserControl
    {
        ThongKeBUS tkBUS = new ThongKeBUS();
        public ThongKeTuNgayDenNgay()
        {
            InitializeComponent();
        }

        public void load_UC(object sender, EventArgs e)
        {
            loadDataChart();
            setUpColumnAndData();

        }

        private void loadDataChart()
        {
            // Xóa dữ liệu cũ nếu có
            bieuDoThongKeTuNgayDenNgay.Series.Clear();
            bieuDoThongKeTuNgayDenNgay.AxisX.Clear();
            bieuDoThongKeTuNgayDenNgay.AxisY.Clear();

            // ve X
            bieuDoThongKeTuNgayDenNgay.AxisX.Add(new Axis
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
            bieuDoThongKeTuNgayDenNgay.AxisY.Add(new Axis
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

            bieuDoThongKeTuNgayDenNgay.LegendLocation = LegendLocation.Right;
        }

        public void setUpColumnAndData()
        {
            try
            {

                dgvThongKeTuNgayDenNgay.Columns.Clear();
                dgvThongKeTuNgayDenNgay.Columns.Add("Ngay", "Ngày");
                dgvThongKeTuNgayDenNgay.Columns.Add("Chiphi", "Vốn");
                dgvThongKeTuNgayDenNgay.Columns.Add("Doanhthu", "Doanh thu");
                dgvThongKeTuNgayDenNgay.Columns.Add("Loinhuan", "Lợi nhuận");
                dgvThongKeTuNgayDenNgay.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                foreach (DataGridViewColumn col in dgvThongKeTuNgayDenNgay.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgvThongKeTuNgayDenNgay.Columns["Ngay"].FillWeight = 25;
                dgvThongKeTuNgayDenNgay.Columns["Chiphi"].FillWeight = 25;
                dgvThongKeTuNgayDenNgay.Columns["Doanhthu"].FillWeight = 25;
                dgvThongKeTuNgayDenNgay.Columns["Loinhuan"].FillWeight = 25;
                dgvThongKeTuNgayDenNgay.RowTemplate.Height = 40;
                dgvThongKeTuNgayDenNgay.RowHeadersVisible = false;//tat cot du voi hang du
                dgvThongKeTuNgayDenNgay.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndData: {ex.Message}", "Debug Error");
            }
        }

        public void LoadDataToGrid(DateTime NgayBD,DateTime NgayKT)
        {

            try
            {
                BindingList<ThongKeTungNgayTrongThangDTO> listThongKeTuNgayDenNgay = tkBUS.thongKeDoanhThuTuNgayDenNgay(NgayBD, NgayKT);
                dgvThongKeTuNgayDenNgay.Rows.Clear();
                foreach (ThongKeTungNgayTrongThangDTO tk in listThongKeTuNgayDenNgay)
                {


                    dgvThongKeTuNgayDenNgay.Rows.Add(
                        tk.Ngay.ToString("dd/MM/yyyy"),
                        tk.Chiphi,
                        tk.Doanhthu,
                        tk.Loinhuan
                    );
                }
                dgvThongKeTuNgayDenNgay.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime NgayBD = chonNgayBD.Value;
            DateTime NgayKT = chonNgayKT.Value;

            var dataDoanhThuTuNgayDenNgay = tkBUS.thongKeDoanhThuTuNgayDenNgay(NgayBD, NgayKT);

            // Tạo dữ liệu cho các cột
            var von = new ChartValues<double>();
            var doanhThu = new ChartValues<double>();
            var loiNhuan = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var item in dataDoanhThuTuNgayDenNgay)
            {
                labels.Add(item.Ngay.ToString("dd/MM"));
                von.Add(item.Chiphi / 1_000_000.0);
                doanhThu.Add(item.Doanhthu / 1_000_000.0);
                loiNhuan.Add(item.Loinhuan / 1_000_000.0);
            }

            // xoa du lieu cu
            bieuDoThongKeTuNgayDenNgay.Series.Clear();

            // ve truc x trong rong
            bieuDoThongKeTuNgayDenNgay.AxisX[0].Labels = labels;

            // them cac cot du lieu
            bieuDoThongKeTuNgayDenNgay.Series = new SeriesCollection
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

            LoadDataToGrid(NgayBD, NgayKT);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {

                chonNgayBD.Value = DateTime.Now;
                chonNgayKT.Value = DateTime.Now;
                bieuDoThongKeTuNgayDenNgay.Series.Clear();
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
