namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu
{
    partial class ThongKeTheoNam
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.namEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.namStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bieuDoDoanhThuTheoNam = new LiveCharts.WinForms.CartesianChart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvThongKeDoanhThuTheoNam = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeDoanhThuTheoNam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 39);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnLamMoi, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnThongKe, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.namEnd, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.namStart, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(851, 39);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(598, 2);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(79, 35);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(513, 2);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(79, 35);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // namEnd
            // 
            this.namEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.namEnd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namEnd.Location = new System.Drawing.Point(428, 2);
            this.namEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.namEnd.Name = "namEnd";
            this.namEnd.Size = new System.Drawing.Size(79, 30);
            this.namEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tới năm:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namStart
            // 
            this.namStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.namStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namStart.Location = new System.Drawing.Point(258, 2);
            this.namStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.namStart.Name = "namStart";
            this.namStart.Size = new System.Drawing.Size(79, 30);
            this.namStart.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ năm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.bieuDoDoanhThuTheoNam);
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 113);
            this.panel2.TabIndex = 1;
            // 
            // bieuDoDoanhThuTheoNam
            // 
            this.bieuDoDoanhThuTheoNam.BackColor = System.Drawing.Color.White;
            this.bieuDoDoanhThuTheoNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bieuDoDoanhThuTheoNam.Location = new System.Drawing.Point(0, 0);
            this.bieuDoDoanhThuTheoNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bieuDoDoanhThuTheoNam.Name = "bieuDoDoanhThuTheoNam";
            this.bieuDoDoanhThuTheoNam.Size = new System.Drawing.Size(848, 113);
            this.bieuDoDoanhThuTheoNam.TabIndex = 0;
            this.bieuDoDoanhThuTheoNam.Text = "cartesianChart1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvThongKeDoanhThuTheoNam);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 162);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(851, 354);
            this.panel3.TabIndex = 2;
            // 
            // dgvThongKeDoanhThuTheoNam
            // 
            this.dgvThongKeDoanhThuTheoNam.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeDoanhThuTheoNam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeDoanhThuTheoNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeDoanhThuTheoNam.Location = new System.Drawing.Point(0, 0);
            this.dgvThongKeDoanhThuTheoNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvThongKeDoanhThuTheoNam.Name = "dgvThongKeDoanhThuTheoNam";
            this.dgvThongKeDoanhThuTheoNam.RowHeadersWidth = 51;
            this.dgvThongKeDoanhThuTheoNam.RowTemplate.Height = 24;
            this.dgvThongKeDoanhThuTheoNam.Size = new System.Drawing.Size(851, 354);
            this.dgvThongKeDoanhThuTheoNam.TabIndex = 0;
            // 
            // ThongKeTheoNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ThongKeTheoNam";
            this.Size = new System.Drawing.Size(851, 516);
            this.Load += new System.EventHandler(this.load_UC);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeDoanhThuTheoNam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DateTimePicker namStart;
        private System.Windows.Forms.DateTimePicker namEnd;
        private LiveCharts.WinForms.CartesianChart bieuDoDoanhThuTheoNam;
        private System.Windows.Forms.DataGridView dgvThongKeDoanhThuTheoNam;
    }
}
