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

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class LoaiGUI : Form
    {

        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<LoaiDTO> listLoai;

        public LoaiGUI()
        {
            InitializeComponent();

            DGVLoai.ClearSelection();
            DGVLoai.RowHeadersVisible = false; // Tắt cột header
            DGVLoai.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVLoai.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVLoai.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVLoai.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVLoai.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVLoai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVLoai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giữa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVLoai.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVLoai.ColumnHeadersHeight = 30;
            DGVLoai.RowHeadersDefaultCellStyle = headerStyle;
            DGVLoai.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            listLoai = loaiBUS.getLoaiList();
        }

        private void DGVLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Chỉ xử lý khi click vào cột Actions
            if (DGVLoai.Columns[e.ColumnIndex].Name != "Actions")
                return;

            // Lấy thông tin Loại được chọn (sử dụng đúng tên cột: MaLoai)
            int maLoai = Convert.ToInt32(DGVLoai.Rows[e.RowIndex].Cells["MaLoai"].Value);
            LoaiDTO loaiDuocChon = loaiBUS.getLoaiById(maLoai);
            if (loaiDuocChon == null)
            {
                MessageBox.Show("Không tìm thấy loại này!");
                return;
            }

            // Tính toán vị trí click trong ô để xác định nút
            Rectangle cellBounds = DGVLoai.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int padding = 5;
            int totalButtons = 3;
            int buttonWidth = (cellBounds.Width - padding * (totalButtons + 1)) / totalButtons;
            // e.X đã là toạ độ tương đối trong cell, không trừ cellBounds.Left
            int clickX = e.X;

            int startSua = padding;
            int startXoa = startSua + buttonWidth + padding;
            int startXem = startXoa + buttonWidth + padding;

            if (clickX >= startSua && clickX < startSua + buttonWidth)
            {
                // Sửa
                UpdateLoaiForm updateLoai = new UpdateLoaiForm(loaiDuocChon);
                updateLoai.ShowDialog();
                if (updateLoai.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(loaiBUS.getLoaiList());
                    new AddSuccessNotification().Show();
                }
            }
            else if (clickX >= startXoa && clickX < startXoa + buttonWidth)
            {
                // Xóa
                DeleteLoaiForm deleteLoai = new DeleteLoaiForm(loaiDuocChon);
                deleteLoai.ShowDialog();
                if (deleteLoai.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(loaiBUS.getLoaiList());
                }
            }
            else if (clickX >= startXem && clickX < startXem + buttonWidth)
            {
                // Xem chi tiết
                DetailLoaiForm detailLoai = new DetailLoaiForm(loaiDuocChon);
                detailLoai.ShowDialog();
            }
        }

        
        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddLoaiForm addLoai = new AddLoaiForm();
            addLoai.ShowDialog();

            if (addLoai.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(loaiBUS.getLoaiList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void LoaiGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listLoai);
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txSearch.Text.Trim().ToLower();
            BindingList<LoaiDTO> listSearch = loaiBUS.SearchLoai(keyword);
            refreshDataGridView(listSearch);

        }

        private void refreshDataGridView(BindingList<LoaiDTO> list)
        {
            DGVLoai.Rows.Clear();
            int soluong = 0;
            foreach (LoaiDTO loai in list)
            {
                DGVLoai.Rows.Add(loai.Maloai, loai.Tenloai);
                soluong++;
            }
            DGVLoai.ClearSelection();
            lbTotalNV.Text = "Tổng số loại: " + soluong.ToString();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVLoai_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maLoai = Convert.ToInt32(DGVLoai.Rows[e.RowIndex].Cells["mal"].Value);
            LoaiDTO loaiDuocChon = loaiBUS.getLoaiById(maLoai);
            if (DGVLoai.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailLoaiForm detailLoai = new DetailLoaiForm(loaiDuocChon);
                detailLoai.ShowDialog();
            } else if(DGVLoai.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateLoaiForm updateLoai = new UpdateLoaiForm(loaiDuocChon);
                updateLoai.ShowDialog();
                if (updateLoai.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(loaiBUS.getLoaiList());
                    new AddSuccessNotification().Show();
                }
            } else if(DGVLoai.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteLoaiForm deleteLoai = new DeleteLoaiForm(loaiDuocChon);
                deleteLoai.ShowDialog();
                if (deleteLoai.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    refreshDataGridView(loaiBUS.getLoaiList());
                }
            }
        }
    }
}
