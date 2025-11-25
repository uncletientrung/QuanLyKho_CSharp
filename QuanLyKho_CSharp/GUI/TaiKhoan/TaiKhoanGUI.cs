using Google.Protobuf.Collections;
using QuanLyKho.BUS;
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

namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    public partial class TaiKhoanGUI : Form
    {
        public TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private BindingList<TaiKhoanDTO> listTK;

        public TaiKhoanGUI()
        {
            InitializeComponent();
            DGVTaiKhoan.ClearSelection();
            DGVTaiKhoan.RowHeadersVisible = false; // Tắt cột header
            DGVTaiKhoan.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVTaiKhoan.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVTaiKhoan.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVTaiKhoan.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVTaiKhoan.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVTaiKhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVTaiKhoan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVTaiKhoan.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVTaiKhoan.ColumnHeadersHeight = 30;
            DGVTaiKhoan.RowHeadersDefaultCellStyle = headerStyle;
            DGVTaiKhoan.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            listTK =tkBUS.getListTK();

        }
        private void TaiKhoanGUI_Load(object sender, EventArgs e)
        {

            refreshDataGridView(tkBUS.getListTK());

        }

        private void DGVTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

       

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTaiKhoanForm addTK = new AddTaiKhoanForm();
            addTK.ShowDialog();

            if(addTK.DialogResult == DialogResult.OK)
            {
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
                refreshDataGridView(tkBUS.getListTK());
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AddSuccessNotification tb = new AddSuccessNotification();
            tb.Show();
            refreshDataGridView(tkBUS.getListTK());
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            
            string TextSearch=txSearch.Text.Trim();
            BindingList<TaiKhoanDTO> listSearch=tkBUS.SearchTaiKhoan(TextSearch);
            refreshDataGridView(listSearch);
        }
        private void refreshDataGridView(BindingList<TaiKhoanDTO> listRefresh) // Tải lại DataGridView
        {
            int soLuongNV = 0;
            DGVTaiKhoan.Rows.Clear();
            foreach (TaiKhoanDTO tk in listRefresh.Where(tk => tk.Trangthai == 1))
            {

                DGVTaiKhoan.Rows.Add(tk.Manv, tk.Tendangnhap, tk.Matkhau,
                    tk.Manhomquyen, "Hoạt động");
                soLuongNV++;
            }
            lbTotal.Text = "Tổng số tài khoản: " + soLuongNV.ToString();
            DGVTaiKhoan.ClearSelection();
        }

        private void DGVTaiKhoan_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int matk = int.Parse(DGVTaiKhoan.Rows[e.RowIndex].Cells["matk"].Value.ToString());
            TaiKhoanDTO TaiKhoanDuocChon = tkBUS.getTKById(matk);
            if (DGVTaiKhoan.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailTaiKhoanForm detailTK = new DetailTaiKhoanForm(TaiKhoanDuocChon);
                detailTK.ShowDialog();
            }
            if (DGVTaiKhoan.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateTaiKhoanForm detailTK = new UpdateTaiKhoanForm(TaiKhoanDuocChon);
                detailTK.ShowDialog();
                if (detailTK.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(tkBUS.getListTK());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }
            if (DGVTaiKhoan.Columns[e.ColumnIndex].Name == "remove")
            {
                DetailTaiKhoanForm deleteTk = new DetailTaiKhoanForm(TaiKhoanDuocChon);
                deleteTk.ShowDialog();
                if (deleteTk.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(tkBUS.getListTK());
                }
            }
        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }


    }
}
