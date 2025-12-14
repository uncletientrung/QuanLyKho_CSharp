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
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            open.Title = "Chọn ảnh sản phẩm";

            if (open.ShowDialog() != DialogResult.OK) return;

            FileInfo fi = new FileInfo(open.FileName);
            if (fi.Length > 5 * 1024 * 1024)
            {
                MessageBox.Show("Ảnh quá lớn! Vui lòng chọn ảnh dưới 5MB.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                picHinhanh.Image?.Dispose();
                picHinhanh.Image = Image.FromFile(open.FileName);

               
                string tenFileMoi = Path.GetFileNameWithoutExtension(open.FileName) + "_" + DateTime.Now.Ticks + fi.Extension;

               
                string binFolder = Path.Combine(Application.StartupPath, "images", "stocks");
                if (!Directory.Exists(binFolder)) Directory.CreateDirectory(binFolder);
                string binPath = Path.Combine(binFolder, tenFileMoi);
                File.Copy(open.FileName, binPath, true);

               
                string projectFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\images\\stocks"));
               
                if (!Directory.Exists(projectFolder)) Directory.CreateDirectory(projectFolder);
                string projectPath = Path.Combine(projectFolder, tenFileMoi);
                File.Copy(open.FileName, projectPath, true);  // ← Ảnh sẽ xuất hiện ở đây ngay lập tức

               
                duongDanAnhMoi = $"images/stocks/{tenFileMoi}";

              
                imgSanpham = LoadImageSafe(duongDanAnhMoi);
                picHinhanh.Image = imgSanpham;
                picHinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\nChi tiết: " + ex.StackTrace);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
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

            //xu li don gia
            if(!int.TryParse(txtDonGia.Text, out int donGia)){
                MessageBox.Show("Đơn giá phải là số!");
                return;
            }

            if(donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0!");
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
            int maKhuVuc = kvBUS.LayMaKhuVuc(cboMaKhuVuc.Text);
            int maChatLieu = clBUS.LayMaChatLieu(cboMaChatLieu.Text);
            int maLoai = loaiBUS.LayMaLoai(cboMaLoai.Text);
            int maSize = sizeBUS.LayMaSize(cboMaSize.Text);
            int soLuong = 0;
            SanPhamDTO sanPham = new SanPhamDTO(maSp, txtTenSanPham.Text,duongDanAnhMoi,
                soLuong,donGia,maChatLieu,maLoai, maKhuVuc, maSize,1,
                cboMaLoai.Text, cboMaKhuVuc.Text, cboMaChatLieu.Text, cboMaSize.Text);
            spBUS.insertSanPham(sanPham);
            this.DialogResult = DialogResult.OK;


        }

        private void AddSanPhamForm_Load(object sender, EventArgs e)
        {

            int id = spBUS.getAutoMaSP();
            txtMaSanPham.Text = $"SP-{id}";
            txtMaSanPham.Tag = id;
            txtMaSanPham.Enabled= false;
            txtSoLuong.Text = "0";
            txtSoLuong.Enabled = false;
            listKV = kvBUS.getKhuVucKhoList();
            foreach (KhuVucKhoDTO kv in listKV)
            {
                cboMaKhuVuc.Items.Add(kv.Tenkhuvuc);
                
            }

            listCL = clBUS.getChatLieuList();
            foreach (ChatLieuDTO cl in listCL)
            {
                cboMaChatLieu.Items.Add(cl.Tenchatlieu);
                
            }

            listLoai = loaiBUS.getLoaiList();
            foreach (LoaiDTO loai in listLoai)
            {
                cboMaLoai.Items.Add(loai.Tenloai);
                

            }

            listSize = sizeBUS.getSizeList();
            foreach (SizeDTO size in listSize)
            {
                cboMaSize.Items.Add(size.Tensize);
                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            
            txtTenSanPham.Text = string.Empty;
            txtSoLuong.Text = "0";
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
