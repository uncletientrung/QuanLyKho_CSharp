namespace QuanLyKho_CSharp.GUI.NhomQuyen
{
    partial class DetailNhomQuyenForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbChiTietNhomQuyen = new System.Windows.Forms.Label();
            this.DGVDetailNhomQuyen = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetailNhomQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelTop.Controls.Add(this.lbChiTietNhomQuyen);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(648, 72);
            this.panelTop.TabIndex = 85;
            // 
            // lbChiTietNhomQuyen
            // 
            this.lbChiTietNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChiTietNhomQuyen.ForeColor = System.Drawing.Color.White;
            this.lbChiTietNhomQuyen.Location = new System.Drawing.Point(0, 0);
            this.lbChiTietNhomQuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChiTietNhomQuyen.Name = "lbChiTietNhomQuyen";
            this.lbChiTietNhomQuyen.Size = new System.Drawing.Size(648, 72);
            this.lbChiTietNhomQuyen.TabIndex = 0;
            this.lbChiTietNhomQuyen.Text = "Chi Tiết Nhóm Quyền";
            this.lbChiTietNhomQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DGVDetailNhomQuyen
            // 
            this.DGVDetailNhomQuyen.BackgroundColor = System.Drawing.Color.White;
            this.DGVDetailNhomQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetailNhomQuyen.Location = new System.Drawing.Point(56, 151);
            this.DGVDetailNhomQuyen.Name = "DGVDetailNhomQuyen";
            this.DGVDetailNhomQuyen.Size = new System.Drawing.Size(562, 336);
            this.DGVDetailNhomQuyen.TabIndex = 90;
            this.DGVDetailNhomQuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetailNhomQuyen_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(274, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 41);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(198, 107);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(337, 29);
            this.txtName.TabIndex = 87;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(52, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 21);
            this.label14.TabIndex = 86;
            this.label14.Text = "Tên nhóm quyền";
            // 
            // DetailNhomQuyenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 541);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.DGVDetailNhomQuyen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DetailNhomQuyenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DetailNhomQuyenForm_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetailNhomQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lbChiTietNhomQuyen;
        private System.Windows.Forms.DataGridView DGVDetailNhomQuyen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label14;
    }
}