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

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class DetailPhieuNhapForm : Form
    {
        private PhieuNhapDTO _phieuNhap;
        private PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private ChiTietPhieuNhapBUS _chiTietPhieuNhapBUS = new ChiTietPhieuNhapBUS();
        private NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        // Constructor nhận tham số PhieuNhapDTO
        public DetailPhieuNhapForm(PhieuNhapDTO phieuNhap)
        {
            InitializeComponent();
            _phieuNhap = phieuNhap;
            LoadDataToForm();
            LoadChiTietPhieuNhap();
        }

        public DetailPhieuNhapForm()
        {
            InitializeComponent();
        }

        private void LoadDataToForm()
        {
            if (_phieuNhap != null)
            {
                // Hiển thị thông tin cơ bản của phiếu nhập
                textBox1.Text = _phieuNhap.Maphieu.ToString();
                textBox2.Text = _nhanVienBUS.getNamebyID(_phieuNhap.Manv);
                textBox3.Text = _nhaCungCapBUS.getNamebyID(_phieuNhap.Mancc);
                textBox4.Text = _phieuNhap.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void LoadChiTietPhieuNhap()
        {
            if (_phieuNhap != null)
            {
                // Lấy danh sách chi tiết phiếu nhập
                var chiTietPhieuNhap = _chiTietPhieuNhapBUS.getChiTietByMaPhieuNhap(_phieuNhap.Maphieu);

                // Cấu hình DataGridView
                SetupDataGridView();

                // Hiển thị dữ liệu
                DisplayChiTietPhieuNhap(chiTietPhieuNhap);
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

            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvXemChiTiet.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["TenSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dgvXemChiTiet.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvXemChiTiet.Columns["STT"].FillWeight = 8;
            dgvXemChiTiet.Columns["MaSP"].FillWeight = 12;
            dgvXemChiTiet.Columns["TenSP"].FillWeight = 35;
            dgvXemChiTiet.Columns["SoLuong"].FillWeight = 15;
            dgvXemChiTiet.Columns["DonGia"].FillWeight = 15;
            dgvXemChiTiet.Columns["ThanhTien"].FillWeight = 15;

            dgvXemChiTiet.ReadOnly = true;
            dgvXemChiTiet.AllowUserToAddRows = false;
            dgvXemChiTiet.AllowUserToDeleteRows = false;
            dgvXemChiTiet.RowHeadersVisible = false;
            dgvXemChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXemChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisplayChiTietPhieuNhap(BindingList<ChiTietPhieuNhapDTO> chiTietList)
        {
            dgvXemChiTiet.Rows.Clear();

            if (chiTietList != null && chiTietList.Count > 0)
            {
                int stt = 1;

                foreach (var chiTiet in chiTietList)
                {
                    // Lấy tên sản phẩm bằng getNamebyID
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
                MessageBox.Show("Không có chi tiết phiếu nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DetailPhieuNhapForm_Load(object sender, EventArgs e)
        {
        }
    }
}