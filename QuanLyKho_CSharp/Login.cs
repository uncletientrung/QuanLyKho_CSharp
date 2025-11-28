using QuanLyKho.BUS;
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
using ComponentFactory.Krypton.Toolkit;

namespace QuanLyKho_CSharp.GUI
{
    public partial class Login : KryptonForm
    {
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private BindingList<TaiKhoanDTO> listTK;
        private static TaiKhoanDTO tkLogin;
        public TaiKhoanDTO getTkLogin()
        {
            return tkLogin;
        }
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = kryptonButton1;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listTK = tkBUS.getListTK();
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            //string user = "admin";
            //string pass = "12345";
            foreach (TaiKhoanDTO tk in listTK)
            {
                if (user.Equals(tk.Tendangnhap) && pass.Equals(tk.Matkhau))
                {
                    this.DialogResult = DialogResult.OK;
                    tkLogin = tk;
                    this.Close();
                    return;

                }
            }
            if (this.DialogResult != DialogResult.OK)
            {
                MessageBox.Show(
                    "Sai tài khoản hoặc mật khẩu!",
                    "Thông tin đăng nhập sai",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint_1(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            int borderWidth = 5;             // Độ dày viền
            Color borderColor = Color.FromArgb(0, 117, 214);  // Màu viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}
