namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    partial class AddChatLieuForm
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
            this.lblAddCL = new System.Windows.Forms.Label();
            this.lblTenChatLieu = new System.Windows.Forms.Label();
            this.txtTenChatLieu = new System.Windows.Forms.TextBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblAddCL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 66);
            this.panel1.TabIndex = 1;
            // 
            // lblAddCL
            // 
            this.lblAddCL.AutoSize = true;
            this.lblAddCL.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblAddCL.ForeColor = System.Drawing.Color.White;
            this.lblAddCL.Location = new System.Drawing.Point(92, 9);
            this.lblAddCL.Name = "lblAddCL";
            this.lblAddCL.Size = new System.Drawing.Size(215, 37);
            this.lblAddCL.TabIndex = 1;
            this.lblAddCL.Text = "Thêm Chất Liệu";
            // 
            // lblTenChatLieu
            // 
            this.lblTenChatLieu.AutoSize = true;
            this.lblTenChatLieu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTenChatLieu.Location = new System.Drawing.Point(30, 84);
            this.lblTenChatLieu.Name = "lblTenChatLieu";
            this.lblTenChatLieu.Size = new System.Drawing.Size(97, 20);
            this.lblTenChatLieu.TabIndex = 2;
            this.lblTenChatLieu.Text = "Tên chất liệu";
            // 
            // txtTenChatLieu
            // 
            this.txtTenChatLieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenChatLieu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenChatLieu.Location = new System.Drawing.Point(34, 109);
            this.txtTenChatLieu.Name = "txtTenChatLieu";
            this.txtTenChatLieu.Size = new System.Drawing.Size(350, 27);
            this.txtTenChatLieu.TabIndex = 3;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDong.Location = new System.Drawing.Point(221, 166);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(163, 35);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(34, 166);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(163, 35);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // AddChatLieuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 226);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenChatLieu);
            this.Controls.Add(this.lblTenChatLieu);
            this.Controls.Add(this.panel1);
            this.Name = "AddChatLieuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddChatLieuForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddCL;
        private System.Windows.Forms.Label lblTenChatLieu;
        private System.Windows.Forms.TextBox txtTenChatLieu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuu;
    }
}