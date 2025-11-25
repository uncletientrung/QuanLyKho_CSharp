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
            this.panelTop = new System.Windows.Forms.Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhanQuyen = new Guna.UI2.WinForms.Guna2Button();
            this.btnSize = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnLoai = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnChatLieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnKiemKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhuVuc = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuNhap = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhaCungCap = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnTonKho = new Guna.UI2.WinForms.Guna2Button();
            this.btnTrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlName = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lbRole = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLogout = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbPage = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panelTop.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLogout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lbTitle);
            this.panelTop.Controls.Add(this.guna2ControlBox3);
            this.panelTop.Controls.Add(this.guna2ControlBox2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1098, 41);
            this.panelTop.TabIndex = 1;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.CustomIconSize = 20F;
            this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2ControlBox3.Location = new System.Drawing.Point(1006, 0);
            this.guna2ControlBox3.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(46, 41);
            this.guna2ControlBox3.TabIndex = 8;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.CustomIconSize = 20F;
            this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.guna2ControlBox2.Location = new System.Drawing.Point(1052, 0);
            this.guna2ControlBox2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(46, 41);
            this.guna2ControlBox2.TabIndex = 7;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 41);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1098, 688);
            this.pnlBody.TabIndex = 3;
            this.pnlBody.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.BorderRadius = 30;
            this.pnlMenu.Controls.Add(this.flowLayoutPanel1);
            this.pnlMenu.Controls.Add(this.pnlName);
            this.pnlMenu.Controls.Add(this.guna2Shapes1);
            this.pnlMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.pnlMenu.Location = new System.Drawing.Point(-26, 41);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(288, 831);
            this.pnlMenu.TabIndex = 2;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.btnBaoCao.BorderRadius = 10;
            this.btnBaoCao.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCao.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnBaoCao.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnBaoCao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnBaoCao.ImageSize = new System.Drawing.Size(25, 25);
            this.btnBaoCao.Location = new System.Drawing.Point(2, 476);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(211, 30);
            this.btnBaoCao.TabIndex = 49;
            this.btnBaoCao.Text = "Báo cáo thống kê";
            this.btnBaoCao.UseTransparentBackground = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.BackColor = System.Drawing.Color.Transparent;
            this.btnPhanQuyen.BorderRadius = 10;
            this.btnPhanQuyen.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPhanQuyen.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnPhanQuyen.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnPhanQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhanQuyen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnPhanQuyen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanQuyen.ForeColor = System.Drawing.Color.White;
            this.btnPhanQuyen.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhanQuyen.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnPhanQuyen.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPhanQuyen.Location = new System.Drawing.Point(2, 444);
            this.btnPhanQuyen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(211, 30);
            this.btnPhanQuyen.TabIndex = 45;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.UseTransparentBackground = true;
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // btnSize
            // 
            this.btnSize.BackColor = System.Drawing.Color.Transparent;
            this.btnSize.BorderRadius = 10;
            this.btnSize.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSize.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSize.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnSize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSize.ForeColor = System.Drawing.Color.White;
            this.btnSize.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSize.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnSize.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSize.Location = new System.Drawing.Point(2, 342);
            this.btnSize.Margin = new System.Windows.Forms.Padding(2);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(211, 30);
            this.btnSize.TabIndex = 47;
            this.btnSize.Text = "Size";
            this.btnSize.UseTransparentBackground = true;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.BorderRadius = 10;
            this.btnTaiKhoan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTaiKhoan.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTaiKhoan.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnTaiKhoan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnTaiKhoan.ImageSize = new System.Drawing.Size(25, 25);
            this.btnTaiKhoan.Location = new System.Drawing.Point(2, 410);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(211, 30);
            this.btnTaiKhoan.TabIndex = 44;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.UseTransparentBackground = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnLoai
            // 
            this.btnLoai.BackColor = System.Drawing.Color.Transparent;
            this.btnLoai.BorderRadius = 10;
            this.btnLoai.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLoai.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnLoai.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnLoai.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoai.ForeColor = System.Drawing.Color.White;
            this.btnLoai.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLoai.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnLoai.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLoai.Location = new System.Drawing.Point(2, 308);
            this.btnLoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoai.Name = "btnLoai";
            this.btnLoai.Size = new System.Drawing.Size(211, 30);
            this.btnLoai.TabIndex = 46;
            this.btnLoai.Text = "Loại";
            this.btnLoai.UseTransparentBackground = true;
            this.btnLoai.Click += new System.EventHandler(this.btnLoai_Click_1);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.BorderRadius = 10;
            this.btnNhanVien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhanVien.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnNhanVien.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnNhanVien.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnNhanVien.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNhanVien.Location = new System.Drawing.Point(2, 376);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(211, 30);
            this.btnNhanVien.TabIndex = 43;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseTransparentBackground = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.BorderRadius = 10;
            this.btnKhachHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhachHang.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnKhachHang.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhachHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnKhachHang.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnKhachHang.ImageSize = new System.Drawing.Size(25, 25);
            this.btnKhachHang.Location = new System.Drawing.Point(2, 172);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(211, 30);
            this.btnKhachHang.TabIndex = 41;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseTransparentBackground = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnChatLieu
            // 
            this.btnChatLieu.BackColor = System.Drawing.Color.Transparent;
            this.btnChatLieu.BorderRadius = 10;
            this.btnChatLieu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChatLieu.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnChatLieu.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnChatLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChatLieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnChatLieu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChatLieu.ForeColor = System.Drawing.Color.White;
            this.btnChatLieu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChatLieu.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnChatLieu.ImageSize = new System.Drawing.Size(25, 25);
            this.btnChatLieu.Location = new System.Drawing.Point(2, 274);
            this.btnChatLieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnChatLieu.Name = "btnChatLieu";
            this.btnChatLieu.Size = new System.Drawing.Size(211, 30);
            this.btnChatLieu.TabIndex = 45;
            this.btnChatLieu.Text = "Chất liệu";
            this.btnChatLieu.UseTransparentBackground = true;
            this.btnChatLieu.Click += new System.EventHandler(this.btnChatLieu_Click_1);
            // 
            // btnKiemKe
            // 
            this.btnKiemKe.BackColor = System.Drawing.Color.Transparent;
            this.btnKiemKe.BorderRadius = 10;
            this.btnKiemKe.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKiemKe.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnKiemKe.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnKiemKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKiemKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnKiemKe.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemKe.ForeColor = System.Drawing.Color.White;
            this.btnKiemKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKiemKe.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnKiemKe.ImageSize = new System.Drawing.Size(25, 25);
            this.btnKiemKe.Location = new System.Drawing.Point(2, 138);
            this.btnKiemKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnKiemKe.Name = "btnKiemKe";
            this.btnKiemKe.Size = new System.Drawing.Size(211, 30);
            this.btnKiemKe.TabIndex = 40;
            this.btnKiemKe.Text = "Kiểm kê";
            this.btnKiemKe.UseTransparentBackground = true;
            this.btnKiemKe.Click += new System.EventHandler(this.btnKiemKe_Click);
            // 
            // btnKhuVuc
            // 
            this.btnKhuVuc.BackColor = System.Drawing.Color.Transparent;
            this.btnKhuVuc.BorderRadius = 10;
            this.btnKhuVuc.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhuVuc.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnKhuVuc.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnKhuVuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhuVuc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnKhuVuc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuVuc.ForeColor = System.Drawing.Color.White;
            this.btnKhuVuc.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhuVuc.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnKhuVuc.ImageSize = new System.Drawing.Size(25, 25);
            this.btnKhuVuc.Location = new System.Drawing.Point(2, 240);
            this.btnKhuVuc.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhuVuc.Name = "btnKhuVuc";
            this.btnKhuVuc.Size = new System.Drawing.Size(211, 30);
            this.btnKhuVuc.TabIndex = 44;
            this.btnKhuVuc.Text = "Khu vực";
            this.btnKhuVuc.UseTransparentBackground = true;
            this.btnKhuVuc.Click += new System.EventHandler(this.btnKhuVuc_Click);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnPhieuNhap.BorderRadius = 10;
            this.btnPhieuNhap.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPhieuNhap.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnPhieuNhap.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhieuNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnPhieuNhap.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuNhap.ForeColor = System.Drawing.Color.White;
            this.btnPhieuNhap.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuNhap.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnPhieuNhap.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPhieuNhap.Location = new System.Drawing.Point(2, 104);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(2);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(211, 30);
            this.btnPhieuNhap.TabIndex = 39;
            this.btnPhieuNhap.Text = "Nhập hàng";
            this.btnPhieuNhap.UseTransparentBackground = true;
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.btnNhaCungCap.BorderRadius = 10;
            this.btnNhaCungCap.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhaCungCap.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnNhaCungCap.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnNhaCungCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhaCungCap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnNhaCungCap.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCungCap.ForeColor = System.Drawing.Color.White;
            this.btnNhaCungCap.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhaCungCap.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnNhaCungCap.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNhaCungCap.Location = new System.Drawing.Point(2, 206);
            this.btnNhaCungCap.Margin = new System.Windows.Forms.Padding(2);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.Size = new System.Drawing.Size(211, 30);
            this.btnNhaCungCap.TabIndex = 43;
            this.btnNhaCungCap.Text = "Nhà cung cấp";
            this.btnNhaCungCap.UseTransparentBackground = true;
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.BackColor = System.Drawing.Color.Transparent;
            this.btnPhieuXuat.BorderRadius = 10;
            this.btnPhieuXuat.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPhieuXuat.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnPhieuXuat.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnPhieuXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhieuXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnPhieuXuat.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnPhieuXuat.ForeColor = System.Drawing.Color.White;
            this.btnPhieuXuat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuXuat.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnPhieuXuat.ImageSize = new System.Drawing.Size(25, 25);
            this.btnPhieuXuat.Location = new System.Drawing.Point(2, 70);
            this.btnPhieuXuat.Margin = new System.Windows.Forms.Padding(2);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.Size = new System.Drawing.Size(211, 30);
            this.btnPhieuXuat.TabIndex = 38;
            this.btnPhieuXuat.Text = "Xuất hàng";
            this.btnPhieuXuat.UseTransparentBackground = true;
            this.btnPhieuXuat.Click += new System.EventHandler(this.btnPhieuXuat_Click);
            // 
            // btnTonKho
            // 
            this.btnTonKho.BackColor = System.Drawing.Color.Transparent;
            this.btnTonKho.BorderRadius = 10;
            this.btnTonKho.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTonKho.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTonKho.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnTonKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTonKho.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnTonKho.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTonKho.ForeColor = System.Drawing.Color.White;
            this.btnTonKho.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTonKho.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnTonKho.Location = new System.Drawing.Point(2, 36);
            this.btnTonKho.Margin = new System.Windows.Forms.Padding(2);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Size = new System.Drawing.Size(211, 30);
            this.btnTonKho.TabIndex = 37;
            this.btnTonKho.Text = "Tồn kho";
            this.btnTonKho.UseTransparentBackground = true;
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.Transparent;
            this.btnTrangChu.BorderRadius = 10;
            this.btnTrangChu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTrangChu.Checked = true;
            this.btnTrangChu.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTrangChu.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnTrangChu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTrangChu.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnTrangChu.Location = new System.Drawing.Point(2, 2);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(211, 30);
            this.btnTrangChu.TabIndex = 3;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseTransparentBackground = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.Transparent;
            this.pnlName.BorderRadius = 25;
            this.pnlName.Controls.Add(this.lbRole);
            this.pnlName.Controls.Add(this.guna2CirclePictureBox1);
            this.pnlName.Controls.Add(this.lbName);
            this.pnlName.Location = new System.Drawing.Point(35, 20);
            this.pnlName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(212, 50);
            this.pnlName.TabIndex = 34;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lbRole.Location = new System.Drawing.Point(52, 25);
            this.lbRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(45, 18);
            this.lbRole.TabIndex = 28;
            this.lbRole.Text = "Name";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lbName.Location = new System.Drawing.Point(51, 6);
            this.lbName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(57, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.White;
            this.guna2Shapes1.FillColor = System.Drawing.Color.White;
            this.guna2Shapes1.LineEndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            this.guna2Shapes1.LineStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2Shapes1.LineThickness = 1;
            this.guna2Shapes1.Location = new System.Drawing.Point(57, 74);
            this.guna2Shapes1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Shape = Guna.UI2.WinForms.Enums.ShapeType.Line;
            this.guna2Shapes1.Size = new System.Drawing.Size(174, 18);
            this.guna2Shapes1.TabIndex = 32;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.UseTransparentBackground = true;
            this.guna2Shapes1.Zoom = 100;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlBody);
            this.pnlRight.Controls.Add(this.panelTop);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(267, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(1098, 729);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lbPage);
            this.pnlLeft.Controls.Add(this.pnlLogout);
            this.pnlLeft.Controls.Add(this.pnlMenu);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(261, 729);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLogout
            // 
            this.pnlLogout.Controls.Add(this.btnLogout);
            this.pnlLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.pnlLogout.Location = new System.Drawing.Point(0, 694);
            this.pnlLogout.Name = "pnlLogout";
            this.pnlLogout.Size = new System.Drawing.Size(261, 35);
            this.pnlLogout.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BorderRadius = 17;
            this.btnLogout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLogout.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnLogout.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.btnLogout.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnLogout.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogout.Location = new System.Drawing.Point(0, 0);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(261, 35);
            this.btnLogout.TabIndex = 50;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseTransparentBackground = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.flowLayoutPanel1.Controls.Add(this.btnTrangChu);
            this.flowLayoutPanel1.Controls.Add(this.btnTonKho);
            this.flowLayoutPanel1.Controls.Add(this.btnPhieuXuat);
            this.flowLayoutPanel1.Controls.Add(this.btnPhieuNhap);
            this.flowLayoutPanel1.Controls.Add(this.btnKiemKe);
            this.flowLayoutPanel1.Controls.Add(this.btnKhachHang);
            this.flowLayoutPanel1.Controls.Add(this.btnNhaCungCap);
            this.flowLayoutPanel1.Controls.Add(this.btnKhuVuc);
            this.flowLayoutPanel1.Controls.Add(this.btnChatLieu);
            this.flowLayoutPanel1.Controls.Add(this.btnLoai);
            this.flowLayoutPanel1.Controls.Add(this.btnSize);
            this.flowLayoutPanel1.Controls.Add(this.btnNhanVien);
            this.flowLayoutPanel1.Controls.Add(this.btnTaiKhoan);
            this.flowLayoutPanel1.Controls.Add(this.btnPhanQuyen);
            this.flowLayoutPanel1.Controls.Add(this.btnBaoCao);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(54, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(213, 514);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lbTitle.Location = new System.Drawing.Point(381, 5);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(349, 33);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "HỆ THỐNG QUẢN LÝ TỒN KHO";
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.lbPage.Location = new System.Drawing.Point(77, 9);
            this.lbPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(54, 26);
            this.lbPage.TabIndex = 29;
            this.lbPage.Text = "Page";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(8, 6);
            this.guna2CirclePictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(39, 37);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 27;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1365, 729);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlLogout.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelTop;
        private Panel pnlBody;
        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Button btnKhachHang;
        private Guna.UI2.WinForms.Guna2Button btnKiemKe;
        private Guna.UI2.WinForms.Guna2Button btnPhieuNhap;
        private Guna.UI2.WinForms.Guna2Button btnPhieuXuat;
        private Guna.UI2.WinForms.Guna2Button btnTonKho;
        private Guna.UI2.WinForms.Guna2Button btnTrangChu;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Label lbName;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Panel pnlRight;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Panel pnlLeft;
        private Guna.UI2.WinForms.Guna2Button btnNhaCungCap;
        private Guna.UI2.WinForms.Guna2Button btnKhuVuc;
        private Guna.UI2.WinForms.Guna2Button btnChatLieu;
        private Guna.UI2.WinForms.Guna2Button btnLoai;
        private Guna.UI2.WinForms.Guna2Button btnSize;
        private Guna.UI2.WinForms.Guna2Button btnNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnPhanQuyen;
        private Guna.UI2.WinForms.Guna2Button btnBaoCao;
        private Guna.UI2.WinForms.Guna2Panel pnlLogout;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Label lbRole;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbTitle;
        private Label lbPage;
    }
}