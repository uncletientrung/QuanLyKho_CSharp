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
    public partial class DetailKhuVucForm : Form
    {
        KhuVucKhoDTO kvk;

        public DetailKhuVucForm(KhuVucKhoDTO _kvk)
        {
            this.kvk = _kvk;
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailKhuVucForm_Load(object sender, EventArgs e)
        {
            txtTenKhuVucKho.Text = kvk.Tenkhuvuc.ToString();
            txtTenKhuVucKho.Enabled = false; //Chặn sửa
            txtDiaChi.Text = kvk.Diachi.ToString();
            txtDiaChi.Enabled = false; // Chặn sửa
            txtSoDienThoai.Text = kvk.Sdt.ToString();
            txtSoDienThoai.Enabled = false; //Chặn sửa
            txtEmail.Text = kvk.Email.ToString();
            txtEmail.Enabled = false; //Chặn sửa
        }

        private void DetailKhuVucKho_Shown(object sender, EventArgs e)
        {
            txtTenKhuVucKho.SelectionLength = 0; // Chặn bị bôi đen khi mở form
            txtDiaChi.SelectionLength = 0;
            txtSoDienThoai.SelectionLength = 0;
            txtEmail.SelectionLength = 0;
        }
    }
}
