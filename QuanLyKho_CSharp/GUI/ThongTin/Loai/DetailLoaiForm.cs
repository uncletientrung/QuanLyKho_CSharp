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

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class DetailLoaiForm : Form
    {
        LoaiDTO loai;
        public DetailLoaiForm(LoaiDTO _loai)
        {
            this.loai = _loai;
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void DetailLoaiForm_Load(object sender, EventArgs e)
        {
            txtTenLoai.Text = loai.Tenloai.ToString();
            txtTenLoai.Enabled = false;
        }

        private void DetailLoaiForm_Shown(object sender, EventArgs e)
        {
            txtTenLoai.SelectionLength = 0;
        }
    }
}
