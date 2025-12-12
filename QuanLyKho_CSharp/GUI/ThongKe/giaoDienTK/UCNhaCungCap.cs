using QuanLyKho.BUS;
using QuanLyKho.DTO.ThongKeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // Dùng để mở file
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    public partial class UCNhaCungCap : UserControl
    {
        ThongKeBUS tkBUS = new ThongKeBUS();
        public UCNhaCungCap()
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
            dgvThongKeNhaCungCap.Columns.Clear();
            dgvThongKeNhaCungCap.Columns.Add("Stt", "STT");
            dgvThongKeNhaCungCap.Columns.Add("Mancc", "Mã NCC");
            dgvThongKeNhaCungCap.Columns.Add("Tenncc", "Tên Nhà cung cấp");
            dgvThongKeNhaCungCap.Columns.Add("Soluongphieu", "Số lượng phiếu");
            dgvThongKeNhaCungCap.Columns.Add("Tongtien", "Tổng tiền");



            dgvThongKeNhaCungCap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            foreach (DataGridViewColumn col in dgvThongKeNhaCungCap.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvThongKeNhaCungCap.Columns["Stt"].FillWeight = 10;
            dgvThongKeNhaCungCap.Columns["Mancc"].FillWeight = 15;
            dgvThongKeNhaCungCap.Columns["Tenncc"].FillWeight = 30;
            dgvThongKeNhaCungCap.Columns["Soluongphieu"].FillWeight = 20;
            dgvThongKeNhaCungCap.Columns["Tongtien"].FillWeight = 25;



            dgvThongKeNhaCungCap.RowTemplate.Height = 40;
            dgvThongKeNhaCungCap.RowHeadersVisible = false;//tat cot du voi hang du
            dgvThongKeNhaCungCap.AllowUserToAddRows = false;


            LoadDataToGrid();


        }

        public void LoadDataToGrid()
        {


            BindingList<ThongKeNhaCungCapDTO> listThongKeNCC = tkBUS.thongKeNhaCungCapList();
            dgvThongKeNhaCungCap.Rows.Clear();
            foreach (ThongKeNhaCungCapDTO ncc in listThongKeNCC)
            {
                dgvThongKeNhaCungCap.Rows.Add(
                    ncc.Stt,
                    $"NCC-{ncc.Mancc}",
                    ncc.Tenncc,
                    ncc.Soluong,
                    ncc.Tongtien

                );


            }
            dgvThongKeNhaCungCap.ClearSelection();
        }

        public void setUpTimKiem()
        {
            txtTimKiem.TextChanged += (s, ev) => Filter();
            Filter();
        }
        public void LoadDataToGridTimKiem(BindingList<ThongKeNhaCungCapDTO> listThongKeNCC)
        {



            dgvThongKeNhaCungCap.Rows.Clear();
            foreach (ThongKeNhaCungCapDTO ncc in listThongKeNCC)
            {
                dgvThongKeNhaCungCap.Rows.Add(
                    ncc.Stt,
                    $"NCC-{ncc.Mancc}",
                    ncc.Tenncc,
                    ncc.Soluong,
                    ncc.Tongtien

                );


            }
            dgvThongKeNhaCungCap.ClearSelection();
        }

        private void Filter()
        {
            string keyWord = txtTimKiem.Text.Trim().ToLower();


            
            var listThongKe = tkBUS.thongKeNhaCungCapList();

            var filtered = listThongKe.Where(ncc =>

                (string.IsNullOrEmpty(keyWord) || ncc.Tenncc.ToLower().Contains(keyWord))).ToList();


            LoadDataToGridTimKiem(new BindingList<ThongKeNhaCungCapDTO>(filtered));
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKeNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveFileDialog.FileName = $"ThongKeNhaCungCap_{timeStamp}.xlsx";

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
                worksheet.Name = "Thống kê Nhà cung cấp";

                DateTime now = DateTime.Now;
                int thang = now.Month;
                int nam = now.Year;

           
                worksheet.Cells[1, 1] = $"BÁO CÁO THỐNG KÊ NHÀ CUNG CẤP THÁNG {thang} NĂM {nam}";
                Excel.Range titleRange = worksheet.Range["A1", "G1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

           
                string[] headers = { "STT", "Mã NCC", "Tên Nhà Cung Cấp", "Số Phiếu Nhập", "Tổng Tiền (VNĐ)" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[3, i + 1] = headers[i];
                }

              
                for (int i = 0; i < dgvThongKeNhaCungCap.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvThongKeNhaCungCap.Columns.Count; j++)
                    {
                        object value = dgvThongKeNhaCungCap.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 4, j + 1] = value != null ? value.ToString() : "";
                    }
                }

          
                Excel.Range headerRange = worksheet.Range["A3", "E3"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Color.LightGray;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                Excel.Range dataRange = worksheet.Range[
                    worksheet.Cells[3, 1],
                    worksheet.Cells[dgvThongKeNhaCungCap.Rows.Count + 3, 5]
                ];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.Columns.AutoFit();
                dataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

               
                Excel.Range moneyRange = worksheet.Range[
                    worksheet.Cells[4, 5],
                    worksheet.Cells[dgvThongKeNhaCungCap.Rows.Count + 3, 5]
                ];
                moneyRange.NumberFormat = "#,##0 \"VNĐ\"";

               
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                app.Quit();

           
                if (File.Exists(saveFileDialog.FileName))
                {
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
