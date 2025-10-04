using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI
{
    public partial class Login : Form
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
            this.AcceptButton = btnLogin;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listTK = tkBUS.getListTK();
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
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
    }
}
