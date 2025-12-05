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

namespace QuanLyKho_CSharp.GUI.SanPham
{
    public partial class DeleteSanPhamForm : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private SanPhamDTO sp;
        public DeleteSanPhamForm(SanPhamDTO _sp)
        {
            InitializeComponent();
            sp = _sp;
            lbInfo.Text = $"Bạn có chắc chắn muốn xóa {sp.Tensp} không?";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            spBUS.removeSanPham(sp.Masp);
            this.DialogResult = DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
