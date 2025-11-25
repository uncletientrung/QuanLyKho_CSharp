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

namespace QuanLyKho_CSharp.GUI.NhanVien
{
    public partial class AddNhanVienForm : Form
    {
        private NhanVienBUS nvBUS = new NhanVienBUS();

        public AddNhanVienForm()
        {
            InitializeComponent();
        }

        private void lbAddNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            Close();
        }

        private void AddNhanVienForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if(txbName.Text.Length > 0)
            {
                DateTime birhday = dtpDate.Value;
                if(birhday >= DateTime.Now.Date)
                {
                    MessageBox.Show(
                             "Ngày sinh phải nhỏ hơn ngày hiện tại!",   
                             "Lỗi dữ liệu",                             
                             MessageBoxButtons.OK,                      
                             MessageBoxIcon.Error                       
                         );
                }
                else
                {
                    string sdt=txbPhone.Text.Trim();
                    string pattern = @"^(0|\+84)(3[2-9]|5[2-9]|7[0|6-9]|8[1-9]|9[0-9])[0-9]{7}$";
                    if (sdt.Length==0)
                    {
                        MessageBox.Show(
                             "Số điện thoại không được để trống!",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
                    }else if (!Regex.IsMatch(sdt, pattern))
                    {
                        MessageBox.Show(
                             "Số điện thoại không hợp lệ!",
                             "Lỗi nhập liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
                    }
                    else
                    {
                        int sex=0;
                        if (rbtnMale.Checked) sex = 1;
                        if (rbtnFemale.Checked) sex = 2;
                        if (rbtnGay.Checked) sex = 3;
                        NhanVienDTO nvInsert = new NhanVienDTO(
                            nvBUS.getAutoMaNV(), txbName.Text, sex,sdt, birhday, 1);
                        nvBUS.insertNhanVien(nvInsert);
                        this.DialogResult = DialogResult.OK; // Biến lưu giữ khi bấm thêm
                    }
                }
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
    }
}
