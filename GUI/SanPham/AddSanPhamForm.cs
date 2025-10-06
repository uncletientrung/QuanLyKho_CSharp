﻿using QuanLyKho_CSharp.BUS;
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
            if (string.IsNullOrWhiteSpace(txtMaSanPham.Text))
            {
                MessageBox.Show(
                    "Mã sản phẩm không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (!int.TryParse(txtMaSanPham.Text, out int maSp))
            {
                MessageBox.Show(
                    "Mã sản phẩm phải là số nguyên!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }


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
            SanPhamDTO sanPham = new SanPhamDTO(maSp, txtTenSanPham.Text,duongDanAnhMoi,soLuong,donGia,maChatLieu,maLoai, maKhuVuc, maSize);
            spBUS.insertSanPham(sanPham);
            this.DialogResult = DialogResult.OK;






        }

        private void AddSanPhamForm_Load(object sender, EventArgs e)
        {

            txtMaSanPham.Text =  spBUS.getAutoMaSP().ToString();
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
