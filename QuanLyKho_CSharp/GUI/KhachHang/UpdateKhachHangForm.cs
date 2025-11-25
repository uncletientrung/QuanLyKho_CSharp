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

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class UpdateKhachHangForm : Form
    {
        private KhachHangBUS khBUS = new KhachHangBUS();
        private KhachHangDTO kh;

        public UpdateKhachHangForm(KhachHangDTO _kh)
        {
            this.kh = _kh;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
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

                string sdt = txtSDT.Text.Trim();
                string email = txtEmail.Text.Trim();

                string phonePattern = @"^(0|\+84)(3[2-9]|5[2-9]|7[0|6-9]|8[1-9]|9[0-9])[0-9]{7}$";
                string emailPattern = @"^[\w\.-]+@([\w-]+\.)+[\w-]{2,4}$";

                if (sdt.Length == 0)
                {
                    MessageBox.Show(
                        "Số điện thoại không được để trống!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

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

                if (email.Length == 0)
                {
                    MessageBox.Show(
                        "Email không được để trống!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

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

                // Tạo đối tượng khách hàng để cập nhật
                KhachHangDTO khUpdate = new KhachHangDTO(
                    kh.Makh,                 // mã khách hàng hiện tại
                    txtName.Text,            // họ tên
                    email,                   // email
                    birthday,                     // số điện thoại
                    sdt,                // ngày sinh
                    1                        // trạng thái hoạt động
                );

                khBUS.updateKhachHang(khUpdate);
                this.DialogResult = DialogResult.OK; // đánh dấu cập nhật thành công
            }
            else
            {
                MessageBox.Show(
                    "Họ và Tên không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateKhachHangForm_Load(object sender, EventArgs e)
        {
            txtName.Text = kh.Tenkhachhang.ToString();
            txtSDT.Text = kh.Sdt.ToString();
            txtEmail.Text = kh.Email.ToString();
            dtpDate.Text = kh.Ngaysinh.Date.ToString();
        }

        private void UpdateKhachHang_Shown(object sender, EventArgs e)
        {
            txtName.SelectionLength = 0;
            txtSDT.SelectionLength = 0;
            txtEmail.SelectionLength = 0;
        }
    }
}
