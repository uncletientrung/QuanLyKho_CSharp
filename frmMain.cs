using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.KiemKe;
using QuanLyKho_CSharp.GUI.PhanQuyen;
using QuanLyKho_CSharp.GUI.PhieuNhap;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.GUI.TaiKhoan;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QuanLyKho_CSharp
{
    public partial class frmMain : Form
    {
        private Form currentFormChild;// Biến giữ form con hiện tại

        private Button currentButton; //biến giữ button hiện tại
        private TaiKhoanDTO tkLogin;
        private NhomQuyenBUS nvBUS = new NhomQuyenBUS();
        private DanhMucChucNangBUS dmncBUS = new DanhMucChucNangBUS();
        private BindingList<Button> listButton;


        public frmMain(TaiKhoanDTO _tkLogin)
        {
            InitializeComponent();
            CustomizeDesign();
            setTagForButton();

            // Kiểm tra xem nhóm quyền tài khoản
            tkLogin = _tkLogin;
            BindingList<ChiTietQuyenDTO> listctq = nvBUS.getListCTNQByIdNQ(tkLogin.Manhomquyen);
            foreach (ChiTietQuyenDTO ctq in listctq)
            {
                if (!listButton.Any(btn => btn.Tag == "tonkho") && !listButton.Any(btn => btn.Tag == "phieuxuat") &&
                    !listButton.Any(btn => btn.Tag == "phieunhap") && !listButton.Any(btn => btn.Tag == "kiemke"))
                {
                    btnquanlykho.Visible = true; // Hiển thị nút quản lý kho
                }
                if (!listButton.Any(btn => btn.Tag == "thongtin") &&
                    !listButton.Any(btn => btn.Tag == "khachhang") &&
                    !listButton.Any(btn => btn.Tag == "baocao"))
                {
                    btnDanhMuc.Visible = true; // Hiển thị nút danh mục
                }
                if (!listButton.Any(btn => btn.Tag == "nhanvien") &&
                    !listButton.Any(btn => btn.Tag == "taikhoan") &&
                    !listButton.Any(btn => btn.Tag == "phanquyen"))
                {
                    btnQuanLyHeThong.Visible = true; // Hiển thị nút quản lý hệ thống
                }
            }



        }

        public void setTagForButton()
        {
            btnquanlykho.Tag = "quanlykho";
            btnTonKho.Tag = "tonkho";
            btnPhieuXuat.Tag = "phieuxuat";
            btnPhieuNhap.Tag = "phieunhap";
            btnKiemKe.Tag = "kiemke";

            btnDanhMuc.Tag = "danhmuc";
            btnKhachHang.Tag = "khachhang";
            btnBaoCao.Tag = "baocao";
            btnThongTin.Tag = "thongtin";
            btnNhaCungCap.Tag = "nhacungcap";
            btnChatLieu.Tag = "chatlieu";
            btnLoai.Tag = "loai";
            btnSize.Tag = "size";
            btnKhuVuc.Tag = "khuvuc";

            btnQuanLyHeThong.Tag = "quanlyhethong";
            btnNhanVien.Tag = "nhanvien";
            btnTaiKhoan.Tag = "taikhoan";
            btnPhanQuyen.Tag = "phanquyen";
        }

        private void OpenChildForm(Form childForm, Button btn)
        {
            //  Nếu form hiện tại cùng loại và cùng button -> Không làm gì
            if (currentFormChild != null
                && currentFormChild.GetType() == childForm.GetType()
                && currentButton == btn)
            {
                // Đang ở đúng form đó, không cần reload
                return;
            }

            // Đóng form cũ
            if (currentFormChild != null)
            {
                this.pnlBody.Controls.Clear();
                currentFormChild.Close();
                currentFormChild.Dispose();
            }

            // Xoá panel và thêm form mới
            pnlBody.Controls.Clear();
            currentFormChild = childForm;
            currentButton = btn; // Cập nhật nút hiện tại

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(childForm);
            pnlBody.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();


            pnlBody.PerformLayout();
            this.PerformLayout();
        }

        #region Xử lý ẩn hiện nút Menu phụ
        private void CustomizeDesign() // Trạng thái tắt button ban đầu
        {
            panelQuanLyKho.Visible = false;
            panelDanhMuc.Visible = false;
            panelQuanLyHeThong.Visible = false;
            panelThongTin.Visible = false;
        }
        private void hideSideMenu() // Ẩn các nút còn lại khi ấn
        {
            if (panelQuanLyKho.Visible) panelQuanLyKho.Visible = false;
            if (panelDanhMuc.Visible) panelDanhMuc.Visible = false;
            if (panelQuanLyHeThong.Visible) panelQuanLyHeThong.Visible = false;
            if (panelThongTin.Visible) panelThongTin.Visible = false;
        }
        private void ShowSideMenu(Panel sidemenu)
        {

            if (sidemenu.Visible == false)
            {
                if (sidemenu != panelThongTin) hideSideMenu();

                sidemenu.Visible = true;
            }
            else
            {
                sidemenu.Visible = false;
            }

        }
        #endregion

        #region 4 nút Menu phụ
        private void btnQuanLyKho_Click(object sender, EventArgs e)
        {
            ShowSideMenu(panelQuanLyKho);
        }
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            ShowSideMenu(panelDanhMuc);
        }
        private void btnQuanLyHeThong_Click(object sender, EventArgs e)
        {
            ShowSideMenu(panelQuanLyHeThong);
        }
        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ShowSideMenu(panelThongTin);
        }
        #endregion
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {

            OpenChildForm(new SanPhamGUI(), btnTonKho);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Test_Connection(), btnTrangChu);
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuNhapGUI(), btnPhieuNhap);
        }
        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuXuatGUI(), btnPhieuXuat);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangGUI(), btnKhachHang);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVienGUI(), btnNhanVien);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCungCapGUI(), btnNhaCungCap);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void avatar_Logout_Click(object sender, EventArgs e)
        {
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoanGUI(), btnTaiKhoan);
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhomQuyenGUI(), btnPhanQuyen);
        }


        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhSachKiemKeGUI(), btnKiemKe);
        }



        private void pnlLeftMenu_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}