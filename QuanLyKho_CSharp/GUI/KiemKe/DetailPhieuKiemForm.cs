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

namespace QuanLyKho_CSharp.GUI.KiemKe
{
    public partial class DetailPhieuKiemForm : Form
    {
        private PhieuKiemKeDTO pkkDuocChon;
        private Action btnClose;
        private SanPhamBUS spBus = new SanPhamBUS();
        private PhieuKiemKeBUS pkkBUS = new PhieuKiemKeBUS();
        private NhanVienBUS nvBUS = new NhanVienBUS();
        private BindingList<ChiTietKiemKeDTO> listCTKK;
        public DetailPhieuKiemForm(Action btnClose, PhieuKiemKeDTO pkk)
        {
            InitializeComponent();
            this.btnClose = btnClose;
            pkkDuocChon = pkk;
            settingDGV();
            settingPanelBot();
            LoadDGV();

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
            dgvSPduocThem.ReadOnly = true;
            dgvSPduocThem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPduocThem.MultiSelect = false;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.ColumnHeadersHeight = 30;
            dgvSPduocThem.RowHeadersDefaultCellStyle = headerStyle;
            dgvSPduocThem.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);

        }
        private void settingPanelBot()
        {
            txNVTao.Text = nvBUS.getNamebyID(pkkDuocChon.Manhanvientao).ToString();
            txNVKiem.Text = nvBUS.getNamebyID(pkkDuocChon.Manhanvienkiem).ToString();
            txDateTao.Text = pkkDuocChon.Thoigiantao.ToString("HH:mm dd/MM/yyyy");
            string ThoiGianCanBangStr = pkkDuocChon.Thoigiancanbang == new DateTime(1, 1, 1)
                                        ? "Chưa cân bằng"
                                        : pkkDuocChon.Thoigiancanbang.ToString("HH:mm dd/MM/yyyy");
            txDateCanBang.Text = ThoiGianCanBangStr;
            txNote.Text = pkkDuocChon.Ghichu;
            lbInfo.Text = $"Xem chi tiết phiếu kiểm PKK-{pkkDuocChon.Maphieukiemke}";
            lbCanBang.Text = $"PKK-{pkkDuocChon.Maphieukiemke}  {pkkDuocChon.Trangthai}";

            //Chặn
            txDateTao.Enabled = false;
            txDateCanBang.Enabled = false;
            txNVTao.Enabled = false;
            txNVKiem.Enabled = false;
            txNote.Enabled = false;
        }
        private void btnOnClose_Click(object sender, EventArgs e)
        {
            btnClose();
        }
        private int CalcGiaTriChenhLech(int ton, int thucTe, int gia)
        {
            return (thucTe - ton) * gia;
        }
        private void LoadDGV()
        {
            listCTKK = pkkBUS.getlistCTKKById(pkkDuocChon.Maphieukiemke);
            dgvSPduocThem.Rows.Clear();
            int stt = 1;
            foreach (ChiTietKiemKeDTO ctkk in listCTKK)
            {
                SanPhamDTO spDuocChon = spBus.getSPByIdSP(ctkk.Masp);
                int giaTriChenhLech = CalcGiaTriChenhLech(ctkk.Tonchinhanh, ctkk.Tonthucte,
                    spDuocChon != null ? spDuocChon.Dongia : 0);
                string gTriChenhLech = giaTriChenhLech > 0 ? $"+{giaTriChenhLech:N0}đ" : $"{giaTriChenhLech:N0}đ";
                Image imageProduct = AddPhieuXuatForm.LoadImageSafe(spDuocChon != null ? spDuocChon.Hinhanh : "");
                dgvSPduocThem.Rows.Add(
                    stt, ctkk.Tensp, imageProduct, spDuocChon != null ? $"{spDuocChon.Dongia:N0}đ" : $"Đã xóa",
                    ctkk.Tonchinhanh, ctkk.Tonthucte,
                    ctkk.Tonchinhanh - ctkk.Tonthucte, gTriChenhLech, ctkk.Ghichu
                    );
                stt++;

            }
            dgvSPduocThem.ClearSelection();
        }
    }
}
