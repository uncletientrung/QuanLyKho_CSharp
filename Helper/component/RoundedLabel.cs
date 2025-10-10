using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper.component
{
    public class RoundedLabel : Label
    {
        public int BorderRadius { get; set; } = 15;
        public Color BorderColor { get; set; } = Color.Black;
        public int BorderSize { get; set; } = 2;
        public Color BackgroundColor { get; set; } = Color.White;

        public RoundedLabel()
        {
            AutoSize = false;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, BorderRadius - 1))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            using (SolidBrush brushSurface = new SolidBrush(BackgroundColor))
            {
                e.Graphics.FillPath(brushSurface, pathSurface);
                if (BorderSize > 0)
                    e.Graphics.DrawPath(penBorder, pathBorder);

                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rectSurface,
                    this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curve = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curve, curve, 180, 90);
            path.AddArc(rect.Right - curve, rect.Y, curve, curve, 270, 90);
            path.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curve, curve, curve, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
    }
