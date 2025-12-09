    using QuanLyKho.BUS;
using QuanLyKho.DTO;
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

namespace QuanLyKho_CSharp.GUI.PhanQuyen
{
    public partial class NhomQuyenGUI : Form
    {
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private BindingList<NhomQuyenDTO> listNQ;
        public NhomQuyenGUI()
        {
            InitializeComponent();
            DGVPhanQuyen.ClearSelection();
            DGVPhanQuyen.RowHeadersVisible = false; // Tắt cột header
            DGVPhanQuyen.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVPhanQuyen.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVPhanQuyen.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVPhanQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVPhanQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVPhanQuyen.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVPhanQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVPhanQuyen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVPhanQuyen.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVPhanQuyen.ColumnHeadersHeight = 30;
            DGVPhanQuyen.RowHeadersDefaultCellStyle = headerStyle;
            DGVPhanQuyen.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            listNQ = nqBUS.getListNQ();
            refreshDataGridView(listNQ);
        }

        private void lbFormName_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNhomQuyenForm addNhomQuyenForm = new AddNhomQuyenForm();
            addNhomQuyenForm.ShowDialog();
            if (addNhomQuyenForm.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(nqBUS.getListNQ());
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void PhanQuyenGUI_Load(object sender, EventArgs e)
        {

        }

        

        private void DGVPhanQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int manq = int.Parse(DGVPhanQuyen.Rows[e.RowIndex].Cells["manq"].Value.ToString().Replace("NQ-",""));
            NhomQuyenDTO NhomQuyenDuocChon = nqBUS.getNQById(manq);
            if (DGVPhanQuyen.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailNhomQuyenForm detailNQ = new DetailNhomQuyenForm(NhomQuyenDuocChon);
                detailNQ.ShowDialog();
            }
            if (DGVPhanQuyen.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateNhomQuyenForm updateNQ = new UpdateNhomQuyenForm(NhomQuyenDuocChon);
                updateNQ.ShowDialog();
                if (updateNQ.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(nqBUS.getListNQ());
                    UpdateSuccessNotification tb = new UpdateSuccessNotification();
                    tb.Show();
                }
            }
            if (DGVPhanQuyen.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteNhomQuyenForm deleteNV = new DeleteNhomQuyenForm(NhomQuyenDuocChon);
                deleteNV.ShowDialog();
                if (deleteNV.DialogResult == DialogResult.OK)
                {

                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(nqBUS.getListNQ());
                }
            }
        }
        #region Xử lý tìm kiểm
        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string textSearch = txSearch.Text;
            listNQ = nqBUS.searchNhomQuyen(textSearch);
            refreshDataGridView(listNQ);

        }
        #endregion
        private void refreshDataGridView(BindingList<NhomQuyenDTO> listRefresh) // Tải lại DataGridView
        {
            int soluong =0;
            DGVPhanQuyen.Rows.Clear();
            foreach (NhomQuyenDTO nq in listRefresh.Where( item => item.Trangthai == 1))
            {
                DGVPhanQuyen.Rows.Add($"NQ-{nq.Manhomquyen}", nq.Tennhomquyen, "Hoạt động");
                soluong++;
            }
            lbTotalNV.Text = "Tổng số nhóm quyền: " + soluong.ToString();
            DGVPhanQuyen.ClearSelection();
        }
    }
}
