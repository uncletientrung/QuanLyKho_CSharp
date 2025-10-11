using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class LoaiGUI : Form
    {

        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<LoaiDTO> listLoai;

        public LoaiGUI()
        {
            InitializeComponent();

            txSearch.Text = "Nhập mã, tên chất liệu để tìm";
            txSearch.ForeColor = Color.Gray;

            // Thiết lập DataGridView
            DGVLoai.ClearSelection();
            DGVLoai.RowHeadersVisible = false; // Tắt cột header
            DGVLoai.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVLoai.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVLoai.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVLoai.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVLoai.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVLoai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVLoai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập thêm cho DataGridView to hơn
            DGVLoai.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DGVLoai.RowTemplate.Height = 35; // Tăng chiều cao mỗi row
            DGVLoai.ColumnHeadersHeight = 40; // Tăng chiều cao header
            DGVLoai.Font = new Font("Segoe UI", 10F); // Tăng font size

            listLoai = loaiBUS.getLoaiList();
        }

        private void DGVLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Chỉ xử lý khi click vào cột Actions
            if (DGVLoai.Columns[e.ColumnIndex].Name != "Actions")
                return;

            // Lấy thông tin Loại được chọn (sử dụng đúng tên cột: MaLoai)
            int maLoai = Convert.ToInt32(DGVLoai.Rows[e.RowIndex].Cells["MaLoai"].Value);
            LoaiDTO loaiDuocChon = loaiBUS.getLoaiById(maLoai);
            if (loaiDuocChon == null)
            {
                MessageBox.Show("Không tìm thấy loại này!");
                return;
            }

            // Tính toán vị trí click trong ô để xác định nút
            Rectangle cellBounds = DGVLoai.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int padding = 5;
            int totalButtons = 3;
            int buttonWidth = (cellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
            int clickX = e.X - cellBounds.Left;

            int startSua = padding;
            int startXoa = startSua + buttonWidth + padding;
            int startXem = startXoa + buttonWidth + padding;

            if (clickX >= startSua && clickX < startSua + buttonWidth)
            {
                // Sửa
                UpdateLoaiForm updateLoai = new UpdateLoaiForm(loaiDuocChon);
                updateLoai.ShowDialog();
                if (updateLoai.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(loaiBUS.getLoaiList());
                    new AddSuccessNotification().Show();
                }
            }
            else if (clickX >= startXoa && clickX < startXoa + buttonWidth)
            {
                // Xóa
                DeleteLoaiForm deleteLoai = new DeleteLoaiForm(loaiDuocChon);
                deleteLoai.ShowDialog();
                if (deleteLoai.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(loaiBUS.getLoaiList());
                }
            }
            else if (clickX >= startXem && clickX < startXem + buttonWidth)
            {
                // Xem chi tiết
                DetailLoaiForm detailLoai = new DetailLoaiForm(loaiDuocChon);
                detailLoai.ShowDialog();
            }
        }

        private void DGVLoai_Painting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVLoai.Columns["Actions"].Index && e.RowIndex >= 0)
            // Nếu cell thuộc cột actions và không phải row header (-1 là header) thì bắt đầu vẽ
            {
                e.PaintBackground(e.CellBounds, true); // Vẽ nền cell mặc định || True nghĩa là highlight nếu đc chọn
                                                       // Định nghĩa các nút
                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (e.CellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
                Rectangle btnSua = new Rectangle(e.CellBounds.Left + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXoa = new Rectangle(btnSua.Right + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXem = new Rectangle(btnXoa.Right + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);

                // Vẽ nút lên cell
                // ButtonRenderer.DrawButton(Đối tượng vẽ lên, vị trí và kích thước vẽ, "Text hiển thị",
                //                          Font chữ, false/true không phải nút đang hover, Trạng thái nút bình thường);
                // Giữ lại giao diện nút nhưng không vẽ văn bản
                ButtonRenderer.DrawButton(e.Graphics, btnXem, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnSua, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnXoa, "", this.Font, false, PushButtonState.Normal);

                // Chèn hình vào nút
                try
                {
                    // Tải hình ảnh từ thư mục image
                    Image imgSua = Image.FromFile("images\\icon\\edit.png");
                    Image imgXoa = Image.FromFile("images\\icon\\remove.png");
                    Image imgXem = Image.FromFile("images\\icon\\detail.png");

                    int targetWidth = 24;
                    int targetHeight = 24;

                    // Vẽ hình ảnh với kích thước 32x32, căn giữa nút
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


                e.Handled = true; // Ngăn DataGridView không vẽ thêm trì đè lên nữa
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddLoaiForm addLoai = new AddLoaiForm();
            addLoai.ShowDialog();

            if (addLoai.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(loaiBUS.getLoaiList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void LoaiGUI_Load(object sender, EventArgs e)
        {
            DGVLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVLoai.Columns.Add("MaLoai", "Mã Loại");
            DGVLoai.Columns["MaLoai"].FillWeight = 30;
            DGVLoai.Columns["MaLoai"].MinimumWidth = 100;

            DGVLoai.Columns.Add("TenLoai", "Tên Loại");
            DGVLoai.Columns["TenLoai"].FillWeight = 200;
            DGVLoai.Columns["TenLoai"].MinimumWidth = 200;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác";
            btn.Name = "Actions";
            btn.Text = "Actions";
            btn.UseColumnTextForButtonValue = true; // Hiện text trên button
            btn.FillWeight = 20; // Giảm tỷ lệ cột button
            btn.MinimumWidth = 200;
            DGVLoai.Columns.Add(btn);

            // Load dữ liệu ban đầu
            refreshDataGridView(listLoai);

            // Đảm bảo DataGridView chiếm toàn bộ không gian
            DGVLoai.Dock = DockStyle.Fill;
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã hoặc tên loại để tìm kiếm")
            {
                string keyword = txSearch.Text.Trim().ToLower();
                BindingList<LoaiDTO> listSearch = loaiBUS.SearchLoai(keyword);
                refreshDataGridView(listSearch);
            }

        }

        private void txSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txSearch.Text))
            {
                txSearch.ForeColor = Color.Gray;
                txSearch.Text = "Nhập mã hoặc tên loại để tìm kiếm";
            }
        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == "Nhập mã hoặc tên chất liệu để tìm kiếm")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }

        private void refreshDataGridView(BindingList<LoaiDTO> list)
        {
            DGVLoai.Rows.Clear();
            foreach (LoaiDTO loai in list)
            {
                DGVLoai.Rows.Add(loai.Maloai, loai.Tenloai);
            }
        }


    }
}
