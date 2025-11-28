using QuanLyKho.BUS;
using QuanLyKho.DTO;
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

        public PhieuNhapGUI()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
            
        }

        private void SetupDataGridView()
        {
            dataGridView1.ClearSelection();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


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
            InitializeDataGridViewColumns();
            dateTimeBegin.Value = DateTime.Now.AddMonths(-1); // 1 tháng trước
            dateTimeEnd.Value = DateTime.Now;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            LoadDataIntoGridView();
            refreshDataGridView(listPN);
        }

        private void InitializeDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("MaPhieu", "Mã phiếu");
            dataGridView1.Columns.Add("TenNV", "Tên nhân viên");
            dataGridView1.Columns.Add("TenNCC", "Nhà cung cấp");
            dataGridView1.Columns.Add("ThoiGian", "Thời gian tạo");
            dataGridView1.Columns.Add("TongTien", "Tổng tiền");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái");

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridView1.Columns["MaPhieu"].FillWeight = 10;      // 10%
            dataGridView1.Columns["TenNV"].FillWeight = 20;        // 20%
            dataGridView1.Columns["TenNCC"].FillWeight = 25;        // 10%
            dataGridView1.Columns["ThoiGian"].FillWeight = 15;     // 20%
            dataGridView1.Columns["TongTien"].FillWeight = 15;     // 20%
            dataGridView1.Columns["TrangThai"].FillWeight = 15;    // 20%

            dataGridView1.RowTemplate.Height = 40;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác";
            btn.Name = "Actions";
            btn.Text = "";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            btn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Actions"].Width = 100;
        }

        private void LoadDataIntoGridView()
        {
            dataGridView1.Rows.Clear();

            if (listPN != null && listPN.Count > 0)
            {
                foreach (PhieuNhapDTO pn in listPN)
                {
                    if (pn.Trangthai == 1)
                    {
                        string tenNV = nvBUS.getNamebyID(pn.Manv);
                        string tenNCC = nccBUS.getNamebyID(pn.Mancc);
                        string trangThai = pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy";
                        dataGridView1.Rows.Add(
                            pn.Maphieu,
                            tenNV,
                            tenNCC,
                            pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                            pn.Tongtien,
                            trangThai
                        );
                    }
                }
            }

            dataGridView1.ClearSelection();
            FilterData();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 5;
                int totalButtons = 2;
                int buttonWidth = (e.CellBounds.Width - padding * (totalButtons + 1)) / totalButtons;

                Rectangle btnXem = new Rectangle(e.CellBounds.Left + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXoa = new Rectangle(btnXem.Right + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);

                ButtonRenderer.DrawButton(e.Graphics, btnXem, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnXoa, "", this.Font, false, PushButtonState.Normal);

                try
                {
                    Image imgXoa = Image.FromFile("images\\icon\\remove.png");
                    Image imgXem = Image.FromFile("images\\icon\\detail.png");

                    int targetWidth = 24;
                    int targetHeight = 24;

                    e.Graphics.DrawImage(imgXem, new Rectangle(
                        btnXem.Left + (btnXem.Width - targetWidth) / 2,
                        btnXem.Top + (btnXem.Height - targetHeight) / 2,
                        targetWidth,
                        targetHeight));

                    e.Graphics.DrawImage(imgXoa, new Rectangle(
                        btnXoa.Left + (btnXoa.Width - targetWidth) / 2,
                        btnXoa.Top + (btnXoa.Height - targetHeight) / 2,
                        targetWidth,
                        targetHeight));

                    imgXem.Dispose();
                    imgXoa.Dispose();
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi ảnh
                }

                e.Handled = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X;

                int maPhieu = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString());
                PhieuNhapDTO phieuDuocChon = pnBUS.getPhieuNhapById(maPhieu);

                if (xRel < padding + buttonWidth) // nút Xem
                {
                    ShowDetailPhieuNhapForm(phieuDuocChon);
                }
                else // nút Xóa
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phiếu nhập {maPhieu}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (pnBUS.removePhieuNhap(maPhieu))
                        {
                            LoadData();
                            LoadDataIntoGridView();
                            MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa phiếu nhập thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Tìm frmMain từ ParentForm
            frmMain mainForm = this.ParentForm as frmMain;
            if (mainForm != null)
            {
                // Sử dụng reflection để gọi OpenChildForm
                var method = mainForm.GetType().GetMethod("OpenChildForm",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (method != null)
                {
                    method.Invoke(mainForm, new object[] { new AddPhieuNhapForm(), null });
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = "DanhSachPhieuNhap.xlsx";

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
                worksheet.Name = "Danh sách phiếu nhập";

                DateTime now = DateTime.Now;

                worksheet.Cells[1, 1] = $"DANH SÁCH PHIẾU NHẬP";
                Excel.Range titleRange = worksheet.Range["A1", "F1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[2, 1] = $"Ngày xuất: {now.ToString("dd/MM/yyyy HH:mm")}";
                worksheet.Cells[2, 1].Font.Italic = true;

                // tiêu đề cột, bỏ qua cột action
                int colIndex = 1;
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++) // -1 để bỏ qua cột button
                {
                    worksheet.Cells[4, colIndex] = dataGridView1.Columns[i].HeaderText;
                    colIndex++;
                }

                // dữ liệu
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < dataGridView1.Columns.Count - 1; j++) // -1 để bỏ qua cột button
                    {
                        object value = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 5, colIndex] = value != null ? value.ToString() : "";
                        colIndex++;
                    }
                }

                // Định dạng header
                int columnCount = dataGridView1.Columns.Count - 1;
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
                    worksheet.Cells[dataGridView1.Rows.Count + 4, columnCount]
                ];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                dataRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                // Căn giữa tất cả các cột trừ cột tên
                for (int col = 1; col <= columnCount; col++)
                {
                    Excel.Range columnRange = worksheet.Range[
                        worksheet.Cells[5, col],
                        worksheet.Cells[dataGridView1.Rows.Count + 4, col]
                    ];

                    if (col == 2 || col == 3) // Cột Tên NV và Tên NCC (căn trái)
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
                int lastRow = dataGridView1.Rows.Count + 5;

                // Tổng số phiếu - Merge từ cột A đến B
                Excel.Range totalPhieuRange = worksheet.Range[worksheet.Cells[lastRow + 1, 1], worksheet.Cells[lastRow + 1, 2]];
                totalPhieuRange.Merge();
                totalPhieuRange.Value = "TỔNG SỐ PHIẾU:";
                totalPhieuRange.Font.Bold = true;
                totalPhieuRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                worksheet.Cells[lastRow + 1, 3] = dataGridView1.Rows.Count;
                worksheet.Cells[lastRow + 1, 3].Font.Bold = true;
                worksheet.Cells[lastRow + 1, 3].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                // Tính tổng tiền
                decimal tongTien = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["TongTien"].Value != null)
                    {
                        tongTien += Convert.ToDecimal(dataGridView1.Rows[i].Cells["TongTien"].Value);
                    }
                }

                // Tổng chi phí - Merge từ cột A đến B
                Excel.Range totalChiPhiLabelRange = worksheet.Range[worksheet.Cells[lastRow + 2, 1], worksheet.Cells[lastRow + 2, 2]];
                totalChiPhiLabelRange.Merge();
                totalChiPhiLabelRange.Value = "TỔNG CHI PHÍ:";
                totalChiPhiLabelRange.Font.Bold = true;
                totalChiPhiLabelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                // Merge từ cột C đến D cho giá trị tổng chi phí
                Excel.Range totalChiPhiValueRange = worksheet.Range[worksheet.Cells[lastRow + 2, 3], worksheet.Cells[lastRow + 2, 4]];
                totalChiPhiValueRange.Merge();
                totalChiPhiValueRange.Value = tongTien.ToString("N0") + " VNĐ";
                totalChiPhiValueRange.Font.Bold = true;
                totalChiPhiValueRange.Font.Color = Color.Red;
                totalChiPhiValueRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

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

        private void FilterData()
        {
            if (listPN == null) return;

            var filteredList = listPN.Where(pn => pn.Trangthai == 1).AsEnumerable();

            // Lọc theo tên nhân viên
            if (!string.IsNullOrWhiteSpace(txtSearchNV.Text))
            {
                string searchText = txtSearchNV.Text.Trim().ToLower();
                filteredList = filteredList.Where(pn =>
                {
                    string tenNV = nvBUS.getNamebyID(pn.Manv)?.ToLower() ?? "";
                    return tenNV.Contains(searchText);
                });
            }

            // Lọc theo tên nhà cung cấp
            if (!string.IsNullOrWhiteSpace(txtSearchNCC.Text))
            {
                string searchText = txtSearchNCC.Text.Trim().ToLower();
                filteredList = filteredList.Where(pn =>
                {
                    string tenNCC = nccBUS.getNamebyID(pn.Mancc)?.ToLower() ?? "";
                    return tenNCC.Contains(searchText);
                });
            }

            // Lọc theo khoảng thời gian
            if (dateTimeBegin.Value != null && dateTimeEnd.Value != null)
            {
                DateTime startDate = dateTimeBegin.Value.Date;
                DateTime endDate = dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1); // Đến hết ngày
                filteredList = filteredList.Where(pn =>
                    pn.Thoigiantao >= startDate && pn.Thoigiantao <= endDate);
            }

            // Lọc theo khoảng giá
            if (numericUpDown1.Value > 0 || numericUpDown2.Value > 0)
            {
                decimal minPrice = numericUpDown1.Value;
                decimal maxPrice = numericUpDown2.Value > 0 ? numericUpDown2.Value : decimal.MaxValue;

                filteredList = filteredList.Where(pn =>
                    pn.Tongtien >= minPrice && pn.Tongtien <= maxPrice);
            }

            // Hiển thị kết quả lọc
            DisplayFilteredData(filteredList.ToList());
        }

        private void DisplayFilteredData(List<PhieuNhapDTO> filteredData)
        {
            dataGridView1.Rows.Clear();

            if (filteredData != null && filteredData.Count > 0)
            {
                foreach (PhieuNhapDTO pn in filteredData)
                {
                    string tenNV = nvBUS.getNamebyID(pn.Manv);
                    string tenNCC = nccBUS.getNamebyID(pn.Mancc);
                    string trangThai = pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy";
                    dataGridView1.Rows.Add(
                        pn.Maphieu,
                        tenNV,
                        tenNCC,
                        pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        pn.Tongtien,
                        trangThai
                    );
                }
            }

            dataGridView1.ClearSelection();
        }

        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSearchNCC_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
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
            foreach (PhieuNhapDTO pn in listRefresh)
            {
                if (pn.Trangthai == 1)
                {
                    string tenNV = nvBUS.getNamebyID(pn.Manv);
                    string tenNCC = nccBUS.getNamebyID(pn.Mancc);
                    string trangThai = pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy";
                    DGVPhieuNhap.Rows.Add(
                        pn.Maphieu,
                        tenNV,
                        tenNCC,
                        pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        pn.Tongtien,
                        trangThai
                    );
                }
            }

            DGVPhieuNhap.ClearSelection();
        }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void txtSearchNV_Enter(object sender, EventArgs e) { }
        private void txtSearchNV_Leave(object sender, EventArgs e) { }
        private void txtSearchNCC_Enter(object sender, EventArgs e) { }
        private void txtSearchNCC_Leave(object sender, EventArgs e) { }
    }
}