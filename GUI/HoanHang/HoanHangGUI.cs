using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.BUS;

namespace QuanLyKho_CSharp.GUI.HoanHang
{
    public partial class HoanHang : Form
    {
        private readonly ChiTietPhieuXuatBUS _chiTietPhieuXuatBUS = new ChiTietPhieuXuatBUS();
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private int _maPhieuXuat;

        public HoanHang(ChiTietHoanHangDTO phieuHoan)
        {
            InitializeComponent();
        }

        public HoanHang(int maPhieuXuat)
        {
            InitializeComponent();
            _maPhieuXuat = maPhieuXuat;
            SetupDataGridView();
        }

        public HoanHang(int maPhieu, string tenKH, int someValue, decimal tongTien, DataTable dt)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;

            _maPhieuXuat = maPhieu;

            textBoxMaPhieuXuat.Text = maPhieu.ToString();
            textBoxTenKhachHang.Text = tenKH;

            SetupDataGridView();

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvXemChiTiet.DataSource = dt;
            }
        }


        public HoanHang(string maPhieu, string tenKH, string maSP, string donGia)
        {
            InitializeComponent();
            textBoxMaPhieuXuat.Text = maPhieu;
            textBoxTenKhachHang.Text = tenKH;
            textBoxSoLuongMatHang.Text = maSP;
            textBoxDonGia.Text = donGia;
        }

        public HoanHang(int maPhieu, string tenKH, string maSP, decimal donGia)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;

            textBoxMaPhieuXuat.Text = maPhieu.ToString();
            textBoxTenKhachHang.Text = tenKH;
            textBoxSoLuongMatHang.Text = maSP;
            textBoxDonGia.Text = donGia.ToString("N0");
        }



        private void SetupDataGridView()
        {
            dgvXemChiTiet.Columns.Clear();
            dgvXemChiTiet.AutoGenerateColumns = false;
            dgvXemChiTiet.RowHeadersVisible = false;
            dgvXemChiTiet.AllowUserToAddRows = false;
            dgvXemChiTiet.ReadOnly = true;

            dgvXemChiTiet.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "TenSP",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "TenSP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvXemChiTiet.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Width = 100
            });

            DataGridViewButtonColumn btnHoanTra = new DataGridViewButtonColumn()
            {
                Name = "btnHoanTra",
                HeaderText = "Hoàn trả",
                Text = "Hoàn trả",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvXemChiTiet.Columns.Add(btnHoanTra);

            dgvXemChiTiet.CellContentClick += dgvXemChiTiet_CellContentClick;
        }



        // sử lý logic click hoàn từng sản phẩm
        private bool _isHandlingClick = false; // thêm biến này ở đầu class
        private void dgvXemChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvXemChiTiet.Columns["btnHoanTra"].Index)
                return;

            string tenSP = dgvXemChiTiet.Rows[e.RowIndex].Cells["TenSP"].Value?.ToString();
            int soLuong = Convert.ToInt32(dgvXemChiTiet.Rows[e.RowIndex].Cells["SoLuong"].Value);

            // Tìm mã sản phẩm để cập nhật DB
            int maSP = _sanPhamBUS.getIDbyName(tenSP); // bạn cần có hàm này trong SanPhamBUS

            // Xóa trong DB
            bool ok = _chiTietPhieuXuatBUS.deleteByMaPhieuXuatAndMaSP(_maPhieuXuat, maSP);
            if (!ok)
            {
                MessageBox.Show("Không thể hoàn trả mặt hàng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Hoàn trả mặt hàng: {tenSP} (Số lượng: {soLuong}) thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa dòng khỏi DataGridView (và DB đã cập nhật)
            if (dgvXemChiTiet.DataSource is DataTable dt)
            {
                DataRow[] found = dt.Select($"TenSP = '{tenSP.Replace("'", "''")}'");
                if (found.Length > 0)
                {
                    dt.Rows.Remove(found[0]);
                    dgvXemChiTiet.DataSource = null;
                    dgvXemChiTiet.DataSource = dt;
                }
            }
            else
            {
                dgvXemChiTiet.Rows.RemoveAt(e.RowIndex);
            }

            // Nếu sau khi xóa không còn sản phẩm nào thì xóa luôn phiếu xuất
            var listCT = _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_maPhieuXuat);
            if (listCT == null || listCT.Count == 0)
            {
                new PhieuXuatBUS().removePhieuXuat(_maPhieuXuat);
            }
        }











        // buttton footer
        private void buttonHoanAll_Click(object sender, EventArgs e)
        {
            if (dgvXemChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không còn sản phẩm nào để hoàn trả.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hoàn trả tất cả sản phẩm không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // Xóa toàn bộ chi tiết phiếu xuất trong DB
            _chiTietPhieuXuatBUS.deleteChiTietPhieuXuat(_maPhieuXuat);

            // Xóa luôn phiếu xuất trong DB
            new PhieuXuatBUS().removePhieuXuat(_maPhieuXuat);

            // Làm trống bảng hiển thị
            if (dgvXemChiTiet.DataSource is DataTable dt)
            {
                dt.Clear();
                dgvXemChiTiet.DataSource = null;
                dgvXemChiTiet.DataSource = dt;
            }
            else
            {
                dgvXemChiTiet.Rows.Clear();
            }

            MessageBox.Show("Đã hoàn trả tất cả sản phẩm và xóa phiếu xuất!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); // đóng form hoàn hàng
        }














        // readonly
        private void textBox1_TextChanged(object sender, EventArgs e) {}

        private void textBox1_TextChanged_1(object sender, EventArgs e) {}

        private void label1_Click(object sender, EventArgs e) {}

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {}

        private void label2_Click(object sender, EventArgs e) {}

        private void label3_Click(object sender, EventArgs e) {}

        private void label4_Click(object sender, EventArgs e) {}

        
    }
}
