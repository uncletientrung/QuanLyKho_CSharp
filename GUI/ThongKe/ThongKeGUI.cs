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
            SetActiveButton(btnTongQuan);

        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCTonKho());
            SetActiveButton(btnTonKho);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCDoanhThu());
            SetActiveButton(btnDoanhThu);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCNhaCungCap());
            SetActiveButton(btnNhaCungCap);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new UCKhachHang());
            SetActiveButton(btnKhachHang);
        }

        private Button currentButton = null; 
        private void SetActiveButton(Button btn)
        {

            foreach (Control control in menuTable.Controls) // duyet qua tung nut
            {
                if (control is Button b)
                {
                    b.BackColor = Color.White; // Màu nền mặc định
                    b.ForeColor = Color.Black; // Màu chữ mặc định
                    b.Font = new Font(b.Font, FontStyle.Regular);
                }
            }


            btn.BackColor = Color.Silver; 
            btn.ForeColor = Color.Black;
            btn.Font = new Font(btn.Font, FontStyle.Bold);

            currentButton = btn;
        }

    }
}
