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
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.KhuVuc;
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
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
using QuanLyKho_CSharp.GUI.ThongKe;
using QuanLyKho_CSharp.GUI.ThongTin.Size;
using ComponentFactory.Krypton.Toolkit;

namespace QuanLyKho_CSharp
{
    public partial class frmMain : KryptonForm
    {
        private Form currentFormChild;// Biến giữ form con hiện tại

        private Button currentButton; //biến giữ button hiện tại
        private TaiKhoanDTO tkLogin;
        public static TaiKhoanDTO CurrentUser { get; private set; }
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private DanhMucChucNangBUS dmncBUS = new DanhMucChucNangBUS();
        private BindingList<KryptonButton> listButton;

        private bool expand = false;



        public frmMain(TaiKhoanDTO _tkLogin)
        {
            InitializeComponent();
            CustomizeDesign();
            setTagForButton();

            // Kiểm tra xem nhóm quyền tài khoản
            tkLogin = _tkLogin;
            CurrentUser = _tkLogin;
            BindingList<ChiTietQuyenDTO> listctq = nqBUS.getListCTNQByIdNQ(tkLogin.Manhomquyen);
            foreach (ChiTietQuyenDTO ctq in listctq)
            {
                string name = dmncBUS.getNameById(ctq.Machucnang);
                var btnToShow = listButton.FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == name);
                if (btnToShow != null)
                {
                    if (btnToShow.Tag == "nhanvien" || btnToShow.Tag == "taikhoan" || btnToShow.Tag == "phanquyen") {
                        pnlSubmenu.Visible = true;
                        btnQuanLyNhanVien.Visible = true;
                    }
                    btnToShow.Visible = true;
                }
            }
            //Nếu muốn hiển thị tất cả nút con của một nhóm, ví dụ 'thongtin'
            if (listctq.Any(q => dmncBUS.getNameById(q.Machucnang) == "thongtin"))
            {
                btnChatLieu.Visible = true;
                btnKhuVuc.Visible = true;
                btnSize.Visible = true;
                btnLoai.Visible = true;
                btnNhaCungCap.Visible = true;
                btnThuocTinh.Visible = true;
            }
        }

        public void setTagForButton()
        {
            btnLogout.Tag = "dangxuat";
            btnTrangChu.Tag = "trangchu";

            btnTonKho.Tag = "tonkho";
            btnPhieuXuat.Tag = "xuathang";
            btnPhieuNhap.Tag = "nhaphang";
            btnKiemKe.Tag = "kiemke";

            btnKhachHang.Tag = "khachhang";
            btnBaoCao.Tag = "baocao";

            btnNhaCungCap.Tag = "nhacungcap";
            btnChatLieu.Tag = "chatlieu";
            btnLoai.Tag = "loai";
            btnSize.Tag = "size";
            btnKhuVuc.Tag = "khuvuc";

            btnQuanLyNhanVien.Tag = "quanlynhanvien";
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
            listButton = nqBUS.GetAllButtons(this); // Lấy các nút 
            foreach (var btn in listButton)
            {
                btn.Visible = false;
            }
            btnTrangChu.Visible = true;
            btnLogout.Visible = true;
            btnClose.Visible=true;

            pnlSubmenu.Visible = false;
        }
        //private void hideSideMenu() // Ẩn các nút còn lại khi ấn
        //{
        //    if (panelQuanLyKho.Visible) panelQuanLyKho.Visible = false;
        //    if (panelDanhMuc.Visible) panelDanhMuc.Visible = false;
        //    if (panelQuanLyHeThong.Visible) panelQuanLyHeThong.Visible = false;
        //    if (panelThongTin.Visible) panelThongTin.Visible = false;
        //}
        //private void ShowSideMenu(Panel sidemenu)
        //{

        //    if (sidemenu.Visible == false)
        //    {
        //        if (sidemenu != panelThongTin) hideSideMenu();

        //        sidemenu.Visible = true;
        //    }
        //    else
        //    {
        //        sidemenu.Visible = false;
        //    }

        //}
        #endregion

        //#region 4 nút Menu phụ
        //private void btnQuanLyKho_Click(object sender, EventArgs e)
        //{
        //    ShowSideMenu(panelQuanLyKho);
        //}
        //private void btnDanhMuc_Click(object sender, EventArgs e)
        //{
        //    ShowSideMenu(panelDanhMuc);
        //}
        //private void btnQuanLyHeThong_Click(object sender, EventArgs e)
        //{
        //    ShowSideMenu(panelQuanLyHeThong);
        //}
        //private void btnThongTin_Click(object sender, EventArgs e)
        //{
        //    ShowSideMenu(panelThongTin);
        //}
        //#endregion
        //private void label1_Click(object sender, EventArgs e)
        //{
        //}

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand == false)
            {
                pnlSubmenu.Height += 15;
                if (pnlSubmenu.Height >= pnlSubmenu.MaximumSize.Height)
                {
                    timer1.Stop();
                    expand = true;
                }
            }
            else
            {
                pnlSubmenu.Height -= 15;
                if (pnlSubmenu.Height <= pnlSubmenu.MinimumSize.Height)
                {
                    timer1.Stop();
                    expand = false;
                }
            }
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }


        //private void btnTonKho_Click(object sender, EventArgs e)
        //{

        //    OpenChildForm(new SanPhamGUI(), btnTonKho);
        //}

        //private void btnTrangChu_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new Test_Connection(), btnTrangChu);
        //}

        //private void btnPhieuNhap_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new PhieuNhapGUI(), btnPhieuNhap);
        //}
        //private void btnPhieuXuat_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new PhieuXuatGUI(), btnPhieuXuat);
        //}

        //private void btnKhachHang_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new KhachHangGUI(), btnKhachHang);
        //}

        //private void btnNhanVien_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new NhanVienGUI(), btnNhanVien);
        //}

        //private void btnNhaCungCap_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new NhaCungCapGUI(), btnNhaCungCap);
        //}

        //private void btnChatLieu_Click_1(object sender, EventArgs e)
        //{
        //    OpenChildForm(new ChatLieuGUI(), btnChatLieu);
        //}

        //private void btnLoai_Click_1(object sender, EventArgs e)
        //{
        //    OpenChildForm(new LoaiGUI(), btnLoai);
        //}

        //private void btnSize_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new SizeGUI(), btnSize);
        //}

        //private void btnKhuVuc_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new KhuVucGUI(), btnKhuVuc);
        //}

        //private void btnLogout_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Abort;
        //    this.Close();
        //}

        //private void avatar_Logout_Click(object sender, EventArgs e)
        //{
        //}

        //private void btnTaiKhoan_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new TaiKhoanGUI(), btnTaiKhoan);
        //}

        //private void btnPhanQuyen_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new NhomQuyenGUI(), btnPhanQuyen);
        //}


        //private void pnlBody_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void btnKiemKe_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new KiemKeGUI(), btnKiemKe);
        //}




        //private void pnlLeftMenu_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void btnBaoCao_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new ThongKeGUI(), btnBaoCao);
        //}
        //bool expend = false;

    }
}