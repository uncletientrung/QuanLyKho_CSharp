using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.HoanHang;
using QuanLyKho_CSharp.GUI.TaiKhoan;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKho_CSharp.GUI.PhieuXuat
{
    public partial class PhieuXuatGUI : Form
    {
        private PhieuXuatBUS pxBUS = new PhieuXuatBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private KhachHangBUS khBUS = new KhachHangBUS();
        private BindingList<PhieuXuatDTO> listPX;

        public PhieuXuatGUI()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            DGVPhieuXuat.ClearSelection();
            DGVPhieuXuat.RowHeadersVisible = false;
            DGVPhieuXuat.AllowUserToResizeRows = false;
            DGVPhieuXuat.AllowUserToAddRows = false;
            DGVPhieuXuat.ReadOnly = true;
            DGVPhieuXuat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVPhieuXuat.MultiSelect = false;
            DGVPhieuXuat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVPhieuXuat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVPhieuXuat.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVPhieuXuat.ColumnHeadersHeight = 30;
            DGVPhieuXuat.RowHeadersDefaultCellStyle = headerStyle;
            DGVPhieuXuat.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
        }

        private void LoadData()
        {
            listPX = pxBUS.getListPX();
        }

        private void PhieuXuat_Load(object sender, EventArgs e) // Load của giao diện 
        {
            //dateTimeBegin.Value = DateTime.Now.AddMonths(-1);
            //dateTimeEnd.Value = DateTime.Now;
            //numericUpDown1.Value = 0;
            //numericUpDown2.Value = 0;
            refreshDataGridView(listPX);

        }

        private string GetTrangThaiDisplay(PhieuXuatDTO px)
        {
            switch (px.Trangthai)
            {
                case 1: return "Hoạt động";
                case 2: return "Đã hoàn một phần";
                case 3: return "Đã hoàn toàn bộ";
                case 0: return "Đã hủy";
                default: return "Không xác định";
            }
        }

        private void SetRowColor(int rowIndex, PhieuXuatDTO px)
        {
            if (DGVPhieuXuat.Rows.Count > rowIndex)
            {
                switch (px.Trangthai)
                {
                    case 2:
                        DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case 3:
                        DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case 1:
                        DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                    default:
                        DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }

                DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }


        private void DGVPhieuXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maPhieu = int.Parse(DGVPhieuXuat.Rows[e.RowIndex].Cells["mapx"].Value.ToString());
            PhieuXuatDTO phieuDuocChon = pxBUS.getPhieuXuatById(maPhieu);
            if (DGVPhieuXuat.Columns[e.ColumnIndex].Name == "detail")
            {
                ShowDetailPhieuXuatForm(phieuDuocChon);
            }
            if(DGVPhieuXuat.Columns[e.ColumnIndex].Name == "remove"){
                DeletePhieuXuatForm deleteTk = new DeletePhieuXuatForm(phieuDuocChon);
                deleteTk.ShowDialog();
                if (deleteTk.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(pxBUS.getListPX());
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.ParentForm as frmMain;
            if (mainForm != null)
            {
                var method = mainForm.GetType().GetMethod("OpenChildForm",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (method != null)
                {
                    method.Invoke(mainForm, new object[] { new AddPhieuXuatForm(), null });
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (DGVPhieuXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = "DanhSachPhieuXuat.xlsx";

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
                worksheet.Name = "Danh sách phiếu xuất";

                DateTime now = DateTime.Now;

                worksheet.Cells[1, 1] = $"DANH SÁCH PHIẾU XUẤT";
                Excel.Range titleRange = worksheet.Range["A1", "F1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[2, 1] = $"Ngày xuất: {now.ToString("dd/MM/yyyy HH:mm")}";
                worksheet.Cells[2, 1].Font.Italic = true;

                // tiêu đề cột, bỏ qua 2 cột action và hoàn hàng
                int colIndex = 1;
                for (int i = 0; i < DGVPhieuXuat.Columns.Count - 2; i++) // -2 để bỏ qua 2 cột button
                {
                    worksheet.Cells[4, colIndex] = DGVPhieuXuat.Columns[i].HeaderText;
                    colIndex++;
                }

                // dữ liệu
                for (int i = 0; i < DGVPhieuXuat.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < DGVPhieuXuat.Columns.Count - 2; j++) // -2 để bỏ qua 2 cột button
                    {
                        object value = DGVPhieuXuat.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 5, colIndex] = value != null ? value.ToString() : "";
                        colIndex++;
                    }
                }

                // Định dạng header
                int columnCount = DGVPhieuXuat.Columns.Count - 2;
                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[4, 1],
                    worksheet.Cells[4, columnCount]
                ];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Color.LightGray;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Định dạng dữ liệu
                Excel.Range dataRange = worksheet.Range[
                    worksheet.Cells[4, 1],
                    worksheet.Cells[DGVPhieuXuat.Rows.Count + 4, columnCount]
                ];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // Căn giữa tất cả các cột trừ cột tên
                for (int col = 1; col <= columnCount; col++)
                {
                    Excel.Range columnRange = worksheet.Range[
                        worksheet.Cells[5, col],
                        worksheet.Cells[DGVPhieuXuat.Rows.Count + 4, col]
                    ];

                    if (col == 2 || col == 3) // Cột Tên NV và Tên KH (căn trái)
                    {
                        columnRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    }
                    else // Các cột còn lại căn giữa
                    {
                        columnRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                }

                // Auto-fit columns
                dataRange.Columns.AutoFit();

                // Tổng kết - Sử dụng merge cell để hiển thị đẹp hơn
                int lastRow = DGVPhieuXuat.Rows.Count + 5;

                // Tổng số phiếu - Merge từ cột A đến B
                Excel.Range totalPhieuRange = worksheet.Range[worksheet.Cells[lastRow + 1, 1], worksheet.Cells[lastRow + 1, 2]];
                totalPhieuRange.Merge();
                totalPhieuRange.Value = "TỔNG SỐ PHIẾU:";
                totalPhieuRange.Font.Bold = true;
                totalPhieuRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                worksheet.Cells[lastRow + 1, 3] = DGVPhieuXuat.Rows.Count;
                worksheet.Cells[lastRow + 1, 3].Font.Bold = true;
                worksheet.Cells[lastRow + 1, 3].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                // Tính tổng tiền
                decimal tongTien = 0;
                for (int i = 0; i < DGVPhieuXuat.Rows.Count; i++)
                {
                    if (DGVPhieuXuat.Rows[i].Cells["TongTien"].Value != null)
                    {
                        tongTien += Convert.ToDecimal(DGVPhieuXuat.Rows[i].Cells["TongTien"].Value);
                    }
                }

                // Tổng doanh thu - Merge từ cột A đến B
                Excel.Range totalDoanhThuLabelRange = worksheet.Range[worksheet.Cells[lastRow + 2, 1], worksheet.Cells[lastRow + 2, 2]];
                totalDoanhThuLabelRange.Merge();
                totalDoanhThuLabelRange.Value = "TỔNG DOANH THU:";
                totalDoanhThuLabelRange.Font.Bold = true;
                totalDoanhThuLabelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                // Merge từ cột C đến D cho giá trị tổng doanh thu
                Excel.Range totalDoanhThuValueRange = worksheet.Range[worksheet.Cells[lastRow + 2, 3], worksheet.Cells[lastRow + 2, 4]];
                totalDoanhThuValueRange.Merge();
                totalDoanhThuValueRange.Value = tongTien.ToString("N0") + " VNĐ";
                totalDoanhThuValueRange.Font.Bold = true;
                totalDoanhThuValueRange.Font.Color = Color.Red;
                totalDoanhThuValueRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                // ---- LƯU FILE ----
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                app.Quit();

                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ---- MỞ FILE SAU KHI LƯU ----
                if (File.Exists(saveFileDialog.FileName))
                {
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (app != null) Marshal.ReleaseComObject(app);
            }
        }

        //private void FilterData()
        //{
        //    if (listPX == null) return;

        //    // HIỂN THỊ TẤT CẢ phiếu có trạng thái khác 0
        //    var filteredList = listPX.Where(px => px.Trangthai != 0).AsEnumerable();

        //    // Lọc theo tên nhân viên
        //    if (!string.IsNullOrWhiteSpace(txtSearchNV.Text))
        //    {
        //        string searchText = txtSearchNV.Text.Trim().ToLower();
        //        filteredList = filteredList.Where(px =>
        //        {
        //            string tenNV = nvBUS.getNamebyID(px.Manv)?.ToLower() ?? "";
        //            return tenNV.Contains(searchText);
        //        });
        //    }

        //    // Lọc theo tên khách hàng
        //    if (!string.IsNullOrWhiteSpace(txtSearchKH.Text))
        //    {
        //        string searchText = txtSearchKH.Text.Trim().ToLower();
        //        filteredList = filteredList.Where(px =>
        //        {
        //            string tenKH = khBUS.getNamebyID(px.Makh)?.ToLower() ?? "";
        //            return tenKH.Contains(searchText);
        //        });
        //    }

        //    // Lọc theo khoảng thời gian
        //    if (dateTimeBegin.Value != null && dateTimeEnd.Value != null)
        //    {
        //        DateTime startDate = dateTimeBegin.Value.Date;
        //        DateTime endDate = dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1);
        //        filteredList = filteredList.Where(px =>
        //            px.Thoigiantao >= startDate && px.Thoigiantao <= endDate);
        //    }

        //    // Lọc theo khoảng giá
        //    if (numericUpDown1.Value > 0 || numericUpDown2.Value > 0)
        //    {
        //        decimal minPrice = numericUpDown1.Value;
        //        decimal maxPrice = numericUpDown2.Value > 0 ? numericUpDown2.Value : decimal.MaxValue;

        //        filteredList = filteredList.Where(px =>
        //            px.Tongtien >= minPrice && px.Tongtien <= maxPrice);
        //    }

        //    DisplayFilteredData(filteredList.ToList());
        //}

        private void DisplayFilteredData(List<PhieuXuatDTO> filteredData)
        {
            DGVPhieuXuat.Rows.Clear();

            if (filteredData != null && filteredData.Count > 0)
            {
                foreach (PhieuXuatDTO px in filteredData)
                {
                    string tenNV = nvBUS.getNamebyID(px.Manv);
                    string tenKH = khBUS.getNamebyID(px.Makh);

                    string trangThai = "";
                    Color backColor = Color.White;
                    Color foreColor = Color.Black;

                    switch (px.Trangthai)
                    {
                        case 0:
                            trangThai = "Đã hủy";
                            backColor = Color.LightGray;
                            foreColor = Color.DarkRed;
                            break;
                        case 1:
                            trangThai = "Hoạt động";
                            backColor = Color.White;
                            foreColor = Color.Black;
                            break;
                        case 2:
                            trangThai = "Hoàn một phần";
                            backColor = Color.LightGoldenrodYellow;
                            foreColor = Color.Black;
                            break;
                        case 3:
                            trangThai = "Hoàn toàn bộ";
                            backColor = Color.OrangeRed;
                            foreColor = Color.Black;
                            break;
                        default:
                            trangThai = "Không xác định";
                            break;
                    }

                    int rowIndex = DGVPhieuXuat.Rows.Add(
                        px.Maphieu,
                        tenNV,
                        tenKH,
                        px.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        px.Tongtien,
                        trangThai
                    );

                    // Chỉ đặt màu nếu KHÔNG phải là trạng thái "Hoạt động"
                    if (rowIndex >= 0 && px.Trangthai != 1)
                    {
                        DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.BackColor = backColor;
                        DGVPhieuXuat.Rows[rowIndex].DefaultCellStyle.ForeColor = foreColor;
                    }
                }
            }

            DGVPhieuXuat.ClearSelection();
        }

        private void ShowDetailPhieuXuatForm(PhieuXuatDTO phieuXuat)
        {
            try
            {
                DetailPhieuXuatForm detailForm = new DetailPhieuXuatForm(phieuXuat);
                detailForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chi tiết: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void txtSearchNV_TextChanged(object sender, EventArgs e)
        //{
        //    FilterData();
        //}

        //private void txtSearchKH_TextChanged(object sender, EventArgs e)
        //{
        //    FilterData();
        //}

        //private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        //{
        //    FilterData();
        //}

        //private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        //{
        //    FilterData();
        //}

        //private void dateTimeBegin_ValueChanged(object sender, EventArgs e)
        //{
        //    FilterData();
        //}

        //private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        //{
        //    FilterData();
        //}


        // hiển thị dialog hoàn hàng
        private void dialogHoanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DGVPhieuXuat.Columns["hoanhang"].Index)
            {
                int maPhieu = Convert.ToInt32(DGVPhieuXuat.Rows[e.RowIndex].Cells["maphieu"].Value);

                PhieuXuatDTO phieu = pxBUS.getPhieuXuatById(maPhieu);
                string tenKH = khBUS.getNamebyID(phieu.Makh);
                decimal tongTien = phieu.Tongtien;

                ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
                DataTable chiTiet = ctpxBUS.getChiTietByMaPhieu(maPhieu);

                var dialog = new QuanLyKho_CSharp.GUI.HoanHang.HoanHang(maPhieu, tenKH, (int)phieu.Manv, tongTien, chiTiet);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Đơn giản chỉ cần reload dữ liệu
                        // Không cần gọi CapNhatTrangThaiPhieuXuat vì đã được xử lý trong HoanHangGUI
                        LoadData();
                        //LoadDataIntoGridView();

                        MessageBox.Show("Cập nhật hoàn hàng thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Reload để đảm bảo đồng bộ
                    LoadData();
                    //LoadDataIntoGridView();
                }
            }
        }

        private void refreshDataGridView(BindingList<PhieuXuatDTO> listRefresh) // Tải lại DataGridView
        {
            int soLuongNV = 0;
            DGVPhieuXuat.Rows.Clear();
            foreach (PhieuXuatDTO px in listRefresh)
            {
                if (px.Trangthai != 0)
                {
                    string tenNV = nvBUS.getNamebyID(px.Manv);
                    string tenKH = khBUS.getNamebyID(px.Makh);
                    string trangThai = GetTrangThaiDisplay(px);

                    int rowIndex = DGVPhieuXuat.Rows.Add(
                        px.Maphieu,
                        tenNV,
                        tenKH,
                        px.Thoigiantao.ToString(" HH:mm dd/MM/yyyy"),
                        px.Tongtien,
                        trangThai
                    );
                    SetRowColor(rowIndex, px);
                }
            }

                DGVPhieuXuat.ClearSelection();
        }

        // Các sự kiện khác
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void txtSearchNV_Enter(object sender, EventArgs e) { }
        private void txtSearchNV_Leave(object sender, EventArgs e) { }
        private void txtSearchKH_Enter(object sender, EventArgs e) { }
        private void txtSearchKH_Leave(object sender, EventArgs e) { }

        private void rjDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}