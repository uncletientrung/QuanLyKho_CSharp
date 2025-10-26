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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbUser = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbRole = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.paneMenu = new System.Windows.Forms.Panel();
            this.btnBaoCao = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlSubmenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyNhanVien = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNhanVien = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTaiKhoan = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPhanQuyen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlSubmenuThuocTinh = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuanLyThuocTinh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNhaCungCap = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnKhuVuc = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnChatLieu = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnLoai = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSize = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnKhachHang = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnKiemKe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPhieuNhap = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPhieuXuat = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTonKho = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTrangChu = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.paneMenu.SuspendLayout();
            this.pnlSubmenu.SuspendLayout();
            this.pnlSubmenuThuocTinh.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(221, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1144, 41);
            this.panelTop.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1104, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 41);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(3, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 1);
            this.panel2.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = false;
            this.lbUser.Location = new System.Drawing.Point(94, 33);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(124, 25);
            this.lbUser.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lbUser.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.lbUser.StateCommon.ShortText.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbUser.TabIndex = 8;
            this.lbUser.Values.Text = "Tiến Trung";
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = false;
            this.lbRole.Location = new System.Drawing.Point(94, 63);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(147, 19);
            this.lbRole.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.lbRole.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.lbRole.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.TabIndex = 9;
            this.lbRole.Values.Text = "Adminâ";
            // 
            // paneMenu
            // 
            this.paneMenu.Controls.Add(this.btnBaoCao);
            this.paneMenu.Controls.Add(this.pnlSubmenu);
            this.paneMenu.Controls.Add(this.pnlSubmenuThuocTinh);
            this.paneMenu.Controls.Add(this.btnKhachHang);
            this.paneMenu.Controls.Add(this.btnKiemKe);
            this.paneMenu.Controls.Add(this.btnPhieuNhap);
            this.paneMenu.Controls.Add(this.btnPhieuXuat);
            this.paneMenu.Controls.Add(this.btnTonKho);
            this.paneMenu.Controls.Add(this.btnTrangChu);
            this.paneMenu.Location = new System.Drawing.Point(0, 116);
            this.paneMenu.Margin = new System.Windows.Forms.Padding(0);
            this.paneMenu.Name = "paneMenu";
            this.paneMenu.Size = new System.Drawing.Size(221, 571);
            this.paneMenu.TabIndex = 10;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 328);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(0);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnBaoCao.Size = new System.Drawing.Size(221, 41);
            this.btnBaoCao.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.StateCommon.Back.ColorAngle = 45F;
            this.btnBaoCao.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.StateCommon.Border.ColorAngle = 45F;
            this.btnBaoCao.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBaoCao.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnBaoCao.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnBaoCao.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBaoCao.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnBaoCao.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBaoCao.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBaoCao.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBaoCao.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBaoCao.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnBaoCao.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnBaoCao.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnBaoCao.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnBaoCao.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBaoCao.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnBaoCao.TabIndex = 13;
            this.btnBaoCao.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCao.Values.Image")));
            this.btnBaoCao.Values.Text = "Báo cáo thống kê";
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // pnlSubmenu
            // 
            this.pnlSubmenu.Controls.Add(this.btnQuanLyNhanVien);
            this.pnlSubmenu.Controls.Add(this.btnNhanVien);
            this.pnlSubmenu.Controls.Add(this.btnTaiKhoan);
            this.pnlSubmenu.Controls.Add(this.btnPhanQuyen);
            this.pnlSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmenu.Location = new System.Drawing.Point(0, 287);
            this.pnlSubmenu.MaximumSize = new System.Drawing.Size(221, 165);
            this.pnlSubmenu.MinimumSize = new System.Drawing.Size(221, 41);
            this.pnlSubmenu.Name = "pnlSubmenu";
            this.pnlSubmenu.Size = new System.Drawing.Size(221, 41);
            this.pnlSubmenu.TabIndex = 12;
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(0, 0);
            this.btnQuanLyNhanVien.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(221, 41);
            this.btnQuanLyNhanVien.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.StateCommon.Back.ColorAngle = 45F;
            this.btnQuanLyNhanVien.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.StateCommon.Border.ColorAngle = 45F;
            this.btnQuanLyNhanVien.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnQuanLyNhanVien.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnQuanLyNhanVien.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnQuanLyNhanVien.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnQuanLyNhanVien.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnQuanLyNhanVien.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnQuanLyNhanVien.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnQuanLyNhanVien.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyNhanVien.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnQuanLyNhanVien.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnQuanLyNhanVien.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnQuanLyNhanVien.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnQuanLyNhanVien.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnQuanLyNhanVien.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnQuanLyNhanVien.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnQuanLyNhanVien.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyNhanVien.TabIndex = 11;
            this.btnQuanLyNhanVien.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyNhanVien.Values.Image")));
            this.btnQuanLyNhanVien.Values.Text = "Quản lý nhân viên";
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(0, 41);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnNhanVien.Size = new System.Drawing.Size(221, 41);
            this.btnNhanVien.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.StateCommon.Back.ColorAngle = 45F;
            this.btnNhanVien.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.StateCommon.Border.ColorAngle = 45F;
            this.btnNhanVien.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhanVien.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnNhanVien.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnNhanVien.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhanVien.StateCommon.Content.Padding = new System.Windows.Forms.Padding(50, 5, -1, -1);
            this.btnNhanVien.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNhanVien.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNhanVien.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhanVien.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhanVien.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnNhanVien.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnNhanVien.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnNhanVien.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnNhanVien.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhanVien.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhanVien.TabIndex = 16;
            this.btnNhanVien.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.Values.Image")));
            this.btnNhanVien.Values.Text = "Nhân viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 82);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnTaiKhoan.Size = new System.Drawing.Size(221, 41);
            this.btnTaiKhoan.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.StateCommon.Back.ColorAngle = 45F;
            this.btnTaiKhoan.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.StateCommon.Border.ColorAngle = 45F;
            this.btnTaiKhoan.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTaiKhoan.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnTaiKhoan.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTaiKhoan.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTaiKhoan.StateCommon.Content.Padding = new System.Windows.Forms.Padding(50, 5, -1, -1);
            this.btnTaiKhoan.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTaiKhoan.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTaiKhoan.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTaiKhoan.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTaiKhoan.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnTaiKhoan.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnTaiKhoan.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnTaiKhoan.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnTaiKhoan.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTaiKhoan.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTaiKhoan.TabIndex = 17;
            this.btnTaiKhoan.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Values.Image")));
            this.btnTaiKhoan.Values.Text = "Tài khoản";
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Location = new System.Drawing.Point(0, 123);
            this.btnPhanQuyen.Margin = new System.Windows.Forms.Padding(0);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnPhanQuyen.Size = new System.Drawing.Size(221, 41);
            this.btnPhanQuyen.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.StateCommon.Back.ColorAngle = 45F;
            this.btnPhanQuyen.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.StateCommon.Border.ColorAngle = 45F;
            this.btnPhanQuyen.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPhanQuyen.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnPhanQuyen.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnPhanQuyen.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhanQuyen.StateCommon.Content.Padding = new System.Windows.Forms.Padding(50, 5, -1, -1);
            this.btnPhanQuyen.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPhanQuyen.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPhanQuyen.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanQuyen.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhanQuyen.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhanQuyen.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnPhanQuyen.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPhanQuyen.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnPhanQuyen.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnPhanQuyen.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPhanQuyen.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhanQuyen.TabIndex = 18;
            this.btnPhanQuyen.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnPhanQuyen.Values.Image")));
            this.btnPhanQuyen.Values.Text = "Phân quyền";
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // pnlSubmenuThuocTinh
            // 
            this.pnlSubmenuThuocTinh.Controls.Add(this.btnQuanLyThuocTinh);
            this.pnlSubmenuThuocTinh.Controls.Add(this.btnNhaCungCap);
            this.pnlSubmenuThuocTinh.Controls.Add(this.btnKhuVuc);
            this.pnlSubmenuThuocTinh.Controls.Add(this.btnChatLieu);
            this.pnlSubmenuThuocTinh.Controls.Add(this.btnLoai);
            this.pnlSubmenuThuocTinh.Controls.Add(this.btnSize);
            this.pnlSubmenuThuocTinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmenuThuocTinh.Location = new System.Drawing.Point(0, 246);
            this.pnlSubmenuThuocTinh.MaximumSize = new System.Drawing.Size(221, 246);
            this.pnlSubmenuThuocTinh.MinimumSize = new System.Drawing.Size(221, 41);
            this.pnlSubmenuThuocTinh.Name = "pnlSubmenuThuocTinh";
            this.pnlSubmenuThuocTinh.Size = new System.Drawing.Size(221, 41);
            this.pnlSubmenuThuocTinh.TabIndex = 13;
            // 
            // btnQuanLyThuocTinh
            // 
            this.btnQuanLyThuocTinh.Location = new System.Drawing.Point(0, 0);
            this.btnQuanLyThuocTinh.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuanLyThuocTinh.Name = "btnQuanLyThuocTinh";
            this.btnQuanLyThuocTinh.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnQuanLyThuocTinh.Size = new System.Drawing.Size(221, 41);
            this.btnQuanLyThuocTinh.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.StateCommon.Back.ColorAngle = 45F;
            this.btnQuanLyThuocTinh.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.StateCommon.Border.ColorAngle = 45F;
            this.btnQuanLyThuocTinh.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnQuanLyThuocTinh.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnQuanLyThuocTinh.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnQuanLyThuocTinh.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnQuanLyThuocTinh.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnQuanLyThuocTinh.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnQuanLyThuocTinh.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnQuanLyThuocTinh.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyThuocTinh.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnQuanLyThuocTinh.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnQuanLyThuocTinh.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnQuanLyThuocTinh.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnQuanLyThuocTinh.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnQuanLyThuocTinh.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnQuanLyThuocTinh.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnQuanLyThuocTinh.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnQuanLyThuocTinh.TabIndex = 11;
            this.btnQuanLyThuocTinh.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyThuocTinh.Values.Image")));
            this.btnQuanLyThuocTinh.Values.Text = "Quản lý thuộc tính";
            this.btnQuanLyThuocTinh.Click += new System.EventHandler(this.btnQuanLyThuocTinh_Click);
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhaCungCap.Location = new System.Drawing.Point(0, 41);
            this.btnNhaCungCap.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnNhaCungCap.Size = new System.Drawing.Size(221, 41);
            this.btnNhaCungCap.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.StateCommon.Back.ColorAngle = 45F;
            this.btnNhaCungCap.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.StateCommon.Border.ColorAngle = 45F;
            this.btnNhaCungCap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhaCungCap.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnNhaCungCap.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnNhaCungCap.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhaCungCap.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnNhaCungCap.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNhaCungCap.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNhaCungCap.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCungCap.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhaCungCap.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNhaCungCap.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnNhaCungCap.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnNhaCungCap.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnNhaCungCap.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnNhaCungCap.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhaCungCap.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnNhaCungCap.TabIndex = 20;
            this.btnNhaCungCap.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnNhaCungCap.Values.Image")));
            this.btnNhaCungCap.Values.Text = "Nhà cung cấp";
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnKhuVuc
            // 
            this.btnKhuVuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhuVuc.Location = new System.Drawing.Point(0, 82);
            this.btnKhuVuc.Margin = new System.Windows.Forms.Padding(0);
            this.btnKhuVuc.Name = "btnKhuVuc";
            this.btnKhuVuc.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnKhuVuc.Size = new System.Drawing.Size(221, 41);
            this.btnKhuVuc.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.StateCommon.Back.ColorAngle = 45F;
            this.btnKhuVuc.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.StateCommon.Border.ColorAngle = 45F;
            this.btnKhuVuc.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKhuVuc.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnKhuVuc.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnKhuVuc.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKhuVuc.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnKhuVuc.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnKhuVuc.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnKhuVuc.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuVuc.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKhuVuc.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKhuVuc.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnKhuVuc.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnKhuVuc.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnKhuVuc.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnKhuVuc.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKhuVuc.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhuVuc.TabIndex = 21;
            this.btnKhuVuc.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnKhuVuc.Values.Image")));
            this.btnKhuVuc.Values.Text = "Khu vực";
            this.btnKhuVuc.Click += new System.EventHandler(this.btnKhuVuc_Click);
            // 
            // btnChatLieu
            // 
            this.btnChatLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChatLieu.Location = new System.Drawing.Point(0, 123);
            this.btnChatLieu.Margin = new System.Windows.Forms.Padding(0);
            this.btnChatLieu.Name = "btnChatLieu";
            this.btnChatLieu.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnChatLieu.Size = new System.Drawing.Size(221, 41);
            this.btnChatLieu.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.StateCommon.Back.ColorAngle = 45F;
            this.btnChatLieu.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.StateCommon.Border.ColorAngle = 45F;
            this.btnChatLieu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnChatLieu.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnChatLieu.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnChatLieu.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnChatLieu.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnChatLieu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnChatLieu.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnChatLieu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChatLieu.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnChatLieu.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnChatLieu.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnChatLieu.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnChatLieu.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnChatLieu.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnChatLieu.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnChatLieu.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnChatLieu.TabIndex = 22;
            this.btnChatLieu.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnChatLieu.Values.Image")));
            this.btnChatLieu.Values.Text = "Chất liệu";
            this.btnChatLieu.Click += new System.EventHandler(this.btnChatLieu_Click_1);
            // 
            // btnLoai
            // 
            this.btnLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoai.Location = new System.Drawing.Point(0, 164);
            this.btnLoai.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoai.Name = "btnLoai";
            this.btnLoai.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnLoai.Size = new System.Drawing.Size(221, 41);
            this.btnLoai.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.StateCommon.Back.ColorAngle = 45F;
            this.btnLoai.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.StateCommon.Border.ColorAngle = 45F;
            this.btnLoai.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLoai.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLoai.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnLoai.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnLoai.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnLoai.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoai.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoai.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoai.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnLoai.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnLoai.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnLoai.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnLoai.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnLoai.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnLoai.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLoai.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLoai.TabIndex = 23;
            this.btnLoai.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnLoai.Values.Image")));
            this.btnLoai.Values.Text = "Loại";
            this.btnLoai.Click += new System.EventHandler(this.btnLoai_Click_1);
            // 
            // btnSize
            // 
            this.btnSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSize.Location = new System.Drawing.Point(0, 205);
            this.btnSize.Margin = new System.Windows.Forms.Padding(0);
            this.btnSize.Name = "btnSize";
            this.btnSize.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSize.Size = new System.Drawing.Size(221, 41);
            this.btnSize.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.StateCommon.Back.ColorAngle = 45F;
            this.btnSize.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.StateCommon.Border.ColorAngle = 45F;
            this.btnSize.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSize.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSize.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSize.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSize.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnSize.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSize.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSize.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSize.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSize.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSize.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnSize.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSize.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnSize.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnSize.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSize.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnSize.TabIndex = 24;
            this.btnSize.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnSize.Values.Image")));
            this.btnSize.Values.Text = "Size";
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 205);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnKhachHang.Size = new System.Drawing.Size(221, 41);
            this.btnKhachHang.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.StateCommon.Back.ColorAngle = 45F;
            this.btnKhachHang.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.StateCommon.Border.ColorAngle = 45F;
            this.btnKhachHang.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKhachHang.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnKhachHang.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnKhachHang.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKhachHang.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnKhachHang.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnKhachHang.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnKhachHang.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKhachHang.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKhachHang.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnKhachHang.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnKhachHang.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnKhachHang.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnKhachHang.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKhachHang.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKhachHang.TabIndex = 9;
            this.btnKhachHang.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.Values.Image")));
            this.btnKhachHang.Values.Text = "Khách hàng";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnKiemKe
            // 
            this.btnKiemKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKiemKe.Location = new System.Drawing.Point(0, 164);
            this.btnKiemKe.Margin = new System.Windows.Forms.Padding(0);
            this.btnKiemKe.Name = "btnKiemKe";
            this.btnKiemKe.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnKiemKe.Size = new System.Drawing.Size(221, 41);
            this.btnKiemKe.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.StateCommon.Back.ColorAngle = 45F;
            this.btnKiemKe.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.StateCommon.Border.ColorAngle = 45F;
            this.btnKiemKe.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKiemKe.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnKiemKe.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnKiemKe.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKiemKe.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnKiemKe.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnKiemKe.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnKiemKe.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemKe.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKiemKe.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnKiemKe.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnKiemKe.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnKiemKe.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnKiemKe.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnKiemKe.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnKiemKe.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnKiemKe.TabIndex = 8;
            this.btnKiemKe.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnKiemKe.Values.Image")));
            this.btnKiemKe.Values.Text = "Kiểm kê";
            this.btnKiemKe.Click += new System.EventHandler(this.btnKiemKe_Click);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuNhap.Location = new System.Drawing.Point(0, 123);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(0);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnPhieuNhap.Size = new System.Drawing.Size(221, 41);
            this.btnPhieuNhap.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.StateCommon.Back.ColorAngle = 45F;
            this.btnPhieuNhap.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.StateCommon.Border.ColorAngle = 45F;
            this.btnPhieuNhap.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPhieuNhap.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnPhieuNhap.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnPhieuNhap.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhieuNhap.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnPhieuNhap.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPhieuNhap.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPhieuNhap.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuNhap.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhieuNhap.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhieuNhap.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnPhieuNhap.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPhieuNhap.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnPhieuNhap.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnPhieuNhap.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPhieuNhap.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuNhap.TabIndex = 7;
            this.btnPhieuNhap.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieuNhap.Values.Image")));
            this.btnPhieuNhap.Values.Text = "Nhập hàng";
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // btnPhieuXuat
            // 
            this.btnPhieuXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuXuat.Location = new System.Drawing.Point(0, 82);
            this.btnPhieuXuat.Margin = new System.Windows.Forms.Padding(0);
            this.btnPhieuXuat.Name = "btnPhieuXuat";
            this.btnPhieuXuat.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnPhieuXuat.Size = new System.Drawing.Size(221, 41);
            this.btnPhieuXuat.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.StateCommon.Back.ColorAngle = 45F;
            this.btnPhieuXuat.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.StateCommon.Border.ColorAngle = 45F;
            this.btnPhieuXuat.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPhieuXuat.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnPhieuXuat.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnPhieuXuat.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhieuXuat.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnPhieuXuat.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPhieuXuat.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPhieuXuat.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuXuat.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhieuXuat.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnPhieuXuat.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnPhieuXuat.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPhieuXuat.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnPhieuXuat.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnPhieuXuat.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPhieuXuat.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnPhieuXuat.TabIndex = 6;
            this.btnPhieuXuat.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieuXuat.Values.Image")));
            this.btnPhieuXuat.Values.Text = "Xuất hàng";
            this.btnPhieuXuat.Click += new System.EventHandler(this.btnPhieuXuat_Click);
            // 
            // btnTonKho
            // 
            this.btnTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTonKho.Location = new System.Drawing.Point(0, 41);
            this.btnTonKho.Margin = new System.Windows.Forms.Padding(0);
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnTonKho.Size = new System.Drawing.Size(221, 41);
            this.btnTonKho.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.StateCommon.Back.ColorAngle = 45F;
            this.btnTonKho.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.StateCommon.Border.ColorAngle = 45F;
            this.btnTonKho.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTonKho.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnTonKho.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTonKho.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTonKho.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnTonKho.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTonKho.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTonKho.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTonKho.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTonKho.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTonKho.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnTonKho.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnTonKho.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnTonKho.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnTonKho.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTonKho.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTonKho.TabIndex = 5;
            this.btnTonKho.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnTonKho.Values.Image")));
            this.btnTonKho.Values.Text = "Tồn kho";
            this.btnTonKho.Click += new System.EventHandler(this.btnTonKho_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 0);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnTrangChu.Size = new System.Drawing.Size(221, 41);
            this.btnTrangChu.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.StateCommon.Back.ColorAngle = 45F;
            this.btnTrangChu.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.StateCommon.Border.ColorAngle = 45F;
            this.btnTrangChu.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTrangChu.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnTrangChu.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnTrangChu.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTrangChu.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnTrangChu.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnTrangChu.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnTrangChu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTrangChu.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTrangChu.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnTrangChu.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnTrangChu.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnTrangChu.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnTrangChu.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnTrangChu.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnTrangChu.TabIndex = 4;
            this.btnTrangChu.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Values.Image")));
            this.btnTrangChu.Values.Text = "Trang chủ";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lbRole);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.lbUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 110);
            this.panel3.TabIndex = 11;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.panelLeft.Controls.Add(this.panel3);
            this.panelLeft.Controls.Add(this.paneMenu);
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(221, 729);
            this.panelLeft.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(0, 687);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnLogout.Size = new System.Drawing.Size(221, 41);
            this.btnLogout.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.StateCommon.Back.ColorAngle = 45F;
            this.btnLogout.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.StateCommon.Border.ColorAngle = 45F;
            this.btnLogout.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLogout.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLogout.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnLogout.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnLogout.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnLogout.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLogout.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLogout.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnLogout.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnLogout.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnLogout.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnLogout.StatePressed.Border.Color1 = System.Drawing.Color.White;
            this.btnLogout.StatePressed.Border.Color2 = System.Drawing.Color.White;
            this.btnLogout.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLogout.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(67)))), ((int)(((byte)(190)))));
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Values.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(221, 41);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1144, 688);
            this.pnlBody.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1365, 729);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.paneMenu.ResumeLayout(false);
            this.pnlSubmenu.ResumeLayout(false);
            this.pnlSubmenuThuocTinh.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelTop;
        private Panel panel2;
        private PictureBox pictureBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbUser;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbRole;
        private Button btnClose;
        private Panel paneMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTrangChu;
        private Panel panel3;
        private FlowLayoutPanel panelLeft;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPhieuXuat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTonKho;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnKhachHang;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnKiemKe;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPhieuNhap;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuanLyNhanVien;
        private FlowLayoutPanel pnlSubmenu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNhanVien;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTaiKhoan;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPhanQuyen;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogout;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBaoCao;
        private Panel pnlBody;
        private Timer timer1;
        private FlowLayoutPanel pnlSubmenuThuocTinh;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuanLyThuocTinh;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNhaCungCap;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnKhuVuc;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnChatLieu;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLoai;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSize;
        private Timer timer2;
    }
}