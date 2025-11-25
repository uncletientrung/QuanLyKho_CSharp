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

namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    public partial class AddSizeForm : Form
    {
        private SizeBUS sizeBUS = new SizeBUS();
        public AddSizeForm()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtTenSize.Text.Length > 0)
            {
                string tenSize = txtTenSize.Text.Trim();
                string ghiChu = txtGhiChu.Text.Trim();

                SizeDTO newSize = new QuanLyKho.DTO.SizeDTO
                {
                    Tensize = tenSize,
                    Ghichu = ghiChu
                };

                if (sizeBUS.insertSize(newSize))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                        MessageBox.Show(
                            "Thêm Size thất bại! Vui lòng kiểm tra lại dữ liệu hoặc kết nối cơ sở dữ liệu.",
                            "Lỗi thêm Size",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
            }
            else
            {
                        MessageBox.Show(
                            "Tên Size không được để trống!",
                            "Lỗi dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
            }
        }
    }
}
