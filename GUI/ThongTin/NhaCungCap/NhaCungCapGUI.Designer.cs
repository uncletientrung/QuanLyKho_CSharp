namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    partial class NhaCungCapGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaCungCapGUI));
            this.label1 = new System.Windows.Forms.Label();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.roundedButton2 = new RoundedButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDanhSachNhaCungCap = new System.Windows.Forms.Label();
            this.DGVNhaCungCap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quản lý nhà cung cấp";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.txSearch.TabIndex = 10;
            this.txSearch.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            this.txSearch.Enter += new System.EventHandler(this.txSearch_Enter);
            this.txSearch.Leave += new System.EventHandler(this.txSearch_Leave);
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
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txSearch);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 24);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.btnExcel.TabIndex = 14;
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
            this.roundedButton2.TabIndex = 9;
            this.roundedButton2.Text = "+ Thêm";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblDanhSachNhaCungCap);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1113, 146);
            this.panel3.TabIndex = 17;
            // 
            // lblDanhSachNhaCungCap
            // 
            this.lblDanhSachNhaCungCap.AutoSize = true;
            this.lblDanhSachNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDanhSachNhaCungCap.ForeColor = System.Drawing.Color.Black;
            this.lblDanhSachNhaCungCap.Location = new System.Drawing.Point(3, 93);
            this.lblDanhSachNhaCungCap.Name = "lblDanhSachNhaCungCap";
            this.lblDanhSachNhaCungCap.Size = new System.Drawing.Size(195, 21);
            this.lblDanhSachNhaCungCap.TabIndex = 17;
            this.lblDanhSachNhaCungCap.Text = "Danh sách nhà cung cấp";
            // 
            // DGVNhaCungCap
            // 
            this.DGVNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVNhaCungCap.Location = new System.Drawing.Point(0, 146);
            this.DGVNhaCungCap.Name = "DGVNhaCungCap";
            this.DGVNhaCungCap.Size = new System.Drawing.Size(1113, 450);
            this.DGVNhaCungCap.TabIndex = 18;
            this.DGVNhaCungCap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVNhaCungCap_CellContentClick);
            this.DGVNhaCungCap.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVNhaCungCap_CellMouseClick);
            this.DGVNhaCungCap.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVNhaCUngCap_CellPainting);
            // 
            // NhaCungCapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 596);
            this.Controls.Add(this.DGVNhaCungCap);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Name = "NhaCungCapGUI";
            this.Text = "NhaCungCapGUI";
            this.Load += new System.EventHandler(this.NhaCungCapGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNhaCungCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.Button btnExcel;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDanhSachNhaCungCap;
        private System.Windows.Forms.DataGridView DGVNhaCungCap;
    }
}