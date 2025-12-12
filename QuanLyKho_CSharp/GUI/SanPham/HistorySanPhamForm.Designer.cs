namespace QuanLyKho_CSharp.GUI.SanPham
{
    partial class HistorySanPhamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorySanPhamForm));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.DGVHistory = new System.Windows.Forms.DataGridView();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSoLuongTon = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.artanPanel3 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.artanButton3 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.lbSoLuongPhieu = new System.Windows.Forms.Label();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuXuatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.picHinhanh = new System.Windows.Forms.PictureBox();
            this.ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoigiantao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistory)).BeginInit();
            this.artanPanel3.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lbSoLuongPhieu);
            this.pnlTop.Controls.Add(this.artanPanel3);
            this.pnlTop.Controls.Add(this.lbPrice);
            this.pnlTop.Controls.Add(this.lbSoLuongTon);
            this.pnlTop.Controls.Add(this.lbName);
            this.pnlTop.Controls.Add(this.picHinhanh);
            this.pnlTop.Controls.Add(this.lbTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F);
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(849, 133);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.DGVHistory);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 157);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFill.Size = new System.Drawing.Size(849, 308);
            this.pnlFill.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(849, 55);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Lịch sử xuất sản phẩm SP-x";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DGVHistory
            // 
            this.DGVHistory.AllowUserToAddRows = false;
            this.DGVHistory.AllowUserToDeleteRows = false;
            this.DGVHistory.AllowUserToResizeColumns = false;
            this.DGVHistory.AllowUserToResizeRows = false;
            this.DGVHistory.BackgroundColor = System.Drawing.Color.White;
            this.DGVHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ma,
            this.nhanvien,
            this.khachhang,
            this.thoigiantao,
            this.soluong,
            this.price,
            this.sum,
            this.trangthai,
            this.detail});
            this.DGVHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVHistory.Location = new System.Drawing.Point(5, 5);
            this.DGVHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.DGVHistory.Name = "DGVHistory";
            this.DGVHistory.RowHeadersVisible = false;
            this.DGVHistory.RowHeadersWidth = 51;
            this.DGVHistory.RowTemplate.Height = 24;
            this.DGVHistory.Size = new System.Drawing.Size(839, 298);
            this.DGVHistory.TabIndex = 1;
            this.DGVHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHistory_CellContentClick);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(106, 64);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(102, 18);
            this.lbName.TabIndex = 21;
            this.lbName.Text = "Tên sản phẩm:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSoLuongTon
            // 
            this.lbSoLuongTon.AutoSize = true;
            this.lbSoLuongTon.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuongTon.Location = new System.Drawing.Point(106, 86);
            this.lbSoLuongTon.Name = "lbSoLuongTon";
            this.lbSoLuongTon.Size = new System.Drawing.Size(73, 18);
            this.lbSoLuongTon.TabIndex = 22;
            this.lbSoLuongTon.Text = "Số lượng tồn:";
            this.lbSoLuongTon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(106, 108);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(74, 18);
            this.lbPrice.TabIndex = 23;
            this.lbPrice.Text = "Giá sản phẩm";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // artanPanel3
            // 
            this.artanPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel3.BorderRadius = 30;
            this.artanPanel3.Controls.Add(this.txtSearch);
            this.artanPanel3.Controls.Add(this.artanButton3);
            this.artanPanel3.ForeColor = System.Drawing.Color.Black;
            this.artanPanel3.GradientAngle = 90F;
            this.artanPanel3.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel3.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel3.Location = new System.Drawing.Point(572, 92);
            this.artanPanel3.Name = "artanPanel3";
            this.artanPanel3.Size = new System.Drawing.Size(261, 37);
            this.artanPanel3.TabIndex = 15;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(39, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(204, 23);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // artanButton3
            // 
            this.artanButton3.BackColor = System.Drawing.Color.White;
            this.artanButton3.BackgroundColor = System.Drawing.Color.White;
            this.artanButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanButton3.BorderRadius = 30;
            this.artanButton3.BorderSize = 0;
            this.artanButton3.FlatAppearance.BorderSize = 0;
            this.artanButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.artanButton3.ForeColor = System.Drawing.Color.White;
            this.artanButton3.Image = ((System.Drawing.Image)(resources.GetObject("artanButton3.Image")));
            this.artanButton3.Location = new System.Drawing.Point(3, 3);
            this.artanButton3.Name = "artanButton3";
            this.artanButton3.Size = new System.Drawing.Size(30, 30);
            this.artanButton3.TabIndex = 12;
            this.artanButton3.TextColor = System.Drawing.Color.White;
            this.artanButton3.UseVisualStyleBackColor = false;
            // 
            // lbSoLuongPhieu
            // 
            this.lbSoLuongPhieu.AutoSize = true;
            this.lbSoLuongPhieu.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F);
            this.lbSoLuongPhieu.Location = new System.Drawing.Point(738, 57);
            this.lbSoLuongPhieu.Name = "lbSoLuongPhieu";
            this.lbSoLuongPhieu.Size = new System.Drawing.Size(93, 18);
            this.lbSoLuongPhieu.TabIndex = 24;
            this.lbSoLuongPhieu.Text = "Số lượng phiếu: x";
            this.lbSoLuongPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.btnDong);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 465);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(849, 53);
            this.pnlBot.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(319, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(134, 47);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // menu
            // 
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuXuatHang,
            this.menuNhapHang});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(849, 24);
            this.menu.TabIndex = 25;
            this.menu.Text = "menuStrip1";
            // 
            // menuXuatHang
            // 
            this.menuXuatHang.Name = "menuXuatHang";
            this.menuXuatHang.Size = new System.Drawing.Size(73, 20);
            this.menuXuatHang.Text = "Xuất hàng";
            this.menuXuatHang.Click += new System.EventHandler(this.menuXuatHang_Click);
            // 
            // menuNhapHang
            // 
            this.menuNhapHang.Name = "menuNhapHang";
            this.menuNhapHang.Size = new System.Drawing.Size(78, 20);
            this.menuNhapHang.Text = "Nhập hàng";
            this.menuNhapHang.Click += new System.EventHandler(this.nhậpHàngToolStripMenuItem_Click);
            // 
            // picHinhanh
            // 
            this.picHinhanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhanh.Location = new System.Drawing.Point(6, 64);
            this.picHinhanh.Name = "picHinhanh";
            this.picHinhanh.Size = new System.Drawing.Size(94, 64);
            this.picHinhanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhanh.TabIndex = 20;
            this.picHinhanh.TabStop = false;
            // 
            // ma
            // 
            this.ma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ma.FillWeight = 8F;
            this.ma.HeaderText = "Mã phiếu";
            this.ma.Name = "ma";
            // 
            // nhanvien
            // 
            this.nhanvien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nhanvien.FillWeight = 13F;
            this.nhanvien.HeaderText = "Nhân viên tạo";
            this.nhanvien.Name = "nhanvien";
            // 
            // khachhang
            // 
            this.khachhang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.khachhang.FillWeight = 21F;
            this.khachhang.HeaderText = "Khách hàng";
            this.khachhang.Name = "khachhang";
            // 
            // thoigiantao
            // 
            this.thoigiantao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thoigiantao.FillWeight = 12F;
            this.thoigiantao.HeaderText = "Thời gian tạo";
            this.thoigiantao.Name = "thoigiantao";
            // 
            // soluong
            // 
            this.soluong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.soluong.FillWeight = 7F;
            this.soluong.HeaderText = "SL xuất";
            this.soluong.Name = "soluong";
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price.FillWeight = 7F;
            this.price.HeaderText = "Đơn giá";
            this.price.Name = "price";
            // 
            // sum
            // 
            this.sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sum.FillWeight = 10F;
            this.sum.HeaderText = "Thành tiền";
            this.sum.Name = "sum";
            // 
            // trangthai
            // 
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.Name = "trangthai";
            // 
            // detail
            // 
            this.detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.detail.HeaderText = "";
            this.detail.Image = ((System.Drawing.Image)(resources.GetObject("detail.Image")));
            this.detail.MinimumWidth = 6;
            this.detail.Name = "detail";
            this.detail.Width = 6;
            // 
            // HistorySanPhamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 518);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "HistorySanPhamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistory)).EndInit();
            this.artanPanel3.ResumeLayout(false);
            this.artanPanel3.PerformLayout();
            this.pnlBot.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView DGVHistory;
        private System.Windows.Forms.Label lbSoLuongTon;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPrice;
        private Helper.component.ArtanPanel artanPanel3;
        private System.Windows.Forms.TextBox txtSearch;
        private Helper.component.ArtanButton artanButton3;
        private System.Windows.Forms.Label lbSoLuongPhieu;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuXuatHang;
        private System.Windows.Forms.ToolStripMenuItem menuNhapHang;
        private System.Windows.Forms.PictureBox picHinhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn khachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoigiantao;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewImageColumn detail;
    }
}