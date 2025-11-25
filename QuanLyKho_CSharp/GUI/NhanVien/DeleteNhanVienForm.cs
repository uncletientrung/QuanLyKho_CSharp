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

namespace QuanLyKho_CSharp.GUI.NhanVien
{
    public partial class DeleteNhanVienForm : Form
    {
        private NhanVienBUS nvBUS= new NhanVienBUS();
        private NhanVienDTO nv;
        public DeleteNhanVienForm(NhanVienDTO _nv)
        {
            this.nv= _nv;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            nvBUS.removeNhanVien(nv.Manv);
            this.DialogResult= DialogResult.OK;
        }

        private void DeleteNhanVienForm_Load(object sender, EventArgs e)
        {
            string name = nv.Tennv.ToString();
            lbInfo.Text = $"Bạn có chắc chắn muốn xóa {name} không?";
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
