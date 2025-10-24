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
            this.txtSearchNCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtGiaBegin = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchNV = new System.Windows.Forms.TextBox();
            this.txtNhanVienPN = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.panelKhung = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelKhung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.tableLayoutPanel2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(5, 2);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(13, 12, 0, 12);
            this.panelHeader.Size = new System.Drawing.Size(996, 164);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(983, 140);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.grBoxTimKiem.Size = new System.Drawing.Size(761, 140);
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
            this.tlPheaderLeft.Size = new System.Drawing.Size(761, 115);
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
            this.tableLayoutPanel8.Location = new System.Drawing.Point(569, 9);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(180, 46);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dateTimeEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(93, 7);
            this.dateTimeEnd.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(84, 32);
            this.dateTimeEnd.TabIndex = 0;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            // 
            // txtTimeEnd
            // 
            this.txtTimeEnd.AutoSize = true;
            this.txtTimeEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimeEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeEnd.Location = new System.Drawing.Point(41, 0);
            this.txtTimeEnd.Name = "txtTimeEnd";
            this.txtTimeEnd.Size = new System.Drawing.Size(46, 46);
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
            this.tableLayoutPanel7.Location = new System.Drawing.Point(345, 9);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(218, 46);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // dateTimeBegin
            // 
            this.dateTimeBegin.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dateTimeBegin.CustomFormat = "dd/MM/yyyy";
            this.dateTimeBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBegin.Location = new System.Drawing.Point(112, 7);
            this.dateTimeBegin.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.dateTimeBegin.Name = "dateTimeBegin";
            this.dateTimeBegin.Size = new System.Drawing.Size(103, 32);
            this.dateTimeBegin.TabIndex = 0;
            this.dateTimeBegin.Value = new System.DateTime(2025, 9, 18, 0, 0, 0, 0);
            this.dateTimeBegin.ValueChanged += new System.EventHandler(this.dateTimeBegin_ValueChanged);
            // 
            // txtTimeBegin
            // 
            this.txtTimeBegin.AutoSize = true;
            this.txtTimeBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTimeBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTimeBegin.Location = new System.Drawing.Point(21, 0);
            this.txtTimeBegin.Name = "txtTimeBegin";
            this.txtTimeBegin.Size = new System.Drawing.Size(85, 46);
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
            this.tableLayoutPanel6.Location = new System.Drawing.Point(569, 59);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(180, 47);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // txtGiaEnd
            // 
            this.txtGiaEnd.AutoSize = true;
            this.txtGiaEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtGiaEnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaEnd.Location = new System.Drawing.Point(41, 0);
            this.txtGiaEnd.Name = "txtGiaEnd";
            this.txtGiaEnd.Size = new System.Drawing.Size(46, 47);
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
            this.numericUpDown2.Location = new System.Drawing.Point(93, 7);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(84, 32);
            this.numericUpDown2.TabIndex = 0;
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 59);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(327, 47);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.txtSearchNCC);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(166, 7);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(158, 33);
            this.panel5.TabIndex = 1;
            // 
            // txtSearchNCC
            // 
            this.txtSearchNCC.BackColor = System.Drawing.Color.White;
            this.txtSearchNCC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchNCC.Font = new System.Drawing.Font("Segoe UI", 12.7F);
            this.txtSearchNCC.Location = new System.Drawing.Point(0, 0);
            this.txtSearchNCC.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchNCC.Name = "txtSearchNCC";
            this.txtSearchNCC.Size = new System.Drawing.Size(158, 29);
            this.txtSearchNCC.TabIndex = 0;
            this.txtSearchNCC.TextChanged += new System.EventHandler(this.txtSearchNCC_TextChanged);
            this.txtSearchNCC.Enter += new System.EventHandler(this.txtSearchNCC_Enter);
            this.txtSearchNCC.Leave += new System.EventHandler(this.txtSearchNCC_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(26, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhà cung cấp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel5.Location = new System.Drawing.Point(345, 59);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(218, 47);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // txtGiaBegin
            // 
            this.txtGiaBegin.AutoSize = true;
            this.txtGiaBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtGiaBegin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGiaBegin.Location = new System.Drawing.Point(40, 0);
            this.txtGiaBegin.Name = "txtGiaBegin";
            this.txtGiaBegin.Size = new System.Drawing.Size(66, 47);
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
            this.numericUpDown1.Location = new System.Drawing.Point(112, 7);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 32);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 9);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(327, 46);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtSearchNV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(166, 7);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 32);
            this.panel2.TabIndex = 0;
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
            this.txtSearchNV.Size = new System.Drawing.Size(158, 29);
            this.txtSearchNV.TabIndex = 0;
            this.txtSearchNV.WordWrap = false;
            this.txtSearchNV.TextChanged += new System.EventHandler(this.txtSearchNV_TextChanged);
            this.txtSearchNV.Enter += new System.EventHandler(this.txtSearchNV_Enter);
            this.txtSearchNV.Leave += new System.EventHandler(this.txtSearchNV_Leave);
            // 
            // txtNhanVienPN
            // 
            this.txtNhanVienPN.AutoSize = true;
            this.txtNhanVienPN.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtNhanVienPN.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtNhanVienPN.Location = new System.Drawing.Point(58, 0);
            this.txtNhanVienPN.Name = "txtNhanVienPN";
            this.txtNhanVienPN.Size = new System.Drawing.Size(102, 46);
            this.txtNhanVienPN.TabIndex = 1;
            this.txtNhanVienPN.Text = "Nhân viên";
            this.txtNhanVienPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtNhanVienPN.Click += new System.EventHandler(this.label1_Click);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(789, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(191, 136);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(18, 69);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 20, 2);
            this.btnThem.MinimumSize = new System.Drawing.Size(91, 50);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 50);
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
            this.btnXuat.Location = new System.Drawing.Point(115, 69);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.btnXuat.MinimumSize = new System.Drawing.Size(91, 50);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(91, 50);
            this.btnXuat.TabIndex = 1;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
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
            this.panelKhung.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.panelKhung.Size = new System.Drawing.Size(1006, 631);
            this.panelKhung.TabIndex = 1;
            this.panelKhung.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(5, 166);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(996, 463);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // PhieuNhapGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 631);
            this.Controls.Add(this.panelKhung);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PhieuNhapGUI";
            this.Text = "NHẬP HÀNG";
            this.Load += new System.EventHandler(this.PhieuNhap_Load);
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
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelKhung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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