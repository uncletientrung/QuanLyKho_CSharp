using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper
{
    public class ScreenSize
    {
        private static int width;
        private static int height;
        public static int Width
        {
            get { return width = Screen.PrimaryScreen.Bounds.Width; }
            set { width = value; }
        }
        public static int Height
        {
            get { return height = Screen.PrimaryScreen.Bounds.Height; }
            set { height = value; }
        }
    }
}
