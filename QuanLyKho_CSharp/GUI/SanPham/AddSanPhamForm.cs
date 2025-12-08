using QuanLyKho.BUS;
using QuanLyKho.DTO;
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

namespace QuanLyKho_CSharp.GUI.SanPham
{
    public partial class AddSanPhamForm : Form
    {

        SanPhamDTO sp;
        private SanPhamBUS spBUS = new SanPhamBUS();
        private KhuVucKhoBUS kvBUS = new KhuVucKhoBUS();
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        private SizeBUS sizeBUS = new SizeBUS();

        private BindingList<KhuVucKhoDTO> listKV;
        private BindingList<ChatLieuDTO> listCL;
        private BindingList<LoaiDTO> listLoai;
        private BindingList<SizeDTO> listSize;
        private string duongDanAnhMoi = null;

        private Image imgSanpham;
        public AddSanPhamForm()
        {
            InitializeComponent();

        }

        private Image LoadImageSafe(string relativePath)
        {
            try
            {
                // Nếu chuỗi rỗng thì báo lỗi và dùng ảnh mặc định
                if (string.IsNullOrEmpty(relativePath))
                {
                    MessageBox.Show(
                        "Không load được hình, sử dụng hình mặc định!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
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
                MessageBox.Show(
                    $"Lỗi khi tải ảnh: {relativePath}\nChi tiết: {ex.Message}",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            open.Title = "Chọn ảnh sản phẩm";

            if (open.ShowDialog() == DialogResult.OK)
            {
                // Kiểm tra kích thước file (ví dụ: giới hạn 5MB)
                FileInfo fileInfo = new FileInfo(open.FileName);
                if (fileInfo.Length > 5 * 1024 * 1024) // 5MB
                {
                    MessageBox.Show("Ảnh quá lớn! Vui lòng chọn ảnh dưới 5MB.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị ảnh lên PictureBox
                try
                {
                    picHinhanh.Image?.Dispose(); // Giải phóng ảnh cũ nếu có
                    picHinhanh.Image = Image.FromFile(open.FileName);

                    // Đường dẫn file nguồn
                    string fileNguon = open.FileName;

                    // Thư mục đích
                    string thuMucDich = Path.Combine(Application.StartupPath, "images", "stocks");
                    if (!Directory.Exists(thuMucDich))
                        Directory.CreateDirectory(thuMucDich);

                    // Tạo tên file mới để tránh trùng lặp
                    string tenFileMoi = Path.GetFileNameWithoutExtension(fileNguon) + "_" + DateTime.Now.Ticks + Path.GetExtension(fileNguon);
                    string fileDich = Path.Combine(thuMucDich, tenFileMoi);

                    // Sao chép file
                    File.Copy(fileNguon, fileDich, false);
                    duongDanAnhMoi = $"images/stocks/{tenFileMoi}";
                    imgSanpham = LoadImageSafe(duongDanAnhMoi);
                    picHinhanh.Image = imgSanpham;
                    picHinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    //MessageBox.Show("Đã chọn ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            // xu ly ma bang return som
            //if (string.IsNullOrWhiteSpace(txtMaSanPham.Text))
            //{
            //    MessageBox.Show(
            //        "Mã sản phẩm không được để trống!",
            //        "Lỗi dữ liệu",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );
            //    return;
            //}

            //if (!int.TryParse(txtMaSanPham.Text, out int maSp))
            //{
            //    MessageBox.Show(
            //        "Mã sản phẩm phải là số nguyên!",
            //        "Lỗi dữ liệu",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );
            //    return;
            //}
            int maSp = (int)txtMaSanPham.Tag;


            SanPhamDTO spTonTai = spBUS.getListSP().FirstOrDefault(sp => sp.Masp == maSp);

            if (spTonTai != null)
            {
                MessageBox.Show(
                   $"Mã sản phẩm này đã tồn tại! Mã: {spTonTai.Masp}",
                   "Lỗi dữ liệu",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                );
                return;
            }

            //xu ly ten
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show(
                    "Tên sản phẩm không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            //xu li solupng

            if(!int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng phải là số!");
                return;
            }

            //xu li don gia
            if(!int.TryParse(txtDonGia.Text, out int donGia)){
                MessageBox.Show("Đơn giá phải là số!");
                return;
            }

            if (picHinhanh.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh cho sản phẩm!");
                return;
            }

            if (cboMaChatLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chất liệu!");
                return;
            }

            if (cboMaKhuVuc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khu vực!");
                return;
            }

            if (cboMaLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!");
                return;
            }

            if (cboMaSize.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn size cho sản phẩm!");
                return;
            }
            int maKhuVuc = int.Parse(cboMaKhuVuc.Text.ToString().Split('.')[0]);
            int maChatLieu = int.Parse(cboMaChatLieu.Text.ToString().Split('.')[0]);
            int maLoai = int.Parse(cboMaLoai.Text.ToString().Split('.')[0]);
            int maSize = int.Parse(cboMaSize.Text.ToString().Split('.')[0]);
            SanPhamDTO sanPham = new SanPhamDTO(maSp, txtTenSanPham.Text,duongDanAnhMoi,soLuong,donGia,maChatLieu,maLoai, maKhuVuc, maSize,1);
            spBUS.insertSanPham(sanPham);
            this.DialogResult = DialogResult.OK;






        }

        private void AddSanPhamForm_Load(object sender, EventArgs e)
        {

            int id = spBUS.getAutoMaSP();
            txtMaSanPham.Text = $"SP-{id}";
            txtMaSanPham.Tag = id;
            txtMaSanPham.Enabled= false;
            listKV = kvBUS.getKhuVucKhoList();
            foreach (KhuVucKhoDTO kv in listKV)
            {
                cboMaKhuVuc.Items.Add(kv.Makhuvuc + ". " + kv.Tenkhuvuc);
                
            }

            listCL = clBUS.getChatLieuList();
            foreach (ChatLieuDTO cl in listCL)
            {
                cboMaChatLieu.Items.Add(cl.Machatlieu + ". " + cl.Tenchatlieu);
                
            }

            listLoai = loaiBUS.getLoaiList();
            foreach (LoaiDTO loai in listLoai)
            {
                cboMaLoai.Items.Add(loai.Maloai + ". " + loai.Tenloai);
                

            }

            listSize = sizeBUS.getSizeList();
            foreach (SizeDTO size in listSize)
            {
                cboMaSize.Items.Add(size.Masize + ". " + size.Tensize);
                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            txtTenSanPham.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            cboMaChatLieu.SelectedIndex = -1;   
            cboMaKhuVuc.SelectedIndex = -1;
            cboMaLoai.SelectedIndex = -1;
            cboMaSize.SelectedIndex = -1;
            picHinhanh.Image = null; 
            txtTenSanPham.Focus();
        }
    }
}
