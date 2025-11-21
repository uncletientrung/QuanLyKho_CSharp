namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    partial class DetailSizeForm
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
            this.txtTenSize = new System.Windows.Forms.TextBox();
            this.lblTenSize = new System.Windows.Forms.Label();
            this.lbDetailSize = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDong.Location = new System.Drawing.Point(53, 254);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(350, 35);
            this.btnDong.TabIndex = 33;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTenSize
            // 
            this.txtTenSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSize.Location = new System.Drawing.Point(53, 114);
            this.txtTenSize.Name = "txtTenSize";
            this.txtTenSize.Size = new System.Drawing.Size(350, 25);
            this.txtTenSize.TabIndex = 32;
            // 
            // lblTenSize
            // 
            this.lblTenSize.AutoSize = true;
            this.lblTenSize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSize.Location = new System.Drawing.Point(49, 90);
            this.lblTenSize.Name = "lblTenSize";
            this.lblTenSize.Size = new System.Drawing.Size(95, 21);
            this.lblTenSize.TabIndex = 31;
            this.lblTenSize.Text = "Tên chất liệu";
            // 
            // lbDetailSize
            // 
            this.lbDetailSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbDetailSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDetailSize.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetailSize.ForeColor = System.Drawing.Color.White;
            this.lbDetailSize.Location = new System.Drawing.Point(0, 0);
            this.lbDetailSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDetailSize.Name = "lbDetailSize";
            this.lbDetailSize.Size = new System.Drawing.Size(472, 67);
            this.lbDetailSize.TabIndex = 30;
            this.lbDetailSize.Text = "Xem Chi Tiết Size";
            this.lbDetailSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(49, 170);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(63, 21);
            this.lblGhiChu.TabIndex = 34;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(53, 194);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 25);
            this.txtGhiChu.TabIndex = 35;
            // 
            // DetailSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 332);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenSize);
            this.Controls.Add(this.lblTenSize);
            this.Controls.Add(this.lbDetailSize);
            this.Name = "DetailSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailSizeForm";
            this.Load += new System.EventHandler(this.DetailSizeForm_Load);
            this.Shown += new System.EventHandler(this.DetailSizeForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTenSize;
        private System.Windows.Forms.Label lblTenSize;
        private System.Windows.Forms.Label lbDetailSize;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
    }
}