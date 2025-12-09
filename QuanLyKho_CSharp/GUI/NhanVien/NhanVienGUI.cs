using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyKho_CSharp.GUI
{
    public partial class NhanVienGUI : Form
    {
        
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhanVienDTO> listNV;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS= new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;

        public NhanVienGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVNhanVien.ClearSelection();
            DGVNhanVien.RowHeadersVisible = false; // Tắt cột header
            DGVNhanVien.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVNhanVien.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVNhanVien.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVNhanVien.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVNhanVien.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVNhanVien.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVNhanVien.ColumnHeadersHeight = 30;
            DGVNhanVien.RowHeadersDefaultCellStyle = headerStyle;
            DGVNhanVien.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listNV = nvBUS.getListNV();
            this.currentUser = currentUser;
            settingRole();
            //testDAO2();

            
        }
        private void testDAO2()
        {
            BindingList<NhanVienDTO> listNV = nvBUS.testDAO2();
            MessageBox.Show(listNV.Count.ToString());
        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("nhanvien");
            var listCT = nqBUS.getListCTNQByIdNQ(maNQ)
                .Where(ctnq => ctnq.Machucnang == maDMNC).ToList();
            listCTQ = new BindingList<ChiTietQuyenDTO>(listCT);
            // Thực hiện ẩn nút
            bool checkThem = false;
            bool checkSua = false;
            bool checkXoa = false;
            foreach (ChiTietQuyenDTO ctq in listCTQ)
            {
                if(ctq.Hanhdong =="Thêm") checkThem = true;
                if(ctq.Hanhdong =="Sửa") checkSua = true;
                if(ctq.Hanhdong =="Xóa") checkXoa = true;
            }
            if (!checkThem)
            {
                btnThem.Visible = false;
                btnNhapExcel.Visible = false;
            }
            if (!checkSua) DGVNhanVien.Columns.Remove("edit");
            if (!checkXoa) DGVNhanVien.Columns.Remove("remove");
        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listNV);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNhanVienForm addNV = new AddNhanVienForm();
            addNV.ShowDialog();
            if(addNV.DialogResult== DialogResult.OK)
            {
                refreshDataGridView(nvBUS.getListNV());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }   
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ToastForm toast = new ToastForm("SUCCESS", "This is a Success Toast");
            toast.Show();
        }


        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string search_Text = txSearch.Text.Trim();
            BindingList<NhanVienDTO> listSearch = nvBUS.SearchNhanVien(search_Text);
            refreshDataGridView(listSearch);
        }
        private void refreshDataGridView(BindingList<NhanVienDTO> listRefresh) // Tải lại DataGridView
        {
            //Hiển thị thống kê nhân viên
            int soLuongNV = 0;
            DGVNhanVien.Rows.Clear();

            foreach (NhanVienDTO nv in listRefresh.Where(nv => nv.Trangthai == 1))
            {
                string gioiTinh = nv.Gioitinh == 1 ? "Nam" : nv.Gioitinh == 2 ? "Nữ" : "Khác";
                DGVNhanVien.Rows.Add($"NV-{nv.Manv}", nv.Tennv, gioiTinh, nv.Sdt
                , nv.Ngaysinh.ToString("dd/MM/yyyy"), "Hoạt động");
                soLuongNV++;
            }
            DGVNhanVien.ClearSelection();
            lbTotalNV.Text= "Tổng số nhân viên: "+ soLuongNV.ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int manv = int.Parse(DGVNhanVien.Rows[e.RowIndex].Cells["manv"].Value.ToString().Replace("NV-",""));
            NhanVienDTO NhanVienDuocChon = nvBUS.getNVById(manv);
            if (DGVNhanVien.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailNhanVienForm detailNV = new DetailNhanVienForm(NhanVienDuocChon);
                detailNV.ShowDialog();
            }
            if (DGVNhanVien.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateNhanVienForm updateNV = new UpdateNhanVienForm(NhanVienDuocChon);
                updateNV.ShowDialog();
                if (updateNV.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(nvBUS.getListNV());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }
            if (DGVNhanVien.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteNhanVienForm deleteNV = new DeleteNhanVienForm(NhanVienDuocChon);
                deleteNV.ShowDialog();
                if (deleteNV.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(nvBUS.getListNV());
                }
            }
        }

        private void DGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void artanButton1_Click(object sender, EventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbTotalNV_Click(object sender, EventArgs e)
        {

        }
        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            XuatExcel_DSNhanVien();
        }
        private void XuatExcel_DSNhanVien()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveDialog.FileName = "DSNhanVien_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            saveDialog.Title = "Xuất danh sách nhân viên";

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            Excel.Application excel = null;
            Excel.Workbooks workbooks = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            try
            {
                excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                excel.ScreenUpdating = false;     // BẮT BUỘC
                excel.UserControl = false;        // Quan trọng nhất để tránh RPC_E_CALL_REJECTED
                excel.Interactive = false;        // Cũng rất quan trọng

                workbooks = excel.Workbooks;
                wb = workbooks.Add();
                ws = (Excel.Worksheet)wb.ActiveSheet;
                ws.Name = "DS Nhan Vien";

                // === Dòng 1: Tiêu đề ===
                ws.Range["A1:F1"].Merge();
                ws.Cells[1, 1] = "DANH SÁCH NHÂN VIÊN";
                withStyle(ws.Range["A1"], bold: true, size: 16, color: Color.Yellow, hAlign: Excel.XlHAlign.xlHAlignCenter);
                ws.Rows[1].RowHeight = 40;

                ws.Rows[2].RowHeight = 20;

                // === Header ===
                string[] header = { "Mã NV", "Họ tên", "Giới tính", "SĐT", "Ngày sinh", "Trạng thái" };
                for (int i = 0; i < header.Length; i++)
                {
                    ws.Cells[3, i + 1] = header[i];
                    Excel.Range cell = ws.Cells[3, i + 1];
                    cell.Font.Bold = true;
                    cell.Font.Color = Color.White;
                    cell.Interior.Color = Color.FromArgb(0, 112, 192);
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                ws.Rows[3].RowHeight = 30;

                // === Dữ liệu ===
                int row = 4;
                foreach (NhanVienDTO nv in listNV.Where(x => x.Trangthai == 1))
                {
                    ws.Cells[row, 1] = "NV-" + nv.Manv;
                    ws.Cells[row, 2] = nv.Tennv;
                    ws.Cells[row, 3] = nv.Gioitinh == 1 ? "Nam" : (nv.Gioitinh == 2 ? "Nữ" : "Khác");
                    ws.Cells[row, 4] = nv.Sdt;
                    ws.Cells[row, 5] = nv.Ngaysinh.ToString("dd/MM/yyyy");
                    ws.Cells[row, 6] = "Hoạt động";
                    row++;
                }

                ws.Columns.AutoFit();
                ws.Range["A3:F" + (row - 1)].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Lưu file
                wb.SaveAs(saveDialog.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);

                MessageBox.Show("Xuất danh sách nhân viên thành công!\n" + saveDialog.FileName,
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng sạch sẽ – không bao giờ lỗi nữa
                try { wb?.Close(false); } catch { }
                try { excel?.Quit(); } catch { }

                if (ws != null) Marshal.ReleaseComObject(ws);
                if (wb != null) Marshal.ReleaseComObject(wb);
                if (workbooks != null) Marshal.ReleaseComObject(workbooks);
                if (excel != null) Marshal.ReleaseComObject(excel);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                // Giết chết process Excel treo (bí kíp cuối cùng)
                KillExcelProcesses();
            }
        }

        // Hàm phụ để style nhanh
        private void withStyle(Excel.Range range, bool bold = false, int size = 11, Color? color = null, Excel.XlHAlign hAlign = Excel.XlHAlign.xlHAlignLeft)
        {
            if (bold) range.Font.Bold = true;
            if (size > 0) range.Font.Size = size;
            if (color.HasValue) range.Interior.Color = color.Value;
            range.HorizontalAlignment = hAlign;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
        }

        // Giết process Excel do Interop tạo ra
        private void KillExcelProcesses()
        {
            try
            {
                foreach (var p in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                {
                    if (p.MainWindowHandle == IntPtr.Zero) // process ẩn = do code tạo
                        p.Kill();
                }
            }
            catch { }
        }
    }
}
