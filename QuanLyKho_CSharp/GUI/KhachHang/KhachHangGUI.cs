using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;

using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.NhomQuyen;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class KhachHangGUI : Form
    {

        private KhachHangBUS khBUS = new KhachHangBUS();
        private BindingList<KhachHangDTO> listKH;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public KhachHangGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            DGVKhachHang.ClearSelection();
            DGVKhachHang.RowHeadersVisible = false; // Tắt cột header
            DGVKhachHang.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhachHang.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhachHang.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhachHang.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhachHang.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVKhachHang.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVKhachHang.ColumnHeadersHeight = 30;
            DGVKhachHang.RowHeadersDefaultCellStyle = headerStyle;
            DGVKhachHang.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listKH = khBUS.getListKH();
            this.currentUser = currentUser;
            settingRole();
        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("khachhang");
            var listCT = nqBUS.getListCTNQByIdNQ(maNQ)
                .Where(ctnq => ctnq.Machucnang == maDMNC).ToList();
            listCTQ = new BindingList<ChiTietQuyenDTO>(listCT);
            // Thực hiện ẩn nút
            bool checkThem = false;
            bool checkSua = false;
            bool checkXoa = false;
            foreach (ChiTietQuyenDTO ctq in listCTQ)
            {
                if (ctq.Hanhdong == "Thêm") checkThem = true;
                if (ctq.Hanhdong == "Sửa") checkSua = true;
                if (ctq.Hanhdong == "Xóa") checkXoa = true;
            }
            if (!checkThem)
            {
                btnThem.Visible = false;
                btnNhapExcel.Visible = false;
            }
            if (!checkSua) DGVKhachHang.Columns.Remove("edit");
            if (!checkXoa) DGVKhachHang.Columns.Remove("remove");
        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(khBUS.getListKH());

        }

        private void refreshDataGridView(BindingList<KhachHangDTO> listRefresh) // Tải lại DataGridView
        {
            DGVKhachHang.Rows.Clear();
            int soluong = 0;
            foreach (KhachHangDTO kh in listRefresh.Where(kh => kh.Trangthai == 1))
            {
                DGVKhachHang.Rows.Add(kh.Makh, kh.Tenkhachhang, kh.Email, kh.Sdt
                , kh.Ngaysinh.ToString("dd/MM/yyyy"), "Hoạt động");
                soluong++;
            }
            DGVKhachHang.ClearSelection();
            lbTotalNV.Text = "Tổng số khách hàng: " + soluong.ToString();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddKhachHangForm addKH = new AddKhachHangForm();
            addKH.ShowDialog();
            if (addKH.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(khBUS.getListKH());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddKhachHangForm addKH = new AddKhachHangForm();
            addKH.ShowDialog();
            if (addKH.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(khBUS.getListKH());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void DGVKhachHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maKH = int.Parse(DGVKhachHang.Rows[e.RowIndex].Cells["makh"].Value.ToString());
            KhachHangDTO KhachHangDuocChon = khBUS.getKHById(maKH);
            if (DGVKhachHang.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateKhachHangForm updateKH = new UpdateKhachHangForm(KhachHangDuocChon);
                updateKH.ShowDialog();
                if (updateKH.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(khBUS.getListKH());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }else if(DGVKhachHang.Columns[e.ColumnIndex].Name == "remove"){
                DeleteKhachHangForm deleteKH = new DeleteKhachHangForm(KhachHangDuocChon);
                deleteKH.ShowDialog();
                if (deleteKH.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(khBUS.getListKH());
                }
            }else if(DGVKhachHang.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailKhachHangForm detailKH = new DetailKhachHangForm(KhachHangDuocChon);
                detailKH.ShowDialog();
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string textSearch = txSearch.Text;
            listKH = khBUS.SearchKhachHang(textSearch);
            refreshDataGridView(listKH);
        }
    }
}
