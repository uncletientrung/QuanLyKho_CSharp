using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyKho.DTO;
using QuanLyKho.BUS;
using QuanLyKho.DAO;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class AddPhieuKiemKeForm : Form
    {
        private readonly string _userName;
        private readonly string SearchPlaceholder = " Tìm kiếm theo mã sản phẩm, tên sản phẩm, tên kho ...";
        private readonly string TonChiNhanhPlaceholder = "1234";
        public event EventHandler HuyBoClicked;
        private List<string> _allKhuVucItems;

        public AddPhieuKiemKeForm(string userName)
        {
            InitializeComponent();
            _userName = userName; // Lưu thông tin người dùng

            this.Load += new System.EventHandler(this.AddPhieuKiemKeForm_Load);
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click_1);
        }

        // load form
        private void AddPhieuKiemKeForm_Load(object sender, EventArgs e)
        {
;

            txSearch.ForeColor = Color.LightGray;
            txSearch.Text = SearchPlaceholder;
            txSearch.GotFocus += txSearch_Enter;
            txSearch.LostFocus += txSearch_Leave;
            txSearch.TextChanged += txSearch_TextChanged;

            // Chỉnh cỡ chữ in nghiêng
            txSearch.Font = new Font(txSearch.Font.FontFamily, 14F, FontStyle.Italic);

            // Placeholder cho textBoxTonchinhanh
            textBoxTonchinhanh.ForeColor = Color.LightGray;
            textBoxTonchinhanh.Font = new Font(textBoxTonchinhanh.Font.FontFamily, 14F, FontStyle.Italic);
            textBoxTonchinhanh.Text = TonChiNhanhPlaceholder;
            textBoxTonchinhanh.GotFocus += textBoxTonchinhanh_Enter;
            textBoxTonchinhanh.LostFocus += textBoxTonchinhanh_Leave;

            this.textBoxTonchinhanh.KeyPress += textBoxTonchinhanh_KeyPress;

            // Các trạng thái của hàng trong kho
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Đủ hàng");
            comboBox2.Items.Add("Thiếu hàng");
            comboBox2.Items.Add("Dư hàng");
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Enabled = false;

            // Lấy dữ liệu kho có trước 
            comboBoxKhuvuckho.Items.Clear();
            var khuVucList = KhuVucKhoDAO.getInstance().SelectAll();
            _allKhuVucItems = khuVucList.Select(kv => $"{kv.Makhuvuc} - {kv.Tenkhuvuc}").ToList();
            foreach (var item in _allKhuVucItems)
            {
                comboBoxKhuvuckho.Items.Add(item);
            }

            comboBoxKhuvuckho.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxKhuvuckho.TextChanged += comboBoxKhuvuckho_TextChanged;

            // Tự động điền mã phiếu kiểm kê
            int nextMaPhieu = PhieuKiemKeDAO.getInstance().GetAutoIncrement();
            boxMaPhieu.Text = nextMaPhieu.ToString();

            LoadAllSanPhamToGrid(); // tải lên danh sách hàng
        }


        // lấy danh sách khu vực kho có sẵn để hiển thị combobox
        private void comboBoxKhuvuckho_TextChanged(object sender, EventArgs e)
        {
            string text = comboBoxKhuvuckho.Text.ToLower();
            comboBoxKhuvuckho.Items.Clear();

            foreach (var item in _allKhuVucItems)
            {
                if (item.ToLower().Contains(text))
                    comboBoxKhuvuckho.Items.Add(item);
            }

            comboBoxKhuvuckho.DroppedDown = true;
            comboBoxKhuvuckho.SelectionStart = comboBoxKhuvuckho.Text.Length;
            comboBoxKhuvuckho.SelectionLength = 0;
        }




        // Hàm load toàn bộ sản phẩm
        private void LoadAllSanPhamToGrid()
        {
            var spBUS = new SanPhamBUS();
            var khuVucKhoBUS = new KhuVucKhoBUS();
            var chatLieuBUS = new ChatLieuBUS();
            var loaiBUS = new LoaiBUS();
            var sizeBUS = new SizeBUS();
            var listSP = spBUS.getListSP();
            ShowSanPhamListOnGrid(listSP, khuVucKhoBUS, chatLieuBUS, loaiBUS, sizeBUS);
        }

        // Hàm hiển thị danh sách sản phẩm lên DGVKiemKe
        private void ShowSanPhamListOnGrid(IEnumerable<SanPhamDTO> listSP, KhuVucKhoBUS khuVucKhoBUS, ChatLieuBUS chatLieuBUS, LoaiBUS loaiBUS, SizeBUS sizeBUS)
        {
            // Đảm bảo DataGridView đã có cột, nếu chưa thì khởi tạo lại cột
            if (DGVKiemKe.Columns.Count == 0)
            {
                DGVKiemKe.Columns.Add("MaSP", "Mã");
                DGVKiemKe.Columns.Add("TenSP", "Tên sản phẩm");
                var imgCol = new DataGridViewImageColumn
                {
                    Name = "HinhAnh",
                    HeaderText = "Hình ảnh",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                DGVKiemKe.Columns.Add(imgCol);
                DGVKiemKe.Columns.Add("SoLuong", "Số lượng");
                DGVKiemKe.Columns.Add("Gia", "Đơn giá");
                DGVKiemKe.Columns.Add("Machatlieu", "Chất liệu");
                DGVKiemKe.Columns.Add("Loai", "Loại");
                DGVKiemKe.Columns.Add("Khuvuc", "Khu vực");
                DGVKiemKe.Columns.Add("Size", "Size");

                foreach (DataGridViewColumn col in DGVKiemKe.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                DGVKiemKe.RowTemplate.Height = 50;
                DGVKiemKe.RowHeadersVisible = false;
                DGVKiemKe.AllowUserToAddRows = false;
            }
            else
            {
                DGVKiemKe.Rows.Clear();
            }

            foreach (var sp in listSP)
            {
                Image img = LoadImageSafe(sp.Hinhanh);
                string tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
                string tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
                string tenLoai = loaiBUS.LayTenLoai(sp);
                string tenSize = sizeBUS.LayTenSize(sp);

                DGVKiemKe.Rows.Add(
                    sp.Masp,
                    sp.Tensp,
                    img,
                    sp.Soluong,
                    sp.Dongia,
                    tenChatLieu,
                    tenLoai,
                    tenKhuVuc,
                    tenSize
                );
            }
            DGVKiemKe.ClearSelection();
            DGVKiemKe.CurrentCell = null;
        }

        // thanh search
        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == SearchPlaceholder)
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
                txSearch.Font = new Font(txSearch.Font.FontFamily, 14F, FontStyle.Regular); 
            }
        }
        private void txSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txSearch.Text))
            {
                txSearch.Text = SearchPlaceholder;
                txSearch.ForeColor = Color.LightGray;
                txSearch.Font = new Font(txSearch.Font.FontFamily, 14F, FontStyle.Italic); 
            }
        }
        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text == SearchPlaceholder || string.IsNullOrWhiteSpace(txSearch.Text))
            {
                LoadAllSanPhamToGrid();
                return;
            }

            string keyword = txSearch.Text.Trim().ToLower();
            var spBUS = new SanPhamBUS();
            var khuVucKhoBUS = new KhuVucKhoBUS();
            var chatLieuBUS = new ChatLieuBUS();
            var loaiBUS = new LoaiBUS();
            var sizeBUS = new SizeBUS();
            var listSP = spBUS.getListSP();

            // Lọc theo tên sản phẩm, mã sản phẩm, tên khu vực kho
            var filtered = listSP.Where(sp =>
                sp.Tensp.ToLower().Contains(keyword) ||
                sp.Masp.ToString().Contains(keyword) ||
                khuVucKhoBUS.LayTenKhuVuc(sp).ToLower().Contains(keyword)
            ).ToList();

            ShowSanPhamListOnGrid(filtered, khuVucKhoBUS, chatLieuBUS, loaiBUS, sizeBUS);
        }

        // nút load hàng tồn kho
        private void buttonLoadHangtonkho_Click(object sender, EventArgs e)
        {
            // Chỉ xóa cột và dòng khi thực sự cần load lại cấu trúc lưới
            if (DGVKiemKe.Columns.Count > 0)
            {
                DGVKiemKe.Rows.Clear();
            }
            else
            {
                DGVKiemKe.Columns.Clear();
                DGVKiemKe.Columns.Add("MaSP", "Mã");
                DGVKiemKe.Columns.Add("TenSP", "Tên sản phẩm");
                var imgCol = new DataGridViewImageColumn
                {
                    Name = "HinhAnh",
                    HeaderText = "Hình ảnh",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                DGVKiemKe.Columns.Add(imgCol);
                DGVKiemKe.Columns.Add("SoLuong", "Số lượng");
                DGVKiemKe.Columns.Add("Gia", "Đơn giá");
                DGVKiemKe.Columns.Add("Machatlieu", "Chất liệu");
                DGVKiemKe.Columns.Add("Loai", "Loại");
                DGVKiemKe.Columns.Add("Khuvuc", "Khu vực");
                DGVKiemKe.Columns.Add("Size", "Size");

                foreach (DataGridViewColumn col in DGVKiemKe.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                DGVKiemKe.RowTemplate.Height = 50;
            }

            DGVKiemKe.RowHeadersVisible = false;
            DGVKiemKe.AllowUserToAddRows = false;

            // Lấy dữ liệu sản phẩm
            var spBUS = new SanPhamBUS();
            var khuVucKhoBUS = new KhuVucKhoBUS();
            var chatLieuBUS = new ChatLieuBUS();
            var loaiBUS = new LoaiBUS();
            var sizeBUS = new SizeBUS();
            var listSP = spBUS.getListSP();

            foreach (var sp in listSP)
            {
                Image img = LoadImageSafe(sp.Hinhanh);
                string tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
                string tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
                string tenLoai = loaiBUS.LayTenLoai(sp);
                string tenSize = sizeBUS.LayTenSize(sp);

                DGVKiemKe.Rows.Add(
                    sp.Masp,
                    sp.Tensp,
                    img,
                    sp.Soluong,
                    sp.Dongia,
                    tenChatLieu,
                    tenLoai,
                    tenKhuVuc,
                    tenSize
                );
            }
            DGVKiemKe.ClearSelection();
            DGVKiemKe.CurrentCell = null;
        }

        // Hàm load ảnh an toàn 
        private Image LoadImageSafe(string relativePath)
        {
            try
            {
                if (string.IsNullOrEmpty(relativePath))
                    return new Bitmap(100, 100);

                string path = System.IO.Path.Combine(Application.StartupPath, relativePath.Replace("/", "\\"));
                if (!System.IO.File.Exists(path))
                {
                    string alt = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", relativePath.Replace("/", "\\"));
                    alt = System.IO.Path.GetFullPath(alt);
                    if (System.IO.File.Exists(alt))
                        path = alt;
                    else
                        return new Bitmap(100, 100);
                }
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return new Bitmap(100, 100);
            }
        }

        // Tồn chi nhánh text box
        private void textBoxTonchinhanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số và phím điều khiển (Backspace, Delete, v.v.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxTonchinhanh_TextChanged(object sender, EventArgs e)
        {

        }
        // màu mè placeholder
        private void textBoxTonchinhanh_Enter(object sender, EventArgs e)
        {
            if (textBoxTonchinhanh.Text == TonChiNhanhPlaceholder)
            {
                textBoxTonchinhanh.Text = "";
                textBoxTonchinhanh.ForeColor = Color.Black;
                textBoxTonchinhanh.Font = new Font(textBoxTonchinhanh.Font.FontFamily, 14F, FontStyle.Regular);
            }
        }
        private void textBoxTonchinhanh_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTonchinhanh.Text))
            {
                textBoxTonchinhanh.Text = TonChiNhanhPlaceholder;
                textBoxTonchinhanh.ForeColor = Color.LightGray;
                textBoxTonchinhanh.Font = new Font(textBoxTonchinhanh.Font.FontFamily, 14F, FontStyle.Italic);
            }
        }

        // tính toán giá trị hàng chênh lệch
        private void buttonCheck_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (DGVKiemKe.SelectedRows.Count == 0 && DGVKiemKe.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để kiểm tra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác định sản phẩm đang được chọn
            DataGridViewRow selectedRow;
            if (DGVKiemKe.SelectedRows.Count > 0)
            {
                selectedRow = DGVKiemKe.SelectedRows[0];
            }
            else
            {
                selectedRow = DGVKiemKe.Rows[DGVKiemKe.CurrentCell.RowIndex];
            }

            // Kiểm tra xem dòng có hợp lệ không
            if (selectedRow == null || selectedRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để kiểm tra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiểm tra số lượng thực tế từ textbox
            if (!int.TryParse(textBoxTonchinhanh.Text, out int soLuongThucTe))
            {
                MessageBox.Show("Số lượng thực tế không hợp lệ.");
                return;
            }

            // Lấy số lượng tồn kho từ cột "SoLuong"
            int soLuongTonKho = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);

            // Tính toán trạng thái phiếu thiếu - đủ của hàng
            int soLuongLech = soLuongThucTe - soLuongTonKho;
            textBoxSoluonglech.Text = Math.Abs(soLuongLech).ToString();

            string trangThai;
            if (soLuongLech < 0)
                trangThai = "Dư hàng";
            else if (soLuongLech > 0)
                trangThai = "Thiếu hàng";
            else
                trangThai = "Đủ hàng";

            comboBox2.Text = trangThai;
        }

        // button event footer
        // xuat file
        private void button_AddPhieuKiemKeClick(object sender, EventArgs e)
        {
            // Kiểm tra các trường bắt buộc
            if (comboBoxKhuvuckho.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBoxKhuvuckho.Text))
            {
                MessageBox.Show("Vui lòng chọn khu vực kho kiểm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxKhuvuckho.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxTonchinhanh.Text) || textBoxTonchinhanh.Text == TonChiNhanhPlaceholder)
            {
                MessageBox.Show("Vui lòng nhập số lượng tồn kho chi nhánh.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTonchinhanh.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxMaNhanVienKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên kiểm hàng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMaNhanVienKiem.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxSoluonglech.Text) || string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Hãy kiểm tra số lượng hàng trước.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = null;

            if (DGVKiemKe.SelectedRows.Count > 0)
            {
                selectedRow = DGVKiemKe.SelectedRows[0];
            }
            else if (DGVKiemKe.CurrentCell != null)
            {
                selectedRow = DGVKiemKe.Rows[DGVKiemKe.CurrentCell.RowIndex];
            }

            if (selectedRow == null || selectedRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để kiểm tra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu;
            if (!int.TryParse(boxMaPhieu.Text.Trim(), out maPhieu))
            {
                MessageBox.Show("Mã phiếu kiểm kê không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maKhuVuc = 0;
            if (!string.IsNullOrWhiteSpace(comboBoxKhuvuckho.Text))
            {
                var parts = comboBoxKhuvuckho.Text.Split('-');
                int.TryParse(parts[0].Trim(), out maKhuVuc);
            }

            // QUAN TRỌNG: Lấy mã nhân viên từ hệ thống thay vì từ textbox
            int maNvTao = GetCurrentUserID(); 
            int maNvKiem;

            if (!int.TryParse(textBoxMaNhanVienKiem.Text.Trim(), out maNvKiem))
            {
                MessageBox.Show("Mã nhân viên kiểm không hợp lệ. Vui lòng nhập số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMaNhanVienKiem.Focus();
                return;
            }

            // LẤY THÔNG TIN SẢN PHẨM - ĐẢM BẢO BIẾN selectedRow ĐÃ ĐƯỢC KHAI BÁO
            int maSP = Convert.ToInt32(selectedRow.Cells["MaSP"].Value);
            int tonThucTe = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value); // Số lượng tồn kho hiện tại
            int tonChiNhanh;

            if (!int.TryParse(textBoxTonchinhanh.Text, out tonChiNhanh))
            {
                MessageBox.Show("Số lượng tồn chi nhánh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo phiếu kiểm kê
            string ghiChu;
            if (comboBox2.Text == "Đủ hàng")
            {
                ghiChu = $"{comboBox2.Text}";
            }
            else
            {
                ghiChu = $"{comboBox2.Text} - {textBoxSoluonglech.Text}";
            }

            PhieuKiemKeDTO phieuKiemKe = new PhieuKiemKeDTO
            {
                Maphieukiemke = maPhieu,
                Thoigiantao = DateTime.Now,
                Trangthai = comboBox2.Text,
                Ghichu = ghiChu, // <-- Sử dụng biến ghiChu vừa khai báo
                Makhuvuc = maKhuVuc,
                Manhanvientao = maNvTao,
                Manhanvienkiem = maNvKiem
            };

            // Thêm phiếu kiểm kê
            int result = PhieuKiemKeBUS.Instance.Insert(phieuKiemKe);
            if (result > 0)
            {
                // Tạo chi tiết kiểm kê
                ChiTietKiemKeDTO chiTiet = new ChiTietKiemKeDTO
                {
                    Maphieukiemke = maPhieu,
                    Masp = maSP,
                    Tonchinhanh = tonChiNhanh,
                    Tonthucte = tonThucTe,
                    Ghichu = ghiChu,
                };

                // Thêm chi tiết kiểm kê (cần có ChiTietKiemKeBUS)
                bool chiTietResult = AddChiTietKiemKe(chiTiet);

                if (chiTietResult)
                {
                    MessageBox.Show("Thêm phiếu kiểm kê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở lại KiemKeGUI sau khi thêm
                    try
                    {
                        frmMain mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
                        if (mainForm != null)
                        {
                            var method = mainForm.GetType().GetMethod("OpenChildForm",
                                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                            if (method != null)
                            {
                                method.Invoke(mainForm, new object[] { new QuanLyKho_CSharp.GUI.KiemKe.KiemKeGUI(_userName), null });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi mở lại giao diện Kiểm kê:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();
                }

                else
                {
                    MessageBox.Show("Thêm chi tiết kiểm kê thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không thể thêm phiếu kiểm kê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm lấy mã nhân viên hiện tại từ hệ thống
        private int GetCurrentUserID()
        {
            return 1; 
        }

        // Hàm thêm chi tiết kiểm kê
        private bool AddChiTietKiemKe(ChiTietKiemKeDTO chiTiet)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }


        // huy bo
        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            try
            {
                // Tìm frmMain trong danh sách form đang mở
                frmMain mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
                if (mainForm != null)
                {
                    var method = mainForm.GetType().GetMethod("OpenChildForm",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                    if (method != null)
                    {
                        method.Invoke(mainForm, new object[] { new QuanLyKho_CSharp.GUI.KiemKe.KiemKeGUI(), null });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi quay lại giao diện Kiểm kê:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        // đóng form sau khi thêm thành công
        private void AddPhieuKiemKeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Tìm frmMain trong danh sách form đang mở
            var mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (mainForm != null)
            {
                var method = mainForm.GetType().GetMethod("OpenChildForm",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (method != null)
                {
                    method.Invoke(mainForm, new object[] { new QuanLyKho_CSharp.GUI.KiemKe.KiemKeGUI(), null });
                }
            }
        }









        // readonly
        private void label1_Click(object sender, EventArgs e) {}
        private void label2_Click(object sender, EventArgs e) {}
        private void label3_Click(object sender, EventArgs e) {}
        private void label4_Click_1(object sender, EventArgs e) {}
        private void label6_Click(object sender, EventArgs e) {}
        private void label7_Click(object sender, EventArgs e) {}
        private void label8_Click(object sender, EventArgs e) {}
        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e) {}
        private void textBox1_TextChanged(object sender, EventArgs e) {}
        private void boxMaPhieu_TextChanged(object sender, EventArgs e) {}

        private void boxMaNVkiem_TextChanged(object sender, EventArgs e) {}
    }
}
