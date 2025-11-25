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

namespace QuanLyKho_CSharp.GUI.NhomQuyen
{
    public partial class UpdateNhomQuyenForm : Form
    {
        private NhomQuyenDTO NQDuocChon;
        private BindingList<ChiTietQuyenDTO> ListCTQuyen;
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private BindingList<NhomQuyenDTO> ListQuyen;
        public UpdateNhomQuyenForm(NhomQuyenDTO _nq)
        {
            NQDuocChon = _nq;
            InitializeComponent();
            DGVUpdateNhomQuyen.ClearSelection();
            //DGVUpdateNhomQuyen.RowHeadersVisible = false; // Tắt cột header
            DGVUpdateNhomQuyen.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVUpdateNhomQuyen.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVUpdateNhomQuyen.AllowUserToAddRows = false;      // chặn thêm dòng
            //DGVUpdateNhomQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVUpdateNhomQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVUpdateNhomQuyen.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVUpdateNhomQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVUpdateNhomQuyen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            DGVUpdateNhomQuyen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; // Chặn kéo cột rowheader
            DGVUpdateNhomQuyen.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVUpdateNhomQuyen.ShowCellErrors = false;
            DGVUpdateNhomQuyen.ShowRowErrors = false;
            // Tắt hết border
            DGVUpdateNhomQuyen.BorderStyle = BorderStyle.None;
            DGVUpdateNhomQuyen.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DGVUpdateNhomQuyen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVUpdateNhomQuyen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // Cho cái form ở giữa
            this.StartPosition = FormStartPosition.CenterScreen;

            // Thêm 5 cột
            DataGridViewCheckBoxColumn chkThem = new DataGridViewCheckBoxColumn();
            chkThem.HeaderText = "Thêm";
            chkThem.Name = "Create";
            DGVUpdateNhomQuyen.Columns.Add(chkThem);
            DGVUpdateNhomQuyen.Columns["Create"].Width = 70;

            DataGridViewCheckBoxColumn chkSua = new DataGridViewCheckBoxColumn();
            chkSua.HeaderText = "Sửa";
            chkSua.Name = "Update";
            DGVUpdateNhomQuyen.Columns.Add(chkSua);
            DGVUpdateNhomQuyen.Columns["Update"].Width = 70;

            DataGridViewCheckBoxColumn chkXoa = new DataGridViewCheckBoxColumn();
            chkXoa.HeaderText = "Xóa";
            chkXoa.Name = "Remove";
            DGVUpdateNhomQuyen.Columns.Add(chkXoa);
            DGVUpdateNhomQuyen.Columns["Remove"].Width = 70;

            DataGridViewCheckBoxColumn chkXem = new DataGridViewCheckBoxColumn();
            chkXem.HeaderText = "Xem chi tiết";
            chkXem.Name = "Detail";
            DGVUpdateNhomQuyen.Columns.Add(chkXem);

            DataGridViewCheckBoxColumn chkThemNhanh = new DataGridViewCheckBoxColumn();
            chkThemNhanh.HeaderText = "Thêm/ Bỏ nhanh";
            chkThemNhanh.Name = "Fast";
            DGVUpdateNhomQuyen.Columns.Add(chkThemNhanh);
            DGVUpdateNhomQuyen.Columns["Fast"].Width = 120;

            DGVUpdateNhomQuyen.RowHeadersWidth = 120;
            DGVUpdateNhomQuyen.RowTemplate.Height = 30;

            //  Thêm các checkbok là false hết
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVUpdateNhomQuyen.Rows.Add(false, false, false, false, false);

            // Đặt tên cho rowheader
            DGVUpdateNhomQuyen.Rows[0].HeaderCell.Value = "Tồn kho";
            DGVUpdateNhomQuyen.Rows[1].HeaderCell.Value = "Nhập hàng";
            DGVUpdateNhomQuyen.Rows[2].HeaderCell.Value = "Xuất hàng";
            DGVUpdateNhomQuyen.Rows[3].HeaderCell.Value = "Thông tin";
            DGVUpdateNhomQuyen.Rows[4].HeaderCell.Value = "Khách hàng";
            DGVUpdateNhomQuyen.Rows[5].HeaderCell.Value = "Nhân viên";
            DGVUpdateNhomQuyen.Rows[6].HeaderCell.Value = "Kiểm kê";
            DGVUpdateNhomQuyen.Rows[7].HeaderCell.Value = "Báo cáo";
            DGVUpdateNhomQuyen.Rows[8].HeaderCell.Value = "Tài Khoản";
            DGVUpdateNhomQuyen.Rows[9].HeaderCell.Value = "Phân quyền";

            // Đặt tag cho rowheader
            DGVUpdateNhomQuyen.Rows[0].Tag = "tonkho";
            DGVUpdateNhomQuyen.Rows[1].Tag = "nhaphang";
            DGVUpdateNhomQuyen.Rows[2].Tag = "xuathang";
            DGVUpdateNhomQuyen.Rows[3].Tag = "thongtin";
            DGVUpdateNhomQuyen.Rows[4].Tag = "khachhang";
            DGVUpdateNhomQuyen.Rows[5].Tag = "nhanvien";
            DGVUpdateNhomQuyen.Rows[6].Tag = "kiemke";
            DGVUpdateNhomQuyen.Rows[7].Tag = "baocao";
            DGVUpdateNhomQuyen.Rows[8].Tag = "taikhoan";
            DGVUpdateNhomQuyen.Rows[9].Tag = "phanquyen";

            // Show các chức năng đã có
            ListCTQuyen = nqBUS.getListCTNQByIdNQ(NQDuocChon.Manhomquyen);
            ShowDetail(ListCTQuyen);
            
        }

        private void DGVUpdateNhomQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVUpdateNhomQuyen.Columns["Fast"].Index && e.RowIndex >= 0)
            {
                DGVUpdateNhomQuyen.CommitEdit(DataGridViewDataErrorContexts.Commit);
                Boolean TichNhanh = Convert.ToBoolean(DGVUpdateNhomQuyen.Rows[e.RowIndex].Cells["Fast"].Value);
                foreach (DataGridViewCell cell in DGVUpdateNhomQuyen.Rows[e.RowIndex].Cells)
                {
                    if (cell.OwningColumn.Name == "Fast") continue;
                    cell.Value = TichNhanh;
                }

            }
        }
        private BindingList<ChiTietQuyenDTO> getListChiTietQuyen(int manhomquyen)
        {
            BindingList<ChiTietQuyenDTO> result = new BindingList<ChiTietQuyenDTO>();
            for (int i = 0; i < DGVUpdateNhomQuyen.Rows.Count; i++)
            {
                for (int j = 0; j < DGVUpdateNhomQuyen.Columns.Count - 1; j++)
                {
                    bool isChecked = Convert.ToBoolean(DGVUpdateNhomQuyen.Rows[i].Cells[j].Value);
                    if (isChecked) // Nếu đc check thì thêm vào
                    {
                        string CRUD = DGVUpdateNhomQuyen.Columns[j].HeaderText.ToString();

                        ChiTietQuyenDTO ctqNew = new ChiTietQuyenDTO
                        {
                            Manhomquyen = manhomquyen,
                            Machucnang = dmcnBUS.getIdByNameCN(DGVUpdateNhomQuyen.Rows[i].Tag.ToString()),
                            Hanhdong = CRUD,
                            Trangthai = 1
                        };
                        result.Add(ctqNew);
                    }
                }
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                ListQuyen = nqBUS.getListNQ();
                // Dùng Any để foreach nhanh
                bool checkTenNhomQuyen = ListQuyen.Any( nq => nq.Tennhomquyen == txtName.Text
                                         && nq.Manhomquyen != NQDuocChon.Manhomquyen);
                if (checkTenNhomQuyen)
                {
                    MessageBox.Show(
                                "Tên nhóm quyền đã tồn tại",
                                "Lỗi dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                    return;
                }
                NQDuocChon.Tennhomquyen=txtName.Text;
                ListCTQuyen = this.getListChiTietQuyen(NQDuocChon.Manhomquyen);
                nqBUS.UpdateNhomQuyen(NQDuocChon, ListCTQuyen);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(
                             "Tên nhóm quyền không được rỗng",
                             "Lỗi dữ liệu",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                         );
            }
        }
        private void ShowDetail(BindingList<ChiTietQuyenDTO> ListCT)
        {
            txtName.Text= NQDuocChon.Tennhomquyen;
            for (int i = 0; i < DGVUpdateNhomQuyen.Rows.Count; i++)
            {
                for (int j = 0; j < DGVUpdateNhomQuyen.Columns.Count; j++)
                {
                    foreach (ChiTietQuyenDTO ctq in ListCT)
                    {
                        string nameChucNang = dmcnBUS.getNameById(ctq.Machucnang).ToLower();
                        string tagRow = DGVUpdateNhomQuyen.Rows[i].Tag.ToString().ToLower();
                        string headerCRUD = DGVUpdateNhomQuyen.Columns[j].HeaderText.ToLower().ToLower();
                        if (nameChucNang.Equals(tagRow) &&
                           ctq.Hanhdong.ToLower().Equals(headerCRUD)) // Nếu chi tiết = hanhdong 
                        {
                            DGVUpdateNhomQuyen.Rows[i].Cells[j].Value = true;
                        }
                    }
                }
            }
            //DGVUpdateNhomQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVUpdateNhomQuyen.ClearSelection();
        }
    }
}
