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
using System.Windows.Forms.VisualStyles;

namespace QuanLyKho_CSharp.GUI.PhanQuyen
{
    public partial class NhomQuyenGUI : Form
    {
        private NhomQuyenBUS nqBUS= new NhomQuyenBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        public NhomQuyenGUI()
        {
            InitializeComponent();
            txSearch.Text = "Nhập mã, tên đăng nhập tài khoản để tìm";
            txSearch.ForeColor = Color.Gray;
            DGVPhanQuyen.ClearSelection();
            DGVPhanQuyen.RowHeadersVisible = false; // Tắt cột header
            DGVPhanQuyen.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVPhanQuyen.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVPhanQuyen.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVPhanQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVPhanQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVPhanQuyen.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVPhanQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVPhanQuyen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            listNQ = nqBUS.getListNQ();
            DGVPhanQuyen.Columns.Add("MaNQ", "Mã nhóm quyền");
            DGVPhanQuyen.Columns["MaNQ"].Width = 120;

            DGVPhanQuyen.Columns.Add("TenNQ", "Tên nhóm quyền");
            DGVPhanQuyen.Columns["TenNQ"].Width = 730;

            DGVPhanQuyen.Columns.Add("TrangThai", "Trạng thái");
            DGVPhanQuyen.Columns["TrangThai"].Width = 154;
            DGVPhanQuyen.RowTemplate.Height = 40;
            refreshDataGridView(listNQ);
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

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void PhanQuyenGUI_Load(object sender, EventArgs e)
        {

            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVPhanQuyen.Columns.Add(btn);
            DGVPhanQuyen.Columns["Actions"].Width = 150;
        }

        private void DGVPhanQuyen_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVPhanQuyen.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (e.CellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
                Rectangle btnSua = new Rectangle(e.CellBounds.Left + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXoa = new Rectangle(btnSua.Right + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXem = new Rectangle(btnXoa.Right + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);

                ButtonRenderer.DrawButton(e.Graphics, btnXem, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnSua, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnXoa, "", this.Font, false, PushButtonState.Normal);

                try
                {
                    Image imgSua = Image.FromFile("images\\icon\\edit.png");
                    Image imgXoa = Image.FromFile("images\\icon\\remove.png");
                    Image imgXem = Image.FromFile("images\\icon\\detail.png");

                    int targetWidth = 24;
                    int targetHeight = 24;

                    e.Graphics.DrawImage(imgSua, new Rectangle(
                        btnSua.Left + (btnSua.Width - targetWidth) / 2 + 3,
                        btnSua.Top + (btnSua.Height - targetHeight) / 2 + 3,
                        targetWidth - 5,
                        targetHeight - 5));
                    e.Graphics.DrawImage(imgXem, new Rectangle(
                        btnXem.Left + (btnXem.Width - targetWidth) / 2,
                        btnXem.Top + (btnXem.Height - targetHeight) / 2,
                        targetWidth,
                        targetHeight));
                    e.Graphics.DrawImage(imgXoa, new Rectangle(
                        btnXoa.Left + (btnXoa.Width - targetWidth) / 2,
                        btnXoa.Top + (btnXoa.Height - targetHeight) / 2,
                        targetWidth,
                        targetHeight));
                    imgXem.Dispose();
                    imgSua.Dispose();
                    imgXoa.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
                }


                e.Handled = true;
            }
        }

        private void DGVPhanQuyen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVPhanQuyen.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X; //Lấy tọa độ X của chuột trong cell
                int manhomquyen = int.Parse(DGVPhanQuyen.Rows[e.RowIndex].Cells["manhomquyen"].Value.ToString());
                NhomQuyenDTO NhomQuyenDuocChon = nqBUS.getNQById(manhomquyen);
                if (xRel < padding + buttonWidth) // kiểm tra trên tọa độ x
                {
                    //UpdateTaiKhoanForm updateNV = new UpdateTaiKhoanForm(TaiKhoanDuocChon);
                    //updateNV.ShowDialog();
                    //if (updateNV.DialogResult == DialogResult.OK)
                    //{
                    //    refreshDataGridView(tkBUS.getListTK());
                    //    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    //    tb.Show();
                    //}

                }
                else if (xRel < padding * 2 + buttonWidth * 2)
                {
                    //DeleteTaiKhoanForm deleteNV = new DeleteTaiKhoanForm(TaiKhoanDuocChon);
                    //deleteNV.ShowDialog();
                    //if (deleteNV.DialogResult == DialogResult.OK)
                    //{
                    //    refreshDataGridView(tkBUS.getListTK());
                    //    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    //    tb.Show();
                    //}
                }
                else
                {
                    //DetailTaiKhoanForm detailNV = new DetailTaiKhoanForm(TaiKhoanDuocChon);
                    //detailNV.ShowDialog();

                }

            }
        }
        private void refreshDataGridView(BindingList<NhomQuyenDTO> listRefresh) // Tải lại DataGridView
        {
            DGVPhanQuyen.Rows.Clear();


            foreach (NhomQuyenDTO nq in listRefresh)
            {
                if (nq.Trangthai == 1)
                {
                    DGVPhanQuyen.Rows.Add(nq.Manhomquyen, nq.Tennhomquyen,"Hoạt động");
                }
            }
            DGVPhanQuyen.ClearSelection();
        }

        private void DGVPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
