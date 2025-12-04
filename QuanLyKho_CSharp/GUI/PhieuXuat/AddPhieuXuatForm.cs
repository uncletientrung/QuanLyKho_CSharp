using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.Helper;
using QuanLyKho_CSharp.Helper.DropDownSearch;
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
using static QuanLyKho_CSharp.GUI.PhieuNhap.AddPhieuNhapForm;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKho_CSharp.GUI.PhieuXuat
{
    public partial class AddPhieuXuatForm : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private PhieuXuatBUS pxBUS = new PhieuXuatBUS();
        private KhachHangBUS khBUS = new KhachHangBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
        private BindingList<KhachHangDTO> listKH;
        private BindingList<SanPhamDTO> listSP;
        private BindingList<SanPhamDTO> listSPDuocThem;
        private Action OnClose;
        private NhanVienDTO currentUser;
        public AddPhieuXuatForm(Action btnOnClose, NhanVienDTO currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            OnClose=btnOnClose;
            SetupDataGridViews();
            LoadData();
            //UpdateButtonStates();
        }

        private void SetupDataGridViews()
        {
            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            // Cấu hình dgvSPtrongKho
            dgvSPtrongKho.ClearSelection();
            dgvSPtrongKho.RowHeadersVisible = false;
            dgvSPtrongKho.AllowUserToResizeRows = false;
            dgvSPtrongKho.AllowUserToAddRows = false;
            dgvSPtrongKho.ReadOnly = true;
            dgvSPtrongKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPtrongKho.MultiSelect = false;
            dgvSPtrongKho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPtrongKho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPtrongKho.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSPtrongKho.ColumnHeadersHeight = 30;
            dgvSPtrongKho.RowHeadersDefaultCellStyle = headerStyle;
            dgvSPtrongKho.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            // Cấu hình dgvSPduocThem
            dgvSPduocThem.ClearSelection();
            dgvSPduocThem.RowHeadersVisible = false;
            dgvSPduocThem.AllowUserToResizeRows = false;
            dgvSPduocThem.AllowUserToAddRows = false;
            dgvSPduocThem.ReadOnly = true;
            dgvSPduocThem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPduocThem.MultiSelect = false;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.ColumnHeadersHeight = 30;
            dgvSPduocThem.RowHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            dgvSPduocThem.Columns[2].ReadOnly = false;

            listSPDuocThem = new BindingList<SanPhamDTO>();
        }

        public static Image LoadImageSafe(string absolutePath)
        {
            if (string.IsNullOrWhiteSpace(absolutePath)) return CreateEmptyImage();
            if (!File.Exists(absolutePath)) return CreateEmptyImage();
            try
            {
                using (var original = Image.FromFile(absolutePath)) // Stretch ảnh
                {
                    var resized = new Bitmap(40, 40);
                    using (var g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, 40, 40);
                    }
                    return resized;
                }
            }
            catch
            {
                return CreateEmptyImage();
            }
        }

        public static Image CreateEmptyImage() // Ảnh trống
        {
            Bitmap emptyImage = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(emptyImage))
            {
                g.Clear(Color.Gray);
            }
            return emptyImage;
        }

        private void LoadData()
        {
            listSP = spBUS.getListSP();
            listKH = khBUS.getListKH();
            txNV.Text = currentUser.Tennv.ToString();
            LoadSPTrongKho();
            LoadSPDuocThem();
        }


        private void LoadSPTrongKho()
        {
            dgvSPtrongKho.Rows.Clear();
            // Thêm dữ liệu
            if (listSP != null && listSP.Count > 0)
            {
                foreach (SanPhamDTO sp in listSP)
                {
                    Image productImage = LoadImageSafe(sp.Hinhanh);
                    dgvSPtrongKho.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        productImage,
                        sp.Dongia,
                        sp.Soluong
                    );
                }
            }
            dgvSPtrongKho.ClearSelection();
        }

        private void LoadSPDuocThem()
        {
            dgvSPduocThem.Rows.Clear();
            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
            {
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    decimal thanhTien = sp.Dongia * sp.Soluong;
                    dgvSPduocThem.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        sp.Soluong,
                        sp.Dongia,
                        $"{thanhTien:N0}đ"
                    );
                }
            }
            dgvSPduocThem.ClearSelection();
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
            {
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    tongTien += sp.Dongia * sp.Soluong;
                }
            }
            lbPrice.Text = $"{tongTien:N0}đ";
        }
        // Thêm sản phẩm vào phiếu
        private void dgvSPtrongKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvSPtrongKho.CurrentRow == null || dgvSPtrongKho.CurrentRow.IsNewRow)
                    return;

                var selectedRow = dgvSPtrongKho.CurrentRow;
                int maSP = int.Parse(selectedRow.Cells[0].Value.ToString());

                SanPhamDTO spTrongKho = listSP.FirstOrDefault(x => x.Masp == maSP);
                if (spTrongKho == null) return;

                if (spTrongKho.Soluong <= 0)
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng!", "Hết hàng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UpdateQuantity(spTrongKho);
            }
        }

        // Chính sửa số lượng nếu cần
        private void dgvSPduocThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                if (dgvSPduocThem.CurrentRow == null) return;
                var selectedRow = dgvSPduocThem.CurrentRow;
                int maSP = int.Parse(selectedRow.Cells[0].Value.ToString());
                SanPhamDTO spDuocChon = listSPDuocThem.FirstOrDefault(x => x.Masp == maSP);
                if (spDuocChon == null) return;
                if (dgvSPduocThem.Columns[e.ColumnIndex].Name != "remove") UpdateQuantity(spDuocChon);
                else if (dgvSPduocThem.Columns[e.ColumnIndex].Name == "remove") {
                    listSPDuocThem.Remove(spDuocChon);
                    LoadSPDuocThem();  
                }
            }
        }
        private void UpdateQuantity(SanPhamDTO spDuocChon)
        {
            var existingSP = listSPDuocThem.FirstOrDefault(x => x.Masp == spDuocChon.Masp);
            string title = existingSP != null ? "Chỉnh sửa số lượng" : "Nhập số lượng";
            int soLuongTruyenVao = existingSP != null ? existingSP.Soluong : 1;
            int soluongTon = listSP.FirstOrDefault(sp => sp.Masp == spDuocChon.Masp).Soluong;
            var inputForm = new QuantityForm(title, soLuongTruyenVao, soluongTon);
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int sl = inputForm.Quantity;
                if (existingSP != null)
                {
                    existingSP.Soluong = sl;
                }
                else
                {
                    var spMoi = new SanPhamDTO
                    {
                        Masp = spDuocChon.Masp,
                        Tensp = spDuocChon.Tensp,
                        Dongia = spDuocChon.Dongia,
                        Soluong = sl
                    };
                    listSPDuocThem.Add(spMoi);
                }

                LoadSPDuocThem();
            }
            else
            {
                txSearch.Clear();
            }
        }
        private void txSearch_TextChanged(object sender, EventArgs e) // Tìm kiếm sản phẩm
        {
            string textSearch = txSearch.Text.Trim();
            listContainer.Controls.Clear();
            if (string.IsNullOrEmpty(textSearch))
            {
                listContainer.Height = 0;
                return;
            }
            BindingList<SanPhamDTO> resultList = SearchResultControl.TimKiem(textSearch);
            if(resultList.Count == 0)
            {
                listContainer.Controls.Add(new Label
                {
                    Text = "Không tìm thấy sản phẩm",
                    Dock = DockStyle.Top,
                    Height = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                listContainer.Height = 50;
                return;
            }
            foreach( SanPhamDTO sp in resultList)
            {
                var item = new SearchResultControl();
                item.BindData(sp);
                item.OnProductSelected += (objPhatRaSuKien, selectedSp) =>
                {
                    txSearch.Text = $"{selectedSp.Masp} | {selectedSp.Tensp} "+ $"| SL: {sp.Soluong} | Giá: {sp.Dongia:N0}đ";
                    listContainer.Height = 0;
                    txSearch.SelectionStart = txSearch.Text.Length;
                    UpdateQuantity(sp);
                };
                listContainer.Controls.Add(item);
            }
            listContainer.Height = Math.Min(resultList.Count * 54 + 10, 300);
        }

        private void txSearchCustomer_TextChanged(object sender, EventArgs e) // Tìm khách hàng
        {
            listContainerCustomer.AutoScroll = true;
            string textSearch = txSearchCustomer.Text.Trim();
            listContainerCustomer.Controls.Clear();
            if (string.IsNullOrEmpty(textSearch))
            {
                listContainerCustomer.Height = 0;
                return;
            }
            BindingList<KhachHangDTO> resultList = SearchResultControlCustomer.TimKiem(textSearch);
            if (resultList.Count == 0)
            {
                listContainerCustomer.Controls.Add(new Label
                {
                    Text = "Không tìm thấy khách hàng",
                    Dock = DockStyle.Top,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                listContainerCustomer.Height = 30;
                return;
            }
            foreach (KhachHangDTO kh in resultList)
            {
                var item = new SearchResultControlCustomer();
                item.BindData(kh);
                item.Dock = DockStyle.Top;
                item.OnCustomerSelected += (objPhatRaSuKien, selectedKh) =>
                {
                    txSearchCustomer.Text = $"{selectedKh.Makh} | {selectedKh.Tenkhachhang} " + $"| SDT: {selectedKh.Sdt}";
                    listContainerCustomer.Height = 0;
                    txSearchCustomer.SelectionStart = txSearchCustomer.Text.Length;
                };
                listContainerCustomer.Controls.Add(item);
            }
            listContainerCustomer.Height = Math.Min(resultList.Count * 30 + 10, 120);
        }
        private void artanButton3_Click(object sender, EventArgs e) // Thêm khách mới
        {
            AddKhachHangForm addKHForm = new AddKhachHangForm();
            DialogResult result = addKHForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (listKH != null && listKH.Count > 0)
                {
                    var newestKH = listKH.OrderByDescending(kh => kh.Makh).FirstOrDefault();

                    if (newestKH != null)
                    {
                        txSearchCustomer.Text = $"{newestKH.Makh} | {newestKH.Tenkhachhang} " + $"| SDT: {newestKH.Sdt}";
                    }
                }
            }
        }


        //        private void buttonXuatHang_Click(object sender, EventArgs e)
        //        {
        //            if (listSPDuocThem == null || listSPDuocThem.Count == 0)
        //            {
        //                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm!", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            // Kiểm tra số lượng tồn kho trước khi xuất
        //            if (!KiemTraSoLuongTonKho())
        //            {
        //                return;
        //            }

        //            // Xử lý mã khách hàng - để tạm 0 nếu không có
        //            int maKH = 0;
        //            if (!string.IsNullOrEmpty(comboBoxKH.Text))
        //            {
        //                string tenKHChon = comboBoxKH.Text.Trim();

        //                // Tìm KH trong danh sách dựa trên tên
        //                KhachHangDTO khDuocChon = listKH.FirstOrDefault(kh =>
        //                    kh.Tenkhachhang.Equals(tenKHChon));

        //                if (khDuocChon != null)
        //                {
        //                    maKH = khDuocChon.Makh;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Khách hàng không hợp lệ!", "Lỗi",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                return;
        //            }

        //            // Lấy mã nhân viên từ frmMain.CurrentUser
        //            int maNV = 1; // Mặc định
        //            try
        //            {
        //                TaiKhoanDTO currentUser = frmMain.CurrentUser;
        //                if (currentUser != null)
        //                {
        //                    maNV = currentUser.Manv;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Không thể lấy thông tin nhân viên: " + ex.Message, "Cảnh báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }

        //            // Tạo phiếu xuất mới
        //            PhieuXuatDTO newPhieuXuat = new PhieuXuatDTO
        //            {
        //                Maphieu = int.Parse(boxMaPhieu.Text),
        //                Manv = maNV,
        //                Makh = maKH,
        //                Thoigiantao = DateTime.Now,
        //                Tongtien = (int)CalculateTongTien(),
        //                Trangthai = 1
        //            };

        //            // Lưu phiếu xuất
        //            if (pxBUS.insertPhieuXuat(newPhieuXuat))
        //            {
        //                // Tạo danh sách chi tiết phiếu xuất
        //                BindingList<ChiTietPhieuXuatDTO> listCTPX = new BindingList<ChiTietPhieuXuatDTO>();

        //                foreach (SanPhamDTO sp in listSPDuocThem)
        //                {
        //                    ChiTietPhieuXuatDTO ctpx = new ChiTietPhieuXuatDTO
        //                    {
        //                        Maphieuxuat = newPhieuXuat.Maphieu,
        //                        Masp = sp.Masp,
        //                        Soluong = sp.Soluong,
        //                        Dongia = sp.Dongia
        //                    };
        //                    listCTPX.Add(ctpx);
        //                }

        //                // Lưu chi tiết phiếu xuất
        //                if (ctpxBUS.insertChiTietPhieuXuat(listCTPX))
        //                {
        //                    // Cập nhật số lượng sản phẩm trong kho (giảm số lượng)
        //                    UpdateSoLuongSanPhamAfterXuat();

        //                    MessageBox.Show("Xuất hàng thành công!", "Thông báo",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                    // Đóng form hiện tại và mở PhieuXuatGUI
        //                    frmMain mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
        //                    if (mainForm != null)
        //                    {
        //                        var method = mainForm.GetType().GetMethod("OpenChildForm",
        //                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        //                        if (method != null)
        //                        {
        //                            method.Invoke(mainForm, new object[] { new PhieuXuatGUI(), mainForm.Controls.Find("btnPhieuXuat", true).FirstOrDefault() });
        //                        }
        //                    }

        //                    this.Close();
        //                }
        //                else
        //                {
        //                    // Nếu có lỗi khi lưu chi tiết, xóa phiếu xuất đã tạo
        //                    pxBUS.removePhieuXuat(newPhieuXuat.Maphieu);
        //                    MessageBox.Show("Có lỗi xảy ra khi lưu chi tiết phiếu xuất!", "Lỗi",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Có lỗi xảy ra khi tạo phiếu xuất!", "Lỗi",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        //        private void UpdateSoLuongSanPhamAfterXuat()
        //        {
        //            try
        //            {
        //                foreach (SanPhamDTO sp in listSPDuocThem)
        //                {
        //                    // Tìm sản phẩm trong danh sách hiện tại
        //                    SanPhamDTO spInList = listSP.FirstOrDefault(s => s.Masp == sp.Masp);
        //                    if (spInList != null)
        //                    {
        //                        // Cập nhật số lượng (giảm số lượng sản phẩm trong kho)
        //                        spInList.Soluong -= sp.Soluong;

        //                        // Cập nhật trong database
        //                        spBUS.updateSanPham(spInList);
        //                    }
        //                }

        //                // Reload lại danh sách sản phẩm để cập nhật số lượng mới nhất
        //                listSP = spBUS.getListSP();
        //                LoadSPTrongKho();

        //                MessageBox.Show("Đã cập nhật số lượng sản phẩm trong kho!", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Có lỗi khi cập nhật số lượng sản phẩm: " + ex.Message, "Lỗi",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        private void AddPhieuXuatForm_Load(object sender, EventArgs e)
        {
            //LoadData();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void artanButton5_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke(); // Thực hiện delegate
        }


        private void dgvSPtrongKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

       





        //        private void ReloadKhachHang()
        //        {
        //            listKH = khBUS.getListKH();
        //            string currentSelection = comboBoxKH.Text;

        //            // Clear và load lại combobox
        //            comboBoxKH.Items.Clear();

        //            if (listKH != null && listKH.Count > 0)
        //            {
        //                foreach (KhachHangDTO kh in listKH)
        //                {
        //                    comboBoxKH.Items.Add(kh.Tenkhachhang);
        //                }
        //            }

        //            // Khôi phục selection cũ (nếu vẫn tồn tại)
        //            if (!string.IsNullOrEmpty(currentSelection) && comboBoxKH.Items.Contains(currentSelection))
        //            {
        //                comboBoxKH.Text = currentSelection;
        //            }
        //        }

        //        private void AutoSelectNewKhachHang()
        //        {
        //            if (listKH != null && listKH.Count > 0)
        //            {
        //                // Lấy khách hàng mới nhất (có mã khách hàng lớn nhất)
        //                var newestKH = listKH.OrderByDescending(kh => kh.Makh).FirstOrDefault();

        //                if (newestKH != null)
        //                {
        //                    // Chọn khách hàng mới nhất trong combobox
        //                    comboBoxKH.Text = newestKH.Tenkhachhang;
        //                }
        //            }
        //        }

        //        private void buttonNhapExcel_Click(object sender, EventArgs e)
        //        {
        //            OpenFileDialog openFileDialog = new OpenFileDialog();
        //            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
        //            openFileDialog.Title = "Chọn file Excel để nhập";

        //            if (openFileDialog.ShowDialog() != DialogResult.OK)
        //                return;

        //            Excel.Application excelApp = null;
        //            Excel.Workbook workbook = null;
        //            Excel.Worksheet worksheet = null;

        //            try
        //            {
        //                excelApp = new Excel.Application();
        //                workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
        //                worksheet = workbook.Sheets[1];

        //                // Đọc dữ liệu từ Excel
        //                Excel.Range usedRange = worksheet.UsedRange;
        //                int rowCount = usedRange.Rows.Count;

        //                if (rowCount < 2)
        //                {
        //                    MessageBox.Show("File Excel không có dữ liệu!", "Thông báo",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                }

        //                int successCount = 0;
        //                int errorCount = 0;
        //                StringBuilder errorMessages = new StringBuilder();

        //                // Bắt đầu từ row 2 (bỏ qua header)
        //                for (int row = 2; row <= rowCount; row++)
        //                {
        //                    try
        //                    {
        //                        // Đọc Mã SP từ cột A
        //                        var maSPCell = worksheet.Cells[row, 1].Value;
        //                        if (maSPCell == null)
        //                            continue;

        //                        int maSP = Convert.ToInt32(maSPCell);

        //                        // Đọc Số lượng từ cột D
        //                        var soLuongCell = worksheet.Cells[row, 4].Value;
        //                        if (soLuongCell == null)
        //                        {
        //                            errorMessages.AppendLine($"Dòng {row}: Thiếu số lượng cho mã SP {maSP}");
        //                            errorCount++;
        //                            continue;
        //                        }

        //                        int soLuong = Convert.ToInt32(soLuongCell);

        //                        if (soLuong <= 0)
        //                        {
        //                            errorMessages.AppendLine($"Dòng {row}: Số lượng phải lớn hơn 0 (Mã SP: {maSP})");
        //                            errorCount++;
        //                            continue;
        //                        }

        //                        // Tìm sản phẩm trong kho
        //                        SanPhamDTO spTrongKho = listSP.FirstOrDefault(sp => sp.Masp == maSP);

        //                        if (spTrongKho == null)
        //                        {
        //                            errorMessages.AppendLine($"Dòng {row}: Không tìm thấy sản phẩm mã {maSP} trong kho");
        //                            errorCount++;
        //                            continue;
        //                        }

        //                        if (spTrongKho.Soluong <= 0)
        //                        {
        //                            errorMessages.AppendLine($"Dòng {row}: Sản phẩm {spTrongKho.Tensp} (Mã: {maSP}) đã hết hàng");
        //                            errorCount++;
        //                            continue;
        //                        }

        //                        if (soLuong > spTrongKho.Soluong)
        //                        {
        //                            errorMessages.AppendLine($"Dòng {row}: Số lượng vượt quá tồn kho. " +
        //                                $"SP: {spTrongKho.Tensp}, Tồn: {spTrongKho.Soluong}, Yêu cầu: {soLuong}");
        //                            errorCount++;
        //                            continue;
        //                        }

        //                        // Kiểm tra xem sản phẩm đã có trong danh sách chưa
        //                        SanPhamDTO existingSP = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);

        //                        if (existingSP != null)
        //                        {
        //                            // Nếu đã có, cộng thêm số lượng
        //                            int tongSoLuong = existingSP.Soluong + soLuong;

        //                            if (tongSoLuong > spTrongKho.Soluong)
        //                            {
        //                                errorMessages.AppendLine($"Dòng {row}: Tổng số lượng vượt quá tồn kho. " +
        //                                    $"SP: {spTrongKho.Tensp}, Tồn: {spTrongKho.Soluong}, " +
        //                                    $"Đã thêm: {existingSP.Soluong}, Yêu cầu thêm: {soLuong}");
        //                                errorCount++;
        //                                continue;
        //                            }

        //                            existingSP.Soluong = tongSoLuong;
        //                        }
        //                        else
        //                        {
        //                            // Nếu chưa có, thêm mới
        //                            SanPhamDTO newSP = new SanPhamDTO
        //                            {
        //                                Masp = spTrongKho.Masp,
        //                                Tensp = spTrongKho.Tensp,
        //                                Dongia = spTrongKho.Dongia,
        //                                Soluong = soLuong
        //                            };
        //                            listSPDuocThem.Add(newSP);
        //                        }

        //                        successCount++;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        errorMessages.AppendLine($"Dòng {row}: Lỗi - {ex.Message}");
        //                        errorCount++;
        //                    }
        //                }

        //                // Cập nhật lại DataGridView
        //                LoadSPDuocThem();

        //                // Hiển thị kết quả
        //                StringBuilder resultMessage = new StringBuilder();
        //                resultMessage.AppendLine($"Kết quả nhập Excel:");
        //                resultMessage.AppendLine($"✓ Thành công: {successCount} sản phẩm");

        //                if (errorCount > 0)
        //                {
        //                    resultMessage.AppendLine($"✗ Lỗi: {errorCount} dòng");
        //                    resultMessage.AppendLine();
        //                    resultMessage.AppendLine("Chi tiết lỗi:");
        //                    resultMessage.Append(errorMessages.ToString());

        //                    MessageBox.Show(resultMessage.ToString(), "Kết quả nhập Excel",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                }
        //                else
        //                {
        //                    MessageBox.Show(resultMessage.ToString(), "Thành công",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Có lỗi xảy ra khi đọc file Excel: {ex.Message}", "Lỗi",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            finally
        //            {
        //                // Giải phóng tài nguyên
        //                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
        //                if (workbook != null)
        //                {
        //                    workbook.Close(false);
        //                    Marshal.ReleaseComObject(workbook);
        //                }
        //                if (excelApp != null)
        //                {
        //                    excelApp.Quit();
        //                    Marshal.ReleaseComObject(excelApp);
        //                }

        //                GC.Collect();
        //                GC.WaitForPendingFinalizers();
        //            }
        //        }

        //    }

 
    }
}