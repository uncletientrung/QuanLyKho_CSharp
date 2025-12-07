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
        private Action refreshDGVPKK;
        private NhanVienDTO currentUser;
        private SanPhamBUS spBus = new SanPhamBUS();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<SanPhamDTO> listSPDuocThem=new BindingList<SanPhamDTO>();
        public AddPhieuKiemKeForm(Action btnClose, NhanVienDTO currentU, Action refreshDGVPKK)
        {
            InitializeComponent();
            settingDGV();
            this.btnClose = btnClose;
            this.currentUser = currentU;
            this.refreshDGVPKK = refreshDGVPKK;
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

            // Thêm dữ liệu vào cbb của dgv
            DataGridViewComboBoxColumn cbb = dgvSPduocThem.Columns["cbbLyDo"] as DataGridViewComboBoxColumn;

            if (cbb != null)
            {
                cbb.DataSource = new string[] { "Đủ", "Hư hỏng", "Khác" };
            }
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
                    ThemSPVaoPhieu(selectedSp);
                };
                listContainerProduct.Controls.Add(item);
            }
            listContainerProduct.Height = Math.Min(resultList.Count * 54 + 10, 300);
        }

        private void ThemSPVaoPhieu(SanPhamDTO spDuocChon)
        {
            var existingSP = listSPDuocThem.FirstOrDefault(x => x.Masp == spDuocChon.Masp);
            string title = existingSP != null ? "Chỉnh sửa số lượng" : "Nhập số lượng thực tế";
            int soLuongTruyenVao = existingSP != null ? existingSP.Soluong : 1;
            int soluongTon = listSP.FirstOrDefault(sp => sp.Masp == spDuocChon.Masp).Soluong;
            var inputForm = new QuantityForm(title, soLuongTruyenVao, soluongTon,"KiemKe");
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                int sl = inputForm.Quantity;
                if (existingSP != null)
                {
                    existingSP.Soluong = sl;
                }
                else
                {
                    var spKiemKe = new SanPhamDTO
                    {
                        Masp = spDuocChon.Masp,
                        Tensp = spDuocChon.Tensp,
                        Hinhanh = spDuocChon.Hinhanh,
                        Dongia = spDuocChon.Dongia,
                        Soluong = sl
                    };
                    listSPDuocThem.Add(spKiemKe);
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
            foreach(SanPhamDTO sp in listSPDuocThem)
            {
                int tonChiNhanh = listSP.FirstOrDefault(s => s.Masp == sp.Masp).Soluong;
                int giaTriChenhLech = CalcGiaTriChenhLech( tonChiNhanh, sp.Soluong, sp.Dongia);
                string gTriChenhLech = giaTriChenhLech > 0 ? $"+{giaTriChenhLech:N0}đ" : $"{giaTriChenhLech:N0}đ";
                string lyDo="";
                if (giaTriChenhLech == 0) lyDo = "Đủ hàng"; 
                Image imageProduct = AddPhieuXuatForm.LoadImageSafe(sp.Hinhanh);
                dgvSPduocThem.Rows.Add(
                    stt, sp.Masp, sp.Tensp, imageProduct, $"{sp.Dongia:N0}đ", tonChiNhanh, sp.Soluong,
                    tonChiNhanh - sp.Soluong, gTriChenhLech, lyDo
                    );
                stt++;
                
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
                SanPhamDTO spDuocChon = listSPDuocThem.FirstOrDefault(x => x.Masp == maSP);
                if (spDuocChon == null) return;
                if (dgvSPduocThem.Columns[e.ColumnIndex].Name != "remove") ThemSPVaoPhieu(spDuocChon);
                else if (dgvSPduocThem.Columns[e.ColumnIndex].Name == "remove")
                {
                    listSPDuocThem.Remove(spDuocChon);
                    LoadDanhSachKiemKe();
                }
            }
        }
    }
    
       
}
