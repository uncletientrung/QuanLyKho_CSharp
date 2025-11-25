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

namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class DeleteNhaCungCapForm : Form
    {
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private NhaCungCapDTO ncc;
        
        public DeleteNhaCungCapForm(NhaCungCapDTO _ncc)
        {
            this.ncc = _ncc;
            InitializeComponent();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            nccBUS.removeNhaCungCap(ncc.Mancc);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
