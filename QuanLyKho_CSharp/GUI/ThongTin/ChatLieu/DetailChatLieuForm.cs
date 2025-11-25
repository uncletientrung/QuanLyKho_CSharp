using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class DetailChatLieuForm : Form
    {
        ChatLieuDTO cl;

        public DetailChatLieuForm(ChatLieuDTO _cl)
        {
            this.cl = _cl;
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailChatLieuForm_Load(object sender, EventArgs e)
        {
            txtTenChatLieu.Text = cl.Tenchatlieu.ToString();
            txtTenChatLieu.Enabled = false; //Chặn sửa
        }

        private void DetailChatLieuForm_Shown(object sender, EventArgs e)
        {
            txtTenChatLieu.SelectionLength = 0;
        }

        private void txtTenChatLieu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
