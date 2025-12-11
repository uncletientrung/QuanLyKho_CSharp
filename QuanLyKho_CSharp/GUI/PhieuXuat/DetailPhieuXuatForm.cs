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
            foreach (ChiTietPhieuXuatDTO ctpx in _chiTietPhieuXuatBUS.getChiTietByMaPhieuXuat(_phieuXuat.Maphieu))
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
                textBox1.Text = $"PX-{_phieuXuat.Maphieu.ToString()}";
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
            dgvXemChiTiet.Columns.Add("TenSP", "Tên sản phẩm");
            dgvXemChiTiet.Columns.Add("SoLuong", "Số lượng");
            dgvXemChiTiet.Columns.Add("DonGia", "Đơn giá");
            dgvXemChiTiet.Columns.Add("ThanhTien", "Thành tiền");
            dgvXemChiTiet.Columns.Add("HoanHang", "Trạng thái");

            // Căn giữa nội dung các ô
            dgvXemChiTiet.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    //string tenSanPham = _sanPhamBUS.getNamebyID(chiTiet.Masp);
                    decimal thanhTien = chiTiet.Soluong * chiTiet.Dongia;
                    string tenTrangTHai = getCTTrangThai(chiTiet);

                    int rowIndex = dgvXemChiTiet.Rows.Add(
                        stt++,
                        chiTiet.TenSP,
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
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Lưu phiếu xuất";
                saveFileDialog.FileName = $"PhieuXuat_{_phieuXuat.Maphieu}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Font Unicode
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font smallFont = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font tableHeaderFont = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font tableContentFont = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);

                    // HEADER - Logo và thông tin công ty
                    PdfPTable headerTable = new PdfPTable(2);
                    headerTable.WidthPercentage = 50;
                    headerTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerTable.SetWidths(new float[] { 1f, 2f });

                    // Logo
                    string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "khopdf.png");
                    if (File.Exists(logoPath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                        logo.ScaleToFit(60f, 60f);
                        PdfPCell logoCell = new PdfPCell(logo);
                        logoCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        logoCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        logoCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        logoCell.PaddingRight = 5;
                        headerTable.AddCell(logoCell);
                    }
                    else
                    {
                        PdfPCell emptyCell = new PdfPCell(new Phrase("", normalFont));
                        emptyCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        headerTable.AddCell(emptyCell);
                    }

                    // Thông tin công ty
                    Paragraph companyInfo = new Paragraph();
                    companyInfo.Add(new Chunk("HỆ THỐNG\nQUẢN LÝ KHO", titleFont));
                    companyInfo.SetLeading(0, 1.1f);

                    PdfPCell companyCell = new PdfPCell();
                    companyCell.AddElement(companyInfo);
                    companyCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    companyCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    companyCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    companyCell.PaddingLeft = 5;
                    headerTable.AddCell(companyCell);

                    headerTable.SpacingAfter = 5;
                    document.Add(headerTable);

                    // TIÊU ĐỀ
                    Paragraph title = new Paragraph("PHIẾU XUẤT KHO", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    title.SpacingAfter = 5;
                    document.Add(title);

                    // Thông tin phiếu - dạng inline
                    Paragraph infoLine = new Paragraph();
                    infoLine.Add(new Chunk($"Mã số: PX-{_phieuXuat.Maphieu}    -    ", normalFont));
                    infoLine.Add(new Chunk($"Ngày: {_phieuXuat.Thoigiantao:dd} tháng {_phieuXuat.Thoigiantao:MM} năm {_phieuXuat.Thoigiantao:yyyy}", normalFont));
                    infoLine.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    infoLine.SpacingAfter = 10;
                    document.Add(infoLine);

                    // Thông tin nhân viên và khách hàng
                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 100;
                    infoTable.SetWidths(new float[] { 1f, 1f });
                    infoTable.SpacingBefore = 10;
                    infoTable.SpacingAfter = 10;

                    PdfPCell khCell = new PdfPCell(new Phrase($"Khách hàng: {GetTenKhachHang(_phieuXuat.Makh)}", normalFont));
                    khCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    khCell.PaddingTop = 5;
                    khCell.PaddingBottom = 5;
                    infoTable.AddCell(khCell);

                    PdfPCell nvCell = new PdfPCell(new Phrase($"Nhân viên: {_nhanVienBUS.getNamebyID(_phieuXuat.Manv)}", normalFont));
                    nvCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nvCell.PaddingTop = 5;
                    nvCell.PaddingBottom = 5;
                    infoTable.AddCell(nvCell);

                    document.Add(infoTable);

                    // BẢNG CHI TIẾT
                    PdfPTable detailTable = new PdfPTable(7);
                    detailTable.WidthPercentage = 100;
                    detailTable.SetWidths(new float[] { 0.6f, 1f, 2.5f, 0.8f, 1.2f, 1.2f, 1.2f });

                    // Header bảng
                    string[] headers = { "STT", "Mã SP", "Tên sản phẩm", "Số lượng", "Đơn giá", "Thành tiền", "Trạng thái" };
                    foreach (string header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, tableHeaderFont));
                        cell.BackgroundColor = new BaseColor(220, 220, 220);
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        cell.Padding = 5;
                        cell.MinimumHeight = 25f;
                        detailTable.AddCell(cell);
                    }

                    // Dữ liệu
                    decimal tongTien = 0;
                    for (int i = 0; i < dgvXemChiTiet.Rows.Count; i++)
                    {
                        var row = dgvXemChiTiet.Rows[i];

                        // STT
                        detailTable.AddCell(CreateTableCell(row.Cells["STT"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));

                        // Mã SP
                        detailTable.AddCell(CreateTableCell(row.Cells["MaSP"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));

                        // Tên sản phẩm
                        detailTable.AddCell(CreateTableCell(row.Cells["TenSP"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_LEFT));

                        // Số lượng
                        detailTable.AddCell(CreateTableCell(row.Cells["SoLuong"].Value?.ToString() ?? "", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));

                        // Đơn giá
                        decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0);
                        detailTable.AddCell(CreateTableCell(donGia.ToString("N0"), tableContentFont, iTextSharp.text.Element.ALIGN_RIGHT));

                        // Thành tiền
                        decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0);
                        detailTable.AddCell(CreateTableCell(thanhTien.ToString("N0"), tableContentFont, iTextSharp.text.Element.ALIGN_RIGHT));

                        // Trạng thái
                        string trangThai = row.Cells["HoanHang"].Value?.ToString() ?? "";
                        detailTable.AddCell(CreateTableCell(trangThai, tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));

                        tongTien += thanhTien;
                    }

                    // Dòng trống
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            detailTable.AddCell(CreateTableCell("", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));
                        }
                    }

                    // Dòng cộng
                    PdfPCell congCell = new PdfPCell(new Phrase("Tổng cộng:", headerFont));
                    congCell.Colspan = 5;
                    congCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    congCell.Padding = 5;
                    detailTable.AddCell(congCell);

                    detailTable.AddCell(CreateTableCell("", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));
                    detailTable.AddCell(CreateTableCell(tongTien.ToString("N0"), headerFont, iTextSharp.text.Element.ALIGN_RIGHT));

                    document.Add(detailTable);

                    // Chữ ký
                    PdfPTable signTable = new PdfPTable(3);
                    signTable.WidthPercentage = 100;
                    signTable.SetWidths(new float[] { 1f, 1f, 1f });

                    string[] signTitles = { "Người lập phiếu\n(Ký, họ tên)", "Khách hàng\n(Ký, họ tên)", "Thủ kho\n(Ký, họ tên)" };
                    foreach (string signTitle in signTitles)
                    {
                        Paragraph p = new Paragraph(signTitle, normalFont);
                        p.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(p);
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.MinimumHeight = 60f;
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        signTable.AddCell(cell);
                    }

                    document.Add(signTable);

                    document.Close();
                    writer.Close();

                    MessageBox.Show("Xuất file PDF thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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