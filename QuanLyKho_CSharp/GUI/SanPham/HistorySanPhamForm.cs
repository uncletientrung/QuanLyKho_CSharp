using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuXuat;
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

namespace QuanLyKho_CSharp.GUI.SanPham
{
    public partial class HistorySanPhamForm : Form
    {
        private SanPhamDTO spDuocChon;
        private BindingList<PhieuXuatDTO> listPX;
        private BindingList<ChiTietPhieuXuatDTO> listCTPX;
        private ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
        private PhieuXuatBUS pxBUS = new PhieuXuatBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private KhachHangBUS khBUS = new KhachHangBUS();

        public HistorySanPhamForm(SanPhamDTO _spDuocChon)
        {
            InitializeComponent();
            this.spDuocChon= _spDuocChon;
            // Nạp dữ liệu
            listPX = pxBUS.getListPX();
            listCTPX = ctpxBUS.getCTPXByMaSP(spDuocChon.Masp);

            SettingDGV();
            SettingPanelTop();
            refreshDGV(listCTPX);
        }
        private void SettingDGV() // Setting cho DGV
        {
            DGVHistory.ClearSelection();
            DGVHistory.RowHeadersVisible = false;
            DGVHistory.AllowUserToResizeRows = false;
            DGVHistory.AllowUserToAddRows = false;
            DGVHistory.ReadOnly = true;
            DGVHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVHistory.MultiSelect = false;
            DGVHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVHistory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 10F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            DGVHistory.ColumnHeadersDefaultCellStyle = headerStyle;
            DGVHistory.ColumnHeadersHeight = 30;
            DGVHistory.RowHeadersDefaultCellStyle = headerStyle;
            DGVHistory.DefaultCellStyle.Font = new Font("Bahnschrift", 8F, FontStyle.Bold);
        }
        private void SettingPanelTop()
        {
            lbTitle.Text = $"Lịch sử xuất sản phẩm SP-{spDuocChon.Masp}";
            lbName.Text = $"Tên sản phẩm: {spDuocChon.Tensp}";
            lbSoLuongTon.Text = $"Số lượng tồn: {spDuocChon.Soluong}";
            lbPrice.Text = $"Giá hiện tại: {spDuocChon.Dongia}";
            picHinhanh.Image = AddPhieuXuatForm.LoadImageSafe(spDuocChon.Hinhanh);
        }
        private void refreshDGV(BindingList<ChiTietPhieuXuatDTO> listRefresh)
        {
            int soLuong = 0;
            string nvTao = "";
            string khMua = "";
            PhieuXuatDTO pxDTO = new PhieuXuatDTO();
            DGVHistory.Rows.Clear();
            foreach (ChiTietPhieuXuatDTO ctpx in listRefresh)
            {
                if (ctpx.TrangTHaiHoanHang != 0)
                {
                    pxDTO = listPX.FirstOrDefault(px => px.Maphieu == ctpx.Maphieuxuat);
                    nvTao = nvBUS.getNamebyID(pxDTO.Manv);
                    khMua = khBUS.getNamebyID(pxDTO.Makh);
                    double thanhtien = (double)ctpx.Soluong * ctpx.Dongia;
                    string trangthai = ctpx.TrangTHaiHoanHang == 1 ? "Hoạt động" : "Đã hoàn"; 
                    var rowIndex = DGVHistory.Rows.Add($"PX-{ctpx.Maphieuxuat}", nvTao, khMua,
                        pxDTO.Thoigiantao.ToString(" HH:mm dd/MM/yyyy"), ctpx.Soluong, 
                        $"{ctpx.Dongia:N0}đ", $"{thanhtien:N0}đ", trangthai);
                    soLuong++;
                    SetRowColor(rowIndex, ctpx.TrangTHaiHoanHang);
                }
            }
            lbSoLuongPhieu.Text = "Tổng số phiếu: " + soLuong.ToString();
            DGVHistory.ClearSelection();
        }
        private void SetRowColor(int rowIndex, int TrangThaiHoanHang)
        {
            if (DGVHistory.Rows.Count > rowIndex)
            {
                switch (TrangThaiHoanHang)
                {
                    case 2:
                        DGVHistory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 102);
                        break;
                    case 1:
                        DGVHistory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                    default:
                        DGVHistory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        break;
                }

                DGVHistory.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        } // Set màu

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        } // Đóng

        private void txtSearch_TextChanged(object sender, EventArgs e) // Search
        {
            string key = txtSearch.Text.ToLower();
            PhieuXuatDTO pxDTO = new PhieuXuatDTO();
            string nvTao = "";
            string khMua = "";
            var filterData = listCTPX.Where(ctpx =>
            {
                if (ctpx.TrangTHaiHoanHang != 0)
                {
                    pxDTO = listPX.FirstOrDefault(px => px.Maphieu == ctpx.Maphieuxuat);
                    string MaPx = $"PX-{pxDTO.Maphieu}"; 
                    nvTao = nvBUS.getNamebyID(pxDTO.Manv);
                    khMua = khBUS.getNamebyID(pxDTO.Makh);
                    string thanhtien = ((double)ctpx.Soluong * ctpx.Dongia).ToString();
                    string trangthai = ctpx.TrangTHaiHoanHang == 1 ? "Hoạt động" : "Đã hoàn";
                    if(nvTao.ToLower().Contains(key) || khMua.ToLower().Contains(key) || MaPx.ToLower().Contains(key)
                    || thanhtien.ToLower().Contains(key) || ctpx.Soluong.ToString().ToLower().Contains(key)
                    || ctpx.Dongia.ToString().ToLower().Contains(key) || trangthai.ToLower().Contains(key))
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            refreshDGV(new BindingList<ChiTietPhieuXuatDTO>(filterData));
            
        }
    }
}
