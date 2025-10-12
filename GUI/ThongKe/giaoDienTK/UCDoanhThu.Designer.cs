namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    partial class UCDoanhThu
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
            this.menuTable = new System.Windows.Forms.TableLayoutPanel();
            this.btnTKTheoNam = new System.Windows.Forms.Button();
            this.btnThongKeTheoQuy = new System.Windows.Forms.Button();
            this.btnThongKeTheoThang = new System.Windows.Forms.Button();
            this.btnThongKeTheoNgay = new System.Windows.Forms.Button();
            this.panelThongKeBody = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.menuTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 44);
            this.panel1.TabIndex = 1;
            // 
            // menuTable
            // 
            this.menuTable.ColumnCount = 4;
            this.menuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.05263F));
            this.menuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.menuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.05263F));
            this.menuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.84211F));
            this.menuTable.Controls.Add(this.btnTKTheoNam, 0, 0);
            this.menuTable.Controls.Add(this.btnThongKeTheoQuy, 1, 0);
            this.menuTable.Controls.Add(this.btnThongKeTheoThang, 2, 0);
            this.menuTable.Controls.Add(this.btnThongKeTheoNgay, 3, 0);
            this.menuTable.Location = new System.Drawing.Point(0, 0);
            this.menuTable.Name = "menuTable";
            this.menuTable.RowCount = 1;
            this.menuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuTable.Size = new System.Drawing.Size(1035, 44);
            this.menuTable.TabIndex = 0;
            // 
            // btnTKTheoNam
            // 
            this.btnTKTheoNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTKTheoNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKTheoNam.Location = new System.Drawing.Point(3, 3);
            this.btnTKTheoNam.Name = "btnTKTheoNam";
            this.btnTKTheoNam.Size = new System.Drawing.Size(232, 38);
            this.btnTKTheoNam.TabIndex = 0;
            this.btnTKTheoNam.Text = "Thống kê theo năm";
            this.btnTKTheoNam.UseVisualStyleBackColor = true;
            this.btnTKTheoNam.Click += new System.EventHandler(this.btnTKTheoNam_Click);
            // 
            // btnThongKeTheoQuy
            // 
            this.btnThongKeTheoQuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKeTheoQuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeTheoQuy.Location = new System.Drawing.Point(241, 3);
            this.btnThongKeTheoQuy.Name = "btnThongKeTheoQuy";
            this.btnThongKeTheoQuy.Size = new System.Drawing.Size(211, 38);
            this.btnThongKeTheoQuy.TabIndex = 1;
            this.btnThongKeTheoQuy.Text = "Thống kê theo quý";
            this.btnThongKeTheoQuy.UseVisualStyleBackColor = true;
            this.btnThongKeTheoQuy.Click += new System.EventHandler(this.btnThongKeTheoQuy_Click);
            // 
            // btnThongKeTheoThang
            // 
            this.btnThongKeTheoThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKeTheoThang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeTheoThang.Location = new System.Drawing.Point(458, 3);
            this.btnThongKeTheoThang.Name = "btnThongKeTheoThang";
            this.btnThongKeTheoThang.Size = new System.Drawing.Size(232, 38);
            this.btnThongKeTheoThang.TabIndex = 1;
            this.btnThongKeTheoThang.Text = "Thống kê theo tháng";
            this.btnThongKeTheoThang.UseVisualStyleBackColor = true;
            this.btnThongKeTheoThang.Click += new System.EventHandler(this.btnThongKeTheoThang_Click);
            // 
            // btnThongKeTheoNgay
            // 
            this.btnThongKeTheoNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKeTheoNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeTheoNgay.Location = new System.Drawing.Point(696, 3);
            this.btnThongKeTheoNgay.Name = "btnThongKeTheoNgay";
            this.btnThongKeTheoNgay.Size = new System.Drawing.Size(336, 38);
            this.btnThongKeTheoNgay.TabIndex = 1;
            this.btnThongKeTheoNgay.Text = "Thống kê theo ngày trong tháng";
            this.btnThongKeTheoNgay.UseVisualStyleBackColor = true;
            this.btnThongKeTheoNgay.Click += new System.EventHandler(this.btnThongKeTheoNgay_Click);
            // 
            // panelThongKeBody
            // 
            this.panelThongKeBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelThongKeBody.Location = new System.Drawing.Point(0, 44);
            this.panelThongKeBody.Name = "panelThongKeBody";
            this.panelThongKeBody.Size = new System.Drawing.Size(922, 622);
            this.panelThongKeBody.TabIndex = 2;
            // 
            // UCDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelThongKeBody);
            this.Controls.Add(this.panel1);
            this.Name = "UCDoanhThu";
            this.Size = new System.Drawing.Size(922, 666);
            this.panel1.ResumeLayout(false);
            this.menuTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel menuTable;
        private System.Windows.Forms.Panel panelThongKeBody;
        private System.Windows.Forms.Button btnTKTheoNam;
        private System.Windows.Forms.Button btnThongKeTheoQuy;
        private System.Windows.Forms.Button btnThongKeTheoThang;
        private System.Windows.Forms.Button btnThongKeTheoNgay;
    }
}
