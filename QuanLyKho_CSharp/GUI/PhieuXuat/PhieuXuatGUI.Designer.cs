namespace QuanLyKho_CSharp.GUI.PhieuXuat
{
    partial class PhieuXuatGUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhieuXuatGUI));
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.artanPanel1 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.DGVPhieuXuat = new System.Windows.Forms.DataGridView();
            this.mapx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoigiantao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoanhang = new System.Windows.Forms.DataGridViewButtonColumn();
            this.detail = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDGV.SuspendLayout();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuXuat)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.artanPanel2.SuspendLayout();
            this.artanPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSearch)).BeginInit();
            this.artanPanel4.SuspendLayout();
            this.lbTotalStatus.SuspendLayout();
            this.pnlMain.SuspendLayout();
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
            this.pnlDGV.TabIndex = 13;
            // 
            // artanPanel1
            // 
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderRadius = 20;
            this.artanPanel1.Controls.Add(this.DGVPhieuXuat);
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
            this.artanPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.artanPanel1_Paint);
            // 
            // DGVPhieuXuat
            // 
            this.DGVPhieuXuat.AllowUserToAddRows = false;
            this.DGVPhieuXuat.AllowUserToDeleteRows = false;
            this.DGVPhieuXuat.AllowUserToResizeColumns = false;
            this.DGVPhieuXuat.AllowUserToResizeRows = false;
            this.DGVPhieuXuat.BackgroundColor = System.Drawing.Color.White;
            this.DGVPhieuXuat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPhieuXuat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPhieuXuat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPhieuXuat.ColumnHeadersHeight = 30;
            this.DGVPhieuXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mapx,
            this.nv,
            this.kh,
            this.thoigiantao,
            this.tongtien,
            this.trangthai,
            this.hoanhang,
            this.detail,
            this.remove});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPhieuXuat.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPhieuXuat.EnableHeadersVisualStyles = false;
            this.DGVPhieuXuat.GridColor = System.Drawing.Color.LightGray;
            this.DGVPhieuXuat.Location = new System.Drawing.Point(5, 0);
            this.DGVPhieuXuat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVPhieuXuat.MultiSelect = false;
            this.DGVPhieuXuat.Name = "DGVPhieuXuat";
            this.DGVPhieuXuat.ReadOnly = true;
            this.DGVPhieuXuat.RowHeadersVisible = false;
            this.DGVPhieuXuat.RowHeadersWidth = 25;
            this.DGVPhieuXuat.RowTemplate.Height = 30;
            this.DGVPhieuXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPhieuXuat.Size = new System.Drawing.Size(1093, 397);
            this.DGVPhieuXuat.TabIndex = 1;
            this.DGVPhieuXuat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPhieuXuat_CellContentClick);
            // 
            // mapx
            // 
            this.mapx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mapx.FillWeight = 10F;
            this.mapx.HeaderText = "Mã";
            this.mapx.MinimumWidth = 6;
            this.mapx.Name = "mapx";
            this.mapx.ReadOnly = true;
            this.mapx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nv
            // 
            this.nv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nv.FillWeight = 20F;
            this.nv.HeaderText = "Nhân viên tạo";
            this.nv.MinimumWidth = 6;
            this.nv.Name = "nv";
            this.nv.ReadOnly = true;
            // 
            // kh
            // 
            this.kh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kh.FillWeight = 20F;
            this.kh.HeaderText = "Khách hàng";
            this.kh.MinimumWidth = 6;
            this.kh.Name = "kh";
            this.kh.ReadOnly = true;
            // 
            // thoigiantao
            // 
            this.thoigiantao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thoigiantao.FillWeight = 20F;
            this.thoigiantao.HeaderText = "Thời gian tạo";
            this.thoigiantao.MinimumWidth = 6;
            this.thoigiantao.Name = "thoigiantao";
            this.thoigiantao.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongtien.FillWeight = 10F;
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.MinimumWidth = 6;
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // trangthai
            // 
            this.trangthai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.trangthai.FillWeight = 15F;
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.MinimumWidth = 6;
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            // 
            // hoanhang
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.hoanhang.DefaultCellStyle = dataGridViewCellStyle2;
            this.hoanhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hoanhang.HeaderText = "Hoàn hàng";
            this.hoanhang.MinimumWidth = 6;
            this.hoanhang.Name = "hoanhang";
            this.hoanhang.ReadOnly = true;
            this.hoanhang.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hoanhang.Text = "Hoàn hàng";
            this.hoanhang.UseColumnTextForButtonValue = true;
            this.hoanhang.Width = 125;
            // 
            // detail
            // 
            this.detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.detail.HeaderText = "";
            this.detail.Image = ((System.Drawing.Image)(resources.GetObject("detail.Image")));
            this.detail.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.detail.MinimumWidth = 6;
            this.detail.Name = "detail";
            this.detail.ReadOnly = true;
            this.detail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detail.Width = 6;
            // 
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.remove.HeaderText = "";
            this.remove.Image = ((System.Drawing.Image)(resources.GetObject("remove.Image")));
            this.remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.remove.MinimumWidth = 6;
            this.remove.Name = "remove";
            this.remove.ReadOnly = true;
            this.remove.Width = 6;
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
            this.pnlTop.TabIndex = 14;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
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
            this.dateE.TabIndex = 18;
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
            this.txtEMoney.Size = new System.Drawing.Size(69, 23);
            this.txtEMoney.TabIndex = 16;
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
            this.artanPanel3.Location = new System.Drawing.Point(238, 91);
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
            this.txtSearchNV.Size = new System.Drawing.Size(204, 29);
            this.txtSearchNV.TabIndex = 14;
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
            this.btnThem.TabIndex = 19;
            this.btnThem.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Values.Image")));
            this.btnThem.Values.Text = "";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbbSearch
            // 
            this.cbbSearch.DropDownWidth = 115;
            this.cbbSearch.Location = new System.Drawing.Point(241, 60);
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
            this.cbbSearch.TabIndex = 13;
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
            this.txtSMoney.Size = new System.Drawing.Size(69, 23);
            this.txtSMoney.TabIndex = 15;
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
            this.dateS.TabIndex = 17;
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
            this.label2.Size = new System.Drawing.Size(306, 36);
            this.label2.TabIndex = 20;
            this.label2.Text = "Danh sách phiếu xuất";
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
            this.lbTotal.Size = new System.Drawing.Size(187, 23);
            this.lbTotal.TabIndex = 15;
            this.lbTotal.Text = "Tổng số phiếu xuất: x";
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
            this.btnXuatExcel.TabIndex = 21;
            this.btnXuatExcel.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Values.Image")));
            this.btnXuatExcel.Values.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuat_Click);
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
            this.pnlMain.TabIndex = 23;
            // 
            // PhieuXuatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 556);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PhieuXuatGUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.PhieuXuat_Load);
            this.pnlDGV.ResumeLayout(false);
            this.artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuXuat)).EndInit();
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
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDGV;
        private Helper.component.ArtanPanel artanPanel1;
        private Helper.component.RJDatePicker dateS;
        private System.Windows.Forms.Panel pnlTop;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXuatExcel;
        private System.Windows.Forms.Panel lbTotalStatus;
        private System.Windows.Forms.Label lbTotal;
        private Helper.component.ArtanPanel artanPanel4;
        private System.Windows.Forms.TextBox txtSMoney;
        private Helper.component.ArtanButton artanButton4;
        private System.Windows.Forms.DataGridView DGVPhieuXuat;
        private Helper.component.ArtanPanel artanPanel3;
        private System.Windows.Forms.TextBox txtSearchNV;
        private Helper.component.ArtanButton artanButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbbSearch;
        private System.Windows.Forms.Label label2;
        private Helper.component.ArtanPanel artanPanel2;
        private System.Windows.Forms.TextBox txtEMoney;
        private Helper.component.ArtanButton artanButton1;
        private Helper.component.RJDatePicker dateE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapx;
        private System.Windows.Forms.DataGridViewTextBoxColumn nv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoigiantao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewButtonColumn hoanhang;
        private System.Windows.Forms.DataGridViewImageColumn detail;
        private System.Windows.Forms.DataGridViewImageColumn remove;
    }
}