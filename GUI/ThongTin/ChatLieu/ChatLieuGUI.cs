using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class ChatLieuGUI : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private BindingList<ChatLieuDTO> listCL;
        public ChatLieuGUI()
        {
            InitializeComponent();
            txSearch.Text = "Nhập mã, tên chất liệu để tìm";
            txSearch.ForeColor = Color.Gray;
            
            // Thiết lập DataGridView
            DGVChatLieu.ClearSelection();
            DGVChatLieu.RowHeadersVisible = false; // Tắt cột header
            DGVChatLieu.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVChatLieu.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVChatLieu.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVChatLieu.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVChatLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVChatLieu.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVChatLieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVChatLieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa
            
            // Thiết lập thêm cho DataGridView to hơn
            DGVChatLieu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DGVChatLieu.RowTemplate.Height = 35; // Tăng chiều cao mỗi row
            DGVChatLieu.ColumnHeadersHeight = 40; // Tăng chiều cao header
            DGVChatLieu.Font = new Font("Segoe UI", 10F); // Tăng font size

            listCL = clBUS.getChatLieuList();
        }

        private void lblDanhSachChatLieu_Click(object sender, EventArgs e)
        {

        }

        private void ChatLieuGUI_Load(object sender, EventArgs e)
        {
            
            DGVChatLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVChatLieu.Columns.Add("Mã chất liệu", "Mã chất liệu");
            DGVChatLieu.Columns["Mã chất liệu"].FillWeight = 30; // Giảm tỷ lệ cột mã
            DGVChatLieu.Columns["Mã chất liệu"].MinimumWidth = 100;

            DGVChatLieu.Columns.Add("Tên chất liệu", "Tên chất liệu");
            DGVChatLieu.Columns["Tên chất liệu"].FillWeight = 50; // Tăng tỷ lệ cột tên
            DGVChatLieu.Columns["Tên chất liệu"].MinimumWidth = 200;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn(); 
            btn.HeaderText = "Thao tác";
            btn.Name = "Actions";
            btn.Text = "Actions";
            btn.UseColumnTextForButtonValue = true; // Hiện text trên button
            btn.FillWeight = 20; // Giảm tỷ lệ cột button
            btn.MinimumWidth = 200;
            DGVChatLieu.Columns.Add(btn);
            
            // Load dữ liệu ban đầu
            refreshDataGridView(listCL);
            
            // Đảm bảo DataGridView chiếm toàn bộ không gian
            DGVChatLieu.Dock = DockStyle.Fill;
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã hoặc tên chất liệu để tìm kiếm")
            {
               string keyword = txSearch.Text.Trim().ToLower();
                BindingList<ChatLieuDTO> listSearch = clBUS.searchChatLieu(keyword);
                refreshDataGridView(listSearch); 
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

        private void txSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txSearch.Text))
            {
                txSearch.ForeColor = Color.Gray;
                txSearch.Text = "Nhập mã hoặc tên chất liệu để tìm kiếm";
            }
        }

        private void refreshDataGridView(BindingList<ChatLieuDTO> list)
        {
            DGVChatLieu.Rows.Clear();
            foreach (ChatLieuDTO cl in list)
            {
                DGVChatLieu.Rows.Add(cl.Machatlieu, cl.Tenchatlieu);
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddChatLieuForm addCL = new AddChatLieuForm();
            addCL.ShowDialog();

            if (addCL.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(clBUS.getChatLieuList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void DGVChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVChatLieu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVChatLieu.Columns["Actions"].Index && e.RowIndex >= 0)
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

        private void DGVChatLieu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
