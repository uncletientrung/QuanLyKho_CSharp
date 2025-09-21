using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class PhieuNhapGUI : Form
    {
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private BindingList<PhieuNhapDTO> listPN;

        public PhieuNhapGUI()
        {
            InitializeComponent();

            // Load dữ liệu
            listPN = pnBUS.getListPN();


        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            // Code khi form load
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Code vẽ panel
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Code khi text thay đổi
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Code vẽ table layout
        }

        private void txtNhanVien_Enter(object sender, EventArgs e)
        {

        }

        private void txtNhanVien_Leave(object sender, EventArgs e)
        {

        }

        private void txtNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}