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

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class DeleteLoaiForm : Form
    {
        private LoaiBUS loaiBUS = new LoaiBUS();
        private LoaiDTO loai;

        public DeleteLoaiForm(LoaiDTO _loai)
        {
            this.loai = _loai;
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            loaiBUS.removeLoai(loai.Maloai);
            this.DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
