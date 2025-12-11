using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.KhachHang;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.GUI.SanPham;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using QuanLyKho_CSharp.Helper;
using QuanLyKho_CSharp.Helper.DropDownSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class AddPhieuNhapForm : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private ChiTietPhieuNhapBUS ctpnBUS = new ChiTietPhieuNhapBUS();
        private BindingList<NhaCungCapDTO> listNCC;
        private BindingList<SanPhamDTO> listSP;
        private BindingList<SanPhamDTO> listSPDuocThem;
        private Action btnClose;
        private NhanVienDTO currentUser;
        private Action refreshDGVPN;

        public AddPhieuNhapForm(Action btnClose, NhanVienDTO currentUser, Action refreshDGVPN)
        {
            InitializeComponent();
            this.btnClose = btnClose;
            this.currentUser = currentUser;
            this.refreshDGVPN = refreshDGVPN;
            SetupDataGridViews();
            LoadData();
        }

        private void btnOnClose_Click(object sender, EventArgs e)
        {
            refreshDGVPN();
            btnClose?.Invoke(); // Thực hiện delegate
        }

        private void SetupDataGridViews()
        {
            // Thiết lập lại style cho header và row
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            // Cấu hình dgvSPtrongKho
            dgvSPtrongKho.ClearSelection();
            dgvSPtrongKho.RowHeadersVisible = false;
            dgvSPtrongKho.AllowUserToResizeRows = false;
            dgvSPtrongKho.AllowUserToAddRows = false;
            dgvSPtrongKho.ReadOnly = true;
            dgvSPtrongKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPtrongKho.MultiSelect = false;
            dgvSPtrongKho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPtrongKho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPtrongKho.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSPtrongKho.ColumnHeadersHeight = 30;
            dgvSPtrongKho.RowHeadersDefaultCellStyle = headerStyle;
            dgvSPtrongKho.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

            // Cấu hình dgvSPduocThem
            dgvSPduocThem.ClearSelection();
            dgvSPduocThem.RowHeadersVisible = false;
            dgvSPduocThem.AllowUserToResizeRows = false;
            dgvSPduocThem.AllowUserToAddRows = false;
            dgvSPduocThem.ReadOnly = true;
            dgvSPduocThem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPduocThem.MultiSelect = false;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.ColumnHeadersHeight = 30;
            dgvSPduocThem.RowHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
            dgvSPduocThem.Columns[2].ReadOnly = false;

            // set cứng tên người xuất
            txNV.ReadOnly = true;
            txNV.Enabled = false;

            listSPDuocThem = new BindingList<SanPhamDTO>();
        }

        private void LoadData()
        {
            listNCC = nccBUS.getListNCC();
            txNV.Text = currentUser.Tennv.ToString();
            LoadSPTrongKho();
            LoadSPDuocThem();
        }

        private void LoadSPTrongKho()
        {
            listSP = spBUS.getListSP();
            dgvSPtrongKho.Rows.Clear();
            if (listSP != null && listSP.Count > 0)
            {
                foreach (SanPhamDTO sp in listSP)
                {
                    if (sp.Trangthai == 0) continue;

                    Image productImage = LoadImageSafe(sp.Hinhanh);
                    dgvSPtrongKho.Rows.Add(
                        $"SP-{sp.Masp}",
                        sp.Tensp,
                        productImage,
                        sp.Dongia,
                        sp.Soluong
                    );
                }
            }
            dgvSPtrongKho.ClearSelection();
        }

        private void LoadSPDuocThem()
        {
            dgvSPduocThem.Rows.Clear();
            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
            {
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    decimal thanhTien = sp.Dongia * sp.Soluong;
                    dgvSPduocThem.Rows.Add(
                        $"SP-{sp.Masp}",
                        sp.Tensp,
                        sp.Soluong,
                        sp.Dongia,
                        $"{thanhTien:N0}đ"
                    );
                }
            }
            dgvSPduocThem.ClearSelection();
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
            {
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    tongTien += sp.Dongia * sp.Soluong;
                }
            }
            lbPrice.Text = $"{tongTien:N0}đ";
        }

        // Thêm sản phẩm vào phiếu
        private void dgvSPtrongKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvSPtrongKho.CurrentRow == null || dgvSPtrongKho.CurrentRow.IsNewRow)
                    return;
                var selectedRow = dgvSPtrongKho.CurrentRow;
                int maSP = int.Parse(selectedRow.Cells[0].Value.ToString().Replace("SP-",""));
                SanPhamDTO spTrongKho = listSP.FirstOrDefault(x => x.Masp == maSP);
                if (spTrongKho == null) return;

                UpdateQuantity(spTrongKho);
            }
        }

        // Chính sửa số lượng nếu cần
        private void dgvSPduocThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvSPduocThem.CurrentRow == null) return;
                var selectedRow = dgvSPduocThem.CurrentRow;
                int maSP = int.Parse(selectedRow.Cells[0].Value.ToString().Replace("SP-",""));
                SanPhamDTO spDuocChon = listSPDuocThem.FirstOrDefault(x => x.Masp == maSP);
                if (spDuocChon == null) return;
                if (dgvSPduocThem.Columns[e.ColumnIndex].Name != "remove") UpdateQuantity(spDuocChon);
                else if (dgvSPduocThem.Columns[e.ColumnIndex].Name == "remove")
                {
                    listSPDuocThem.Remove(spDuocChon);
                    LoadSPDuocThem();
                }
            }
        }

        private void UpdateQuantity(SanPhamDTO spDuocChon)
        {
            var existingSP = listSPDuocThem.FirstOrDefault(x => x.Masp == spDuocChon.Masp);
            string title = existingSP != null ? "Chỉnh sửa số lượng" : "Nhập số lượng";
            int soLuongTruyenVao = existingSP != null ? existingSP.Soluong : 1;
            int soluongTon = listSP.FirstOrDefault(sp => sp.Masp == spDuocChon.Masp).Soluong;
            var inputForm = new QuantityForm(title, soLuongTruyenVao, soluongTon, "Nhap");
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int sl = inputForm.Quantity;
                if (existingSP != null)
                {
                    existingSP.Soluong = sl;
                }
                else
                {
                    var spMoi = new SanPhamDTO
                    {
                        Masp = spDuocChon.Masp,
                        Tensp = spDuocChon.Tensp,
                        Dongia = spDuocChon.Dongia,
                        Soluong = sl
                    };
                    listSPDuocThem.Add(spMoi);
                }
                LoadSPDuocThem();
            }
            else
            {
                txSearch.Clear();
            }
        }

        private void txSearch_TextChanged(object sender, EventArgs e) // Tìm kiếm sản phẩm
        {
            string textSearch = txSearch.Text.Trim();
            listContainer.Controls.Clear();
            if (string.IsNullOrEmpty(textSearch))
            {
                listContainer.Height = 0;
                return;
            }
            BindingList<SanPhamDTO> resultList = SearchResultControl.TimKiem(textSearch);
            if (resultList.Count == 0)
            {
                listContainer.Controls.Add(new Label
                {
                    Text = "Không tìm thấy sản phẩm",
                    Dock = DockStyle.Top,
                    Height = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                listContainer.Height = 50;
                return;
            }
            foreach (SanPhamDTO sp in resultList)
            {
                var item = new SearchResultControl();
                item.BindData(sp);
                item.OnProductSelected += (objPhatRaSuKien, selectedSp) =>
                {
                    txSearch.Text = $"{selectedSp.Masp} | {selectedSp.Tensp} " + $"| SL: {sp.Soluong} | Giá: {sp.Dongia:N0}đ";
                    listContainer.Height = 0;
                    txSearch.SelectionStart = txSearch.Text.Length;
                    UpdateQuantity(sp);
                };
                listContainer.Controls.Add(item);
            }
            listContainer.Height = Math.Min(resultList.Count * 54 + 10, 300);
        }

        private void txSearchVendor_TextChanged(object sender, EventArgs e) // Tìm nhà cung cấp
        {
            listContainerVendor.AutoScroll = true;
            string textSearch = txSearchVendor.Text.Trim();
            listContainerVendor.Controls.Clear();
            if (string.IsNullOrEmpty(textSearch))
            {
                listContainerVendor.Height = 0;
                return;
            }
            BindingList<NhaCungCapDTO> resultList = SearchResultControlVendor.TimKiem(textSearch);
            if (resultList.Count == 0)
            {
                listContainerVendor.Controls.Add(new Label
                {
                    Text = "Không tìm thấy nhà cung cấp",
                    Dock = DockStyle.Top,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                listContainerVendor.Height = 30;
                return;
            }
            foreach (NhaCungCapDTO ncc in resultList)
            {
                var item = new SearchResultControlVendor();
                item.BindData(ncc);
                item.Dock = DockStyle.Top;
                item.OnCustomerSelected += (objPhatRaSuKien, selectedVendor) =>
                {
                    txSearchVendor.Text = $"{selectedVendor.Mancc} | {selectedVendor.Tenncc} " + $"| SDT: {selectedVendor.Sdt}";
                    lbNameVendor.Text = $"{selectedVendor.Mancc} - {selectedVendor.Tenncc} ";
                    listContainerVendor.Height = 0;
                    txSearchVendor.SelectionStart = txSearchVendor.Text.Length;
                };
                listContainerVendor.Controls.Add(item);
            }
            listContainerVendor.Height = Math.Min(resultList.Count * 30 + 10, 120);
        }

        private void btnNewNCC_Click(object sender, EventArgs e) // Thêm nhà cung cấp
        {
            AddNhaCungCapForm addNCCForm = new AddNhaCungCapForm();
            DialogResult result = addNCCForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                listNCC = nccBUS.getListNCC();
                if (listNCC != null && listNCC.Count > 0)
                {
                    var newestNCC = listNCC.OrderByDescending(ncc => ncc.Mancc).FirstOrDefault();
                    if (newestNCC != null)
                    {
                        txSearchVendor.Text = $"{newestNCC.Mancc} | {newestNCC.Tenncc} " + $"| SDT: {newestNCC.Sdt}";
                        lbNameVendor.Text = $"{newestNCC.Mancc} - {newestNCC.Tenncc} ";
                        listContainerVendor.Height = 0;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e) // Thêm phiếu
        {
            int mancc;
            int manv = currentUser.Manv;
            string labelPrice = lbPrice.Text.Replace("đ", "").Replace(",", "").Trim();
            int tongtien = int.Parse(labelPrice);
            DateTime ngayTao;

            if (listSPDuocThem == null || listSPDuocThem.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lbNameVendor.Text == "Chưa chọn nhà cung cấp")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                mancc = int.Parse(lbNameVendor.Text.Split('-')[0].Trim());
                NhaCungCapDTO kh = nccBUS.getNCCById(mancc);
                if (kh == null)
                {
                    MessageBox.Show("Nhà cung cấp không hợp lệ!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Xử lý ngày
            if (dateCreate.Value.Date == DateTime.Now.Date)
            {
                ngayTao = DateTime.Now;
            }
            else
            {
                ngayTao = dateCreate.Value.Date;
            }
            PhieuNhapDTO newPhieuNhap = new PhieuNhapDTO // Tạo phiếu nhập mới 
            {
                Maphieu = pnBUS.getAutoMaPhieuNhap(),
                Manv = manv,
                Mancc = mancc,
                Thoigiantao = ngayTao,
                Tongtien = tongtien,
                Trangthai = 1
            };

            if (pnBUS.insertPhieuNhap(newPhieuNhap))
            {
                BindingList<ChiTietPhieuNhapDTO> listCTPX = new BindingList<ChiTietPhieuNhapDTO>();
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO
                    {
                        Maphieunhap = newPhieuNhap.Maphieu,
                        Masp = sp.Masp,
                        Soluong = sp.Soluong,
                        Dongia = sp.Dongia,
                        Tensp = sp.Tensp
                    };
                    listCTPX.Add(ctpn);
                }
                if (ctpnBUS.insertChiTietPhieuNhap(listCTPX))
                {
                    UpdateSoLuongSanPhamAfterNhap();
                }
                else
                {
                    pnBUS.removePhieuNhap(newPhieuNhap.Maphieu);
                    MessageBox.Show("Có lỗi xảy ra khi lưu chi tiết phiếu nhập!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo phiếu nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSoLuongSanPhamAfterNhap()
        {
            LoadSPTrongKho(); // Load lại sp trong kho
            listSPDuocThem.Clear();
            LoadSPDuocThem();// Load lại sp dc them
            lbNameVendor.Text = "Chưa chọn nhà cung cấp";
            txSearch.Clear(); txSearchVendor.Clear();
            dateCreate.Value = DateTime.Now;
            AddSuccessNotification tb = new AddSuccessNotification();
            tb.Show();
        }

        private void btnNewClothes_Click(object sender, EventArgs e) // Thêm quần áo mới
        {
            AddSanPhamForm addSPForm = new AddSanPhamForm();
            DialogResult result = addSPForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                listSP = spBUS.getListSP();
                LoadSPTrongKho();
            }
        }

        private void AddPhieuNhapForm_Load(object sender, EventArgs e)
        {
            // Không cần xử lý gì
        }

        // Thêm phương thức LoadImageSafe giống AddPhieuXuatForm
        public static Image LoadImageSafe(string absolutePath)
        {
            if (string.IsNullOrWhiteSpace(absolutePath)) return CreateEmptyImage();
            if (!File.Exists(absolutePath)) return CreateEmptyImage();
            try
            {
                using (var original = Image.FromFile(absolutePath))
                {
                    var resized = new Bitmap(40, 40);
                    using (var g = Graphics.FromImage(resized))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, 40, 40);
                    }
                    return resized;
                }
            }
            catch
            {
                return CreateEmptyImage();
            }
        }

        public static Image CreateEmptyImage() // Ảnh trống
        {
            Bitmap emptyImage = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(emptyImage))
            {
                g.Clear(Color.Gray);
            }
            return emptyImage;
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Chọn file Excel để nhập";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = openFileDialog.FileName;

                // Tạo DataTable từ file Excel
                DataTable dataTable = ReadExcelFile(filePath);

                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("File Excel không có dữ liệu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra cấu trúc file
                if (!CheckExcelStructure(dataTable))
                {
                    MessageBox.Show("File Excel không đúng định dạng!\n" +
                                   "Yêu cầu các cột: Tên sản phẩm, Số lượng, Đơn giá",
                                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nhập dữ liệu
                int successCount = 0;
                int errorCount = 0;
                StringBuilder errors = new StringBuilder();

                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        string tenSP = row["Tên sản phẩm"]?.ToString()?.Trim();
                        string slStr = row["Số lượng"]?.ToString()?.Trim();
                        string giaStr = row["Đơn giá"]?.ToString()?.Trim();

                        if (string.IsNullOrEmpty(tenSP))
                        {
                            errors.AppendLine($"- Dòng {dataTable.Rows.IndexOf(row) + 2}: Thiếu tên sản phẩm");
                            errorCount++;
                            continue;
                        }

                        if (!int.TryParse(slStr, out int soLuong) || soLuong <= 0)
                        {
                            errors.AppendLine($"- Dòng {dataTable.Rows.IndexOf(row) + 2}: Số lượng '{slStr}' không hợp lệ");
                            errorCount++;
                            continue;
                        }

                        if (!int.TryParse(giaStr, out int donGia) || donGia < 0)
                        {
                            errors.AppendLine($"- Dòng {dataTable.Rows.IndexOf(row) + 2}: Đơn giá '{giaStr}' không hợp lệ (phải là số nguyên)");
                            errorCount++;
                            continue;
                        }

                        // Tìm sản phẩm trong kho theo tên
                        SanPhamDTO sanPham = listSP.FirstOrDefault(sp =>
                            sp.Tensp.Equals(tenSP, StringComparison.OrdinalIgnoreCase) && sp.Trangthai == 1);

                        if (sanPham == null)
                        {
                            // KHÔNG tự động thêm sản phẩm mới, thay vào đó thông báo lỗi
                            errors.AppendLine($"- Dòng {dataTable.Rows.IndexOf(row) + 2}: Sản phẩm '{tenSP}' không tồn tại trong hệ thống. Vui lòng thêm sản phẩm trước!");
                            errorCount++;
                            continue;
                        }

                        // Thêm vào danh sách sản phẩm được chọn
                        var existingSP = listSPDuocThem.FirstOrDefault(x => x.Masp == sanPham.Masp);
                        if (existingSP != null)
                        {
                            // Nếu đã có, cộng dồn số lượng
                            existingSP.Soluong += soLuong;
                        }
                        else
                        {
                            var spThem = new SanPhamDTO
                            {
                                Masp = sanPham.Masp,
                                Tensp = sanPham.Tensp,
                                Dongia = donGia,
                                Soluong = soLuong
                            };
                            listSPDuocThem.Add(spThem);
                        }

                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"- Dòng {dataTable.Rows.IndexOf(row) + 2}: Lỗi - {ex.Message}");
                        errorCount++;
                    }
                }

                // Cập nhật giao diện
                LoadSPDuocThem();
                LoadSPTrongKho();

                // Hiển thị kết quả
                string message = $"Đã nhập thành công {successCount} sản phẩm.";
                if (errorCount > 0)
                {
                    message += $"\n\nCó {errorCount} lỗi:\n{errors.ToString()}";

                    // Nếu có lỗi sản phẩm không tồn tại, đề xuất thêm sản phẩm
                    if (errors.ToString().Contains("không tồn tại trong hệ thống"))
                    {
                        message += "\n\nGợi ý: Sử dụng nút 'Thêm quần áo mới' để thêm sản phẩm trước khi nhập Excel.";
                    }
                }

                MessageBox.Show(message, "Kết quả nhập Excel",
                    MessageBoxButtons.OK,
                    errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nhập Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1]; // Lấy sheet đầu tiên

                Excel.Range usedRange = worksheet.UsedRange;
                int rowCount = usedRange.Rows.Count;
                int colCount = usedRange.Columns.Count;

                // Tạo DataTable
                DataTable dataTable = new DataTable();

                // Thêm cột cho header
                for (int col = 1; col <= colCount; col++)
                {
                    string columnName = usedRange.Cells[1, col]?.Value?.ToString() ?? $"Column{col}";
                    dataTable.Columns.Add(columnName);
                }

                // Thêm dữ liệu (bắt đầu từ dòng 2 vì dòng 1 là header)
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    bool hasData = false;

                    for (int col = 1; col <= colCount; col++)
                    {
                        object cellValue = usedRange.Cells[row, col]?.Value;
                        if (cellValue != null)
                        {
                            dataRow[col - 1] = cellValue.ToString();
                            hasData = true;
                        }
                    }

                    if (hasData)
                    {
                        dataTable.Rows.Add(dataRow);
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Giải phóng tài nguyên
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.FinalReleaseComObject(excelApp);
                    excelApp = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private bool CheckExcelStructure(DataTable dataTable)
        {
            // Kiểm tra các cột bắt buộc
            string[] requiredColumns = { "Tên sản phẩm", "Số lượng", "Đơn giá" };

            foreach (string column in requiredColumns)
            {
                if (!dataTable.Columns.Contains(column))
                {
                    return false;
                }
            }

            return true;
        }
    }
}