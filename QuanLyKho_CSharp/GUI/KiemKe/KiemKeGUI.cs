using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuNhap;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.Helper;
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
using ClosedXML.Excel;
using System.Diagnostics;

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class KiemKeGUI : Form
    {
        private NhanVienDTO currentUser;
        private PhieuKiemKeBUS pkkBUS= new PhieuKiemKeBUS();
        private BindingList<PhieuKiemKeDTO> listPKK;
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<NhanVienDTO> listNV;

        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private BindingList<ChiTietQuyenDTO> listCTQ;

        public KiemKeGUI(NhanVienDTO currentUser)
        {
            InitializeComponent();
            listPKK = pkkBUS.getListPKK();
            this.currentUser= currentUser;
            SettingDGV();
            SettingTopPanel();
            refreshDGV(listPKK);
            settingRole();
        }
        private void settingRole() // Xử lý ẩn hiện các nút dựa trên role
        {
            int maNQ = tkBUS.getIdNQByIdNV(currentUser.Manv);
            int maDMNC = dmcnBUS.getIdByNameCN("kiemke");
            var listCT = nqBUS.getListCTNQByIdNQ(maNQ)
                .Where(ctnq => ctnq.Machucnang == maDMNC).ToList();
            listCTQ = new BindingList<ChiTietQuyenDTO>(listCT);
            // Thực hiện ẩn nút
            bool checkThem = false;
            bool checkSua = false;
            bool checkXoa = false;
            foreach (ChiTietQuyenDTO ctq in listCTQ)
            {
                if (ctq.Hanhdong == "Thêm") checkThem = true;
                if (ctq.Hanhdong == "Sửa") checkSua = true;
                if (ctq.Hanhdong == "Xóa") checkXoa = true;
            }
            if (!checkThem)
            {
                btnThem.Visible = false;
            }
            if (!checkSua) DGVPhieuKiem.Columns.Remove("btnCanBang");
            if (!checkXoa) DGVPhieuKiem.Columns.Remove("remove");
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
        private void SettingTopPanel()
        {
            listNV = nvBUS.getListNV();
            cbbSearchNVTao.Items.Add("Nhân viên tạo");
            cbbSearchNVKiem.Items.Add("Nhân viên kiểm");
            foreach(NhanVienDTO nv in  listNV)
            {
                string tenNv = nv.Tennv;
                cbbSearchNVTao.Items.Add(tenNv);
                cbbSearchNVKiem.Items.Add(tenNv);
            }
            cbbSearchNVTao.SelectedIndex = 0;
            cbbSearchNVKiem.SelectedIndex = 0;
            DateTime ngayDauTien = new DateTime(DateTime.Now.Year, 1, 1);
            dateS.Value = ngayDauTien;
            dateE.Value = DateTime.Today;
        }
        private void DanhSachKiemKeGUI_Load(object sender, EventArgs e)
        {
        } // Chưa dùng
        private void refreshDGV(BindingList<PhieuKiemKeDTO> listLoadData)
        {
            DGVPhieuKiem.Rows.Clear();
            int soPKK = 0;
            foreach (PhieuKiemKeDTO pkk in listLoadData)
            {
                if(pkk.Trangthai != "Đã xóa")
                {
                    string NhanVienTao = nvBUS.getNamebyID(pkk.Manhanvientao);
                    string NhanVienKiem = nvBUS.getNamebyID(pkk.Manhanvienkiem);
                    string ThoiGianCanBangStr = pkk.Thoigiancanbang == new DateTime(1, 1, 1)
                                        ? "Chưa cân bằng"
                                        : pkk.Thoigiancanbang.ToString("HH:mm dd/MM/yyyy");
                    int rowIndex = DGVPhieuKiem.Rows.Add(
                        $"PKK-{pkk.Maphieukiemke}", NhanVienTao, NhanVienKiem,
                        pkk.Thoigiantao.ToString(" HH:mm dd/MM/yyyy"),
                        ThoiGianCanBangStr,
                        pkk.Ghichu, pkk.Trangthai);
                    soPKK++;
                    if (DGVPhieuKiem.Columns.Contains("btnCanBang")) // Nếu có trong DGV mới gán
                    {
                        DGVPhieuKiem.Rows[rowIndex].Cells["btnCanBang"].Value =
                            pkk.Trangthai == "Đã cân bằng" ? "Đã cân bằng xong" : "Cân bằng";
                    }
                    SetRowColor(rowIndex, pkk);
                }
            }
            lbTotal.Text = $"Tổng số phiếu kiểm {soPKK}";
            DGVPhieuKiem.ClearSelection();
        }
        private void SetRowColor(int rowIndex, PhieuKiemKeDTO pkk)
        {
            if (DGVPhieuKiem.Rows.Count > rowIndex)
            {
                switch (pkk.Trangthai)
                {
                    case "Đã cân bằng":
                        DGVPhieuKiem.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(152, 251, 152);
                        break;
                    case "Chưa cân bằng":
                        DGVPhieuKiem.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    default:
                        DGVPhieuKiem.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }
                DGVPhieuKiem.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void FilterData()
        {
            listPKK = pkkBUS.getListPKK();
            if (listPKK == null) return;
            var filteredList = listPKK.Where(pkk => pkk.Trangthai != "Đã xóa").AsEnumerable();
            string searchText = txtSearchNV.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredList = filteredList.Where(pkk =>
                        pkk.Maphieukiemke.ToString().Contains(searchText) ||
                        (nvBUS.getNamebyID(pkk.Manhanvientao) ?? "").ToLower().Contains(searchText) ||
                        (nvBUS.getNamebyID(pkk.Manhanvienkiem) ?? "").ToLower().Contains(searchText) ||
                        pkk.Ghichu.ToLower().Contains(searchText) ||
                        pkk.Trangthai.ToLower().Contains(searchText));

            }
            if (cbbSearchNVTao.Text != "Nhân viên tạo")
            {
                filteredList = filteredList.Where(pkk =>
                    nvBUS.getNamebyID(pkk.Manhanvientao) == cbbSearchNVTao.Text);
            }
            if (cbbSearchNVKiem.Text != "Nhân viên kiểm")
            {
                filteredList = filteredList.Where(pkk =>
                    nvBUS.getNamebyID(pkk.Manhanvienkiem) == cbbSearchNVKiem.Text);
            }
            //// Lọc theo khoảng thời gian
            if (dateS.Value != null && dateE.Value != null)
            {
                DateTime startDate = dateS.Value.Date;
                DateTime endDate = dateE.Value.Date.AddDays(1).AddSeconds(-1);
                filteredList = filteredList.Where(pkk =>
                    pkk.Thoigiantao >= startDate && pkk.Thoigiantao <= endDate);
            }
            refreshDGV(new BindingList<PhieuKiemKeDTO>(filteredList.ToList()));
        } // Tìm kiếm
        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cbbSearchNVTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void cbbSearchNVKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dateS_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dateE_ValueChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void DGVPhieuKiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var currentRow = DGVPhieuKiem.CurrentRow;
            int mapkk = int.Parse(currentRow.Cells["mapk"].Value.ToString().Replace("PKK-", ""));

            PhieuKiemKeDTO pkkDTO = pkkBUS.getPKKById(mapkk);
            if (pkkDTO == null) return;

            if (DGVPhieuKiem.Columns[e.ColumnIndex].Name == "remove")
            {
                DeletePhieuKiemKeForm deleteForm = new DeletePhieuKiemKeForm(pkkDTO);
                if(deleteForm.ShowDialog() == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    pkkBUS = new PhieuKiemKeBUS();
                    refreshDGV(pkkBUS.getListPKK());
                }
            }
            else if (DGVPhieuKiem.Columns[e.ColumnIndex].Name == "btnCanBang")
            {
                if(currentRow.Cells["trangthai"].Value.ToString() == "Đã cân bằng")
                {
                    MessageBox.Show("Phiếu này đã cân bằng, không thể thao tác.");
                    return;
                }
                CanBangForm canBangForm = new CanBangForm(pkkDTO);
                if (canBangForm.ShowDialog() == DialogResult.OK)
                {
                    new UpdateSuccessNotification().Show();
                    pkkBUS = new PhieuKiemKeBUS();
                    refreshDGV(pkkBUS.getListPKK());
                }
            }
            else if (DGVPhieuKiem.Columns[e.ColumnIndex].Name == "detail")
            {
                pnlDGV.Visible = false;
                pnlTop.Visible = false;
                DetailPhieuKiemForm addFormControl = null;
                addFormControl = new DetailPhieuKiemForm(() => btnOnCloseDetail(addFormControl), pkkDTO);

                addFormControl.TopLevel = false;
                addFormControl.FormBorderStyle = FormBorderStyle.None;
                addFormControl.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(addFormControl);
                addFormControl.Show();
            }
        } // nút nhấn

        private void btnThem_Click(object sender, EventArgs e) // Thêm phiếu
        {

            pnlDGV.Visible = false;
            pnlTop.Visible = false;
            AddPhieuKiemKeForm addFormControl = null;
            addFormControl = new AddPhieuKiemKeForm(() => btnOnClose(addFormControl), currentUser);

            addFormControl.TopLevel = false;
            addFormControl.FormBorderStyle = FormBorderStyle.None;
            addFormControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(addFormControl);
            addFormControl.Show();

        }
        private void btnOnClose(AddPhieuKiemKeForm formAdd)
        {
            pnlDGV.Visible = true;
            pnlTop.Visible = true;
            pnlMain.Controls.Remove(formAdd);
            formAdd.Dispose();
            pkkBUS = new PhieuKiemKeBUS();
            listPKK = pkkBUS.getListPKK();
            refreshDGV(pkkBUS.getListPKK());
        }
        private void btnOnCloseDetail(DetailPhieuKiemForm formDetail)
        {
            pnlDGV.Visible = true;
            pnlTop.Visible = true;
            pnlMain.Controls.Remove(formDetail);
            formDetail.Dispose();
            pkkBUS = new PhieuKiemKeBUS();
            listPKK = pkkBUS.getListPKK();
            refreshDGV(pkkBUS.getListPKK());
        }

        // Xuất Excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Chọn nơi lưu file Excel";
                sfd.FileName = $"DanhSachKiemKe_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Tạo file Excel mới
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("PhieuKiemKe");
                            // thêm bảng
                            worksheet.Cell(1, 1).Value = "Mã phiếu";
                            worksheet.Cell(1, 2).Value = "Nhân viên tạo";
                            worksheet.Cell(1, 3).Value = "Nhân viên kiểm";
                            worksheet.Cell(1, 4).Value = "Thời gian tạo";
                            worksheet.Cell(1, 5).Value = "Thời gian cân bằng";
                            worksheet.Cell(1, 6).Value = "Ghi chú";
                            worksheet.Cell(1, 7).Value = "Trạng thái";

                            int row = 2;
                            foreach (PhieuKiemKeDTO pkk in listPKK)
                            {
                                if (pkk.Trangthai != "Đã xóa")
                                {
                                    worksheet.Cell(row, 1).Value = $"PKK-{pkk.Maphieukiemke}";
                                    worksheet.Cell(row, 2).Value = nvBUS.getNamebyID(pkk.Manhanvientao);
                                    worksheet.Cell(row, 3).Value = nvBUS.getNamebyID(pkk.Manhanvienkiem);
                                    worksheet.Cell(row, 4).Value = pkk.Thoigiantao.ToString("HH:mm dd/MM/yyyy");
                                    worksheet.Cell(row, 5).Value = pkk.Thoigiancanbang == new DateTime(1, 1, 1)
                                        ? "Chưa cân bằng"
                                        : pkk.Thoigiancanbang.ToString("HH:mm dd/MM/yyyy");
                                    worksheet.Cell(row, 6).Value = pkk.Ghichu;
                                    worksheet.Cell(row, 7).Value = pkk.Trangthai;
                                    row++;
                                }
                            }
                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        Process.Start(sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                    }
                }
            }
        }
    }
}


