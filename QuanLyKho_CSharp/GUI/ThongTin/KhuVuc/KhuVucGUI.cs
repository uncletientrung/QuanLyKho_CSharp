using QuanLyKho.BUS;
using QuanLyKho.DTO;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    public partial class KhuVucGUI : Form
    {
        private KhuVucKhoBUS kvkBUS = new KhuVucKhoBUS();
        private BindingList<KhuVucKhoDTO> listKhuVuc;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;

        public KhuVucGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVKhuVuc.ClearSelection();
            DGVKhuVuc.RowHeadersVisible = false; // Tắt cột header
            DGVKhuVuc.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhuVuc.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhuVuc.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhuVuc.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhuVuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhuVuc.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhuVuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhuVuc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVKhuVuc.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVKhuVuc.ColumnHeadersHeight = 30;
            DGVKhuVuc.RowHeadersDefaultCellStyle = headerStyle;
            DGVKhuVuc.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listKhuVuc = kvkBUS.getKhuVucKhoList();
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
            if (!checkSua) DGVKhuVuc.Columns.Remove("edit");
            if (!checkXoa) DGVKhuVuc.Columns.Remove("remove");
        }

        private void DGVKhuVuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVKhuVuc.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                // Tính toán vị trí các nút
                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (DGVKhuVuc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Width - padding * (totalButtons + 1)) / totalButtons;
                int xRelative = e.Location.X;

                // Vị trí các nút
                int startSua = padding;
                int startXoa = startSua + buttonWidth + padding;
                int startXem = startXoa + buttonWidth + padding;

                // Lấy thông tin khu vực kho được chọn
                int maKVK = int.Parse(DGVKhuVuc.Rows[e.RowIndex].Cells["MaKVK"].Value.ToString());
                KhuVucKhoDTO KhuVucKhoDuocChon = kvkBUS.getKVKById(maKVK);

                if (KhuVucKhoDuocChon == null)
                {
                    MessageBox.Show("Không tìm thấy khu vực kho này!");
                    return;
                }

                if (xRelative >= startSua && xRelative < startSua + buttonWidth)
                {
                    // Nút Sửa
                    UpdateKhuVucForm updateKVK = new UpdateKhuVucForm(KhuVucKhoDuocChon);
                    updateKVK.ShowDialog();
                    if (updateKVK.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(kvkBUS.getKhuVucKhoList()); 
                        AddSuccessNotification tb = new AddSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative >= startXoa && xRelative < startXoa + buttonWidth)
                {
                    // Nút Xóa
                    DeleteKhuVucForm deleteKVK = new DeleteKhuVucForm(KhuVucKhoDuocChon);
                    deleteKVK.ShowDialog();
                    if (deleteKVK.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(kvkBUS.getKhuVucKhoList());
                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative >= startXem && xRelative < startXem + buttonWidth)
                {
                    // Nút Xem chi tiết
                    DetailKhuVucForm detailKVK = new DetailKhuVucForm(KhuVucKhoDuocChon);
                    detailKVK.ShowDialog();
                }
            }
        }

        

        private void KhuVucGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listKhuVuc);
        }

        private void KhuVucGUI_Shown(object sender, EventArgs e)
        {

        }

        private void refreshDataGridView(BindingList<KhuVucKhoDTO> list)
        {
            DGVKhuVuc.Rows.Clear();
            int soluong = 0;
            foreach (KhuVucKhoDTO kvk in list)
            {
                DGVKhuVuc.Rows.Add($"KV-{kvk.Makhuvuc}", kvk.Tenkhuvuc, kvk.Diachi, kvk.Sdt, kvk.Email);
                soluong++;
            }
            DGVKhuVuc.ClearSelection();
            lbTotalNV.Text = "Tổng số khu vực: " + soluong.ToString();
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txSearch.Text.Trim().ToLower();
            BindingList<KhuVucKhoDTO> listSearch = kvkBUS.SearchKho(keyword);
            refreshDataGridView(listSearch);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddKhuVucForm addKhuVuc = new AddKhuVucForm();
            addKhuVuc.ShowDialog();

            if (addKhuVuc.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(kvkBUS.getKhuVucKhoList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void DGVKhuVuc_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int makv = int.Parse(DGVKhuVuc.Rows[e.RowIndex].Cells["makv"].Value.ToString().Replace("KV-", ""));
            KhuVucKhoDTO KhuVucKhoDuocChon = kvkBUS.getKVKById(makv);
            if (DGVKhuVuc.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailKhuVucForm detailKVK = new DetailKhuVucForm(KhuVucKhoDuocChon);
                detailKVK.ShowDialog();
            }else if(DGVKhuVuc.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateKhuVucForm updateKVK = new UpdateKhuVucForm(KhuVucKhoDuocChon);
                updateKVK.ShowDialog();
                if (updateKVK.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(kvkBUS.getKhuVucKhoList());
                    AddSuccessNotification tb = new AddSuccessNotification();
                    tb.Show();
                }
            }else if(DGVKhuVuc.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteKhuVucForm deleteKVK = new DeleteKhuVucForm(KhuVucKhoDuocChon);
                deleteKVK.ShowDialog();
                if (deleteKVK.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(kvkBUS.getKhuVucKhoList());
                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
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
                            string tenKV = worksheet.Cells[row, 2].Value?.ToString()?.Trim();
                            string diaChi = worksheet.Cells[row, 3].Value?.ToString()?.Trim();
                            string sdt = worksheet.Cells[row, 4].Value?.ToString()?.Trim();
                            string email = worksheet.Cells[row, 5].Value?.ToString()?.Trim();

                            if (string.IsNullOrEmpty(tenKV))
                            {
                                errors.AppendLine($"Dòng {row}: Tên khu vực không được để trống");
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

                            KhuVucKhoDTO newKVK = new KhuVucKhoDTO
                            {
                                Tenkhuvuc = tenKV,
                                Diachi = diaChi,
                                Sdt = sdt,
                                Email = email
                            };

                            if (kvkBUS.insertKhuVuc(newKVK))
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

                    string message = $"Nhập thành công: {successCount} khu vực\n";
                    if (errorCount > 0)
                    {
                        message += $"Lỗi: {errorCount} dòng\n\nChi tiết lỗi:\n{errors}";
                    }

                    MessageBox.Show(message, "Kết quả nhập Excel",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    if (successCount > 0)
                    {
                        listKhuVuc = kvkBUS.getKhuVucKhoList();
                        refreshDataGridView(listKhuVuc);
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
                saveFileDialog.FileName = $"DanhSachKhuVuc_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    worksheet.Name = "Danh sách khu vực";

                    worksheet.Cells[1, 1] = "Mã khu vực";
                    worksheet.Cells[1, 2] = "Tên khu vực";
                    worksheet.Cells[1, 3] = "Địa chỉ";
                    worksheet.Cells[1, 4] = "Số điện thoại";
                    worksheet.Cells[1, 5] = "Email";

                    Excel.Range headerRange = worksheet.Range["A1", "E1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(17, 155, 248));
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    int row = 2;
                    foreach (KhuVucKhoDTO kvk in listKhuVuc)
                    {
                        worksheet.Cells[row, 1] = $"KV-{kvk.Makhuvuc}";
                        worksheet.Cells[row, 2] = kvk.Tenkhuvuc;
                        worksheet.Cells[row, 3] = kvk.Diachi;
                        worksheet.Cells[row, 4] = kvk.Sdt;
                        worksheet.Cells[row, 5] = kvk.Email;
                        row++;
                    }

                    if (row > 2)
                    {
                        Excel.Range dataRange = worksheet.Range["A1", $"E{row - 1}"];
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
