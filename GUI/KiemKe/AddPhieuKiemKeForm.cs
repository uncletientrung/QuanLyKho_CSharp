using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class AddPhieuKiemKeForm : Form
    {
        private readonly string SearchPlaceholder = "Tìm kiếm theo mã sản phẩm, tên sản phẩm, nhà cung cấp, ...";

        public AddPhieuKiemKeForm()
        {
            InitializeComponent();
        }



        // load form
        private void AddPhieuKiemKeForm_Load(object sender, EventArgs e)
        {
            txSearch.ForeColor = Color.Gray;
            txSearch.Text = SearchPlaceholder;
            txSearch.GotFocus += txSearch_Enter;
            txSearch.LostFocus += txSearch_Leave;
        }





        // thanh search
        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == SearchPlaceholder)
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }
        private void txSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txSearch.Text))
            {
                txSearch.Text = SearchPlaceholder;
                txSearch.ForeColor = Color.Gray;
            }
        }
        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text == "")
            {
                txSearch.ForeColor = Color.Gray;
                txSearch.Text = SearchPlaceholder;
                txSearch.SelectionStart = 0;
                txSearch.SelectionLength = 0;
            }
            else
            {
                txSearch.ForeColor = Color.Black;
            }
        }




















        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
