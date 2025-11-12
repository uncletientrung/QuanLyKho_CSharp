using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyKho_CSharp
{
    public partial class Test_Connection : Form
    {
        public Test_Connection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string sql = "SELECT * FROM nhanvien";
            //    DataTable dt = ConnectionHelper.getDataTable(sql);
            //    dataGridView1.DataSource = dt;
            //    dataGridView1.AutoGenerateColumns = true;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void Test_Connection_Load(object sender, EventArgs e)
        {

        }
    }
}
