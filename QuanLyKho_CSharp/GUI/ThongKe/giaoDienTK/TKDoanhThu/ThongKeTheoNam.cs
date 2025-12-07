using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using QuanLyKho.BUS;
using QuanLyKho.DTO.ThongKeDTO;
using SkiaSharp;
using System.Windows.Forms.DataVisualization.Charting;
using Axis = LiveCharts.Wpf.Axis;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using SeriesCollection = LiveCharts.SeriesCollection;


namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu
{
    public partial class ThongKeTheoNam : UserControl
    {
        ThongKeBUS tkBUS = new ThongKeBUS();
        public ThongKeTheoNam()
        {
            InitializeComponent();
            
        }

        public void load_UC(object sender, EventArgs e)
        {
            namStart.Format = DateTimePickerFormat.Custom;
            namStart.CustomFormat = "yyyy";
            namStart.ShowUpDown = true; // Dạng spinbox (không hiển thị lịch)
            namEnd.Format = DateTimePickerFormat.Custom;
            namEnd.CustomFormat = "yyyy";
            namEnd.ShowUpDown = true; // Dạng spinbox (không hiển thị lịch)
            loadDataChart();
            setUpColumnAndData();
            btnThongKe_Click(null, null);



        }

        private void loadDataChart()
        {
            // Xóa dữ liệu cũ nếu có
            bieuDoDoanhThuTheoNam.Series.Clear();
            bieuDoDoanhThuTheoNam.AxisX.Clear();
            bieuDoDoanhThuTheoNam.AxisY.Clear();

            // ve X
            bieuDoDoanhThuTheoNam.AxisX.Add(new Axis
            {
                Title = "Năm",
                Labels = new List<string>(), 
                LabelsRotation = 0,
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false 
                }
            });

            // va truc y
            bieuDoDoanhThuTheoNam.AxisY.Add(new Axis
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

            bieuDoDoanhThuTheoNam.LegendLocation = LegendLocation.Right;
        }


        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int namBatDau = namStart.Value.Year;
            int namKetThuc = namEnd.Value.Year;

            if (namBatDau > namKetThuc)
            {
                MessageBox.Show("Năm bắt đầu phải nhỏ hơn hoặc bằng năm kết thúc!");
                return;
            }

            var dataDoanhThuTungNam = tkBUS.thongKeDoanhThuTheoNam(namBatDau, namKetThuc);

            // Tạo dữ liệu cho các cột
            var von = new ChartValues<double>();
            var doanhThu = new ChartValues<double>();
            var loiNhuan = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var item in dataDoanhThuTungNam)
            {
                labels.Add(item.Thoigian.ToString());
                von.Add(item.Von / 1_000_000.0);
                doanhThu.Add(item.Doanhthu / 1_000_000.0);
                loiNhuan.Add(item.Loinhuan / 1_000_000.0);
            }

            // xoa du lieu cu
            bieuDoDoanhThuTheoNam.Series.Clear();

            // ve truc x trong rong
            bieuDoDoanhThuTheoNam.AxisX[0].Labels = labels;

            // them cac cot du lieu
            bieuDoDoanhThuTheoNam.Series = new SeriesCollection
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

            LoadDataToGrid(namBatDau,namKetThuc);
        }

        public void setUpColumnAndData()
        {
            try
            {

                dgvThongKeDoanhThuTheoNam.Columns.Clear();
                dgvThongKeDoanhThuTheoNam.Columns.Add("Year", "Năm");
                dgvThongKeDoanhThuTheoNam.Columns.Add("Chiphi", "Vốn");
                dgvThongKeDoanhThuTheoNam.Columns.Add("Doanhthu", "Doanh thu");
                dgvThongKeDoanhThuTheoNam.Columns.Add("Loinhuan", "Lợi nhuận");
                dgvThongKeDoanhThuTheoNam.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                foreach (DataGridViewColumn col in dgvThongKeDoanhThuTheoNam.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                dgvThongKeDoanhThuTheoNam.Columns["Year"].FillWeight = 25;
                dgvThongKeDoanhThuTheoNam.Columns["Chiphi"].FillWeight = 25;
                dgvThongKeDoanhThuTheoNam.Columns["Doanhthu"].FillWeight = 25;
                dgvThongKeDoanhThuTheoNam.Columns["Loinhuan"].FillWeight = 25;
                dgvThongKeDoanhThuTheoNam.RowTemplate.Height = 40;
                dgvThongKeDoanhThuTheoNam.RowHeadersVisible = false;//tat cot du voi hang du
                dgvThongKeDoanhThuTheoNam.AllowUserToAddRows = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndData: {ex.Message}", "Debug Error");
            }
        }

        public void LoadDataToGrid(int nambatdau,int namketthuc)
        {
            
            try
            {
                BindingList<ThongKeDoanhThuDTO> listThongKeTheoNam = tkBUS.thongKeDoanhThuTheoNam(nambatdau,namketthuc);
                dgvThongKeDoanhThuTheoNam.Rows.Clear();
                foreach (ThongKeDoanhThuDTO tk in listThongKeTheoNam)
                {


                    dgvThongKeDoanhThuTheoNam.Rows.Add(
                        tk.Thoigian,
                        tk.Von.ToString("N0"),
                        tk.Doanhthu.ToString("N0"),
                        tk.Loinhuan.ToString("N0")
                    );
                }
                dgvThongKeDoanhThuTheoNam.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
               
                namStart.Value = DateTime.Now;
                namEnd.Value = DateTime.Now;    
                bieuDoDoanhThuTheoNam.Series.Clear(); 
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
