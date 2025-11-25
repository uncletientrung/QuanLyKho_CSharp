using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    public partial class DetailSizeForm : Form
    {
        SizeDTO size;

        public DetailSizeForm(SizeDTO _size)
        {
            this.size = _size;
            InitializeComponent();
        }



        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailSizeForm_Load(object sender, EventArgs e)
        {
            txtTenSize.Text = size.Tensize.ToString();
            txtTenSize.Enabled = false;
            txtGhiChu.Text = size.Ghichu.ToString();
            txtGhiChu.Enabled = false;
        }

        private void DetailSizeForm_Shown(object sender, EventArgs e)
        {
            txtTenSize.SelectionLength = 0;
            txtGhiChu.SelectionLength = 0;
        }
    }
}
