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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.TaiKhoan
{
    public partial class DetailTaiKhoanForm : Form
    {
        private TaiKhoanDTO tk;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        private BindingList<NhanVienDTO> listNV;
        private BindingList<TaiKhoanDTO> listTK;
        public DetailTaiKhoanForm(TaiKhoanDTO _tk)
        {
            InitializeComponent();
            tk = _tk;
        }

        private void Detail2TaiKhoanForm_Load(object sender, EventArgs e)
        {
            cbbNhanVien.Enabled = false;
            cbbNhomQuyen.Enabled = false;
            txtUser.Enabled = false;
            txtPassword.Enabled = false;
            txtUser.Text=tk.Tendangnhap;
            txtPassword.Text = tk.Matkhau;
            

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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
