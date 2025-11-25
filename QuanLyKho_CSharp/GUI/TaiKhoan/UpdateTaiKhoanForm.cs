using Google.Protobuf.Collections;
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

namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    public partial class UpdateTaiKhoanForm : Form
    {
        private TaiKhoanDTO tkDuocChon;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        private BindingList<NhanVienDTO> listNV;
        private BindingList<TaiKhoanDTO> listTK;
        public UpdateTaiKhoanForm(TaiKhoanDTO _tk)
        {
            InitializeComponent();
            tkDuocChon = _tk;
        }

        private void UpdateTaiKhoanForm_Load(object sender, EventArgs e)
        {
            cbbNhanVien.Enabled = false;


            listNQ = nqBUS.getListNQ();
            foreach (NhomQuyenDTO nq in listNQ.Where(item => item.Trangthai==1))
            {
                cbbNhomQuyen.Items.Add(nq.Manhomquyen + ". " + nq.Tennhomquyen);
                if (nq.Manhomquyen == tkDuocChon.Manhomquyen)
                {
                    cbbNhomQuyen.SelectedItem = nq.Manhomquyen + ". " + nq.Tennhomquyen;
                }
            }

            // Nhân viên
            listNV = nvBUS.getListNV();
            foreach (NhanVienDTO nv in listNV.Where(item => item.Trangthai==1))
            {
                cbbNhanVien.Items.Add(nv.Manv + ". " + nv.Tennv);
                if (nv.Manv == tkDuocChon.Manv)
                {
                    cbbNhanVien.SelectedItem = nv.Manv + ". " + nv.Tennv;
                }
            }
            txtUser.Text = tkDuocChon.Tendangnhap;
            txtPassword.Text = tkDuocChon.Matkhau;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            listTK = tkBUS.getListTK();
            if (listTK.Any(tk => tk.Tendangnhap == txtUser.Text &&
                                 tk.Manv != tkDuocChon.Manv &&
                                 tk.Trangthai == 1))
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
            tkDuocChon = tkBUS.getTKById(manv);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
