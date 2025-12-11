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

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class AddKhachHangForm : Form
    {
        private KhachHangBUS khBUS = new KhachHangBUS();

        public AddKhachHangForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên không được để trống
            if (string.IsNullOrWhiteSpace(txbName.Text))
            {
                MessageBox.Show(
                    "Họ và Tên không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Kiểm tra ngày sinh
            DateTime birthday = dtpDate.Value;
            if (birthday >= DateTime.Now.Date)
            {
                MessageBox.Show(
                    "Ngày sinh phải nhỏ hơn ngày hiện tại!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Validate số điện thoại
            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show(
                    "Số điện thoại không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Sử dụng pattern linh hoạt hơn cho số điện thoại
            string phonePattern = @"^(0|\+84)(3[2-9]|5[2-9]|7[0|6-9]|8[1-9]|9[0-9])[0-9]{7}$";
            if (!Regex.IsMatch(sdt, phonePattern))
            {
                MessageBox.Show(
                    "Số điện thoại không hợp lệ!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Validate email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Email không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show(
                    "Định dạng email không hợp lệ!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Tạo khách hàng mới
            KhachHangDTO khInsert = new KhachHangDTO(
                khBUS.getAutoMaKH(),
                txbName.Text.Trim(),
                email,
                birthday,
                sdt,
                1  // Trạng thái hoạt động
            );

            Boolean result = khBUS.insertKhachHang(khInsert);
            if (result)
            {
                MessageBox.Show(
                    "Thêm khách hàng thành công!",
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
                    "Thêm khách hàng thất bại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
