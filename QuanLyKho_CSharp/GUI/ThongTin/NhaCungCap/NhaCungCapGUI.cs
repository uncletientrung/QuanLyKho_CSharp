using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class NhaCungCapGUI : Form
    {
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private BindingList<NhaCungCapDTO> listNCC;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public NhaCungCapGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVNhaCungCap.ClearSelection();
            DGVNhaCungCap.RowHeadersVisible = false; // Tắt cột header
            DGVNhaCungCap.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVNhaCungCap.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVNhaCungCap.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVNhaCungCap.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVNhaCungCap.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVNhaCungCap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVNhaCungCap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVNhaCungCap.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVNhaCungCap.ColumnHeadersHeight = 30;
            DGVNhaCungCap.RowHeadersDefaultCellStyle = headerStyle;
            DGVNhaCungCap.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listNCC = nccBUS.getListNCC();
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
            if (!checkSua) DGVNhaCungCap.Columns.Remove("edit");
            if (!checkXoa) DGVNhaCungCap.Columns.Remove("remove");
        }
        private void NhaCungCapGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listNCC);
        }

       
        private void refreshDataGridView(BindingList<NhaCungCapDTO> list)
        {
            DGVNhaCungCap.Rows.Clear();
            int soluong = 0;
            foreach (NhaCungCapDTO ncc in list)
            {
                string trangThai = ncc.Trangthai == 1 ? "Hoạt động" : "Ngừng hoạt động";
                DGVNhaCungCap.Rows.Add($"NCC-{ncc.Mancc}", ncc.Tenncc, ncc.Diachincc, ncc.Sdt, ncc.Email, trangThai);
                soluong++;
            }
            DGVNhaCungCap.ClearSelection();
            lbTotalNV.Text = "Tổng số nhà cung cấp: " + soluong.ToString();
        }

        private void DGVNhaCungCap_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        private void DGVNhaCungCap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //e.ColumnIndex, e.RowIndex → xác định cell được click
            //e.Location → vị trí con trỏ chuột trong cell(tọa độ X, Y)
            //e.Button → nút chuột được nhấn
            if (e.ColumnIndex == DGVNhaCungCap.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRelative = e.Location.X; // Tọa độ X của con trỏ chuột trong cell
                // Cells["mancc"] là ô dựa trên dataSource,
                // Column["mancc"] là cột dữ liệu của DGV
                int maNCC = int.Parse(DGVNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString());
                NhaCungCapDTO NhaCungCapDuocChon = nccBUS.getNCCById(maNCC);
                if (xRelative < padding + buttonWidth)
                {
                    UpdateNhaCungCapForm updateNCC = new UpdateNhaCungCapForm(NhaCungCapDuocChon);
                    updateNCC.ShowDialog();
                    if (updateNCC.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                        AddSuccessNotification tb = new AddSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative < padding * 2 + buttonWidth * 2)
                {
                    DeleteNhaCungCapForm deleteNCC = new DeleteNhaCungCapForm(NhaCungCapDuocChon);
                    deleteNCC.ShowDialog();
                    if (deleteNCC.DialogResult == DialogResult.OK)
                    {
                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                        refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                    }
                }
                else
                {
                    DetailNhaCungCapForm detailNCC = new DetailNhaCungCapForm(NhaCungCapDuocChon);
                    detailNCC.ShowDialog();
                }
            }
            {

            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddNhaCungCapForm addNCC = new AddNhaCungCapForm();
            addNCC.ShowDialog();

            if (addNCC.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txSearch.Text;
            listNCC = nccBUS.searchNhaCungCap(text);
            refreshDataGridView(listNCC);
        }

        private void DGVNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maNCC = int.Parse(DGVNhaCungCap.Rows[e.RowIndex].Cells["mancc"].Value.ToString().Replace("NCC-", ""));
            NhaCungCapDTO NhaCungCapDuocChon = nccBUS.getNCCById(maNCC);
            if (DGVNhaCungCap.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailNhaCungCapForm detailNCC = new DetailNhaCungCapForm(NhaCungCapDuocChon);
                detailNCC.ShowDialog();
            }
            else if (DGVNhaCungCap.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateNhaCungCapForm updateNCC = new UpdateNhaCungCapForm(NhaCungCapDuocChon);
                updateNCC.ShowDialog();
                if (updateNCC.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                    AddSuccessNotification tb = new AddSuccessNotification();
                    tb.Show();
                }
            }else if (DGVNhaCungCap.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteNhaCungCapForm deleteNCC = new DeleteNhaCungCapForm(NhaCungCapDuocChon);
                deleteNCC.ShowDialog();
                if (deleteNCC.DialogResult == DialogResult.OK)
                {
                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
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
                            string tenNCC = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                            string diaChi = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
                            string sdt = worksheet.Cells[row, 3].Value?.ToString()?.Trim();
                            string email = worksheet.Cells[row, 4].Value?.ToString()?.Trim();

                            if (string.IsNullOrEmpty(tenNCC))
                            {
                                errors.AppendLine($"Dòng {row}: Tên nhà cung cấp không được để trống");
                                errorCount++;
                                continue;
                            }

                            if (string.IsNullOrEmpty(diaChi))
                            {
                                errors.AppendLine($"Dòng {row}: Địa chỉ không được để trống");
                                errorCount++;
                                continue;
                            }

                            if (string.IsNullOrEmpty(sdt))
                            {
                                errors.AppendLine($"Dòng {row}: Số điện thoại không được để trống");
                                errorCount++;
                                continue;
                            }

                            if (string.IsNullOrEmpty(email))
                            {
                                errors.AppendLine($"Dòng {row}: Email không được để trống");
                                errorCount++;
                                continue;
                            }

                            NhaCungCapDTO newNCC = new NhaCungCapDTO
                            {
                                Tenncc = tenNCC,
                                Diachincc = diaChi,
                                Sdt = sdt,
                                Email = email,
                                Trangthai = 1
                            };

                            if (nccBUS.insertNhaCungCap(newNCC))
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

                    string message = $"Nhập thành công: {successCount} nhà cung cấp\n";
                    if (errorCount > 0)
                    {
                        message += $"Lỗi: {errorCount} dòng\n\nChi tiết lỗi:\n{errors}";
                    }

                    MessageBox.Show(message, "Kết quả nhập Excel",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    if (successCount > 0)
                    {
                        listNCC = nccBUS.getListNCC();
                        refreshDataGridView(listNCC);
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
                saveFileDialog.FileName = $"DanhSachNhaCungCap_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    worksheet.Name = "Danh sách nhà cung cấp";

                    worksheet.Cells[1, 1] = "Mã NCC";
                    worksheet.Cells[1, 2] = "Tên nhà cung cấp";
                    worksheet.Cells[1, 3] = "Địa chỉ";
                    worksheet.Cells[1, 4] = "Số điện thoại";
                    worksheet.Cells[1, 5] = "Email";
                    worksheet.Cells[1, 6] = "Trạng thái";

                    Excel.Range headerRange = worksheet.Range["A1", "F1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(17, 155, 248));
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    int row = 2;
                    foreach (NhaCungCapDTO ncc in listNCC)
                    {
                        string trangThai = ncc.Trangthai == 1 ? "Hoạt động" : "Ngừng hoạt động";
                        worksheet.Cells[row, 1] = $"NCC-{ncc.Mancc}";
                        worksheet.Cells[row, 2] = ncc.Tenncc;
                        worksheet.Cells[row, 3] = ncc.Diachincc;
                        worksheet.Cells[row, 4] = ncc.Sdt;
                        worksheet.Cells[row, 5] = ncc.Email;
                        worksheet.Cells[row, 6] = trangThai;
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
