using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class KhachHangGUI : Form
    {

        private KhachHangBUS khBUS = new KhachHangBUS();
        private BindingList<KhachHangDTO> listKH;
        public KhachHangGUI()
        {
            InitializeComponent();
            txSearch.Text = "Nhập mã, tên hoặc số điện thoại nhân viên để tìm";
            txSearch.ForeColor = Color.Gray;
            DGVKhachHang.ClearSelection();
            DGVKhachHang.RowHeadersVisible = false; // Tắt cột header
            DGVKhachHang.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhachHang.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhachHang.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhachHang.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhachHang.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            listKH = khBUS.getListKH();
        }

        private void DGVKhachHang_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == DGVKhachHang.Columns["Actions"].Index && e.RowIndex >= 0)
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

        private void DGVKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVKhachHang.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X; //Lấy tọa độ X của chuột trong cell
                
                int maKH = int.Parse(DGVKhachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString());
                KhachHangDTO KhachHangDuocChon = khBUS.getKHById(maKH);
                if (xRel < padding + buttonWidth) // kiểm tra trên tọa độ x
                {
                    UpdateKhachHangForm updateKH = new UpdateKhachHangForm(KhachHangDuocChon);
                    updateKH.ShowDialog();
                    if (updateKH.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(khBUS.getListKH());
                        UpdateSuccessNotification tb = new UpdateSuccessNotification();
                        tb.Show();
                    }

                }
                else if (xRel < padding * 2 + buttonWidth * 2)
                {
                    DeleteKhachHangForm deleteKH = new DeleteKhachHangForm(KhachHangDuocChon);
                    deleteKH.ShowDialog();
                    if (deleteKH.DialogResult == DialogResult.OK)
                    {

                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                        refreshDataGridView(khBUS.getListKH());
                    }
                }
                else
                {
                    DetailKhachHangForm detailKH = new DetailKhachHangForm(KhachHangDuocChon);
                    detailKH.ShowDialog();
                }

            }

        }

        private void DGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            DGVKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động lấp đầy

            DGVKhachHang.Columns.Add("MaKH", "Mã khách hàng");
            DGVKhachHang.Columns["MaKH"].FillWeight = 10;

            DGVKhachHang.Columns.Add("TenKH", "Họ và Tên");
            DGVKhachHang.Columns["TenKH"].FillWeight = 10;

            DGVKhachHang.Columns.Add("Email", "Email");
            DGVKhachHang.Columns["Email"].FillWeight = 25;

            DGVKhachHang.Columns.Add("SDT", "Số điện thoại");
            DGVKhachHang.Columns["SDT"].FillWeight = 20;

            DGVKhachHang.Columns.Add("NgaySinh", "Ngày sinh");
            DGVKhachHang.Columns["NgaySinh"].FillWeight = 10;

            DGVKhachHang.Columns.Add("TrangThai", "Trạng thái");
            DGVKhachHang.Columns["TrangThai"].FillWeight = 10;

            DGVKhachHang.RowTemplate.Height = 40;

            foreach (KhachHangDTO kh in listKH.Where(k => k.Trangthai == 1))
            {
                DGVKhachHang.Rows.Add(
                    kh.Makh,                         
                    kh.Tenkhachhang,                     
                    kh.Email,                        
                    kh.Sdt,                          
                    kh.Ngaysinh.ToString("dd/MM/yyyy"),
                    "Hoạt động"                      
                );
            }
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Nút"; // Tên cột
            btn.Name = "Actions"; // setName để truy xuất dataGridView1.Columns["button"]
            btn.Text = "Hit me"; // Text của button
            btn.UseColumnTextForButtonValue = true; // true để mỗi row đều hiện
            DGVKhachHang.Columns.Add(btn);
            DGVKhachHang.Columns["Actions"].FillWeight = 15;

        }

        private void refreshDataGridView(BindingList<KhachHangDTO> listRefresh) // Tải lại DataGridView
        {
            DGVKhachHang.Rows.Clear();

            foreach (KhachHangDTO kh in listRefresh.Where(kh => kh.Trangthai == 1))
            {
                DGVKhachHang.Rows.Add(kh.Makh, kh.Tenkhachhang, kh.Email, kh.Sdt
                , kh.Ngaysinh.ToString("dd/MM/yyyy"), "Hoạt động");
            }
            DGVKhachHang.ClearSelection();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddKhachHangForm addKH = new AddKhachHangForm();
            addKH.ShowDialog();
            if (addKH.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(khBUS.getListKH());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }
    }
}
