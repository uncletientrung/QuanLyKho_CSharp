using QuanLyKho.BUS;
using QuanLyKho.DTO;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.KhuVuc
{
    public partial class KhuVucGUI : Form
    {
        private KhuVucKhoBUS kvkBUS = new KhuVucKhoBUS();
        private BindingList<KhuVucKhoDTO> listKhuVuc;

        public KhuVucGUI()
        {
            InitializeComponent();
            DGVKhuVuc.ClearSelection();
            DGVKhuVuc.RowHeadersVisible = false; // Tắt cột header
            DGVKhuVuc.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVKhuVuc.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVKhuVuc.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVKhuVuc.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVKhuVuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVKhuVuc.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVKhuVuc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVKhuVuc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            
            listKhuVuc = kvkBUS.getKhuVucKhoList();
        }

        private void DGVKhuVuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVKhuVuc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVKhuVuc.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                // Tính toán vị trí các nút
                int padding = 5;
                int totalButtons = 3;
                int buttonWidth = (DGVKhuVuc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Width - padding * (totalButtons + 1)) / totalButtons;
                int xRelative = e.Location.X;

                // Vị trí các nút
                int startSua = padding;
                int startXoa = startSua + buttonWidth + padding;
                int startXem = startXoa + buttonWidth + padding;

                // Lấy thông tin khu vực kho được chọn
                int maKVK = int.Parse(DGVKhuVuc.Rows[e.RowIndex].Cells["MaKVK"].Value.ToString());
                KhuVucKhoDTO KhuVucKhoDuocChon = kvkBUS.getKVKById(maKVK);

                if (KhuVucKhoDuocChon == null)
                {
                    MessageBox.Show("Không tìm thấy khu vực kho này!");
                    return;
                }

                if (xRelative >= startSua && xRelative < startSua + buttonWidth)
                {
                    // Nút Sửa
                    UpdateKhuVucForm updateKVK = new UpdateKhuVucForm(KhuVucKhoDuocChon);
                    updateKVK.ShowDialog();
                    if (updateKVK.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(kvkBUS.getKhuVucKhoList()); 
                        AddSuccessNotification tb = new AddSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative >= startXoa && xRelative < startXoa + buttonWidth)
                {
                    // Nút Xóa
                    DeleteKhuVucForm deleteKVK = new DeleteKhuVucForm(KhuVucKhoDuocChon);
                    deleteKVK.ShowDialog();
                    if (deleteKVK.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(kvkBUS.getKhuVucKhoList());
                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative >= startXem && xRelative < startXem + buttonWidth)
                {
                    // Nút Xem chi tiết
                    DetailKhuVucForm detailKVK = new DetailKhuVucForm(KhuVucKhoDuocChon);
                    detailKVK.ShowDialog();
                }
            }
        }

        

        private void KhuVucGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listKhuVuc);
        }

        private void KhuVucGUI_Shown(object sender, EventArgs e)
        {

        }

        private void refreshDataGridView(BindingList<KhuVucKhoDTO> list)
        {
            DGVKhuVuc.Rows.Clear();
            int soluong = 0;
            foreach (KhuVucKhoDTO kvk in list)
            {
                DGVKhuVuc.Rows.Add(kvk.Makhuvuc, kvk.Tenkhuvuc, kvk.Diachi, kvk.Sdt, kvk.Email);
                soluong++;
            }
            DGVKhuVuc.ClearSelection();
            lbTotalNV.Text = "Tổng số khu vực: " + soluong.ToString();
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txSearch.Text.Trim().ToLower();
            BindingList<KhuVucKhoDTO> listSearch = kvkBUS.SearchKho(keyword);
            refreshDataGridView(listSearch);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddKhuVucForm addKhuVuc = new AddKhuVucForm();
            addKhuVuc.ShowDialog();

            if (addKhuVuc.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(kvkBUS.getKhuVucKhoList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void DGVKhuVuc_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int makv = int.Parse(DGVKhuVuc.Rows[e.RowIndex].Cells["makv"].Value.ToString());
            KhuVucKhoDTO KhuVucKhoDuocChon = kvkBUS.getKVKById(makv);
            if (DGVKhuVuc.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailKhuVucForm detailKVK = new DetailKhuVucForm(KhuVucKhoDuocChon);
                detailKVK.ShowDialog();
            }else if(DGVKhuVuc.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateKhuVucForm updateKVK = new UpdateKhuVucForm(KhuVucKhoDuocChon);
                updateKVK.ShowDialog();
                if (updateKVK.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(kvkBUS.getKhuVucKhoList());
                    AddSuccessNotification tb = new AddSuccessNotification();
                    tb.Show();
                }
            }else if(DGVKhuVuc.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteKhuVucForm deleteKVK = new DeleteKhuVucForm(KhuVucKhoDuocChon);
                deleteKVK.ShowDialog();
                if (deleteKVK.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(kvkBUS.getKhuVucKhoList());
                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                }
            }
        }
    }
}
