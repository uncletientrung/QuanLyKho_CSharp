using QuanLyKho_CSharp.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp
{
    public partial class frmMain : Form
    {
        private Form currentFormChild; // Biến giữ form con hiện tại
        public frmMain()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null) // Đóng form con hiện tại nếu đang mở
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm; // Gán current cho form được chọn
            childForm.TopLevel = false; // Để biến form con thành control nằm trong cha
                                        // Nếu để true thì nó sẽ bật ra thành cửa sổ
            childForm.FormBorderStyle = FormBorderStyle.None; // Đóng hộp - vuông X đi
            childForm.Dock = DockStyle.Fill; // Lắp đầy panel_Body
            pnlBody.Controls.Add(childForm); // Thêm form con vào panel_Body.Controls
            pnlBody.Tag = childForm; 
            childForm.BringToFront();
            childForm.Show(); // hiển thị form con
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {

        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Test_Connection());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVienGUI());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
