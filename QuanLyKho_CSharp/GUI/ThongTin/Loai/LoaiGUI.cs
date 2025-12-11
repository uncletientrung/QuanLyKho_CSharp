using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using QuanLyKho_CSharp.Helper;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class LoaiGUI : Form
    {

        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<LoaiDTO> listLoai;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public LoaiGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();

            DGVLoai.ClearSelection();
            DGVLoai.RowHeadersVisible = false; // Tắt cột header
            DGVLoai.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVLoai.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVLoai.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVLoai.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVLoai.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVLoai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVLoai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVLoai.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVLoai.ColumnHeadersHeight = 30;
            DGVLoai.RowHeadersDefaultCellStyle = headerStyle;
            DGVLoai.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listLoai = loaiBUS.getLoaiList();
            this.currentUser = currentUser;
            settingRole();
        }

        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("thongtin");
            var listCT = nqBUS.getListCTNQByIdNQ(maNQ)
                .Where(ctnq => ctnq.Machucnang == maDMNC).ToList();
            listCTQ = new BindingList<ChiTietQuyenDTO>(listCT);
            // Thực hiện ẩn nút
            bool checkThem = false;
            bool checkSua = false;
            bool checkXoa = false;
            foreach (ChiTietQuyenDTO ctq in listCTQ)
            {
                if (ctq.Hanhdong == "Thêm") checkThem = true;
                if (ctq.Hanhdong == "Sửa") checkSua = true;
                if (ctq.Hanhdong == "Xóa") checkXoa = true;
            }
            if (!checkThem)
            {
                btnThem.Visible = false;
                btnNhapExcel.Visible = false;
            }
            if (!checkSua) DGVLoai.Columns.Remove("edit");
            if (!checkXoa) DGVLoai.Columns.Remove("remove");
        }

        private void DGVLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Chỉ xử lý khi click vào cột Actions
            if (DGVLoai.Columns[e.ColumnIndex].Name != "Actions")
                return;

            // Lấy thông tin Loại được chọn (sử dụng đúng tên cột: MaLoai)
            int maLoai = Convert.ToInt32(DGVLoai.Rows[e.RowIndex].Cells["MaLoai"].Value);
            LoaiDTO loaiDuocChon = loaiBUS.getLoaiById(maLoai);
            if (loaiDuocChon == null)
            {
                MessageBox.Show("Không tìm thấy loại này!");
                return;
            }

            // Tính toán vị trí click trong ô để xác định nút
            Rectangle cellBounds = DGVLoai.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int padding = 5;
            int totalButtons = 3;
            int buttonWidth = (cellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
            // e.X đã là toạ độ tương đối trong cell, không trừ cellBounds.Left
            int clickX = e.X;

            int startSua = padding;
            int startXoa = startSua + buttonWidth + padding;
            int startXem = startXoa + buttonWidth + padding;

            if (clickX >= startSua && clickX < startSua + buttonWidth)
            {
                // Sửa
                UpdateLoaiForm updateLoai = new UpdateLoaiForm(loaiDuocChon);
                updateLoai.ShowDialog();
                if (updateLoai.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(loaiBUS.getLoaiList());
                    new AddSuccessNotification().Show();
                }
            }
            else if (clickX >= startXoa && clickX < startXoa + buttonWidth)
            {
                // Xóa
                DeleteLoaiForm deleteLoai = new DeleteLoaiForm(loaiDuocChon);
                deleteLoai.ShowDialog();
                if (deleteLoai.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(loaiBUS.getLoaiList());
                }
            }
            else if (clickX >= startXem && clickX < startXem + buttonWidth)
            {
                // Xem chi tiết
                DetailLoaiForm detailLoai = new DetailLoaiForm(loaiDuocChon);
                detailLoai.ShowDialog();
            }
        }

        
        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddLoaiForm addLoai = new AddLoaiForm();
            addLoai.ShowDialog();

            if (addLoai.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(loaiBUS.getLoaiList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void LoaiGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listLoai);
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txSearch.Text.Trim().ToLower();
            BindingList<LoaiDTO> listSearch = loaiBUS.SearchLoai(keyword);
            refreshDataGridView(listSearch);

        }

        private void refreshDataGridView(BindingList<LoaiDTO> list)
        {
            DGVLoai.Rows.Clear();
            int soluong = 0;
            foreach (LoaiDTO loai in list)
            {
                DGVLoai.Rows.Add($"L-{loai.Maloai}", loai.Tenloai);
                soluong++;
            }
            DGVLoai.ClearSelection();
            lbTotalNV.Text = "Tổng số loại: " + soluong.ToString();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVLoai_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maLoai = int.Parse(DGVLoai.Rows[e.RowIndex].Cells["mal"].Value.ToString().Replace("L-", ""));
            LoaiDTO loaiDuocChon = loaiBUS.getLoaiById(maLoai);
            if (DGVLoai.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailLoaiForm detailLoai = new DetailLoaiForm(loaiDuocChon);
                detailLoai.ShowDialog();
            } else if(DGVLoai.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateLoaiForm updateLoai = new UpdateLoaiForm(loaiDuocChon);
                updateLoai.ShowDialog();
                if (updateLoai.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(loaiBUS.getLoaiList());
                    new AddSuccessNotification().Show();
                }
            } else if(DGVLoai.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteLoaiForm deleteLoai = new DeleteLoaiForm(loaiDuocChon);
                deleteLoai.ShowDialog();
                if (deleteLoai.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(loaiBUS.getLoaiList());
                }
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn file Excel để nhập";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    Excel.Range usedRange = worksheet.UsedRange;
                    int rowCount = usedRange.Rows.Count;

                    int successCount = 0;
                    int errorCount = 0;
                    StringBuilder errors = new StringBuilder();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            string tenLoai = worksheet.Cells[row, 1].Value?.ToString()?.Trim();

                            if (string.IsNullOrEmpty(tenLoai))
                            {
                                errors.AppendLine($"Dòng {row}: Tên loại không được để trống");
                                errorCount++;
                                continue;
                            }

                            LoaiDTO newLoai = new LoaiDTO
                            {
                                Tenloai = tenLoai
                            };

                            if (loaiBUS.insertLoai(newLoai))
                            {
                                successCount++;
                            }
                            else
                            {
                                errors.AppendLine($"Dòng {row}: Lỗi khi thêm vào database");
                                errorCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            errors.AppendLine($"Dòng {row}: {ex.Message}");
                            errorCount++;
                        }
                    }

                    string message = $"Nhập thành công: {successCount} loại\n";
                    if (errorCount > 0)
                    {
                        message += $"Lỗi: {errorCount} dòng\n\nChi tiết lỗi:\n{errors}";
                    }

                    MessageBox.Show(message, "Kết quả nhập Excel",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    if (successCount > 0)
                    {
                        listLoai = loaiBUS.getLoaiList();
                        refreshDataGridView(listLoai);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nhập file Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = $"DanhSachLoai_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    worksheet.Name = "Danh sách loại";

                    worksheet.Cells[1, 1] = "Mã loại";
                    worksheet.Cells[1, 2] = "Tên loại";

                    Excel.Range headerRange = worksheet.Range["A1", "B1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(17, 155, 248));
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    int row = 2;
                    foreach (LoaiDTO loai in listLoai)
                    {
                        worksheet.Cells[row, 1] = $"L-{loai.Maloai}";
                        worksheet.Cells[row, 2] = loai.Tenloai;
                        row++;
                    }

                    if (row > 2)
                    {
                        Excel.Range dataRange = worksheet.Range["A1", $"B{row - 1}"];
                        dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        dataRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }

                    worksheet.Columns.AutoFit();

                    workbook.SaveAs(saveFileDialog.FileName);

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
