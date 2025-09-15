using System.Drawing;
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
            this.lbUser = new System.Windows.Forms.Label();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.avatar_Logout = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnPhieuXuat = new System.Windows.Forms.Button();
            this.btnKiemKe = new System.Windows.Forms.Button();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTonKho = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnPhanQuyen = new System.Windows.Forms.Button();
            this.tablelayoutLeftmenu = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_Logout)).BeginInit();
            this.tablelayoutLeftmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftMenu
            // 
            this.pnlLeftMenu.AutoScroll = true;
            this.pnlLeftMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeftMenu.Controls.Add(this.tablelayoutLeftmenu);
            this.pnlLeftMenu.Controls.Add(this.lbUser);
            this.pnlLeftMenu.Controls.Add(this.avatar);
            this.pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeftMenu.Name = "pnlLeftMenu";
            this.pnlLeftMenu.Size = new System.Drawing.Size(197, 640);
            this.pnlLeftMenu.TabIndex = 0;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(67, 82);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(60, 20);
            this.lbUser.TabIndex = 2;
            this.lbUser.Text = "Hi, user";
            this.lbUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // avatar
            // 
            this.avatar.Image = ((System.Drawing.Image)(resources.GetObject("avatar.Image")));
            this.avatar.InitialImage = null;
            this.avatar.Location = new System.Drawing.Point(0, 0);
            this.avatar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(197, 78);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.avatar_Logout);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(197, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(867, 78);
            this.pnlTop.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.Location = new System.Drawing.Point(783, 35);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // avatar_Logout
            // 
            this.avatar_Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avatar_Logout.Image = ((System.Drawing.Image)(resources.GetObject("avatar_Logout.Image")));
            this.avatar_Logout.Location = new System.Drawing.Point(738, 21);
            this.avatar_Logout.Name = "avatar_Logout";
            this.avatar_Logout.Size = new System.Drawing.Size(42, 37);
            this.avatar_Logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar_Logout.TabIndex = 0;
            this.avatar_Logout.TabStop = false;
            this.avatar_Logout.Click += new System.EventHandler(this.avatar_Logout_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.Location = new System.Drawing.Point(197, 78);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(867, 562);
            this.pnlBody.TabIndex = 2;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKhachHang.Location = new System.Drawing.Point(3, 272);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(191, 50);
            this.btnKhachHang.TabIndex = 7;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnThongTin
            // 
            this.btnThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongTin.Location = new System.Drawing.Point(3, 218);
            this.btnThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(191, 50);
            this.btnThongTin.TabIndex = 6;
            this.btnThongTin.Text = "Thông tin";
            this.btnThongTin.UseVisualStyleBackColor = true;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNhanVien.Location = new System.Drawing.Point(3, 326);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(191, 50);
            this.btnNhanVien.TabIndex = 8;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhieuXuat.Location = new System.Drawing.Point(3, 164);
            this.btnPhieuXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.Size = new System.Drawing.Size(191, 50);
            this.btnPhieuXuat.TabIndex = 5;
            this.btnPhieuXuat.Text = "Xuất hàng";
            this.btnPhieuXuat.UseVisualStyleBackColor = true;
            // 
            // btnKiemKe
            // 
            this.btnKiemKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKiemKe.Location = new System.Drawing.Point(3, 380);
            this.btnKiemKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKiemKe.Name = "btnKiemKe";
            this.btnKiemKe.Size = new System.Drawing.Size(191, 50);
            this.btnKiemKe.TabIndex = 9;
            this.btnKiemKe.Text = "Kiểm kê";
            this.btnKiemKe.UseVisualStyleBackColor = true;
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhieuNhap.Location = new System.Drawing.Point(3, 110);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(191, 50);
            this.btnPhieuNhap.TabIndex = 4;
            this.btnPhieuNhap.Text = "Nhập hàng";
            this.btnPhieuNhap.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBaoCao.Location = new System.Drawing.Point(3, 434);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(191, 50);
            this.btnBaoCao.TabIndex = 10;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnTonKho
            // 
            this.btnTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTonKho.Location = new System.Drawing.Point(3, 56);
            this.btnTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Size = new System.Drawing.Size(191, 50);
            this.btnTonKho.TabIndex = 3;
            this.btnTonKho.Text = "Tồn kho";
            this.btnTonKho.UseVisualStyleBackColor = true;
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTaiKhoan.Location = new System.Drawing.Point(3, 488);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(191, 50);
            this.btnTaiKhoan.TabIndex = 11;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrangChu.Location = new System.Drawing.Point(3, 2);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(191, 50);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhanQuyen.Location = new System.Drawing.Point(3, 543);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(191, 59);
            this.btnPhanQuyen.TabIndex = 12;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.UseVisualStyleBackColor = true;
            // 
            // tablelayoutLeftmenu
            // 
            this.tablelayoutLeftmenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablelayoutLeftmenu.AutoScroll = true;
            this.tablelayoutLeftmenu.AutoSize = true;
            this.tablelayoutLeftmenu.ColumnCount = 1;
            this.tablelayoutLeftmenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelayoutLeftmenu.Controls.Add(this.btnPhanQuyen, 0, 10);
            this.tablelayoutLeftmenu.Controls.Add(this.btnTrangChu, 0, 0);
            this.tablelayoutLeftmenu.Controls.Add(this.btnTaiKhoan, 0, 9);
            this.tablelayoutLeftmenu.Controls.Add(this.btnTonKho, 0, 1);
            this.tablelayoutLeftmenu.Controls.Add(this.btnBaoCao, 0, 8);
            this.tablelayoutLeftmenu.Controls.Add(this.btnPhieuNhap, 0, 2);
            this.tablelayoutLeftmenu.Controls.Add(this.btnKiemKe, 0, 7);
            this.tablelayoutLeftmenu.Controls.Add(this.btnPhieuXuat, 0, 3);
            this.tablelayoutLeftmenu.Controls.Add(this.btnNhanVien, 0, 6);
            this.tablelayoutLeftmenu.Controls.Add(this.btnThongTin, 0, 4);
            this.tablelayoutLeftmenu.Controls.Add(this.btnKhachHang, 0, 5);
            this.tablelayoutLeftmenu.Location = new System.Drawing.Point(3, 105);
            this.tablelayoutLeftmenu.Name = "tablelayoutLeftmenu";
            this.tablelayoutLeftmenu.RowCount = 11;
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tablelayoutLeftmenu.Size = new System.Drawing.Size(197, 605);
            this.tablelayoutLeftmenu.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 640);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeftMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlLeftMenu.ResumeLayout(false);
            this.pnlLeftMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatar_Logout)).EndInit();
            this.tablelayoutLeftmenu.ResumeLayout(false);
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
        private TableLayoutPanel tablelayoutLeftmenu;
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
    }
}