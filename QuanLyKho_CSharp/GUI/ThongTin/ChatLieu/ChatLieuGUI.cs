using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class ChatLieuGUI : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private BindingList<ChatLieuDTO> listCL;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public ChatLieuGUI(NhanVienDTO cureentUser)
        {
            InitializeComponent();
            // Thiết lập DataGridView
            DGVChatLieu.ClearSelection();
            DGVChatLieu.RowHeadersVisible = false; // Tắt cột header
            DGVChatLieu.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVChatLieu.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVChatLieu.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVChatLieu.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVChatLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVChatLieu.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVChatLieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVChatLieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVChatLieu.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVChatLieu.ColumnHeadersHeight = 30;
            DGVChatLieu.RowHeadersDefaultCellStyle = headerStyle;
            DGVChatLieu.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listCL = clBUS.getChatLieuList();
            this.currentUser = cureentUser;
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
            if (!checkSua) DGVChatLieu.Columns.Remove("edit");
            if (!checkXoa) DGVChatLieu.Columns.Remove("remove");
        }

        private void ChatLieuGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listCL);
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txSearch.Text.Trim().ToLower();
            BindingList<ChatLieuDTO> listSearch = clBUS.searchChatLieu(keyword);
            refreshDataGridView(listSearch); 
        }

        private void refreshDataGridView(BindingList<ChatLieuDTO> list)
        {
            DGVChatLieu.Rows.Clear();
            int soluong = 0;
            foreach (ChatLieuDTO cl in list)
            {
                DGVChatLieu.Rows.Add($"CL-{cl.Machatlieu}", cl.Tenchatlieu);
                soluong++;
            }
            DGVChatLieu.ClearSelection();
            lbTotalNV.Text = "Tổng số chất liệu: " + soluong.ToString();
        }

        private void DGVChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maCL = int.Parse(DGVChatLieu.Rows[e.RowIndex].Cells["macl"].Value.ToString().Replace("CL-", ""));
            ChatLieuDTO chatLieuDuocChon = clBUS.getChatLieuById(maCL);
            if (DGVChatLieu.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailChatLieuForm detailCL = new DetailChatLieuForm(chatLieuDuocChon);
                detailCL.ShowDialog();
            }else if (DGVChatLieu.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateChatLieuForm updateCL = new UpdateChatLieuForm(chatLieuDuocChon);
                updateCL.ShowDialog();
                if (updateCL.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(clBUS.getChatLieuList());
                    new AddSuccessNotification().Show();
                }
            }else if(DGVChatLieu.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteChatLieuForm deleteCL = new DeleteChatLieuForm(chatLieuDuocChon);
                deleteCL.ShowDialog();
                if (deleteCL.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(clBUS.getChatLieuList());
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddChatLieuForm addCL = new AddChatLieuForm();
            addCL.ShowDialog();

            if (addCL.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(clBUS.getChatLieuList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
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
                            string tenCL = worksheet.Cells[row, 1].Value?.ToString()?.Trim();

                            if (string.IsNullOrEmpty(tenCL))
                            {
                                errors.AppendLine($"Dòng {row}: Tên chất liệu không được để trống");
                                errorCount++;
                                continue;
                            }

                            ChatLieuDTO newCL = new ChatLieuDTO
                            {
                                Tenchatlieu = tenCL
                            };

                            if (clBUS.insertChatLieu(newCL))
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

                    string message = $"Nhập thành công: {successCount} chất liệu\n";
                    if (errorCount > 0)
                    {
                        message += $"Lỗi: {errorCount} dòng\n\nChi tiết lỗi:\n{errors}";
                    }

                    MessageBox.Show(message, "Kết quả nhập Excel",
                        MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    if (successCount > 0)
                    {
                        listCL = clBUS.getChatLieuList();
                        refreshDataGridView(listCL);
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
                saveFileDialog.FileName = $"DanhSachChatLieu_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application();
                    excelApp.DisplayAlerts = false;
                    workbook = excelApp.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                    worksheet.Name = "Danh sách chất liệu";

                    worksheet.Cells[1, 1] = "Mã chất liệu";
                    worksheet.Cells[1, 2] = "Tên chất liệu";

                    Excel.Range headerRange = worksheet.Range["A1", "B1"];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(17, 155, 248));
                    headerRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    int row = 2;
                    foreach (ChatLieuDTO cl in listCL)
                    {
                        worksheet.Cells[row, 1] = $"CL-{cl.Machatlieu}";
                        worksheet.Cells[row, 2] = cl.Tenchatlieu;
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
