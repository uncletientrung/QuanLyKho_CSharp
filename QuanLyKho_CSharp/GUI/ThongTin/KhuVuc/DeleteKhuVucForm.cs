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

namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    public partial class DeleteKhuVucForm : Form
    {
        private KhuVucKhoBUS khuVucKhoBUS = new KhuVucKhoBUS();
        private KhuVucKhoDTO kvk;

        public DeleteKhuVucForm(KhuVucKhoDTO _kvk)
        {
            this.kvk = _kvk;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            khuVucKhoBUS.removeKhuVuc(kvk.Makhuvuc);
            this.DialogResult = DialogResult.OK;
        }
    }
}
