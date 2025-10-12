using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu
{
    public partial class ThongKeTheoNam : UserControl
    {
        public ThongKeTheoNam()
        {
            InitializeComponent();
        }

        public void load_UC(object sender, EventArgs e)
        {
            namStart.Format = DateTimePickerFormat.Custom;
            namStart.CustomFormat = "yyyy";
            namStart.ShowUpDown = true; // Dạng spinbox (không hiển thị lịch)
            namEnd.Format = DateTimePickerFormat.Custom;
            namEnd.CustomFormat = "yyyy";
            namEnd.ShowUpDown = true; // Dạng spinbox (không hiển thị lịch)

        }
    }
}
