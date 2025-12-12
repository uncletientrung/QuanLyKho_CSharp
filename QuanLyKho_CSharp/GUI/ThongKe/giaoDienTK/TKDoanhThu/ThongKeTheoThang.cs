using LiveCharts;
using QuanLyKho.BUS;
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
using SkiaSharp;
using System.Windows.Forms.DataVisualization.Charting;
using Axis = LiveCharts.Wpf.Axis;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu
{
    public partial class ThongKeTheoThang : UserControl
    {

        ThongKeBUS tkBUS = new ThongKeBUS();
        public ThongKeTheoThang()
        {
            InitializeComponent();
        }

        public void load_UC(object sender, EventArgs e)
        {
            chonNam.Format = DateTimePickerFormat.Custom;
            chonNam.CustomFormat = "yyyy";
            chonNam.ShowUpDown = true; // Dạng spinbox (không hiển thị lịch)


            loadDataChart();
            setUpColumnAndData();
            btnThongKe_Click(null,null);

        }



        private void loadDataChart()
        {
            // Xóa dữ liệu cũ nếu có
            bieuDoThongKeTheoThang.Series.Clear();
            bieuDoThongKeTheoThang.AxisX.Clear();
            bieuDoThongKeTheoThang.AxisY.Clear();

            // ve X
            bieuDoThongKeTheoThang.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = new List<string>(),
                LabelsRotation = 0,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });

            // va truc y
            bieuDoThongKeTheoThang.AxisY.Add(new Axis
            {
                Title = "Đơn vị: Trăm triệu",
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

            bieuDoThongKeTheoThang.LegendLocation = LegendLocation.Right;
        }


        public void setUpColumnAndData()
        {
            try
            {

                dgvThongKeTheoThang.Columns.Clear();
                dgvThongKeTheoThang.Columns.Add("Thang", "Tháng");
                dgvThongKeTheoThang.Columns.Add("Chiphi", "Vốn");
                dgvThongKeTheoThang.Columns.Add("Doanhthu", "Doanh thu");
                dgvThongKeTheoThang.Columns.Add("Loinhuan", "Lợi nhuận");
                dgvThongKeTheoThang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                foreach (DataGridViewColumn col in dgvThongKeTheoThang.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgvThongKeTheoThang.Columns["Thang"].FillWeight = 25;
                dgvThongKeTheoThang.Columns["Chiphi"].FillWeight = 25;
                dgvThongKeTheoThang.Columns["Doanhthu"].FillWeight = 25;
                dgvThongKeTheoThang.Columns["Loinhuan"].FillWeight = 25;
                dgvThongKeTheoThang.RowTemplate.Height = 40;
                dgvThongKeTheoThang.RowHeadersVisible = false;//tat cot du voi hang du
                dgvThongKeTheoThang.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndData: {ex.Message}", "Debug Error");
            }
        }

        public void LoadDataToGrid(int nam)
        {

            try
            {
                BindingList<ThongKeTheoThangDTO> listThongKeTheoThang = tkBUS.thongKeDoanhThuTheoThang(nam);
                dgvThongKeTheoThang.Rows.Clear();
                foreach (ThongKeTheoThangDTO tk in listThongKeTheoThang)
                {


                    dgvThongKeTheoThang.Rows.Add(
                        tk.Thang,
                        $"{tk.Chiphi:N0} đ",
                        $"{tk.Doanhthu:N0} đ",
                        $"{tk.Loinhuan:N0} đ"
                    );
                }
                dgvThongKeTheoThang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int nam = chonNam.Value.Year;
            
            var dataDoanhThuTungNam = tkBUS.thongKeDoanhThuTheoThang(nam);

            // Tạo dữ liệu cho các cột
            var von = new ChartValues<double>();
            var doanhThu = new ChartValues<double>();
            var loiNhuan = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var item in dataDoanhThuTungNam)
            {
                labels.Add(item.Thang.ToString());
                von.Add((double)(item.Chiphi / 100_000_000.0));
                doanhThu.Add((double)(item.Doanhthu / 100_000_000.0));
                loiNhuan.Add((double)(item.Loinhuan / 100_000_000.0));
            }

            // xoa du lieu cu
            bieuDoThongKeTheoThang.Series.Clear();

            // ve truc x trong rong
            bieuDoThongKeTheoThang.AxisX[0].Labels = labels;

            // them cac cot du lieu
            bieuDoThongKeTheoThang.Series = new SeriesCollection
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

            LoadDataToGrid(nam);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {

                chonNam.Value = DateTime.Now;
               
                bieuDoThongKeTheoThang.Series.Clear();
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
