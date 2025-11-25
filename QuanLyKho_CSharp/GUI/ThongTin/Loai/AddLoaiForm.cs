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

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class AddLoaiForm : Form
    {
        private LoaiBUS loaiBUS = new LoaiBUS();

        public AddLoaiForm()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text.Length > 0)
            {
                string tenLoai = txtTenLoai.Text.Trim();
                if (loaiBUS.insertLoai(new QuanLyKho.DTO.LoaiDTO { Tenloai = tenLoai }))
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
    }
}
