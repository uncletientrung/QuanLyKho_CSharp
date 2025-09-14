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
            this.btnPhanQuyen = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnKiemKe = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnPhieuXuat = new System.Windows.Forms.Button();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.btnTonKho = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.avatar_Logout = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlLeftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar_Logout)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeftMenu
            // 
            this.pnlLeftMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeftMenu.Controls.Add(this.btnPhanQuyen);
            this.pnlLeftMenu.Controls.Add(this.btnTaiKhoan);
            this.pnlLeftMenu.Controls.Add(this.btnBaoCao);
            this.pnlLeftMenu.Controls.Add(this.btnKiemKe);
            this.pnlLeftMenu.Controls.Add(this.btnNhanVien);
            this.pnlLeftMenu.Controls.Add(this.btnKhachHang);
            this.pnlLeftMenu.Controls.Add(this.btnThongTin);
            this.pnlLeftMenu.Controls.Add(this.btnPhieuXuat);
            this.pnlLeftMenu.Controls.Add(this.btnPhieuNhap);
            this.pnlLeftMenu.Controls.Add(this.btnTonKho);
            this.pnlLeftMenu.Controls.Add(this.lbUser);
            this.pnlLeftMenu.Controls.Add(this.btnTrangChu);
            this.pnlLeftMenu.Controls.Add(this.avatar);
            this.pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeftMenu.Name = "pnlLeftMenu";
            this.pnlLeftMenu.Size = new System.Drawing.Size(197, 573);
            this.pnlLeftMenu.TabIndex = 0;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Location = new System.Drawing.Point(14, 514);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(166, 36);
            this.btnPhanQuyen.TabIndex = 12;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.UseVisualStyleBackColor = true;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(14, 473);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(166, 36);
            this.btnTaiKhoan.TabIndex = 11;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(14, 433);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(166, 36);
            this.btnBaoCao.TabIndex = 10;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnKiemKe
            // 
            this.btnKiemKe.Location = new System.Drawing.Point(14, 393);
            this.btnKiemKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKiemKe.Name = "btnKiemKe";
            this.btnKiemKe.Size = new System.Drawing.Size(166, 36);
            this.btnKiemKe.TabIndex = 9;
            this.btnKiemKe.Text = "Kiểm kê";
            this.btnKiemKe.UseVisualStyleBackColor = true;
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(14, 353);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(166, 36);
            this.btnNhanVien.TabIndex = 8;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(14, 313);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(166, 36);
            this.btnKhachHang.TabIndex = 7;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnThongTin
            // 
            this.btnThongTin.Location = new System.Drawing.Point(14, 273);
            this.btnThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(166, 36);
            this.btnThongTin.TabIndex = 6;
            this.btnThongTin.Text = "Thông tin";
            this.btnThongTin.UseVisualStyleBackColor = true;
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Location = new System.Drawing.Point(12, 233);
            this.btnPhieuXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.Size = new System.Drawing.Size(166, 36);
            this.btnPhieuXuat.TabIndex = 5;
            this.btnPhieuXuat.Text = "Xuất hàng";
            this.btnPhieuXuat.UseVisualStyleBackColor = true;
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Location = new System.Drawing.Point(12, 192);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(166, 36);
            this.btnPhieuNhap.TabIndex = 4;
            this.btnPhieuNhap.Text = "Nhập hàng";
            this.btnPhieuNhap.UseVisualStyleBackColor = true;
            // 
            // btnTonKho
            // 
            this.btnTonKho.Location = new System.Drawing.Point(14, 152);
            this.btnTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.Size = new System.Drawing.Size(166, 36);
            this.btnTonKho.TabIndex = 3;
            this.btnTonKho.Text = "Tồn kho";
            this.btnTonKho.UseVisualStyleBackColor = true;
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(67, 82);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(49, 17);
            this.lbUser.TabIndex = 2;
            this.lbUser.Text = "Hi, user";
            this.lbUser.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Location = new System.Drawing.Point(14, 108);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(166, 40);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // avatar
            // 
            this.avatar.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.pnlTop.Size = new System.Drawing.Size(867, 52);
            this.pnlTop.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.Location = new System.Drawing.Point(747, 21);
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
            this.avatar_Logout.Image = ((System.Drawing.Image)(resources.GetObject("avatar_Logout.Image")));
            this.avatar_Logout.Location = new System.Drawing.Point(701, 12);
            this.avatar_Logout.Name = "avatar_Logout";
            this.avatar_Logout.Size = new System.Drawing.Size(42, 37);
            this.avatar_Logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar_Logout.TabIndex = 0;
            this.avatar_Logout.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(197, 52);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(867, 521);
            this.pnlBody.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 573);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeftMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlLeftMenu.ResumeLayout(false);
            this.pnlLeftMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avatar_Logout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftMenu;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnKiemKe;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.Button btnPhieuXuat;
        private System.Windows.Forms.Button btnPhieuNhap;
        private System.Windows.Forms.Button btnTonKho;
        private System.Windows.Forms.Button btnPhanQuyen;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox avatar_Logout;
        private System.Windows.Forms.Panel pnlBody;
    }
}