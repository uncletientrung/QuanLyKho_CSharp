namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    partial class AddSizeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddSize = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtTenSize = new System.Windows.Forms.TextBox();
            this.lblTenSize = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblAddSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 66);
            this.panel1.TabIndex = 17;
            // 
            // lblAddSize
            // 
            this.lblAddSize.AutoSize = true;
            this.lblAddSize.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblAddSize.ForeColor = System.Drawing.Color.White;
            this.lblAddSize.Location = new System.Drawing.Point(127, 9);
            this.lblAddSize.Name = "lblAddSize";
            this.lblAddSize.Size = new System.Drawing.Size(150, 37);
            this.lblAddSize.TabIndex = 1;
            this.lblAddSize.Text = "Thêm Loại";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(34, 257);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(163, 35);
            this.btnLuu.TabIndex = 21;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDong.Location = new System.Drawing.Point(221, 257);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(163, 35);
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTenSize
            // 
            this.txtTenSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSize.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenSize.Location = new System.Drawing.Point(34, 130);
            this.txtTenSize.Name = "txtTenSize";
            this.txtTenSize.Size = new System.Drawing.Size(350, 27);
            this.txtTenSize.TabIndex = 19;
            // 
            // lblTenSize
            // 
            this.lblTenSize.AutoSize = true;
            this.lblTenSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTenSize.Location = new System.Drawing.Point(30, 105);
            this.lblTenSize.Name = "lblTenSize";
            this.lblTenSize.Size = new System.Drawing.Size(64, 20);
            this.lblTenSize.TabIndex = 18;
            this.lblTenSize.Text = "Tên size";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtGhiChu.Location = new System.Drawing.Point(34, 206);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 27);
            this.txtGhiChu.TabIndex = 22;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(30, 182);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(62, 20);
            this.lblGhiChu.TabIndex = 23;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // AddSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 322);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenSize);
            this.Controls.Add(this.lblTenSize);
            this.Name = "AddSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSizeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddSize;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTenSize;
        private System.Windows.Forms.Label lblTenSize;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
    }
}