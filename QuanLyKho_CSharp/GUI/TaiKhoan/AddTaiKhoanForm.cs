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
    public partial class AddTaiKhoanForm : Form
    {
        private NhomQuyenBUS nqBUS= new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS= new TaiKhoanBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        private BindingList<NhanVienDTO> listNV;
        private BindingList<TaiKhoanDTO> listTK;
        private NhanVienDTO nvDuocChon;
        public AddTaiKhoanForm()
        {
            InitializeComponent();
        }

        private void lbAddTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void AddTaiKhoanForm_Load(object sender, EventArgs e)
        {
            // Nhóm quyền
            listNQ= nqBUS.getListNQ();
            foreach (NhomQuyenDTO nq in listNQ)
            {
                if(nq.Trangthai == 1)
                {
                    cbbNhomQuyen.Items.Add(nq.Manhomquyen + ". " + nq.Tennhomquyen);
                }
                
            }

            // Nhân viên
            cbbNhanVien.Items.Add("Chọn nhân viên");
            listNV=nvBUS.getListNV();
            foreach (NhanVienDTO nv in listNV)
            {
                if(nv.Trangthai == 1)
                {
                    cbbNhanVien.Items.Add(nv.Manv + ". " + nv.Tennv);
                }
                
            }

            cbbNhanVien.SelectedIndex = 0;
            cbbNhomQuyen.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbNhanVien.Text.Equals("Chọn nhân viên"))
            {
                MessageBox.Show(
                              "Vui lòng chọn nhân viên được cấp tài khoản",
                              "Lỗi dữ liệu",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error
                          );
                return;
            }
            
            int manv = int.Parse(cbbNhanVien.Text.ToString().Split('.')[0]);
            nvDuocChon = nvBUS.getNVById(manv);
            int manhomquyen= int.Parse(cbbNhomQuyen.Text.ToString().Split('.')[0]);
            listTK=tkBUS.getListTK();

            if (!listTK.Any( tk => tk.Manv == manv &&
                                     tk.Trangthai == 1))
            {
                if (listTK.Any(tk => tk.Manv != manv &&
                                     tk.Tendangnhap == txbUser.Text &&
                                     tk.Trangthai ==1))
                {
                    MessageBox.Show(
                                  "Tên đăng nhập đã tồn tại",
                                  "Lỗi dữ liệu",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error
                              );
                    return;
                }
                if (txbUser.Text != "")
                {
                    string user = txbUser.Text;
                    if (txtPassword.Text == "")
                    {
                        MessageBox.Show(
                              "Mật khẩu không được để trống",
                              "Lỗi dữ liệu",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error
                          );
                    }
                    else if(txtPassword.Text != txtConfirmPass.Text)
                    {
                        MessageBox.Show(
                              "2 mật khẩu khác nhau",
                              "Lỗi dữ liệu",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error
                          );

                    }
                    else
                    {
                        string password = txtPassword.Text;
                        TaiKhoanDTO tk = new TaiKhoanDTO(manv, user, password, manhomquyen, 1);
                        tkBUS.InsertTK(tk);
                        this.DialogResult=DialogResult.OK;
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
            else
            {
                MessageBox.Show(
                              "Nhân viên này đã được cấp tài khoản",
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
