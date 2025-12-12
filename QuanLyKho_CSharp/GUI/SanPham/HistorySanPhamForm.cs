using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuNhap;
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
        private BindingList<PhieuNhapDTO> listPN;
        private BindingList<ChiTietPhieuNhapDTO> listCTPN;
        private ChiTietPhieuXuatBUS ctpxBUS = new ChiTietPhieuXuatBUS();
        private PhieuXuatBUS pxBUS = new PhieuXuatBUS();
        private ChiTietPhieuNhapBUS ctpnBUS = new ChiTietPhieuNhapBUS();
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private KhachHangBUS khBUS = new KhachHangBUS();
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private string loaiMenu= "Xuất hàng";
        public HistorySanPhamForm(SanPhamDTO _spDuocChon)
        {
            InitializeComponent();
            this.spDuocChon= _spDuocChon;
            // Nạp dữ liệu
            listPX = pxBUS.getListPX();
            listCTPX = ctpxBUS.getCTPXByMaSP(spDuocChon.Masp);
            listPN = pnBUS.getListPN();
            listCTPN = ctpnBUS.getCTPNByMaSP(spDuocChon.Masp);

            SettingDGV();
            SettingPanelTop();
            refreshDGVPX(listCTPX);
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
            if (loaiMenu == "Xuất hàng") { 
                lbTitle.Text = $"Lịch sử xuất sản phẩm SP-{spDuocChon.Masp}";
                DGVHistory.Columns["khachhang"].HeaderText = "Khách hàng";
                DGVHistory.Columns["soluong"].HeaderText = "SL xuất";
            }
            else { 
                lbTitle.Text = $"Lịch sử nhập sản phẩm SP-{spDuocChon.Masp}";
                DGVHistory.Columns["khachhang"].HeaderText = "Nhà cung cấp";
                DGVHistory.Columns["soluong"].HeaderText = "SL nhập";
            }
            lbName.Text = $"Tên sản phẩm: {spDuocChon.Tensp}";
            lbSoLuongTon.Text = $"Số lượng tồn: {spDuocChon.Soluong}";
            lbPrice.Text = $"Giá hiện tại: {spDuocChon.Dongia}";
            Image imgSanpham = AddPhieuXuatForm.LoadImageSafe(spDuocChon.Hinhanh);
            picHinhanh.Image = imgSanpham;
        }
        private void refreshDGVPX(BindingList<ChiTietPhieuXuatDTO> listRefresh)
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
            if(loaiMenu == "Xuất hàng") { 
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
                refreshDGVPX(new BindingList<ChiTietPhieuXuatDTO>(filterData));
            }else if(loaiMenu=="Nhập hàng")
            {
                string nvTao = "";
                string nCC = "";
                PhieuNhapDTO pnDTO = new PhieuNhapDTO();
                var filterData = listCTPN.Where(ctpn =>
                {
                    pnDTO = listPN.FirstOrDefault(pn => pn.Maphieu == ctpn.Maphieunhap);
                    string MaPN = $"PN-{pnDTO.Maphieu}";
                    nvTao = nvBUS.getNamebyID(pnDTO.Manv);
                    nCC = nccBUS.getNamebyID(pnDTO.Mancc);
                    string thanhtien = ((double)ctpn.Soluong * ctpn.Dongia).ToString();
                    string trangthai = "Hoạt động";
                    if (nvTao.ToLower().Contains(key) || nCC.ToLower().Contains(key) || MaPN.ToLower().Contains(key)
                    || thanhtien.ToLower().Contains(key) || ctpn.Soluong.ToString().ToLower().Contains(key)
                    || ctpn.Dongia.ToString().ToLower().Contains(key) || trangthai.ToLower().Contains(key))
                    {
                        return true;
                    }
                    return false;
                }).ToList();
                refreshDGVPN(new BindingList<ChiTietPhieuNhapDTO>(filterData));
            }

        }

        private void refreshDGVPN(BindingList<ChiTietPhieuNhapDTO> listRefresh) // refresh cho phiếu nhập
        {
            int soLuong = 0;
            string nvTao = "";
            string nCC = "";
            PhieuNhapDTO pnDTO = new PhieuNhapDTO();
            DGVHistory.Rows.Clear();
            foreach (ChiTietPhieuNhapDTO ctpn in listRefresh)
            {
                pnDTO = listPN.FirstOrDefault(pn => pn.Maphieu == ctpn.Maphieunhap);
                nvTao = nvBUS.getNamebyID(pnDTO.Manv);
                nCC = nccBUS.getNamebyID(pnDTO.Mancc);
                double thanhtien = (double)ctpn.Soluong * ctpn.Dongia;
                string trangthai ="Hoạt động";
                var rowIndex = DGVHistory.Rows.Add($"PN-{ctpn.Maphieunhap}", nvTao, nCC,
                    pnDTO.Thoigiantao.ToString(" HH:mm dd/MM/yyyy"), ctpn.Soluong,
                    $"{ctpn.Dongia:N0}đ", $"{thanhtien:N0}đ", trangthai);
                soLuong++;
            }
            lbSoLuongPhieu.Text = "Tổng số phiếu: " + soLuong.ToString();
            DGVHistory.ClearSelection();
        }

        private void menuXuatHang_Click(object sender, EventArgs e)
        {
            loaiMenu = "Xuất hàng";
            SettingPanelTop();
            refreshDGVPX(listCTPX);
        }
        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loaiMenu = "Nhập hàng";
            SettingPanelTop();
            refreshDGVPN(listCTPN);
        }

        private void DGVHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int maPhieu = 0;
            if(loaiMenu == "Xuất hàng")
            {
                maPhieu = int.Parse(DGVHistory.Rows[e.RowIndex].Cells["ma"].Value.ToString().Replace("PX-", ""));
                PhieuXuatDTO phieuDuocChon = pxBUS.getPhieuXuatById(maPhieu);
                if (DGVHistory.Columns[e.ColumnIndex].Name == "detail")
                {
                    DetailPhieuXuatForm detailForm = new DetailPhieuXuatForm(phieuDuocChon);
                    detailForm.ShowDialog();
                }
            }else if (loaiMenu == "Nhập hàng")
            {
                maPhieu = int.Parse(DGVHistory.Rows[e.RowIndex].Cells["ma"].Value.ToString().Replace("PN-", ""));
                PhieuNhapDTO phieuDuocChon = pnBUS.getPhieuNhapById(maPhieu);
                if (DGVHistory.Columns[e.ColumnIndex].Name == "detail")
                {
                    DetailPhieuNhapForm detailForm = new DetailPhieuNhapForm(phieuDuocChon);
                    detailForm.ShowDialog();
                }
            }

        }
    }
}
