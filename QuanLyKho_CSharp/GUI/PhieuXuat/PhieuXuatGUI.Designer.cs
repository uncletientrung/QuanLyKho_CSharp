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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhieuXuatGUI));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNhanVienPN = new System.Windows.Forms.Label();
            this.txtSearchNV = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtGiaBegin = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchKH = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grBoxTimKiem = new System.Windows.Forms.GroupBox();
            this.tlPheaderLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.txtTimeEnd = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.txtTimeBegin = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtGiaEnd = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.remove = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grBoxTimKiem.SuspendLayout();
            this.tlPheaderLeft.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlDGV.SuspendLayout();
            this.artanPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(789, 108);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dialogHoanHang_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(15, 34);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 18, 2);
            this.btnThem.MinimumSize = new System.Drawing.Size(79, 47);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(79, 47);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnXuat.Location = new System.Drawing.Point(125, 34);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(18, 2, 2, 2);
            this.btnXuat.MinimumSize = new System.Drawing.Size(79, 47);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(79, 47);
            this.btnXuat.TabIndex = 1;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnThem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnXuat, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(874, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 97);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // txtNhanVienPN
            // 
            this.txtNhanVienPN.AutoSize = true;
            this.txtNhanVienPN.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtNhanVienPN.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNhanVienPN.Location = new System.Drawing.Point(102, 0);
            this.txtNhanVienPN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtNhanVienPN.Name = "txtNhanVienPN";
            this.txtNhanVienPN.Size = new System.Drawing.Size(80, 29);
            this.txtNhanVienPN.TabIndex = 1;
            this.txtNhanVienPN.Text = "Nhân viên";
            this.txtNhanVienPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchNV
            // 
            this.txtSearchNV.BackColor = System.Drawing.Color.White;
            this.txtSearchNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchNV.Font = new System.Drawing.Font("Segoe UI", 12.7F);
            this.txtSearchNV.Location = new System.Drawing.Point(0, 0);
            this.txtSearchNV.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchNV.Name = "txtSearchNV";
            this.txtSearchNV.Size = new System.Drawing.Size(181, 23);
            this.txtSearchNV.TabIndex = 0;
            this.txtSearchNV.WordWrap = false;
            this.txtSearchNV.TextChanged += new System.EventHandler(this.txtSearchNV_TextChanged);
            this.txtSearchNV.Enter += new System.EventHandler(this.txtSearchNV_Enter);
            this.txtSearchNV.Leave += new System.EventHandler(this.txtSearchNV_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtSearchNV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(186, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 15);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNhanVienPN, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 9);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(369, 29);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtGiaBegin
            // 
            this.txtGiaBegin.AutoSize = true;
            this.txtGiaBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtGiaBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaBegin.Location = new System.Drawing.Point(69, 0);
            this.txtGiaBegin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtGiaBegin.Name = "txtGiaBegin";
            this.txtGiaBegin.Size = new System.Drawing.Size(52, 30);
            this.txtGiaBegin.TabIndex = 2;
            this.txtGiaBegin.Text = "Giá từ";
            this.txtGiaBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(125, 7);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 7, 2, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 27);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.txtGiaBegin, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(383, 42);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(247, 30);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // txtSearchKH
            // 
            this.txtSearchKH.BackColor = System.Drawing.Color.White;
            this.txtSearchKH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchKH.Font = new System.Drawing.Font("Segoe UI", 12.7F);
            this.txtSearchKH.Location = new System.Drawing.Point(0, 0);
            this.txtSearchKH.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchKH.Name = "txtSearchKH";
            this.txtSearchKH.Size = new System.Drawing.Size(181, 23);
            this.txtSearchKH.TabIndex = 0;
            this.txtSearchKH.TextChanged += new System.EventHandler(this.txtSearchKH_TextChanged);
            this.txtSearchKH.Enter += new System.EventHandler(this.txtSearchKH_Enter);
            this.txtSearchKH.Leave += new System.EventHandler(this.txtSearchKH_Leave);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.dataGridView1);
            this.panelHeader.Controls.Add(this.tableLayoutPanel2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(5, 5);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(12, 12, 0, 12);
            this.panelHeader.Size = new System.Drawing.Size(1103, 125);
            this.panelHeader.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.grBoxTimKiem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1091, 101);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // grBoxTimKiem
            // 
            this.grBoxTimKiem.Controls.Add(this.tlPheaderLeft);
            this.grBoxTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grBoxTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.grBoxTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grBoxTimKiem.Margin = new System.Windows.Forms.Padding(0, 0, 22, 0);
            this.grBoxTimKiem.Name = "grBoxTimKiem";
            this.grBoxTimKiem.Padding = new System.Windows.Forms.Padding(0);
            this.grBoxTimKiem.Size = new System.Drawing.Size(850, 101);
            this.grBoxTimKiem.TabIndex = 1;
            this.grBoxTimKiem.TabStop = false;
            this.grBoxTimKiem.Text = "Tìm kiếm";
            this.grBoxTimKiem.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tlPheaderLeft
            // 
            this.tlPheaderLeft.BackColor = System.Drawing.Color.Transparent;
            this.tlPheaderLeft.ColumnCount = 3;
            this.tlPheaderLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.78114F));
            this.tlPheaderLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.13468F));
            this.tlPheaderLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlPheaderLeft.Controls.Add(this.tableLayoutPanel8, 2, 0);
            this.tlPheaderLeft.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tlPheaderLeft.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tlPheaderLeft.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tlPheaderLeft.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tlPheaderLeft.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tlPheaderLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPheaderLeft.Location = new System.Drawing.Point(0, 20);
            this.tlPheaderLeft.Margin = new System.Windows.Forms.Padding(2);
            this.tlPheaderLeft.Name = "tlPheaderLeft";
            this.tlPheaderLeft.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tlPheaderLeft.RowCount = 2;
            this.tlPheaderLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPheaderLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPheaderLeft.Size = new System.Drawing.Size(850, 81);
            this.tlPheaderLeft.TabIndex = 0;
            this.tlPheaderLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.dateTimeEnd, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.txtTimeEnd, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(634, 9);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(206, 29);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dateTimeEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(105, 7);
            this.dateTimeEnd.Margin = new System.Windows.Forms.Padding(2, 7, 2, 2);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(99, 27);
            this.dateTimeEnd.TabIndex = 3;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            // 
            // txtTimeEnd
            // 
            this.txtTimeEnd.AutoSize = true;
            this.txtTimeEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimeEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeEnd.Location = new System.Drawing.Point(66, 0);
            this.txtTimeEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTimeEnd.Name = "txtTimeEnd";
            this.txtTimeEnd.Size = new System.Drawing.Size(35, 29);
            this.txtTimeEnd.TabIndex = 3;
            this.txtTimeEnd.Text = "đến";
            this.txtTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.dateTimeBegin, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.txtTimeBegin, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(383, 9);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(247, 29);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // dateTimeBegin
            // 
            this.dateTimeBegin.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dateTimeBegin.CustomFormat = "dd/MM/yyyy";
            this.dateTimeBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBegin.Location = new System.Drawing.Point(125, 7);
            this.dateTimeBegin.Margin = new System.Windows.Forms.Padding(2, 7, 2, 2);
            this.dateTimeBegin.Name = "dateTimeBegin";
            this.dateTimeBegin.Size = new System.Drawing.Size(120, 27);
            this.dateTimeBegin.TabIndex = 2;
            this.dateTimeBegin.Value = new System.DateTime(2025, 9, 18, 0, 0, 0, 0);
            this.dateTimeBegin.ValueChanged += new System.EventHandler(this.dateTimeBegin_ValueChanged);
            // 
            // txtTimeBegin
            // 
            this.txtTimeBegin.AutoSize = true;
            this.txtTimeBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimeBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeBegin.Location = new System.Drawing.Point(55, 0);
            this.txtTimeBegin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTimeBegin.Name = "txtTimeBegin";
            this.txtTimeBegin.Size = new System.Drawing.Size(66, 29);
            this.txtTimeBegin.TabIndex = 2;
            this.txtTimeBegin.Text = "Từ ngày";
            this.txtTimeBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.txtGiaEnd, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.numericUpDown2, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(634, 42);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(206, 30);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // txtGiaEnd
            // 
            this.txtGiaEnd.AutoSize = true;
            this.txtGiaEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtGiaEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaEnd.Location = new System.Drawing.Point(66, 0);
            this.txtGiaEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtGiaEnd.Name = "txtGiaEnd";
            this.txtGiaEnd.Size = new System.Drawing.Size(35, 30);
            this.txtGiaEnd.TabIndex = 2;
            this.txtGiaEnd.Text = "đến";
            this.txtGiaEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numericUpDown2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(105, 7);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2, 7, 2, 2);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(99, 27);
            this.numericUpDown2.TabIndex = 4;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(10, 42);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(369, 30);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.txtSearchKH);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(186, 7);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(181, 16);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(91, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Khách hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlDGV
            // 
            this.pnlDGV.Controls.Add(this.artanPanel1);
            this.pnlDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDGV.Location = new System.Drawing.Point(5, 130);
            this.pnlDGV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlDGV.Name = "pnlDGV";
            this.pnlDGV.Size = new System.Drawing.Size(1103, 421);
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
            this.artanPanel1.Size = new System.Drawing.Size(1103, 421);
            this.artanPanel1.TabIndex = 0;
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
            this.edit,
            this.remove});
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
            this.DGVPhieuXuat.Size = new System.Drawing.Size(1093, 404);
            this.DGVPhieuXuat.TabIndex = 0;
            // 
            // mapx
            // 
            this.mapx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mapx.FillWeight = 10F;
            this.mapx.HeaderText = "Mã";
            this.mapx.Name = "mapx";
            this.mapx.ReadOnly = true;
            this.mapx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nv
            // 
            this.nv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nv.FillWeight = 25F;
            this.nv.HeaderText = "Nhân viên tạo";
            this.nv.Name = "nv";
            this.nv.ReadOnly = true;
            // 
            // kh
            // 
            this.kh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kh.FillWeight = 10F;
            this.kh.HeaderText = "Khách hàng";
            this.kh.Name = "kh";
            this.kh.ReadOnly = true;
            // 
            // thoigiantao
            // 
            this.thoigiantao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.thoigiantao.FillWeight = 20F;
            this.thoigiantao.HeaderText = "Thời gian tạo";
            this.thoigiantao.Name = "thoigiantao";
            this.thoigiantao.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongtien.FillWeight = 10F;
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
            // hoanhang
            // 
            this.hoanhang.HeaderText = "Hoàn hàng";
            this.hoanhang.Name = "hoanhang";
            this.hoanhang.ReadOnly = true;
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
            // PhieuXuatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1113, 556);
            this.Controls.Add(this.pnlDGV);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PhieuXuatGUI";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.PhieuXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grBoxTimKiem.ResumeLayout(false);
            this.tlPheaderLeft.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlDGV.ResumeLayout(false);
            this.artanPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPhieuXuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtNhanVienPN;
        private System.Windows.Forms.TextBox txtSearchNV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label txtGiaBegin;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtSearchKH;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grBoxTimKiem;
        private System.Windows.Forms.TableLayoutPanel tlPheaderLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label txtTimeEnd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.DateTimePicker dateTimeBegin;
        private System.Windows.Forms.Label txtTimeBegin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label txtGiaEnd;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDGV;
        private Helper.component.ArtanPanel artanPanel1;
        private System.Windows.Forms.DataGridView DGVPhieuXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapx;
        private System.Windows.Forms.DataGridViewTextBoxColumn nv;
        private System.Windows.Forms.DataGridViewTextBoxColumn kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoigiantao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewButtonColumn hoanhang;
        private System.Windows.Forms.DataGridViewImageColumn detail;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn remove;
    }
}