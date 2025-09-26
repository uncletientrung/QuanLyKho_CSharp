using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.ThongTin
{
    public partial class ThongTinGUI : Form
    {
        public ThongTinGUI()
        {
            InitializeComponent();

            // Đảm bảo cấu hình flow
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.AutoScroll = true;

            // Canh giữa nội dung khi hiển thị và khi đổi kích thước
            this.Shown += (s, e) => CenterFlowContents();
            flowLayoutPanel1.Resize += (s, e) => CenterFlowContents();
        }

        private void CenterFlowContents()
        {
            // Kích thước tối ưu để chứa 5 nút
            var pref = flowLayoutPanel1.GetPreferredSize(Size.Empty);

            int left = Math.Max(0, (flowLayoutPanel1.ClientSize.Width  - pref.Width)  / 2);
            int top  = Math.Max(0, (flowLayoutPanel1.ClientSize.Height - pref.Height) / 2);

            // Đặt padding trái/trên để nội dung nằm giữa (giữ phải/dưới = 0 để AutoScroll hoạt động)
            flowLayoutPanel1.Padding = new Padding(left, top, 0, 0);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Gọi sau khi form hiển thị để đảm bảo Button đã có kích thước
            SetRoundedButton(button1, 5);
            SetRoundedButton(button2, 5);
            SetRoundedButton(button3, 5);
            SetRoundedButton(button4, 5);
            SetRoundedButton(button5, 5);
        }

        // Bo tròn góc nút và tự cập nhật khi thay đổi kích thước
        private void SetRoundedButton(Button btn, int radius)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false; // để BackColor hiển thị đúng

            // tránh đăng ký trùng
            btn.Resize -= Button_RoundedResize;
            btn.Resize += Button_RoundedResize;

            ApplyRoundedRegion(btn, radius);

            void Button_RoundedResize(object s, EventArgs args)
            {
                ApplyRoundedRegion(btn, radius);
            }
        }

        private void ApplyRoundedRegion(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;

            int d = radius * 2;
            var rect = ctrl.ClientRectangle;
            rect.Width -= 1;  // giảm răng cưa mép
            rect.Height -= 1;

            using (var path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(rect.Left, rect.Top, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                ctrl.Region?.Dispose();
                ctrl.Region = new Region(path);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null) btn.BackColor = Color.LightPink;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null) btn.BackColor = Color.Pink; // Rời chuột: hồng mặc định
        }

        private void button5_Click(object sender, EventArgs e) { }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
