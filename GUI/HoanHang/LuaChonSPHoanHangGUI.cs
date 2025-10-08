using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyKho_CSharp.GUI.HoanHang
{
    public partial class LuaChonSPHoanHang : Form
    {
        public LuaChonSPHoanHang()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // chỉ đọc
        private void label1_Click(object sender, EventArgs e) { }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LuaChonSPHoanHang_Load(object sender, EventArgs e)
        {
            // Gán placeholder ban đầu
            textBox1.Text = "Tìm kiếm sản phẩm đã mua";
            textBox1.ForeColor = Color.Gray;

            // Gắn sự kiện Enter + Leave cho TextBox
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện khi focus/bỏ focus vào TextBox
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tìm kiếm sản phẩm đã mua")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Tìm kiếm sản phẩm đã mua";
                textBox1.ForeColor = Color.Gray;
            }
        }
    }
}
