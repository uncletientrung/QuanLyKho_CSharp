using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    partial class PhieuNhapGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhieuNhapGUI));
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.artanPanel1 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.DGVPhieuNhap = new System.Windows.Forms.DataGridView();
            this.mapn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoigiantao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateE = new QuanLyKho_CSharp.Helper.component.RJDatePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.artanPanel2 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txtEMoney = new System.Windows.Forms.TextBox();
            this.artanButton1 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.artanPanel3 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txtSearchNV = new System.Windows.Forms.TextBox();
            this.artanButton3 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.btnThem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cbbSearch = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.artanPanel4 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txtSMoney = new System.Windows.Forms.TextBox();
            this.artanButton4 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.dateS = new QuanLyKho_CSharp.Helper.component.RJDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalStatus = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnXuatExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlDGV.SuspendLayout();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuNhap)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.artanPanel2.SuspendLayout();
            this.artanPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearch)).BeginInit();
            this.artanPanel4.SuspendLayout();
            this.lbTotalStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDGV
            // 
            this.pnlDGV.Controls.Add(this.artanPanel1);
            this.pnlDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDGV.Location = new System.Drawing.Point(0, 132);
            this.pnlDGV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(1103, 414);
            this.pnlDGV.TabIndex = 14;
            // 
            // artanPanel1
            // 
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderRadius = 20;
            this.artanPanel1.Controls.Add(this.DGVPhieuNhap);
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
            // DGVPhieuNhap
            // 
            this.DGVPhieuNhap.AllowUserToAddRows = false;
            this.DGVPhieuNhap.AllowUserToDeleteRows = false;
            this.DGVPhieuNhap.AllowUserToResizeColumns = false;
            this.DGVPhieuNhap.AllowUserToResizeRows = false;
            this.DGVPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.DGVPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPhieuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPhieuNhap.ColumnHeadersHeight = 30;
            this.DGVPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mapn,
            this.nv,
            this.kh,
            this.thoigiantao,
            this.tongtien,
            this.trangthai,
            this.detail,
            this.remove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPhieuNhap.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPhieuNhap.EnableHeadersVisualStyles = false;
            this.DGVPhieuNhap.GridColor = System.Drawing.Color.LightGray;
            this.DGVPhieuNhap.Location = new System.Drawing.Point(5, 0);
            this.DGVPhieuNhap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVPhieuNhap.MultiSelect = false;
            this.DGVPhieuNhap.Name = "DGVPhieuNhap";
            this.DGVPhieuNhap.ReadOnly = true;
            this.DGVPhieuNhap.RowHeadersVisible = false;
            this.DGVPhieuNhap.RowHeadersWidth = 25;
            this.DGVPhieuNhap.RowTemplate.Height = 30;
            this.DGVPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPhieuNhap.Size = new System.Drawing.Size(1093, 397);
            this.DGVPhieuNhap.TabIndex = 0;
            this.DGVPhieuNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPhieuNhap_CellContentClick);
            // 
            // mapn
            // 
            this.mapn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mapn.FillWeight = 10F;
            this.mapn.HeaderText = "Mã";
            this.mapn.Name = "mapn";
            this.mapn.ReadOnly = true;
            this.mapn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nv
            // 
            this.nv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nv.FillWeight = 20F;
            this.nv.HeaderText = "Nhân viên tạo";
            this.nv.Name = "nv";
            this.nv.ReadOnly = true;
            // 
            // kh
            // 
            this.kh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kh.FillWeight = 20F;
            this.kh.HeaderText = "Nhà cung cấp";
            this.kh.Name = "kh";
            this.kh.ReadOnly = true;
            // 
            // thoigiantao
            // 
            this.thoigiantao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thoigiantao.FillWeight = 15F;
            this.thoigiantao.HeaderText = "Thời gian tạo";
            this.thoigiantao.Name = "thoigiantao";
            this.thoigiantao.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongtien.FillWeight = 15F;
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // trangthai
            // 
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
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.panel2);
            this.pnlTop.Controls.Add(this.dateE);
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Controls.Add(this.artanPanel2);
            this.pnlTop.Controls.Add(this.artanPanel3);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.cbbSearch);
            this.pnlTop.Controls.Add(this.artanPanel4);
            this.pnlTop.Controls.Add(this.dateS);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.lbTotalStatus);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1103, 132);
            this.pnlTop.TabIndex = 15;
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
            this.dateE.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.panel1.Location = new System.Drawing.Point(628, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 5);
            this.panel1.TabIndex = 21;
            // 
            // artanPanel2
            // 
            this.artanPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel2.BorderRadius = 30;
            this.artanPanel2.Controls.Add(this.txtEMoney);
            this.artanPanel2.Controls.Add(this.artanButton1);
            this.artanPanel2.ForeColor = System.Drawing.Color.Black;
            this.artanPanel2.GradientAngle = 90F;
            this.artanPanel2.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel2.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel2.Location = new System.Drawing.Point(641, 91);
            this.artanPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.artanPanel2.Name = "artanPanel2";
            this.artanPanel2.Size = new System.Drawing.Size(120, 37);
            this.artanPanel2.TabIndex = 17;
            // 
            // txtEMoney
            // 
            this.txtEMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.txtEMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEMoney.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMoney.ForeColor = System.Drawing.Color.White;
            this.txtEMoney.Location = new System.Drawing.Point(39, 10);
            this.txtEMoney.Name = "txtEMoney";
            this.txtEMoney.Size = new System.Drawing.Size(69, 19);
            this.txtEMoney.TabIndex = 13;
            this.txtEMoney.Text = "Đến tiền";
            this.txtEMoney.TextChanged += new System.EventHandler(this.txtEMoney_TextChanged);
            this.txtEMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEMoney_KeyPress);
            this.txtEMoney.MouseEnter += new System.EventHandler(this.txtEMoney_MouseEnter);
            this.txtEMoney.MouseLeave += new System.EventHandler(this.txtEMoney_MouseLeave);
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
            this.artanPanel3.Location = new System.Drawing.Point(242, 91);
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
            // cbbSearch
            // 
            this.cbbSearch.DropDownWidth = 115;
            this.cbbSearch.Location = new System.Drawing.Point(244, 60);
            this.cbbSearch.Margin = new System.Windows.Forms.Padding(5);
            this.cbbSearch.MaximumSize = new System.Drawing.Size(100, 30);
            this.cbbSearch.MinimumSize = new System.Drawing.Size(100, 30);
            this.cbbSearch.Name = "cbbSearch";
            this.cbbSearch.Size = new System.Drawing.Size(100, 30);
            this.cbbSearch.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearch.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearch.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.cbbSearch.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cbbSearch.StateCommon.ComboBox.Border.Rounding = 10;
            this.cbbSearch.StateCommon.ComboBox.Content.Color1 = System.Drawing.Color.White;
            this.cbbSearch.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSearch.TabIndex = 20;
            this.cbbSearch.Text = "Tất cả";
            this.cbbSearch.SelectedIndexChanged += new System.EventHandler(this.cbbSearch_SelectedIndexChanged);
            // 
            // artanPanel4
            // 
            this.artanPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel4.BorderRadius = 30;
            this.artanPanel4.Controls.Add(this.txtSMoney);
            this.artanPanel4.Controls.Add(this.artanButton4);
            this.artanPanel4.ForeColor = System.Drawing.Color.Black;
            this.artanPanel4.GradientAngle = 90F;
            this.artanPanel4.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel4.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanPanel4.Location = new System.Drawing.Point(505, 91);
            this.artanPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.artanPanel4.Name = "artanPanel4";
            this.artanPanel4.Size = new System.Drawing.Size(120, 37);
            this.artanPanel4.TabIndex = 16;
            // 
            // txtSMoney
            // 
            this.txtSMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.txtSMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSMoney.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSMoney.ForeColor = System.Drawing.Color.White;
            this.txtSMoney.Location = new System.Drawing.Point(39, 10);
            this.txtSMoney.Name = "txtSMoney";
            this.txtSMoney.Size = new System.Drawing.Size(69, 19);
            this.txtSMoney.TabIndex = 13;
            this.txtSMoney.Text = "Tiền từ";
            this.txtSMoney.TextChanged += new System.EventHandler(this.txtSMoney_TextChanged);
            this.txtSMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMoney_KeyPress);
            this.txtSMoney.MouseEnter += new System.EventHandler(this.txtSMoney_MouseEnter);
            this.txtSMoney.MouseLeave += new System.EventHandler(this.txtSMoney_MouseLeave);
            // 
            // artanButton4
            // 
            this.artanButton4.BackColor = System.Drawing.Color.White;
            this.artanButton4.BackgroundColor = System.Drawing.Color.White;
            this.artanButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.artanButton4.BorderRadius = 30;
            this.artanButton4.BorderSize = 0;
            this.artanButton4.FlatAppearance.BorderSize = 0;
            this.artanButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.artanButton4.ForeColor = System.Drawing.Color.White;
            this.artanButton4.Image = ((System.Drawing.Image)(resources.GetObject("artanButton4.Image")));
            this.artanButton4.Location = new System.Drawing.Point(3, 3);
            this.artanButton4.Name = "artanButton4";
            this.artanButton4.Size = new System.Drawing.Size(30, 30);
            this.artanButton4.TabIndex = 12;
            this.artanButton4.TextColor = System.Drawing.Color.White;
            this.artanButton4.UseVisualStyleBackColor = false;
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
            this.dateS.ValueChanged += new System.EventHandler(this.dateTimeBegin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Danh sách phiếu nhập";
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
            this.lbTotal.Size = new System.Drawing.Size(149, 18);
            this.lbTotal.TabIndex = 15;
            this.lbTotal.Text = "Tổng số phiếu nhập: x";
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
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // PhieuNhapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 556);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PhieuNhapGUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "NHẬP HÀNG";
            this.Load += new System.EventHandler(this.PhieuNhap_Load);
            this.pnlDGV.ResumeLayout(false);
            this.artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuNhap)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.artanPanel2.ResumeLayout(false);
            this.artanPanel2.PerformLayout();
            this.artanPanel3.ResumeLayout(false);
            this.artanPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearch)).EndInit();
            this.artanPanel4.ResumeLayout(false);
            this.artanPanel4.PerformLayout();
            this.lbTotalStatus.ResumeLayout(false);
            this.lbTotalStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlDGV;
        private Helper.component.ArtanPanel artanPanel1;
        private DataGridView DGVPhieuNhap;
        private Panel pnlMain;
        private Panel pnlTop;
        private Panel panel2;
        private Helper.component.RJDatePicker dateE;
        private Panel panel1;
        private Helper.component.ArtanPanel artanPanel2;
        private TextBox txtEMoney;
        private Helper.component.ArtanButton artanButton1;
        private Helper.component.ArtanPanel artanPanel3;
        private TextBox txtSearchNV;
        private Helper.component.ArtanButton artanButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbSearch;
        private Helper.component.ArtanPanel artanPanel4;
        private TextBox txtSMoney;
        private Helper.component.ArtanButton artanButton4;
        private Helper.component.RJDatePicker dateS;
        private Label label2;
        private Panel lbTotalStatus;
        private Label lbTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXuatExcel;
        private DataGridViewTextBoxColumn mapn;
        private DataGridViewTextBoxColumn nv;
        private DataGridViewTextBoxColumn kh;
        private DataGridViewTextBoxColumn thoigiantao;
        private DataGridViewTextBoxColumn tongtien;
        private DataGridViewTextBoxColumn trangthai;
        private DataGridViewImageColumn detail;
        private DataGridViewImageColumn remove;
    }
}