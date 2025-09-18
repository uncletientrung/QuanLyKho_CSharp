using QuanLyKho_CSharp.DTO;
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
            txtMasp.Text= sp.Masp.ToString();
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
