namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    partial class UpdateKhuVucForm
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
            this.txtTenKhuVucKho = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUpdateKVK = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTenKhuVucKho = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTenKhuVucKho
            // 
            this.txtTenKhuVucKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKhuVucKho.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenKhuVucKho.Location = new System.Drawing.Point(33, 111);
            this.txtTenKhuVucKho.Name = "txtTenKhuVucKho";
            this.txtTenKhuVucKho.Size = new System.Drawing.Size(350, 27);
            this.txtTenKhuVucKho.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblUpdateKVK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 66);
            this.panel1.TabIndex = 22;
            // 
            // lblUpdateKVK
            // 
            this.lblUpdateKVK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblUpdateKVK.AutoSize = true;
            this.lblUpdateKVK.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblUpdateKVK.ForeColor = System.Drawing.Color.White;
            this.lblUpdateKVK.Location = new System.Drawing.Point(103, 9);
            this.lblUpdateKVK.Name = "lblUpdateKVK";
            this.lblUpdateKVK.Size = new System.Drawing.Size(236, 37);
            this.lblUpdateKVK.TabIndex = 1;
            this.lblUpdateKVK.Text = "Sửa Khu Vực Kho";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(33, 181);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(163, 35);
            this.btnLuu.TabIndex = 32;
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
            this.btnDong.Location = new System.Drawing.Point(220, 181);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(163, 35);
            this.btnDong.TabIndex = 31;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lblTenKhuVucKho
            // 
            this.lblTenKhuVucKho.AutoSize = true;
            this.lblTenKhuVucKho.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTenKhuVucKho.Location = new System.Drawing.Point(29, 86);
            this.lblTenKhuVucKho.Name = "lblTenKhuVucKho";
            this.lblTenKhuVucKho.Size = new System.Drawing.Size(123, 20);
            this.lblTenKhuVucKho.TabIndex = 23;
            this.lblTenKhuVucKho.Text = "Tên khu vực kho";
            // 
            // UpdateKhuVucForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 251);
            this.Controls.Add(this.txtTenKhuVucKho);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblTenKhuVucKho);
            this.Name = "UpdateKhuVucForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateKhuVucForm";
            this.Load += new System.EventHandler(this.UpdateKhuVucForm_Load);
            this.Shown += new System.EventHandler(this.UpdateKhuVucKhoForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenKhuVucKho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUpdateKVK;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblTenKhuVucKho;
    }
}