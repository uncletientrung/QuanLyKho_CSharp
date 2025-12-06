using QuanLyKho.BUS;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace QuanLyKho_CSharp.GUI.PhieuXuat
{
    public partial class DetailPhieuXuatForm : Form
    {
        private PhieuXuatDTO _phieuXuat;
        private PhieuXuatBUS _phieuXuatBUS = new PhieuXuatBUS();
        private ChiTietPhieuXuatBUS _chiTietPhieuXuatBUS = new ChiTietPhieuXuatBUS();
        private KhachHangBUS _khachHangBUS = new KhachHangBUS();
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        // Constructor nhận tham số PhieuXuatDTO
        public DetailPhieuXuatForm(PhieuXuatDTO phieuXuat)
        {
            InitializeComponent();
            _phieuXuat = phieuXuat;
            LoadDataToForm();
            LoadChiTietPhieuXuat();
            txGiaCu.Text = $"{phieuXuat.Tongtien:N0}đ";
            
            txGiaMoi.Text = $"{LayGiaDonHangSauHoan():N0}đ";
            this.Shown += HoanHang_Shown; // Chặn bôi dòng đầu
        }
        private int LayGiaDonHangSauHoan()
        {
            int result = 0;
            foreach(ChiTietPhieuXuatDTO ctpx in _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_phieuXuat.Maphieu))
            {
                if (ctpx.TrangTHaiHoanHang == 1) result = ctpx.Soluong * ctpx.Dongia;
            }
            return result;
        }
        private void HoanHang_Shown(object sender, EventArgs e)
        {
            dgvXemChiTiet.ClearSelection();
        }

        private void LoadDataToForm()
        {
            if (_phieuXuat != null)
            {
                // Hiển thị thông tin cơ bản của phiếu xuất
                textBox1.Text = _phieuXuat.Maphieu.ToString();
                textBox2.Text = _nhanVienBUS.getNamebyID(_phieuXuat.Manv);
                textBox3.Text = GetTenKhachHang(_phieuXuat.Makh);
                textBox4.Text = _phieuXuat.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void LoadChiTietPhieuXuat()
        {
            if (_phieuXuat != null)
            {
                // Lấy danh sách chi tiết phiếu xuất
                var chiTietPhieuXuat = _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_phieuXuat.Maphieu);

                // Cấu hình DataGridView
                SetupDataGridView();

                // Hiển thị dữ liệu
                DisplayChiTietPhieuXuat(chiTietPhieuXuat);
            }
        }

        private void SetupDataGridView()
        {
            dgvXemChiTiet.Columns.Clear();
            dgvXemChiTiet.Rows.Clear();
            dgvXemChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvXemChiTiet.Columns.Add("STT", "STT");
            dgvXemChiTiet.Columns.Add("MaSP", "Mã SP");
            dgvXemChiTiet.Columns.Add("TenSP", "Tên sản phẩm");
            dgvXemChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvXemChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvXemChiTiet.Columns.Add("ThanhTien", "Thành tiền");
            dgvXemChiTiet.Columns.Add("HoanHang", "Trạng thái");

            // Căn giữa nội dung các ô
            dgvXemChiTiet.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["TenSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["HoanHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Định dạng số
            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            foreach (DataGridViewColumn column in dgvXemChiTiet.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Tỷ lệ cột
            dgvXemChiTiet.Columns["STT"].FillWeight = 8;
            dgvXemChiTiet.Columns["MaSP"].FillWeight = 12;
            dgvXemChiTiet.Columns["TenSP"].FillWeight = 30;
            dgvXemChiTiet.Columns["SoLuong"].FillWeight = 15;
            dgvXemChiTiet.Columns["DonGia"].FillWeight = 15;
            dgvXemChiTiet.Columns["ThanhTien"].FillWeight = 15;
            dgvXemChiTiet.Columns["HoanHang"].FillWeight = 15;

            // Cấu hình khác
            dgvXemChiTiet.ReadOnly = true;
            dgvXemChiTiet.AllowUserToAddRows = false;
            dgvXemChiTiet.AllowUserToDeleteRows = false;
            dgvXemChiTiet.RowHeadersVisible = false;
            dgvXemChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXemChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisplayChiTietPhieuXuat(BindingList<ChiTietPhieuXuatDTO> chiTietList)
        {
            dgvXemChiTiet.Rows.Clear();

            if (chiTietList != null && chiTietList.Count > 0)
            {
                int stt = 1;

                foreach (var chiTiet in chiTietList)
                {
                    string tenSanPham = _sanPhamBUS.getNamebyID(chiTiet.Masp);
                    decimal thanhTien = chiTiet.Soluong * chiTiet.Dongia;
                    string tenTrangTHai = getCTTrangThai(chiTiet);

                    int rowIndex=dgvXemChiTiet.Rows.Add(
                        stt++,
                        chiTiet.Masp,
                        tenSanPham,
                        chiTiet.Soluong,
                        chiTiet.Dongia,
                        thanhTien,
                        tenTrangTHai
                    );
                    SetRowColor(rowIndex, chiTiet);
                }
            }
            else
            {
                MessageBox.Show("Không có chi tiết phiếu xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetTenKhachHang(int maKH)
        {
            try
            {
                return _khachHangBUS.getNamebyID(maKH);
            }
            catch (Exception)
            {
                return "Không tìm thấy";
            }
        }

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo SaveFileDialog để người dùng chọn nơi lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Lưu phiếu xuất";
                saveFileDialog.FileName = $"PhieuXuat_{_phieuXuat.Maphieu}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo document PDF
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Tạo font Unicode (hỗ trợ tiếng Việt)
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font tableHeaderFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font tableContentFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                    // Tiêu đề
                    Paragraph title = new Paragraph("PHIẾU XUẤT KHO", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    document.Add(title);

                    // Thông tin phiếu xuất
                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 100;
                    infoTable.SetWidths(new float[] { 1f, 2f });
                    infoTable.SpacingAfter = 20;

                    infoTable.AddCell(CreateInfoCell("Mã phiếu:", headerFont));
                    infoTable.AddCell(CreateInfoCell(_phieuXuat.Maphieu.ToString(), normalFont));

                    infoTable.AddCell(CreateInfoCell("Nhân viên:", headerFont));
                    infoTable.AddCell(CreateInfoCell(_nhanVienBUS.getNamebyID(_phieuXuat.Manv), normalFont));

                    infoTable.AddCell(CreateInfoCell("Khách hàng:", headerFont));
                    infoTable.AddCell(CreateInfoCell(GetTenKhachHang(_phieuXuat.Makh), normalFont));

                    infoTable.AddCell(CreateInfoCell("Thời gian tạo:", headerFont));
                    infoTable.AddCell(CreateInfoCell(_phieuXuat.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss"), normalFont));

                    document.Add(infoTable);

                    // Tiêu đề chi tiết
                    Paragraph detailTitle = new Paragraph("CHI TIẾT PHIẾU XUẤT", headerFont);
                    detailTitle.SpacingAfter = 10;
                    document.Add(detailTitle);

                    // Bảng chi tiết
                    PdfPTable detailTable = new PdfPTable(6);
                    detailTable.WidthPercentage = 100;
                    detailTable.SetWidths(new float[] { 0.5f, 1f, 3f, 1f, 1.5f, 1.5f });

                    // Header
                    detailTable.AddCell(CreateTableHeaderCell("STT", tableHeaderFont));
                    detailTable.AddCell(CreateTableHeaderCell("Mã SP", tableHeaderFont));
                    detailTable.AddCell(CreateTableHeaderCell("Tên sản phẩm", tableHeaderFont));
                    detailTable.AddCell(CreateTableHeaderCell("Số lượng", tableHeaderFont));
                    detailTable.AddCell(CreateTableHeaderCell("Đơn giá", tableHeaderFont));
                    detailTable.AddCell(CreateTableHeaderCell("Thành tiền", tableHeaderFont));

                    // Lấy dữ liệu từ DataGridView
                    decimal tongTien = 0;
                    for (int i = 0; i < dgvXemChiTiet.Rows.Count; i++)
                    {
                        var row = dgvXemChiTiet.Rows[i];

                        detailTable.AddCell(CreateTableCell(row.Cells["STT"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));
                        detailTable.AddCell(CreateTableCell(row.Cells["MaSP"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));
                        detailTable.AddCell(CreateTableCell(row.Cells["TenSP"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_LEFT));
                        detailTable.AddCell(CreateTableCell(row.Cells["SoLuong"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));

                        decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0);
                        detailTable.AddCell(CreateTableCell(donGia.ToString("N0"), tableContentFont, iTextSharp.text.Element.ALIGN_RIGHT));

                        decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0);
                        detailTable.AddCell(CreateTableCell(thanhTien.ToString("N0"), tableContentFont, iTextSharp.text.Element.ALIGN_RIGHT));

                        tongTien += thanhTien;
                    }

                    document.Add(detailTable);

                    // Tổng tiền
                    Paragraph tongTienPara = new Paragraph($"Tổng tiền: {tongTien.ToString("N0")} VNĐ", headerFont);
                    tongTienPara.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tongTienPara.SpacingBefore = 15;
                    document.Add(tongTienPara);

                    document.Close();
                    writer.Close();

                    MessageBox.Show("Xuất file PDF thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file PDF vừa tạo
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file PDF: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper methods
        private PdfPCell CreateInfoCell(string text, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cell.PaddingBottom = 5;
            return cell;
        }

        private PdfPCell CreateTableHeaderCell(string text, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.BackgroundColor = new BaseColor(200, 200, 200);
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            return cell;
        }

        private PdfPCell CreateTableCell(string text, iTextSharp.text.Font font, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 5;
            return cell;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DetailPhieuXuatForm_Load(object sender, EventArgs e)
        {
        }

        private void dgvXemChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private string getCTTrangThai(ChiTietPhieuXuatDTO ctpx)
        {
            switch (ctpx.TrangTHaiHoanHang)
            {
                case 1: return "Hoạt động";
                case 2: return "Đã hoàn";
                case 0: return "Đã hủy";
                default: return "Không xác định";
            }
        }

        private void SetRowColor(int rowIndex, ChiTietPhieuXuatDTO ctpx)
        {
            if (dgvXemChiTiet.Rows.Count > rowIndex)
            {
                switch (ctpx.TrangTHaiHoanHang)
                {
                    case 2:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case 3:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case 1:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                    default:
                        dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }

                dgvXemChiTiet.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

    }
}