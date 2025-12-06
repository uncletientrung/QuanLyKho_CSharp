using QuanLyKho.BUS;

using QuanLyKho.DTO;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.HoanHang
{
    public partial class HoanHang : Form
    {
        private readonly ChiTietPhieuXuatBUS _chiTietPhieuXuatBUS = new ChiTietPhieuXuatBUS();
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private readonly PhieuXuatBUS _phieuXuatBUS = new PhieuXuatBUS(); // THÊM DÒNG NÀY
        private ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private KhachHangBUS khBUS = new KhachHangBUS();
        private SanPhamBUS spBUS = new SanPhamBUS();
        private int _maPhieuXuat;
        BindingList<ChiTietPhieuXuatDTO> listCTPX;

        // 4 thông số chính của phiếu xuất
        public HoanHang(int maPhieu, string tenKH, int manv, decimal tongTien, DataTable dt)
        {
            InitializeComponent();
            listCTPX = _chiTietPhieuXuatBUS.getCTPXByMaPX(maPhieu);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = true;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            _maPhieuXuat = maPhieu;

            textBoxMaPhieuXuat.Text = maPhieu.ToString();
            textBoxTenKhachHang.Text = tenKH;
            txtGiaCu.Text = $"{tongTien:N0}đ";

            SetupDataGridView();

            refreshDataGridView(listCTPX);
            this.Shown += HoanHang_Shown; // Chặn bôi dòng đầu
        }
        private void HoanHang_Shown(object sender, EventArgs e)
        {
            dgvXemChiTiet.ClearSelection();
        }
        private void refreshDataGridView(BindingList<ChiTietPhieuXuatDTO> listRefresh) // Tải lại DataGridView
        {
            dgvXemChiTiet.Rows.Clear();
            int tienSauHoan = 0;
            foreach (ChiTietPhieuXuatDTO ctpx in listRefresh)
            {
                if (ctpx.TrangTHaiHoanHang != 0)
                {
                    string trangThai = GetTrangThaiDisplay(ctpx);
                    string tenSP = spBUS.getNamebyID(ctpx.Masp);
                    int tongtien = ctpx.Soluong * ctpx.Dongia;
                    int rowIndex = dgvXemChiTiet.Rows.Add(
                        ctpx.Masp,
                        tenSP,
                        ctpx.Soluong,
                        $"{ctpx.Dongia:N0}đ",
                        $"{tongtien:N0}đ",
                        trangThai
                    );
                    dgvXemChiTiet.Rows[rowIndex].Cells["btnHoanHang"].Value = "Hoàn hàng";
                    SetRowColor(rowIndex, ctpx);
                    if(ctpx.TrangTHaiHoanHang == 1)
                    {
                        tienSauHoan += (ctpx.Soluong * ctpx.Dongia);
                    }
                }
            }
            txGiaMoi.Text = $"{tienSauHoan:N0}đ";
            dgvXemChiTiet.ClearSelection();
        }
        private string GetTrangThaiDisplay(ChiTietPhieuXuatDTO ctpx)
        {
            switch (ctpx.TrangTHaiHoanHang)
            {
                case 1: return "Hoạt động";
                case 2: return "Đã hoàn";
                case 0: return "Đã hủy";
                default: return "Không xác định";
            }
        }
        private void SetRowColor(int rowIndex, ChiTietPhieuXuatDTO ctpx)
        {
            if (dgvXemChiTiet.Rows.Count > rowIndex)
            {
                switch (ctpx.TrangTHaiHoanHang)
                {
                    case 2:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 102);
                        dgvXemChiTiet.Rows[rowIndex].Cells["btnHoanHang"].Value = "Đã hoàn";
                        break;
                    case 1:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                    default:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }

                dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void SetupDataGridView()
        {
            dgvXemChiTiet.ClearSelection();
            dgvXemChiTiet.RowHeadersVisible = false; // Tắt cột header
            dgvXemChiTiet.AllowUserToResizeRows = false; // Chặn kéo dài row
            dgvXemChiTiet.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            dgvXemChiTiet.AllowUserToAddRows = false;      // chặn thêm dòng
            dgvXemChiTiet.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            dgvXemChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            dgvXemChiTiet.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            dgvXemChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            dgvXemChiTiet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            DataGridViewButtonColumn btnCol =
                dgvXemChiTiet.Columns["btnHoanHang"] as DataGridViewButtonColumn;
            if (btnCol != null)
            {
                btnCol.UseColumnTextForButtonValue = false;
            }
            dgvXemChiTiet.CellContentClick += dgvXemChiTiet_CellContentClick;
            dgvXemChiTiet.ClearSelection();
        }

        private void dgvXemChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;// Xử lý hoàn 1 phần
            var currentRow = dgvXemChiTiet.CurrentRow;
            if (dgvXemChiTiet.Columns[e.ColumnIndex].Name == "btnHoanHang")
            {
                if (currentRow.Cells["trangThaiHoanHang"].Value == "Hoạt động")
                {
                    int masp = int.Parse(currentRow.Cells["masp"].Value.ToString());
                    CapNhatTrangThaiHoanMotPhan(_maPhieuXuat, masp);
                    refreshDataGridView(ctpxBUS.getCTPXByMaPX(_maPhieuXuat));
                }
            }
        }

        private void CapNhatTrangThaiHoanMotPhan(int mapx, int masp)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn hoàn trả sản phẩm này không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                // Sử dụng PhieuXuatBUS để cập nhật trạng thái
                var phieu = _phieuXuatBUS.getPhieuXuatById(mapx);
                if (phieu != null)
                {
                    phieu.Trangthai = 2; // 2 = Đã hoàn một phần
                    
                    var ctpxDuocChon = listCTPX
                        .FirstOrDefault(ctpx => ctpx.Maphieuxuat == mapx && ctpx.Masp == masp);
                    if (ctpxDuocChon == null)
                    {

                        MessageBox.Show($"{mapx} - {masp} Không tìm thấy sản phẩm trong phiếu xuất!");
                        return;
                    }
                    _phieuXuatBUS.updatePhieuXuat(phieu);
                    ctpxDuocChon.TrangTHaiHoanHang = 2; // Cái này là đã hoàn
                    ctpxBUS.updateTrangThaiHoanHang(ctpxDuocChon);
                    new UpdateSuccessNotification().Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu xuất!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }

        private void buttonHoanAll_Click(object sender, EventArgs e)
        {
            if (dgvXemChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Không còn sản phẩm nào để hoàn trả.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (KiemTrHoanHetChua())
            {
                MessageBox.Show("Tất cả sản phẩm đã được hoàn.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hoàn trả tất cả sản phẩm không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                var phieu = _phieuXuatBUS.getPhieuXuatById(_maPhieuXuat);
                if (phieu != null)
                {
                    phieu.Trangthai = 3; // 3 = Đã hoàn toàn bộ
                    _phieuXuatBUS.updatePhieuXuat(phieu);
                    foreach(ChiTietPhieuXuatDTO ctpxDuocChon in listCTPX)
                    {
                        ctpxDuocChon.TrangTHaiHoanHang = 2; // Hoàn tất cả
                        ctpxBUS.updateTrangThaiHoanHang(ctpxDuocChon);
                    }
                }
                refreshDataGridView(ctpxBUS.getCTPXByMaPX(_maPhieuXuat));
                new UpdateSuccessNotification().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn trả: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // Hoàn tất cả

        // nút đóng dialog
        private void buttonHuyBo_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean KiemTrHoanHetChua()
        {
            Boolean checkHoanHetChua = true; // true là là đã hoàn hết
            foreach (ChiTietPhieuXuatDTO ctpx in ctpxBUS.getChiTietByMaPhieuXuat(_maPhieuXuat))
            {
                if (ctpx.TrangTHaiHoanHang == 1)
                {
                    checkHoanHetChua = false;
                }
            }
            return checkHoanHetChua;
        }
        private void xuLyDongDialig()
        {
            Boolean ktrHoanHetChua = KiemTrHoanHetChua();
            if (ktrHoanHetChua)
            {
                var phieu = _phieuXuatBUS.getPhieuXuatById(_maPhieuXuat);
                phieu.Trangthai = 3;
                _phieuXuatBUS.updatePhieuXuat(phieu);
            }
        } // Xử lý đóng dilog

        private void HoanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            xuLyDongDialig();
        }
        // readonly
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void dgvXemChiTiet_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

       
    }
}