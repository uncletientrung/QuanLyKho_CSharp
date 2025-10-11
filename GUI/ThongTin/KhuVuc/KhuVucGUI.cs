using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    public partial class KhuVucGUI : Form
    {
        private KhuVucKhoBUS kvkBUS = new KhuVucKhoBUS();
        private BindingList<KhuVucKhoDTO> listKhuVuc;

        public KhuVucGUI()
        {
            InitializeComponent();

            txSearch.Text = "Nhập mã, tên hoặc số điện thoại nhà cung cấp để tìm";
            txSearch.ForeColor = Color.Gray;
            DGVKhuVuc.ClearSelection();
            DGVKhuVuc.RowHeadersVisible = false; // Tắt cột header
            DGVKhuVuc.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhuVuc.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhuVuc.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhuVuc.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhuVuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhuVuc.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhuVuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhuVuc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            
            listKhuVuc = kvkBUS.getKhuVucKhoList();
        }

        private void DGVKhuVuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVKhuVuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DGVKhuVuc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void KhuVucGUI_Load(object sender, EventArgs e)
        {
            DGVKhuVuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVKhuVuc.Columns.Add("MaKVK", "Mã");
            DGVKhuVuc.Columns["MaKVK"].FillWeight = 30;

            DGVKhuVuc.Columns.Add("TenKVK", "Tên khu vực kho");
            DGVKhuVuc.Columns["TenKVK"].FillWeight = 150;

            DGVKhuVuc.Columns.Add("DiaChiKho", "Địa chỉ kho");
            DGVKhuVuc.Columns["DiaChiKho"].FillWeight = 200;

            DGVKhuVuc.Columns.Add("SDT", "Số điện thoại");
            DGVKhuVuc.Columns["SDT"].FillWeight = 100;

            DGVKhuVuc.Columns.Add("Email", "Email");
            DGVKhuVuc.Columns["Email"].FillWeight = 150;  

            DGVKhuVuc.RowTemplate.Height = 40;

            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVKhuVuc.Columns.Add(btn);
            DGVKhuVuc.Columns["Actions"].FillWeight = 100;

            refreshDataGridView(listKhuVuc);
        }

        private void KhuVucGUI_Shown(object sender, EventArgs e)
        {

        }

        private void refreshDataGridView(BindingList<KhuVucKhoDTO> list)
        {
            DGVKhuVuc.Rows.Clear();
            foreach (KhuVucKhoDTO kvk in list)
            {
                DGVKhuVuc.Rows.Add(kvk.Makhuvuc, kvk.Tenkhuvuc, kvk.Diachi, kvk.Sdt, kvk.Email);
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã, tên hoặc số điện thoại của khu vực kho để tìm")
            {
                string keyword = txSearch.Text.Trim().ToLower();
                BindingList<KhuVucKhoDTO> listSearch = kvkBUS.SearchKho(keyword); // Sửa: dùng KhuVucKhoDTO thay vì LoaiDTO
                refreshDataGridView(listSearch);
            }
        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if(txSearch.Text == "Nhập mã, tên hoặc số điện thoại của khu vực kho để tìm")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txSearch.Text))
            {
                txSearch.Text = "Nhập mã, tên hoặc số điện thoại Khu vực kho để tìm";
                txSearch.ForeColor = Color.Gray;
            }
        }
    }
}
