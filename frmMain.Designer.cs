using System.Drawing;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace QuanLyKho_CSharp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlLeftMenu = new System.Windows.Forms.Panel();
            this.panelQuanLyHeThong = new System.Windows.Forms.Panel();
            this.btnPhanQuyen = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnQuanLyHeThong = new System.Windows.Forms.Button();
            this.panelDanhMuc = new System.Windows.Forms.Panel();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.btnKhuVuc = new System.Windows.Forms.Button();
            this.btnLoai = new System.Windows.Forms.Button();
            this.btnSize = new System.Windows.Forms.Button();
            this.btnChatLieu = new System.Windows.Forms.Button();
            this.btnNhaCungCap = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.panelQuanLyKho = new System.Windows.Forms.Panel();
            this.btnKiemKe = new System.Windows.Forms.Button();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.btnPhieuXuat = new System.Windows.Forms.Button();
            this.btnTonKho = new System.Windows.Forms.Button();
            this.btnquanlykho = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.panelAvatar = new System.Windows.Forms.Panel();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.avatar_Logout = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.mySqlCommandBuilder1 = new MySqlConnector.MySqlCommandBuilder();
            this.pnlLeftMenu.SuspendLayout();
            this.panelQuanLyHeThong.SuspendLayout();
            this.panelDanhMuc.SuspendLayout();
            this.panelThongTin.SuspendLayout();
            this.panelQuanLyKho.SuspendLayout();
            this.panelAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_Logout)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeftMenu
            // 
            this.pnlLeftMenu.AutoScroll = true;
            this.pnlLeftMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeftMenu.Controls.Add(this.panelQuanLyHeThong);
            this.pnlLeftMenu.Controls.Add(this.btnQuanLyHeThong);
            this.pnlLeftMenu.Controls.Add(this.panelDanhMuc);
            this.pnlLeftMenu.Controls.Add(this.btnDanhMuc);
            this.pnlLeftMenu.Controls.Add(this.panelQuanLyKho);
            this.pnlLeftMenu.Controls.Add(this.btnquanlykho);
            this.pnlLeftMenu.Controls.Add(this.btnTrangChu);
            this.pnlLeftMenu.Controls.Add(this.panelAvatar);
            this.pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeftMenu.Name = "pnlLeftMenu";
            this.pnlLeftMenu.Size = new System.Drawing.Size(236, 729);
            this.pnlLeftMenu.TabIndex = 0;
            this.pnlLeftMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeftMenu_Paint);
            // 
            // panelQuanLyHeThong
            // 
            this.panelQuanLyHeThong.Controls.Add(this.btnPhanQuyen);
            this.panelQuanLyHeThong.Controls.Add(this.btnTaiKhoan);
            this.panelQuanLyHeThong.Controls.Add(this.btnNhanVien);
            this.panelQuanLyHeThong.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuanLyHeThong.Location = new System.Drawing.Point(0, 737);
            this.panelQuanLyHeThong.Margin = new System.Windows.Forms.Padding(0);
            this.panelQuanLyHeThong.Name = "panelQuanLyHeThong";
            this.panelQuanLyHeThong.Size = new System.Drawing.Size(219, 137);
            this.panelQuanLyHeThong.TabIndex = 9;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhanQuyen.Image = ((System.Drawing.Image)(resources.GetObject("btnPhanQuyen.Image")));
            this.btnPhanQuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanQuyen.Location = new System.Drawing.Point(0, 90);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPhanQuyen.Size = new System.Drawing.Size(219, 45);
            this.btnPhanQuyen.TabIndex = 12;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.UseVisualStyleBackColor = true;
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 45);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTaiKhoan.Size = new System.Drawing.Size(219, 45);
            this.btnTaiKhoan.TabIndex = 11;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.Image")));
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 0);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNhanVien.Size = new System.Drawing.Size(219, 45);
            this.btnNhanVien.TabIndex = 8;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnQuanLyHeThong
            // 
            this.btnQuanLyHeThong.BackColor = System.Drawing.Color.Gainsboro;
            this.btnQuanLyHeThong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnQuanLyHeThong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyHeThong.ForeColor = System.Drawing.Color.Black;
            this.btnQuanLyHeThong.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyHeThong.Image")));
            this.btnQuanLyHeThong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyHeThong.Location = new System.Drawing.Point(0, 692);
            this.btnQuanLyHeThong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyHeThong.Name = "btnQuanLyHeThong";
            this.btnQuanLyHeThong.Size = new System.Drawing.Size(219, 45);
            this.btnQuanLyHeThong.TabIndex = 8;
            this.btnQuanLyHeThong.Text = "Quản lý hệ thống";
            this.btnQuanLyHeThong.UseVisualStyleBackColor = false;
            this.btnQuanLyHeThong.Click += new System.EventHandler(this.btnQuanLyHeThong_Click);
            // 
            // panelDanhMuc
            // 
            this.panelDanhMuc.Controls.Add(this.btnBaoCao);
            this.panelDanhMuc.Controls.Add(this.btnKhachHang);
            this.panelDanhMuc.Controls.Add(this.panelThongTin);
            this.panelDanhMuc.Controls.Add(this.btnThongTin);
            this.panelDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDanhMuc.Location = new System.Drawing.Point(0, 376);
            this.panelDanhMuc.Margin = new System.Windows.Forms.Padding(0);
            this.panelDanhMuc.Name = "panelDanhMuc";
            this.panelDanhMuc.Size = new System.Drawing.Size(219, 316);
            this.panelDanhMuc.TabIndex = 7;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCao.Image")));
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 279);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(0);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBaoCao.Size = new System.Drawing.Size(219, 35);
            this.btnBaoCao.TabIndex = 10;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.Image")));
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 239);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKhachHang.Size = new System.Drawing.Size(219, 40);
            this.btnKhachHang.TabIndex = 7;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // panelThongTin
            // 
            this.panelThongTin.Controls.Add(this.btnKhuVuc);
            this.panelThongTin.Controls.Add(this.btnLoai);
            this.panelThongTin.Controls.Add(this.btnSize);
            this.panelThongTin.Controls.Add(this.btnChatLieu);
            this.panelThongTin.Controls.Add(this.btnNhaCungCap);
            this.panelThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongTin.Location = new System.Drawing.Point(0, 40);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Size = new System.Drawing.Size(219, 199);
            this.panelThongTin.TabIndex = 7;
            // 
            // btnKhuVuc
            // 
            this.btnKhuVuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhuVuc.Image = ((System.Drawing.Image)(resources.GetObject("btnKhuVuc.Image")));
            this.btnKhuVuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuVuc.Location = new System.Drawing.Point(0, 160);
            this.btnKhuVuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhuVuc.Name = "btnKhuVuc";
            this.btnKhuVuc.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnKhuVuc.Size = new System.Drawing.Size(219, 40);
            this.btnKhuVuc.TabIndex = 11;
            this.btnKhuVuc.Text = "Khu Vực";
            this.btnKhuVuc.UseVisualStyleBackColor = true;
            // 
            // btnLoai
            // 
            this.btnLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoai.Image = ((System.Drawing.Image)(resources.GetObject("btnLoai.Image")));
            this.btnLoai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoai.Location = new System.Drawing.Point(0, 120);
            this.btnLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoai.Name = "btnLoai";
            this.btnLoai.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnLoai.Size = new System.Drawing.Size(219, 40);
            this.btnLoai.TabIndex = 10;
            this.btnLoai.Text = "Loại";
            this.btnLoai.UseVisualStyleBackColor = true;
            // 
            // btnSize
            // 
            this.btnSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSize.Image = ((System.Drawing.Image)(resources.GetObject("btnSize.Image")));
            this.btnSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSize.Location = new System.Drawing.Point(0, 80);
            this.btnSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSize.Name = "btnSize";
            this.btnSize.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnSize.Size = new System.Drawing.Size(219, 40);
            this.btnSize.TabIndex = 9;
            this.btnSize.Text = "Size";
            this.btnSize.UseVisualStyleBackColor = true;
            // 
            // btnChatLieu
            // 
            this.btnChatLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChatLieu.Image = ((System.Drawing.Image)(resources.GetObject("btnChatLieu.Image")));
            this.btnChatLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChatLieu.Location = new System.Drawing.Point(0, 40);
            this.btnChatLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChatLieu.Name = "btnChatLieu";
            this.btnChatLieu.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnChatLieu.Size = new System.Drawing.Size(219, 40);
            this.btnChatLieu.TabIndex = 8;
            this.btnChatLieu.Text = "Chất liệu";
            this.btnChatLieu.UseVisualStyleBackColor = true;
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhaCungCap.Image = ((System.Drawing.Image)(resources.GetObject("btnNhaCungCap.Image")));
            this.btnNhaCungCap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.btnNhaCungCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnNhaCungCap.Size = new System.Drawing.Size(219, 40);
            this.btnNhaCungCap.TabIndex = 7;
            this.btnNhaCungCap.Text = "Nhà cung cấp";
            this.btnNhaCungCap.UseVisualStyleBackColor = true;
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongTin.Image = ((System.Drawing.Image)(resources.GetObject("btnThongTin.Image")));
            this.btnThongTin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTin.Location = new System.Drawing.Point(0, 0);
            this.btnThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnThongTin.Size = new System.Drawing.Size(219, 40);
            this.btnThongTin.TabIndex = 6;
            this.btnThongTin.Text = "Thông tin";
            this.btnThongTin.UseVisualStyleBackColor = true;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDanhMuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.btnDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhMuc.Image")));
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 336);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(219, 40);
            this.btnDanhMuc.TabIndex = 6;
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // panelQuanLyKho
            // 
            this.panelQuanLyKho.Controls.Add(this.btnKiemKe);
            this.panelQuanLyKho.Controls.Add(this.btnPhieuNhap);
            this.panelQuanLyKho.Controls.Add(this.btnPhieuXuat);
            this.panelQuanLyKho.Controls.Add(this.btnTonKho);
            this.panelQuanLyKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuanLyKho.Location = new System.Drawing.Point(0, 174);
            this.panelQuanLyKho.Name = "panelQuanLyKho";
            this.panelQuanLyKho.Size = new System.Drawing.Size(219, 162);
            this.panelQuanLyKho.TabIndex = 5;
            // 
            // btnKiemKe
            // 
            this.btnKiemKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKiemKe.Image = ((System.Drawing.Image)(resources.GetObject("btnKiemKe.Image")));
            this.btnKiemKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKiemKe.Location = new System.Drawing.Point(0, 120);
            this.btnKiemKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKiemKe.Name = "btnKiemKe";
            this.btnKiemKe.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKiemKe.Size = new System.Drawing.Size(219, 40);
            this.btnKiemKe.TabIndex = 9;
            this.btnKiemKe.Text = "Kiểm kê";
            this.btnKiemKe.UseVisualStyleBackColor = true;
            this.btnKiemKe.Click += new System.EventHandler(this.btnKiemKe_Click);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieuNhap.Image")));
            this.btnPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhieuNhap.Location = new System.Drawing.Point(0, 80);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPhieuNhap.Size = new System.Drawing.Size(219, 40);
            this.btnPhieuNhap.TabIndex = 4;
            this.btnPhieuNhap.Text = "Nhập hàng";
            this.btnPhieuNhap.UseVisualStyleBackColor = true;
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieuXuat.Image")));
            this.btnPhieuXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhieuXuat.Location = new System.Drawing.Point(0, 40);
            this.btnPhieuXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPhieuXuat.Size = new System.Drawing.Size(219, 40);
            this.btnPhieuXuat.TabIndex = 5;
            this.btnPhieuXuat.Text = "Xuất hàng";
            this.btnPhieuXuat.UseVisualStyleBackColor = true;
            this.btnPhieuXuat.Click += new System.EventHandler(this.btnPhieuXuat_Click);
            // 
            // btnTonKho
            // 
            this.btnTonKho.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTonKho.Image = ((System.Drawing.Image)(resources.GetObject("btnTonKho.Image")));
            this.btnTonKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTonKho.Location = new System.Drawing.Point(0, 0);
            this.btnTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTonKho.Size = new System.Drawing.Size(219, 40);
            this.btnTonKho.TabIndex = 3;
            this.btnTonKho.Text = "Tồn kho";
            this.btnTonKho.UseVisualStyleBackColor = false;
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // btnquanlykho
            // 
            this.btnquanlykho.BackColor = System.Drawing.Color.Gainsboro;
            this.btnquanlykho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnquanlykho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnquanlykho.ForeColor = System.Drawing.Color.Black;
            this.btnquanlykho.Image = ((System.Drawing.Image)(resources.GetObject("btnquanlykho.Image")));
            this.btnquanlykho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnquanlykho.Location = new System.Drawing.Point(0, 134);
            this.btnquanlykho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnquanlykho.Name = "btnquanlykho";
            this.btnquanlykho.Size = new System.Drawing.Size(219, 40);
            this.btnquanlykho.TabIndex = 4;
            this.btnquanlykho.Text = "Quản lý kho";
            this.btnquanlykho.UseVisualStyleBackColor = false;
            this.btnquanlykho.Click += new System.EventHandler(this.btnQuanLyKho_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTrangChu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.ForeColor = System.Drawing.Color.Black;
            this.btnTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Image")));
            this.btnTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 94);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(219, 40);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // panelAvatar
            // 
            this.panelAvatar.Controls.Add(this.avatar);
            this.panelAvatar.Controls.Add(this.lbUser);
            this.panelAvatar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAvatar.Location = new System.Drawing.Point(0, 0);
            this.panelAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.panelAvatar.Name = "panelAvatar";
            this.panelAvatar.Size = new System.Drawing.Size(219, 94);
            this.panelAvatar.TabIndex = 3;
            // 
            // avatar
            // 
            this.avatar.Dock = System.Windows.Forms.DockStyle.Top;
            this.avatar.Image = ((System.Drawing.Image)(resources.GetObject("avatar.Image")));
            this.avatar.InitialImage = null;
            this.avatar.Location = new System.Drawing.Point(0, 0);
            this.avatar.Margin = new System.Windows.Forms.Padding(0);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(219, 78);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(79, 77);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(49, 17);
            this.lbUser.TabIndex = 2;
            this.lbUser.Text = "Hi, user";
            this.lbUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.avatar_Logout);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(236, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1129, 94);
            this.pnlTop.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.Location = new System.Drawing.Point(1019, 21);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 37);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // avatar_Logout
            // 
            this.avatar_Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avatar_Logout.Image = ((System.Drawing.Image)(resources.GetObject("avatar_Logout.Image")));
            this.avatar_Logout.Location = new System.Drawing.Point(1000, 21);
            this.avatar_Logout.Name = "avatar_Logout";
            this.avatar_Logout.Size = new System.Drawing.Size(42, 37);
            this.avatar_Logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar_Logout.TabIndex = 0;
            this.avatar_Logout.TabStop = false;
            this.avatar_Logout.Click += new System.EventHandler(this.avatar_Logout_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(236, 94);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1129, 635);
            this.pnlBody.TabIndex = 2;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // mySqlCommandBuilder1
            // 
            this.mySqlCommandBuilder1.DataAdapter = null;
            this.mySqlCommandBuilder1.QuotePrefix = "`";
            this.mySqlCommandBuilder1.QuoteSuffix = "`";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1365, 729);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeftMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlLeftMenu.ResumeLayout(false);
            this.panelQuanLyHeThong.ResumeLayout(false);
            this.panelDanhMuc.ResumeLayout(false);
            this.panelThongTin.ResumeLayout(false);
            this.panelQuanLyKho.ResumeLayout(false);
            this.panelAvatar.ResumeLayout(false);
            this.panelAvatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_Logout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftMenu;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox avatar_Logout;
        private System.Windows.Forms.Panel pnlBody;
        private Button btnPhanQuyen;
        private Button btnTrangChu;
        private Button btnTaiKhoan;
        private Button btnTonKho;
        private Button btnBaoCao;
        private Button btnPhieuNhap;
        private Button btnKiemKe;
        private Button btnPhieuXuat;
        private Button btnNhanVien;
        private Button btnThongTin;
        private Button btnKhachHang;
        private Panel panelAvatar;
        private Panel panelQuanLyKho;
        private Button btnquanlykho;
        private Panel panelDanhMuc;
        private Button btnDanhMuc;
        private Button btnQuanLyHeThong;
        private MySqlConnector.MySqlCommandBuilder mySqlCommandBuilder1;
        private Panel panelQuanLyHeThong;
        private Panel panelThongTin;
        private Button btnChatLieu;
        private Button btnNhaCungCap;
        private Button btnKhuVuc;
        private Button btnLoai;
        private Button btnSize;
    }
}