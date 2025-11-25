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

namespace QuanLyKho_CSharp.GUI.NhomQuyen
{
    public partial class DeleteNhomQuyenForm : Form
    {
        private NhomQuyenBUS nqBUS=new NhomQuyenBUS();
        private NhomQuyenDTO nq;
        public DeleteNhomQuyenForm(NhomQuyenDTO _nq)
        {
            InitializeComponent();
            
             nq=_nq;
            lbInfo.Text = $"Bạn có chắn chắn muốn xóa {nq.Tennhomquyen} không?";

        }

        private void DeleteNhomQuyenForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            nqBUS.DeleteNhomQuyen(nq.Manhomquyen);
            this.DialogResult = DialogResult.OK;
        }
    }
}
