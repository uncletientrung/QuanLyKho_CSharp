namespace QuanLyKho_CSharp.Helper.DropDownSearch
{
    partial class SearchResultControlCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResultControlCustomer));
            this.lbSDT = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSDT
            // 
            this.lbSDT.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSDT.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lbSDT.Location = new System.Drawing.Point(140, 15);
            this.lbSDT.Name = "lbSDT";
            this.lbSDT.Size = new System.Drawing.Size(96, 15);
            this.lbSDT.TabIndex = 2;
            this.lbSDT.Text = "số điện thoại";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(44, 1);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 16);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Họ và tên";
            // 
            // image
            // 
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.Location = new System.Drawing.Point(10, 1);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(28, 28);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 4;
            this.image.TabStop = false;
            // 
            // SearchResultControlCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.image);
            this.Controls.Add(this.lbSDT);
            this.Controls.Add(this.lbName);
            this.Name = "SearchResultControlCustomer";
            this.Size = new System.Drawing.Size(236, 30);
            this.Click += new System.EventHandler(this.SearchResultControl_Click);
            this.MouseLeave += new System.EventHandler(this.SearchResultControl_MouseLeave);
            this.MouseHover += new System.EventHandler(this.SearchResultControl_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Label lbSDT;
        private System.Windows.Forms.Label lbName;
    }
}
