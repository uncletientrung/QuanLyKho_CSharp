using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using QuanLyKho_CSharp.Helper;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class ChatLieuGUI : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private BindingList<ChatLieuDTO> listCL;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;
        public ChatLieuGUI(NhanVienDTO cureentUser)
        {
            InitializeComponent();
            // Thiết lập DataGridView
            DGVChatLieu.ClearSelection();
            DGVChatLieu.RowHeadersVisible = false; // Tắt cột header
            DGVChatLieu.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVChatLieu.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVChatLieu.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVChatLieu.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVChatLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVChatLieu.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVChatLieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVChatLieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVChatLieu.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVChatLieu.ColumnHeadersHeight = 30;
            DGVChatLieu.RowHeadersDefaultCellStyle = headerStyle;
            DGVChatLieu.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listCL = clBUS.getChatLieuList();
            this.currentUser = cureentUser;
            settingRole();
        }

        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("thongtin");
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
            if (!checkSua) DGVChatLieu.Columns.Remove("edit");
            if (!checkXoa) DGVChatLieu.Columns.Remove("remove");
        }

        private void ChatLieuGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listCL);
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txSearch.Text.Trim().ToLower();
            BindingList<ChatLieuDTO> listSearch = clBUS.searchChatLieu(keyword);
            refreshDataGridView(listSearch); 
        }

        private void refreshDataGridView(BindingList<ChatLieuDTO> list)
        {
            DGVChatLieu.Rows.Clear();
            int soluong = 0;
            foreach (ChatLieuDTO cl in list)
            {
                DGVChatLieu.Rows.Add($"CL-{cl.Machatlieu}", cl.Tenchatlieu);
                soluong++;
            }
            DGVChatLieu.ClearSelection();
            lbTotalNV.Text = "Tổng số chất liệu: " + soluong.ToString();
        }

        private void DGVChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maCL = int.Parse(DGVChatLieu.Rows[e.RowIndex].Cells["macl"].Value.ToString().Replace("CL-", ""));
            ChatLieuDTO chatLieuDuocChon = clBUS.getChatLieuById(maCL);
            if (DGVChatLieu.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailChatLieuForm detailCL = new DetailChatLieuForm(chatLieuDuocChon);
                detailCL.ShowDialog();
            }else if (DGVChatLieu.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateChatLieuForm updateCL = new UpdateChatLieuForm(chatLieuDuocChon);
                updateCL.ShowDialog();
                if (updateCL.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(clBUS.getChatLieuList());
                    new AddSuccessNotification().Show();
                }
            }else if(DGVChatLieu.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteChatLieuForm deleteCL = new DeleteChatLieuForm(chatLieuDuocChon);
                deleteCL.ShowDialog();
                if (deleteCL.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(clBUS.getChatLieuList());
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddChatLieuForm addCL = new AddChatLieuForm();
            addCL.ShowDialog();

            if (addCL.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(clBUS.getChatLieuList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }
    }
}
