﻿namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    partial class DetailChatLieuForm
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
            this.txtTenChatLieu = new System.Windows.Forms.TextBox();
            this.lblTenChatLieu = new System.Windows.Forms.Label();
            this.lbDetailChatLieu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnDong.Location = new System.Drawing.Point(53, 198);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(350, 35);
            this.btnDong.TabIndex = 29;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTenChatLieu
            // 
            this.txtTenChatLieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenChatLieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChatLieu.Location = new System.Drawing.Point(53, 125);
            this.txtTenChatLieu.Name = "txtTenChatLieu";
            this.txtTenChatLieu.Size = new System.Drawing.Size(350, 25);
            this.txtTenChatLieu.TabIndex = 22;
            // 
            // lblTenChatLieu
            // 
            this.lblTenChatLieu.AutoSize = true;
            this.lblTenChatLieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChatLieu.Location = new System.Drawing.Point(49, 100);
            this.lblTenChatLieu.Name = "lblTenChatLieu";
            this.lblTenChatLieu.Size = new System.Drawing.Size(95, 21);
            this.lblTenChatLieu.TabIndex = 21;
            this.lblTenChatLieu.Text = "Tên chất liệu";
            // 
            // lbDetailChatLieu
            // 
            this.lbDetailChatLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbDetailChatLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDetailChatLieu.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetailChatLieu.ForeColor = System.Drawing.Color.White;
            this.lbDetailChatLieu.Location = new System.Drawing.Point(0, 0);
            this.lbDetailChatLieu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDetailChatLieu.Name = "lbDetailChatLieu";
            this.lbDetailChatLieu.Size = new System.Drawing.Size(448, 67);
            this.lbDetailChatLieu.TabIndex = 20;
            this.lbDetailChatLieu.Text = "Xem Chi Tiết Chất Liệu";
            this.lbDetailChatLieu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DetailChatLieuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 282);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenChatLieu);
            this.Controls.Add(this.lblTenChatLieu);
            this.Controls.Add(this.lbDetailChatLieu);
            this.Name = "DetailChatLieuForm";
            this.Text = "DetailChatLieuForm";
            this.Load += new System.EventHandler(this.DetailChatLieuForm_Load);
            this.Shown += new System.EventHandler(this.DetailChatLieuForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTenChatLieu;
        private System.Windows.Forms.Label lblTenChatLieu;
        private System.Windows.Forms.Label lbDetailChatLieu;
    }
}