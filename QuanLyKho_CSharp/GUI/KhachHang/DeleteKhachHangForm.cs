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

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class DeleteKhachHangForm : Form
    {
        private KhachHangBUS khBUS = new KhachHangBUS();
        private KhachHangDTO kh;

        public DeleteKhachHangForm(KhachHangDTO _kh)
        {
            this.kh = _kh;
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            khBUS.removeKhachHang(kh.Makh);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
