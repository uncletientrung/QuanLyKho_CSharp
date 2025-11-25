using QuanLyKho.BUS;
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
    public partial class DeleteSizeForm : Form
    {
        private SizeBUS sizeBUS = new SizeBUS();
        private SizeDTO size;

        public DeleteSizeForm(SizeDTO _size)
        {
            this.size = _size;
            InitializeComponent();
        }

        private void DeleteSizeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sizeBUS.removeSize(size.Masize);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
