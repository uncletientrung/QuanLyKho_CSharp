using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
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
            if (txtTenKhuVucKho.Text.Length > 0)
            {
                string sdt = txtSoDienThoai.Text.Trim();
                string pattern = @"^(0|\+84)(3[2-9]|5[2-9]|7[0|6-9]|8[1-9]|9[0-9])[0-9]{7}$";
                if (!Regex.IsMatch(sdt, pattern))
                {
                    MessageBox.Show(
                             "Số điện thoại không hợp lệ!",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
                    return; // Thêm return để dừng execution
                }

                string email = txtEmail.Text.Trim();
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, emailPattern) && email.Length > 0)
                {
                    MessageBox.Show(
                             "Email không hợp lệ!",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
                    return; // Thêm return để dừng execution
                }

                // Cập nhật thông tin
                kvk.Tenkhuvuc = txtTenKhuVucKho.Text.Trim();
                kvk.Sdt = txtSoDienThoai.Text.Trim();
                kvk.Diachi = txtDiaChi.Text.Trim();
                kvk.Email = txtEmail.Text.Trim();
                
                Boolean result = kvkBUS.updateKhuVuc(kvk);
                if (result)
                {
                    MessageBox.Show(
                        "Cập nhật thông tin khu vực kho thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    this.DialogResult = DialogResult.OK; // Thêm DialogResult.OK
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
            else
            {
                MessageBox.Show(
                         "Vui lòng nhập tên khu vực kho!",
                         "Lỗi dữ liệu",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                     );
            }
        }

        private void UpdateKhuVucForm_Load(object sender, EventArgs e)
        {
            txtTenKhuVucKho.Text = kvk.Tenkhuvuc.ToString();
            txtSoDienThoai.Text = kvk.Sdt.ToString();
            txtDiaChi.Text = kvk.Diachi.ToString();
            txtEmail.Text = kvk.Email.ToString();
        }

        private void UpdateKhuVucKhoForm_Shown(object sender, EventArgs e)
        {
            txtTenKhuVucKho.SelectionLength = 0; // Chặn bị bôi đen khi mở form
            txtSoDienThoai.SelectionLength = 0;
            txtDiaChi.SelectionLength = 0;
            txtEmail.SelectionLength = 0;
        }
    }
}
