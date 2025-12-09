using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.Loai;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using QuanLyKho_CSharp.GUI.ThongTin.Size;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.ThongTin.Size
{
    public partial class SizeGUI : Form
    {
        private SizeBUS sizeBUS = new SizeBUS();
        private BindingList<SizeDTO> listSize;
        private NhanVienDTO currentUser;
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;



        public SizeGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            // Thiết lập DataGridView
            DGVSize.ClearSelection();
            DGVSize.RowHeadersVisible = false; // Tắt cột header
            DGVSize.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVSize.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVSize.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVSize.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVSize.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVSize.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVSize.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVSize.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVSize.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVSize.ColumnHeadersHeight = 30;
            DGVSize.RowHeadersDefaultCellStyle = headerStyle;
            DGVSize.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            listSize = sizeBUS.getSizeList();
            this.currentUser = currentUser;
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
            if (!checkSua) DGVSize.Columns.Remove("edit");
            if (!checkXoa) DGVSize.Columns.Remove("remove");
        }
        private void roundedButton2_Click_1(object sender, EventArgs e)
        {
            AddSizeForm addSize = new AddSizeForm();
            addSize.ShowDialog();

            if (addSize.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(sizeBUS.getSizeList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void refreshDataGridView(BindingList<SizeDTO> list)
        {
            DGVSize.Rows.Clear();
            int soluong = 0;
            foreach (SizeDTO size in list)
            {
                DGVSize.Rows.Add(size.Masize, size.Tensize, size.Ghichu);
                soluong++;
            }
            DGVSize.ClearSelection();
            lbTotalNV.Text = "Tổng số size: " + soluong.ToString();
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txSearch.Text;
            listSize = sizeBUS.SearchSize(text);
            refreshDataGridView(listSize);
        }
        

        private void SizeGUI_Load(object sender, EventArgs e)
        {
           
            refreshDataGridView(listSize);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVSize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVSize_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maSize = Convert.ToInt32(DGVSize.Rows[e.RowIndex].Cells["masize"].Value);
            SizeDTO SizeDuocChon = sizeBUS.getSizeById(maSize);
            if (DGVSize.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailSizeForm detailSize = new DetailSizeForm(SizeDuocChon);
                detailSize.ShowDialog();
            }else if(DGVSize.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteSizeForm deleteSize = new DeleteSizeForm(SizeDuocChon);
                deleteSize.ShowDialog();
                if (deleteSize.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(sizeBUS.getSizeList());
                }
            }else if(DGVSize.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateSizeForm updateSize = new UpdateSizeForm(SizeDuocChon);
                updateSize.ShowDialog();
                if (updateSize.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(sizeBUS.getSizeList());
                    new UpdateSuccessNotification().Show();
                }
            }
        }
    }
}
