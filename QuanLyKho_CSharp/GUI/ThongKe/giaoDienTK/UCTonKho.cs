using Org.BouncyCastle.Asn1.Cmp;
using QuanLyKho.BUS;
using QuanLyKho.DTO.ThongKeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics; // Dùng để mở file
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    public partial class UCTonKho : UserControl
    {
        private ThongKeBUS tkBUS = new ThongKeBUS();
        
        public UCTonKho()
        {
            InitializeComponent();
           
        }

        public void Load_Form(object sender, EventArgs e)
        {
            setUpCollumnAndData();
            setUpTimKiem();



        }

        public void setUpCollumnAndData()
        {
            dgvThongKeTonKho.Columns.Clear();
            dgvThongKeTonKho.Columns.Add("Stt", "STT");
            dgvThongKeTonKho.Columns.Add("Masp", "Mã SP");
            dgvThongKeTonKho.Columns.Add("Tensp", "Tên Sản phẩm");
            dgvThongKeTonKho.Columns.Add("Tondauky", "Tồn đầu kỳ");
            dgvThongKeTonKho.Columns.Add("Nhap", "Nhập trong kỳ");
            dgvThongKeTonKho.Columns.Add("Xuat", "Xuất trong kỳ");
            dgvThongKeTonKho.Columns.Add("Toncuoiky", "Tồn cuối kì");


            dgvThongKeTonKho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            foreach (DataGridViewColumn col in dgvThongKeTonKho.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvThongKeTonKho.Columns["Stt"].FillWeight = 5;
            dgvThongKeTonKho.Columns["Masp"].FillWeight = 9;
            dgvThongKeTonKho.Columns["Tensp"].FillWeight = 16;
            dgvThongKeTonKho.Columns["Tondauky"].FillWeight = 11;
            dgvThongKeTonKho.Columns["Nhap"].FillWeight = 17;
            dgvThongKeTonKho.Columns["Xuat"].FillWeight = 17;
            dgvThongKeTonKho.Columns["Toncuoiky"].FillWeight = 17;


            dgvThongKeTonKho.RowTemplate.Height = 40;
            dgvThongKeTonKho.RowHeadersVisible = false;//tat cot du voi hang du
            dgvThongKeTonKho.AllowUserToAddRows = false;


            LoadDataToGrid();

        }

        public void LoadDataToGrid()
        {
            DateTime hienTai = DateTime.Now;
            int thangHienTai = hienTai.Month;
            int namHienTai = hienTai.Year;

            BindingList<ThongKeTonKhoDTO> listThongKeTonKho = tkBUS.ThongKeTonKho(thangHienTai, namHienTai);
            dgvThongKeTonKho.Rows.Clear();
            foreach (ThongKeTonKhoDTO sp in listThongKeTonKho)
            {
                dgvThongKeTonKho.Rows.Add(
                    sp.Stt,
                    sp.Masp,
                    sp.Tensp,
                    sp.TonDauKy,
                    sp.NhapTrongKy,
                    sp.XuatTrongKy,
                    sp.TonCuoiKy
                );


            }
            dgvThongKeTonKho.ClearSelection();
        }




        public void LoadDataToGridTimKiem(BindingList<ThongKeTonKhoDTO> listThongKeTonKhoTimKiem)
        {

            dgvThongKeTonKho.Rows.Clear();
            foreach (ThongKeTonKhoDTO sp in listThongKeTonKhoTimKiem)
            {
                dgvThongKeTonKho.Rows.Add(
                    sp.Stt,
                    sp.Masp,
                    sp.Tensp,
                    sp.TonDauKy,
                    sp.NhapTrongKy,
                    sp.XuatTrongKy,
                    sp.TonCuoiKy
                );


            }
            dgvThongKeTonKho.ClearSelection();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
            txtTimKiem.Text = String.Empty;
        }

        public void Filter()
        {
            DateTime hienTai = DateTime.Now;
            int thangHienTai = hienTai.Month;
            int namHienTai = hienTai.Year;
            String keyWord = txtTimKiem.Text.Trim().ToLower();
            var ketqualoc = tkBUS.ThongKeTonKho(thangHienTai,namHienTai).Where(tk =>
            (string.IsNullOrEmpty(keyWord) ||
             tk.Tensp.ToLower().Contains(keyWord))
        ).ToList();
            BindingList<ThongKeTonKhoDTO> thongketonkho = new BindingList<ThongKeTonKhoDTO>(ketqualoc);
            LoadDataToGridTimKiem(thongketonkho);
        }


        public void setUpTimKiem()
        {
            txtTimKiem.TextChanged += (s, ev) => Filter();
            Filter();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKeTonKho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = "ThongKeTonKho.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application app = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                app = new Excel.Application();
                workbook = app.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Thống kê tồn kho";

                DateTime now = DateTime.Now;
                int thang = now.Month;
                int nam = now.Year;

                // ---- DÒNG TIÊU ĐỀ LỚN ----
                worksheet.Cells[1, 1] = $"BÁO CÁO TỒN KHO THÁNG {thang} NĂM {nam}";
                Excel.Range titleRange = worksheet.Range["A1", "G1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ---- TIÊU ĐỀ CỘT ----
                for (int i = 0; i < dgvThongKeTonKho.Columns.Count; i++)
                {
                    worksheet.Cells[3, i + 1] = dgvThongKeTonKho.Columns[i].HeaderText;
                }

                // ---- DỮ LIỆU ----
                for (int i = 0; i < dgvThongKeTonKho.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvThongKeTonKho.Columns.Count; j++)
                    {
                        object value = dgvThongKeTonKho.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 4, j + 1] = value != null ? value.ToString() : "";
                    }
                }

                // ---- ĐỊNH DẠNG ----
                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[3, 1],
                    worksheet.Cells[3, dgvThongKeTonKho.Columns.Count]
                ];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Color.LightGray;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                Excel.Range dataRange = worksheet.Range[
                    worksheet.Cells[3, 1],
                    worksheet.Cells[dgvThongKeTonKho.Rows.Count + 3, dgvThongKeTonKho.Columns.Count]
                ];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.Columns.AutoFit();
                dataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ---- LƯU FILE ----
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                app.Quit();

               

                // ---- MỞ FILE SAU KHI LƯU ----
                if (File.Exists(saveFileDialog.FileName))
                {
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (app != null) Marshal.ReleaseComObject(app);
            }
        }
    }
}
