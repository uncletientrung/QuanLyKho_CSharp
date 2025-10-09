namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    partial class LoaiGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaiGUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoai = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDanhSachLoai = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.roundedButton2 = new RoundedButton();
            this.lblChatLieu = new System.Windows.Forms.Label();
            this.DGVLoai = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblLoai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 149);
            this.panel1.TabIndex = 0;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.ForeColor = System.Drawing.Color.Black;
            this.lblLoai.Location = new System.Drawing.Point(12, 28);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(49, 25);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Loại";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txSearch);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(17, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 24);
            this.panel3.TabIndex = 2;
            // 
            // txSearch
            // 
            this.txSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSearch.ForeColor = System.Drawing.Color.Black;
            this.txSearch.Location = new System.Drawing.Point(46, 0);
            this.txSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txSearch.Name = "txSearch";
            this.txSearch.Size = new System.Drawing.Size(307, 22);
            this.txSearch.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDanhSachLoai);
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.roundedButton2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblChatLieu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 149);
            this.panel2.TabIndex = 3;
            // 
            // lblDanhSachLoai
            // 
            this.lblDanhSachLoai.AutoSize = true;
            this.lblDanhSachLoai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDanhSachLoai.ForeColor = System.Drawing.Color.Black;
            this.lblDanhSachLoai.Location = new System.Drawing.Point(3, 94);
            this.lblDanhSachLoai.Name = "lblDanhSachLoai";
            this.lblDanhSachLoai.Size = new System.Drawing.Size(122, 21);
            this.lblDanhSachLoai.TabIndex = 16;
            this.lblDanhSachLoai.Text = "Danh sách loại";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(513, 67);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(1);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(131, 24);
            this.btnExcel.TabIndex = 15;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(209)))));
            this.roundedButton2.FlatAppearance.BorderSize = 0;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.roundedButton2.ForeColor = System.Drawing.Color.Black;
            this.roundedButton2.Location = new System.Drawing.Point(378, 67);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Radius = 5;
            this.roundedButton2.Size = new System.Drawing.Size(131, 24);
            this.roundedButton2.TabIndex = 10;
            this.roundedButton2.Text = "+ Thêm";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // lblChatLieu
            // 
            this.lblChatLieu.AutoSize = true;
            this.lblChatLieu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatLieu.ForeColor = System.Drawing.Color.Black;
            this.lblChatLieu.Location = new System.Drawing.Point(12, 28);
            this.lblChatLieu.Name = "lblChatLieu";
            this.lblChatLieu.Size = new System.Drawing.Size(89, 25);
            this.lblChatLieu.TabIndex = 1;
            this.lblChatLieu.Text = "Chất liệu";
            // 
            // DGVLoai
            // 
            this.DGVLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVLoai.Location = new System.Drawing.Point(0, 149);
            this.DGVLoai.Name = "DGVLoai";
            this.DGVLoai.Size = new System.Drawing.Size(1113, 447);
            this.DGVLoai.TabIndex = 2;
            this.DGVLoai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLoai_CellContentClick);
            this.DGVLoai.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVLoai_CellMouseClick);
            this.DGVLoai.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVLoai_Painting);
            // 
            // LoaiGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 596);
            this.Controls.Add(this.DGVLoai);
            this.Controls.Add(this.panel1);
            this.Name = "LoaiGUI";
            this.Text = "LoaiGUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDanhSachLoai;
        private System.Windows.Forms.Button btnExcel;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblChatLieu;
        private System.Windows.Forms.DataGridView DGVLoai;
    }
}