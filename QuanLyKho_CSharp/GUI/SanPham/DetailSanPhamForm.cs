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
    public partial class DetailSanPhamForm : Form
    {
        SanPhamDTO sp;
        public DetailSanPhamForm(SanPhamDTO _sp)
        {
            this.sp = _sp;
            InitializeComponent();
        }

        public void detailSanPhamLoad(object sender, EventArgs e)
        {
            Image imgSanpham = LoadImageSafe(sp.Hinhanh);
            picHinhanh.Image = imgSanpham;
            picHinhanh.SizeMode=PictureBoxSizeMode.StretchImage;
            txtMasp.Text= "SP-"+sp.Masp.ToString();
            txtMasp.Enabled= false;
            txtTensp.Text= sp.Tensp.ToString();
            txtTensp.Enabled= false;
            txtSoluong.Text= sp.Soluong.ToString();
            txtSoluong.Enabled= false;
            txtDongia.Text= sp.Dongia.ToString();
            txtDongia.Enabled= false;
            txtMachatlieu.Text= sp.Machatlieu.ToString();
            txtMachatlieu.Enabled= false;
            txtMaloai.Text= sp.Maloai.ToString();
            txtMaloai.Enabled= false;
            txtMakhuvuc.Text= sp.Makhuvuc.ToString();
            txtMakhuvuc.Enabled= false;
            txtMasize.Text= sp.Masize.ToString();
            txtMasize.Enabled= false;
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
