using Google.Protobuf.Collections;
using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
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

namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    public partial class TaiKhoanGUI : Form
    {
        public TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private BindingList<TaiKhoanDTO> listTK;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;

        public TaiKhoanGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVTaiKhoan.ClearSelection();
            DGVTaiKhoan.RowHeadersVisible = false; // Tắt cột header
            DGVTaiKhoan.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVTaiKhoan.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVTaiKhoan.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVTaiKhoan.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVTaiKhoan.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVTaiKhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVTaiKhoan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVTaiKhoan.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVTaiKhoan.ColumnHeadersHeight = 30;
            DGVTaiKhoan.RowHeadersDefaultCellStyle = headerStyle;
            DGVTaiKhoan.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listTK =tkBUS.getListTK();
            this.currentUser = currentUser;
            settingRole();

        }
        private void TaiKhoanGUI_Load(object sender, EventArgs e)
        {

            refreshDataGridView(listTK);
        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("taikhoan");
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
            if (!checkSua) DGVTaiKhoan.Columns.Remove("edit");
            if (!checkXoa) DGVTaiKhoan.Columns.Remove("remove");
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTaiKhoanForm addTK = new AddTaiKhoanForm();
            addTK.ShowDialog();

            if(addTK.DialogResult == DialogResult.OK)
            {
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
                refreshDataGridView(tkBUS.getListTK());
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AddSuccessNotification tb = new AddSuccessNotification();
            tb.Show();
            refreshDataGridView(tkBUS.getListTK());
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            
            string TextSearch=txSearch.Text.Trim();
            BindingList<TaiKhoanDTO> listSearch=tkBUS.SearchTaiKhoan(TextSearch);
            refreshDataGridView(listSearch);
        }
        private void refreshDataGridView(BindingList<TaiKhoanDTO> listRefresh) // Tải lại DataGridView
        {
            int soLuongNV = 0;
            DGVTaiKhoan.Rows.Clear();
            foreach (TaiKhoanDTO tk in listRefresh.Where(tk => tk.Trangthai == 1))
            {

                DGVTaiKhoan.Rows.Add($"TK-{tk.Manv}", tk.Tendangnhap, tk.Matkhau,
                    tk.Manhomquyen, "Hoạt động");
                soLuongNV++;
            }
            lbTotal.Text = "Tổng số tài khoản: " + soLuongNV.ToString();
            DGVTaiKhoan.ClearSelection();
        }

        private void DGVTaiKhoan_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int matk = int.Parse(DGVTaiKhoan.Rows[e.RowIndex].Cells["matk"].Value.ToString().Replace("TK-",""));
            TaiKhoanDTO TaiKhoanDuocChon = tkBUS.getTKById(matk);
            if (DGVTaiKhoan.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailTaiKhoanForm detailTK = new DetailTaiKhoanForm(TaiKhoanDuocChon);
                detailTK.ShowDialog();
            }
            if (DGVTaiKhoan.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateTaiKhoanForm detailTK = new UpdateTaiKhoanForm(TaiKhoanDuocChon);
                detailTK.ShowDialog();
                if (detailTK.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(tkBUS.getListTK());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }
            if (DGVTaiKhoan.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteTaiKhoanForm deleteTk = new DeleteTaiKhoanForm(TaiKhoanDuocChon);
                deleteTk.ShowDialog();
                if (deleteTk.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(tkBUS.getListTK());
                }
            }
        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddTaiKhoanForm addNV = new AddTaiKhoanForm();
            addNV.ShowDialog();
            if (addNV.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(tkBUS.getListTK());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (DGVTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Workbook|*.xlsx";
            save.Title = "Chọn nơi lưu file Excel";
            save.FileName = "DanhSachTaiKhoan.xlsx";

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
                worksheet.Name = "TaiKhoan";

                int colIndex = 1;
                worksheet.Cells[1, 1] = "DANH SÁCH TÀI KHOẢN";
                Excel.Range titleRange = worksheet.Range[
                    worksheet.Cells[1, 1],
                    worksheet.Cells[1, DGVTaiKhoan.Columns.Count]
                ];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                colIndex = 1;
                int check = 0;

                foreach (DataGridViewColumn col in DGVTaiKhoan.Columns)
                {
                    if (check == 5) break;
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

                foreach (DataGridViewRow row in DGVTaiKhoan.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        colIndex = 1;
                        check = 0;

                        foreach (DataGridViewColumn col in DGVTaiKhoan.Columns)
                        {
                            if (check == 5) break;

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
