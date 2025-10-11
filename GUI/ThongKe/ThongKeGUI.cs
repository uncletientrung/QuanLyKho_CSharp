using QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.ThongKe
{
    public partial class ThongKeGUI : Form
    {
        public ThongKeGUI()
        {
            InitializeComponent();
        }

        private void ThongKeGUI_Load(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCTongQuan());
        }
        private void ShowGiaoDien(UserControl uc)
        {
            pnlContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCTongQuan());
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCTonKho());
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCDoanhThu());
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCNhaCungCap());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCKhachHang());
        }
    }
}
