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

            // Giảm nhấp nháy (optional)
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Gọi sau khi form đã render kích thước thật
            ApplyRoundAll(5);
        }

        // Nếu bạn muốn bo lại khi thay đổi kích thước nút (hiếm khi cần)
        private void ReHookResize(Button btn, int radius)
        {
            btn.Resize -= Button_Resize;
            btn.Resize += Button_Resize;
            void Button_Resize(object s, EventArgs ev) => ApplyRoundedRegion(btn, radius);
        }

        private void ApplyRoundAll(int radius)
        {
            // Giả sử bạn có 5 nút: button1..button5 trên Designer
            SetRoundedButton(btnNhaCungCap, 10);
            SetRoundedButton(btnChatLieu, 10);
            SetRoundedButton(btnKhuVuc, 10);
            SetRoundedButton(btnLoai, 10);
            SetRoundedButton(btnSize, 10);
        }

        private void SetRoundedButton(Button btn, int radius)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false; // để màu BackColor hiển thị

            ApplyRoundedRegion(btn, radius);
            ReHookResize(btn, radius);
        }

        private void ApplyRoundedRegion(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;

            int d = radius * 2;
            Rectangle rect = ctrl.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = new GraphicsPath())
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

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            NhaCungCap frm = new NhaCungCap();
            frm.Show();
            this.Hide();
        }
    }
}
