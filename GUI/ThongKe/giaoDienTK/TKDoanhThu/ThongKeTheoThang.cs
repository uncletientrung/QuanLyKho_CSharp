using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.UninterpretedOption.Types;

namespace QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK.TKDoanhThu
{
    public partial class ThongKeTheoThang : UserControl
    {
        public ThongKeTheoThang()
        {
            InitializeComponent();
        }

        public void load_UC(object sender, EventArgs e)
        {
            chonNam.Format = DateTimePickerFormat.Custom;
            chonNam.CustomFormat = "yyyy";
            chonNam.ShowUpDown = true; // Dạng spinbox (không hiển thị lịch)
            

        }
    }
}
