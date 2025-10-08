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

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class KiemKeGUI : Form
    {
        public KiemKeGUI()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.FileName = "SanPhamHoanHang.xlsx";
                // Chỉ hiện alert sau khi đã lưu file thành công
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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

        private void btn_search(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã phiếu, tên hàng hoá để tìm kiếm"){}
        }

        private void DanhSachKiemKeGUI_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewColumns();
            LoadDataIntoGridView();
        }

        // Add this method to your KiemKeGUI class (in KiemKeGUI.cs, not the Designer file)
        private void lbFormName_Click(object sender, EventArgs e)
        {
            // You can leave this empty or add your desired logic here
        }
        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_addPhieuKiemKe(object sender, EventArgs e)
        {

        }

        private void SetupDataGridView()
        {
            DGVKiemKe.ClearSelection();
            DGVKiemKe.RowHeadersVisible = false;
            DGVKiemKe.AllowUserToResizeRows = false;
            DGVKiemKe.AllowUserToAddRows = false;
            DGVKiemKe.ReadOnly = true;
            DGVKiemKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVKiemKe.MultiSelect = false;
            DGVKiemKe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVKiemKe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void InitializeDataGridViewColumns()
        {
            DGVKiemKe.Columns.Clear();

            DGVKiemKe.Columns.Add("MaPhieuKiemKe", "Mã phiếu");
            DGVKiemKe.Columns.Add("ThoiGianTao", "Thời gian tạo");
            DGVKiemKe.Columns.Add("NhanVienTao", "Nhân viên tạo");
            DGVKiemKe.Columns.Add("MaNhanVienTao", "Mã nhân viên tạo");
            DGVKiemKe.Columns.Add("MaKhuVuc", "Mã khu vực");
            DGVKiemKe.Columns.Add("TrangThai", "Trạng thái");
            DGVKiemKe.Columns.Add("GhiChu", "Ghi chú");

            foreach (DataGridViewColumn column in DGVKiemKe.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DGVKiemKe.Columns["MaPhieuKiemKe"].FillWeight = 12;   // 12%
            DGVKiemKe.Columns["ThoiGianTao"].FillWeight = 16;     // 16%
            DGVKiemKe.Columns["NhanVienTao"].FillWeight = 18;     // 18%
            DGVKiemKe.Columns["MaNhanVienTao"].FillWeight = 12;   // 12%
            DGVKiemKe.Columns["MaKhuVuc"].FillWeight = 10;        // 10%
            DGVKiemKe.Columns["TrangThai"].FillWeight = 14;       // 14%
            DGVKiemKe.Columns["GhiChu"].FillWeight = 18;          // 18%

            DGVKiemKe.RowTemplate.Height = 40;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác";
            btn.Name = "Actions";
            btn.Text = "";
            btn.UseColumnTextForButtonValue = true;
            DGVKiemKe.Columns.Add(btn);
            btn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGVKiemKe.Columns["Actions"].Width = 100;
        }

        private void LoadDataIntoGridView()
        {
            DGVKiemKe.Rows.Clear();
            var list = QuanLyKho_CSharp.BUS.PhieuKiemKeBUS.Instance.GetAll();

            if (list != null && list.Count > 0)
            {
                foreach (var kk in list)
                {
                    DGVKiemKe.Rows.Add(
                        kk.Maphieukiemke,
                        kk.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        kk.Nhanvientao,
                        kk.Manhanvientao,
                        kk.Makhuvuc,
                        kk.Trangthai,
                        kk.Ghichu
                    );
                }
            }
            DGVKiemKe.ClearSelection();
        }

        // 2 nút ation xem-xoá
        // Thêm các hàm xử lý vẽ và click nút thao tác
        private void DGVKiemKe_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVKiemKe.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 5;
                int totalButtons = 2;
                int buttonWidth = (e.CellBounds.Width - padding * (totalButtons + 1)) / totalButtons;

                Rectangle btnXem = new Rectangle(e.CellBounds.Left + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXoa = new Rectangle(btnXem.Right + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);

                ButtonRenderer.DrawButton(e.Graphics, btnXem, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnXoa, "", this.Font, false, PushButtonState.Normal);

                try
                {
                    // Vẽ icon dấu 3 chấm (xem chi tiết)
                    Image imgXem = Image.FromFile("images\\icon\\detail.png");
                    // Vẽ icon thùng rác (xoá)
                    Image imgXoa = Image.FromFile("images\\icon\\remove.png");

                    int targetWidth = 24;
                    int targetHeight = 24;

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
                    imgXoa.Dispose();
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi ảnh
                }

                e.Handled = true;
            }
        }
        private void DGVKiemKe_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVKiemKe.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X;

                int maPhieu = int.Parse(DGVKiemKe.Rows[e.RowIndex].Cells["MaPhieuKiemKe"].Value.ToString());
                // Lấy đối tượng kiểm kê theo mã nếu cần

                if (xRel < padding + buttonWidth) // nút Xem chi tiết
                {
                    // TODO: Hiển thị chi tiết phiếu kiểm kê
                    MessageBox.Show($"Xem chi tiết phiếu kiểm kê: {maPhieu}", "Chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // nút Xoá
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phiếu kiểm kê {maPhieu}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // TODO: Xoá phiếu kiểm kê qua BUS/DAO
                        MessageBox.Show("Xóa phiếu kiểm kê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIntoGridView();
                    }
                }
            }
        }
    }
}
