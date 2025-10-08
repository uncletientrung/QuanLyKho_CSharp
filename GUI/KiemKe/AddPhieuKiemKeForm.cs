using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho_CSharp.GUI.KiemKe;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class AddPhieuKiemKeForm : Form
    {
        // nhận KiemKeGUI là parent
        public AddPhieuKiemKeForm(KiemKeGUI parent = null)
        {
            InitializeComponent();
            parentForm = parent;
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

        // Placeholder logic
        private void ComboBoxTT_GotFocus(object sender, EventArgs e)
        {
            if (comboBoxTT.Text == TrangThaiPlaceholder)
            {
                comboBoxTT.Text = "";
                comboBoxTT.ForeColor = NormalColor;
                comboBoxTT.DroppedDown = true;
            }
        }
        private void ComboBoxTT_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxTT.Text))
            {
                comboBoxTT.Text = TrangThaiPlaceholder;
                comboBoxTT.ForeColor = PlaceholderColor;
            }
        }
        private void ComboBoxTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTT.ForeColor = NormalColor;
        }











        // button xuat phieu kiem ke
        private void buttonXuatPhieuKiemKe_Click(object sender, EventArgs e)
        {
            if (DGVKiemKe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu để kiểm kê!");
                return;
            }

            var row = DGVKiemKe.SelectedRows[0];
            string maPhieu = row.Cells["MaPhieu"].Value.ToString();
            string thoiGian = row.Cells["ThoiGian"].Value.ToString();
            string tenNV = boxNVxuat.Text;
            string maNV = ""; // Lấy mã NV nếu có
            string khuVuc = ""; // Lấy khu vực nếu có
            string trangThai = comboBoxTT.Text;
            int soLuongLech = (int)numericUpDown1.Value;

            // Ghi chú
            string ghiChu = "";
            if (trangThai == "Đủ hàng")
                ghiChu = "đủ hàng";
            else if (trangThai == "Thiếu hàng")
                ghiChu = $"thiếu - {soLuongLech}";
            else if (trangThai == "Dư hàng")
                ghiChu = $"dư - {soLuongLech}";

            // Thêm vào KiemKeGUI
            parentForm?.AddKiemKeRow(maPhieu, thoiGian, tenNV, maNV, khuVuc, trangThai, ghiChu);

            // Xóa dòng khỏi bảng
            DGVKiemKe.Rows.Remove(row);

        }



        private void DGVKiemKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            // Setup trạng thái kiểm kê 
            comboBoxTT.Items.Clear();
            comboBoxTT.Items.AddRange(new object[] { "Đủ hàng", "Thiếu hàng", "Dư hàng" });
            comboBoxTT.Text = TrangThaiPlaceholder;
            comboBoxTT.ForeColor = PlaceholderColor;

            comboBoxTT.GotFocus += ComboBoxTT_GotFocus;
            comboBoxTT.LostFocus += ComboBoxTT_LostFocus;
            comboBoxTT.SelectedIndexChanged += ComboBoxTT_SelectedIndexChanged;
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

        // thanh tìm kiếm
        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text == SearchPlaceholder || string.IsNullOrWhiteSpace(txSearch.Text))
            {
                pull_Phieunhap(sender, e); 
                return;
            }

            string search = txSearch.Text.Trim().ToLower();
            var pnBUS = new QuanLyKho_CSharp.BUS.PhieuNhapBUS();
            var nccBUS = new QuanLyKho_CSharp.BUS.NhaCungCapBUS();
            var list = pnBUS.getListPN();

            DGVKiemKe.Rows.Clear();

            foreach (var pn in list)
            {
                string tenNCC = nccBUS.getNamebyID(pn.Mancc);
                // không phân biệt hoa thường
                if (pn.Maphieu.ToString().Contains(search) || tenNCC.ToLower().Contains(search))
                {
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

        private void labelPrice_Click(object sender, EventArgs e) {}
    }
}
