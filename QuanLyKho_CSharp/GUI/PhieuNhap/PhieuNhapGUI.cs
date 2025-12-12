using QuanLyKho.BUS;
using QuanLyKho.DTO;
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

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class PhieuNhapGUI : Form
    {
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private BindingList<PhieuNhapDTO> listPN;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public PhieuNhapGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
            this.currentUser = currentUser;
            cbbSearch.Items.Add("Tất cả");
            cbbSearch.Items.Add("Mã");
            cbbSearch.Items.Add("Nhân viên");
            cbbSearch.Items.Add("Nhà cung cấp");
            cbbSearch.SelectedIndex = 0;
            cbbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            settingRole();

        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("nhaphang");
            var listCT = nqBUS.getListCTNQByIdNQ(maNQ)
                .Where(ctnq => ctnq.Machucnang == maDMNC).ToList();
            listCTQ = new BindingList<ChiTietQuyenDTO>(listCT);
            // Thực hiện ẩn nút
            bool checkThem = false;
            bool checkXoa = false;
            foreach (ChiTietQuyenDTO ctq in listCTQ)
            {
                if (ctq.Hanhdong == "Thêm") checkThem = true;
                if (ctq.Hanhdong == "Xóa") checkXoa = true;
            }
            if (!checkThem)
            {
                btnThem.Visible = false;
            }
            if (!checkXoa) DGVPhieuNhap.Columns.Remove("remove");
        }
        private void SetupDataGridView()
        {
            DGVPhieuNhap.ClearSelection();
            DGVPhieuNhap.RowHeadersVisible = false;
            DGVPhieuNhap.AllowUserToResizeRows = false;
            DGVPhieuNhap.AllowUserToAddRows = false;
            DGVPhieuNhap.ReadOnly = true;
            DGVPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVPhieuNhap.MultiSelect = false;
            DGVPhieuNhap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVPhieuNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVPhieuNhap.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVPhieuNhap.ColumnHeadersHeight = 30;
            DGVPhieuNhap.RowHeadersDefaultCellStyle = headerStyle;
            DGVPhieuNhap.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
        }

        private void LoadData()
        {
            listPN = pnBUS.getListPN();    
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            //refreshDataGridView(listPN);
            FilterData();
        }

        private void DGVPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int mapn = int.Parse(DGVPhieuNhap.CurrentRow.Cells[0].Value.ToString().Replace("PN-",""));
            PhieuNhapDTO pnDTO= pnBUS.getPhieuNhapById(mapn);
            if (DGVPhieuNhap.Columns[e.ColumnIndex].Name == "detail")
            {
                ShowDetailPhieuNhapForm(pnDTO);
                pnBUS = new PhieuNhapBUS();
                refreshDataGridView(pnBUS.getListPN());
            }else if(DGVPhieuNhap.Columns[e.ColumnIndex].Name == "remove")
            {
                DeletePhieuNhapForm deleteTk = new DeletePhieuNhapForm(pnDTO);
                deleteTk.ShowDialog();
                if (deleteTk.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(pnBUS.getListPN());
                }
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnlDGV.Visible = false;
            pnlTop.Visible = false;
            AddPhieuNhapForm addFormControl = null;
            addFormControl = new AddPhieuNhapForm(() => btnOnClose(addFormControl), currentUser,
               () => refreshDataGridView(pnBUS.getListPN()));
            addFormControl.TopLevel = false;
            addFormControl.FormBorderStyle = FormBorderStyle.None;
            addFormControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(addFormControl);
            addFormControl.Show();
        }
        private void btnOnClose(AddPhieuNhapForm formAdd)
        {
            pnlDGV.Visible = true;
            pnlTop.Visible = true;
            pnlMain.Controls.Remove(formAdd);
            formAdd.Dispose();

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (DGVPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = $"DanhSachPhieuNhap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application app = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                app = new Excel.Application();
                app.Visible = false;
                app.DisplayAlerts = false;

                workbook = app.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Phiếu nhập";

                DateTime now = DateTime.Now;

                // 1. TIÊU ĐỀ CHÍNH
                worksheet.Cells[1, 1] = "DANH SÁCH PHIẾU NHẬP";
                Excel.Range titleRange = worksheet.Range["A1", "F1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.Font.Name = "Times New Roman";

                // 2. THÔNG TIN XUẤT BÁO CÁO
                worksheet.Cells[2, 1] = $"Người xuất: {currentUser.Tennv}";
                worksheet.Cells[2, 1].Font.Italic = true;
                worksheet.Cells[2, 1].Font.Size = 10;

                worksheet.Cells[3, 1] = $"Ngày xuất: {now:HH:mm dd/MM/yyyy}";
                worksheet.Cells[3, 1].Font.Italic = true;
                worksheet.Cells[3, 1].Font.Size = 10;

                // 3. TIÊU ĐỀ CỘT
                int startRow = 5; // Dòng bắt đầu dữ liệu
                int colIndex = 1;

                // Xác định các cột cần xuất (bỏ cột action cuối cùng)
                var columnsToExport = new List<DataGridViewColumn>();
                foreach (DataGridViewColumn col in DGVPhieuNhap.Columns)
                {
                    if (col.Name != "detail" && col.Name != "remove")
                    {
                        columnsToExport.Add(col);
                    }
                }

                // Ghi tiêu đề cột
                foreach (var col in columnsToExport)
                {
                    worksheet.Cells[startRow, colIndex] = col.HeaderText;
                    colIndex++;
                }

                // 4. DỮ LIỆU
                for (int i = 0; i < DGVPhieuNhap.Rows.Count; i++)
                {
                    colIndex = 1;
                    foreach (var col in columnsToExport)
                    {
                        object value = DGVPhieuNhap.Rows[i].Cells[col.Index].Value;

                        // Xử lý riêng cho cột tổng tiền (cột số 5, index 4)
                        if (col.Index == 4 && value != null)
                        {
                            string moneyValue = value.ToString();
                            // Loại bỏ ký tự 'đ' nếu có
                            moneyValue = moneyValue.Replace("đ", "").Replace(",", "").Trim();
                            if (long.TryParse(moneyValue, out long money))
                            {
                                worksheet.Cells[startRow + i + 1, colIndex] = money;
                                // Định dạng số tiền
                                worksheet.Cells[startRow + i + 1, colIndex].NumberFormat = "#,##0";
                            }
                            else
                            {
                                worksheet.Cells[startRow + i + 1, colIndex] = value?.ToString() ?? "";
                            }
                        }
                        else
                        {
                            worksheet.Cells[startRow + i + 1, colIndex] = value?.ToString() ?? "";
                        }
                        colIndex++;
                    }
                }

                // 5. ĐỊNH DẠNG BẢNG
                int totalRows = DGVPhieuNhap.Rows.Count;
                int totalCols = columnsToExport.Count;

                // Định dạng header
                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[startRow, 1],
                    worksheet.Cells[startRow, totalCols]
                ];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Color.FromArgb(217, 225, 242); // Màu xanh nhạt
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                headerRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                // Định dạng toàn bộ bảng
                Excel.Range tableRange = worksheet.Range[
                    worksheet.Cells[startRow, 1],
                    worksheet.Cells[startRow + totalRows, totalCols]
                ];
                tableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                tableRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                tableRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // Căn chỉnh từng cột
                for (int col = 1; col <= totalCols; col++)
                {
                    Excel.Range columnRange = worksheet.Range[
                        worksheet.Cells[startRow + 1, col],
                        worksheet.Cells[startRow + totalRows, col]
                    ];

                    // Các cột số (Mã, Tổng tiền) căn giữa
                    if (col == 1 || col == 5) // Mã phiếu và Tổng tiền
                    {
                        columnRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                    else // Các cột text căn trái
                    {
                        columnRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    }
                }

                // Cột tổng tiền format
                if (totalCols >= 5) // Đảm bảo có cột tổng tiền
                {
                    Excel.Range moneyColumn = worksheet.Range[
                        worksheet.Cells[startRow + 1, 5],
                        worksheet.Cells[startRow + totalRows, 5]
                    ];
                    moneyColumn.NumberFormat = "#,##0\" ₫\"";
                    moneyColumn.Font.Color = Color.Black;
                }

                // 6. TỔNG KẾT - ĐẶT Ở CỘT H VÀ I
                int summaryRow = startRow + totalRows + 2;

                // Tổng số phiếu - Chiếm 2 cột H5,I5
                Excel.Range totalPhieuRange = worksheet.Range[worksheet.Cells[summaryRow, 8], worksheet.Cells[summaryRow, 9]];
                totalPhieuRange.Merge();
                totalPhieuRange.Value = "TỔNG SỐ PHIẾU:";
                totalPhieuRange.Font.Bold = true;
                totalPhieuRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                totalPhieuRange.Font.Size = 11;

                worksheet.Cells[summaryRow, 10] = totalRows;
                worksheet.Cells[summaryRow, 10].Font.Bold = true;
                worksheet.Cells[summaryRow, 10].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                worksheet.Cells[summaryRow, 10].Font.Size = 11;
                worksheet.Cells[summaryRow, 10].NumberFormat = "#,##0";

                // Tổng tiền - Chiếm 2 cột H6,I6
                Excel.Range totalCostLabelRange = worksheet.Range[worksheet.Cells[summaryRow + 1, 8], worksheet.Cells[summaryRow + 1, 9]];
                totalCostLabelRange.Merge();
                totalCostLabelRange.Value = "TỔNG CHI PHÍ:";
                totalCostLabelRange.Font.Bold = true;
                totalCostLabelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                totalCostLabelRange.Font.Size = 11;

                // Tính tổng tiền
                decimal tongTien = 0;
                for (int i = 0; i < DGVPhieuNhap.Rows.Count; i++)
                {
                    if (DGVPhieuNhap.Rows[i].Cells[4].Value != null)
                    {
                        string moneyValue = DGVPhieuNhap.Rows[i].Cells[4].Value.ToString()
                            .Replace("đ", "").Replace(",", "").Trim();
                        if (decimal.TryParse(moneyValue, out decimal money))
                        {
                            tongTien += money;
                        }
                    }
                }

                worksheet.Cells[summaryRow + 1, 10] = tongTien;
                worksheet.Cells[summaryRow + 1, 10].NumberFormat = "#,##0\" ₫\"";
                worksheet.Cells[summaryRow + 1, 10].Font.Bold = true;
                worksheet.Cells[summaryRow + 1, 10].Font.Color = Color.Red;
                worksheet.Cells[summaryRow + 1, 10].Font.Size = 11;

                // Thêm border cho phần tổng kết
                Excel.Range summaryBorderRange = worksheet.Range[
                    worksheet.Cells[summaryRow, 8],
                    worksheet.Cells[summaryRow + 1, 10]
                ];
                summaryBorderRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                summaryBorderRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                summaryBorderRange.Borders.Color = Color.Black;

                // 7. TỰ ĐỘNG ĐIỀU CHỈNH CỘT
                tableRange.Columns.AutoFit();

                // 8. LƯU FILE
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close(true);
                app.Quit();

                MessageBox.Show($"Xuất Excel thành công!\nFile: {Path.GetFileName(saveFileDialog.FileName)}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 9. MỞ FILE VỪA XUẤT
                if (File.Exists(saveFileDialog.FileName))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                    }
                    catch
                    {
                        // Nếu không mở được, chỉ cần thông báo
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xuất Excel:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // GIẢI PHÓNG TÀI NGUYÊN ĐÚNG CÁCH
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (workbook != null)
                {
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (app != null)
                {
                    Marshal.FinalReleaseComObject(app);
                    app = null;
                }

                // Gọi GC để giải phóng bộ nhớ
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void FilterData()
        {
            if (listPN == null) return;

            // HIỂN THỊ TẤT CẢ phiếu có trạng thái khác 0
            listPN = pnBUS.getListPN();
            var filteredList = listPN.Where(px => px.Trangthai != 0).AsEnumerable();
            string searchText = txtSearchNV.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                if (cbbSearch.Text == "Tất cả")
                {
                    filteredList = filteredList.Where(pn =>
                        pn.Maphieu.ToString().Contains(searchText) ||
                        (nvBUS.getNamebyID(pn.Manv) ?? "").ToLower().Contains(searchText) ||
                        (nccBUS.getNamebyID(pn.Mancc) ?? "").ToLower().Contains(searchText));
                }
                if (cbbSearch.Text == "Nhân viên")
                {
                    filteredList = filteredList.Where(px =>
                        (nvBUS.getNamebyID(px.Manv) ?? "").ToLower().Contains(searchText));
                }
                if (cbbSearch.Text == "Nhà cung cấp")
                {
                    filteredList = filteredList.Where(pn =>
                        (nccBUS.getNamebyID(pn.Mancc) ?? "").ToLower().Contains(searchText));
                }
                if (cbbSearch.Text == "Mã")
                {
                    filteredList = filteredList.Where(pn => pn.Maphieu.ToString().Contains(searchText));
                }
            }

            //// Lọc theo khoảng thời gian
            if (dateS.Value != null && dateE.Value != null)
            {
                DateTime startDate = dateS.Value.Date;
                DateTime endDate = dateE.Value.Date.AddDays(1).AddSeconds(-1);
                filteredList = filteredList.Where(px =>
                    px.Thoigiantao >= startDate && px.Thoigiantao <= endDate);
            }

            // Lọc theo khoảng giá
            decimal? minPrice = null; // có thể số hoặc null
            decimal? maxPrice = null;

            if (!string.IsNullOrWhiteSpace(txtSMoney.Text) && txtSMoney.Text != "Tiền từ")
            {
                if (decimal.TryParse(txtSMoney.Text, out decimal min)) minPrice = min;
            }
            if (!string.IsNullOrWhiteSpace(txtEMoney.Text) && txtEMoney.Text != "Đến tiền")
            {
                if (decimal.TryParse(txtEMoney.Text, out decimal max)) maxPrice = max;
            }
            if (minPrice.HasValue || maxPrice.HasValue) // True nếu có giá trị
            {
                filteredList = filteredList.Where(px =>
                {
                    if (minPrice.HasValue && px.Tongtien < minPrice.Value) return false;
                    if (maxPrice.HasValue && px.Tongtien > maxPrice.Value) return false;
                    return true;
                });
            }

            refreshDataGridView(new BindingList<PhieuNhapDTO>(filteredList.ToList()));
        }

        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSMoney_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtEMoney_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dateTimeBegin_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void ShowDetailPhieuNhapForm(PhieuNhapDTO phieuNhap)
        {
            try
            {
                DetailPhieuNhapForm detailForm = new DetailPhieuNhapForm(phieuNhap);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form chi tiết: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshDataGridView(BindingList<PhieuNhapDTO> listRefresh) // Tải lại DataGridView
        {
            int soLuongNV = 0;
            DGVPhieuNhap.Rows.Clear();
            foreach (PhieuNhapDTO pn in listRefresh)
            {
                if (pn.Trangthai == 1)
                {
                    string tenNV = nvBUS.getNamebyID(pn.Manv);
                    string tenNCC = nccBUS.getNamebyID(pn.Mancc);
                    string trangThai = pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy";
                    DGVPhieuNhap.Rows.Add(
                        $"PN-{pn.Maphieu}",
                        tenNV,
                        tenNCC,
                        pn.Thoigiantao.ToString("HH:mm dd/MM/yyyy"),
                        $"{pn.Tongtien:N0}đ",
                        trangThai
                    );
                    soLuongNV++;
                }
            }
            lbTotal.Text = "Tổng số phiếu nhập: " + soLuongNV.ToString();

            DGVPhieuNhap.ClearSelection();
        }
        // Xử lý thay đổi cbb
        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchNV.Clear();
            txtSMoney.Text = "Tiền từ";
            txtEMoney.Text = "Đến tiền";
            DateTime ngayDauTien = new DateTime(DateTime.Now.Year, 1, 1);
            dateS.Value = ngayDauTien;
            dateE.Value = DateTime.Today;
        }

        // Xử lý placeholder và keypress
        private void txtSMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }

        private void txtSMoney_MouseLeave(object sender, EventArgs e)
        {
            if (txtSMoney.Text == "" || txtSMoney.Text == null)
            {
                txtSMoney.Text = "Tiền từ";
                if (txtEMoney.Text == "" || txtEMoney.Text == null)
                {
                    txtEMoney.Text = "Đến tiền";
                }
            }
        }

        private void txtEMoney_MouseLeave(object sender, EventArgs e)
        {
            if (txtEMoney.Text == "" || txtEMoney.Text == null)
            {
                txtEMoney.Text = "Đến tiền";
                if (txtSMoney.Text == "" || txtEMoney.Text == null)
                {
                    txtSMoney.Text = "Tiền từ";
                }
            }
        }

        private void txtEMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }

        private void txtEMoney_MouseEnter(object sender, EventArgs e)
        {
            if (txtEMoney.Text == "Đến tiền")
                txtEMoney.Clear();
        }

        private void txtSMoney_MouseEnter(object sender, EventArgs e)
        {
            if (txtSMoney.Text == "Tiền từ")
                txtSMoney.Clear();
        }
    }
}