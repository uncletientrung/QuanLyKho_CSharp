using Microsoft.Office.Interop.Excel;
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

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class DeletePhieuKiemKeForm : Form
    {
        private PhieuKiemKeDTO pkkDuocChon;
        private PhieuKiemKeBUS pkkBUS= new PhieuKiemKeBUS();
        public DeletePhieuKiemKeForm(PhieuKiemKeDTO _pkkDuocChon)
        {
            InitializeComponent();
            this.pkkDuocChon = _pkkDuocChon;
            lbInfo.Text= $"Bạn có chắc chắn muốn xóa mã phiếu PKK-{pkkDuocChon.Maphieukiemke} không?";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            pkkBUS.Delete(pkkDuocChon.Maphieukiemke);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
