namespace QuanLyKho_CSharp.GUI.NhomQuyen
{
    partial class UpdateNhomQuyenForm
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
            this.lbUpdateNhomQuyen = new System.Windows.Forms.Label();
            this.DGVUpdateNhomQuyen = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUpdateNhomQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelTop.Controls.Add(this.lbUpdateNhomQuyen);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(648, 72);
            this.panelTop.TabIndex = 85;
            // 
            // lbUpdateNhomQuyen
            // 
            this.lbUpdateNhomQuyen.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateNhomQuyen.ForeColor = System.Drawing.Color.White;
            this.lbUpdateNhomQuyen.Location = new System.Drawing.Point(0, 0);
            this.lbUpdateNhomQuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUpdateNhomQuyen.Name = "lbUpdateNhomQuyen";
            this.lbUpdateNhomQuyen.Size = new System.Drawing.Size(648, 72);
            this.lbUpdateNhomQuyen.TabIndex = 0;
            this.lbUpdateNhomQuyen.Text = "Sửa Nhóm Quyền";
            this.lbUpdateNhomQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DGVUpdateNhomQuyen
            // 
            this.DGVUpdateNhomQuyen.BackgroundColor = System.Drawing.Color.White;
            this.DGVUpdateNhomQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUpdateNhomQuyen.Location = new System.Drawing.Point(56, 146);
            this.DGVUpdateNhomQuyen.Name = "DGVUpdateNhomQuyen";
            this.DGVUpdateNhomQuyen.Size = new System.Drawing.Size(562, 336);
            this.DGVUpdateNhomQuyen.TabIndex = 90;
            this.DGVUpdateNhomQuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUpdateNhomQuyen_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(331, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 41);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(189, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 41);
            this.btnSave.TabIndex = 88;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(198, 102);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(337, 29);
            this.txtName.TabIndex = 87;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(52, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 21);
            this.label14.TabIndex = 86;
            this.label14.Text = "Tên nhóm quyền";
            // 
            // UpdateNhomQuyenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 541);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.DGVUpdateNhomQuyen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UpdateNhomQuyenForm";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUpdateNhomQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lbUpdateNhomQuyen;
        private System.Windows.Forms.DataGridView DGVUpdateNhomQuyen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label14;
    }
}