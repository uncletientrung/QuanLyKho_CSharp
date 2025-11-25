using QuanLyKho.BUS;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class AddChatLieuForm : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        public AddChatLieuForm()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenChatLieu.Text.Length > 0)
            {
                string tenCL = txtTenChatLieu.Text.Trim();
                if (clBUS.insertChatLieu(new QuanLyKho.DTO.ChatLieuDTO { Tenchatlieu = tenCL }))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(
                        "Thêm chất liệu thất bại! Vui lòng kiểm tra lại dữ liệu",
                        "Lỗi thêm chất liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                     );
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
