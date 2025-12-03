using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
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
        public AddPhieuXuatForm(Action btnOnClose)
        {
            InitializeComponent();
            OnClose=btnOnClose;
            SetupDataGridViews();
            //LoadData();
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

            // Khởi tạo danh sách sản phẩm được thêm
            listSPDuocThem = new BindingList<SanPhamDTO>();
        }

        //        private Image LoadImageSafe(string relativePath)
        //        {
        //            try
        //            {
        //                if (string.IsNullOrEmpty(relativePath))
        //                {
        //                    // Trả về ảnh mặc định nếu không có đường dẫn
        //                    return CreateEmptyImage();
        //                }

        //                string path = Path.Combine(Application.StartupPath, relativePath.Replace("/", "\\"));

        //                if (!File.Exists(path))
        //                {
        //                    // Thử tìm theo đường dẫn khác
        //                    string alt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", relativePath.Replace("/", "\\"));
        //                    alt = Path.GetFullPath(alt);
        //                    if (File.Exists(alt))
        //                    {
        //                        path = alt;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine($"File không tồn tại: {path}");
        //                        return CreateEmptyImage();
        //                    }
        //                }

        //                byte[] bytes = File.ReadAllBytes(path);
        //                using (var ms = new MemoryStream(bytes))
        //                {
        //                    return Image.FromStream(ms);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Lỗi khi tải ảnh {relativePath}: {ex.Message}");
        //                return CreateEmptyImage();
        //            }
        //        }

        //        private Image CreateEmptyImage()
        //        {
        //            // Tạo ảnh trống màu trắng
        //            Bitmap emptyImage = new Bitmap(50, 50);
        //            using (Graphics g = Graphics.FromImage(emptyImage))
        //            {
        //                g.Clear(Color.White);
        //            }
        //            return emptyImage;
        //        }

        //        private void LoadData()
        //        {
        //            listSP = spBUS.getListSP();
        //            listKH = khBUS.getListKH();
        //            boxMaPhieu.Text = pxBUS.getAutoMaPhieuXuat().ToString();
        //            // Lấy tên nhân viên từ frmMain.CurrentUser
        //            try
        //            {
        //                TaiKhoanDTO currentUser = frmMain.CurrentUser;

        //                if (currentUser != null)
        //                {
        //                    int maNV = currentUser.Manv;
        //                    string tenNV = nvBUS.getNamebyID(maNV);
        //                    boxNVxuat.Text = !string.IsNullOrEmpty(tenNV) ? tenNV : "Không tìm thấy nhân viên";
        //                }
        //                else
        //                {
        //                    boxNVxuat.Text = "Chưa đăng nhập";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                boxNVxuat.Text = "Lỗi: " + ex.Message;
        //            }
        //            LoadKhachHang();
        //            LoadSPTrongKho();
        //            LoadSPDuocThem();
        //        }

        //        private void LoadKhachHang()
        //        {
        //            comboBoxKH.Items.Clear();

        //            if (listKH != null && listKH.Count > 0)
        //            {
        //                foreach (KhachHangDTO kh in listKH)
        //                {
        //                    comboBoxKH.Items.Add(kh.Tenkhachhang);
        //                }
        //            }

        //            if (comboBoxKH.Items.Count > 0)
        //            {
        //                comboBoxKH.SelectedIndex = 0;
        //            }
        //        }

        //        private void LoadSPTrongKho()
        //        {
        //            dgvSPtrongKho.Columns.Clear();
        //            dgvSPtrongKho.Rows.Clear();

        //            dgvSPtrongKho.Columns.Add("MaSP", "Mã SP");
        //            dgvSPtrongKho.Columns.Add("TenSP", "Tên sản phẩm");

        //            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
        //            imgCol.Name = "HinhAnh";
        //            imgCol.HeaderText = "Ảnh";
        //            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
        //            dgvSPtrongKho.Columns.Add(imgCol);

        //            dgvSPtrongKho.Columns.Add("DonGia", "Đơn giá");
        //            dgvSPtrongKho.Columns.Add("SoLuong", "Số lượng");

        //            foreach (DataGridViewColumn column in dgvSPtrongKho.Columns)
        //            {
        //                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            }

        //            dgvSPtrongKho.Columns["MaSP"].FillWeight = 10;      // 10%
        //            dgvSPtrongKho.Columns["TenSP"].FillWeight = 40;     // 40%
        //            dgvSPtrongKho.Columns["HinhAnh"].FillWeight = 15;   // 15%
        //            dgvSPtrongKho.Columns["DonGia"].FillWeight = 20;    // 20%
        //            dgvSPtrongKho.Columns["SoLuong"].FillWeight = 15;   // 15%

        //            dgvSPtrongKho.RowTemplate.Height = 40; // set height

        //            // Thêm dữ liệu
        //            if (listSP != null && listSP.Count > 0)
        //            {
        //                foreach (SanPhamDTO sp in listSP)
        //                {
        //                    Image productImage = LoadImageSafe(sp.Hinhanh);
        //                    dgvSPtrongKho.Rows.Add(
        //                        sp.Masp,
        //                        sp.Tensp,
        //                        productImage,
        //                        sp.Dongia,
        //                        sp.Soluong
        //                    );
        //                }
        //            }

        //            dgvSPtrongKho.ClearSelection();
        //        }

        //        private void LoadSPDuocThem()
        //        {
        //            dgvSPduocThem.Columns.Clear();
        //            dgvSPduocThem.Rows.Clear();

        //            dgvSPduocThem.Columns.Add("STT", "STT");
        //            dgvSPduocThem.Columns.Add("MaSP", "Mã SP");
        //            dgvSPduocThem.Columns.Add("TenSP", "Tên sản phẩm");
        //            dgvSPduocThem.Columns.Add("DonGia", "Đơn giá");
        //            dgvSPduocThem.Columns.Add("SoLuong", "Số lượng");
        //            dgvSPduocThem.Columns.Add("ThanhTien", "Thành tiền");

        //            foreach (DataGridViewColumn column in dgvSPduocThem.Columns)
        //            {
        //                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            }

        //            dgvSPduocThem.Columns["STT"].FillWeight = 8;        // 8%
        //            dgvSPduocThem.Columns["MaSP"].FillWeight = 12;      // 12%
        //            dgvSPduocThem.Columns["TenSP"].FillWeight = 35;     // 35%
        //            dgvSPduocThem.Columns["DonGia"].FillWeight = 15;    // 15%
        //            dgvSPduocThem.Columns["SoLuong"].FillWeight = 15;   // 15%
        //            dgvSPduocThem.Columns["ThanhTien"].FillWeight = 15; // 15%

        //            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
        //            {
        //                int stt = 1;
        //                foreach (SanPhamDTO sp in listSPDuocThem)
        //                {
        //                    decimal thanhTien = sp.Dongia * sp.Soluong;
        //                    dgvSPduocThem.Rows.Add(
        //                        stt++,
        //                        sp.Masp,
        //                        sp.Tensp,
        //                        sp.Dongia,
        //                        sp.Soluong,
        //                        $"{thanhTien:N0}đ"
        //                    );
        //                }
        //            }

        //            dgvSPduocThem.ClearSelection();
        //            UpdateTongTien();
        //            UpdateButtonStates();
        //        }

        //        private void UpdateTongTien()
        //        {
        //            decimal tongTien = 0;
        //            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
        //            {
        //                foreach (SanPhamDTO sp in listSPDuocThem)
        //                {
        //                    tongTien += sp.Dongia * sp.Soluong;
        //                }
        //            }
        //            labelPrice.Text = $"{tongTien:N0}đ";
        //        }

        //        private void UpdateButtonStates()
        //        {
        //            // Chỉ enable nút Sửa và Xóa khi có sản phẩm trong danh sách được thêm
        //            bool hasProducts = listSPDuocThem != null && listSPDuocThem.Count > 0;
        //            buttonSuaSP.Enabled = hasProducts;
        //            buttonXoaSP.Enabled = hasProducts;
        //        }

        //        private void txSearch_TextChanged(object sender, EventArgs e)
        //        {
        //            string searchString = txSearch.Text.Trim();

        //            if (string.IsNullOrEmpty(searchString))
        //            {
        //                LoadSPTrongKho();
        //                return;
        //            }

        //            // Tìm kiếm theo mã hoặc tên sản phẩm
        //            var filteredList = listSP.Where(sp =>
        //                sp.Masp.ToString().Contains(searchString) ||
        //                sp.Tensp.ToLower().Contains(searchString.ToLower())
        //            ).ToList();

        //            dgvSPtrongKho.Rows.Clear();

        //            if (filteredList.Count > 0)
        //            {
        //                foreach (SanPhamDTO sp in filteredList)
        //                {
        //                    Image productImage = LoadImageSafe(sp.Hinhanh);
        //                    dgvSPtrongKho.Rows.Add(
        //                        sp.Masp,
        //                        sp.Tensp,
        //                        productImage,
        //                        sp.Dongia,
        //                        sp.Soluong
        //                    );
        //                }
        //            }

        //            dgvSPtrongKho.ClearSelection();
        //        }

        //        private void buttonThemSP_Click(object sender, EventArgs e)
        //        {
        //            if (dgvSPtrongKho.SelectedRows.Count > 0)
        //            {
        //                DataGridViewRow selectedRow = dgvSPtrongKho.SelectedRows[0];
        //                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());

        //                // Tìm sản phẩm trong danh sách
        //                SanPhamDTO spToAdd = listSP.FirstOrDefault(sp => sp.Masp == maSP);

        //                if (spToAdd != null)
        //                {
        //                    if (spToAdd.Soluong <= 0)
        //                    {
        //                        MessageBox.Show("Sản phẩm này đã hết hàng, không thể thêm!", "Thông báo",
        //                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                        return;
        //                    }

        //                    // Kiểm tra xem sản phẩm đã có trong danh sách chưa
        //                    SanPhamDTO existingSP = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);

        //                    // Hiển thị form nhập số lượng
        //                    using (var inputForm = new InputQuantityForm())
        //                    {
        //                        // Nếu sản phẩm đã có trong danh sách, hiển thị số lượng hiện tại
        //                        if (existingSP != null)
        //                        {
        //                            inputForm.Quantity = existingSP.Soluong;
        //                            inputForm.Text = "Chỉnh sửa số lượng"; // Đổi title cho rõ ràng
        //                        }
        //                        else
        //                        {
        //                            inputForm.Quantity = 1; // Mặc định là 1
        //                            inputForm.Text = "Nhập số lượng"; // Title cho trường hợp thêm mới
        //                        }

        //                        // Hiển thị form và chờ người dùng nhập
        //                        if (inputForm.ShowDialog() == DialogResult.OK)
        //                        {
        //                            int newQuantity = inputForm.Quantity;

        //                            if (newQuantity <= 0)
        //                            {
        //                                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi",
        //                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                return;
        //                            }

        //                            if (newQuantity > spToAdd.Soluong)
        //                            {
        //                                MessageBox.Show($"Số lượng không được vượt quá {spToAdd.Soluong} (trong kho)!", "Lỗi",
        //                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                                return;
        //                            }

        //                            if (existingSP != null)
        //                            {
        //                                // Nếu đã có, cập nhật số lượng
        //                                existingSP.Soluong = newQuantity;
        //                            }
        //                            else
        //                            {
        //                                // Nếu chưa có, thêm sản phẩm mới với số lượng người dùng nhập
        //                                SanPhamDTO newSP = new SanPhamDTO
        //                                {
        //                                    Masp = spToAdd.Masp,
        //                                    Tensp = spToAdd.Tensp,
        //                                    Dongia = spToAdd.Dongia,
        //                                    Soluong = newQuantity
        //                                };
        //                                listSPDuocThem.Add(newSP);
        //                            }

        //                            LoadSPDuocThem();
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Vui lòng chọn sản phẩm để thêm!", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }

        //        private void buttonSuaSP_Click(object sender, EventArgs e)
        //        {
        //            if (dgvSPduocThem.SelectedRows.Count > 0)
        //            {
        //                DataGridViewRow selectedRow = dgvSPduocThem.SelectedRows[0];
        //                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());

        //                SanPhamDTO spTrongKho = listSP.FirstOrDefault(sp => sp.Masp == maSP);
        //                SanPhamDTO spToUpdate = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);

        //                if (spTrongKho == null || spToUpdate == null) return;

        //                using (var inputForm = new InputQuantityForm())
        //                {
        //                    inputForm.Quantity = spToUpdate.Soluong;

        //                    if (inputForm.ShowDialog() == DialogResult.OK)
        //                    {
        //                        int newQuantity = inputForm.Quantity;

        //                        if (newQuantity <= 0)
        //                        {
        //                            MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi",
        //                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            return;
        //                        }

        //                        if (newQuantity > spTrongKho.Soluong)
        //                        {
        //                            MessageBox.Show($"Số lượng không được vượt quá {spTrongKho.Soluong} (trong kho)!", "Lỗi",
        //                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                            return;
        //                        }

        //                        spToUpdate.Soluong = newQuantity;
        //                        LoadSPDuocThem();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }


        //        private void buttonXoaSP_Click(object sender, EventArgs e)
        //        {
        //            if (dgvSPduocThem.SelectedRows.Count > 0)
        //            {
        //                DataGridViewRow selectedRow = dgvSPduocThem.SelectedRows[0];
        //                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());

        //                // Xác nhận xóa
        //                DialogResult result = MessageBox.Show(
        //                    "Bạn có chắc muốn xóa sản phẩm này khỏi danh sách?",
        //                    "Xác nhận xóa",
        //                    MessageBoxButtons.YesNo,
        //                    MessageBoxIcon.Question);

        //                if (result == DialogResult.Yes)
        //                {
        //                    // Xóa sản phẩm
        //                    SanPhamDTO spToRemove = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);
        //                    if (spToRemove != null)
        //                    {
        //                        listSPDuocThem.Remove(spToRemove);
        //                        LoadSPDuocThem();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo",
        //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }

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

        //        private decimal CalculateTongTien()
        //        {
        //            decimal tongTien = 0;
        //            foreach (SanPhamDTO sp in listSPDuocThem)
        //            {
        //                tongTien += sp.Dongia * sp.Soluong;
        //            }
        //            return tongTien;
        //        }
        //        private bool KiemTraSoLuongTonKho()
        //        {
        //            foreach (SanPhamDTO sp in listSPDuocThem)
        //            {
        //                SanPhamDTO spTrongKho = listSP.FirstOrDefault(s => s.Masp == sp.Masp);
        //                if (spTrongKho == null)
        //                {
        //                    MessageBox.Show($"Sản phẩm mã {sp.Masp} không tồn tại trong kho!", "Lỗi",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }

        //                if (sp.Soluong > spTrongKho.Soluong)
        //                {
        //                    MessageBox.Show($"Số lượng sản phẩm {sp.Tensp} vượt quá tồn kho! " +
        //                                  $"Tồn kho: {spTrongKho.Soluong}, Yêu cầu: {sp.Soluong}", "Lỗi",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //            return true;
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

        private void txSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void artanButton5_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke(); // Thực hiện delegate
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        //        private void dgvSPduocThem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //        }

        //        private void dgvSPtrongKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //        }

        //        private void linkNewKH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //        {
        //            AddKhachHangForm addKHForm = new AddKhachHangForm();
        //            DialogResult result = addKHForm.ShowDialog();

        //            if (result == DialogResult.OK)
        //            {
        //                ReloadKhachHang();
        //                AutoSelectNewKhachHang();
        //            }
        //        }

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

        //        private void boxMaPhieu_TextChanged(object sender, EventArgs e)
        //        {

        //        }

        //        private void comboBoxKH_SelectedIndexChanged(object sender, EventArgs e)
        //        {

        //        }
        //    }

        //    // Form phụ để nhập số lượng
        //    public class InputQuantityForm : Form
        //    {
        //        private NumericUpDown numericUpDown;
        //        private Button btnOK;
        //        private Button btnCancel;

        //        public int Quantity { get; set; }

        //        public InputQuantityForm()
        //        {
        //            InitializeComponent();
        //        }

        //        private void InitializeComponent()
        //        {
        //            this.Text = "Chỉnh sửa số lượng";
        //            this.Size = new Size(350, 180);
        //            this.StartPosition = FormStartPosition.CenterParent;
        //            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        //            this.MaximizeBox = false;
        //            this.MinimizeBox = false;

        //            // Tạo controls với kích thước lớn hơn
        //            var label = new Label()
        //            {
        //                Text = "Nhập số lượng:",
        //                Location = new Point(20, 20),
        //                Size = new Size(300, 25),
        //                Font = new Font("Microsoft Sans Serif", 12F),
        //                TextAlign = ContentAlignment.MiddleLeft
        //            };

        //            numericUpDown = new NumericUpDown()
        //            {
        //                Location = new Point(20, 50),
        //                Size = new Size(300, 35),
        //                Minimum = 1,
        //                Maximum = 100000,
        //                Value = 1,
        //                Font = new Font("Microsoft Sans Serif", 12F),
        //                TextAlign = HorizontalAlignment.Center
        //            };

        //            btnOK = new Button()
        //            {
        //                Text = "OK",
        //                Location = new Point(20, 100),
        //                Size = new Size(140, 35),
        //                DialogResult = DialogResult.OK,
        //                Font = new Font("Microsoft Sans Serif", 11F)
        //            };

        //            btnCancel = new Button()
        //            {
        //                Text = "Cancel",
        //                Location = new Point(180, 100),
        //                Size = new Size(140, 35),
        //                DialogResult = DialogResult.Cancel,
        //                Font = new Font("Microsoft Sans Serif", 11F)
        //            };

        //            this.Controls.AddRange(new Control[] { label, numericUpDown, btnOK, btnCancel });

        //            btnOK.Click += (s, e) => { Quantity = (int)numericUpDown.Value; };
        //            this.AcceptButton = btnOK;
        //            this.CancelButton = btnCancel;

        //            this.Shown += (s, e) =>
        //            {
        //                numericUpDown.Select();
        //                numericUpDown.Select(0, numericUpDown.Text.Length);
        //            };
        //        }
    }
}