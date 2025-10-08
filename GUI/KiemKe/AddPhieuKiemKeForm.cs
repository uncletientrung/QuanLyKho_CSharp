using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class AddPhieuKiemKeForm : Form
    {
        public AddPhieuKiemKeForm()
        {
            InitializeComponent();
        }

        // sidebar thong tin nhan vien va ma phieu kiem ke
        // mã
        private void label_maPhieuKiem(object sender, EventArgs e) {}
        private void boxMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        // nhân viên kiểm
        private void label_nhanVienKiem(object sender, EventArgs e) {}
        private void boxNVkiem_TextChanged(object sender, EventArgs e)
        {

        }

        // trạng thái
        private void label_trangthaikiemke(object sender, EventArgs e) {}
        private void comboBoxTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


      








        // button xuat phieu kiem ke
        private void buttonXuatPhieuKiemKe_Click(object sender, EventArgs e)
        {

        }

        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonXuatHang_Click(object sender, EventArgs e)
        {

        }









        // searchplaceholder

        private void AddPhieuKiemKeForm_Load(object sender, EventArgs e)
        {
            DGVKiemKe.RowHeadersVisible = false; // bỏ cột row header
            txSearch.ForeColor = Color.Gray; 
            txSearch.Font = placeholderFont;      
            txSearch.Text = SearchPlaceholder;
            txSearch.GotFocus += txSearch_Enter;
            txSearch.LostFocus += txSearch_Leave;
        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == SearchPlaceholder)
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
                txSearch.Font = normalFont;
            }
        }

        private void txSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txSearch.Text))
            {
                txSearch.Text = SearchPlaceholder;
                txSearch.ForeColor = Color.LightGray;
                txSearch.Font = placeholderFont;
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {

        }

        // pull phiếu nhập
        private void pull_Phieunhap(object sender, EventArgs e)
        {
            DGVKiemKe.Columns.Clear();

            DGVKiemKe.Columns.Add("MaPhieu", "Mã phiếu");
            DGVKiemKe.Columns.Add("TenNCC", "Tên nhà cung cấp");
            DGVKiemKe.Columns.Add("ThoiGian", "Thời gian tạo");
            DGVKiemKe.Columns.Add("TongTien", "Tổng tiền");
            DGVKiemKe.Columns.Add("TrangThai", "Trạng thái");

            foreach (DataGridViewColumn column in DGVKiemKe.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGVKiemKe.Rows.Clear();

            var pnBUS = new QuanLyKho_CSharp.BUS.PhieuNhapBUS();
            var nccBUS = new QuanLyKho_CSharp.BUS.NhaCungCapBUS(); // Giả sử có BUS này
            var list = pnBUS.getListPN();
            if (list != null && list.Count > 0)
            {
                foreach (var pn in list)
                {
                    string tenNCC = nccBUS.getNamebyID(pn.Mancc); // Lấy tên NCC từ mã
                    DGVKiemKe.Rows.Add(
                        pn.Maphieu,
                        tenNCC,
                        pn.Thoigiantao.ToString("dd/MM/yyyy HH:mm"),
                        pn.Tongtien,
                        pn.Trangthai == 1 ? "Hoạt động" : "Đã hủy"
                    );
                }
            }
            DGVKiemKe.ClearSelection();
        }

        // pull phiếu nhập từ excel
        private void pull_PhieunhapExcel(object sender, EventArgs e)
        {

        }


        










        private void labelTongTien_Click(object sender, EventArgs e)
        {

        }









        // readonly font for placeholder
        private void pictureBox1_Click(object sender, EventArgs e) {}
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {}
        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e) {}
        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e) {}
        
        


    }
}
