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

namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class AddNhaCungCapForm : Form
    {
        NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        public AddNhaCungCapForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtTenNhaCungCap.Text.Length > 0)
            {
                string tenNCC = txtTenNhaCungCap.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string sdt = txtSoDienThoai.Text.Trim();
                string email = txtEmail.Text.Trim();

                // Regex số điện thoại cơ bản (bạn có thể thay bằng regex VN như trong code nhân viên)
                string phonePattern = @"^(0|\+84)(3[2-9]|5[2-9]|7[0|6-9]|8[1-9]|9[0-9])[0-9]{7}$";

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

                else if(tenNCC.Length == 0)
                {
                    MessageBox.Show(
                        "Tên nhà cung cấp không được để trống!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                     );
                    return;
                }

                else if (!Regex.IsMatch(sdt, phonePattern))
                {
                    MessageBox.Show(
                        "Số điện thoại không hợp lệ!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                     );
                    return;
                }

                else if (email.Length > 0 && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show(
                        "Email không hợp lệ!",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                     );
                    return;
                }

                NhaCungCapDTO nccInsert = new NhaCungCapDTO(
                nccBUS.getAutoMaNCC(),  // mã NCC tự sinh
                tenNCC,
                diaChi,
                sdt,
                email,
                1                       // trạng thái mặc định = 1 (còn hoạt động)
            );

            if (nccBUS.insertNhaCungCap(nccInsert))
                {
                    MessageBox.Show(
                        "Thêm nhà cung cấp thông tin!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show(
                        "Thêm nhà thất bại!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddNhaCungCapForm_Load(object sender, EventArgs e)
        {

        }
    }
}
