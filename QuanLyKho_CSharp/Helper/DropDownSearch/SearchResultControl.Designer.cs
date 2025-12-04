namespace QuanLyKho_CSharp.Helper
{
    partial class SearchResultControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResultControl));
            this.lbNameProduct = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNameProduct
            // 
            this.lbNameProduct.AutoSize = true;
            this.lbNameProduct.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameProduct.Location = new System.Drawing.Point(61, 10);
            this.lbNameProduct.Name = "lbNameProduct";
            this.lbNameProduct.Size = new System.Drawing.Size(148, 18);
            this.lbNameProduct.TabIndex = 0;
            this.lbNameProduct.Text = "Code + NameProduct";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lbQuantity.Location = new System.Drawing.Point(61, 31);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(110, 16);
            this.lbQuantity.TabIndex = 0;
            this.lbQuantity.Text = "Số lượng tồn + Giá";
            // 
            // image
            // 
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.Location = new System.Drawing.Point(10, 5);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(45, 45);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 1;
            this.image.TabStop = false;
            // 
            // SearchResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.image);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbNameProduct);
            this.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SearchResultControl";
            this.Size = new System.Drawing.Size(275, 53);
            this.Click += new System.EventHandler(this.SearchResultControl_Click);
            this.MouseLeave += new System.EventHandler(this.SearchResultControl_MouseLeave);
            this.MouseHover += new System.EventHandler(this.SearchResultControl_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNameProduct;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.PictureBox image;
    }
}
