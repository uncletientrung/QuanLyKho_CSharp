using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    public partial class KhuVucGUI : Form
    {
        private KhuVucKhoBUS kvkBUS = new KhuVucKhoBUS();
        private BindingList<KhuVucKhoDTO> listKhuVuc;

        public KhuVucGUI()
        {
            InitializeComponent();

            txSearch.Text = "Nhập mã, tên hoặc số điện thoại của khu vực kho để tìm"; // Sửa: đồng bộ placeholder text
            txSearch.ForeColor = Color.Gray;
            DGVKhuVuc.ClearSelection();
            DGVKhuVuc.RowHeadersVisible = false; // Tắt cột header
            DGVKhuVuc.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhuVuc.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhuVuc.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhuVuc.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhuVuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhuVuc.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhuVuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhuVuc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            
            listKhuVuc = kvkBUS.getKhuVucKhoList();
        }

        private void DGVKhuVuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVKhuVuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DGVKhuVuc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVKhuVuc.Columns["Actions"].Index && e.RowIndex >= 0)
            // Nếu cell thuộc cột actions và không phải row header (-1 là header) thì bắt đầu vẽ
            {
                e.PaintBackground(e.CellBounds, true);
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

        private void KhuVucGUI_Load(object sender, EventArgs e)
        {
            DGVKhuVuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVKhuVuc.Columns.Add("MaKVK", "Mã");
            DGVKhuVuc.Columns["MaKVK"].FillWeight = 30;

            DGVKhuVuc.Columns.Add("TenKVK", "Tên khu vực kho");
            DGVKhuVuc.Columns["TenKVK"].FillWeight = 150;

            DGVKhuVuc.Columns.Add("DiaChiKho", "Địa chỉ kho");
            DGVKhuVuc.Columns["DiaChiKho"].FillWeight = 200;

            DGVKhuVuc.Columns.Add("SDT", "Số điện thoại");
            DGVKhuVuc.Columns["SDT"].FillWeight = 100;

            DGVKhuVuc.Columns.Add("Email", "Email");
            DGVKhuVuc.Columns["Email"].FillWeight = 150;  

            DGVKhuVuc.RowTemplate.Height = 40;

            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVKhuVuc.Columns.Add(btn);
            DGVKhuVuc.Columns["Actions"].FillWeight = 100;

            refreshDataGridView(listKhuVuc);
        }

        private void KhuVucGUI_Shown(object sender, EventArgs e)
        {

        }

        private void refreshDataGridView(BindingList<KhuVucKhoDTO> list)
        {
            DGVKhuVuc.Rows.Clear();
            foreach (KhuVucKhoDTO kvk in list)
            {
                DGVKhuVuc.Rows.Add(kvk.Makhuvuc, kvk.Tenkhuvuc, kvk.Diachi, kvk.Sdt, kvk.Email);
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã, tên hoặc số điện thoại của khu vực kho để tìm")
            {
                string keyword = txSearch.Text.Trim().ToLower();
                BindingList<KhuVucKhoDTO> listSearch = kvkBUS.SearchKho(keyword);
                refreshDataGridView(listSearch);
            }
        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if(txSearch.Text == "Nhập mã, tên hoặc số điện thoại của khu vực kho để tìm")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txSearch.Text))
            {
                txSearch.Text = "Nhập mã, tên hoặc số điện thoại của khu vực kho để tìm";
                txSearch.ForeColor = Color.Gray;
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddKhuVucForm addKhuVuc = new AddKhuVucForm();
            addKhuVuc.ShowDialog();

            if (addKhuVuc.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(kvkBUS.getKhuVucKhoList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }
    }
}
