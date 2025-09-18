using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.TaiKhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyKho_CSharp
{
    public partial class frmMain : Form
    {
        private Form currentFormChild; // Biến giữ form con hiện tại

        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, Button btn)
        {
            // Luôn đóng form hiện tại trước
            if (currentFormChild != null)
            {
                this.pnlBody.Controls.Clear();
                currentFormChild.Close();
                currentFormChild.Dispose(); // Giải phóng bộ nhớ
            }

            // Clear panel trước khi add form mới
            pnlBody.Controls.Clear();

            // Gán current cho form được chọn
            currentFormChild = childForm;

            // Cấu hình form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel
            pnlBody.Controls.Add(childForm);
            pnlBody.Tag = childForm;

            // Hiển thị form
            childForm.BringToFront();
            childForm.Show();

            // Reset button colors
            ResetButton();
            btn.BackColor = Color.DodgerBlue;
            btn.ForeColor = Color.White;

            // Force refresh layout
            pnlBody.PerformLayout();
            this.PerformLayout();
        }

        private void ResetButton()
        {
            foreach (Control ctrl in tablelayoutLeftmenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.Gainsboro;
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            
            OpenChildForm(new SanPhamGUI(), btnTonKho);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Test_Connection(), btnTrangChu);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangGUI(), btnKhachHang);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVienGUI(), btnNhanVien);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void avatar_Logout_Click(object sender, EventArgs e)
        {
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoanGUI(), btnTaiKhoan);
        }
    }
}