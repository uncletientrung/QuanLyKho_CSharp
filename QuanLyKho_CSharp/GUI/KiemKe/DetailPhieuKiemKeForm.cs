using QuanLyKho.BUS;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class DetailPhieuKiemKeForm : Form
    {
        private PhieuKiemKeDTO _phieuKiem;
        private PhieuKiemKeBUS _phieuKiemKeBUS = new PhieuKiemKeBUS();
        private NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        public DetailPhieuKiemKeForm(PhieuKiemKeDTO phieuKiem)
        {
            InitializeComponent();
            _phieuKiem = phieuKiem;
            LoadDataToForm();
            LoadChiTietPhieuKiem();
        }

        private void LoadDataToForm()
        {
            if (_phieuKiem != null)
            {
                textBox1.Text = _phieuKiem.Maphieukiemke.ToString();                    // Mã phiếu kiểm
                textBox2.Text = _phieuKiem.Trangthai;                                   // Trạng thái
                textBox3.Text = _phieuKiem.Ghichu;                                      // Ghi chú
                textBox4.Text = _phieuKiem.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss"); // Thời gian tạo phiếu
            }
        }

        private void LoadChiTietPhieuKiem()
        {
            //if (_phieuKiem != null)
            //{
            //    // Sử dụng phương thức GetById để lấy chi tiết phiếu kiểm kê
            //    var chiTietPhieuKiemKe = new BindingList<PhieuKiemKeDTO>();
            //    var phieu = _phieuKiemKeBUS.GetById(_phieuKiem.Maphieukiemke);
            //    if (phieu != null)
            //    {
            //        chiTietPhieuKiemKe.Add(phieu);
            //    }
            //    // Cấu hình DataGridView
            //    SetupDataGridView();
            //    // Hiển thị dữ liệu
            //    DisplayChiTietPhieuKiemKe(chiTietPhieuKiemKe);
            //}
        }
        private void SetupDataGridView()
        {
            dgvXemChiTiet.Columns.Clear();
            dgvXemChiTiet.Rows.Clear();
            dgvXemChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvXemChiTiet.Columns.Add("TenNVTao", "Tên nhân viên tạo");
            dgvXemChiTiet.Columns.Add("MaNVTao", "Mã nhân viên tạo");
            dgvXemChiTiet.Columns.Add("TenNVKiem", "Tên nhân viên kiểm");
            dgvXemChiTiet.Columns.Add("MaNVKiem", "Mã nhân viên kiểm");
            dgvXemChiTiet.Columns.Add("TenKhuVuc", "Tên khu vực");
            dgvXemChiTiet.Columns.Add("MaKhuVuc", "Mã khu vực");

            foreach (DataGridViewColumn column in dgvXemChiTiet.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvXemChiTiet.ReadOnly = true;
            dgvXemChiTiet.AllowUserToAddRows = false;
            dgvXemChiTiet.AllowUserToDeleteRows = false;
            dgvXemChiTiet.RowHeadersVisible = false;
            dgvXemChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXemChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void DisplayChiTietPhieuKiemKe(BindingList<PhieuKiemKeDTO> chiTietList)
        {
            //dgvXemChiTiet.Rows.Clear();

            //if (chiTietList != null && chiTietList.Count > 0)
            //{
            //    foreach (var chiTiet in chiTietList)
            //    {
            //        dgvXemChiTiet.Rows.Add(
            //            chiTiet.TenNhanVienTao,
            //            chiTiet.Manhanvientao,
            //            chiTiet.TenNhanVienKiem,
            //            chiTiet.Manhanvienkiem,
            //            chiTiet.TenKho,
            //            chiTiet.Makhuvuc
            //        );
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Không có chi tiết phiếu kiểm kê!", "Thông báo",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }






        // buttton footer
        // excel
        private void buttonXuatFile_Click(object sender, EventArgs e)
        {

        }
        // cancel - OK
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        // readonly
        private void dgvXemChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e) {}
    }
}
