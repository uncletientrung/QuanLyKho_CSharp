using QuanLyKho.BUS;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class UpdateChatLieuForm : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private ChatLieuDTO cl;

        public UpdateChatLieuForm(ChatLieuDTO _cl)
        {
            this.cl = _cl;
            InitializeComponent();
        }

        private void UpdateChatLieuForm_Load(object sender, EventArgs e)
        {
            txtTenChatLieu.Text = cl.Tenchatlieu.ToString();
        }

        private void UpdateChatLieuForm_Shown(object sender, EventArgs e)
        {
            txtTenChatLieu.SelectionLength = 0; // Chặn bị bôi đen khi mở form
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenChatLieu.Text.Length > 0)
            {
                string tenCL = txtTenChatLieu.Text.Trim();
                if (clBUS.updateChatLieu(new QuanLyKho.DTO.ChatLieuDTO { Machatlieu = cl.Machatlieu, Tenchatlieu = tenCL }))
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật chất liệu thất bại! Vui lòng kiểm tra lại dữ liệu",
                        "Lỗi cập nhật chất liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                     );
                }
            }
        }

        
    }
}
