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
using System.Diagnostics;
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
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (DGVNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Workbook|*.xlsx";
            save.Title = "Chọn nơi lưu file Excel";
            save.FileName = "DanhSachNhanVien.xlsx";

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
                worksheet.Name = "NhanVien";

                int colIndex = 1;
                worksheet.Cells[1, 1] = "DANH SÁCH NHÂN VIÊN";
                Excel.Range titleRange = worksheet.Range[
                    worksheet.Cells[1, 1],
                    worksheet.Cells[1, 6]
                ];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                colIndex = 1;
                int check = 0;
                foreach (DataGridViewColumn col in DGVNhanVien.Columns)
                {
                    if (check == 6) break;
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
                foreach (DataGridViewRow row in DGVNhanVien.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        colIndex = 1;
                        check = 0;

                        foreach (DataGridViewColumn col in DGVNhanVien.Columns)
                        {
                            if (check == 6) break;
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
