using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper
{
    public partial class QuantityForm : Form
    {
        public int Quantity { get; set; }
        private int soluongTon;
        public QuantityForm(string title, int soLuongTruyenVao, int soluongton)
        {
            this.FormBorderStyle= FormBorderStyle.None;
            InitializeComponent();
            this.soluongTon = soluongton;
            lb.Text = title;
            lbTonKho.Text = "Hàng tồn còn: " + soluongTon.ToString();
            soLuong.Maximum = 10000;
            soLuong.Minimum= 1;
            soLuong.Value = soLuongTruyenVao;
           
        }

        private void kryptonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int slNhap= int.Parse(soLuong.Value.ToString());
            if (slNhap > soluongTon)
            {
                MessageBox.Show("Đã nhập quá số lượng tồn kho", "Cảnh báo",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Quantity = int.Parse(soLuong.Value.ToString());
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }

        private void artanPanel1_Paint(object sender, PaintEventArgs e)
        {

            
        }

        private void QuantityForm_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 5;             // Độ dày viền
            Color borderColor = Color.FromArgb(0, 0, 0);  // Màu viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}
