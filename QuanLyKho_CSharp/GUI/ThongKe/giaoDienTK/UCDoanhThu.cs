using QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    public partial class UCDoanhThu : UserControl
    {
        public UCDoanhThu()
        {
            InitializeComponent();
        }


        private void ShowGiaoDien(UserControl uc)
        {
            panelThongKeBody.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelThongKeBody.Controls.Add(uc);
        }

        private void btnTKTheoNam_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new ThongKeTheoNam());
            SetActiveButton(btnTKTheoNam);
        }

        private void btnThongKeTheoQuy_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new ThongKeTheoQuy());
            SetActiveButton(btnThongKeTheoQuy);
        }

        private void btnThongKeTheoThang_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new ThongKeTheoThang());
            SetActiveButton(btnThongKeTheoThang);
        }

        private void btnThongKeTheoNgay_Click(object sender, EventArgs e)
        {
            ShowGiaoDien(new ThongKeTungNgayTrongThang());
            SetActiveButton(btnThongKeTheoNgay);
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
