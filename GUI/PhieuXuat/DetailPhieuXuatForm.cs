using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.PhieuXuat
{
    public partial class DetailPhieuXuatForm : Form
    {
        private PhieuXuatDTO _phieuXuat;
        private PhieuXuatBUS _phieuXuatBUS = new PhieuXuatBUS();
        private ChiTietPhieuXuatBUS _chiTietPhieuXuatBUS = new ChiTietPhieuXuatBUS();
        private KhachHangBUS _khachHangBUS = new KhachHangBUS();
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        // Constructor nhận tham số PhieuXuatDTO
        public DetailPhieuXuatForm(PhieuXuatDTO phieuXuat)
        {
            InitializeComponent();
            _phieuXuat = phieuXuat;
            LoadDataToForm();
            LoadChiTietPhieuXuat();
        }

        public DetailPhieuXuatForm()
        {
            InitializeComponent();
        }

        private void LoadDataToForm()
        {
            if (_phieuXuat != null)
            {
                // Hiển thị thông tin cơ bản của phiếu xuất
                textBox1.Text = _phieuXuat.Maphieu.ToString();
                textBox2.Text = _nhanVienBUS.getNamebyID(_phieuXuat.Manv);
                textBox3.Text = GetTenKhachHang(_phieuXuat.Makh);
                textBox4.Text = _phieuXuat.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void LoadChiTietPhieuXuat()
        {
            if (_phieuXuat != null)
            {
                // Lấy danh sách chi tiết phiếu xuất
                var chiTietPhieuXuat = _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_phieuXuat.Maphieu);

                // Cấu hình DataGridView
                SetupDataGridView();

                // Hiển thị dữ liệu
                DisplayChiTietPhieuXuat(chiTietPhieuXuat);
            }
        }

        private void SetupDataGridView()
        {
            dgvXemChiTiet.Columns.Clear();
            dgvXemChiTiet.Rows.Clear();
            dgvXemChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvXemChiTiet.Columns.Add("STT", "STT");
            dgvXemChiTiet.Columns.Add("MaSP", "Mã SP");
            dgvXemChiTiet.Columns.Add("TenSP", "Tên sản phẩm");
            dgvXemChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvXemChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvXemChiTiet.Columns.Add("ThanhTien", "Thành tiền");

            // Căn giữa nội dung các ô
            dgvXemChiTiet.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["TenSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Định dạng số
            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            foreach (DataGridViewColumn column in dgvXemChiTiet.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Tỷ lệ cột
            dgvXemChiTiet.Columns["STT"].FillWeight = 8;
            dgvXemChiTiet.Columns["MaSP"].FillWeight = 12;
            dgvXemChiTiet.Columns["TenSP"].FillWeight = 35;
            dgvXemChiTiet.Columns["SoLuong"].FillWeight = 15;
            dgvXemChiTiet.Columns["DonGia"].FillWeight = 15;
            dgvXemChiTiet.Columns["ThanhTien"].FillWeight = 15;

            // Cấu hình khác
            dgvXemChiTiet.ReadOnly = true;
            dgvXemChiTiet.AllowUserToAddRows = false;
            dgvXemChiTiet.AllowUserToDeleteRows = false;
            dgvXemChiTiet.RowHeadersVisible = false;
            dgvXemChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXemChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisplayChiTietPhieuXuat(BindingList<ChiTietPhieuXuatDTO> chiTietList)
        {
            dgvXemChiTiet.Rows.Clear();

            if (chiTietList != null && chiTietList.Count > 0)
            {
                int stt = 1;

                foreach (var chiTiet in chiTietList)
                {
                    string tenSanPham = _sanPhamBUS.getNamebyID(chiTiet.Masp);
                    decimal thanhTien = chiTiet.Soluong * chiTiet.Dongia;

                    dgvXemChiTiet.Rows.Add(
                        stt++,
                        chiTiet.Masp,
                        tenSanPham,
                        chiTiet.Soluong,
                        chiTiet.Dongia,
                        thanhTien
                    );
                }
            }
            else
            {
                MessageBox.Show("Không có chi tiết phiếu xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetTenKhachHang(int maKH)
        {
            try
            {
                return _khachHangBUS.getNamebyID(maKH);
            }
            catch (Exception)
            {
                return "Không tìm thấy";
            }
        }

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXuatFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất file sẽ được triển khai sau!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DetailPhieuXuatForm_Load(object sender, EventArgs e)
        {
        }
    }
}