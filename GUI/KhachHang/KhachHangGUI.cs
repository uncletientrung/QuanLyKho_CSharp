using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class KhachHangGUI : Form
    {
        private KhachHangBUS khBUS = new KhachHangBUS();
        private BindingList<KhachHangDTO> listKH;
        public KhachHangGUI()
        {
            InitializeComponent();
            InitializeComponent();
            khSearch.Text = "Nhập mã, tên hoặc số điện thoại nhân viên để tìm";
            khSearch.ForeColor = Color.Gray;
            DGVKhachHang.ClearSelection();
            DGVKhachHang.RowHeadersVisible = false; // Tắt cột header
            DGVKhachHang.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhachHang.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhachHang.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhachHang.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhachHang.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            listKH = khBUS.getListKH();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbFormName_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (khSearch.Text != "Nhập mã, tên hoặc số điện thoại khách hàng để tìm")
            {
                string search_Text = khSearch.Text.Trim();
                BindingList<KhachHangDTO> listSearch = khBUS.SearchKhachHang(search_Text);
                refreshDataGridView(listSearch);
            }
        }

        private void refreshDataGridView(BindingList<KhachHangDTO> listRefresh) // Tải lại DataGridView
        {
            DGVKhachHang.Rows.Clear();

            foreach (KhachHangDTO kh in listRefresh)
            {
                if (kh.Trangthai == 1) // chỉ hiện khách hàng đang hoạt động
                {
                    string trangThai = "Hoạt động";
                    DGVKhachHang.Rows.Add(
                        kh.Makh,
                        kh.Tenkhachhang,
                        kh.Email,
                        kh.Sdt,
                        kh.Ngaysinh.ToString("dd/MM/yyyy"),
                        trangThai
                    );
                }
            }
            DGVKhachHang.ClearSelection();
        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            DGVKhachHang.Columns.Add("MaKH", "Mã khách hàng");
            DGVKhachHang.Columns["MaKH"].Width = 120;

            DGVKhachHang.Columns.Add("TenKH", "Họ và Tên");
            DGVKhachHang.Columns["TenKH"].Width = 250;

            DGVKhachHang.Columns.Add("Email", "Email");
            DGVKhachHang.Columns["Email"].Width = 200;

            DGVKhachHang.Columns.Add("SDT", "Số điện thoại");
            DGVKhachHang.Columns["SDT"].Width = 200;

            DGVKhachHang.Columns.Add("NgaySinh", "Ngày sinh");
            DGVKhachHang.Columns["NgaySinh"].Width = 140;

            DGVKhachHang.Columns.Add("TrangThai", "Trạng thái");
            DGVKhachHang.Columns["TrangThai"].Width = 153;

            DGVKhachHang.RowTemplate.Height = 40;

            // Đổ dữ liệu từ listKH (BUS)
            foreach (KhachHangDTO kh in listKH)
            {
                if (kh.Trangthai == 1)
                {
                    string trangThai = "Hoạt động";
                    DGVKhachHang.Rows.Add(
                        kh.Makh,
                        kh.Tenkhachhang,
                        kh.Email,
                        kh.Sdt,
                        kh.Ngaysinh.ToString("dd/MM/yyyy"),
                        trangThai
                    );
                }
            }

            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác"; // Tên cột
            btn.Name = "Actions";        // Đặt tên để truy xuất
            btn.Text = "Xem";            // Text hiển thị trên nút
            btn.UseColumnTextForButtonValue = true;
            DGVKhachHang.Columns.Add(btn);
            DGVKhachHang.Columns["Actions"].Width = 150;

        }

        private void DGVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
