using QuanLyKho_CSharp.GUI.PhieuXuat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper
{
    public partial class ToastForm : Form
    {
        int toastX, toastY;
        public ToastForm(string type, string message)
        {
            InitializeComponent();
            lbType.Text = type;
            lbMessage.Text = message;
            string path;
            switch (type)
            {

                case "SUCCESS":
                    toastBorder.BackColor = Color.FromArgb(57, 155, 53);
                    path = Path.Combine(Application.StartupPath,
                        "images",
                        "icon",
                        "insert_success.png");
                    picIcon.Image = AddPhieuXuatForm.LoadImageSafe(path);
                    break;
                case "ERROR":
                    toastBorder.BackColor = Color.FromArgb(227, 50, 45);
                    path = Path.Combine(Application.StartupPath,
                        "images",
                        "icon",
                        "insert_success.png");
                    picIcon.Image = AddPhieuXuatForm.LoadImageSafe(path);
                    break;
                case "INFO":
                    toastBorder.BackColor = Color.FromArgb(18, 136, 191);
                    path = Path.Combine(Application.StartupPath,
                       "images",
                       "icon",
                       "insert_success.png");
                    picIcon.Image = AddPhieuXuatForm.LoadImageSafe(path);
                    break;
                case "WARNING":
                    path = Path.Combine(Application.StartupPath,
                        "images",
                        "icon",
                        "insert_success.png");
                    picIcon.Image = AddPhieuXuatForm.LoadImageSafe(path);
                    toastBorder.BackColor = Color.FromArgb(245, 171, 35);
                    break;
            }
        }

        private void ToastForm_Load(object sender, EventArgs e)
        {
            Position();
        }
        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastY -= 10;
            this.Location = new Point(toastX, toastY);
            if (toastY <= 760)
            {
                toastTimer.Stop();
                toastHide.Start();
            }
        }
        int y = 100;
        private void toastHide_Tick(object sender, EventArgs e)
        {
            y--;
            if (y <= 0)
            {
                toastY += 1;
                this.Location = new Point(toastX, toastY += 10);
                if (toastY > 800)
                {
                    toastHide.Stop();
                    y = 100;
                    this.Close();
                }
            }
        }

        private void Position()
        {

            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = ScreenWidth - this.Width - 10;
            toastY = ScreenHeight - this.Height ;

            this.Location = new Point(toastX, toastY);

        }
    }
}
