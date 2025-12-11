using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.Helper;
using QuanLyKho_CSharp.Helper.DropDownSearch;
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

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class AddPhieuKiemKeForm : Form
    {
        private Action btnClose;
        private NhanVienDTO currentUser;
        private SanPhamBUS spBus = new SanPhamBUS();
        private PhieuKiemKeBUS pkkBUS= new PhieuKiemKeBUS();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<ChiTietKiemKeDTO> listCTKKDuocThem=new BindingList<ChiTietKiemKeDTO>();
        public AddPhieuKiemKeForm(Action btnClose, NhanVienDTO currentU)
        {
            InitializeComponent();
            settingDGV();
            this.btnClose = btnClose;
            this.currentUser = currentU;
            txNVTao.Text= $"{currentU.Manv} | {currentU.Tennv}";
            txNVKiem.Text= $"{currentU.Manv} | {currentU.Tennv}";
            listNVTao.Height = 0;
            listNVKiem.Height = 0;
            listSP= spBus.getListSP();
        }
        private void settingDGV()
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
            dgvSPduocThem.ClearSelection();
            dgvSPduocThem.RowHeadersVisible = false;
            dgvSPduocThem.AllowUserToResizeRows = false;
            dgvSPduocThem.AllowUserToAddRows = false;
            dgvSPduocThem.ReadOnly = false;
            dgvSPduocThem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPduocThem.MultiSelect = false;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.ColumnHeadersHeight = 30;
            dgvSPduocThem.RowHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);


            foreach (DataGridViewColumn col in dgvSPduocThem.Columns)
            {
                col.ReadOnly = true;
            }
            
            dgvSPduocThem.Columns["cbbLyDo"].ReadOnly = false;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOnClose_Click(object sender, EventArgs e)
        {
            btnClose();
        }

        private void txNV_TextChanged(object sender, EventArgs e) // Tìm nhân viên tạo
        {
            SearchBarOfStaff(listNVTao, txNVTao);
        }
        private void txNVKiem_TextChanged(object sender, EventArgs e)
        {
            SearchBarOfStaff(listNVKiem, txNVKiem);
        }
        private void SearchBarOfStaff(Panel listContainer, TextBox TxSearch)
        {
            listContainer.AutoScroll = true;
            string textSearch = TxSearch.Text.Trim();
            listContainer.Controls.Clear();
            if (string.IsNullOrEmpty(textSearch))
            {
                listContainer.Height = 0;
                return;
            }
            BindingList<NhanVienDTO> resultList = SearchResultControlStaff.TimKiem(textSearch);
            if (resultList.Count == 0)
            {
                listContainer.Controls.Add(new Label
                {
                    Text = "Không tìm thấy nhân viên",
                    Dock = DockStyle.Top,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                listContainer.Height = 30;
                return;
            }
            foreach (NhanVienDTO nv in resultList)
            {
                var item = new SearchResultControlStaff();
                item.BindData(nv);
                item.Dock = DockStyle.Top;
                item.OnStaffSelected += (objPhatRaSuKien, selectedNV) =>
                {
                    TxSearch.Text = $"{selectedNV.Manv} | {selectedNV.Tennv}";
                    listContainer.Height = 0;
                    TxSearch.SelectionStart = TxSearch.Text.Length;
                };
                listContainer.Controls.Add(item);
            }
            listContainer.Height = Math.Min(resultList.Count * 30 + 10, 120);
        } // Tìm kiếm của nhân viên

        private void txSearch_TextChanged(object sender, EventArgs e) // Tìm kiếm sản phẩm
        {
            string textSearch = txSearch.Text.Trim();
            listContainerProduct.Controls.Clear();
            if (string.IsNullOrEmpty(textSearch))
            {
                listContainerProduct.Height = 0;
                return;
            }
            BindingList<SanPhamDTO> resultList = SearchResultControl.TimKiem(textSearch);
            if (resultList.Count == 0)
            {
                listContainerProduct.Controls.Add(new Label
                {
                    Text = "Không tìm thấy sản phẩm",
                    Dock = DockStyle.Top,
                    Height = 50,
                    TextAlign = ContentAlignment.MiddleCenter,
                });
                listContainerProduct.Height = 50;
                return;
            }
            foreach (SanPhamDTO sp in resultList)
            {
                var item = new SearchResultControl();
                item.BindData(sp);
                item.OnProductSelected += (objPhatRaSuKien, selectedSp) =>
                {
                    txSearch.Text = $"{selectedSp.Tensp}";
                    listContainerProduct.Height = 0;
                    txSearch.SelectionStart = txSearch.Text.Length;
                    ChiTietKiemKeDTO ctkkDuocCHon = new ChiTietKiemKeDTO();
                    ctkkDuocCHon.Masp=selectedSp.Masp;
                    ThemSPVaoPhieu(ctkkDuocCHon);
                };
                listContainerProduct.Controls.Add(item);
            }
            listContainerProduct.Height = Math.Min(resultList.Count * 54 + 10, 300);
        }

        private void ThemSPVaoPhieu(ChiTietKiemKeDTO spDuocChon)
        {
            var existingSP = listCTKKDuocThem.FirstOrDefault(x => x.Masp == spDuocChon.Masp);
            string title = existingSP != null ? "Chỉnh sửa số lượng" : "Nhập số lượng thực tế";
            int soLuongTruyenVao = existingSP != null ? existingSP.Tonthucte : 1;
            int soluongTon = listSP.FirstOrDefault(sp => sp.Masp == spDuocChon.Masp).Soluong;
            var inputForm = new QuantityForm(title, soLuongTruyenVao, soluongTon,"KiemKe");
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int sl = inputForm.Quantity;
                if (existingSP != null)
                {
                    existingSP.Tonthucte = sl;
                }
                else
                {
                    var spKiemKe = new ChiTietKiemKeDTO
                    {
                        Masp = spDuocChon.Masp,
                        Tonthucte = sl
                    };
                    listCTKKDuocThem.Add(spKiemKe);
                }
                LoadDanhSachKiemKe();
            }
            else
            {
                txSearch.Clear();
            }
        }
        private int CalcGiaTriChenhLech(int ton, int thucTe, int gia)
        {
            return (thucTe - ton) * gia;
        }
        private void LoadDanhSachKiemKe()
        {
            dgvSPduocThem.Rows.Clear();
            int stt = 1;
            foreach(ChiTietKiemKeDTO ctkk in listCTKKDuocThem)
            {
                SanPhamDTO spDuocChon = listSP.FirstOrDefault(sp => sp.Masp == ctkk.Masp);
                int tonChiNhanh = spDuocChon.Soluong;
                int giaTriChenhLech = CalcGiaTriChenhLech( tonChiNhanh, ctkk.Tonthucte, spDuocChon.Dongia);
                string gTriChenhLech = giaTriChenhLech > 0 ? $"+{giaTriChenhLech:N0}đ" : $"{giaTriChenhLech:N0}đ";
                string lyDo="";
                if (giaTriChenhLech == 0) lyDo = "Đủ hàng"; 
                if (giaTriChenhLech < 0) lyDo = "Thiếu sản phâm"; 
                if (giaTriChenhLech > 0) lyDo = "Thừa sản phẩm"; 
                Image imageProduct = AddPhieuXuatForm.LoadImageSafe(spDuocChon.Hinhanh);
                dgvSPduocThem.Rows.Add(
                    stt, ctkk.Masp, spDuocChon.Tensp, imageProduct, $"{spDuocChon.Dongia:N0}đ", 
                    tonChiNhanh, ctkk.Tonthucte,
                    tonChiNhanh - ctkk.Tonthucte, gTriChenhLech, lyDo
                    );
                stt++;
                // Nhét dữ liệu vào list để thêm
                ctkk.Tonchinhanh = tonChiNhanh;
                ctkk.Ghichu = lyDo;
                ctkk.Maphieukiemke = pkkBUS.getMaTiepTheo();

            }
            dgvSPduocThem.ClearSelection();
        }

        private void dgvSPduocThem_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (dgvSPduocThem.CurrentRow == null) return;
                var selectedRow = dgvSPduocThem.CurrentRow;
                int maSP = int.Parse(selectedRow.Cells[1].Value.ToString());
                ChiTietKiemKeDTO ctkkDuocChon = listCTKKDuocThem.FirstOrDefault(x => x.Masp == maSP);
                if (ctkkDuocChon == null) return;
                if (dgvSPduocThem.Columns[e.ColumnIndex].Name != "remove" &&
                    dgvSPduocThem.Columns[e.ColumnIndex].Name != "cbbLyDo") ThemSPVaoPhieu(ctkkDuocChon);
                else if (dgvSPduocThem.Columns[e.ColumnIndex].Name == "remove")
                {
                    listCTKKDuocThem.Remove(ctkkDuocChon);
                    LoadDanhSachKiemKe();
                }
            }
        }

        private void artanButton3_Click(object sender, EventArgs e) // Thêm phiếu
        {
            if(listCTKKDuocThem.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng nhập sản phẩm đã kiểm!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            PhieuKiemKeDTO pkNew = new PhieuKiemKeDTO();
            pkNew.Maphieukiemke = pkkBUS.getMaTiepTheo();
            Boolean checkCanBang = true; 
            pkNew.Ghichu = txNote.Text;
            int manvTao = int.Parse(txNVTao.Text.Split('|')[0].Trim());
            int manvKiem = int.Parse(txNVKiem.Text.Split('|')[0].Trim());
            pkNew.Manhanvientao = manvTao;
            pkNew.Manhanvienkiem = manvKiem;
            pkNew.Thoigiantao = DateTime.Now;
            foreach (ChiTietKiemKeDTO ctkk in listCTKKDuocThem)
            {
                if(ctkk.Tonchinhanh < ctkk.Tonthucte || ctkk.Tonchinhanh > ctkk.Tonthucte)
                {
                    checkCanBang = false; break;
                }
            }
            if (!checkCanBang) pkNew.Trangthai = "Chưa cân bằng";
            else { 
                pkNew.Trangthai = "Đã cân bằng";
                pkNew.Thoigiancanbang = DateTime.Now;
            }

           

            // Thêm
            Boolean result= pkkBUS.insertPKK(pkNew, listCTKKDuocThem);
            if (result)
            {
                new AddSuccessNotification().Show();
                listCTKKDuocThem.Clear();
                LoadDanhSachKiemKe();
                txNote.Clear();
                txSearch.Clear();
                dateCreate.Value= DateTime.Now;
                txNVTao.Text = $"{currentUser.Manv} | {currentUser.Tennv}";
                txNVKiem.Text = $"{currentUser.Manv} | {currentUser.Tennv}";
            }


        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                    Title = "Chọn file Excel để nhập"
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = openFileDialog.FileName;

                // Đọc sheet đầu tiên
                DataTable sheet = ReadExcelFile(filePath);

                if (sheet == null || sheet.Rows.Count == 0)
                {
                    MessageBox.Show("File Excel không có dữ liệu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra cấu trúc 2 phần
                if (!CheckExcelStructureForKiemKe(sheet))
                {
                    MessageBox.Show("File Excel không đúng định dạng!\n" +
                                    "Yêu cầu các cột:\n" +
                                    "- Bên trái (Phiếu): Mã phiếu, Nhân viên tạo, Nhân viên kiểm, Thời gian tạo, Thời gian cân bằng, Ghi chú, Trạng thái\n" +
                                    "- Bên phải (Chi tiết): Mã Phiếu, STT, Mã SP, tên sản phẩm, Giá SP, Tồn chi nhánh, Tồn thực tế, SL chênh lệch, giá trị chênh lệch, Lý do",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tách dòng phiếu bên trái
                var excelPhieuRows = new List<DataRow>();
                foreach (DataRow r in sheet.Rows)
                {
                    var maPhieuStr = (r["Mã phiếu"] ?? "").ToString().Trim();
                    var nvTaoStr = (r["Nhân viên tạo"] ?? "").ToString().Trim();
                    var nvKiemStr = (r["Nhân viên kiểm"] ?? "").ToString().Trim();
                    var timeTaoStr = (r["Thời gian tạo"] ?? "").ToString().Trim();
                    var trangThaiStr = (r["Trạng thái"] ?? "").ToString().Trim();

                    if (!string.IsNullOrEmpty(maPhieuStr) &&
                        (!string.IsNullOrEmpty(nvTaoStr) || !string.IsNullOrEmpty(trangThaiStr) || !string.IsNullOrEmpty(timeTaoStr)))
                    {
                        excelPhieuRows.Add(r);
                    }
                }

                if (excelPhieuRows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dòng Phiếu kiểm bên trái!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gom chi tiết theo "Mã Phiếu" bên phải
                var detailsByDisplayMaPhieu = new Dictionary<string, BindingList<ChiTietKiemKeDTO>>(StringComparer.OrdinalIgnoreCase);

                int sanitizeInt(string s)
                {
                    s = (s ?? "").Trim().Replace(".", "").Replace(",", "").Replace("đ", "").Replace("Đ", "");
                    int v;
                    return int.TryParse(s, out v) ? v : 0;
                }

                foreach (DataRow r in sheet.Rows)
                {
                    var maPhieuDisplay = (r["Mã Phiếu"] ?? "").ToString().Trim();
                    var maSpStr = (r["Mã SP"] ?? "").ToString().Trim();
                    var tonCNStr = (r["Tồn chi nhánh"] ?? "").ToString().Trim();
                    var tonTTStr = (r["Tồn thực tế"] ?? "").ToString().Trim();
                    var lyDoStr = (r["Lý do"] ?? "").ToString().Trim();

                    if (string.IsNullOrEmpty(maPhieuDisplay)) continue;
                    if (!int.TryParse(maSpStr, out var maSp)) continue;

                    var dto = new ChiTietKiemKeDTO
                    {
                        Masp = maSp,
                        Tonchinhanh = sanitizeInt(tonCNStr),
                        Tonthucte = sanitizeInt(tonTTStr),
                        Ghichu = lyDoStr
                    };

                    if (!detailsByDisplayMaPhieu.TryGetValue(maPhieuDisplay, out var list))
                    {
                        list = new BindingList<ChiTietKiemKeDTO>();
                        detailsByDisplayMaPhieu[maPhieuDisplay] = list;
                    }
                    list.Add(dto);
                }

                // Helper parse
                DateTime parseDateTimeOrNow(string s)
                {
                    s = (s ?? "").Trim();
                    if (string.IsNullOrEmpty(s)) return DateTime.Now;
                    if (DateTime.TryParse(s, out var dt)) return dt;
                    var parts = s.Split(' ');
                    if (parts.Length == 2 &&
                        DateTime.TryParse(parts[1], out var date) &&
                        TimeSpan.TryParse(parts[0], out var time))
                    {
                        return date.Date + time;
                    }
                    return DateTime.Now;
                }

                Func<string, int?> resolveNhanVienId = (nameOrLabel) =>
                {
                    var s = (nameOrLabel ?? "").Trim();
                    if (string.IsNullOrEmpty(s)) return null;
                    var pipeIdx = s.IndexOf("|", StringComparison.Ordinal);
                    if (pipeIdx > 0 && int.TryParse(s.Substring(0, pipeIdx).Trim(), out var idFromLabel))
                        return idFromLabel;
                    return null; // fallback không resolve được
                };

                // Lưu từng phiếu với chi tiết
                int insertedCount = 0;
                var errors = new StringBuilder();

                foreach (var r in excelPhieuRows)
                {
                    string displayMaPhieu = (r["Mã phiếu"] ?? "").ToString().Trim();
                    string nvTaoStr = (r["Nhân viên tạo"] ?? "").ToString().Trim();
                    string nvKiemStr = (r["Nhân viên kiểm"] ?? "").ToString().Trim();
                    string timeTaoStr = (r["Thời gian tạo"] ?? "").ToString().Trim();
                    string timeCanBangStr = (r["Thời gian cân bằng"] ?? "").ToString().Trim();
                    string ghiChuStr = (r["Ghi chú"] ?? "").ToString().Trim();
                    string trangThaiStr = (r["Trạng thái"] ?? "").ToString().Trim();

                    if (!detailsByDisplayMaPhieu.TryGetValue(displayMaPhieu, out var chiTietList) || chiTietList.Count == 0)
                    {
                        errors.AppendLine($"- Phiếu '{displayMaPhieu}': Không tìm thấy chi tiết ở cột bên phải.");
                        continue;
                    }

                    var pkk = new PhieuKiemKeDTO();
                    pkk.Maphieukiemke = pkkBUS.getMaTiepTheo();

                    foreach (var ct in chiTietList)
                    {
                        ct.Maphieukiemke = pkk.Maphieukiemke;
                    }

                    var pkkThucTe = new QuanLyKho.DTO.PhieuKiemKeDTO
                    {
                        Maphieukiemke = pkk.Maphieukiemke
                    };
                    try
                    {
                        pkkThucTe.GetType().GetProperty("Ghichu")?.SetValue(pkkThucTe, ghiChuStr, null);
                        pkkThucTe.GetType().GetProperty("Trangthai")?.SetValue(pkkThucTe, string.IsNullOrEmpty(trangThaiStr) ? "Chưa cân bằng" : trangThaiStr, null);
                        pkkThucTe.GetType().GetProperty("Thoigiantao")?.SetValue(pkkThucTe, parseDateTimeOrNow(timeTaoStr), null);
                        var manvTao = resolveNhanVienId(nvTaoStr) ?? currentUser.Manv;
                        var manvKiem = resolveNhanVienId(nvKiemStr) ?? currentUser.Manv;
                        pkkThucTe.GetType().GetProperty("Manhanvientao")?.SetValue(pkkThucTe, manvTao, null);
                        pkkThucTe.GetType().GetProperty("Manhanvienkiem")?.SetValue(pkkThucTe, manvKiem, null);

                        var trangthai = (string)pkkThucTe.GetType().GetProperty("Trangthai")?.GetValue(pkkThucTe, null);
                        if (!string.IsNullOrEmpty(timeCanBangStr) &&
                            !string.IsNullOrEmpty(trangthai) &&
                            trangthai.IndexOf("Đã cân bằng", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            pkkThucTe.GetType().GetProperty("Thoigiancanbang")?.SetValue(pkkThucTe, parseDateTimeOrNow(timeCanBangStr), null);
                        }
                    }
                    catch
                    {
                       
                    }

                    try
                    {
                        bool ok = pkkBUS.insertPKK(pkkThucTe, chiTietList);
                        if (!ok)
                        {
                            errors.AppendLine($"- Phiếu '{displayMaPhieu}': Insert thất bại.");
                            continue;
                        }
                        insertedCount++;
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"- Phiếu '{displayMaPhieu}': Lỗi {ex.Message}");
                    }
                }

                listCTKKDuocThem.Clear();
                LoadDanhSachKiemKe();
                txNote.Clear();
                txSearch.Clear();
                dateCreate.Value = DateTime.Now;
                txNVTao.Text = $"{currentUser.Manv} | {currentUser.Tennv}";
                txNVKiem.Text = $"{currentUser.Manv} | {currentUser.Tennv}";

                string message = $"Đã nhập và lưu {insertedCount} phiếu kiểm từ Excel.";
                if (errors.Length > 0)
                {
                    message += "\n\nCác lỗi:\n" + errors.ToString();
                    MessageBox.Show(message, "Kết quả nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(message, "Kết quả nhập Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnClose?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nhập Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1];

                Microsoft.Office.Interop.Excel.Range usedRange = worksheet.UsedRange;
                int rowCount = usedRange.Rows.Count;
                int colCount = usedRange.Columns.Count;

                DataTable dataTable = new DataTable();

                // Header
                for (int col = 1; col <= colCount; col++)
                {
                    string columnName = usedRange.Cells[1, col]?.Value?.ToString() ?? $"Column{col}";
                    dataTable.Columns.Add(columnName);
                }

                // Data
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

        private bool CheckExcelStructureForKiemKe(DataTable dt)
        {
            string[] pHeaders = {
        "Mã phiếu", "Nhân viên tạo", "Nhân viên kiểm",
        "Thời gian tạo", "Thời gian cân bằng", "Ghi chú", "Trạng thái"
    };
            string[] dHeaders = {
        "Mã Phiếu", "STT", "Mã SP", "tên sản phẩm", "Giá SP",
        "Tồn chi nhánh", "Tồn thực tế", "SL chênh lệch", "giá trị chênh lệch", "Lý do"
    };

            foreach (var h in pHeaders)
                if (!dt.Columns.Contains(h)) return false;
            foreach (var h in dHeaders)
                if (!dt.Columns.Contains(h)) return false;

            return true;
        }
    }
    
       
}
