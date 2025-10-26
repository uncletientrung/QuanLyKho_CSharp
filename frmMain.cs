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

        private KryptonButton currentButton; //biến giữ button hiện tại
        private TaiKhoanDTO tkLogin;
        public static TaiKhoanDTO CurrentUser { get; private set; }
        private NhanVienBUS nvBUS= new NhanVienBUS();
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private DanhMucChucNangBUS dmncBUS = new DanhMucChucNangBUS();
        private BindingList<KryptonButton> listButton;

        private bool expand = false;
        private bool expandThuocTinh = false;



        public frmMain(TaiKhoanDTO _tkLogin)
        {
            InitializeComponent();
            tkLogin = _tkLogin;
            CurrentUser = _tkLogin;
            CustomizeDesign();
            setTagForButton();
            lbUser.Text = LayTenNguoiDung(nvBUS.getNamebyID(_tkLogin.Manv)); // set Tên
            //set Role
            setRole();
            

            // Kiểm tra xem nhóm quyền tài khoản
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
                    if (btnToShow.Tag == "thongtin")
                    {
                        pnlSubmenuThuocTinh.Visible = true;
                        btnQuanLyThuocTinh.Visible = true;
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

            btnQuanLyThuocTinh.Tag = "quanlythuoctinh";
            btnNhaCungCap.Tag = "thongtin";
            btnChatLieu.Tag = "thongtin";
            btnLoai.Tag = "thongtin";
            btnSize.Tag = "thongtin";
            btnKhuVuc.Tag = "thongtin";

            btnQuanLyNhanVien.Tag = "quanlynhanvien";
            btnNhanVien.Tag = "nhanvien";
            btnTaiKhoan.Tag = "taikhoan";
            btnPhanQuyen.Tag = "phanquyen";
        }


        private void OpenChildForm(Form childForm, KryptonButton btn)
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
            btnClose.Visible=true;

            pnlSubmenu.Visible = false;
            pnlSubmenuThuocTinh.Visible = false;
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


        private void kryptonButton1_Click(object sender, EventArgs e)
        {

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
            if(nameRole.Equals("Quản lý"))
            {
                lbRole.StateCommon.ShortText.Color1 = Color.FromArgb(240, 43, 43);
                lbRole.StateCommon.ShortText.Color2 = Color.FromArgb(240, 43, 43);
            }
            else
            {
                lbRole.StateCommon.ShortText.Color1 = Color.FromArgb(255, 255, 255);
                lbRole.StateCommon.ShortText.Color2 = Color.FromArgb(255, 255, 255);
            }
            lbRole.Values.Text = nameRole;
        }

        private void CloseSubmenuNhanVien()
            {
                if (expand) // Nếu đang mở
                {
                    timer1.Stop();
                    pnlSubmenu.Height = pnlSubmenu.MinimumSize.Height;
                    expand = false;
                }
            }

        private void CloseSubmenuThuocTinh()
        {
            if (expandThuocTinh) // Nếu đang mở
            {
                timer2.Stop();
                pnlSubmenuThuocTinh.Height = pnlSubmenuThuocTinh.MinimumSize.Height;
                expandThuocTinh = false;
            }
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
            CloseSubmenuThuocTinh();
            timer1.Start();
            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (expandThuocTinh == false)
            {
                pnlSubmenuThuocTinh.Height += 15;
                if (pnlSubmenuThuocTinh.Height >= pnlSubmenuThuocTinh.MaximumSize.Height)
                {
                    timer2.Stop();
                    expandThuocTinh = true;
                }
            }
            else
            {
                pnlSubmenuThuocTinh.Height -= 15;
                if (pnlSubmenuThuocTinh.Height <= pnlSubmenuThuocTinh.MinimumSize.Height)
                {
                    timer2.Stop();
                    expandThuocTinh = false;
                }
            }
        }
        private void btnQuanLyThuocTinh_Click(object sender, EventArgs e)
        {
            CloseSubmenuNhanVien();
            timer2.Start();
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

        private void btnChatLieu_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ChatLieuGUI(), btnChatLieu);
        }

        private void btnLoai_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiGUI(), btnLoai);
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SizeGUI(), btnSize);
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhuVucGUI(), btnKhuVuc);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
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
            OpenChildForm(new KiemKeGUI(), btnKiemKe);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeGUI(), btnBaoCao);
        }

    }
}