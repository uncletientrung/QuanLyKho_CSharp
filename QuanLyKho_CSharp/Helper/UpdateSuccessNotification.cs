using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper
{
    public class UpdateSuccessNotification : Form
    {
        private Timer timer;
        private ProgressBar progressBar;
        private int timeShown = 1000; // tổng thời gian hiển thị (ms)
        private int elapsed = 0;      // thời gian đã trôi qua
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
        public UpdateSuccessNotification()
        {
            // Cấu hình form nhỏ
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(255, 193, 7);
            this.Size = new Size(300, 70);
            this.TopMost = true;
            this.ForeColor = Color.White;

            // Vị trí (góc dưới phải)
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int y = 24; // cách trên 10px
            this.Location = new Point(x, y);

            // Label
            Label lbl = new Label();
            lbl.Text = "SỬA THÀNH CÔNG";
            lbl.Dock = DockStyle.Fill;
            lbl.Height = 30;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lbl);

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
    }
}
