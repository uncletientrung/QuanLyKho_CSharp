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
using QuanLyKho_CSharp.GUI.ThongTin.Size;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    public partial class SizeGUI : Form
    {
        private SizeBUS sizeBUS = new SizeBUS();
        private BindingList<SizeDTO> listSize;



        public SizeGUI()
        {
            InitializeComponent();

            txSearch.Text = "Nhập mã, tên size để tìm";
            txSearch.ForeColor = Color.Gray;

            // Thiết lập DataGridView
            DGVSize.ClearSelection();
            DGVSize.RowHeadersVisible = false; // Tắt cột header
            DGVSize.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVSize.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVSize.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVSize.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVSize.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVSize.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVSize.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVSize.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập thêm cho DataGridView to hơn
            DGVSize.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DGVSize.RowTemplate.Height = 35; // Tăng chiều cao mỗi row
            DGVSize.ColumnHeadersHeight = 40; // Tăng chiều cao header
            DGVSize.Font = new Font("Segoe UI", 10F); // Tăng font size

            listSize = sizeBUS.getSizeList();
        }

        private void DGVSize_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVSize.Columns["Actions"].Index && e.RowIndex >= 0)
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

        private void roundedButton2_Click_1(object sender, EventArgs e)
        {
            AddSizeForm addSize = new AddSizeForm();
            addSize.ShowDialog();

            if (addSize.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(sizeBUS.getSizeList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void refreshDataGridView(BindingList<SizeDTO> list)
        {
            DGVSize.Rows.Clear();
            foreach (SizeDTO size in list)
            {
                DGVSize.Rows.Add(size.Masize, size.Tensize, size.Ghichu);
            }

        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã hoặc tên size để tìm kiếm")
            {
                string keyword = txSearch.Text.Trim().ToLower();
                BindingList<SizeDTO> listSearch = sizeBUS.SearchSize(keyword);
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
            if (txSearch.Text == "Nhập mã hoặc tên size để tìm kiếm")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }

        }

        private void SizeGUI_Load(object sender, EventArgs e)
        {
            DGVSize.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVSize.Columns.Add("MaSize", "Mã size");
            DGVSize.Columns["MaSize"].FillWeight = 30;
            DGVSize.Columns["MaSize"].MinimumWidth = 100;

            DGVSize.Columns.Add("TenSize", "Tên size");
            DGVSize.Columns["TenSize"].FillWeight = 200;
            DGVSize.Columns["TenSize"].MinimumWidth = 200;

            DGVSize.Columns.Add("GhiChu", "Ghi chú");
            DGVSize.Columns["GhiChu"].FillWeight = 200;
            DGVSize.Columns["GhiChu"].MinimumWidth = 200;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Thao tác";
            btn.Name = "Actions";
            btn.Text = "Actions";
            btn.UseColumnTextForButtonValue = true; // Hiện text trên button
            btn.FillWeight = 20; // Giảm tỷ lệ cột button
            btn.MinimumWidth = 200;
            DGVSize.Columns.Add(btn);

            // Load dữ liệu ban đầu
            refreshDataGridView(listSize);

            // Đảm bảo DataGridView chiếm toàn bộ không gian
            DGVSize.Dock = DockStyle.Fill;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVSize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVSize_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Chỉ xử lý khi click vào cột Actions
            if (DGVSize.Columns[e.ColumnIndex].Name != "Actions")
                return;

            // Lấy thông tin Loại được chọn (sử dụng đúng tên cột: MaLoai)
            int maSize = Convert.ToInt32(DGVSize.Rows[e.RowIndex].Cells["MaSize"].Value);
            SizeDTO SizeDuocChon = sizeBUS.getSizeById(maSize);
            if (SizeDuocChon == null)
            {
                MessageBox.Show("Không tìm thấy size này!");
                return;
            }

            // Tính toán vị trí click trong ô để xác định nút
            Rectangle cellBounds = DGVSize.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int padding = 5;
            int totalButtons = 3;
            int buttonWidth = (cellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
            // e.X đã là toạ độ tương đối trong cell, không trừ cellBounds.Left
            int clickX = e.X;

            int startSua = padding;
            int startXoa = startSua + buttonWidth + padding;
            int startXem = startXoa + buttonWidth + padding;
            


        }



    }
}
