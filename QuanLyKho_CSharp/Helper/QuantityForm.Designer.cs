namespace QuanLyKho_CSharp.Helper
{
    partial class QuantityForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.artanPanel1 = new QuanLyKho_CSharp.Helper.component.ArtanPanel();
            this.lbTonKho = new System.Windows.Forms.Label();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lb = new System.Windows.Forms.Label();
            this.soLuong = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.artanPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // artanPanel1
            // 
            this.artanPanel1.BackColor = System.Drawing.Color.DimGray;
            this.artanPanel1.BorderRadius = 30;
            this.artanPanel1.Controls.Add(this.lbTonKho);
            this.artanPanel1.Controls.Add(this.btnCancel);
            this.artanPanel1.Controls.Add(this.btnOk);
            this.artanPanel1.Controls.Add(this.lb);
            this.artanPanel1.Controls.Add(this.soLuong);
            this.artanPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.artanPanel1.ForeColor = System.Drawing.Color.Black;
            this.artanPanel1.GradientAngle = 90F;
            this.artanPanel1.GradientBottomColor = System.Drawing.Color.White;
            this.artanPanel1.GradientTopColor = System.Drawing.Color.White;
            this.artanPanel1.Location = new System.Drawing.Point(5, 5);
            this.artanPanel1.Name = "artanPanel1";
            this.artanPanel1.Size = new System.Drawing.Size(370, 171);
            this.artanPanel1.TabIndex = 25;
            this.artanPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.artanPanel1_Paint);
            // 
            // lbTonKho
            // 
            this.lbTonKho.BackColor = System.Drawing.Color.White;
            this.lbTonKho.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTonKho.ForeColor = System.Drawing.Color.Black;
            this.lbTonKho.Location = new System.Drawing.Point(223, 0);
            this.lbTonKho.Name = "lbTonKho";
            this.lbTonKho.Size = new System.Drawing.Size(147, 28);
            this.lbTonKho.TabIndex = 25;
            this.lbTonKho.Text = "Hàng tồn còn:  0";
            this.lbTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(189, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnCancel.Size = new System.Drawing.Size(91, 40);
            this.btnCancel.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.StateCommon.Back.ColorAngle = 45F;
            this.btnCancel.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.StateCommon.Border.ColorAngle = 45F;
            this.btnCancel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCancel.StateCommon.Border.Rounding = 10;
            this.btnCancel.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnCancel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCancel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnCancel.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnCancel.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(80, 106);
            this.btnOk.Name = "btnOk";
            this.btnOk.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnOk.Size = new System.Drawing.Size(91, 40);
            this.btnOk.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.StateCommon.Back.ColorAngle = 45F;
            this.btnOk.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.StateCommon.Border.ColorAngle = 45F;
            this.btnOk.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOk.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnOk.StateCommon.Border.Rounding = 10;
            this.btnOk.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 5, -1, -1);
            this.btnOk.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOk.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.btnOk.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.btnOk.StatePressed.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.btnOk.TabIndex = 23;
            this.btnOk.Values.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lb
            // 
            this.lb.BackColor = System.Drawing.Color.White;
            this.lb.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.lb.Location = new System.Drawing.Point(63, 28);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(227, 31);
            this.lb.TabIndex = 22;
            this.lb.Text = "Chỉnh sửa số lượng";
            this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // soLuong
            // 
            this.soLuong.Location = new System.Drawing.Point(101, 62);
            this.soLuong.MaximumSize = new System.Drawing.Size(150, 27);
            this.soLuong.MinimumSize = new System.Drawing.Size(150, 27);
            this.soLuong.Name = "soLuong";
            this.soLuong.Size = new System.Drawing.Size(150, 27);
            this.soLuong.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.soLuong.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.soLuong.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(248)))));
            this.soLuong.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.soLuong.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.soLuong.StateCommon.Content.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soLuong.TabIndex = 0;
            this.soLuong.ValueChanged += new System.EventHandler(this.kryptonNumericUpDown1_ValueChanged);
            this.soLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soLuong_KeyPress);
            // 
            // QuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 181);
            this.Controls.Add(this.artanPanel1);
            this.Name = "QuantityForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QuantityForm_Paint);
            this.artanPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown soLuong;
        private System.Windows.Forms.Label lb;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private component.ArtanPanel artanPanel1;
        private System.Windows.Forms.Label lbTonKho;
    }
}
