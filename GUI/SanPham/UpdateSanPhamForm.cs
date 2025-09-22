using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.BUS;
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
                if (string.IsNullOrEmpty(relativePath))
                {
                    MessageBox.Show(
                             "Khong load duoc hinh, su dung hinh anh mac dinh!",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
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
                        MessageBox.Show(
                             $"file khong ton tai! {path}",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
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

                MessageBox.Show(
                             $"loi khi tai anh! {relativePath}: {ex.Message}",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
                return Properties.Resources.no_image;
            }
        }

        private void chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh mới lên Pic bõ
                picHinhanh.Image = Image.FromFile(open.FileName);

                // Đường dẫn ảnh người dùng chọn
                string fileNguon = open.FileName;

                // Tạo đường dẫn đích trong thư mục dự án
                string thuMucDich = Path.Combine(Application.StartupPath, "images", "stocks");
                if (!Directory.Exists(thuMucDich))
                    Directory.CreateDirectory(thuMucDich);

                // Lấy tên file của ảnh cũ từ sp.Hinhanh (e.g., "images/stocks/ao1.png")
                string tenFileCu = Path.GetFileName(sp.Hinhanh); // Lấy tên file từ đường dẫn hiện tại
                string fileDich;

                // Nếu sản phẩm đã có ảnh, sử dụng tên file cũ; nếu không, tạo tên file mới
                if (!string.IsNullOrEmpty(tenFileCu) && File.Exists(Path.Combine(thuMucDich, tenFileCu)))
                {
                    fileDich = Path.Combine(thuMucDich, tenFileCu); // Sử dụng tên file cũ
                }
                else
                {
                    // Nếu không có ảnh cũ, sử dụng tên file mới
                    tenFileCu = Path.GetFileName(fileNguon);
                    fileDich = Path.Combine(thuMucDich, tenFileCu);
                }

                // Xóa file cũ nếu tồn tại
                if (File.Exists(fileDich))
                {
                    try
                    {
                        // Giải phóng tài nguyên ảnh trong pix box trước khi xóa
                        if (picHinhanh.Image != null)
                        {
                            picHinhanh.Image.Dispose();
                            picHinhanh.Image = null;
                        }
                        File.Delete(fileDich);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể xóa ảnh cũ: {ex.Message}");
                        return;
                    }
                }

                // Copy ảnh mới vào thư mục đích với tên file cũ
                try
                {
                    File.Copy(fileNguon, fileDich, true);
                    duongDanAnhMoi = $"images/stocks/{tenFileCu}"; // Lưu đường dẫn tương đối
                    picHinhanh.Image = Image.FromFile(fileDich); // Tải lại ảnh vào pix box
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
            txtMaChatLieu.Text=sp.Machatlieu.ToString();
            txtMaKhuVuc.Text=sp.Makhuvuc.ToString();
            txtMaLoai.Text=sp.Maloai.ToString();    
            txtMaSize.Text=sp.Masize.ToString();

           
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

                        }
                        else
                        {
                            int maChatLieuMoi;
                            if (!int.TryParse(txtMaChatLieu.Text, out maChatLieuMoi))
                            {
                                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu");
                                txtMaChatLieu.Focus();
                                return;
                            }
                            else
                            {
                                int maLoaiMoi;
                                if (!int.TryParse(txtMaLoai.Text, out maLoaiMoi))
                                {
                                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu");
                                    txtMaLoai.Focus();
                                    return;
                                }
                                else
                                {
                                    int maKhuVucMoi;
                                    if (!int.TryParse(txtMaKhuVuc.Text, out maKhuVucMoi))
                                    {
                                        MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu");
                                        txtMaKhuVuc.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        int maSizeMoi;
                                        if (!int.TryParse(txtMaSize.Text, out maSizeMoi))
                                        {
                                            MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu");
                                            txtMaSize.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            string duongDanLuuDB = duongDanAnhMoi ?? sp.Hinhanh;
                                            SanPhamDTO sanPhamUpdate= new SanPhamDTO(sp.Masp,tenSanPhamMoi,duongDanLuuDB,soLuongMoi,donGiaMoi,maChatLieuMoi,maLoaiMoi,maKhuVucMoi,maSizeMoi);
                                            spBUS.updateSanPham(sanPhamUpdate);
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();

                                        }
                                    }
                                }
                            }

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
