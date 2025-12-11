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

namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    public partial class AddKhuVucForm : Form
    {
        KhuVucKhoBUS kvkBUS = new KhuVucKhoBUS();

        public AddKhuVucForm()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Sửa: dùng Cancel thay vì OK
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtTenKhuVucKho.Text.Length > 0)
            {
                string tenKVK = txtTenKhuVucKho.Text.Trim();

                


                if(tenKVK.Length == 0)
                {
                    MessageBox.Show(
                        "Tên khu vực kho không được để trống!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                     );
                    return;
                }

                KhuVucKhoDTO kvkInsert = new KhuVucKhoDTO(
                    kvkBUS.getAutoMaKVK(),
                    tenKVK, null, null, null
                );

                if (kvkBUS.insertKhuVuc(kvkInsert))
                {
                    MessageBox.Show(
                        "Thêm khu vực kho thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Thêm khu vực kho thất bại!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            else
            {
                MessageBox.Show(
                        "Tên khu vực kho không được để trống!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
            }
        }
    }
}
