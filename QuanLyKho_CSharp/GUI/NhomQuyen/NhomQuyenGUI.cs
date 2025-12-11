using OfficeOpenXml;
using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.NhomQuyen;
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

namespace QuanLyKho_CSharp.GUI.PhanQuyen
{
    public partial class NhomQuyenGUI : Form
    {
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        private NhanVienDTO currentUser;
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public NhomQuyenGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVPhanQuyen.ClearSelection();
            DGVPhanQuyen.RowHeadersVisible = false; // Tắt cột header
            DGVPhanQuyen.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVPhanQuyen.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVPhanQuyen.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVPhanQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVPhanQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVPhanQuyen.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVPhanQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVPhanQuyen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVPhanQuyen.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVPhanQuyen.ColumnHeadersHeight = 30;
            DGVPhanQuyen.RowHeadersDefaultCellStyle = headerStyle;
            DGVPhanQuyen.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            listNQ = nqBUS.getListNQ();
            refreshDataGridView(listNQ);
            this.currentUser = currentUser;
            settingRole();
        }

        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("phanquyen");
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
            }
            if (!checkSua) DGVPhanQuyen.Columns.Remove("edit");
            if (!checkXoa) DGVPhanQuyen.Columns.Remove("remove");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNhomQuyenForm addNhomQuyenForm = new AddNhomQuyenForm();
            addNhomQuyenForm.ShowDialog();
            if (addNhomQuyenForm.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(nqBUS.getListNQ());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void PhanQuyenGUI_Load(object sender, EventArgs e)
        {

        }

        

        private void DGVPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int manq = int.Parse(DGVPhanQuyen.Rows[e.RowIndex].Cells["manq"].Value.ToString().Replace("NQ-",""));
            NhomQuyenDTO NhomQuyenDuocChon = nqBUS.getNQById(manq);
            if (DGVPhanQuyen.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailNhomQuyenForm detailNQ = new DetailNhomQuyenForm(NhomQuyenDuocChon);
                detailNQ.ShowDialog();
            }
            if (DGVPhanQuyen.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateNhomQuyenForm updateNQ = new UpdateNhomQuyenForm(NhomQuyenDuocChon);
                updateNQ.ShowDialog();
                if (updateNQ.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(nqBUS.getListNQ());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }
            if (DGVPhanQuyen.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteNhomQuyenForm deleteNV = new DeleteNhomQuyenForm(NhomQuyenDuocChon);
                deleteNV.ShowDialog();
                if (deleteNV.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(nqBUS.getListNQ());
                }
            }
        }
        #region Xử lý tìm kiểm
        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string textSearch = txSearch.Text;
            listNQ = nqBUS.searchNhomQuyen(textSearch);
            refreshDataGridView(listNQ);

        }
        #endregion
        private void refreshDataGridView(BindingList<NhomQuyenDTO> listRefresh) // Tải lại DataGridView
        {
            int soluong =0;
            DGVPhanQuyen.Rows.Clear();
            foreach (NhomQuyenDTO nq in listRefresh.Where( item => item.Trangthai == 1))
            {
                DGVPhanQuyen.Rows.Add($"NQ-{nq.Manhomquyen}", nq.Tennhomquyen, "Hoạt động");
                soluong++;
            }
            lbTotalNV.Text = "Tổng số nhóm quyền: " + soluong.ToString();
            DGVPhanQuyen.ClearSelection();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (DGVPhanQuyen.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Workbook|*.xlsx";
            save.Title = "Chọn nơi lưu file Excel";
            save.FileName = "DanhSachPhanQuyen.xlsx";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "PhanQuyen";

                int colIndex = 1;
                worksheet.Cells[1, 1] = "DANH SÁCH PHÂN QUYỀN";
                Excel.Range titleRange = worksheet.Range[
                    worksheet.Cells[1, 1],
                    worksheet.Cells[1, DGVPhanQuyen.Columns.Count]
                ];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                var exportColumns = new[] { "manq", "tennhomquyen", "trangthai" };

                colIndex = 1;
                int check = 0;
                foreach (DataGridViewColumn col in DGVPhanQuyen.Columns)
                {
                    if (check == 3) break;
                    worksheet.Cells[2, colIndex] = col.HeaderText;
                    colIndex++;
                    check++;
                }

                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[2, 1],
                    worksheet.Cells[2, colIndex - 1]
                ];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                int rowIndex = 3;

                foreach (DataGridViewRow row in DGVPhanQuyen.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        colIndex = 1;
                        check = 0;
                        foreach (DataGridViewColumn col in DGVPhanQuyen.Columns)
                        {
                            if (check == 3) break ;
                            
                            worksheet.Cells[rowIndex, colIndex] =
                                row.Cells[col.Index].Value?.ToString();
                            colIndex++;
                            check++;
                        }
                        rowIndex++;
                    }
                }

                worksheet.Columns.AutoFit();
                workbook.SaveAs(save.FileName);
                workbook.Close();
                excelApp.Quit();

                if (File.Exists(save.FileName))
                {
                    Process.Start(new ProcessStartInfo(save.FileName) { UseShellExecute = true });
                }

                MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }
        


    }
}
