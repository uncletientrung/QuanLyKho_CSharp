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
            txSearch.Text = "Nhập mã, tên hoặc số điện thoại nhân viên để tìm";
            txSearch.ForeColor = Color.Gray;
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

        private void DGVKhachHang_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void DGVKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            DGVKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động lấp đầy

            DGVKhachHang.Columns.Add("MaKH", "Mã khách hàng");
            DGVKhachHang.Columns["MaKH"].FillWeight = 10;

            DGVKhachHang.Columns.Add("TenKH", "Họ và Tên");
            DGVKhachHang.Columns["TenKH"].FillWeight = 10;

            DGVKhachHang.Columns.Add("Email", "Email");
            DGVKhachHang.Columns["Email"].FillWeight = 25;

            DGVKhachHang.Columns.Add("SDT", "Số điện thoại");
            DGVKhachHang.Columns["SDT"].FillWeight = 20;

            DGVKhachHang.Columns.Add("NgaySinh", "Ngày sinh");
            DGVKhachHang.Columns["NgaySinh"].FillWeight = 10;

            DGVKhachHang.Columns.Add("TrangThai", "Trạng thái");
            DGVKhachHang.Columns["TrangThai"].FillWeight = 10;

            DGVKhachHang.RowTemplate.Height = 40;

            foreach (KhachHangDTO kh in listKH.Where(k => k.Trangthai == 1))
            {
                DGVKhachHang.Rows.Add(
                    kh.Makh,                         
                    kh.Tenkhachhang,                     
                    kh.Email,                        
                    kh.Sdt,                          
                    kh.Ngaysinh.ToString("dd/MM/yyyy"),
                    "Hoạt động"                      
                );
            }

        }
    }
}
