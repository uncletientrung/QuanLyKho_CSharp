using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    private int radius = 20;
    public int Radius
    {
        get { return radius; }
        set { radius = value; this.Invalidate(); } // vẽ lại khi đổi radius
    }

    public RoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = Color.LightBlue;
        this.ForeColor = Color.Black;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
        GraphicsPath path = GetRoundPath(rect, radius);

        // Set vùng hiển thị
        this.Region = new Region(path);

        // Vẽ nền
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            g.FillPath(brush, path);
        }

        // Vẽ border
        using (Pen pen = new Pen(Color.DarkBlue, 2))
        {
            g.DrawPath(pen, path);
        }

        // Vẽ text ở giữa
        TextRenderer.DrawText(
            g, this.Text, this.Font, rect,
            this.ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
        );
    }

    private GraphicsPath GetRoundPath(Rectangle rect, int radius)
    {
        int r2 = radius * 2;
        GraphicsPath path = new GraphicsPath();

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, r2, r2, 180, 90);
        path.AddArc(rect.Right - r2, rect.Y, r2, r2, 270, 90);
        path.AddArc(rect.Right - r2, rect.Bottom - r2, r2, r2, 0, 90);
        path.AddArc(rect.X, rect.Bottom - r2, r2, r2, 90, 90);
        path.CloseFigure();

        return path;
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            this.ResumeLayout(false);

    }
}
