namespace QuanLyKho_CSharp.GUI.SanPham
{
    partial class DetailSanPhamForm
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
            this.lblChiTietSanPham = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblmasp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMasp = new System.Windows.Forms.TextBox();
            this.txtTensp = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.txtMachatlieu = new System.Windows.Forms.TextBox();
            this.txtMaloai = new System.Windows.Forms.TextBox();
            this.txtMakhuvuc = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMasize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.picHinhanh = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChiTietSanPham
            // 
            this.lblChiTietSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblChiTietSanPham.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTietSanPham.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblChiTietSanPham.Location = new System.Drawing.Point(0, 2);
            this.lblChiTietSanPham.Name = "lblChiTietSanPham";
            this.lblChiTietSanPham.Size = new System.Drawing.Size(834, 61);
            this.lblChiTietSanPham.TabIndex = 1;
            this.lblChiTietSanPham.Text = "Chi Tiết Hàng";
            this.lblChiTietSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên sản phẩm:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblmasp
            // 
            this.lblmasp.AutoSize = true;
            this.lblmasp.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmasp.Location = new System.Drawing.Point(3, 16);
            this.lblmasp.Name = "lblmasp";
            this.lblmasp.Size = new System.Drawing.Size(120, 25);
            this.lblmasp.TabIndex = 3;
            this.lblmasp.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã chất liệu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mã loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Mã khu vực";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtMasp
            // 
            this.txtMasp.Location = new System.Drawing.Point(158, 10);
            this.txtMasp.Name = "txtMasp";
            this.txtMasp.Size = new System.Drawing.Size(374, 31);
            this.txtMasp.TabIndex = 9;
            // 
            // txtTensp
            // 
            this.txtTensp.Location = new System.Drawing.Point(158, 58);
            this.txtTensp.Name = "txtTensp";
            this.txtTensp.Size = new System.Drawing.Size(374, 31);
            this.txtTensp.TabIndex = 10;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(158, 106);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(374, 31);
            this.txtSoluong.TabIndex = 11;
            // 
            // txtDongia
            // 
            this.txtDongia.Location = new System.Drawing.Point(158, 157);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(374, 31);
            this.txtDongia.TabIndex = 12;
            // 
            // txtMachatlieu
            // 
            this.txtMachatlieu.Location = new System.Drawing.Point(158, 206);
            this.txtMachatlieu.Name = "txtMachatlieu";
            this.txtMachatlieu.Size = new System.Drawing.Size(374, 31);
            this.txtMachatlieu.TabIndex = 13;
            // 
            // txtMaloai
            // 
            this.txtMaloai.Location = new System.Drawing.Point(158, 254);
            this.txtMaloai.Name = "txtMaloai";
            this.txtMaloai.Size = new System.Drawing.Size(374, 31);
            this.txtMaloai.TabIndex = 14;
            // 
            // txtMakhuvuc
            // 
            this.txtMakhuvuc.Location = new System.Drawing.Point(158, 305);
            this.txtMakhuvuc.Name = "txtMakhuvuc";
            this.txtMakhuvuc.Size = new System.Drawing.Size(374, 31);
            this.txtMakhuvuc.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtMasize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblmasp);
            this.panel1.Controls.Add(this.txtMakhuvuc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMasp);
            this.panel1.Controls.Add(this.txtMaloai);
            this.panel1.Controls.Add(this.txtMachatlieu);
            this.panel1.Controls.Add(this.txtDongia);
            this.panel1.Controls.Add(this.txtSoluong);
            this.panel1.Controls.Add(this.txtTensp);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(299, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 397);
            this.panel1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mã size";
            // 
            // txtMasize
            // 
            this.txtMasize.Location = new System.Drawing.Point(158, 360);
            this.txtMasize.Name = "txtMasize";
            this.txtMasize.Size = new System.Drawing.Size(374, 31);
            this.txtMasize.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Đơn giá";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblChiTietSanPham);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 63);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 461);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(836, 96);
            this.panel3.TabIndex = 18;
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(352, 19);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(134, 47);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // picHinhanh
            // 
            this.picHinhanh.Dock = System.Windows.Forms.DockStyle.Left;
            this.picHinhanh.Location = new System.Drawing.Point(0, 63);
            this.picHinhanh.Name = "picHinhanh";
            this.picHinhanh.Size = new System.Drawing.Size(296, 398);
            this.picHinhanh.TabIndex = 19;
            this.picHinhanh.TabStop = false;
            // 
            // DetailSanPhamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 557);
            this.Controls.Add(this.picHinhanh);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DetailSanPhamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailSanPhamForm";
            this.Load += new System.EventHandler(this.detailSanPhamLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblChiTietSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblmasp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMasp;
        private System.Windows.Forms.TextBox txtTensp;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.TextBox txtMachatlieu;
        private System.Windows.Forms.TextBox txtMaloai;
        private System.Windows.Forms.TextBox txtMakhuvuc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMasize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.PictureBox picHinhanh;
    }
}