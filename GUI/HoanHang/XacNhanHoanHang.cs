using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.HoanHang
{
    public partial class XacNhanHoanHang : Form
    {
        public XacNhanHoanHang()
        {
            InitializeComponent();
        }

        // chỉ đọc
        private void lbInfo_Click(object sender, EventArgs e) {}

        private void label1_Click(object sender, EventArgs e) {}

        // nút hoàn hàng
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Xử lý xác nhận hoàn hàng ở đây

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void XacNhanHoanHang_Load(object sender, EventArgs e)
        {

        }
    }
}
