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
using System.Xml.Linq;

namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class UpdateNhaCungCapForm : Form
    {
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private NhaCungCapDTO ncc;
        public UpdateNhaCungCapForm(NhaCungCapDTO _ncc)
        {
            this.ncc=_ncc;
            InitializeComponent();
        }

        public void UpdateNhaCungCapForm_Load(object sender, EventArgs e)
        {
            txtTenNhaCungCap.Text = ncc.Tenncc.ToString();
            txtSoDienThoai.Text = ncc.Sdt.ToString();    
            txtDiaChi.Text= ncc.Diachincc.ToString();
            txtEmail.Text= ncc.Email.ToString();
        }

        private void UpdateNhanVienForm_Shown(object sender, EventArgs e)
        {
            txtTenNhaCungCap.SelectionLength = 0; // Chặn bị bôi đen khi mở form
            txtSoDienThoai.SelectionLength = 0;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtTenNhaCungCap.Text.Length > 0)
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
                }
                else
                {
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
                    }
                    else
                    {
                        ncc.Tenncc = txtTenNhaCungCap.Text;
                        ncc.Sdt = txtSoDienThoai.Text;
                        ncc.Diachincc = txtDiaChi.Text;
                        ncc.Email = txtEmail.Text;
                        Boolean result = nccBUS.updateNhaCungCap(ncc);
                        if (result)
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Cập nhật thông tin nhà cung cấp thất bại!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(
                         "Vui lòng nhập tên nhà cung cấp!",
                         "Lỗi dữ liệu",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                     );
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
