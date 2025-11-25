using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
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
namespace QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap
{
    public partial class NhaCungCapGUI : Form
    {
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private BindingList<NhaCungCapDTO> listNCC;
        public NhaCungCapGUI()
        {
            InitializeComponent();
            DGVNhaCungCap.ClearSelection();
            DGVNhaCungCap.RowHeadersVisible = false; // Tắt cột header
            DGVNhaCungCap.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVNhaCungCap.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVNhaCungCap.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVNhaCungCap.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVNhaCungCap.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVNhaCungCap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVNhaCungCap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            listNCC = nccBUS.getListNCC();
        }

        private void NhaCungCapGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(listNCC);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void refreshDataGridView(BindingList<NhaCungCapDTO> list)
        {
            DGVNhaCungCap.Rows.Clear();
            int soluong = 0;
            foreach (NhaCungCapDTO ncc in list)
            {
                string trangThai = ncc.Trangthai == 1 ? "Hoạt động" : "Ngừng hoạt động";
                DGVNhaCungCap.Rows.Add(ncc.Mancc, ncc.Tenncc, ncc.Diachincc, ncc.Sdt, ncc.Email, trangThai);
                soluong++;
            }
            DGVNhaCungCap.ClearSelection();
            lbTotalNV.Text = "Tổng số nhà cung cấp: " + soluong.ToString();
        }

        private void DGVNhaCungCap_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        private void DGVNhaCungCap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //e.ColumnIndex, e.RowIndex → xác định cell được click
            //e.Location → vị trí con trỏ chuột trong cell(tọa độ X, Y)
            //e.Button → nút chuột được nhấn
            if (e.ColumnIndex == DGVNhaCungCap.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRelative = e.Location.X; // Tọa độ X của con trỏ chuột trong cell
                // Cells["mancc"] là ô dựa trên dataSource,
                // Column["mancc"] là cột dữ liệu của DGV
                int maNCC = int.Parse(DGVNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString());
                NhaCungCapDTO NhaCungCapDuocChon = nccBUS.getNCCById(maNCC);
                if (xRelative < padding + buttonWidth)
                {
                    UpdateNhaCungCapForm updateNCC = new UpdateNhaCungCapForm(NhaCungCapDuocChon);
                    updateNCC.ShowDialog();
                    if (updateNCC.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                        AddSuccessNotification tb = new AddSuccessNotification();
                        tb.Show();
                    }
                }
                else if (xRelative < padding * 2 + buttonWidth * 2)
                {
                    DeleteNhaCungCapForm deleteNCC = new DeleteNhaCungCapForm(NhaCungCapDuocChon);
                    deleteNCC.ShowDialog();
                    if (deleteNCC.DialogResult == DialogResult.OK)
                    {
                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                        refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                    }
                }
                else
                {
                    DetailNhaCungCapForm detailNCC = new DetailNhaCungCapForm(NhaCungCapDuocChon);
                    detailNCC.ShowDialog();
                }
            }
            {

            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddNhaCungCapForm addNCC = new AddNhaCungCapForm();
            addNCC.ShowDialog();

            if (addNCC.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txSearch.Text;
            listNCC = nccBUS.searchNhaCungCap(text);
            refreshDataGridView(listNCC);
        }

        private void DGVNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maNCC = int.Parse(DGVNhaCungCap.Rows[e.RowIndex].Cells["mancc"].Value.ToString());
            NhaCungCapDTO NhaCungCapDuocChon = nccBUS.getNCCById(maNCC);
            if (DGVNhaCungCap.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailNhaCungCapForm detailNCC = new DetailNhaCungCapForm(NhaCungCapDuocChon);
                detailNCC.ShowDialog();
            }
            else if (DGVNhaCungCap.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateNhaCungCapForm updateNCC = new UpdateNhaCungCapForm(NhaCungCapDuocChon);
                updateNCC.ShowDialog();
                if (updateNCC.DialogResult == DialogResult.OK)
                {
                    refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                    AddSuccessNotification tb = new AddSuccessNotification();
                    tb.Show();
                }
            }else if (DGVNhaCungCap.Columns[e.ColumnIndex].Name == "remove")
            {
                DeleteNhaCungCapForm deleteNCC = new DeleteNhaCungCapForm(NhaCungCapDuocChon);
                deleteNCC.ShowDialog();
                if (deleteNCC.DialogResult == DialogResult.OK)
                {
                    DeleteSuccessNotification tb = new DeleteSuccessNotification();
                    tb.Show();
                    refreshDataGridView(nccBUS.getListNCC()); // load lại danh sách NCC
                }
            }
        }
    }
}
