namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    partial class DetailLoaiForm
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
            this.btnDong = new System.Windows.Forms.Button();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.lblTenLoai = new System.Windows.Forms.Label();
            this.lbDetailLoai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDong.Location = new System.Drawing.Point(53, 183);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(350, 35);
            this.btnDong.TabIndex = 33;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenLoai.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenLoai.Location = new System.Drawing.Point(53, 125);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(350, 27);
            this.txtTenLoai.TabIndex = 32;
            this.txtTenLoai.TextChanged += new System.EventHandler(this.txtTenLoai_TextChanged);
            // 
            // lblTenLoai
            // 
            this.lblTenLoai.AutoSize = true;
            this.lblTenLoai.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTenLoai.Location = new System.Drawing.Point(49, 100);
            this.lblTenLoai.Name = "lblTenLoai";
            this.lblTenLoai.Size = new System.Drawing.Size(63, 20);
            this.lblTenLoai.TabIndex = 31;
            this.lblTenLoai.Text = "Tên loại";
            // 
            // lbDetailLoai
            // 
            this.lbDetailLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbDetailLoai.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDetailLoai.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetailLoai.ForeColor = System.Drawing.Color.White;
            this.lbDetailLoai.Location = new System.Drawing.Point(0, 0);
            this.lbDetailLoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDetailLoai.Name = "lbDetailLoai";
            this.lbDetailLoai.Size = new System.Drawing.Size(448, 67);
            this.lbDetailLoai.TabIndex = 30;
            this.lbDetailLoai.Text = "Xem Chi Tiết Loại";
            this.lbDetailLoai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DetailLoaiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 254);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenLoai);
            this.Controls.Add(this.lblTenLoai);
            this.Controls.Add(this.lbDetailLoai);
            this.Name = "DetailLoaiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailLoaiForm";
            this.Load += new System.EventHandler(this.DetailLoaiForm_Load);
            this.Shown += new System.EventHandler(this.DetailLoaiForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label lblTenLoai;
        private System.Windows.Forms.Label lbDetailLoai;
    }
}