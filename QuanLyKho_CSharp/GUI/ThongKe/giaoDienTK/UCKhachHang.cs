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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    public partial class UCKhachHang : UserControl
    {
        ThongKeBUS tkBUS = new ThongKeBUS();
        
        public UCKhachHang()
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
            dgvThongKeKhachHang.Columns.Clear();
            dgvThongKeKhachHang.Columns.Add("Stt", "STT");
            dgvThongKeKhachHang.Columns.Add("Makh", "Mã KH");
            dgvThongKeKhachHang.Columns.Add("Tenkh", "Tên Khách hàng");
            dgvThongKeKhachHang.Columns.Add("Soluongphieu", "Số lượng phiếu");
            dgvThongKeKhachHang.Columns.Add("Tongtien", "Tổng tiền");
            


            dgvThongKeKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            foreach (DataGridViewColumn col in dgvThongKeKhachHang.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvThongKeKhachHang.Columns["Stt"].FillWeight = 10;
            dgvThongKeKhachHang.Columns["Makh"].FillWeight = 15;
            dgvThongKeKhachHang.Columns["Tenkh"].FillWeight = 30;
            dgvThongKeKhachHang.Columns["Soluongphieu"].FillWeight = 20;
            dgvThongKeKhachHang.Columns["Tongtien"].FillWeight = 25;
           


            dgvThongKeKhachHang.RowTemplate.Height = 40;
            dgvThongKeKhachHang.RowHeadersVisible = false;//tat cot du voi hang du
            dgvThongKeKhachHang.AllowUserToAddRows = false;


            LoadDataToGrid();
            

        }

        public void LoadDataToGrid()
        {
           

            BindingList<ThongKeKhachHangDTO> listThongKeKhachHang = tkBUS.thongKeKhachHangList();
            dgvThongKeKhachHang.Rows.Clear();
            foreach (ThongKeKhachHangDTO kh in listThongKeKhachHang)
            {
                dgvThongKeKhachHang.Rows.Add(
                    kh.Stt,
                    $"KH-{kh.Makh}",
                    kh.Tenkh,
                    kh.Soluongphieu,
                    kh.Tongtien
                    
                );


            }
            dgvThongKeKhachHang.ClearSelection();
        }

        public void setUpTimKiem()
        {
            txtTimKiem.TextChanged += (s, ev) => Filter(); 
            Filter();
        }
        public void LoadDataToGridTimKiem(BindingList<ThongKeKhachHangDTO> listThongKeKhachHang)
        {


            
            dgvThongKeKhachHang.Rows.Clear();
            foreach (ThongKeKhachHangDTO kh in listThongKeKhachHang)
            {
                dgvThongKeKhachHang.Rows.Add(
                    kh.Stt,
                    $"KH-{kh.Makh}",
                    kh.Tenkh,
                    kh.Soluongphieu,
                    kh.Tongtien

                );


            }
            dgvThongKeKhachHang.ClearSelection();
        }

        private void Filter()
        {
            string keyWord = txtTimKiem.Text.Trim().ToLower();
   

           
            var listThongKe = tkBUS.thongKeKhachHangList();

            var filtered = listThongKe.Where(kh =>
               
                (string.IsNullOrEmpty(keyWord) || kh.Tenkh.ToLower().Contains(keyWord))).ToList();

           
            LoadDataToGridTimKiem(new BindingList<ThongKeKhachHangDTO>(filtered));
        }


        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvThongKeKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = "ThongKeKhachHang.xlsx";

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
                worksheet.Name = "Thống kê Khách hàng";

                DateTime now = DateTime.Now;
                int thang = now.Month;
                int nam = now.Year;

                // tieu de
                worksheet.Cells[1, 1] = $"BÁO CÁO THỐNG KÊ KHÁCH HÀNG THÁNG {thang} NĂM {nam}";
                Excel.Range titleRange = worksheet.Range["A1", "G1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // tieu de coyt
                string[] headers = { "STT", "Mã KH", "Tên Khách hàng", "Số Phiếu Xuất", "Tổng Tiền (VNĐ)" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[3, i + 1] = headers[i];
                }

                // du lieu
                for (int i = 0; i < dgvThongKeKhachHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvThongKeKhachHang.Columns.Count; j++)
                    {
                        object value = dgvThongKeKhachHang.Rows[i].Cells[j].Value;
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
                    worksheet.Cells[dgvThongKeKhachHang.Rows.Count + 3, 5]
                ];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.Columns.AutoFit();
                dataRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // dinh dang cot tong tien
                Excel.Range moneyRange = worksheet.Range[
                    worksheet.Cells[4, 5],
                    worksheet.Cells[dgvThongKeKhachHang.Rows.Count + 3, 5]
                ];
                moneyRange.NumberFormat = "#,##0 \"VNĐ\"";

                // luu
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                app.Quit();

                // mo file
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
