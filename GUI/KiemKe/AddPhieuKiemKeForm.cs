using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.BUS; 

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class AddPhieuKiemKeForm : Form
    {
        private readonly string SearchPlaceholder = " Tìm kiếm theo mã sản phẩm, tên sản phẩm, mã khu vực, ...";
        private readonly string TonChiNhanhPlaceholder = "1234";
        private string _userName;

        public AddPhieuKiemKeForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AddPhieuKiemKeForm_Load);
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
        }

        public AddPhieuKiemKeForm(string userName)
        {
            InitializeComponent();
            this._userName = userName;
            this.Load += new System.EventHandler(this.AddPhieuKiemKeForm_Load);
            this.buttonHuyBo.Click += new System.EventHandler(this.buttonHuyBo_Click);
        }













        // load form
        private void AddPhieuKiemKeForm_Load(object sender, EventArgs e)
        {
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

            // Lấy dữ liệu kho có trước 
            comboBoxKhuvuckho.Items.Clear();
            var khuVucList = KhuVucKhoDAO.getInstance().SelectAll();
            foreach (var kv in khuVucList)
            {
                comboBoxKhuvuckho.Items.Add($"{kv.Makhuvuc} - {kv.Tenkhuvuc}");
            }

            // Tự động điền mã phiếu kiểm kê
            int nextMaPhieu = PhieuKiemKeDAO.getInstance().GetAutoIncrement();
            boxMaPhieu.Text = nextMaPhieu.ToString();

            // Gán nhân viên tạo phiếu là tài khoản đăng nhập
            boxNVkiem.Text = _userName;
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
            DGVKiemKe.Rows.Clear();
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
            DGVKiemKe.Columns.Clear();
            DGVKiemKe.Rows.Clear();
            DGVKiemKe.RowHeadersVisible = false; // bỏ cột đầu tiên của gridview nigga
            DGVKiemKe.AllowUserToAddRows = false; // bỏ luôn dòng cuối gigigaga

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

            // 2. Lấy dữ liệu sản phẩm
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
















        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        

        

        

        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
















        // button event footer
        // xuat file
        private void buttonXuatFile_Click(object sender, EventArgs e){
            
        }
        // huy bo
        private void buttonHuyBo_Click(object sender, EventArgs e) {
            txSearch.Text = SearchPlaceholder;
            txSearch.ForeColor = Color.LightGray;

            if (boxMaPhieu != null) boxMaPhieu.Text = "";
            if (boxNVkiem != null) boxNVkiem.Text = "";
            if (textBoxTonchinhanh != null) textBoxTonchinhanh.Text = "";
            if (textBoxSoluonglech != null) textBoxSoluonglech.Text = "";
            if (textBox1 != null) textBox1.Text = "";
            if (comboBoxKhuvuckho != null) comboBoxKhuvuckho.SelectedIndex = -1;
            if (comboBox2 != null) comboBox2.SelectedIndex = -1;

            // Đóng form
            this.Close();
        }


        // readonly
        private void label1_Click(object sender, EventArgs e) {}
        private void label2_Click(object sender, EventArgs e) {}

        private void label3_Click(object sender, EventArgs e) {}
        private void label4_Click_1(object sender, EventArgs e) {}

        private void label7_Click(object sender, EventArgs e) {}
        private void label6_Click(object sender, EventArgs e) {}

        // Hàm load ảnh an toàn (bạn có thể copy từ SanPhamGUI)
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
    }
}
