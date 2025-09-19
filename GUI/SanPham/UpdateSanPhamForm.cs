using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.SanPham
{
    public partial class UpdateSanPhamForm : Form
    {
        SanPhamDTO sp;
        public UpdateSanPhamForm(SanPhamDTO _sp)
        {
            this.sp= _sp;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateSanPhamForm_Load(object sender, EventArgs e)
        {
            txtMaSanPham.Enabled = false;
        }
    }
}
