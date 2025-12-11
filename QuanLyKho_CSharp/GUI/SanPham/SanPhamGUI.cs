using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.GUI.SanPham;
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
    public partial class SanPhamGUI : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private KhuVucKhoBUS khuVucKhoBUS = new KhuVucKhoBUS();
        private ChatLieuBUS chatLieuBUS = new ChatLieuBUS();
        private SizeBUS sizeBUS = new SizeBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<KhuVucKhoDTO> listKV;
        private BindingList<ChatLieuDTO> listCL;
        private BindingList<SizeDTO> listSize;
        private BindingList<LoaiDTO> listLoai;

        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public SanPhamGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            listSP = spBUS.getListSP();
            listKV = khuVucKhoBUS.getKhuVucKhoList();
            listLoai = loaiBUS.getLoaiList();
            listCL = chatLieuBUS.getChatLieuList();
            listSize = sizeBUS.getSizeList();

            ConfigureDataGridView();
            setUpBoxTimKiem();
            LoadDataToGrid(spBUS.getListSP());
            this.currentUser = currentUser;
            settingRole();
        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("tonkho");
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
            if (!checkSua) dgvSanPham.Columns.Remove("edit");
            if (!checkXoa) dgvSanPham.Columns.Remove("remove");
        }
        private void ConfigureDataGridView() // Setting cho DGV
        {
            dgvSanPham.ClearSelection();
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.AllowUserToResizeRows = false;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanPham.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            dgvSanPham.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSanPham.ColumnHeadersHeight = 30;
            dgvSanPham.RowHeadersDefaultCellStyle = headerStyle;
            dgvSanPham.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
        }

        public void setUpBoxTimKiem()
        {
            cbbLoai.Items.Clear();
            cbbLoai.Items.Add("Tất cả loại");
            foreach (LoaiDTO loai in listLoai)
                cbbLoai.Items.Add(loai.Tenloai);
            cbbLoai.SelectedIndex = 0;

            cbbChatLieu.Items.Clear();
            cbbChatLieu.Items.Add("Tất cả chất liệu");
            foreach (ChatLieuDTO cl in listCL)
                cbbChatLieu.Items.Add(cl.Tenchatlieu);
            cbbChatLieu.SelectedIndex = 0;


            cbbKhuVuc.Items.Clear();
            cbbKhuVuc.Items.Add("Tất cả khu vực");
            foreach (KhuVucKhoDTO kv in listKV)
                cbbKhuVuc.Items.Add(kv.Tenkhuvuc);
            cbbKhuVuc.SelectedIndex = 0;

            cbbSize.Items.Clear();
            cbbSize.Items.Add("Tất cả size");
            foreach (SizeDTO s in listSize)
                cbbSize.Items.Add(s.Tensize);
            cbbSize.SelectedIndex = 0;

            //gan sk de khi thay doi no tim luon
            txtSearch.TextChanged += (s, ev) => Filter();
            cbbChatLieu.SelectedIndexChanged += (s, ev) => Filter();
            cbbLoai.SelectedIndexChanged += (s, ev) => Filter();
            cbbKhuVuc.SelectedIndexChanged += (s, ev) => Filter();
            cbbSize.SelectedIndexChanged += (s, ev) => Filter();
            txtSMoney.TextChanged += (s,ev) => Filter();
            txtEMoney.TextChanged += (s,ev) => Filter();
        }
        private void LoadDataToGrid(BindingList<SanPhamDTO> loadList)
        {
            try
            {
                dgvSanPham.Rows.Clear();
                int soLuongSP = 0;
                if (listSP == null || listSP.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Debug - No Data");
                    return;
                }
                foreach (SanPhamDTO sp in loadList)
                {
                    if (sp.Trangthai == 0) continue; 
                    Image productImage = AddPhieuXuatForm.LoadImageSafe(sp.Hinhanh);
                    String tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
                    String tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
                    String tenLoai = loaiBUS.LayTenLoai(sp);
                    String tenSize = sizeBUS.LayTenSize(sp);
                    dgvSanPham.Rows.Add(
                        $"SP-{sp.Masp}",
                        sp.Tensp,
                        productImage,
                        sp.Soluong,
                        sp.Dongia,
                        tenChatLieu,
                        tenLoai,
                        tenKhuVuc,
                        tenSize
                    );
                    soLuongSP++;
                }

                dgvSanPham.ClearSelection();
                lbTotal.Text = $"Tổng số sản phẩm {soLuongSP}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selectedRow = dgvSanPham.CurrentRow;
            string fakeMa = selectedRow.Cells["masp"].Value.ToString();
            int masp = int.Parse(fakeMa.Replace("SP-", ""));
            SanPhamDTO spDuocChon = spBUS.getSPById(masp);
            if (spDuocChon == null) MessageBox.Show($"Sản phẩm không tồn tại");
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailSanPhamForm detailForm = new DetailSanPhamForm(spDuocChon);
                detailForm.ShowDialog();
                if(detailForm.DialogResult == DialogResult.OK)
                {
                    new AddSuccessNotification().Show();
                    LoadDataToGrid(spBUS.getListSP());
                }
            }if(dgvSanPham.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateSanPhamForm updateForm = new UpdateSanPhamForm(spDuocChon);
                updateForm.ShowDialog();
                if (updateForm.DialogResult == DialogResult.OK)
                {
                    new UpdateSuccessNotification().Show();
                    LoadDataToGrid(spBUS.getListSP());
                }
            }
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteSanPhamForm updateForm = new DeleteSanPhamForm(spDuocChon);
                updateForm.ShowDialog();
                if (updateForm.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    LoadDataToGrid(spBUS.getListSP());
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            AddSanPhamForm addSP = new AddSanPhamForm();
            addSP.ShowDialog();
            if (addSP.DialogResult == DialogResult.OK)
            {
                LoadDataToGrid(spBUS.getListSP());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }
        private void Filter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string chatLieu = cbbChatLieu.SelectedItem?.ToString();
            string loai = cbbLoai.SelectedItem?.ToString();
            string khuVuc = cbbKhuVuc.SelectedItem?.ToString();
            string size = cbbSize.SelectedItem?.ToString();

            int maLoai = loaiBUS.LayMaLoai(loai);
            int makv = khuVucKhoBUS.LayMaKhuVuc(khuVuc);
            int maCl = chatLieuBUS.LayMaChatLieu(chatLieu);
            int maSize = sizeBUS.LayMaSize(size);

            var filtered = spBUS.getListSP().ToList();
            if (!string.IsNullOrWhiteSpace(keyword)) {
                filtered = spBUS.TimkiemSanPhamOFormSP(keyword).ToList();
            }
            if (maCl > 0)
                filtered = filtered.Where(sp => sp.Machatlieu == maCl).ToList();
            if (maLoai > 0)
                filtered = filtered.Where(sp => sp.Maloai == maLoai).ToList();
            if (makv > 0)
                filtered = filtered.Where(sp => sp.Makhuvuc == makv).ToList();
            if (maSize > 0)
                filtered = filtered.Where(sp => sp.Masize == maSize).ToList();
            decimal? minPrice = null; // có thể số hoặc null
            decimal? maxPrice = null;
            if (!string.IsNullOrWhiteSpace(txtSMoney.Text) && txtSMoney.Text != "Tiền từ")
            {
                if (decimal.TryParse(txtSMoney.Text, out decimal min)) minPrice = min;
            }
            if (!string.IsNullOrWhiteSpace(txtEMoney.Text) && txtEMoney.Text != "Đến tiền")
            {
                if (decimal.TryParse(txtEMoney.Text, out decimal max)) maxPrice = max;
            }
            if (minPrice.HasValue || maxPrice.HasValue) // True nếu có giá trị
            {
                filtered = filtered.Where(sp =>
                {
                    if (minPrice.HasValue && sp.Dongia < minPrice.Value) return false;
                    if (maxPrice.HasValue && sp.Dongia > maxPrice.Value) return false;
                    return true;
                }).ToList();
            }


            LoadDataToGrid(new BindingList<SanPhamDTO>(filtered));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file Excel";
            saveFileDialog.FileName = "DanhSachSanPham.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "SanPham";

                int colIndex = 1;

               
                worksheet.Cells[1, 1] = "DANH SÁCH SẢN PHẨM";
                Excel.Range titleRange = worksheet.Range[
                    worksheet.Cells[1, 1],
                    worksheet.Cells[1, dgvSanPham.Columns.Count - 4]
                ];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // tieu de cot
                colIndex = 1;
                foreach (DataGridViewColumn col in dgvSanPham.Columns)
                {
                    if (col is DataGridViewImageColumn) continue; 

                    worksheet.Cells[2, colIndex] = col.HeaderText;
                    colIndex++;
                }

               
                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[2, 1],
                    worksheet.Cells[2, colIndex - 1]
                ];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ghi dlieu
                int rowIndex = 3;

                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        colIndex = 1;
                        foreach (DataGridViewColumn col in dgvSanPham.Columns)
                        {
                            if (col is DataGridViewImageColumn) continue;

                            worksheet.Cells[rowIndex, colIndex] = row.Cells[col.Index].Value?.ToString();
                            colIndex++;
                        }
                        rowIndex++;
                    }
                }

             
                worksheet.Columns.AutoFit();

                // luu filwe
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                excelApp.Quit();

                // mo file
                if (File.Exists(saveFileDialog.FileName))
                {
                    Process.Start(new ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });
                }
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

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel File|*.xlsx;*.xls";

            if (open.ShowDialog() != DialogResult.OK)
                return;

            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(open.FileName);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                // Kiểm tra số cột hợp lệ
                if (colCount < 6)
                {
                    MessageBox.Show("File Excel thiếu cột dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                for (int row = 3; row <= rowCount; row++)
                {
                    string tensp = xlRange.Cells[row, 1].Value?.ToString();
                    string dongiaStr = xlRange.Cells[row, 2].Value?.ToString();
                    string chatlieu = xlRange.Cells[row, 3].Value?.ToString();
                    string loai = xlRange.Cells[row, 4].Value?.ToString();
                    string khuvuc = xlRange.Cells[row, 5].Value?.ToString();
                    string size = xlRange.Cells[row, 6].Value?.ToString();


                    if (string.IsNullOrWhiteSpace(tensp))
                        continue; // Bỏ dòng trống

                    int soluong = 0;
                    int dongia = int.TryParse(dongiaStr, out int dg) ? dg : 0;
                    int maCl = chatLieuBUS.LayMaChatLieu(chatlieu);
                    int maLoai = loaiBUS.LayMaLoai(loai);
                    int maKV = khuVucKhoBUS.LayMaKhuVuc(khuvuc);
                    int maSize = sizeBUS.LayMaSize(size);



                    SanPhamDTO sp = new SanPhamDTO();
                    sp.Tensp = tensp;
                    sp.Soluong = soluong;
                    sp.Dongia = dongia;
                    sp.Machatlieu = maCl;
                    sp.Maloai = maLoai;
                    sp.Makhuvuc = maKV;
                    sp.Masize = maSize;
                    sp.Hinhanh = "../images/stocks/no_image.png";   

                    
                    spBUS.insertSanPham(sp);
                }

                MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload lại bảng
                LoadDataToGrid(spBUS.getListSP());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (xlRange != null) Marshal.ReleaseComObject(xlRange);
                if (xlWorksheet != null) Marshal.ReleaseComObject(xlWorksheet);
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false);
                    Marshal.ReleaseComObject(xlWorkbook);
                }
                if (xlApp != null) Marshal.ReleaseComObject(xlApp);
            }
        }




        // Xử lý playholder và keypress
        private void txtSMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }
        private void txtSMoney_MouseLeave(object sender, EventArgs e)
        {
            if (txtSMoney.Text == "" || txtSMoney.Text == null)
            {
                txtSMoney.Text = "Tiền từ";
                if (txtEMoney.Text == "" || txtEMoney.Text == null)
                {
                    txtEMoney.Text = "Đến tiền";
                }
            }
        }

        private void txtEMoney_MouseLeave(object sender, EventArgs e)
        {
            if (txtEMoney.Text == "" || txtEMoney.Text == null)
            {
                txtEMoney.Text = "Đến tiền";
                if (txtSMoney.Text == "" || txtEMoney.Text == null)
                {
                    txtSMoney.Text = "Tiền từ";
                }
            }
        }
        private void txtEMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }

        private void txtEMoney_MouseEnter(object sender, EventArgs e)
        {
            if (txtEMoney.Text == "Đến tiền")
                txtEMoney.Clear();
        }

        private void txtSMoney_MouseEnter(object sender, EventArgs e)
        {
            if (txtSMoney.Text == "Tiền từ")
                txtSMoney.Clear();
        }
    }
}