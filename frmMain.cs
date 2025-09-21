using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.TaiKhoan;
using QuanLyKho_CSharp.GUI.PhanQuyen;
using QuanLyKho_CSharp.GUI.PhieuNhap;
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
        private Form currentFormChild;// Biến giữ form con hiện tại

        private Button currentButton; //biến giữ button hiện tại

        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, Button btn)
        {
            //  Nếu form hiện tại cùng loại và cùng button -> Không làm gì
            if (currentFormChild != null
                && currentFormChild.GetType() == childForm.GetType()
                && currentButton == btn)
            {
                // Đang ở đúng form đó, không cần reload
                return;
            }

            // Đóng form cũ
            if (currentFormChild != null)
            {
                this.pnlBody.Controls.Clear();
                currentFormChild.Close();
                currentFormChild.Dispose();
            }

            // Xoá panel và thêm form mới
            pnlBody.Controls.Clear();
            currentFormChild = childForm;
            currentButton = btn; // Cập nhật nút hiện tại

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(childForm);
            pnlBody.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

            // Reset màu các nút và tô sáng nút đang chọn
            ResetButton();
            btn.BackColor = Color.DodgerBlue;
            btn.ForeColor = Color.White;

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

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuNhapGUI(), btnPhieuNhap);
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

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhomQuyenGUI(), btnPhanQuyen);
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}