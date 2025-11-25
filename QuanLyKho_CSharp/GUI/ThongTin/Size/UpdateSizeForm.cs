using System;
using System.Collections.Generic;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    public partial class UpdateSizeForm : Form
    {
        private SizeBUS sizeBUS = new SizeBUS();
        private SizeDTO size;

        public UpdateSizeForm(SizeDTO _size)
        {
            this.size = _size;
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenSize = txtTenSize.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();

            // Kiểm tra dữ liệu trước khi xử lý
            if (string.IsNullOrEmpty(tenSize))
            {
                MessageBox.Show(
                    "Tên Size không được để trống!",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            SizeDTO newSize = new SizeDTO
            {
                Masize = size.Masize, 
                Tensize = tenSize,
                Ghichu = ghiChu
            };
            bool result = sizeBUS.updateSize(newSize); 

            if (result)
            {
                MessageBox.Show(
                    "Lưu Size thành công!",
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
                    "Lưu Size thất bại! Vui lòng kiểm tra lại dữ liệu hoặc kết nối cơ sở dữ liệu.",
                    "Lỗi lưu Size",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void UpdateSizeForm_Shown(object sender, EventArgs e)
        {
            txtTenSize.SelectionLength = 0;
            txtGhiChu.SelectionLength = 0;
        }

        private void UpdateSizeForm_Load(object sender, EventArgs e)
        {
            txtTenSize.Text = size.Tensize.ToString();
            txtGhiChu.Text = size.Ghichu.ToString();
        }
    }
}
