using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
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

namespace QuanLyKho_CSharp.GUI
{
    public partial class NhanVienGUI : Form
    {
        
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhanVienDTO> listNV;

        public NhanVienGUI()
        {
            InitializeComponent();
            DGVNhanVien.ClearSelection();
            DGVNhanVien.RowHeadersVisible = false; // Tắt cột header
            DGVNhanVien.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVNhanVien.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVNhanVien.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVNhanVien.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVNhanVien.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVNhanVien.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVNhanVien.ColumnHeadersHeight = 30;
            DGVNhanVien.RowHeadersDefaultCellStyle = headerStyle;
            DGVNhanVien.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listNV = nvBUS.getListNV();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(nvBUS.getListNV());
        }

        private void DGVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNhanVienForm addNV = new AddNhanVienForm();
            addNV.ShowDialog();
            if(addNV.DialogResult== DialogResult.OK)
            {
                refreshDataGridView(nvBUS.getListNV());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }   
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ToastForm toast = new ToastForm("SUCCESS", "This is a Success Toast");
            toast.Show();
        }


        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string search_Text = txSearch.Text.Trim();
            BindingList<NhanVienDTO> listSearch = nvBUS.SearchNhanVien(search_Text);
            refreshDataGridView(listSearch);
        }
        private void refreshDataGridView(BindingList<NhanVienDTO> listRefresh) // Tải lại DataGridView
        {
            //Hiển thị thống kê nhân viên
            int soLuongNV = 0;
            DGVNhanVien.Rows.Clear();

            foreach (NhanVienDTO nv in listRefresh.Where(nv => nv.Trangthai == 1))
            {
                string gioiTinh = nv.Gioitinh == 1 ? "Nam" : nv.Gioitinh == 2 ? "Nữ" : "Khác";
                DGVNhanVien.Rows.Add($"NV-{nv.Manv}", nv.Tennv, gioiTinh, nv.Sdt
                , nv.Ngaysinh.ToString("dd/MM/yyyy"), "Hoạt động");
                soLuongNV++;
            }
            DGVNhanVien.ClearSelection();
            lbTotalNV.Text= "Tổng số nhân viên: "+ soLuongNV.ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int manv = int.Parse(DGVNhanVien.Rows[e.RowIndex].Cells["manv"].Value.ToString().Replace("NV-",""));
            NhanVienDTO NhanVienDuocChon = nvBUS.getNVById(manv);
            if (DGVNhanVien.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailNhanVienForm detailNV = new DetailNhanVienForm(NhanVienDuocChon);
                detailNV.ShowDialog();
            }
            if (DGVNhanVien.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateNhanVienForm updateNV = new UpdateNhanVienForm(NhanVienDuocChon);
                updateNV.ShowDialog();
                if (updateNV.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(nvBUS.getListNV());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }
            if (DGVNhanVien.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteNhanVienForm deleteNV = new DeleteNhanVienForm(NhanVienDuocChon);
                deleteNV.ShowDialog();
                if (deleteNV.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(nvBUS.getListNV());
                }
            }
        }

        private void DGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void artanButton1_Click(object sender, EventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbTotalNV_Click(object sender, EventArgs e)
        {

        }
        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            AddSuccessNotification toast = new AddSuccessNotification();
            toast.Show();
        }
    }
}
