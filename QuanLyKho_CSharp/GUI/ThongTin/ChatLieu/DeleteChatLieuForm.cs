using QuanLyKho.BUS;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class DeleteChatLieuForm : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private ChatLieuDTO cl;

        public DeleteChatLieuForm(ChatLieuDTO _cl)
        {
            this.cl = _cl;
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clBUS.removeChatLieu(cl.Machatlieu);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
