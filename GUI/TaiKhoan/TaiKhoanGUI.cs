using Google.Protobuf.Collections;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
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
            txSearch.Text = "Nhập mã, tên hoặc số điện thoại nhân viên để tìm";
            txSearch.ForeColor = Color.Gray;
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
        
            listTK=tkBUS.getListTK();

        }
        private void TaiKhoanGUI_Load(object sender, EventArgs e)
        {
            DGVTaiKhoan.Columns.Add("MaNV", "Mã nhân viên");
            DGVTaiKhoan.Columns["MaNV"].Width = 120;

            DGVTaiKhoan.Columns.Add("TenDangNhap", "Tên đăng nhập");
            DGVTaiKhoan.Columns["TenDangNhap"].Width = 300;

            DGVTaiKhoan.Columns.Add("MatKhau", "Mật khẩu");
            DGVTaiKhoan.Columns["MatKhau"].Width = 220;

            DGVTaiKhoan.Columns.Add("MaNhomQuyen", "Mã nhóm quyền");
            DGVTaiKhoan.Columns["MaNhomQuyen"].Width = 210;

            DGVTaiKhoan.Columns.Add("TrangThai", "Trạng thái");
            DGVTaiKhoan.Columns["TrangThai"].Width = 154;
            DGVTaiKhoan.RowTemplate.Height = 40;

            foreach (TaiKhoanDTO tk in listTK)
            {
                if (tk.Trangthai == 1)
                {
                    DGVTaiKhoan.Rows.Add(tk.Manv, tk.Tendangnhap, tk.Matkhau,
                        tk.Manhomquyen, "Hoạt động");
                }
            }
            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVTaiKhoan.Columns.Add(btn);
            DGVTaiKhoan.Columns["Actions"].Width = 150;
        }

        private void DGVTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DGVTaiKhoan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVTaiKhoan.Columns["Actions"].Index && e.RowIndex >= 0)
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

        private void DGVTaiKhoan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVTaiKhoan.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X; //Lấy tọa độ X của chuột trong cell
                int manv = int.Parse(DGVTaiKhoan.Rows[e.RowIndex].Cells["manv"].Value.ToString());
                TaiKhoanDTO TaiKhoanDuocChon = tkBUS.getTKById(manv);
                if (xRel < padding + buttonWidth) // kiểm tra trên tọa độ x
                {
                    UpdateTaiKhoanForm updateNV = new UpdateTaiKhoanForm(TaiKhoanDuocChon);
                    updateNV.ShowDialog();
                    if (updateNV.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(tkBUS.getListTK());
                        UpdateSuccessNotification tb = new UpdateSuccessNotification();
                        tb.Show();
                    }

                }
                else if (xRel < padding * 2 + buttonWidth * 2)
                {
                    DeleteTaiKhoanForm deleteNV = new DeleteTaiKhoanForm(TaiKhoanDuocChon);
                    deleteNV.ShowDialog();
                    if (deleteNV.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(tkBUS.getListTK());
                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                    }
                }
                else
                {
                    DetailTaiKhoanForm detailNV = new DetailTaiKhoanForm(TaiKhoanDuocChon);
                    detailNV.ShowDialog();
                }

            }
        }
        private void refreshDataGridView(BindingList<TaiKhoanDTO> listRefresh) // Tải lại DataGridView
        {
            DGVTaiKhoan.Rows.Clear();
            DGVTaiKhoan.ClearSelection();

            foreach (TaiKhoanDTO tk in listRefresh)
            {
                if (tk.Trangthai == 1)
                {
                    DGVTaiKhoan.Rows.Add(tk.Manv, tk.Tendangnhap, tk.Matkhau,
                        tk.Manhomquyen, "Hoạt động");
                }
            }
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
    }
}
