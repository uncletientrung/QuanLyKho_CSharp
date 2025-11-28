namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    partial class UpdateNhaCungCapForm
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
            this.txtTenNhaCungCap = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUpdateNCC = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTenNhaCungCap = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTenNhaCungCap
            // 
            this.txtTenNhaCungCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenNhaCungCap.Location = new System.Drawing.Point(33, 110);
            this.txtTenNhaCungCap.Name = "txtTenNhaCungCap";
            this.txtTenNhaCungCap.Size = new System.Drawing.Size(350, 27);
            this.txtTenNhaCungCap.TabIndex = 13;
            this.txtTenNhaCungCap.TextChanged += new System.EventHandler(this.txtTenNhaCungCap_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblUpdateNCC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 66);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblUpdateNCC
            // 
            this.lblUpdateNCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblUpdateNCC.AutoSize = true;
            this.lblUpdateNCC.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblUpdateNCC.ForeColor = System.Drawing.Color.White;
            this.lblUpdateNCC.Location = new System.Drawing.Point(80, 9);
            this.lblUpdateNCC.Name = "lblUpdateNCC";
            this.lblUpdateNCC.Size = new System.Drawing.Size(253, 37);
            this.lblUpdateNCC.TabIndex = 1;
            this.lblUpdateNCC.Text = "Sửa Nhà Cung Cấp";
            this.lblUpdateNCC.Click += new System.EventHandler(this.lblUpdateNCC_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(33, 355);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(163, 35);
            this.btnLuu.TabIndex = 21;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDong.Location = new System.Drawing.Point(220, 355);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(163, 35);
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtEmail.Location = new System.Drawing.Point(33, 304);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(350, 27);
            this.txtEmail.TabIndex = 19;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(29, 280);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 20);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSoDienThoai.Location = new System.Drawing.Point(33, 240);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(350, 27);
            this.txtSoDienThoai.TabIndex = 17;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSoDienThoai.Location = new System.Drawing.Point(29, 216);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(100, 20);
            this.lblSoDienThoai.TabIndex = 16;
            this.lblSoDienThoai.Text = "Số điện thoại";
            this.lblSoDienThoai.Click += new System.EventHandler(this.lblSoDienThoai_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtDiaChi.Location = new System.Drawing.Point(33, 174);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(350, 27);
            this.txtDiaChi.TabIndex = 15;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.Location = new System.Drawing.Point(29, 150);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(56, 20);
            this.lblDiaChi.TabIndex = 14;
            this.lblDiaChi.Text = "Địa chỉ";
            this.lblDiaChi.Click += new System.EventHandler(this.lblDiaChi_Click);
            // 
            // lblTenNhaCungCap
            // 
            this.lblTenNhaCungCap.AutoSize = true;
            this.lblTenNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTenNhaCungCap.Location = new System.Drawing.Point(29, 85);
            this.lblTenNhaCungCap.Name = "lblTenNhaCungCap";
            this.lblTenNhaCungCap.Size = new System.Drawing.Size(130, 20);
            this.lblTenNhaCungCap.TabIndex = 12;
            this.lblTenNhaCungCap.Text = "Tên nhà cung cấp";
            this.lblTenNhaCungCap.Click += new System.EventHandler(this.lblTenNhaCungCap_Click);
            // 
            // UpdateNhaCungCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 431);
            this.Controls.Add(this.txtTenNhaCungCap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblTenNhaCungCap);
            this.Name = "UpdateNhaCungCapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateNhaCungCapForm";
            this.Load += new System.EventHandler(this.UpdateNhaCungCapForm_Load);
            this.Shown += new System.EventHandler(this.UpdateNhanVienForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenNhaCungCap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUpdateNCC;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTenNhaCungCap;
    }
}