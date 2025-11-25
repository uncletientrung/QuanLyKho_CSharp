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

namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    public partial class DeleteTaiKhoanForm : Form
    {
        private TaiKhoanBUS tkBUS= new TaiKhoanBUS();
        private TaiKhoanDTO tk;
        public DeleteTaiKhoanForm(TaiKhoanDTO _tk)
        {
            InitializeComponent();
            tk = _tk;
        }

        private void DeleteTaiKhoanForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tkBUS.DeleteTK(tk.Manv);
            this.DialogResult= DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
