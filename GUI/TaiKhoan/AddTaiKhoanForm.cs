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
    public partial class AddTaiKhoanForm : Form
    {
        private NhomQuyenBUS nqBUS= new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS= new TaiKhoanBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        private BindingList<NhanVienDTO> listNV;
        private NhomQuyenDTO nqDuocChon;
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
                cbbNhomQuyen.Items.Add(nq.Tennhomquyen);
            }
            cbbNhomQuyen.SelectedIndex = 1;

            // Nhân viên
            
            listNV=nvBUS.getListNV();
            MessageBox.Show(listNV.Count.ToString());
            foreach (NhanVienDTO nv in listNV)
            {
                cbbNhanVien.Items.Add(nv.Manv +". " + nv.Tennv);
            }
            cbbNhomQuyen.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //nvDuocChon=
            //if(txbUser.Text != "")
            //{
            //    string user=txbUser.Text;
            //    if(txtPassword.Text != "")
            //    {
            //        string password= txtPassword.Text;
            //        //TaiKhoanDTO tk= new TaiKhoanDTO(user, password, );
            //        //tkBUS.InsertTK()
            //    }
            //}
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }
    }
}
