using QuanLyKho.DTO;
using QuanLyKho.BUS;
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
    public partial class UpdateSanPhamForm : Form
    {
        SanPhamDTO sp;
        private SanPhamBUS spBUS= new SanPhamBUS();
        private KhuVucKhoBUS kvBUS = new KhuVucKhoBUS();
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        private SizeBUS sizeBUS = new SizeBUS();

        private BindingList<KhuVucKhoDTO> listKV;
        private BindingList<ChatLieuDTO> listCL;
        private BindingList<LoaiDTO> listLoai;
        private BindingList<SizeDTO> listSize;

        private string duongDanAnhMoi=null;//tao bien de sau khi bam nut chon anh se lay duoc duong dan
        public UpdateSanPhamForm(SanPhamDTO _sp)
        {
            this.sp= _sp;
            InitializeComponent();
        }




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

       
        private void chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh vừa chọn lên PictureBox
                picHinhanh.Image = Image.FromFile(open.FileName);

                // Đường dẫn file người dùng chọn
                string fileNguon = open.FileName;

                // Thư mục đích trong dự án
                string thuMucDich = Path.Combine(Application.StartupPath, "images", "stocks");
                if (!Directory.Exists(thuMucDich))
                    Directory.CreateDirectory(thuMucDich);

                // Lấy tên file ảnh mới
                string tenFileMoi = Path.GetFileName(fileNguon);
                string fileDich = Path.Combine(thuMucDich, tenFileMoi);

                try
                {
                    // Copy ảnh vào thư mục đích (cho phép ghi đè nếu trùng tên)
                    File.Copy(fileNguon, fileDich, true);

                    // Lưu đường dẫn tương đối
                    duongDanAnhMoi = $"images/stocks/{tenFileMoi}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép ảnh: {ex.Message}");
                }
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateSanPhamForm_Load(object sender, EventArgs e)
        {
            txtMaSanPham.Enabled = false;
            Image imgSanpham = LoadImageSafe(sp.Hinhanh);
            picHinhanh.Image = imgSanpham;
            picHinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
            txtMaSanPham.Text = sp.Masp.ToString();
            txtTenSanPham.Text=sp.Tensp.ToString();
            txtSoLuong.Text=sp.Soluong.ToString();
            txtDonGia.Text=sp.Dongia.ToString();
            


            
            listKV= kvBUS.getKhuVucKhoList();
            foreach(KhuVucKhoDTO kv in listKV)
            {
                cboMaKhuVuc.Items.Add(kv.Makhuvuc + ". "+kv.Tenkhuvuc);
                if (kv.Makhuvuc == sp.Makhuvuc)// dong nay de hien thi cai dang duoc chon len cbo
                {
                    cboMaKhuVuc.SelectedItem = kv.Makhuvuc + ". " + kv.Tenkhuvuc;
                }
            }

            listCL = clBUS.getChatLieuList();
            foreach(ChatLieuDTO cl in listCL)
            {
                cboMaChatLieu.Items.Add(cl.Machatlieu + ". " + cl.Tenchatlieu);
                if(cl.Machatlieu== sp.Machatlieu)
                {
                    cboMaChatLieu.SelectedItem= cl.Machatlieu+". " + cl.Tenchatlieu;
                }
            }

            listLoai= loaiBUS.getLoaiList();
            foreach(LoaiDTO loai in listLoai)
            {
                cboMaLoai.Items.Add(loai.Maloai + ". " + loai.Tenloai);
                if (loai.Maloai == sp.Maloai)
                {
                    cboMaLoai.SelectedItem = loai.Maloai + ". " + loai.Tenloai;
                }

            }

            listSize= sizeBUS.getSizeList();
            foreach(SizeDTO size in listSize)
            {
                cboMaSize.Items.Add(size.Masize + ". " + size.Tensize);
                if (size.Masize == sp.Masize)
                {
                    cboMaSize.SelectedItem = size.Masize + ". " + size.Tensize;
                }
            }


           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham != null)
            {
                string tenSanPhamMoi=txtTenSanPham.Text;
                if(txtSoLuong != null)
                {
                    int soLuongMoi= int.Parse(txtSoLuong.Text);
                    if (soLuongMoi < 0)
                    {
                        MessageBox.Show(
                       "Số lượng không được nhỏ hơn 0!",
                       "Lỗi dữ liệu",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                       );

                    }
                    else
                    {
                        int donGiaMoi= int.Parse(txtDonGia.Text);
                        if(donGiaMoi < 0)
                        {
                            MessageBox.Show(
                           "Đơn giá không được nhỏ hơn 0!",
                           "Lỗi dữ liệu",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);

                        } else {
                            string duongDanLuuDB = duongDanAnhMoi ?? sp.Hinhanh;
                            int maKhuVucMoi = int.Parse(cboMaKhuVuc.Text.ToString().Split('.')[0]);
                            int maChatLieuMoi = int.Parse(cboMaChatLieu.Text.ToString().Split('.')[0]);
                            int maLoaiMoi = int.Parse(cboMaLoai.Text.ToString().Split('.')[0]);
                            int maSizeMoi = int.Parse(cboMaSize.Text.ToString().Split('.')[0]);

                            SanPhamDTO sanPhamUpdate= new SanPhamDTO(sp.Masp,tenSanPhamMoi,duongDanLuuDB,soLuongMoi,donGiaMoi,maChatLieuMoi,maLoaiMoi,maKhuVucMoi,maSizeMoi);
                            spBUS.updateSanPham(sanPhamUpdate);
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                         }
           
                    }
                }
                else
                {
                    MessageBox.Show(
                   "Số lượng không được để trống!",
                   "Lỗi dữ liệu",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
                }

            }
            else
            {
                MessageBox.Show(
               "Tên sản phẩm không được để trống!",
               "Lỗi dữ liệu",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error
               );
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
