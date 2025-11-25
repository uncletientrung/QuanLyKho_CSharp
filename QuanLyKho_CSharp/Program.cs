using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.GUI.NhomQuyen;
using QuanLyKho_CSharp.GUI.PhanQuyen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Application.Run(new testKryptonForm()); // Lười đăng nhập thì xài cái này
            while (true)
            {
                Login loginForm = new Login();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    frmMain mainForm = new frmMain(loginForm.getTkLogin());

                    if (mainForm.ShowDialog() == DialogResult.Abort)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break; // nếu thoát ở màn hình Login thì break luôn
                }
            }
        }
    }
}
