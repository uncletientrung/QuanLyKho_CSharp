using System.Drawing;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    partial class KiemKeGUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KiemKeGUI));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.artanPanel1 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.DGVPhieuKiem = new System.Windows.Forms.DataGridView();
            this.mapk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoigiantao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCanBang = new System.Windows.Forms.DataGridViewButtonColumn();
            this.detail = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cbbSearchNVKiem = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateE = new QuanLyKho_CSharp.Helper.component.RJDatePicker();
            this.artanPanel3 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txtSearchNV = new System.Windows.Forms.TextBox();
            this.artanButton3 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.btnThem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbbSearchNVTao = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dateS = new QuanLyKho_CSharp.Helper.component.RJDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalStatus = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnXuatExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlMain.SuspendLayout();
            this.pnlDGV.SuspendLayout();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuKiem)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearchNVKiem)).BeginInit();
            this.artanPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearchNVTao)).BeginInit();
            this.lbTotalStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDGV);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1103, 546);
            this.pnlMain.TabIndex = 24;
            // 
            // pnlDGV
            // 
            this.pnlDGV.Controls.Add(this.artanPanel1);
            this.pnlDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDGV.Location = new System.Drawing.Point(0, 132);
            this.pnlDGV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(1103, 414);
            this.pnlDGV.TabIndex = 13;
            // 
            // artanPanel1
            // 
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderRadius = 20;
            this.artanPanel1.Controls.Add(this.DGVPhieuKiem);
            this.artanPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artanPanel1.ForeColor = System.Drawing.Color.Black;
            this.artanPanel1.GradientAngle = 90F;
            this.artanPanel1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel1.Location = new System.Drawing.Point(0, 0);
            this.artanPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.artanPanel1.Name = "artanPanel1";
            this.artanPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 17);
            this.artanPanel1.Size = new System.Drawing.Size(1103, 414);
            this.artanPanel1.TabIndex = 0;
            // 
            // DGVPhieuKiem
            // 
            this.DGVPhieuKiem.AllowUserToAddRows = false;
            this.DGVPhieuKiem.AllowUserToDeleteRows = false;
            this.DGVPhieuKiem.AllowUserToResizeColumns = false;
            this.DGVPhieuKiem.AllowUserToResizeRows = false;
            this.DGVPhieuKiem.BackgroundColor = System.Drawing.Color.White;
            this.DGVPhieuKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPhieuKiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPhieuKiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPhieuKiem.ColumnHeadersHeight = 30;
            this.DGVPhieuKiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mapk,
            this.nv,
            this.kh,
            this.thoigiantao,
            this.tongtien,
            this.ghichu,
            this.trangthai,
            this.btnCanBang,
            this.detail,
            this.remove});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPhieuKiem.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPhieuKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPhieuKiem.EnableHeadersVisualStyles = false;
            this.DGVPhieuKiem.GridColor = System.Drawing.Color.LightGray;
            this.DGVPhieuKiem.Location = new System.Drawing.Point(5, 0);
            this.DGVPhieuKiem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVPhieuKiem.MultiSelect = false;
            this.DGVPhieuKiem.Name = "DGVPhieuKiem";
            this.DGVPhieuKiem.ReadOnly = true;
            this.DGVPhieuKiem.RowHeadersVisible = false;
            this.DGVPhieuKiem.RowHeadersWidth = 25;
            this.DGVPhieuKiem.RowTemplate.Height = 30;
            this.DGVPhieuKiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPhieuKiem.Size = new System.Drawing.Size(1093, 397);
            this.DGVPhieuKiem.TabIndex = 1;
            this.DGVPhieuKiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPhieuKiem_CellContentClick);
            // 
            // mapk
            // 
            this.mapk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mapk.FillWeight = 7F;
            this.mapk.HeaderText = "Mã kiểm";
            this.mapk.Name = "mapk";
            this.mapk.ReadOnly = true;
            this.mapk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nv
            // 
            this.nv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nv.FillWeight = 12F;
            this.nv.HeaderText = "Nhân viên tạo";
            this.nv.Name = "nv";
            this.nv.ReadOnly = true;
            // 
            // kh
            // 
            this.kh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kh.FillWeight = 12F;
            this.kh.HeaderText = "Nhân viên kiểm";
            this.kh.Name = "kh";
            this.kh.ReadOnly = true;
            // 
            // thoigiantao
            // 
            this.thoigiantao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thoigiantao.FillWeight = 12F;
            this.thoigiantao.HeaderText = "Thời gian tạo";
            this.thoigiantao.Name = "thoigiantao";
            this.thoigiantao.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongtien.FillWeight = 14F;
            this.tongtien.HeaderText = "Thời gian cân bằng";
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // ghichu
            // 
            this.ghichu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ghichu.FillWeight = 10F;
            this.ghichu.HeaderText = "Ghi chú";
            this.ghichu.Name = "ghichu";
            this.ghichu.ReadOnly = true;
            // 
            // trangthai
            // 
            this.trangthai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.trangthai.FillWeight = 10F;
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            // 
            // btnCanBang
            // 
            this.btnCanBang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.btnCanBang.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnCanBang.FillWeight = 10F;
            this.btnCanBang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanBang.HeaderText = "Cân bằng";
            this.btnCanBang.Name = "btnCanBang";
            this.btnCanBang.ReadOnly = true;
            this.btnCanBang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnCanBang.Text = "Cân bằng";
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
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.cbbSearchNVKiem);
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Controls.Add(this.dateE);
            this.pnlTop.Controls.Add(this.artanPanel3);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.cbbSearchNVTao);
            this.pnlTop.Controls.Add(this.dateS);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.lbTotalStatus);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1103, 132);
            this.pnlTop.TabIndex = 14;
            // 
            // cbbSearchNVKiem
            // 
            this.cbbSearchNVKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchNVKiem.DropDownWidth = 115;
            this.cbbSearchNVKiem.Location = new System.Drawing.Point(640, 91);
            this.cbbSearchNVKiem.Margin = new System.Windows.Forms.Padding(5);
            this.cbbSearchNVKiem.MaximumSize = new System.Drawing.Size(120, 37);
            this.cbbSearchNVKiem.MinimumSize = new System.Drawing.Size(120, 37);
            this.cbbSearchNVKiem.Name = "cbbSearchNVKiem";
            this.cbbSearchNVKiem.Size = new System.Drawing.Size(120, 37);
            this.cbbSearchNVKiem.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearchNVKiem.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearchNVKiem.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearchNVKiem.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbbSearchNVKiem.StateCommon.ComboBox.Border.Rounding = 15;
            this.cbbSearchNVKiem.StateCommon.ComboBox.Content.Color1 = System.Drawing.Color.White;
            this.cbbSearchNVKiem.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearchNVKiem.TabIndex = 23;
            this.cbbSearchNVKiem.SelectedIndexChanged += new System.EventHandler(this.cbbSearchNVKiem_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.panel2.Location = new System.Drawing.Point(893, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 5);
            this.panel2.TabIndex = 22;
            // 
            // dateE
            // 
            this.dateE.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dateE.BorderSize = 0;
            this.dateE.CalendarFont = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateE.CustomFormat = "dd/MM/yyyy";
            this.dateE.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateE.Location = new System.Drawing.Point(906, 93);
            this.dateE.Margin = new System.Windows.Forms.Padding(0);
            this.dateE.MinimumSize = new System.Drawing.Size(100, 35);
            this.dateE.Name = "dateE";
            this.dateE.Size = new System.Drawing.Size(122, 35);
            this.dateE.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.dateE.TabIndex = 22;
            this.dateE.TextColor = System.Drawing.Color.White;
            this.dateE.ValueChanged += new System.EventHandler(this.dateE_ValueChanged);
            // 
            // artanPanel3
            // 
            this.artanPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel3.BorderRadius = 30;
            this.artanPanel3.Controls.Add(this.txtSearchNV);
            this.artanPanel3.Controls.Add(this.artanButton3);
            this.artanPanel3.ForeColor = System.Drawing.Color.Black;
            this.artanPanel3.GradientAngle = 90F;
            this.artanPanel3.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel3.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel3.Location = new System.Drawing.Point(243, 91);
            this.artanPanel3.Name = "artanPanel3";
            this.artanPanel3.Size = new System.Drawing.Size(261, 37);
            this.artanPanel3.TabIndex = 14;
            // 
            // txtSearchNV
            // 
            this.txtSearchNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.txtSearchNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchNV.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchNV.ForeColor = System.Drawing.Color.White;
            this.txtSearchNV.Location = new System.Drawing.Point(39, 6);
            this.txtSearchNV.Name = "txtSearchNV";
            this.txtSearchNV.Size = new System.Drawing.Size(204, 23);
            this.txtSearchNV.TabIndex = 13;
            this.txtSearchNV.TextChanged += new System.EventHandler(this.txtSearchNV_TextChanged);
            // 
            // artanButton3
            // 
            this.artanButton3.BackColor = System.Drawing.Color.White;
            this.artanButton3.BackgroundColor = System.Drawing.Color.White;
            this.artanButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanButton3.BorderRadius = 30;
            this.artanButton3.BorderSize = 0;
            this.artanButton3.FlatAppearance.BorderSize = 0;
            this.artanButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.artanButton3.ForeColor = System.Drawing.Color.White;
            this.artanButton3.Image = ((System.Drawing.Image)(resources.GetObject("artanButton3.Image")));
            this.artanButton3.Location = new System.Drawing.Point(3, 3);
            this.artanButton3.Name = "artanButton3";
            this.artanButton3.Size = new System.Drawing.Size(30, 30);
            this.artanButton3.TabIndex = 12;
            this.artanButton3.TextColor = System.Drawing.Color.White;
            this.artanButton3.UseVisualStyleBackColor = false;
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
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbbSearchNVTao
            // 
            this.cbbSearchNVTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchNVTao.DropDownWidth = 115;
            this.cbbSearchNVTao.Location = new System.Drawing.Point(512, 91);
            this.cbbSearchNVTao.Margin = new System.Windows.Forms.Padding(5);
            this.cbbSearchNVTao.MaximumSize = new System.Drawing.Size(120, 37);
            this.cbbSearchNVTao.MinimumSize = new System.Drawing.Size(120, 37);
            this.cbbSearchNVTao.Name = "cbbSearchNVTao";
            this.cbbSearchNVTao.Size = new System.Drawing.Size(120, 37);
            this.cbbSearchNVTao.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearchNVTao.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearchNVTao.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearchNVTao.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbbSearchNVTao.StateCommon.ComboBox.Border.Rounding = 15;
            this.cbbSearchNVTao.StateCommon.ComboBox.Content.Color1 = System.Drawing.Color.White;
            this.cbbSearchNVTao.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearchNVTao.TabIndex = 20;
            this.cbbSearchNVTao.SelectedIndexChanged += new System.EventHandler(this.cbbSearchNVTao_SelectedIndexChanged);
            // 
            // dateS
            // 
            this.dateS.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dateS.BorderSize = 0;
            this.dateS.CalendarFont = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateS.CustomFormat = "dd/MM/yyyy";
            this.dateS.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateS.Location = new System.Drawing.Point(770, 93);
            this.dateS.Margin = new System.Windows.Forms.Padding(0);
            this.dateS.MinimumSize = new System.Drawing.Size(100, 35);
            this.dateS.Name = "dateS";
            this.dateS.Size = new System.Drawing.Size(120, 35);
            this.dateS.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.dateS.TabIndex = 1;
            this.dateS.TextColor = System.Drawing.Color.White;
            this.dateS.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dateS.ValueChanged += new System.EventHandler(this.dateS_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Danh sách phiếu kiểm";
            // 
            // lbTotalStatus
            // 
            this.lbTotalStatus.Controls.Add(this.lbTotal);
            this.lbTotalStatus.Controls.Add(this.btnXuatExcel);
            this.lbTotalStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTotalStatus.Location = new System.Drawing.Point(0, 0);
            this.lbTotalStatus.Name = "lbTotalStatus";
            this.lbTotalStatus.Size = new System.Drawing.Size(1103, 48);
            this.lbTotalStatus.TabIndex = 14;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTotal.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Black;
            this.lbTotal.Location = new System.Drawing.Point(0, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(150, 18);
            this.lbTotal.TabIndex = 15;
            this.lbTotal.Text = "Tổng số phiếu kiểm: x";
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
            this.btnXuatExcel.TabIndex = 12;
            this.btnXuatExcel.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Values.Image")));
            this.btnXuatExcel.Values.Text = "Xuất Excel";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // KiemKeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 556);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "KiemKeGUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.DanhSachKiemKeGUI_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlDGV.ResumeLayout(false);
            this.artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuKiem)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearchNVKiem)).EndInit();
            this.artanPanel3.ResumeLayout(false);
            this.artanPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearchNVTao)).EndInit();
            this.lbTotalStatus.ResumeLayout(false);
            this.lbTotalStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        // searchplaceholder
        private const string SearchPlaceholder = "Nhập mã phiếu, tên hàng hoá để tìm kiếm";
        private readonly Font placeholderFont = new Font("Segoe UI", 9F, FontStyle.Italic);
        private readonly Font normalFont = new Font("Segoe UI", 12F, FontStyle.Regular);
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDGV;
        private Helper.component.ArtanPanel artanPanel1;
        private System.Windows.Forms.DataGridView DGVPhieuKiem;
        private System.Windows.Forms.Panel pnlTop;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbSearchNVKiem;
        private System.Windows.Forms.Panel panel2;
        private Helper.component.RJDatePicker dateE;
        private Helper.component.ArtanPanel artanPanel3;
        private System.Windows.Forms.TextBox txtSearchNV;
        private Helper.component.ArtanButton artanButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbSearchNVTao;
        private Helper.component.RJDatePicker dateS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel lbTotalStatus;
        private System.Windows.Forms.Label lbTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXuatExcel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapk;
        private System.Windows.Forms.DataGridViewTextBoxColumn nv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoigiantao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewButtonColumn btnCanBang;
        private System.Windows.Forms.DataGridViewImageColumn detail;
        private System.Windows.Forms.DataGridViewImageColumn remove;
    }
}