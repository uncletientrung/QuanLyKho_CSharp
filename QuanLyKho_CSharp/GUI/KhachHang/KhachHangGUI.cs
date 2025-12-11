using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;

using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.NhomQuyen;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class KhachHangGUI : Form
    {

        private KhachHangBUS khBUS = new KhachHangBUS();
        private BindingList<KhachHangDTO> listKH;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public KhachHangGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVKhachHang.ClearSelection();
            DGVKhachHang.RowHeadersVisible = false; // Tắt cột header
            DGVKhachHang.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhachHang.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhachHang.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhachHang.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhachHang.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVKhachHang.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVKhachHang.ColumnHeadersHeight = 30;
            DGVKhachHang.RowHeadersDefaultCellStyle = headerStyle;
            DGVKhachHang.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listKH = khBUS.getListKH();
            this.currentUser = currentUser;
            settingRole();
        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("khachhang");
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
            if (!checkSua) DGVKhachHang.Columns.Remove("edit");
            if (!checkXoa) DGVKhachHang.Columns.Remove("remove");
        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(khBUS.getListKH());

        }

        private void refreshDataGridView(BindingList<KhachHangDTO> listRefresh) // Tải lại DataGridView
        {
            DGVKhachHang.Rows.Clear();
            int soluong = 0;
            foreach (KhachHangDTO kh in listRefresh.Where(kh => kh.Trangthai == 1))
            {
                DGVKhachHang.Rows.Add($"KH-{kh.Makh}", kh.Tenkhachhang, kh.Email, kh.Sdt
                , kh.Ngaysinh.ToString("dd/MM/yyyy"), "Hoạt động");
                soluong++;
            }
            DGVKhachHang.ClearSelection();
            lbTotalNV.Text = "Tổng số khách hàng: " + soluong.ToString();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddKhachHangForm addKH = new AddKhachHangForm();
            addKH.ShowDialog();
            if (addKH.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(khBUS.getListKH());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddKhachHangForm addKH = new AddKhachHangForm();
            addKH.ShowDialog();
            if (addKH.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(khBUS.getListKH());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void DGVKhachHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maKH = int.Parse(DGVKhachHang.Rows[e.RowIndex].Cells["makh"].Value.ToString().Replace("KH-", ""));
            KhachHangDTO KhachHangDuocChon = khBUS.getKHById(maKH);
            if (DGVKhachHang.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateKhachHangForm updateKH = new UpdateKhachHangForm(KhachHangDuocChon);
                updateKH.ShowDialog();
                if (updateKH.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(khBUS.getListKH());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }else if(DGVKhachHang.Columns[e.ColumnIndex].Name == "remove"){
                DeleteKhachHangForm deleteKH = new DeleteKhachHangForm(KhachHangDuocChon);
                deleteKH.ShowDialog();
                if (deleteKH.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(khBUS.getListKH());
                }
            }else if(DGVKhachHang.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailKhachHangForm detailKH = new DetailKhachHangForm(KhachHangDuocChon);
                detailKH.ShowDialog();
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string textSearch = txSearch.Text;
            listKH = khBUS.SearchKhachHang(textSearch);
            refreshDataGridView(listKH);
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
                            string tenKH = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                            string email = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
                            string sdt = worksheet.Cells[row, 3].Value?.ToString()?.Trim();
                            object ngaySinhValue = worksheet.Cells[row, 4].Value;

                            if (string.IsNullOrEmpty(tenKH))
                            {
                                errors.AppendLine($"Dòng {row}: Tên khách hàng không được để trống");
                                errorCount++;
                                continue;
                            }

                            if (string.IsNullOrEmpty(email))
                            {
                                errors.AppendLine($"Dòng {row}: Email không được để trống");
                                errorCount++;
                                continue;
                            }

                            if (string.IsNullOrEmpty(sdt))
                            {
                                errors.AppendLine($"Dòng {row}: Số điện thoại không được để trống");
                                errorCount++;
                                continue;
                            }

                            DateTime ngaySinh;
                            if (ngaySinhValue == null)
                            {
                                errors.AppendLine($"Dòng {row}: Ngày sinh không được để trống");
                                errorCount++;
                                continue;
                            }
                            else if (ngaySinhValue is DateTime)
                            {
                                ngaySinh = (DateTime)ngaySinhValue;
                            }
                            else if (ngaySinhValue is double)
                            {
                                ngaySinh = DateTime.FromOADate((double)ngaySinhValue);
                            }
                            else
                            {
                                string ngaySinhStr = ngaySinhValue.ToString().Trim();
                                if (!DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy",
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None, out ngaySinh))
                                {
                                    if (!DateTime.TryParse(ngaySinhStr, out ngaySinh))
                                    {
                                        errors.AppendLine($"Dòng {row}: Định dạng ngày sinh không hợp lệ (dd/MM/yyyy)");
                                        errorCount++;
                                        continue;
                                    }
                                }
                            }

                            KhachHangDTO newKH = new KhachHangDTO
                            {
                                Tenkhachhang = tenKH,
                                Email = email,
                                Sdt = sdt,
                                Ngaysinh = ngaySinh,
                                Trangthai = 1
                            };

                            if (khBUS.insertKhachHang(newKH))
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

                    string message = $"Nhập thành công: {successCount} khách hàng\n";
                    if (errorCount > 0)
                    {
                        message += $"Lỗi: {errorCount} dòng\n\nChi tiết lỗi:\n{errors}";
                    }

                    MessageBox.Show(message, "Kết quả nhập Excel",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    if (successCount > 0)
                    {
                        listKH = khBUS.getListKH();
                        refreshDataGridView(listKH);
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
                saveFileDialog.FileName = $"DanhSachKhachHang_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    worksheet.Name = "Danh sách khách hàng";

                    worksheet.Cells[1, 1] = "Mã KH";
                    worksheet.Cells[1, 2] = "Tên khách hàng";
                    worksheet.Cells[1, 3] = "Email";
                    worksheet.Cells[1, 4] = "Số điện thoại";
                    worksheet.Cells[1, 5] = "Ngày sinh";
                    worksheet.Cells[1, 6] = "Trạng thái";

                    Excel.Range headerRange = worksheet.Range["A1", "F1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(17, 155, 248));
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    int row = 2;
                    foreach (KhachHangDTO kh in listKH.Where(kh => kh.Trangthai == 1))
                    {
                        worksheet.Cells[row, 1] = $"KH-{kh.Makh}";
                        worksheet.Cells[row, 2] = kh.Tenkhachhang;
                        worksheet.Cells[row, 3] = kh.Email;
                        worksheet.Cells[row, 4] = kh.Sdt;
                        worksheet.Cells[row, 5] = kh.Ngaysinh.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 6] = "Hoạt động";
                        row++;
                    }

                    if (row > 2)
                    {
                        Excel.Range dataRange = worksheet.Range["A1", $"F{row - 1}"];
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
