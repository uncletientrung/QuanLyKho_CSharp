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
    public partial class CanBangForm : Form
    {
        private PhieuKiemKeDTO pkkDuocChon;
        private PhieuKiemKeBUS pkkBUS = new PhieuKiemKeBUS();
        public CanBangForm(PhieuKiemKeDTO _pkkDuocChon)
        {
            InitializeComponent();
            this.pkkDuocChon = _pkkDuocChon;
            lbInfo.Text = $"Bạn chắc chắn đã cân bằng phiếu PKK-{pkkDuocChon.Maphieukiemke} hết chưa?";
        }
        private void btnCanBang_Click(object sender, EventArgs e)
        {
            pkkDuocChon.Thoigiancanbang = DateTime.Now;
            pkkDuocChon.Trangthai = "Đã cân bằng";
            pkkBUS.updateTrangThai(pkkDuocChon);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
