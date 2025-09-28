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

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class PhieuNhapGUI : Form
    {
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<PhieuNhapDTO> listPN;

        public PhieuNhapGUI()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.ClearSelection();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadData()
        {
            listPN = pnBUS.getListPN();
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewColumns();
            dateTimeBegin.Value = DateTime.Now.AddMonths(-1); // 1 tháng trước
            dateTimeEnd.Value = DateTime.Now;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            LoadDataIntoGridView();
        }

        private void InitializeDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("MaPhieu", "Mã phiếu");
            dataGridView1.Columns.Add("TenNV", "Tên nhân viên");
            dataGridView1.Columns.Add("MaNCC", "Mã NCC");
            dataGridView1.Columns.Add("ThoiGian", "Thời gian tạo");
            dataGridView1.Columns.Add("TongTien", "Tổng tiền");
            dataGridView1.Columns.Add("TrangThai", "Trạng thái");

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridView1.Columns["MaPhieu"].FillWeight = 10;      // 10%
            dataGridView1.Columns["TenNV"].FillWeight = 20;        // 20%
            dataGridView1.Columns["MaNCC"].FillWeight = 10;        // 10%
            dataGridView1.Columns["ThoiGian"].FillWeight = 20;     // 20%
            dataGridView1.Columns["TongTien"].FillWeight = 20;     // 20%
            dataGridView1.Columns["TrangThai"].FillWeight = 20;    // 20%

            dataGridView1.RowTemplate.Height = 40;

            // Thêm cột nút hành động giống NhanVienGUI
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác";
            btn.Name = "Actions";
            btn.Text = "";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            btn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Actions"].Width = 150;
        }

        private void LoadDataIntoGridView()
        {
            dataGridView1.Rows.Clear();

            if (listPN != null && listPN.Count > 0)
            {
                foreach (PhieuNhapDTO pn in listPN)
                {
                    if (pn.Trangthai == 1)
                    {
                        string tenNV = nvBUS.getNamebyID(pn.Manv);
                        string trangThai = pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy";
                        dataGridView1.Rows.Add(
                            pn.Maphieu,
                            tenNV,
                            pn.Mancc,
                            pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                            pn.Tongtien,
                            trangThai
                        );
                    }
                }
            }

            dataGridView1.ClearSelection();
            FilterData();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (e.CellBounds.Width - padding * (totalButtons + 1)) / totalButtons;

                Rectangle btnSua = new Rectangle(e.CellBounds.Left + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXoa = new Rectangle(btnSua.Right + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXem = new Rectangle(btnXoa.Right + padding, e.CellBounds.Top + padding,
                    buttonWidth, e.CellBounds.Height - 2 * padding);

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
                catch (Exception)
                {
                    // Bỏ qua lỗi ảnh
                }

                e.Handled = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X;

                int maPhieu = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString());
                PhieuNhapDTO phieuDuocChon = pnBUS.getPhieuNhapById(maPhieu);

                if (xRel < padding + buttonWidth)
                {
                    // Sửa phiếu nhập
                    MessageBox.Show($"Sửa phiếu nhập: {maPhieu}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (xRel < padding * 2 + buttonWidth * 2)
                {
                    // Xóa phiếu nhập
                    if (MessageBox.Show($"Bạn có chắc muốn xóa phiếu nhập {maPhieu}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (pnBUS.removePhieuNhap(maPhieu))
                        {
                            LoadData();
                            LoadDataIntoGridView();
                            MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa phiếu nhập thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Xem chi tiết
                    string tenNV = nvBUS.getNamebyID(phieuDuocChon.Manv);
                    MessageBox.Show($"Chi tiết phiếu nhập:\nMã phiếu: {maPhieu}\nNhân viên: {tenNV}\n" +
                        $"Mã NCC: {phieuDuocChon.Mancc}\nThời gian: {phieuDuocChon.Thoigiantao:dd/MM/yyyy HH:mm}\n" +
                        $"Tổng tiền: {phieuDuocChon.Tongtien:N0}",
                        "Chi tiết phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Thêm phiếu nhập mới
            MessageBox.Show("Chức năng thêm phiếu nhập", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Xuất Excel
            MessageBox.Show("Chức năng xuất Excel", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FilterData()
        {
            if (listPN == null) return;

            var filteredList = listPN.Where(pn => pn.Trangthai == 1).AsEnumerable();

            // Lọc theo tên nhân viên
            if (!string.IsNullOrWhiteSpace(txtSearchNV.Text))
            {
                string searchText = txtSearchNV.Text.Trim().ToLower();
                filteredList = filteredList.Where(pn =>
                {
                    string tenNV = nvBUS.getNamebyID(pn.Manv)?.ToLower() ?? "";
                    return tenNV.Contains(searchText);
                });
            }

            // Lọc theo mã nhà cung cấp
            if (!string.IsNullOrWhiteSpace(txtSearchNCC.Text))
            {
                string searchText = txtSearchNCC.Text.Trim().ToLower();
                filteredList = filteredList.Where(pn =>
                    pn.Mancc.ToString().ToLower().Contains(searchText));
            }

            // Lọc theo khoảng thời gian
            if (dateTimeBegin.Value != null && dateTimeEnd.Value != null)
            {
                DateTime startDate = dateTimeBegin.Value.Date;
                DateTime endDate = dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1); // Đến hết ngày
                filteredList = filteredList.Where(pn =>
                    pn.Thoigiantao >= startDate && pn.Thoigiantao <= endDate);
            }

            // Lọc theo khoảng giá
            if (numericUpDown1.Value > 0 || numericUpDown2.Value > 0)
            {
                decimal minPrice = numericUpDown1.Value;
                decimal maxPrice = numericUpDown2.Value > 0 ? numericUpDown2.Value : decimal.MaxValue;

                filteredList = filteredList.Where(pn =>
                    pn.Tongtien >= minPrice && pn.Tongtien <= maxPrice);
            }

            // Hiển thị kết quả lọc
            DisplayFilteredData(filteredList.ToList());
        }

        private void DisplayFilteredData(List<PhieuNhapDTO> filteredData)
        {
            dataGridView1.Rows.Clear();

            if (filteredData != null && filteredData.Count > 0)
            {
                foreach (PhieuNhapDTO pn in filteredData)
                {
                    string tenNV = nvBUS.getNamebyID(pn.Manv);
                    string trangThai = pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy";
                    dataGridView1.Rows.Add(
                        pn.Maphieu,
                        tenNV,
                        pn.Mancc,
                        pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        pn.Tongtien,
                        trangThai
                    );
                }
            }

            dataGridView1.ClearSelection();
        }

        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtSearchNCC_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dateTimeBegin_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
         }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void txtSearchNV_Enter(object sender, EventArgs e) { }
        private void txtSearchNV_Leave(object sender, EventArgs e) { }
        private void txtSearchNCC_Enter(object sender, EventArgs e) { }
        private void txtSearchNCC_Leave(object sender, EventArgs e) { }
    }
}