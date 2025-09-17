using Google.Protobuf.Collections;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    public partial class UpdateTaiKhoanForm : Form
    {
        private TaiKhoanDTO tk;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        private BindingList<NhanVienDTO> listNV;
        private BindingList<TaiKhoanDTO> listTK;
        public UpdateTaiKhoanForm(TaiKhoanDTO _tk)
        {
            InitializeComponent();
            tk=_tk;
        }

        private void UpdateTaiKhoanForm_Load(object sender, EventArgs e)
        {
            cbbNhanVien.Enabled = false;


            listNQ = nqBUS.getListNQ();
            foreach (NhomQuyenDTO nq in listNQ)
            {
                if (nq.Trangthai == 1)
                {
                    cbbNhomQuyen.Items.Add(nq.Manhomquyen + ". " + nq.Tennhomquyen);
                    if (nq.Manhomquyen == tk.Manhomquyen)
                    {
                        cbbNhomQuyen.SelectedItem = nq.Manhomquyen + ". " + nq.Tennhomquyen;
                    }
                }
            }

            // Nhân viên
            listNV = nvBUS.getListNV();
            foreach (NhanVienDTO nv in listNV)
            {
                if (nv.Trangthai == 1)
                {
                    cbbNhanVien.Items.Add(nv.Manv + ". " + nv.Tennv);
                    if (nv.Manv == tk.Manv)
                    {
                        cbbNhanVien.SelectedItem = nv.Manv + ". " + nv.Tennv;
                    }
                }
            }
            txtUser.Text = tk.Tendangnhap;
            txtPassword.Text = tk.Matkhau;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsUsernameExist(txtUser.Text))
            {
                MessageBox.Show(
                            "Tên đăng nhập đã tồn tại",
                            "Lỗi dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                return;
            }
            int manv = int.Parse(cbbNhanVien.Text.ToString().Split('.')[0]);
            tk = tkBUS.getTKById(manv);
            int manhomquyen = int.Parse(cbbNhomQuyen.Text.ToString().Split('.')[0]);

            if (txtUser.Text != "")
            {
                string user = txtUser.Text;
                if (txtPassword.Text == "")
                {
                    MessageBox.Show(
                            "Mật khẩu không được để trống",
                            "Lỗi dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }
                else
                {
                    string password = txtPassword.Text;
                    TaiKhoanDTO tkUpdate = new TaiKhoanDTO(manv, user, password, manhomquyen, 1);
                    tkBUS.UpdateTK(tkUpdate);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show(
                            "Tài khoản không được để trống",
                            "Lỗi dữ liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
            }
        }

        private Boolean IsUsernameExist(string username)
        {
            listTK = tkBUS.getListTK();
            foreach (TaiKhoanDTO tk in listTK)
            {
                if (tk.Tendangnhap == username)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
