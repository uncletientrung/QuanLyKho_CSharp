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
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xlsx;*.xls",
                    Title = "Chọn file Excel để nhập"
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.DisplayAlerts = false;
                workbook = excelApp.Workbooks.Open(openFileDialog.FileName);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                Microsoft.Office.Interop.Excel.Range usedRange = worksheet.UsedRange;
                int rowCount = usedRange.Rows.Count;
                int colCount = usedRange.Columns.Count;

                // Kiểm tra tối thiểu 4 dòng: 2 dòng info + 1 header detail + 1 dữ liệu
                if (rowCount < 4)
                {
                    MessageBox.Show("File Excel không đúng định dạng (thiếu dữ liệu).", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Func<int, int, string> cell = (r, c) =>
                {
                    object v = usedRange.Cells[r, c]?.Value;
                    return v == null ? "" : v.ToString().Trim();
                };

                // Dòng 1: header thông tin phiếu (không bắt buộc vị trí chính xác, chỉ cần đủ nhãn)
                var infoHeaders = new[] { "Nhân viên tạo", "Nhân viên kiểm", "Thời gian tạo", "Ghi chú" };
                var headersRow1 = new List<string>();
                for (int c = 1; c <= colCount; c++) headersRow1.Add(cell(1, c));
                foreach (var h in infoHeaders)
                {
                    if (!headersRow1.Any(x => string.Equals(x, h, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Thiếu header thông tin phiếu ở dòng 1.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Tìm cột theo tên header ở dòng 1
                Func<string, int> colOfInfo = (name) =>
                {
                    for (int c = 1; c <= colCount; c++)
                        if (string.Equals(cell(1, c), name, StringComparison.OrdinalIgnoreCase)) return c;
                    return -1;
                };

                int colNVTAO = colOfInfo("Nhân viên tạo");
                int colNVKIEM = colOfInfo("Nhân viên kiểm");
                int colTGTAO = colOfInfo("Thời gian tạo");
                int colGHICHU = colOfInfo("Ghi chú");

                string nvTaoStr = cell(2, colNVTAO);
                string nvKiemStr = cell(2, colNVKIEM);
                string tgTaoStr = cell(2, colTGTAO);
                string ghiChuStr = cell(2, colGHICHU);

                DateTime thoigiantao;
                if (string.IsNullOrEmpty(tgTaoStr))
                {
                    thoigiantao = DateTime.Now;
                }
                else
                {
                    if (!DateTime.TryParse(tgTaoStr, out thoigiantao))
                    {
                        // Hỗ trợ định dạng "HH:mm dd/MM/yyyy"
                        var parts = tgTaoStr.Split(' ');
                        if (parts.Length == 2 &&
                            DateTime.TryParse(parts[1], out var d) &&
                            TimeSpan.TryParse(parts[0], out var t))
                        {
                            thoigiantao = d.Date + t;
                        }
                        else
                        {
                            thoigiantao = DateTime.Now;
                        }
                    }
                }

                // Dòng 3: header chi tiết (cố định nhãn)
                var detailHeaders = new[]
                {
            "STT","Mã SP","Tên sản phẩm","Giá SP","Tồn chi nhánh","Tồn thực tế","SL chênh lệch","Giá trị chênh lệch","Lý do"
        };
                var headerCols = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                for (int c = 1; c <= colCount; c++)
                {
                    string h = cell(3, c);
                    if (!string.IsNullOrEmpty(h) && detailHeaders.Any(x => string.Equals(x, h, StringComparison.OrdinalIgnoreCase)))
                        headerCols[h] = c;
                }
                foreach (var h in detailHeaders)
                {
                    if (!headerCols.ContainsKey(h))
                    {
                        MessageBox.Show("Thiếu header chi tiết ở dòng 3.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int parseIntSafe(string s)
                {
                    s = (s ?? "").Trim().Replace(".", "").Replace(",", "").Replace("đ", "").Replace("Đ", "");
                    int v; return int.TryParse(s, out v) ? v : 0;
                }

                var chiTiet = new BindingList<ChiTietKiemKeDTO>();
                int successCount = 0;
                int errorCount = 0;
                var errors = new StringBuilder();

                // Dòng 4 trở đi: dữ liệu chi tiết
                for (int r = 4; r <= rowCount; r++)
                {
                    try
                    {
                        string stt = cell(r, headerCols["STT"]);
                        string maSpStr = cell(r, headerCols["Mã SP"]);
                        if (string.IsNullOrEmpty(maSpStr)) continue;
                        if (!string.IsNullOrEmpty(stt) && !int.TryParse(stt, out _)) { errors.AppendLine($"Dòng {r}: STT không hợp lệ."); errorCount++; continue; }
                        if (!int.TryParse(maSpStr, out var maSp)) { errors.AppendLine($"Dòng {r}: Mã SP không hợp lệ."); errorCount++; continue; }

                        string tonCNStr = cell(r, headerCols["Tồn chi nhánh"]);
                        string tonTTStr = cell(r, headerCols["Tồn thực tế"]);
                        string lyDoStr = cell(r, headerCols["Lý do"]);

                        var dto = new ChiTietKiemKeDTO
                        {
                            Masp = maSp,
                            Tonchinhanh = parseIntSafe(tonCNStr),
                            Tonthucte = parseIntSafe(tonTTStr),
                            Ghichu = lyDoStr
                        };
                        chiTiet.Add(dto);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"Dòng {r}: {ex.Message}");
                        errorCount++;
                    }
                }

                if (chiTiet.Count == 0)
                {
                    MessageBox.Show("Không có chi tiết sản phẩm hợp lệ trong file.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo phiếu và tính trạng thái
                var pkk = new PhieuKiemKeDTO
                {
                    Maphieukiemke = pkkBUS.getMaTiepTheo(),
                    Ghichu = ghiChuStr,
                    Thoigiantao = thoigiantao
                };

                int resolveNV(string s, int fallback)
                {
                    s = (s ?? "").Trim();
                    if (string.IsNullOrEmpty(s)) return fallback;
                    int pipeIdx = s.IndexOf("|", StringComparison.Ordinal);
                    if (pipeIdx > 0 && int.TryParse(s.Substring(0, pipeIdx).Trim(), out var id)) return id;
                    return fallback;
                }
                pkk.Manhanvientao = resolveNV(nvTaoStr, currentUser.Manv);
                pkk.Manhanvienkiem = resolveNV(nvKiemStr, currentUser.Manv);

                bool canBang = chiTiet.All(ct => ct.Tonchinhanh == ct.Tonthucte);
                pkk.Trangthai = canBang ? "Đã cân bằng" : "Chưa cân bằng";
                if (canBang) pkk.Thoigiancanbang = DateTime.Now;

                foreach (var ct in chiTiet) ct.Maphieukiemke = pkk.Maphieukiemke;

                if (!pkkBUS.insertPKK(pkk, chiTiet))
                {
                    MessageBox.Show("Thêm phiếu kiểm từ Excel thất bại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string message = $"Nhập chi tiết thành công: {successCount} dòng";
                if (errorCount > 0) message += $"\nLỗi: {errorCount} dòng\n\n{errors}";
                MessageBox.Show(message, "Kết quả nhập Excel",
                    MessageBoxButtons.OK,
                    errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                // Reset UI
                new AddSuccessNotification().Show();
                listCTKKDuocThem.Clear();
                LoadDanhSachKiemKe();
                txNote.Clear();
                txSearch.Clear();
                dateCreate.Value = DateTime.Now;
                txNVTao.Text = $"{currentUser.Manv} | {currentUser.Tennv}";
                txNVKiem.Text = $"{currentUser.Manv} | {currentUser.Tennv}";
                btnClose?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nhập file Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null)
                {
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
    
       
}
