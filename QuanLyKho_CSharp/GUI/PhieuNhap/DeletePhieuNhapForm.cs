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

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class DeletePhieuNhapForm : Form
    {
        private PhieuNhapDTO pnDuocChon;
        private PhieuNhapBUS pnBUS=  new PhieuNhapBUS();
        public DeletePhieuNhapForm(PhieuNhapDTO pnDuocChon)
        {
            InitializeComponent();
            this.pnDuocChon = pnDuocChon;
            string name = pnDuocChon.Maphieu.ToString();
            lbInfo.Text = $"Bạn có chắc chắn muốn xóa mã phiếu {name} không?";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            pnBUS.removePhieuNhap(pnDuocChon.Maphieu);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
