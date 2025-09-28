using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.SanPham;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI
{
    public partial class SanPhamGUI : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private BindingList<SanPhamDTO> listSP;

        public SanPhamGUI()
        {
            

            InitializeComponent();
            ConfigureDataGridView();

            listSP = spBUS.getListSP();
            

            // Gọi setup ngay trong constructor thay vì đợi Load event
            SetupColumnsAndLoadData();
        }

        private void ConfigureDataGridView()
        {
            dgvSanPham.ClearSelection();
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.AllowUserToResizeRows = false;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanPham.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Đăng ký events
            dgvSanPham.CellPainting += dgvSanPham_CellPainting;
            dgvSanPham.CellMouseClick += dgvSanPham_CellMouseClick;
        }

        private void SetupColumnsAndLoadData()
        {
           

            try
            {
                // Clear existing columns first
                dgvSanPham.Columns.Clear();

                dgvSanPham.Columns.Add("MaSP", "Mã SP");
                dgvSanPham.Columns["MaSP"].Width = 50;

                dgvSanPham.Columns.Add("TenSP", "Tên sản phẩm");
                dgvSanPham.Columns["TenSP"].Width = 210;

                // Cột ảnh 
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.Name = "HinhAnh";
                imgCol.HeaderText = "Ảnh";
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgCol.Width = 130;
                dgvSanPham.Columns.Add(imgCol);

                dgvSanPham.RowTemplate.Height = 40;

                dgvSanPham.Columns.Add("SoLuong", "Số lượng");
                dgvSanPham.Columns["SoLuong"].Width = 100;

                dgvSanPham.Columns.Add("Gia", "Đơn giá");
                dgvSanPham.Columns["Gia"].Width = 100;

                dgvSanPham.Columns.Add("Machatlieu", "Chất liệu");
                dgvSanPham.Columns["Machatlieu"].Width = 80;

                dgvSanPham.Columns.Add("Loai", "Loại");
                dgvSanPham.Columns["Loai"].Width = 80;

                dgvSanPham.Columns.Add("Khuvuc", "Khu vực");
                dgvSanPham.Columns["Khuvuc"].Width = 170;

                dgvSanPham.Columns.Add("Size", "Size");
                dgvSanPham.Columns["Size"].Width = 60;

                // Thêm cột hành động
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Hành động";
                btn.Name = "Actions";
                dgvSanPham.Columns.Add(btn);
                dgvSanPham.Columns["Actions"].Width = 150;

               
                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndLoadData: {ex.Message}", "Debug Error");
            }
        }

        private void SanPhamGUI_Load(object sender, EventArgs e)
        {
            

            // Nếu chưa setup thì setup ở đây
            if (dgvSanPham.Columns.Count == 0)
            {
                SetupColumnsAndLoadData();
            }
        }

        private void LoadDataToGrid()
        {
            try
            {
                // Always fetch the latest data from the database
                listSP = spBUS.getListSP();

                dgvSanPham.Rows.Clear();

                if (listSP == null || listSP.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Debug - No Data");
                    return;
                }

                foreach (SanPhamDTO sp in listSP)
                {
                    Image img = LoadImageSafe(sp.Hinhanh);

                    dgvSanPham.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        img,
                        sp.Soluong,
                        sp.Dongia,
                        sp.Machatlieu,
                        sp.Maloai,
                        sp.Makhuvuc,
                        sp.Masize
                    );
                }

                dgvSanPham.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }

        // Giữ nguyên tất cả methods khác
        private Image LoadImageSafe(string relativePath)
        {
            try
            {
                if (string.IsNullOrEmpty(relativePath))
                {
                    Console.WriteLine("Đường dẫn rỗng, trả về ảnh mặc định.");
                    return Properties.Resources.no_image;
                }

                string path = Path.Combine(Application.StartupPath, relativePath.Replace("/", "\\"));

                if (!File.Exists(path))
                {
                    string alt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", relativePath.Replace("/", "\\"));
                    alt = Path.GetFullPath(alt);
                    if (File.Exists(alt))
                    {
                        path = alt;
                    }
                    else
                    {
                        Console.WriteLine($"File không tồn tại: {path}");
                        return Properties.Resources.no_image;
                    }
                }

                byte[] bytes = File.ReadAllBytes(path);
                using (var ms = new MemoryStream(bytes))
                {
                    Image im = Image.FromStream(ms);
                    return new Bitmap(im);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải ảnh {relativePath}: {ex.Message}");
                return Properties.Resources.no_image;
            }
        }

       

        private void dgvSanPham_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvSanPham.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (e.CellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
                Rectangle btnSua = new Rectangle(e.CellBounds.Left + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXoa = new Rectangle(btnSua.Right + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);
                Rectangle btnXem = new Rectangle(btnXoa.Right + padding, e.CellBounds.Top + padding, buttonWidth, e.CellBounds.Height - 2 * padding);

                ButtonRenderer.DrawButton(e.Graphics, btnXem, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnSua, "", this.Font, false, PushButtonState.Normal);
                ButtonRenderer.DrawButton(e.Graphics, btnXoa, "", this.Font, false, PushButtonState.Normal);

                try
                {
                    Image imgSua = LoadImageSafe("images/icon/edit.png");
                    Image imgXoa = LoadImageSafe("images/icon/remove.png");
                    Image imgXem = LoadImageSafe("images/icon/detail.png");

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
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
                }

                e.Handled = true;
            }
        }

        private void dgvSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvSanPham.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (dgvSanPham.Columns["Actions"].Width - padding * (totalButtons + 1)) / totalButtons;
                int xRel = e.Location.X;
                int masp = int.Parse(dgvSanPham.Rows[e.RowIndex].Cells["masp"].Value.ToString());
                SanPhamDTO spduocchon = spBUS.getSPById(masp);
                if (xRel < padding + buttonWidth) // kiểm tra trên tọa độ x
                {
                    UpdateSanPhamForm updateSanPham = new UpdateSanPhamForm(spduocchon);
                    updateSanPham.ShowDialog();
                    if (updateSanPham.DialogResult == DialogResult.OK)
                    {
                        LoadDataToGrid();
                        UpdateSuccessNotification tb = new UpdateSuccessNotification();
                        tb.Show();
                    }

                }
                else if (xRel < padding * 2 + buttonWidth * 2)
                {
                    //DeleteNhanVienForm deleteNV = new DeleteNhanVienForm(spduocchon);
                    //deleteNV.ShowDialog();
                    //if (deleteNV.DialogResult == DialogResult.OK)
                    //{

                    //    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    //    tb.Show();
                    //    LoadDataToGrid();
                    //}
                }
                else
                {
                   


                    DetailSanPhamForm detailSanPham = new DetailSanPhamForm(spduocchon);
                    detailSanPham.ShowDialog();
                    if (detailSanPham.DialogResult == DialogResult.OK)
                    {
                        LoadDataToGrid();
                        UpdateSuccessNotification tb = new UpdateSuccessNotification();
                        tb.Show();
                    }


                }

            }
        
        }


        private void LoadDataToGridFind(BindingList<SanPhamDTO> newList)
        {
            try
            {
                
                

                dgvSanPham.Rows.Clear();

                if (listSP == null || listSP.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Debug - No Data");
                    return;
                }

                foreach (SanPhamDTO sp in newList)
                {
                    Image img = LoadImageSafe(sp.Hinhanh);

                    dgvSanPham.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        img,
                        sp.Soluong,
                        sp.Dongia,
                        sp.Machatlieu,
                        sp.Maloai,
                        sp.Makhuvuc,
                        sp.Masize
                    );
                }

                dgvSanPham.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtTimKiem.Text.Trim();
            BindingList<SanPhamDTO> listSP = spBUS.TimkiemSanPham(searchString);
            LoadDataToGridFind(listSP);
        }
    }
}