namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    partial class UCTongQuan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTongQuan));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTinhHangTon = new System.Windows.Forms.Button();
            this.btnTinhKhachHang = new System.Windows.Forms.Button();
            this.btnTinhPhieuNhap = new System.Windows.Forms.Button();
            this.btnTinhPhieuXuat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bieuDoDoanhThuTheoNgay = new LiveCharts.WinForms.CartesianChart();
            this.chartLoaiSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDoanhThu7ngay = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiSP)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7ngay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 100);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.096434F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.93674F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.686722F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.93674F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.686722F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.93674F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.686722F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.93674F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.096434F));
            this.tableLayoutPanel2.Controls.Add(this.btnTinhHangTon, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTinhKhachHang, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTinhPhieuNhap, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTinhPhieuXuat, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1043, 100);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnTinhHangTon
            // 
            this.btnTinhHangTon.BackColor = System.Drawing.Color.Aquamarine;
            this.btnTinhHangTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhHangTon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhHangTon.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhHangTon.Image")));
            this.btnTinhHangTon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhHangTon.Location = new System.Drawing.Point(97, 3);
            this.btnTinhHangTon.Name = "btnTinhHangTon";
            this.btnTinhHangTon.Size = new System.Drawing.Size(170, 94);
            this.btnTinhHangTon.TabIndex = 0;
            this.btnTinhHangTon.Text = "Sản phẩm hiện có";
            this.btnTinhHangTon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTinhHangTon.UseVisualStyleBackColor = false;
            this.btnTinhHangTon.Click += new System.EventHandler(this.btnTinhHangTon_Click);
            // 
            // btnTinhKhachHang
            // 
            this.btnTinhKhachHang.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTinhKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhKhachHang.Image")));
            this.btnTinhKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhKhachHang.Location = new System.Drawing.Point(321, 3);
            this.btnTinhKhachHang.Name = "btnTinhKhachHang";
            this.btnTinhKhachHang.Size = new System.Drawing.Size(170, 94);
            this.btnTinhKhachHang.TabIndex = 1;
            this.btnTinhKhachHang.Text = "Khách hàng";
            this.btnTinhKhachHang.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTinhKhachHang.UseVisualStyleBackColor = false;
            // 
            // btnTinhPhieuNhap
            // 
            this.btnTinhPhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTinhPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhPhieuNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhPhieuNhap.Image")));
            this.btnTinhPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhPhieuNhap.Location = new System.Drawing.Point(545, 3);
            this.btnTinhPhieuNhap.Name = "btnTinhPhieuNhap";
            this.btnTinhPhieuNhap.Size = new System.Drawing.Size(170, 94);
            this.btnTinhPhieuNhap.TabIndex = 2;
            this.btnTinhPhieuNhap.Text = "Phiếu nhập";
            this.btnTinhPhieuNhap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTinhPhieuNhap.UseVisualStyleBackColor = false;
            // 
            // btnTinhPhieuXuat
            // 
            this.btnTinhPhieuXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnTinhPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhPhieuXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhPhieuXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhPhieuXuat.Image")));
            this.btnTinhPhieuXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhPhieuXuat.Location = new System.Drawing.Point(769, 3);
            this.btnTinhPhieuXuat.Name = "btnTinhPhieuXuat";
            this.btnTinhPhieuXuat.Size = new System.Drawing.Size(170, 94);
            this.btnTinhPhieuXuat.TabIndex = 3;
            this.btnTinhPhieuXuat.Text = "Phiếu xuất";
            this.btnTinhPhieuXuat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTinhPhieuXuat.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 170);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1043, 25);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "THỐNG KÊ DOANH THU 7 NGÀY GẦN ĐÂY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(680, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "TỈ LỆ LOẠI SẢN PHẨM TRONG KHO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.bieuDoDoanhThuTheoNgay, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chartLoaiSP, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1043, 170);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // bieuDoDoanhThuTheoNgay
            // 
            this.bieuDoDoanhThuTheoNgay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bieuDoDoanhThuTheoNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bieuDoDoanhThuTheoNgay.Location = new System.Drawing.Point(3, 3);
            this.bieuDoDoanhThuTheoNgay.Name = "bieuDoDoanhThuTheoNgay";
            this.bieuDoDoanhThuTheoNgay.Size = new System.Drawing.Size(671, 164);
            this.bieuDoDoanhThuTheoNgay.TabIndex = 1;
            this.bieuDoDoanhThuTheoNgay.Text = "cartesianChart1";
            // 
            // chartLoaiSP
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLoaiSP.ChartAreas.Add(chartArea1);
            this.chartLoaiSP.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartLoaiSP.Legends.Add(legend1);
            this.chartLoaiSP.Location = new System.Drawing.Point(680, 3);
            this.chartLoaiSP.Name = "chartLoaiSP";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLoaiSP.Series.Add(series1);
            this.chartLoaiSP.Size = new System.Drawing.Size(360, 164);
            this.chartLoaiSP.TabIndex = 0;
            this.chartLoaiSP.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 276);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1043, 294);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.dgvDoanhThu7ngay, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1043, 294);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // dgvDoanhThu7ngay
            // 
            this.dgvDoanhThu7ngay.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDoanhThu7ngay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu7ngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu7ngay.GridColor = System.Drawing.Color.LightSlateGray;
            this.dgvDoanhThu7ngay.Location = new System.Drawing.Point(3, 3);
            this.dgvDoanhThu7ngay.Name = "dgvDoanhThu7ngay";
            this.dgvDoanhThu7ngay.RowHeadersWidth = 51;
            this.dgvDoanhThu7ngay.RowTemplate.Height = 24;
            this.dgvDoanhThu7ngay.Size = new System.Drawing.Size(1037, 288);
            this.dgvDoanhThu7ngay.TabIndex = 2;
            // 
            // UCTongQuan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCTongQuan";
            this.Size = new System.Drawing.Size(1043, 570);
            this.Load += new System.EventHandler(this.UCTongQuan_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLoaiSP)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7ngay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnTinhHangTon;
        private System.Windows.Forms.Button btnTinhKhachHang;
        private System.Windows.Forms.Button btnTinhPhieuNhap;
        private System.Windows.Forms.Button btnTinhPhieuXuat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLoaiSP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dgvDoanhThu7ngay;
        private LiveCharts.WinForms.CartesianChart bieuDoDoanhThuTheoNgay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
