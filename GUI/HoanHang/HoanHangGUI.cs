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
            buttonHuyBo.Click += buttonHuyBo_Click_1;
        }

        public HoanHang(int maPhieuXuat)
        {
            InitializeComponent();
            buttonHuyBo.Click += buttonHuyBo_Click_1;
            _maPhieuXuat = maPhieuXuat;
            SetupDataGridView();
        }


        // 4 thông số chính của phiếu xuất
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

                textBoxSoLuongMatHang.Text = dt.Rows.Count.ToString();

                decimal tongGiaTri = 0;
                if (dt.Columns.Contains("DonGia"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (decimal.TryParse(row["DonGia"]?.ToString(), out decimal donGia) &&
                            int.TryParse(row["SoLuong"]?.ToString(), out int soLuong))
                        {
                            tongGiaTri += donGia * soLuong;
                        }
                    }
                }

                textBoxDonGia.Text = tongGiaTri.ToString("N0"); // format tiền tệ
            }
            else
            {
                textBoxSoLuongMatHang.Text = "0";
                textBoxDonGia.Text = "0";
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
            int maSP = _sanPhamBUS.getIDbyName(tenSP);

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

            // Xoá luôn phiếu xuất nếu hết sp
            var listCT = _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_maPhieuXuat);
            if (listCT == null || listCT.Count == 0)
            {
                new PhieuXuatBUS().removePhieuXuat(_maPhieuXuat);
                this.DialogResult = DialogResult.OK; // Thêm dòng này
                this.Close(); // Thêm dòng này
            }
            // Cập nhật cột tổng tiền - PhieuXuatGUI
            else
            {
                int newTotal = listCT.Sum(ct => ct.Soluong * ct.Dongia);
                var phieu = new PhieuXuatBUS().getPhieuXuatById(_maPhieuXuat);
                phieu.Tongtien = newTotal;
                new PhieuXuatBUS().updatePhieuXuat(phieu);

                // THÊM PHẦN NÀY: Cập nhật trạng thái hoàn một phần
                CapNhatTrangThaiHoanMotPhan(_maPhieuXuat);
            }
        }

        // THÊM PHƯƠNG THỨC MỚI: Cập nhật trạng thái hoàn một phần
        private void CapNhatTrangThaiHoanMotPhan(int maPhieuXuat)
        {
            try
            {
                var phieuBUS = new PhieuXuatBUS();
                var phieu = phieuBUS.getPhieuXuatById(maPhieuXuat);
                if (phieu != null && phieu.Trangthai != 3) // Chỉ cập nhật nếu chưa hoàn toàn bộ
                {
                    phieu.Trangthai = 2; // 2 = Đã hoàn một phần
                    phieuBUS.updatePhieuXuat(phieu);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật trạng thái hoàn một phần: {ex.Message}");
            }
        }











        // buttton footer
        // button hoàn tất cả
        // buttton footer
        // button hoàn tất cả
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

            try
            {
                // Cập nhật trạng thái phiếu xuất sang "Đã hoàn toàn bộ" (Trangthai = 3)
                var phieuBUS = new PhieuXuatBUS();
                var phieu = phieuBUS.getPhieuXuatById(_maPhieuXuat);
                if (phieu != null)
                {
                    phieu.Trangthai = 3; // 3 = Đã hoàn toàn bộ
                    phieuBUS.updatePhieuXuat(phieu);
                }

                // Xóa tất cả chi tiết phiếu xuất (nếu muốn xóa dữ liệu)
                // _chiTietPhieuXuatBUS.deleteChiTietPhieuXuat(_maPhieuXuat);

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

                // Đặt DialogResult để báo cho form cha biết đã cập nhật
                this.DialogResult = DialogResult.OK;

                MessageBox.Show("Đã hoàn trả tất cả sản phẩm! Phiếu xuất vẫn sẽ được lưu lại với trạng thái 'Đã hoàn toàn bộ'.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // đóng form hoàn hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hoàn trả: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // nút đóng dialog
        private void buttonHuyBo_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }









        // Thêm phương thức để xử lý khi form đóng
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Nếu người dùng đóng form bằng nút X, vẫn cập nhật trạng thái nếu đã hoàn một phần
            if (this.DialogResult != DialogResult.OK && dgvXemChiTiet.Rows.Count > 0)
            {
                var listCT = _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_maPhieuXuat);
                if (listCT != null && listCT.Count > 0 && listCT.Count < GetTongSoDongBanDau())
                {
                    CapNhatTrangThaiHoanMotPhan(_maPhieuXuat);
                }
            }
        }
        // Phương thức hỗ trợ để lấy tổng số dòng ban đầu (nếu cần)
        private int GetTongSoDongBanDau()
        {
            if (dgvXemChiTiet.DataSource is DataTable dt)
            {
                return dt.Rows.Count;
            }
            return dgvXemChiTiet.Rows.Count;
        }









        // readonly
        private void textBox1_TextChanged(object sender, EventArgs e) {}
        private void textBox1_TextChanged_1(object sender, EventArgs e) {}
        private void label1_Click(object sender, EventArgs e) {}
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {}
        private void label2_Click(object sender, EventArgs e) {}
        private void label3_Click(object sender, EventArgs e) {}
        private void label4_Click(object sender, EventArgs e) {}
        private void dgvXemChiTiet_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {}

    }
}
