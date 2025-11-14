using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.NhanVien;
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

namespace QuanLyKho_CSharp.GUI.KhachHang
{
    public partial class KhachHangGUI : Form
    {

        private KhachHangBUS khBUS = new KhachHangBUS();
        private BindingList<KhachHangDTO> listKH;
        public KhachHangGUI()
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

            listKH = khBUS.getListKH();
        }



        private void DGVKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == DGVKhachHang.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int buttonWidth = 50;
                int padding = 5;
                int xRel = e.Location.X; //Lấy tọa độ X của chuột trong cell
                
                int maKH = int.Parse(DGVKhachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString());
                KhachHangDTO KhachHangDuocChon = khBUS.getKHById(maKH);
                if (xRel < padding + buttonWidth) // kiểm tra trên tọa độ x
                {
                    UpdateKhachHangForm updateKH = new UpdateKhachHangForm(KhachHangDuocChon);
                    updateKH.ShowDialog();
                    if (updateKH.DialogResult == DialogResult.OK)
                    {
                        refreshDataGridView(khBUS.getListKH());
                        UpdateSuccessNotification tb = new UpdateSuccessNotification();
                        tb.Show();
                    }

                }
                else if (xRel < padding * 2 + buttonWidth * 2)
                {
                    DeleteKhachHangForm deleteKH = new DeleteKhachHangForm(KhachHangDuocChon);
                    deleteKH.ShowDialog();
                    if (deleteKH.DialogResult == DialogResult.OK)
                    {

                        DeleteSuccessNotification tb = new DeleteSuccessNotification();
                        tb.Show();
                        refreshDataGridView(khBUS.getListKH());
                    }
                }
                else
                {
                    DetailKhachHangForm detailKH = new DetailKhachHangForm(KhachHangDuocChon);
                    detailKH.ShowDialog();
                }

            }

        }

        private void DGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            refreshDataGridView(khBUS.getListKH());

        }

        private void refreshDataGridView(BindingList<KhachHangDTO> listRefresh) // Tải lại DataGridView
        {
            DGVKhachHang.Rows.Clear();

            foreach (KhachHangDTO kh in listRefresh.Where(kh => kh.Trangthai == 1))
            {
                DGVKhachHang.Rows.Add(kh.Makh, kh.Tenkhachhang, kh.Email, kh.Sdt
                , kh.Ngaysinh.ToString("dd/MM/yyyy"), "Hoạt động");
            }
            DGVKhachHang.ClearSelection();
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
    }
}
