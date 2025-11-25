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
    public partial class ThongKeTheoQuy : UserControl
    {
        public ThongKeTheoQuy()
        {
            InitializeComponent();
        }

        public void load_UC(object sender, EventArgs e)
        {
            chonNam.Format = DateTimePickerFormat.Custom;
            chonNam.CustomFormat = "yyyy";
            chonNam.ShowUpDown = true;

            cboChonQuy.Items.Clear();
            cboChonQuy.Items.Add("Quý 1");
            cboChonQuy.Items.Add("Quý 2");
            cboChonQuy.Items.Add("Quý 3");
            cboChonQuy.Items.Add("Quý 4");
        }
    }
}
