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

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class UpdateLoaiForm : Form
    {
        private LoaiBUS loaiBUS = new LoaiBUS();
        private LoaiDTO loai;

        public UpdateLoaiForm(LoaiDTO _loai)
        {
            this.loai = _loai;
            InitializeComponent();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text.Length > 0)
            {
                string tenLoaiMoi = txtTenLoai.Text.Trim();

                // Kiểm tra nếu không có thay đổi gì
                if (tenLoaiMoi.Equals(loai.Tenloai, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Tên loại không thay đổi. Vui lòng nhập tên khác để cập nhật.",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // Tạo đối tượng mới để cập nhật
                LoaiDTO loaiCapNhat = new LoaiDTO
                {
                    Maloai = loai.Maloai,
                    Tenloai = tenLoaiMoi
                };

                // Gọi BUS cập nhật
                if (loaiBUS.updateLoai(loaiCapNhat))
                {
                    MessageBox.Show(
                        "Cập nhật loại thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật loại thất bại! Vui lòng kiểm tra lại dữ liệu.",
                        "Lỗi cập nhật loại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Tên loại không được để trống.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateLoaiForm_Load(object sender, EventArgs e)
        {
            txtTenLoai.Text = loai.Tenloai.ToString();
        }

        private void UpdateLoaiForm_Shown(object sender, EventArgs e)
        {
            txtTenLoai.SelectionLength = 0;
        }
    }
}
