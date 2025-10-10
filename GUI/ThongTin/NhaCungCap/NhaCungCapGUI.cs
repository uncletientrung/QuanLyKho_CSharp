using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
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
namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class NhaCungCapGUI : Form
    {
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private BindingList<NhaCungCapDTO> listNCC;
        public NhaCungCapGUI()
        {
            InitializeComponent();
            txSearch.Text = "Nhập mã, tên hoặc số điện thoại nhà cung cấp để tìm";
            txSearch.ForeColor = Color.Gray;
            DGVNhaCungCap.ClearSelection();
            DGVNhaCungCap.RowHeadersVisible = false; // Tắt cột header
            DGVNhaCungCap.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVNhaCungCap.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVNhaCungCap.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVNhaCungCap.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVNhaCungCap.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVNhaCungCap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVNhaCungCap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            listNCC = nccBUS.getListNCC();
        }

        private void NhaCungCapGUI_Load(object sender, EventArgs e)
        {
            DGVNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVNhaCungCap.Columns.Add("MaNCC", "Mã");
            DGVNhaCungCap.Columns["MaNCC"].FillWeight = 30;

            DGVNhaCungCap.Columns.Add("TenNCC", "Tên nhà cung cấp");
            DGVNhaCungCap.Columns["TenNCC"].FillWeight = 150;

            DGVNhaCungCap.Columns.Add("DiaChiNCC", "Địa chỉ");
            DGVNhaCungCap.Columns["DiaChiNCC"].FillWeight = 200;

            DGVNhaCungCap.Columns.Add("SDT", "Số điện thoại");
            DGVNhaCungCap.Columns["SDT"].FillWeight = 100;

            DGVNhaCungCap.Columns.Add("Email", "Email");
            DGVNhaCungCap.Columns["Email"].FillWeight = 150;

            DGVNhaCungCap.Columns.Add("TrangThai", "Trạng thái");
            DGVNhaCungCap.Columns["TrangThai"].FillWeight = 80;

            DGVNhaCungCap.RowTemplate.Height = 40;
            foreach (NhaCungCapDTO ncc in listNCC.Where(ncc => ncc.Trangthai ==1))
            {
                string trangThai = ncc.Trangthai == 1 ? "Hoạt động" : "Ngừng hoạt động";
                DGVNhaCungCap.Rows.Add(ncc.Mancc, ncc.Tenncc, ncc.Diachincc, ncc.Sdt, ncc.Email, trangThai);
            }

            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVNhaCungCap.Columns.Add(btn);
            DGVNhaCungCap.Columns["Actions"].FillWeight = 100;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == "Nhập mã, tên hoặc số điện thoại nhà cung cấp để tìm")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }

        private void txSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txSearch.Text)) // Kiểm tra rỗng, null và khoảng trắng
            {
                txSearch.ForeColor = Color.Gray;
                txSearch.Text = "Nhập mã, tên hoặc số điện thoại nhà cung cấp để tìm";
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã, tên hoặc số điện thoại nhà cung cấp để tìm")
            {
                string search_Text = txSearch.Text.Trim();
                BindingList<NhaCungCapDTO> listSearch = nccBUS.searchNhaCungCap(search_Text);
                refreshDataGridView(listSearch);
            }
        }
        private void refreshDataGridView(BindingList<NhaCungCapDTO> list)
        {
            DGVNhaCungCap.Rows.Clear();
            foreach (NhaCungCapDTO ncc in list)
            {
                string trangThai = ncc.Trangthai == 1 ? "Hoạt động" : "Ngừng hoạt động";
                DGVNhaCungCap.Rows.Add(ncc.Mancc, ncc.Tenncc, ncc.Diachincc, ncc.Sdt, ncc.Email, trangThai);
            }
        }

        private void DGVNhaCungCap_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVNhaCungCap.Columns["Actions"].Index && e.RowIndex >= 0)
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

        private void DGVNhaCungCap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //e.ColumnIndex, e.RowIndex → xác định cell được click
            //e.Location → vị trí con trỏ chuột trong cell(tọa độ X, Y)
            //e.Button → nút chuột được nhấn
            if (e.ColumnIndex == DGVNhaCungCap.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRelative = e.Location.X; // Tọa độ X của con trỏ chuột trong cell
                // Cells["mancc"] là ô dựa trên dataSource,
                // Column["mancc"] là cột dữ liệu của DGV
                int maNCC = int.Parse(DGVNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString());
                NhaCungCapDTO NhaCungCapDuocChon = nccBUS.getNCCById(maNCC);
                if (xRelative < padding + buttonWidth)
                {
                    UpdateNhaCungCapForm updateNCC = new UpdateNhaCungCapForm(NhaCungCapDuocChon);
                    updateNCC.ShowDialog();
                    if (updateNCC.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                        AddSuccessNotification tb = new AddSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative < padding * 2 + buttonWidth * 2)
                {
                    DeleteNhaCungCapForm deleteNCC = new DeleteNhaCungCapForm(NhaCungCapDuocChon);
                    deleteNCC.ShowDialog();
                    if (deleteNCC.DialogResult == DialogResult.OK)
                    {
                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                        refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                    }
                }
                else
                {
                    DetailNhaCungCapForm detailNCC = new DetailNhaCungCapForm(NhaCungCapDuocChon);
                    detailNCC.ShowDialog();
                }
            }
            {

            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddNhaCungCapForm addNCC = new AddNhaCungCapForm();
            addNCC.ShowDialog();

            if (addNCC.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }
    }
}
