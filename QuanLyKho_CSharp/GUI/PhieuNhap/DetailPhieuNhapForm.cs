using iTextSharp.text;
using iTextSharp.text.pdf;
using QuanLyKho.BUS;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class DetailPhieuNhapForm : Form
    {
        private PhieuNhapDTO _phieuNhap;
        private PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private ChiTietPhieuNhapBUS _chiTietPhieuNhapBUS = new ChiTietPhieuNhapBUS();
        private NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        // Constructor nhận tham số PhieuNhapDTO
        public DetailPhieuNhapForm(PhieuNhapDTO phieuNhap)
        {
            InitializeComponent();
            _phieuNhap = phieuNhap;
            LoadDataToForm();
            LoadChiTietPhieuNhap();
        }

        public DetailPhieuNhapForm()
        {
            InitializeComponent();
        }

        private void LoadDataToForm()
        {
            if (_phieuNhap != null)
            {
                // Hiển thị thông tin cơ bản của phiếu nhập
                textBox1.Text = $"PN-{_phieuNhap.Maphieu.ToString()}";
                textBox2.Text = _nhanVienBUS.getNamebyID(_phieuNhap.Manv);
                textBox3.Text = _nhaCungCapBUS.getNamebyID(_phieuNhap.Mancc);
                textBox4.Text = _phieuNhap.Thoigiantao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void LoadChiTietPhieuNhap()
        {
            if (_phieuNhap != null)
            {
                // Lấy danh sách chi tiết phiếu nhập
                var chiTietPhieuNhap = _chiTietPhieuNhapBUS.getChiTietByMaPhieuNhap(_phieuNhap.Maphieu);

                // Cấu hình DataGridView
                SetupDataGridView();

                // Hiển thị dữ liệu
                DisplayChiTietPhieuNhap(chiTietPhieuNhap);
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

            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvXemChiTiet.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["TenSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvXemChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn column in dgvXemChiTiet.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvXemChiTiet.Columns["STT"].FillWeight = 8;
            dgvXemChiTiet.Columns["MaSP"].FillWeight = 12;
            dgvXemChiTiet.Columns["TenSP"].FillWeight = 35;
            dgvXemChiTiet.Columns["SoLuong"].FillWeight = 15;
            dgvXemChiTiet.Columns["DonGia"].FillWeight = 15;
            dgvXemChiTiet.Columns["ThanhTien"].FillWeight = 15;

            dgvXemChiTiet.ReadOnly = true;
            dgvXemChiTiet.AllowUserToAddRows = false;
            dgvXemChiTiet.AllowUserToDeleteRows = false;
            dgvXemChiTiet.RowHeadersVisible = false;
            dgvXemChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXemChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisplayChiTietPhieuNhap(BindingList<ChiTietPhieuNhapDTO> chiTietList)
        {
            dgvXemChiTiet.Rows.Clear();

            if (chiTietList != null && chiTietList.Count > 0)
            {
                int stt = 1;

                foreach (var chiTiet in chiTietList)
                {
                    // Lấy tên sản phẩm bằng getNamebyID
                    string tenSanPham = _sanPhamBUS.getNamebyID(chiTiet.Masp);

                    decimal thanhTien = chiTiet.Soluong * chiTiet.Dongia;

                    dgvXemChiTiet.Rows.Add(
                        stt++,
                        $"SP-{chiTiet.Masp}",
                        tenSanPham,
                        chiTiet.Soluong,
                        chiTiet.Dongia,
                        thanhTien
                    );
                }
            }
            else
            {
                MessageBox.Show("Không có chi tiết phiếu nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                saveFileDialog.Title = "Lưu phiếu nhập";
                saveFileDialog.FileName = $"PhieuNhap_{_phieuNhap.Maphieu}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

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
                    headerTable.WidthPercentage = 50; // Giảm độ rộng table để logo và text gần nhau
                    headerTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    headerTable.SetWidths(new float[] { 1f, 2f });

                    // Logo
                    string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "khopdf.png");
                    if (File.Exists(logoPath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                        logo.ScaleToFit(60f, 60f); // Giảm kích thước logo
                        PdfPCell logoCell = new PdfPCell(logo);
                        logoCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        logoCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        logoCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        logoCell.PaddingRight = 5; // Padding nhỏ để sát text
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
                    companyCell.PaddingLeft = 5; // Padding nhỏ để sát logo
                    headerTable.AddCell(companyCell);

                    headerTable.SpacingAfter = 5;
                    document.Add(headerTable);

                    // TIÊU ĐỀ
                    Paragraph title = new Paragraph("PHIẾU NHẬP KHO", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    title.SpacingAfter = 5;
                    document.Add(title);

                    // Thông tin phiếu - dạng inline
                    Paragraph infoLine = new Paragraph();
                    infoLine.Add(new Chunk($"Mã số: PN-{_phieuNhap.Maphieu}    -    ", normalFont));
                    infoLine.Add(new Chunk($"Ngày: {_phieuNhap.Thoigiantao:dd} tháng {_phieuNhap.Thoigiantao:MM} năm {_phieuNhap.Thoigiantao:yyyy}", normalFont));
                    infoLine.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    infoLine.SpacingAfter = 10;
                    document.Add(infoLine);

                    // Thông tin nhà cung cấp và nhân viên
                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 100;
                    infoTable.SetWidths(new float[] { 1f, 1f });
                    infoTable.SpacingBefore = 10;
                    infoTable.SpacingAfter = 10;

                    PdfPCell nccCell = new PdfPCell(new Phrase($"Nhà cung cấp: {_nhaCungCapBUS.getNamebyID(_phieuNhap.Mancc)}", normalFont));
                    nccCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nccCell.PaddingTop = 5;
                    nccCell.PaddingBottom = 5;
                    infoTable.AddCell(nccCell);

                    PdfPCell nvCell = new PdfPCell(new Phrase($"Nhân viên: {_nhanVienBUS.getNamebyID(_phieuNhap.Manv)}", normalFont));
                    nvCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nvCell.PaddingTop = 5;
                    nvCell.PaddingBottom = 5;
                    infoTable.AddCell(nvCell);

                    document.Add(infoTable);

                    // BẢNG CHI TIẾT
                    PdfPTable detailTable = new PdfPTable(6);
                    detailTable.WidthPercentage = 100;
                    detailTable.SetWidths(new float[] { 0.7f, 1f, 3f, 1f, 1.5f, 1.5f });

                    // Header bảng
                    string[] headers = { "STT", "Mã SP", "Tên sản phẩm", "Số lượng", "Đơn giá", "Thành tiền" };
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

                        tongTien += thanhTien;
                    }

                    // Dòng trống
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            detailTable.AddCell(CreateTableCell("", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));
                        }
                    }

                    // Dòng cộng
                    PdfPCell congCell = new PdfPCell(new Phrase("Tổng cộng:", headerFont));
                    congCell.Colspan = 4;
                    congCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    congCell.Padding = 5;
                    detailTable.AddCell(congCell);

                    detailTable.AddCell(CreateTableCell("", tableContentFont, iTextSharp.text.Element.ALIGN_CENTER));
                    detailTable.AddCell(CreateTableCell(tongTien.ToString("N0"), headerFont, iTextSharp.text.Element.ALIGN_RIGHT));

                    document.Add(detailTable);

                    // Chữ ký
                    PdfPTable signTable = new PdfPTable(4);
                    signTable.WidthPercentage = 100;
                    signTable.SetWidths(new float[] { 1f, 1f, 1f, 1f });

                    string[] signTitles = { "Người lập phiếu\n(Ký, họ tên)", "Người giao hàng\n(Ký, họ tên)", "Người nhận hàng\n(Ký, họ tên)", "Người vận chuyển\n(Ký, họ tên)" };
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DetailPhieuNhapForm_Load(object sender, EventArgs e)
        {
        }

        private void dgvXemChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}