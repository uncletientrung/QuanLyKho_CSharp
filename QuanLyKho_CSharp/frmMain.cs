using ComponentFactory.Krypton.Toolkit;
using Guna.UI2.WinForms;
using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.KiemKe;
using QuanLyKho_CSharp.GUI.PhanQuyen;
using QuanLyKho_CSharp.GUI.PhieuNhap;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.GUI.TaiKhoan;
using QuanLyKho_CSharp.GUI.ThongKe;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.KhuVuc;
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using QuanLyKho_CSharp.GUI.ThongTin.Size;
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

        private Guna2Button currentButton; //biến giữ button hiện tại
        private TaiKhoanDTO tkLogin;
        public static TaiKhoanDTO CurrentUser { get; private set; }
        private NhanVienBUS nvBUS= new NhanVienBUS();
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private DanhMucChucNangBUS dmncBUS = new DanhMucChucNangBUS();
        private BindingList<Guna2Button> listButton;
        private NhanVienDTO currentUser2; // Nhân viên đăng nhập

        public frmMain(TaiKhoanDTO _tkLogin)
        {
            InitializeComponent();
            tkLogin = _tkLogin;
            CurrentUser = _tkLogin;
            currentUser2 = nvBUS.getNVById(_tkLogin.Manv);
            CustomizeDesign();
            setTagForButton();
            lbName.Text = LayTenNguoiDung(nvBUS.getNamebyID(_tkLogin.Manv)); // set Tên
            //set Role
            setRole();


            // Kiểm tra xem nhóm quyền tài khoản
            BindingList<ChiTietQuyenDTO> listctq = nqBUS.getListCTNQByIdNQ(tkLogin.Manhomquyen);
            foreach (ChiTietQuyenDTO ctq in listctq)
            {
                string name = dmncBUS.getNameById(ctq.Machucnang);
                var btnToShow = listButton.FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == name);
                if (btnToShow != null && ctq.Hanhdong == "Xem")
                {
                    if (btnToShow.Tag == "thongtin")
                    {
                        btnNhaCungCap.Visible = true;
                        btnKhuVuc.Visible = true;
                        btnLoai.Visible = true;
                        btnSize.Visible = true;
                        btnChatLieu.Visible = true;
                        continue;
                    }
                    btnToShow.Visible = true;
                }
            }

            OpenChildForm(new Test_Connection(), btnTrangChu); // Chạy trang chủ đầu tiên 
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

            btnNhaCungCap.Tag = "thongtin";
            btnChatLieu.Tag = "thongtin";
            btnLoai.Tag = "thongtin";
            btnSize.Tag = "thongtin";
            btnKhuVuc.Tag = "thongtin";

            btnNhanVien.Tag = "nhanvien";
            btnTaiKhoan.Tag = "taikhoan";
            btnPhanQuyen.Tag = "phanquyen";
        }


        private void OpenChildForm(Form childForm, Guna2Button btn = null)
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
            if(btn != null) lbPage.Text = btn.Text;


            pnlBody.PerformLayout();
            this.PerformLayout();
        }

        //#region Xử lý ẩn hiện nút Menu phụ
        private void CustomizeDesign() // Trạng thái tắt button ban đầu
        {
            listButton = nqBUS.GetAllButtons(this); // Lấy các nút 
            foreach (var btn in listButton)
            {
                btn.Visible = false;
            }
            btnTrangChu.Visible = true;
            btnLogout.Visible = true;
        }


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


        public string LayTenNguoiDung(string hoTen)
        {
            if (hoTen == "Không tìm thấy") return "Admin";
            if (string.IsNullOrWhiteSpace(hoTen))
                return string.Empty;
            string[] parts = hoTen.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                return parts[0];
            }
            else if (parts.Length == 2)
            {
                return $"{parts[0]} {parts[1]}";
            }
            else
            {
                return $"{parts[parts.Length - 2]} {parts[parts.Length - 1]}";
            }
        }
        public void setRole()
        {
            string nameRole = nqBUS.getNQById(tkLogin.Manhomquyen).Tennhomquyen;
            if (nameRole.Equals("Quản lý"))
            {
                lbRole.ForeColor = Color.FromArgb(240, 43, 43);
                
            }
            lbRole.Text = nameRole;
        }




        private void btnTonKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPhamGUI(currentUser2), btnTonKho);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Test_Connection(), btnTrangChu);
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuNhapGUI(currentUser2), btnPhieuNhap);
        }
        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhieuXuatGUI(currentUser2), btnPhieuXuat);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangGUI(currentUser2), btnKhachHang);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVienGUI(currentUser2), btnNhanVien);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhaCungCapGUI(currentUser2), btnNhaCungCap);
        }

        private void btnChatLieu_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ChatLieuGUI(currentUser2), btnChatLieu);
        }

        private void btnLoai_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiGUI(currentUser2), btnLoai);
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SizeGUI(currentUser2), btnSize);
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhuVucGUI(currentUser2), btnKhuVuc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoanGUI(currentUser2), btnTaiKhoan);
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhomQuyenGUI(currentUser2), btnPhanQuyen);
        }


        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KiemKeGUI(currentUser2), btnKiemKe);

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeGUI(), btnBaoCao);

        }


        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }





        private void imgSlide_Click(object sender, EventArgs e)
        {

        }

        private void imgSlide_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox3_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        

    }
}