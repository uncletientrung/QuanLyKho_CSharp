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

namespace QuanLyKho_CSharp.GUI.NhanVien
{
    public partial class DetailNhanVienForm : Form
    {
        NhanVienDTO nv;
        public DetailNhanVienForm(NhanVienDTO _nv)
        {
            this.nv = _nv;
            InitializeComponent();
        }

        private void DetailNhanVienForm_Load(object sender, EventArgs e)
        {
            txbName.Text = nv.Tennv.ToString();
            txbName.Enabled = false; //Chặn sửa

            dtpDate.Text = nv.Ngaysinh.Date.ToString();
            dtpDate.Enabled = false; // Chặn sửa

            txbPhone.Text=nv.Sdt.ToString();
            txbPhone.Enabled = false; //Chặn sửa

            if (nv.Gioitinh == 1) rbtnMale.Checked = true;
            rbtnMale.Enabled = false; // Chặn sửa
            if (nv.Gioitinh == 2) rbtnFemale.Checked = true;
            rbtnFemale.Enabled = false; // Chặn sửa
            if (nv.Gioitinh == 3) rbtnGay.Checked = true;
            rbtnGay.Enabled = false; // Chặn sửa

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailNhanVienForm_Shown(object sender, EventArgs e)
        {
            txbName.SelectionLength = 0; // Chặn bị bôi đen khi mở form
            txbPhone.SelectionLength = 0;

        }
    }
}
