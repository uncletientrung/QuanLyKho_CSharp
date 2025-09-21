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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.grBoxTimKiem = new System.Windows.Forms.GroupBox();
            this.tlPheaderLeft = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtSearchNCC = new System.Windows.Forms.TextBox();
            this.dateTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.panelKhung = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchNV = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNhanVienPN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtGiaBegin = new System.Windows.Forms.Label();
            this.txtGiaEnd = new System.Windows.Forms.Label();
            this.txtTimeBegin = new System.Windows.Forms.Label();
            this.txtTimeEnd = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.grBoxTimKiem.SuspendLayout();
            this.tlPheaderLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panelKhung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.tableLayoutPanel2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(5, 3);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(13, 12, 0, 12);
            this.panelHeader.Size = new System.Drawing.Size(810, 164);
            this.panelHeader.TabIndex = 0;
            // 
            // grBoxTimKiem
            // 
            this.grBoxTimKiem.Controls.Add(this.tlPheaderLeft);
            this.grBoxTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grBoxTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.grBoxTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grBoxTimKiem.Margin = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.grBoxTimKiem.Name = "grBoxTimKiem";
            this.grBoxTimKiem.Padding = new System.Windows.Forms.Padding(0);
            this.grBoxTimKiem.Size = new System.Drawing.Size(612, 140);
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
            this.tlPheaderLeft.Location = new System.Drawing.Point(0, 25);
            this.tlPheaderLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlPheaderLeft.Name = "tlPheaderLeft";
            this.tlPheaderLeft.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.tlPheaderLeft.RowCount = 2;
            this.tlPheaderLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPheaderLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPheaderLeft.Size = new System.Drawing.Size(612, 115);
            this.tlPheaderLeft.TabIndex = 0;
            this.tlPheaderLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numericUpDown1.Location = new System.Drawing.Point(89, 7);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(81, 32);
            this.numericUpDown1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.txtSearchNCC);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(133, 7);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(124, 31);
            this.panel5.TabIndex = 1;
            // 
            // txtSearchNCC
            // 
            this.txtSearchNCC.BackColor = System.Drawing.Color.IndianRed;
            this.txtSearchNCC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchNCC.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSearchNCC.Location = new System.Drawing.Point(0, 0);
            this.txtSearchNCC.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchNCC.Name = "txtSearchNCC";
            this.txtSearchNCC.Size = new System.Drawing.Size(124, 25);
            this.txtSearchNCC.TabIndex = 0;
            // 
            // dateTimeBegin
            // 
            this.dateTimeBegin.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dateTimeBegin.CustomFormat = "dd/MM/yyyy";
            this.dateTimeBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBegin.Location = new System.Drawing.Point(89, 7);
            this.dateTimeBegin.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.dateTimeBegin.Name = "dateTimeBegin";
            this.dateTimeBegin.Size = new System.Drawing.Size(81, 32);
            this.dateTimeBegin.TabIndex = 2;
            this.dateTimeBegin.Value = new System.DateTime(2025, 9, 18, 0, 0, 0, 0);
            this.dateTimeBegin.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dateTimeEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(74, 7);
            this.dateTimeEnd.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(66, 32);
            this.dateTimeEnd.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.numericUpDown2.Location = new System.Drawing.Point(74, 7);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(66, 32);
            this.numericUpDown2.TabIndex = 4;
            // 
            // panelKhung
            // 
            this.panelKhung.BackColor = System.Drawing.SystemColors.Control;
            this.panelKhung.Controls.Add(this.dataGridView1);
            this.panelKhung.Controls.Add(this.panelHeader);
            this.panelKhung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKhung.Location = new System.Drawing.Point(0, 0);
            this.panelKhung.Margin = new System.Windows.Forms.Padding(0);
            this.panelKhung.Name = "panelKhung";
            this.panelKhung.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelKhung.Size = new System.Drawing.Size(820, 570);
            this.panelKhung.TabIndex = 1;
            this.panelKhung.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(5, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(810, 400);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(640, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(154, 134);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.grBoxTimKiem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(797, 140);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNhanVienPN, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(260, 44);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // txtSearchNV
            // 
            this.txtSearchNV.BackColor = System.Drawing.Color.IndianRed;
            this.txtSearchNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchNV.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSearchNV.Location = new System.Drawing.Point(0, 0);
            this.txtSearchNV.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchNV.Name = "txtSearchNV";
            this.txtSearchNV.Size = new System.Drawing.Size(124, 25);
            this.txtSearchNV.TabIndex = 0;
            this.txtSearchNV.WordWrap = false;
            this.txtSearchNV.TextChanged += new System.EventHandler(this.txtNhanVien_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtSearchNV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(133, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 30);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 60);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(260, 45);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // txtNhanVienPN
            // 
            this.txtNhanVienPN.AutoSize = true;
            this.txtNhanVienPN.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtNhanVienPN.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNhanVienPN.Location = new System.Drawing.Point(25, 0);
            this.txtNhanVienPN.Name = "txtNhanVienPN";
            this.txtNhanVienPN.Size = new System.Drawing.Size(102, 44);
            this.txtNhanVienPN.TabIndex = 1;
            this.txtNhanVienPN.Text = "Nhân viên";
            this.txtNhanVienPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtNhanVienPN.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhà cung cấp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.txtGiaBegin, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(278, 60);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(173, 45);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.txtGiaEnd, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.numericUpDown2, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(457, 60);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(143, 45);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // txtGiaBegin
            // 
            this.txtGiaBegin.AutoSize = true;
            this.txtGiaBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtGiaBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaBegin.Location = new System.Drawing.Point(17, 0);
            this.txtGiaBegin.Name = "txtGiaBegin";
            this.txtGiaBegin.Size = new System.Drawing.Size(66, 45);
            this.txtGiaBegin.TabIndex = 2;
            this.txtGiaBegin.Text = "Giá từ";
            this.txtGiaBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGiaEnd
            // 
            this.txtGiaEnd.AutoSize = true;
            this.txtGiaEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtGiaEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaEnd.Location = new System.Drawing.Point(22, 0);
            this.txtGiaEnd.Name = "txtGiaEnd";
            this.txtGiaEnd.Size = new System.Drawing.Size(46, 45);
            this.txtGiaEnd.TabIndex = 2;
            this.txtGiaEnd.Text = "đến";
            this.txtGiaEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimeBegin
            // 
            this.txtTimeBegin.AutoSize = true;
            this.txtTimeBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimeBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeBegin.Location = new System.Drawing.Point(27, 0);
            this.txtTimeBegin.Name = "txtTimeBegin";
            this.txtTimeBegin.Size = new System.Drawing.Size(56, 44);
            this.txtTimeBegin.TabIndex = 2;
            this.txtTimeBegin.Text = "Từ ngày";
            this.txtTimeBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimeEnd
            // 
            this.txtTimeEnd.AutoSize = true;
            this.txtTimeEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimeEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeEnd.Location = new System.Drawing.Point(22, 0);
            this.txtTimeEnd.Name = "txtTimeEnd";
            this.txtTimeEnd.Size = new System.Drawing.Size(46, 44);
            this.txtTimeEnd.TabIndex = 3;
            this.txtTimeEnd.Text = "đến";
            this.txtTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.dateTimeEnd, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.txtTimeEnd, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(457, 10);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(143, 44);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.dateTimeBegin, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.txtTimeBegin, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(278, 10);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(173, 44);
            this.tableLayoutPanel7.TabIndex = 6;
            // 
            // btnXuat
            // 
            this.btnXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnXuat.Location = new System.Drawing.Point(97, 66);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnXuat.MinimumSize = new System.Drawing.Size(91, 50);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(91, 50);
            this.btnXuat.TabIndex = 1;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(18, 66);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnThem.MinimumSize = new System.Drawing.Size(91, 50);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 50);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // PhieuNhapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 570);
            this.Controls.Add(this.panelKhung);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PhieuNhapGUI";
            this.Text = "NHẬP HÀNG";
            this.Load += new System.EventHandler(this.PhieuNhap_Load);
            this.panelHeader.ResumeLayout(false);
            this.grBoxTimKiem.ResumeLayout(false);
            this.tlPheaderLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panelKhung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TableLayoutPanel tlPheaderLeft;
        private System.Windows.Forms.Panel panelKhung;
        private Panel panel5;
        private TextBox txtSearchNCC;
        private DateTimePicker dateTimeBegin;
        private GroupBox grBoxTimKiem;
        private DateTimePicker dateTimeEnd;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel2;
        private TextBox txtSearchNV;
        private TableLayoutPanel tableLayoutPanel4;
        private Label txtNhanVienPN;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label txtGiaBegin;
        private Label txtGiaEnd;
        private TableLayoutPanel tableLayoutPanel7;
        private Label txtTimeBegin;
        private TableLayoutPanel tableLayoutPanel8;
        private Label txtTimeEnd;
        private Button btnThem;
        private Button btnXuat;
    }
}