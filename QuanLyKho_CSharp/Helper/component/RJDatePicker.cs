using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper.component
{
    public class RJDatePicker : DateTimePicker
    {
        // Fields
        private Color _skinColor = Color.FromArgb(17, 155, 248); // Xanh dương đẹp
        private Color _textColor = Color.White;
        private Color _borderColor = Color.PaleVioletRed;
        private int _borderSize = 0;

        private bool _droppedDown = false;
        private Image _calendarIcon;

        private const int IconWidth = 34;
        private Rectangle _iconButtonArea;

        // Properties
        public Color SkinColor
        {
            get => _skinColor;
            set { _skinColor = value; this.Invalidate(); }
        }

        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; this.Invalidate(); }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; this.Invalidate(); }
        }

        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = value; this.Invalidate(); }
        }

        // Constructor
        public RJDatePicker()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.MinimumSize = new Size(100, 35);
            this.Font = new Font("Segoe UI", 10F);
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd/MM/yyyy";

            LoadCalendarIcon();
        }

        private void LoadCalendarIcon()
        {
            try
            {
                // Cách 1: Dùng embedded resource (tốt nhất)
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var resourceName = "QuanLyKho_CSharp.images.calendarWhite.png"; // phải set Build Action = Embedded Resource
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                        _calendarIcon = Image.FromStream(stream);
                }
            }
            catch { }

            // Cách 2: Nếu không dùng embedded → tìm trong thư mục chạy
            if (_calendarIcon == null)
            {
                string path = System.IO.Path.Combine(Application.StartupPath, "images", "calendarWhite.png");
                if (System.IO.File.Exists(path))
                    _calendarIcon = Image.FromFile(path);
            }

            // Cách 3: Dự phòng - vẽ icon bằng code nếu không có file
            if (_calendarIcon == null)
                _calendarIcon = CreateCalendarIcon();
        }

        private Image CreateCalendarIcon()
        {
            Bitmap bmp = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen p = new Pen(Color.White, 2))
                {
                    g.DrawRectangle(p, 4, 4, 16, 16);
                    g.DrawLine(p, 8, 2, 8, 6);
                    g.DrawLine(p, 16, 2, 16, 6);
                }
            }
            return bmp;
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            _droppedDown = true;
            this.Invalidate();
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            _droppedDown = false;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle iconRect = new Rectangle(this.Width - IconWidth, 0, IconWidth, this.Height);

            // Background
            using (SolidBrush brush = new SolidBrush(_skinColor))
                g.FillRectangle(brush, rect);

            // Highlight khi mở dropdown
            if (_droppedDown)
            {
                using (SolidBrush highlight = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                    g.FillRectangle(highlight, iconRect);
            }

            // Text
            TextRenderer.DrawText(
                g,
                " " + this.Text,
                this.Font,
                new Rectangle(8, 0, this.Width - IconWidth - 8, this.Height),
                _textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            // Border
            if (_borderSize > 0)
            {
                using (Pen pen = new Pen(_borderColor, _borderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    g.DrawRectangle(pen, rect);
                }
            }

            // Calendar Icon
            if (_calendarIcon != null)
            {
                int iconX = this.Width - IconWidth + (IconWidth - _calendarIcon.Width) / 2;
                int iconY = (this.Height - _calendarIcon.Height) / 2;
                g.DrawImage(_calendarIcon, iconX, iconY);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _iconButtonArea = new Rectangle(this.Width - IconWidth, 0, IconWidth, this.Height);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.Cursor = _iconButtonArea.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _calendarIcon?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}