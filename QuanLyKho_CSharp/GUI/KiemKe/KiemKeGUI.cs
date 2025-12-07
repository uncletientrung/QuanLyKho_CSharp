using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuNhap;
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

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class KiemKeGUI : Form
    {
        private string _currentUserName; // Thêm field để lưu tên người dùng
        private PhieuKiemKeBUS pkkBUS= new PhieuKiemKeBUS();
        private BindingList<PhieuKiemKeDTO> listPKK;

        public KiemKeGUI(string userName = null)
        {
            InitializeComponent();
            SettingDGV();

        }

        private void SettingDGV()
        {
            DGVPhieuKiem.ClearSelection();
            DGVPhieuKiem.RowHeadersVisible = false; // Tắt cột header
            DGVPhieuKiem.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVPhieuKiem.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVPhieuKiem.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVPhieuKiem.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVPhieuKiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVPhieuKiem.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVPhieuKiem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVPhieuKiem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVPhieuKiem.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVPhieuKiem.ColumnHeadersHeight = 30;
            DGVPhieuKiem.RowHeadersDefaultCellStyle = headerStyle;
            DGVPhieuKiem.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
        }
        private void DanhSachKiemKeGUI_Load(object sender, EventArgs e)
        {
        } // Chưa dùng
        private void refreshDGV()
        {
            listPKK = pkkBUS.getListPKK();
            foreach(PhieuKiemKeDTO pkk in listPKK)
            {

            }
        }

   
    }
}


