namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    partial class TaiKhoanGUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaiKhoanGUI));
            this.pnlDGV = new System.Windows.Forms.Panel();
            this.artanPanel1 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.DGVTaiKhoan = new System.Windows.Forms.DataGridView();
            this.matk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detail = new System.Windows.Forms.DataGridViewImageColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnThem = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSearch = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.artanButton1 = new QuanLyKho_CSharp.Helper.component.ArtanButton();
            this.lbTotalStatus = new System.Windows.Forms.Panel();
            this.btnNhapExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnXuatExcel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbTotal = new System.Windows.Forms.Label();
            this.pnlDGV.SuspendLayout();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTaiKhoan)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.lbTotalStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDGV
            // 
            this.pnlDGV.Controls.Add(this.artanPanel1);
            this.pnlDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDGV.Location = new System.Drawing.Point(5, 137);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(1103, 414);
            this.pnlDGV.TabIndex = 12;
            // 
            // artanPanel1
            // 
            this.artanPanel1.BackColor = System.Drawing.Color.White;
            this.artanPanel1.BorderRadius = 20;
            this.artanPanel1.Controls.Add(this.DGVTaiKhoan);
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
            // DGVTaiKhoan
            // 
            this.DGVTaiKhoan.AllowUserToAddRows = false;
            this.DGVTaiKhoan.AllowUserToDeleteRows = false;
            this.DGVTaiKhoan.AllowUserToResizeColumns = false;
            this.DGVTaiKhoan.AllowUserToResizeRows = false;
            this.DGVTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.DGVTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVTaiKhoan.ColumnHeadersHeight = 30;
            this.DGVTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matk,
            this.username,
            this.password,
            this.manq,
            this.trangthai,
            this.detail,
            this.edit,
            this.remove});
            this.DGVTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVTaiKhoan.EnableHeadersVisualStyles = false;
            this.DGVTaiKhoan.GridColor = System.Drawing.Color.LightGray;
            this.DGVTaiKhoan.Location = new System.Drawing.Point(4, 0);
            this.DGVTaiKhoan.MultiSelect = false;
            this.DGVTaiKhoan.Name = "DGVTaiKhoan";
            this.DGVTaiKhoan.ReadOnly = true;
            this.DGVTaiKhoan.RowHeadersVisible = false;
            this.DGVTaiKhoan.RowHeadersWidth = 25;
            this.DGVTaiKhoan.RowTemplate.Height = 30;
            this.DGVTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTaiKhoan.Size = new System.Drawing.Size(1095, 399);
            this.DGVTaiKhoan.TabIndex = 0;
            this.DGVTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTaiKhoan_CellContentClick_1);
            // 
            // matk
            // 
            this.matk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.matk.FillWeight = 10F;
            this.matk.HeaderText = "Mã";
            this.matk.Name = "matk";
            this.matk.ReadOnly = true;
            this.matk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // username
            // 
            this.username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.username.FillWeight = 25F;
            this.username.HeaderText = "Tên đăng nhập";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // password
            // 
            this.password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.password.FillWeight = 10F;
            this.password.HeaderText = "Mật khẩu";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // manq
            // 
            this.manq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.manq.FillWeight = 20F;
            this.manq.HeaderText = "Mã nhóm quyền";
            this.manq.Name = "manq";
            this.manq.ReadOnly = true;
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
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.flowLayoutPanel1);
            this.pnlTop.Controls.Add(this.lbTotalStatus);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1103, 132);
            this.pnlTop.TabIndex = 11;
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
            this.btnThem.TabIndex = 17;
            this.btnThem.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Values.Image")));
            this.btnThem.Values.Text = "";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.pnlSearch);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 86);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(564, 43);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh sách tài khoản";
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
            this.pnlSearch.Location = new System.Drawing.Point(237, 3);
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
            // lbTotalStatus
            // 
            this.lbTotalStatus.Controls.Add(this.btnNhapExcel);
            this.lbTotalStatus.Controls.Add(this.btnXuatExcel);
            this.lbTotalStatus.Controls.Add(this.lbTotal);
            this.lbTotalStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTotalStatus.Location = new System.Drawing.Point(0, 0);
            this.lbTotalStatus.Name = "lbTotalStatus";
            this.lbTotalStatus.Size = new System.Drawing.Size(1103, 48);
            this.lbTotalStatus.TabIndex = 14;
            // 
            // btnNhapExcel
            // 
            this.btnNhapExcel.Location = new System.Drawing.Point(842, 3);
            this.btnNhapExcel.Name = "btnNhapExcel";
            this.btnNhapExcel.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnNhapExcel.Size = new System.Drawing.Size(116, 40);
            this.btnNhapExcel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.StateCommon.Back.ColorAngle = 45F;
            this.btnNhapExcel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.StateCommon.Border.ColorAngle = 45F;
            this.btnNhapExcel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNhapExcel.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnNhapExcel.StateCommon.Border.Rounding = 10;
            this.btnNhapExcel.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnNhapExcel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNhapExcel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNhapExcel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold);
            this.btnNhapExcel.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnNhapExcel.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(112)))));
            this.btnNhapExcel.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnNhapExcel.TabIndex = 17;
            this.btnNhapExcel.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapExcel.Values.Image")));
            this.btnNhapExcel.Values.Text = "Nhập Excel";
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
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTotal.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Black;
            this.lbTotal.Location = new System.Drawing.Point(0, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(138, 18);
            this.lbTotal.TabIndex = 15;
            this.lbTotal.Text = "Tổng số tài khoản: x";
            this.lbTotal.Click += new System.EventHandler(this.lbTotal_Click);
            // 
            // TaiKhoanGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 556);
            this.Controls.Add(this.pnlDGV);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TaiKhoanGUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.TaiKhoanGUI_Load);
            this.pnlDGV.ResumeLayout(false);
            this.artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTaiKhoan)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.lbTotalStatus.ResumeLayout(false);
            this.lbTotalStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDGV;
        private Helper.component.ArtanPanel artanPanel1;
        private System.Windows.Forms.DataGridView DGVTaiKhoan;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel lbTotalStatus;
        private System.Windows.Forms.Label lbTotal;
        private Helper.component.ArtanPanel pnlSearch;
        private System.Windows.Forms.TextBox txSearch;
        private Helper.component.ArtanButton artanButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn matk;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn manq;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewImageColumn detail;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn remove;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNhapExcel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnXuatExcel;
    }
}