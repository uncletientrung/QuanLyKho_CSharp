namespace QuanLyKho_CSharp.GUI.KiemKe
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.PhNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChungTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThucNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chenh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PhNhap,
            this.NgNhap,
            this.NCC,
            this.ChungTu,
            this.ThucNhap,
            this.Chenh,
            this.Note});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(11, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1026, 486);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 44);
            this.label1.TabIndex = 17;
            this.label1.Text = "Kiểm kê";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PhNhap
            // 
            this.PhNhap.HeaderText = "Mã Phiếu Nhập";
            this.PhNhap.Name = "PhNhap";
            this.PhNhap.ReadOnly = true;
            this.PhNhap.Width = 150;
            // 
            // NgNhap
            // 
            this.NgNhap.HeaderText = "Ngày Nhập";
            this.NgNhap.Name = "NgNhap";
            this.NgNhap.ReadOnly = true;
            this.NgNhap.Width = 130;
            // 
            // NCC
            // 
            this.NCC.HeaderText = "Nhà Cung Cấp";
            this.NCC.Name = "NCC";
            this.NCC.ReadOnly = true;
            this.NCC.Width = 150;
            // 
            // ChungTu
            // 
            this.ChungTu.HeaderText = "Tổng SL Theo chứng từ";
            this.ChungTu.Name = "ChungTu";
            this.ChungTu.ReadOnly = true;
            this.ChungTu.Width = 150;
            // 
            // ThucNhap
            // 
            this.ThucNhap.HeaderText = "Tổng SL Thực Nhập";
            this.ThucNhap.Name = "ThucNhap";
            this.ThucNhap.ReadOnly = true;
            this.ThucNhap.Width = 150;
            // 
            // Chenh
            // 
            this.Chenh.HeaderText = "Chênh Lệch";
            this.Chenh.Name = "Chenh";
            this.Chenh.ReadOnly = true;
            this.Chenh.Width = 130;
            // 
            // Note
            // 
            this.Note.HeaderText = "Ghi Chú";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            this.Note.Width = 140;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 568);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChungTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThucNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chenh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}