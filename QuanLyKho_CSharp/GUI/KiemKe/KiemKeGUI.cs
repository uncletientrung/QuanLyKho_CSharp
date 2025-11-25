using QuanLyKho_CSharp.GUI.PhieuNhap;
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
        private string _currentUserName; // Thêm field để lưu tên người dùng

        public KiemKeGUI(string userName = null)
        {
            InitializeComponent();
            _currentUserName = userName; // Lưu thông tin người dùng

            InitializeDataGridViewColumns();
            SetupDataGridView();
            this.Load += new System.EventHandler(this.KiemKeGUI_Load);
            DGVKiemKe.CellPainting += DGVKiemKe_CellPainting;
            DGVKiemKe.CellMouseClick += DGVKiemKe_CellMouseClick;
            LoadDataIntoGridView();
        }











        // header button
        // add phiếu kiểm kê
        private void btn_addPhieuKiemKe(object sender, EventArgs e)
        {
            frmMain mainForm = this.ParentForm as frmMain;
            if (mainForm != null)
            {
                var method = mainForm.GetType().GetMethod("OpenChildForm",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (method != null)
                {
                    // Truyền thông tin người dùng sang AddPhieuKiemKeForm
                    method.Invoke(mainForm, new object[] { new AddPhieuKiemKeForm(_currentUserName), null });
                }
            }
        }
        // export excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu Excel danh sách hoàn hàng";
                saveFileDialog.FileName = "DanhSachHoanHang.xlsx";
                // Chỉ hiện alert sau khi đã lưu file thành công
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    MessageBox.Show("Xuất thành công danh sách hoàn hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }











        // searchplaceholder
        
        private void KiemKeGUI_Load(object sender, EventArgs e)
        {
            txSearch.ForeColor = Color.Gray;
            txSearch.Font = placeholderFont;
            txSearch.Text = SearchPlaceholder;
            txSearch.GotFocus += txSearch_Enter;
            txSearch.LostFocus += txSearch_Leave;
            LoadDataIntoGridView();
        }
        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == SearchPlaceholder)
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
                txSearch.Font = normalFont;
            }
        }
        private void txSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txSearch.Text))
            {
                txSearch.Text = SearchPlaceholder;
                txSearch.ForeColor = Color.LightGray;
                txSearch.Font = placeholderFont;
            }
        }





        // Cho phép Add dòng từ AddPhieuKiemKeForm
        public void AddKiemKeRow(
        int maPhieu,
        string thoiGianTao,
        string trangThai,
        string ghiChu,
        string maKhuVuc,
        string maNhanVienTao,
        string maNhanVienKiem)
            {
                if (DGVKiemKe.Columns.Count == 0)
                    InitializeDataGridViewColumns();

                DGVKiemKe.Rows.Add(
                    maPhieu,
                    thoiGianTao,
                    trangThai,
                    ghiChu,
                    maKhuVuc,
                    maNhanVienTao,
                    maNhanVienKiem
                );
        }

        private void DanhSachKiemKeGUI_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewColumns();
            LoadDataIntoGridView();
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
            DGVKiemKe.Columns.Add("ThoiGianTao", "Thời gian tạo phiếu");
            DGVKiemKe.Columns.Add("TrangThai", "Trạng thái");
            DGVKiemKe.Columns.Add("GhiChu", "Ghi chú");
            DGVKiemKe.Columns.Add("MaKhuVuc", "Mã khu vực");
            DGVKiemKe.Columns.Add("MaNhanVienTao", "Mã nhân viên tạo");
            DGVKiemKe.Columns.Add("MaNhanVienKiem", "Mã nhân viên kiểm");

            foreach (DataGridViewColumn column in DGVKiemKe.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DGVKiemKe.Columns["MaPhieuKiemKe"].FillWeight = 10;   // 10%
            DGVKiemKe.Columns["ThoiGianTao"].FillWeight = 18;     // 18%
            DGVKiemKe.Columns["TrangThai"].FillWeight = 14;       // 14%
            DGVKiemKe.Columns["GhiChu"].FillWeight = 16;          // 18%
            DGVKiemKe.Columns["MaKhuVuc"].FillWeight = 14;          // 12%
            DGVKiemKe.Columns["MaNhanVienTao"].FillWeight = 14;     // 14%
            DGVKiemKe.Columns["MaNhanVienKiem"].FillWeight = 14;   // 14%

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

        public void LoadDataIntoGridView()
        {
            DGVKiemKe.Rows.Clear();
            var list = QuanLyKho.BUS.PhieuKiemKeBUS.Instance.GetAll();

            if (list != null && list.Count > 0)
            {
                foreach (var kk in list)
                {
                    DGVKiemKe.Rows.Add(
                        kk.Maphieukiemke,
                        kk.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        kk.Trangthai,
                        kk.Ghichu,
                        kk.Makhuvuc,
                        kk.Manhanvientao,
                        kk.Manhanvienkiem
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
                    using (Image imgXem = Image.FromFile("images\\icon\\detail.png"))
                    using (Image imgXoa = Image.FromFile("images\\icon\\remove.png"))
                    {
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
                    }
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
                int padding = 5;
                int totalButtons = 2;
                int buttonWidth = (DGVKiemKe.Columns["Actions"].Width - padding * (totalButtons + 1)) / totalButtons;
                int xRel = e.Location.X;

                int maPhieu = Convert.ToInt32(DGVKiemKe.Rows[e.RowIndex].Cells["MaPhieuKiemKe"].Value);

                if (xRel < padding + buttonWidth) // Nút Xem
                {
                    // Lấy đối tượng PhieuKiemKeDTO từ BUS theo mã phiếu
                    var phieuKiem = QuanLyKho.BUS.PhieuKiemKeBUS.Instance.GetById(maPhieu);
                    if (phieuKiem != null)
                    {
                        using (var detailForm = new DetailPhieuKiemKeForm(phieuKiem))
                        {
                            detailForm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu kiểm kê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // Nút Xóa
                {
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phiếu kiểm kê {maPhieu}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = maPhieu;
                        var result = QuanLyKho.BUS.PhieuKiemKeBUS.Instance.Delete(id);
                        if (result > 0)
                        {
                            DGVKiemKe.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Xóa phiếu kiểm kê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa phiếu kiểm kê thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }













        // readonly 
        private void btn_search(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) {}
        private void panel2_Paint(object sender, PaintEventArgs e) {}
        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e) {}
        private void pictureBox1_Click(object sender, EventArgs e) {}
        private void panel1_Paint(object sender, PaintEventArgs e) {}
    }
}


