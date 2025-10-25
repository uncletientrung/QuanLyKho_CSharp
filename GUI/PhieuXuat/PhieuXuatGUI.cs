﻿using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.HoanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
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
            dataGridView1.ClearSelection();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadData()
        {
            listPX = pxBUS.getListPX();
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewColumns();
            dateTimeBegin.Value = DateTime.Now.AddMonths(-1);
            dateTimeEnd.Value = DateTime.Now;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            LoadDataIntoGridView();
        }

        private void InitializeDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("MaPhieu", "Mã phiếu");
            dataGridView1.Columns.Add("TenNV", "Tên nhân viên");
            dataGridView1.Columns.Add("TenKH", "Tên KH");
            dataGridView1.Columns.Add("ThoiGian", "Thời gian tạo");
            dataGridView1.Columns.Add("TongTien", "Tổng tiền");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái");

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridView1.Columns["MaPhieu"].FillWeight = 10;
            dataGridView1.Columns["TenNV"].FillWeight = 15;
            dataGridView1.Columns["TenKH"].FillWeight = 15;
            dataGridView1.Columns["ThoiGian"].FillWeight = 20;
            dataGridView1.Columns["TongTien"].FillWeight = 15;
            dataGridView1.Columns["TrangThai"].FillWeight = 15;

            dataGridView1.RowTemplate.Height = 40; // set height

            // THÊM CỘT HOÀN HÀNG
            DataGridViewButtonColumn btnHoanHang = new DataGridViewButtonColumn();
            btnHoanHang.HeaderText = "Hoàn hàng";
            btnHoanHang.Name = "HoanHang";
            btnHoanHang.Text = "OK";
            btnHoanHang.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnHoanHang);
            btnHoanHang.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["HoanHang"].Width = 100;

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

            if (listPX != null && listPX.Count > 0)
            {
                foreach (PhieuXuatDTO px in listPX)
                {
                    if (px.Trangthai != 0)
                    {
                        string tenNV = nvBUS.getNamebyID(px.Manv);
                        string tenKH = khBUS.getNamebyID(px.Makh);
                        string trangThai = GetTrangThaiDisplay(px);

                        int rowIndex = dataGridView1.Rows.Add(
                            px.Maphieu,
                            tenNV,
                            tenKH,
                            px.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                            px.Tongtien,
                            trangThai
                        );
                        SetRowColor(rowIndex, px);
                    }
                }
            }

            dataGridView1.ClearSelection();
            FilterData();
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
            if (dataGridView1.Rows.Count > rowIndex)
            {
                switch (px.Trangthai)
                {
                    case 2:
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case 3:
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case 1: 
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                    default:
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }

                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }























        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Vẽ cho cột Hoàn hàng
            if (e.ColumnIndex == dataGridView1.Columns["HoanHang"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                ButtonRenderer.DrawButton(e.Graphics, e.CellBounds, "Hoàn hàng", this.Font,
                    false, PushButtonState.Normal);

                e.Handled = true;
            }

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
                PhieuXuatDTO phieuDuocChon = pxBUS.getPhieuXuatById(maPhieu);

                if (xRel < padding + buttonWidth) // nút Xem
                {
                    ShowDetailPhieuXuatForm(phieuDuocChon);
                }
                else // nút Xóa
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phiếu xuất {maPhieu}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (pxBUS.removePhieuXuat(maPhieu))
                        {
                            LoadData();
                            LoadDataIntoGridView();
                            MessageBox.Show("Xóa phiếu xuất thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa phiếu xuất thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
            if (dataGridView1.Rows.Count == 0)
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
                for (int i = 0; i < dataGridView1.Columns.Count - 2; i++) // -2 để bỏ qua 2 cột button
                {
                    worksheet.Cells[4, colIndex] = dataGridView1.Columns[i].HeaderText;
                    colIndex++;
                }

                // dữ liệu
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < dataGridView1.Columns.Count - 2; j++) // -2 để bỏ qua 2 cột button
                    {
                        object value = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 5, colIndex] = value != null ? value.ToString() : "";
                        colIndex++;
                    }
                }

                // Định dạng header
                int columnCount = dataGridView1.Columns.Count - 2;
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

        private void FilterData()
        {
            if (listPX == null) return;

            // HIỂN THỊ TẤT CẢ phiếu có trạng thái khác 0
            var filteredList = listPX.Where(px => px.Trangthai != 0).AsEnumerable();

            // Lọc theo tên nhân viên
            if (!string.IsNullOrWhiteSpace(txtSearchNV.Text))
            {
                string searchText = txtSearchNV.Text.Trim().ToLower();
                filteredList = filteredList.Where(px =>
                {
                    string tenNV = nvBUS.getNamebyID(px.Manv)?.ToLower() ?? "";
                    return tenNV.Contains(searchText);
                });
            }

            // Lọc theo tên khách hàng
            if (!string.IsNullOrWhiteSpace(txtSearchKH.Text))
            {
                string searchText = txtSearchKH.Text.Trim().ToLower();
                filteredList = filteredList.Where(px =>
                {
                    string tenKH = khBUS.getNamebyID(px.Makh)?.ToLower() ?? "";
                    return tenKH.Contains(searchText);
                });
            }

            // Lọc theo khoảng thời gian
            if (dateTimeBegin.Value != null && dateTimeEnd.Value != null)
            {
                DateTime startDate = dateTimeBegin.Value.Date;
                DateTime endDate = dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1);
                filteredList = filteredList.Where(px =>
                    px.Thoigiantao >= startDate && px.Thoigiantao <= endDate);
            }

            // Lọc theo khoảng giá
            if (numericUpDown1.Value > 0 || numericUpDown2.Value > 0)
            {
                decimal minPrice = numericUpDown1.Value;
                decimal maxPrice = numericUpDown2.Value > 0 ? numericUpDown2.Value : decimal.MaxValue;

                filteredList = filteredList.Where(px =>
                    px.Tongtien >= minPrice && px.Tongtien <= maxPrice);
            }

            DisplayFilteredData(filteredList.ToList());
        }

        private void DisplayFilteredData(List<PhieuXuatDTO> filteredData)
        {
            dataGridView1.Rows.Clear();

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

                    int rowIndex = dataGridView1.Rows.Add(
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
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = backColor;
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = foreColor;
                    }
                }
            }

            dataGridView1.ClearSelection();
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
        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSearchKH_TextChanged(object sender, EventArgs e)
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


        // hiển thị dialog hoàn hàng
        private void dialogHoanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["HoanHang"].Index)
            {
                int maPhieu = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MaPhieu"].Value);

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
                        LoadDataIntoGridView();

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
                    LoadDataIntoGridView();
                }
            }
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

    }
}