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
    public partial class DetailKhachHangForm : Form
    {
        KhachHangDTO kh;

        public DetailKhachHangForm(KhachHangDTO _kh)
        {
            this.kh = _kh;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailKhachHangForm_Load(object sender, EventArgs e)
        {
            txtName.Text = kh.Tenkhachhang.ToString();
            txtName.Enabled = false; //Chặn sửa

            txtSDT.Text = kh.Sdt.ToString();
            txtSDT.Enabled = false; //Chặn sửa

            txtEmail.Text = kh.Email.ToString();
            txtEmail.Enabled = false; //Chặn sửa

            dtpDate.Text = kh.Ngaysinh.Date.ToString();
            dtpDate.Enabled = false; // Chặn sửa
        }

        private void DetailKhachHangForm_Shown(object sender, EventArgs e)
        {
            txtName.SelectionLength = 0;
            txtSDT.SelectionLength = 0;
            txtEmail.SelectionLength = 0;
        }
    }
}
