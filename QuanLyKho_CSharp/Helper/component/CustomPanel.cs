using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper.component
{
    internal class CustomPanel : Panel
    {
        public Color mauTren { get; set; }
        public Color mauDuoi { get; set; }

        public CustomPanel() {
            this.Resize += CustomPanel_Resize;
        }
        private void CustomPanel_Resize(object sender, EventArgs e) {
            this.Invalidate();
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush linear =new LinearGradientBrush(
                this.ClientRectangle,
                this.mauTren,
                this.mauDuoi,
                90F
                );
            Graphics g= e.Graphics;
            g.FillRectangle(linear, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
