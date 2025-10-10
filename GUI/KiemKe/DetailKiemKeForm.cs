using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho_CSharp.DTO;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class DetailKiemKeForm : Form
    {
        private readonly PhieuKiemKeDTO _dto;

        public DetailKiemKeForm()
        {
            InitializeComponent();
        }

        public DetailKiemKeForm(PhieuKiemKeDTO dto)
        {
            InitializeComponent();
            _dto = dto;  // <-- phải đặt lên trước
            Chitietphieukiem.Visible = true;
            LoadDetailToGrid();  // <-- gọi sau khi _dto đã có giá trị
        }





        // thông tin chi tiết phiếu nhập
        private void LoadDetailToGrid()
        {
            Chitietphieukiem.Rows.Clear();
            Chitietphieukiem.Columns.Clear();

            Chitietphieukiem.Columns.Add("Field", "Thông tin");
            Chitietphieukiem.Columns.Add("Value", "Giá trị");

            Chitietphieukiem.Rows.Add("Mã phiếu kiểm", _dto.Maphieukiemke);
            Chitietphieukiem.Rows.Add("Thời gian tạo", _dto.Thoigiantao.ToString("HH:mm:ss dd/MM/yyyy"));
            Chitietphieukiem.Rows.Add("Trạng thái", _dto.Trangthai == "Đủ" ? "đủ hàng" : _dto.Trangthai);
            Chitietphieukiem.Rows.Add("Ghi chú", _dto.Ghichu);
            Chitietphieukiem.Rows.Add("Mã khu vực", _dto.Makhuvuc);
            Chitietphieukiem.Rows.Add("Tên kho", _dto.TenKho);
            Chitietphieukiem.Rows.Add("Mã nhân viên tạo", _dto.Manhanvientao);
            Chitietphieukiem.Rows.Add("Tên nhân viên tạo", _dto.TenNhanVienTao);
            Chitietphieukiem.Rows.Add("Mã nhân viên kiểm", _dto.Manhanvienkiem);
            Chitietphieukiem.Rows.Add("Tên nhân viên kiểm", _dto.TenNhanVienKiem);
        }





        // nút xác nhận - bấm để tắt dialog
        private void buttonXacNhanChiTiet_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }




        // readonly
        private void label1_Click(object sender, EventArgs e) {}
        private void Chitietphieukiem_CellContentClick(object sender, DataGridViewCellEventArgs e) {}

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {}

        
    }
}
