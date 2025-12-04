using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper
{
    public class AddSuccessNotification : Form
    {
        private Timer timer;
        private ProgressBar progressBar;
        private int timeShown = 1000; // tổng thời gian hiển thị (ms)
        private int elapsed = 0;      // thời gian đã trôi qua
        public AddSuccessNotification()
        {
            // Cấu hình form nhỏ
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(255,255,255);
            this.Size = new Size(300, 70);
            this.TopMost = true;
            this.ForeColor=Color.WhiteSmoke;

            // Vị trí (góc dưới phải)
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int toastX = ScreenWidth - this.Width - 10;
            int toastY = ScreenHeight - this.Height +16;

            this.Location = new Point(toastX, toastY);

            // Label
            Label lbl = new Label();
            lbl.Text = "THÊM THÀNH CÔNG";
            lbl.Dock = DockStyle.Fill;
            lbl.Height = 30;
            lbl.BackColor = Color.White; // nền trắng
            lbl.ForeColor = Color.FromArgb(57, 155, 53); // chữ xanh
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lbl);

            // Panel màu xanh bên trái
            Panel leftBorder = new Panel();
            leftBorder.Dock = DockStyle.Left;
            leftBorder.Width = 8;
            leftBorder.BackColor = Color.FromArgb(57, 155, 53);
            this.Controls.Add(leftBorder);


            // ProgressBar (thanh tua ngược)
            progressBar = new ProgressBar();
            progressBar.Dock = DockStyle.Bottom;
            progressBar.Height = 10;
            progressBar.Maximum = timeShown;
            progressBar.Value = timeShown;
            progressBar.Style = ProgressBarStyle.Continuous;
            this.Controls.Add(progressBar);

            // Timer
            timer = new Timer();
            timer.Interval = 10; // cập nhật mỗi 0.01 giây
            timer.Tick += Timer_Tick;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ viền đen 1px
            using (Pen pen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsed += timer.Interval;
            progressBar.Value = Math.Max(0, timeShown - elapsed);

            if (elapsed >= timeShown)
            {
                timer.Stop();
                this.Close();
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Start();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AddSuccessNotification
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSuccessNotification";
            this.Load += new System.EventHandler(this.NotificationSuccessful_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddSuccessNotification_Paint);
            this.ResumeLayout(false);

        }

        private void NotificationSuccessful_Load(object sender, EventArgs e)
        {

        }

        private void AddSuccessNotification_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
