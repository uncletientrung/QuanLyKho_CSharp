using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.DAO;
using System.Windows.Forms.VisualStyles;

namespace QuanLyKho_CSharp.GUI
{
    public partial class NhanVienGUI : Form
    {
        private static BindingList<NhanVienDTO> listNV;
        public NhanVienGUI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            DGVNhanVien.RowHeadersVisible = false; // Tắt cột header
            DGVNhanVien.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVNhanVien.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVNhanVien.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVNhanVien.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa


            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            listNV = NhanVienDAO.getInstance().SelectAll();
            DGVNhanVien.Columns.Add("MaNV", "Mã nhân viên");
            DGVNhanVien.Columns["MaNV"].Width = 120;

            DGVNhanVien.Columns.Add("TenNV", "Họ và Tên");
            DGVNhanVien.Columns["TenNV"].Width = 150;

            DGVNhanVien.Columns.Add("GioiTinh", "Giới tính");
            DGVNhanVien.Columns["GioiTinh"].Width = 90;

            DGVNhanVien.Columns.Add("SDT", "Số điện thoại");
            DGVNhanVien.Columns["SDT"].Width = 100;

            DGVNhanVien.Columns.Add("NgaySinh", "Ngày sinh");
            DGVNhanVien.Columns["NgaySinh"].Width = 100;

            DGVNhanVien.Columns.Add("TrangThai", "Trạng thái");
            DGVNhanVien.Columns["TrangThai"].Width = 116;
            DGVNhanVien.RowTemplate.Height = 40;

            foreach (NhanVienDTO nv in listNV)
            {
                DGVNhanVien.Rows.Add(nv.Manv, nv.Tennv, nv.Gioitinh, nv.Sdt
                    ,nv.Ngaysinh.ToString("dd/MM/yyyy"), nv.Trangthai);

            }
            

            // Tạo 3 cái nút ở table
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVNhanVien.Columns.Add(btn);
            DGVNhanVien.Columns["Actions"].Width = 150;
        }

        private void DGVNhanVien_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVNhanVien.Columns["Actions"].Index && e.RowIndex >= 0)
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
                        btnSua.Top + (btnSua.Height - targetHeight) / 2 +3,
                        targetWidth -5,
                        targetHeight -5 ));
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

        private void DGVNhanVien_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void DGVNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //e.ColumnIndex, e.RowIndex → xác định cell được click
            //e.Location → vị trí con trỏ chuột trong cell(tọa độ X, Y)
            //e.Button → nút chuột được nhấn
            if (e.ColumnIndex == DGVNhanVien.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X; //Lấy tọa độ X của chuột trong cell

                if (xRel < padding + buttonWidth) MessageBox.Show("Bấm Sửa"); // kiểm tra trên tọa độ x
                else if (xRel < padding * 2 + buttonWidth * 2) MessageBox.Show("Bấm Xóa");
                else MessageBox.Show("Bấm Xem");
            }
        }
    }
}
