using QuanLyKho.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK
{
    
        public partial class GUITongQuan : Form
        {
            private ThongKeBUS tkBUS = new ThongKeBUS();

            public GUITongQuan()
            {
                InitializeComponent();
            }

            private void ThongKeGUI_Load(object sender, EventArgs e)
            {
                
            }
        }
    
}
