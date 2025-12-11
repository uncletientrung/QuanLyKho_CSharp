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
    public partial class UpdateKhuVucForm : Form
    {
        private KhuVucKhoBUS kvkBUS = new KhuVucKhoBUS();
        private KhuVucKhoDTO kvk;

        public UpdateKhuVucForm(KhuVucKhoDTO _kvk)
        {
            this.kvk = _kvk;
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên khu vực kho không được để trống
            if (string.IsNullOrWhiteSpace(txtTenKhuVucKho.Text))
            {
                MessageBox.Show(
                         "Vui lòng nhập tên khu vực kho!",
                         "Lỗi dữ liệu",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                     );
                return;
            }



            // Cập nhật thông tin
            kvk.Tenkhuvuc = txtTenKhuVucKho.Text.Trim();
           
            
                        Boolean result = kvkBUS.updateKhuVuc(kvk);
                        if (result)
                        {
                            MessageBox.Show(
                    "Cập nhật thông tin khu vực kho thành công!",
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
                    "Cập nhật thông tin khu vực kho thất bại!",
                    "Lỗi",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                     );
            }
        }

        private void UpdateKhuVucForm_Load(object sender, EventArgs e)
        {
            txtTenKhuVucKho.Text = kvk.Tenkhuvuc.ToString();
        }

        private void UpdateKhuVucKhoForm_Shown(object sender, EventArgs e)
        {
            txtTenKhuVucKho.SelectionLength = 0; // Chặn bị bôi đen khi mở form
        }
    }
}
