namespace QuanLyKho_CSharp.GUI.PhanQuyen
{
    partial class NhomQuyenGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhomQuyenGUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnThem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbTotalNV = new System.Windows.Forms.Label();
            this.lbTotalStatus = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.artanPanel1 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.DGVPhanQuyen = new System.Windows.Forms.DataGridView();
            this.manq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlSearch = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.artanButton1 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.lbTotalStatus.SuspendLayout();
            this.pnlDGV.SuspendLayout();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhanQuyen)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1039, 88);
            this.btnThem.Name = "btnThem";
            this.btnThem.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnThem.Size = new System.Drawing.Size(40, 40);
            this.btnThem.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.StateCommon.Back.ColorAngle = 45F;
            this.btnThem.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.StateCommon.Border.ColorAngle = 45F;
            this.btnThem.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnThem.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnThem.StateCommon.Border.Rounding = 10;
            this.btnThem.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnThem.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnThem.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnThem.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnThem.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnThem.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnThem.TabIndex = 10;
            this.btnThem.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Values.Image")));
            this.btnThem.Values.Text = "";
            this.btnThem.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbTotalNV
            // 
            this.lbTotalNV.AutoSize = true;
            this.lbTotalNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTotalNV.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalNV.ForeColor = System.Drawing.Color.Black;
            this.lbTotalNV.Location = new System.Drawing.Point(0, 0);
            this.lbTotalNV.Name = "lbTotalNV";
            this.lbTotalNV.Size = new System.Drawing.Size(157, 18);
            this.lbTotalNV.TabIndex = 15;
            this.lbTotalNV.Text = "Tổng số nhóm quyền: x";
            // 
            // lbTotalStatus
            // 
            this.lbTotalStatus.Controls.Add(this.btnXuatExcel);
            this.lbTotalStatus.Controls.Add(this.lbTotalNV);
            this.lbTotalStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTotalStatus.Location = new System.Drawing.Point(0, 0);
            this.lbTotalStatus.Name = "lbTotalStatus";
            this.lbTotalStatus.Size = new System.Drawing.Size(1103, 48);
            this.lbTotalStatus.TabIndex = 14;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(963, 3);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnXuatExcel.Size = new System.Drawing.Size(116, 40);
            this.btnXuatExcel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.StateCommon.Back.ColorAngle = 45F;
            this.btnXuatExcel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.StateCommon.Border.ColorAngle = 45F;
            this.btnXuatExcel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnXuatExcel.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnXuatExcel.StateCommon.Border.Rounding = 10;
            this.btnXuatExcel.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnXuatExcel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnXuatExcel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnXuatExcel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnXuatExcel.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnXuatExcel.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnXuatExcel.TabIndex = 16;
            this.btnXuatExcel.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Values.Image")));
            this.btnXuatExcel.Values.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // pnlDGV
            // 
            this.pnlDGV.Controls.Add(this.artanPanel1);
            this.pnlDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDGV.Location = new System.Drawing.Point(5, 137);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(1103, 414);
            this.pnlDGV.TabIndex = 11;
            // 
            // artanPanel1
            // 
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderRadius = 20;
            this.artanPanel1.Controls.Add(this.DGVPhanQuyen);
            this.artanPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artanPanel1.ForeColor = System.Drawing.Color.Black;
            this.artanPanel1.GradientAngle = 90F;
            this.artanPanel1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel1.Location = new System.Drawing.Point(0, 0);
            this.artanPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.artanPanel1.Name = "artanPanel1";
            this.artanPanel1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 15);
            this.artanPanel1.Size = new System.Drawing.Size(1103, 414);
            this.artanPanel1.TabIndex = 0;
            // 
            // DGVPhanQuyen
            // 
            this.DGVPhanQuyen.AllowUserToAddRows = false;
            this.DGVPhanQuyen.AllowUserToDeleteRows = false;
            this.DGVPhanQuyen.AllowUserToResizeColumns = false;
            this.DGVPhanQuyen.AllowUserToResizeRows = false;
            this.DGVPhanQuyen.BackgroundColor = System.Drawing.Color.White;
            this.DGVPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPhanQuyen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPhanQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPhanQuyen.ColumnHeadersHeight = 30;
            this.DGVPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.manq,
            this.hoten,
            this.trangthai,
            this.detail,
            this.edit,
            this.remove});
            this.DGVPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPhanQuyen.EnableHeadersVisualStyles = false;
            this.DGVPhanQuyen.GridColor = System.Drawing.Color.LightGray;
            this.DGVPhanQuyen.Location = new System.Drawing.Point(4, 0);
            this.DGVPhanQuyen.MultiSelect = false;
            this.DGVPhanQuyen.Name = "DGVPhanQuyen";
            this.DGVPhanQuyen.ReadOnly = true;
            this.DGVPhanQuyen.RowHeadersVisible = false;
            this.DGVPhanQuyen.RowHeadersWidth = 25;
            this.DGVPhanQuyen.RowTemplate.Height = 30;
            this.DGVPhanQuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPhanQuyen.Size = new System.Drawing.Size(1095, 399);
            this.DGVPhanQuyen.TabIndex = 0;
            this.DGVPhanQuyen.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPhanQuyen_CellContentClick);
            // 
            // manq
            // 
            this.manq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.manq.FillWeight = 10F;
            this.manq.HeaderText = "Mã";
            this.manq.Name = "manq";
            this.manq.ReadOnly = true;
            this.manq.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // hoten
            // 
            this.hoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hoten.FillWeight = 55F;
            this.hoten.HeaderText = "Tên nhóm quyền";
            this.hoten.Name = "hoten";
            this.hoten.ReadOnly = true;
            // 
            // trangthai
            // 
            this.trangthai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.trangthai.FillWeight = 10F;
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            // 
            // detail
            // 
            this.detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.detail.HeaderText = "";
            this.detail.Image = ((System.Drawing.Image)(resources.GetObject("detail.Image")));
            this.detail.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.detail.Name = "detail";
            this.detail.ReadOnly = true;
            this.detail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detail.Width = 5;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.edit.HeaderText = "";
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 5;
            // 
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.remove.HeaderText = "";
            this.remove.Image = ((System.Drawing.Image)(resources.GetObject("remove.Image")));
            this.remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.remove.Name = "remove";
            this.remove.ReadOnly = true;
            this.remove.Width = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.label1.Location = new System.Drawing.Point(3, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh sách nhóm quyền";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lbTotalStatus);
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1103, 132);
            this.pnlTop.TabIndex = 12;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.pnlSearch.BorderRadius = 30;
            this.pnlSearch.Controls.Add(this.txSearch);
            this.pnlSearch.Controls.Add(this.artanButton1);
            this.pnlSearch.ForeColor = System.Drawing.Color.Black;
            this.pnlSearch.GradientAngle = 90F;
            this.pnlSearch.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.pnlSearch.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.pnlSearch.Location = new System.Drawing.Point(258, 89);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(315, 37);
            this.pnlSearch.TabIndex = 11;
            // 
            // txSearch
            // 
            this.txSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.txSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txSearch.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSearch.ForeColor = System.Drawing.Color.White;
            this.txSearch.Location = new System.Drawing.Point(39, 6);
            this.txSearch.Name = "txSearch";
            this.txSearch.Size = new System.Drawing.Size(258, 23);
            this.txSearch.TabIndex = 13;
            this.txSearch.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            // 
            // artanButton1
            // 
            this.artanButton1.BackColor = System.Drawing.Color.White;
            this.artanButton1.BackgroundColor = System.Drawing.Color.White;
            this.artanButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanButton1.BorderRadius = 30;
            this.artanButton1.BorderSize = 0;
            this.artanButton1.FlatAppearance.BorderSize = 0;
            this.artanButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.artanButton1.ForeColor = System.Drawing.Color.White;
            this.artanButton1.Image = ((System.Drawing.Image)(resources.GetObject("artanButton1.Image")));
            this.artanButton1.Location = new System.Drawing.Point(3, 3);
            this.artanButton1.Name = "artanButton1";
            this.artanButton1.Size = new System.Drawing.Size(30, 30);
            this.artanButton1.TabIndex = 12;
            this.artanButton1.TextColor = System.Drawing.Color.White;
            this.artanButton1.UseVisualStyleBackColor = false;
            // 
            // NhomQuyenGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 556);
            this.Controls.Add(this.pnlDGV);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhomQuyenGUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.PhanQuyenGUI_Load);
            this.lbTotalStatus.ResumeLayout(false);
            this.lbTotalStatus.PerformLayout();
            this.pnlDGV.ResumeLayout(false);
            this.artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhanQuyen)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
        private System.Windows.Forms.TextBox txSearch;
        private Helper.component.ArtanPanel pnlSearch;
        private Helper.component.ArtanButton artanButton1;
        private System.Windows.Forms.Label lbTotalNV;
        private System.Windows.Forms.Panel lbTotalStatus;
        private System.Windows.Forms.DataGridView DGVPhanQuyen;
        private Helper.component.ArtanPanel artanPanel1;
        private System.Windows.Forms.Panel pnlDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn manq;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewImageColumn detail;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn remove;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXuatExcel;
    }
}