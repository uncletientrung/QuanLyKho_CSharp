using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKho_CSharp.GUI
{
    public partial class SanPhamGUI : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private KhuVucKhoBUS khuVucKhoBUS = new KhuVucKhoBUS();
        private ChatLieuBUS chatLieuBUS = new ChatLieuBUS();
        private SizeBUS sizeBUS = new SizeBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<KhuVucKhoDTO> listKV;
        private BindingList<ChatLieuDTO> listCL;
        private BindingList<SizeDTO> listSize;
        private BindingList<LoaiDTO> listLoai;

        public SanPhamGUI()
        {
            

            InitializeComponent();

            ConfigureDataGridView();

            listSP = spBUS.getListSP();
            listKV = khuVucKhoBUS.getKhuVucKhoList();
            listLoai = loaiBUS.getLoaiList();
            listCL = chatLieuBUS.getChatLieuList();
            listSize = sizeBUS.getSizeList();

            // Gọi setup ngay trong constructor thay vì đợi Load event
            SetupColumnsAndLoadData();
            setUpBoxTimKiem();
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
                dgvSanPham.Columns.Clear();

                
                dgvSanPham.Columns.Add("MaSP", "Mã");
                dgvSanPham.Columns.Add("TenSP", "Tên sản phẩm");
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "HinhAnh",
                    HeaderText = "Hình ảnh",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvSanPham.Columns.Add(imgCol);
                dgvSanPham.Columns.Add("SoLuong", "Số lượng");
                dgvSanPham.Columns.Add("Gia", "Đơn giá");
                dgvSanPham.Columns.Add("Machatlieu", "Chất liệu");
                dgvSanPham.Columns.Add("Loai", "Loại");
                dgvSanPham.Columns.Add("Khuvuc", "Khu vực");
                dgvSanPham.Columns.Add("Size", "Size");

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn
                {
                    HeaderText = "Hành động",
                    Name = "Actions"
                };
                dgvSanPham.Columns.Add(btn);

                
                foreach (DataGridViewColumn col in dgvSanPham.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                
                dgvSanPham.Columns["MaSP"].FillWeight = 10;
                dgvSanPham.Columns["TenSP"].FillWeight = 20;
                dgvSanPham.Columns["HinhAnh"].FillWeight = 15;
                dgvSanPham.Columns["SoLuong"].FillWeight = 10;
                dgvSanPham.Columns["Gia"].FillWeight = 10;
                dgvSanPham.Columns["Machatlieu"].FillWeight = 10;
                dgvSanPham.Columns["Loai"].FillWeight = 10;
                dgvSanPham.Columns["Khuvuc"].FillWeight = 15;
                dgvSanPham.Columns["Size"].FillWeight = 10;
                dgvSanPham.Columns["Actions"].FillWeight = 15;

                
                dgvSanPham.Columns["Actions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSanPham.Columns["Actions"].Width = 150;

                dgvSanPham.RowTemplate.Height = 50;

                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong SetupColumnsAndLoadData: {ex.Message}", "Debug Error");
            }
        }

        public void setUpBoxTimKiem()
        {    
            cboLoai.Items.Clear();
            cboLoai.Items.Add("Tất cả");
            foreach (LoaiDTO loai in listLoai)
                cboLoai.Items.Add(loai.Tenloai);
            cboLoai.SelectedIndex = 0;

            cboChatLieu.Items.Clear();
            cboChatLieu.Items.Add("Tất cả");
            foreach (ChatLieuDTO cl in listCL)
                cboChatLieu.Items.Add(cl.Tenchatlieu);
            cboChatLieu.SelectedIndex = 0;


            cboKhuVuc.Items.Clear();
            cboKhuVuc.Items.Add("Tất cả");
            foreach (KhuVucKhoDTO kv in listKV)
                cboKhuVuc.Items.Add(kv.Tenkhuvuc);
            cboKhuVuc.SelectedIndex = 0;


            cboSize.Items.Clear();
            cboSize.Items.Add("Tất cả");
            foreach (SizeDTO s in listSize)
                cboSize.Items.Add(s.Tensize);
            cboSize.SelectedIndex = 0;

            //gan sk de khi thay doi no tim luon
            txtTimKiem.TextChanged += (s, ev) => Filter();
            cboChatLieu.SelectedIndexChanged += (s, ev) => Filter();
            cboLoai.SelectedIndexChanged += (s, ev) => Filter();
            cboKhuVuc.SelectedIndexChanged += (s, ev) => Filter();
            cboSize.SelectedIndexChanged += (s, ev) => Filter();

            // Gọi Filter() để hiển thị dữ liệu ban đầu
            Filter();
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
                listKV = khuVucKhoBUS.getKhuVucKhoList();
                

                dgvSanPham.Rows.Clear();

                if (listSP == null || listSP.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Debug - No Data");
                    return;
                }

                foreach (SanPhamDTO sp in listSP)
                {
                    Image img = LoadImageSafe(sp.Hinhanh);
                    String tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
                    String tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
                    String tenLoai = loaiBUS.LayTenLoai(sp);
                    String tenSize = sizeBUS.LayTenSize(sp);
                    

                    dgvSanPham.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        img,
                        sp.Soluong,
                        sp.Dongia,
                        tenChatLieu,
                        tenLoai,
                        tenKhuVuc,
                        tenSize
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
                // Nếu chuỗi rỗng thì báo lỗi và dùng ảnh mặc định
                if (string.IsNullOrEmpty(relativePath))
                {
                   
                    return LoadDefaultImage();
                }

                // Ghép đường dẫn ảnh theo vị trí chạy thực tế
                string path = Path.Combine(Application.StartupPath, relativePath.Replace("/", "\\"));

                // Nếu không tồn tại thì thử tìm ở cấp cao hơn (khi chạy từ bin/Debug)
                if (!File.Exists(path))
                {
                    string alt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", relativePath.Replace("/", "\\"));
                    alt = Path.GetFullPath(alt);

                    if (File.Exists(alt))
                        path = alt;
                    else
                    {
                        MessageBox.Show(
                            $"File không tồn tại: {path}",
                            "Lỗi dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return LoadDefaultImage();
                    }
                }

                // Đọc file an toàn, tránh giữ file bị lock
                byte[] bytes = File.ReadAllBytes(path);
                using (var ms = new MemoryStream(bytes))
                {
                    Image im = Image.FromStream(ms);
                    return new Bitmap(im);
                }
            }
            catch (Exception ex)
            {
                
                return LoadDefaultImage();
            }
        }

        private Image LoadDefaultImage()
        {
            try
            {
                string defaultPath = Path.Combine(Application.StartupPath, "images", "stocks", "no_image.png");

                // Nếu không có thì thử tìm ở thư mục gốc dự án (trong trường hợp chạy từ bin)
                if (!File.Exists(defaultPath))
                {
                    string alt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\images\\stocks\\no_image.png");
                    alt = Path.GetFullPath(alt);
                    if (File.Exists(alt))
                        defaultPath = alt;
                    else
                        throw new FileNotFoundException("Không tìm thấy ảnh mặc định no_image.png!");
                }

                return Image.FromFile(defaultPath);
            }
            catch
            {
                // Nếu ảnh mặc định cũng không có, trả về ảnh trống
                Bitmap bmp = new Bitmap(100, 100);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.LightGray);
                    g.DrawString("No Image", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, new PointF(10, 40));
                }
                return bmp;
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
                    DeleteSanPhamForm deleteSP = new DeleteSanPhamForm(spduocchon);
                    deleteSP.ShowDialog();
                    if (deleteSP.DialogResult == DialogResult.OK)
                    {

                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                        LoadDataToGrid();
                    }
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
                    String tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
                    String tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
                    String tenLoai = loaiBUS.LayTenLoai(sp);
                    String tenSize = sizeBUS.LayTenSize(sp);

                    dgvSanPham.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        img,
                        sp.Soluong,
                        sp.Dongia,
                        tenChatLieu,
                        tenLoai,
                        tenKhuVuc,
                        tenSize
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
            //string searchString = txtTimKiem.Text.Trim();
            //BindingList<SanPhamDTO> listSP = spBUS.TimkiemSanPham(searchString);
            //LoadDataToGridFind(listSP);
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            AddSanPhamForm addSP = new AddSanPhamForm();
            addSP.ShowDialog();
            if(addSP.DialogResult == DialogResult.OK)
            {
                LoadDataToGrid();
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void Filter()
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            string chatLieu = cboChatLieu.SelectedItem?.ToString();
            string loai = cboLoai.SelectedItem?.ToString();
            string khuVuc = cboKhuVuc.SelectedItem?.ToString();
            string size = cboSize.SelectedItem?.ToString();

            int maLoai = loaiBUS.LayMaLoai(loai);
            int makv = khuVucKhoBUS.LayMaKhuVuc(khuVuc);
            int maCl = chatLieuBUS.LayMaChatLieu(chatLieu);
            int maSize = sizeBUS.LayMaSize(size); 

            var filtered = spBUS.getListSP().Where(sp =>
                (string.IsNullOrEmpty(keyword) || sp.Tensp.ToLower().Contains(keyword)) &&
                (chatLieu == "Tất cả" || maCl == 0 || sp.Machatlieu == maCl) &&
                (loai == "Tất cả" || maLoai == 0 || sp.Maloai == maLoai) &&
                (khuVuc == "Tất cả" || makv == 0 || sp.Makhuvuc == makv) &&
                (size == "Tất cả" || maSize == 0 || sp.Masize == maSize)
            ).ToList();

            BindingList<SanPhamDTO> filteredList = new BindingList<SanPhamDTO>(filtered);
            LoadDataToGridFind(filteredList);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboChatLieu.SelectedIndex = 0;
            cboKhuVuc.SelectedIndex = 0;
            cboLoai.SelectedIndex = 0;
            cboSize.SelectedIndex = 0;
            txtTimKiem.Text= string.Empty;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Application.Workbooks.Add(Type.Missing);

            Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;
            worksheet.Name = "SanPham";//tạo 1 workshet 

            int colIndex = 1;
    
            worksheet.Cells[1, 1] = "DANH SÁCH SẢN PHẨM";
            Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgvSanPham.Columns.Count - 2]];
            titleRange.Merge(); 
            titleRange.Font.Size = 16;
            titleRange.Font.Bold = true;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            
            for (int i = 0; i < dgvSanPham.Columns.Count; i++)
            {
                if (i == 2 || i == 9) continue; 

                worksheet.Cells[2, colIndex] = dgvSanPham.Columns[i].HeaderText;
                colIndex++;
            }

            // định dạng tiêu đề cột
            Excel.Range tieuDeCot = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, colIndex - 1]];
            tieuDeCot.Font.Bold = true;
            tieuDeCot.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
            tieuDeCot.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // ghi du lieu vô 
            int rowIndex = 3;
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (!row.IsNewRow)
                {
                    colIndex = 1;
                    for (int i = 0; i < dgvSanPham.Columns.Count; i++)
                    {
                        if (i == 2 || i == 9) continue; 
                        worksheet.Cells[rowIndex, colIndex] = row.Cells[i].Value?.ToString();
                        colIndex++;
                    }
                    rowIndex++;
                }
            }

            
            worksheet.Columns.AutoFit();// dùng để chỉnh cột cho vừa vặn với nooij dung

            excelApp.Visible = true;
        }
    }
}