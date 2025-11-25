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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class DetailNhaCungCapForm : Form
    {
        NhaCungCapDTO ncc;
        
        public DetailNhaCungCapForm(NhaCungCapDTO _ncc)
        {
            this.ncc = _ncc;
            InitializeComponent();
        }

        private void DetailNhaCungCapForm_Load(object sender, EventArgs e)
        {   
            txtTenNhaCungCap.Text = ncc.Tenncc.ToString();
            txtTenNhaCungCap.Enabled = false; //Chặn sửa

            txtDiaChi.Text = ncc.Diachincc.ToString();
            txtDiaChi.Enabled = false; // Chặn sửa

            txtSoDienThoai.Text = ncc.Sdt.ToString();
            txtSoDienThoai.Enabled = false; //Chặn sửa

            txtEmail.Text = ncc.Email.ToString();
            txtEmail.Enabled = false; //Chặn sửa
        }



        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailNhaCungCapForm_Shown(object sender, EventArgs e)
        {
            txtTenNhaCungCap.SelectionLength = 0; // Chặn bị bôi đen khi mở form
            txtDiaChi.SelectionLength = 0;
            txtSoDienThoai.SelectionLength = 0;
            txtEmail.SelectionLength = 0;
        }

    }
}
