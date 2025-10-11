using System.Drawing;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    partial class GUITongQuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUITongQuan));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTinhHangTon = new System.Windows.Forms.Button();
            this.bbtnTinhKhachHang = new System.Windows.Forms.Button();
            this.btnTinhPhieuNhap = new System.Windows.Forms.Button();
            this.btnTinhPhieuXuat = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDoanhThu7ngay = new System.Windows.Forms.DataGridView();
            this.chartDoanhThu7ngayGanDay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7ngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu7ngayGanDay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button5, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tổng quan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(114, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Tồn kho";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(225, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 26);
            this.button3.TabIndex = 2;
            this.button3.Text = "Doanh thu";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(336, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 26);
            this.button4.TabIndex = 3;
            this.button4.Text = "Nhà cung cấp";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(447, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 26);
            this.button5.TabIndex = 4;
            this.button5.Text = "Khách hàng";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1399, 34);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1399, 85);
            this.panel2.TabIndex = 2;
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
            this.tableLayoutPanel2.Controls.Add(this.bbtnTinhKhachHang, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTinhPhieuNhap, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTinhPhieuXuat, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1399, 85);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnTinhHangTon
            // 
            this.btnTinhHangTon.BackColor = System.Drawing.Color.Aquamarine;
            this.btnTinhHangTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhHangTon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhHangTon.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhHangTon.Image")));
            this.btnTinhHangTon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhHangTon.Location = new System.Drawing.Point(130, 3);
            this.btnTinhHangTon.Name = "btnTinhHangTon";
            this.btnTinhHangTon.Size = new System.Drawing.Size(230, 79);
            this.btnTinhHangTon.TabIndex = 0;
            this.btnTinhHangTon.Text = "Hàng tồn kho";
            this.btnTinhHangTon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTinhHangTon.UseVisualStyleBackColor = false;
            // 
            // bbtnTinhKhachHang
            // 
            this.bbtnTinhKhachHang.BackColor = System.Drawing.Color.SkyBlue;
            this.bbtnTinhKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bbtnTinhKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbtnTinhKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("bbtnTinhKhachHang.Image")));
            this.bbtnTinhKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbtnTinhKhachHang.Location = new System.Drawing.Point(431, 3);
            this.bbtnTinhKhachHang.Name = "bbtnTinhKhachHang";
            this.bbtnTinhKhachHang.Size = new System.Drawing.Size(230, 79);
            this.bbtnTinhKhachHang.TabIndex = 1;
            this.bbtnTinhKhachHang.Text = "Khách hàng";
            this.bbtnTinhKhachHang.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bbtnTinhKhachHang.UseVisualStyleBackColor = false;
            // 
            // btnTinhPhieuNhap
            // 
            this.btnTinhPhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTinhPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTinhPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhPhieuNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhPhieuNhap.Image")));
            this.btnTinhPhieuNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhPhieuNhap.Location = new System.Drawing.Point(732, 3);
            this.btnTinhPhieuNhap.Name = "btnTinhPhieuNhap";
            this.btnTinhPhieuNhap.Size = new System.Drawing.Size(230, 79);
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
            this.btnTinhPhieuXuat.Location = new System.Drawing.Point(1033, 3);
            this.btnTinhPhieuXuat.Name = "btnTinhPhieuXuat";
            this.btnTinhPhieuXuat.Size = new System.Drawing.Size(230, 79);
            this.btnTinhPhieuXuat.TabIndex = 3;
            this.btnTinhPhieuXuat.Text = "Phiếu xuất";
            this.btnTinhPhieuXuat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTinhPhieuXuat.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1399, 577);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.chartDoanhThu7ngayGanDay, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1399, 577);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top 3 xuất kho nhiều nhất";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 514);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1399, 182);
            this.panel5.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.dgvDoanhThu7ngay, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1399, 182);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(912, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.00681F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.99319F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(484, 176);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // dgvDoanhThu7ngay
            // 
            this.dgvDoanhThu7ngay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu7ngay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu7ngay.Location = new System.Drawing.Point(3, 3);
            this.dgvDoanhThu7ngay.Name = "dgvDoanhThu7ngay";
            this.dgvDoanhThu7ngay.RowHeadersWidth = 51;
            this.dgvDoanhThu7ngay.RowTemplate.Height = 24;
            this.dgvDoanhThu7ngay.Size = new System.Drawing.Size(903, 176);
            this.dgvDoanhThu7ngay.TabIndex = 2;
            // 
            // chartDoanhThu7ngayGanDay
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu7ngayGanDay.ChartAreas.Add(chartArea1);
            this.chartDoanhThu7ngayGanDay.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanhThu7ngayGanDay.Legends.Add(legend1);
            this.chartDoanhThu7ngayGanDay.Location = new System.Drawing.Point(3, 3);
            this.chartDoanhThu7ngayGanDay.Name = "chartDoanhThu7ngayGanDay";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu7ngayGanDay.Series.Add(series1);
            this.chartDoanhThu7ngayGanDay.Size = new System.Drawing.Size(903, 571);
            this.chartDoanhThu7ngayGanDay.TabIndex = 0;
            this.chartDoanhThu7ngayGanDay.Text = "chart1";
            // 
            // ThongKeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 696);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ThongKeGUI";
            this.Text = "ThongKeGUI";
            this.Load += new System.EventHandler(this.ThongKeGUI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7ngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu7ngayGanDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnTinhHangTon;
        private System.Windows.Forms.Button bbtnTinhKhachHang;
        private System.Windows.Forms.Button btnTinhPhieuNhap;
        private System.Windows.Forms.Button btnTinhPhieuXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dgvDoanhThu7ngay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu7ngayGanDay;
    }
}