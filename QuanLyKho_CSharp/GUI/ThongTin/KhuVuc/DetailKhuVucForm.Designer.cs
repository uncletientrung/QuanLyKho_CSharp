namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    partial class DetailKhuVucForm
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
            this.txtTenKhuVucKho = new System.Windows.Forms.TextBox();
            this.lblTenKhuVucKho = new System.Windows.Forms.Label();
            this.lbDetailKhuVucKho = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDong.Location = new System.Drawing.Point(52, 181);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(350, 35);
            this.btnDong.TabIndex = 29;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTenKhuVucKho
            // 
            this.txtTenKhuVucKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKhuVucKho.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtTenKhuVucKho.Location = new System.Drawing.Point(52, 125);
            this.txtTenKhuVucKho.Name = "txtTenKhuVucKho";
            this.txtTenKhuVucKho.Size = new System.Drawing.Size(350, 27);
            this.txtTenKhuVucKho.TabIndex = 22;
            // 
            // lblTenKhuVucKho
            // 
            this.lblTenKhuVucKho.AutoSize = true;
            this.lblTenKhuVucKho.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTenKhuVucKho.Location = new System.Drawing.Point(48, 100);
            this.lblTenKhuVucKho.Name = "lblTenKhuVucKho";
            this.lblTenKhuVucKho.Size = new System.Drawing.Size(123, 20);
            this.lblTenKhuVucKho.TabIndex = 21;
            this.lblTenKhuVucKho.Text = "Tên khu vực kho";
            // 
            // lbDetailKhuVucKho
            // 
            this.lbDetailKhuVucKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbDetailKhuVucKho.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetailKhuVucKho.ForeColor = System.Drawing.Color.White;
            this.lbDetailKhuVucKho.Location = new System.Drawing.Point(0, -2);
            this.lbDetailKhuVucKho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDetailKhuVucKho.Name = "lbDetailKhuVucKho";
            this.lbDetailKhuVucKho.Size = new System.Drawing.Size(448, 67);
            this.lbDetailKhuVucKho.TabIndex = 20;
            this.lbDetailKhuVucKho.Text = "Xem Chi Tiết Khu Vực Kho";
            this.lbDetailKhuVucKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DetailKhuVucForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 251);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenKhuVucKho);
            this.Controls.Add(this.lblTenKhuVucKho);
            this.Controls.Add(this.lbDetailKhuVucKho);
            this.Name = "DetailKhuVucForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailKhuVucForm";
            this.Load += new System.EventHandler(this.DetailKhuVucForm_Load);
            this.Shown += new System.EventHandler(this.DetailKhuVucKho_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTenKhuVucKho;
        private System.Windows.Forms.Label lblTenKhuVucKho;
        private System.Windows.Forms.Label lbDetailKhuVucKho;
    }
}