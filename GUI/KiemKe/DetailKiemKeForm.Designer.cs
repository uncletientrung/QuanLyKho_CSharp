namespace QuanLyKho_CSharp.GUI.KiemKe
{
    partial class DetailKiemKeForm
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonXacNhanChiTiet = new System.Windows.Forms.Button();
            this.Chitietphieukiem = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chitietphieukiem)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonXacNhanChiTiet, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Chitietphieukiem, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(831, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2 - thông tin chi tiết phiếu kiểm kê label
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(827, 62);
            this.tableLayoutPanel2.TabIndex = 6;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(200, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN CHI TIẾT PHIẾU KIỂM KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonXacNhanChiTiet
            // 
            this.buttonXacNhanChiTiet.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonXacNhanChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonXacNhanChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXacNhanChiTiet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonXacNhanChiTiet.Location = new System.Drawing.Point(3, 377);
            this.buttonXacNhanChiTiet.Name = "buttonXacNhanChiTiet";
            this.buttonXacNhanChiTiet.Size = new System.Drawing.Size(825, 60);
            this.buttonXacNhanChiTiet.TabIndex = 7;
            this.buttonXacNhanChiTiet.Text = "XÁC NHẬN";
            this.buttonXacNhanChiTiet.UseVisualStyleBackColor = false;
            this.buttonXacNhanChiTiet.Click += new System.EventHandler(this.buttonXacNhanChiTiet_Click);
            // 
            // Chitietphieukiem
            // 
            this.Chitietphieukiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Chitietphieukiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chitietphieukiem.Location = new System.Drawing.Point(3, 69);
            this.Chitietphieukiem.Name = "Chitietphieukiem";
            this.Chitietphieukiem.Size = new System.Drawing.Size(825, 302);
            this.Chitietphieukiem.TabIndex = 8;
            this.Chitietphieukiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Chitietphieukiem_CellContentClick);
            // 
            // DetailKiemKeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DetailKiemKeForm";
            this.Text = "DetailKiemKeForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chitietphieukiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonXacNhanChiTiet;
        private System.Windows.Forms.DataGridView Chitietphieukiem;

    }
}