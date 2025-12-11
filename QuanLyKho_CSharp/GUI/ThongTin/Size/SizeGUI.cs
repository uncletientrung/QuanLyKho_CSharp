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
using QuanLyKho_CSharp.GUI.ThongTin.Size;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    public partial class SizeGUI : Form
    {
        private SizeBUS sizeBUS = new SizeBUS();
        private BindingList<SizeDTO> listSize;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;



        public SizeGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            // Thiết lập DataGridView
            DGVSize.ClearSelection();
            DGVSize.RowHeadersVisible = false; // Tắt cột header
            DGVSize.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVSize.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVSize.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVSize.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVSize.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVSize.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVSize.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVSize.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVSize.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVSize.ColumnHeadersHeight = 30;
            DGVSize.RowHeadersDefaultCellStyle = headerStyle;
            DGVSize.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            listSize = sizeBUS.getSizeList();
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
            if (!checkSua) DGVSize.Columns.Remove("edit");
            if (!checkXoa) DGVSize.Columns.Remove("remove");
        }
        private void roundedButton2_Click_1(object sender, EventArgs e)
        {
            AddSizeForm addSize = new AddSizeForm();
            addSize.ShowDialog();

            if (addSize.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(sizeBUS.getSizeList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void refreshDataGridView(BindingList<SizeDTO> list)
        {
            DGVSize.Rows.Clear();
            int soluong = 0;
            foreach (SizeDTO size in list)
            {
                DGVSize.Rows.Add($"S-{size.Masize}", size.Tensize, size.Ghichu);
                soluong++;
            }
            DGVSize.ClearSelection();
            lbTotalNV.Text = "Tổng số size: " + soluong.ToString();
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txSearch.Text;
            listSize = sizeBUS.SearchSize(text);
            refreshDataGridView(listSize);
        }
        

        private void SizeGUI_Load(object sender, EventArgs e)
        {
           
            refreshDataGridView(listSize);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVSize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVSize_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maSize = int.Parse(DGVSize.Rows[e.RowIndex].Cells["masize"].Value.ToString().Replace("S-", ""));
            SizeDTO SizeDuocChon = sizeBUS.getSizeById(maSize);
            if (DGVSize.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailSizeForm detailSize = new DetailSizeForm(SizeDuocChon);
                detailSize.ShowDialog();
            }else if(DGVSize.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteSizeForm deleteSize = new DeleteSizeForm(SizeDuocChon);
                deleteSize.ShowDialog();
                if (deleteSize.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(sizeBUS.getSizeList());
                }
            }else if(DGVSize.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateSizeForm updateSize = new UpdateSizeForm(SizeDuocChon);
                updateSize.ShowDialog();
                if (updateSize.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(sizeBUS.getSizeList());
                    new UpdateSuccessNotification().Show();
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
                            string tenSize = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                            string ghiChu = worksheet.Cells[row, 2].Value?.ToString()?.Trim();

                            if (string.IsNullOrEmpty(tenSize))
                            {
                                errors.AppendLine($"Dòng {row}: Tên size không được để trống");
                                errorCount++;
                                continue;
                            }

                            SizeDTO newSize = new SizeDTO
                            {
                                Tensize = tenSize,
                                Ghichu = string.IsNullOrEmpty(ghiChu) ? "" : ghiChu
                            };

                            if (sizeBUS.insertSize(newSize))
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

                    string message = $"Nhập thành công: {successCount} size\n";
                    if (errorCount > 0)
                    {
                        message += $"Lỗi: {errorCount} dòng\n\nChi tiết lỗi:\n{errors}";
                    }

                    MessageBox.Show(message, "Kết quả nhập Excel",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    if (successCount > 0)
                    {
                        listSize = sizeBUS.getSizeList();
                        refreshDataGridView(listSize);
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
                saveFileDialog.FileName = $"DanhSachSize_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    worksheet.Name = "Danh sách size";

                    worksheet.Cells[1, 1] = "Mã size";
                    worksheet.Cells[1, 2] = "Tên size";
                    worksheet.Cells[1, 3] = "Ghi chú";

                    Excel.Range headerRange = worksheet.Range["A1", "C1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(17, 155, 248));
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    int row = 2;
                    foreach (SizeDTO size in listSize)
                    {
                        worksheet.Cells[row, 1] = $"S-{size.Masize}";
                        worksheet.Cells[row, 2] = size.Tensize;
                        worksheet.Cells[row, 3] = size.Ghichu;
                        row++;
                    }

                    if (row > 2)
                    {
                        Excel.Range dataRange = worksheet.Range["A1", $"C{row - 1}"];
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
