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
    public partial class AddNhomQuyenForm : Form
    {
        private List<ChiTietQuyenDTO> ListCTQuyen;
        private DanhMucChucNangBUS dmcnBUS = new DanhMucChucNangBUS();
        private NhomQuyenBUS nqBUS = new NhomQuyenBUS();
        private BindingList<NhomQuyenDTO> ListQuyen;
        public AddNhomQuyenForm()
        {
            InitializeComponent();
            DGVAddNhomQuyen.ClearSelection();
            DGVAddNhomQuyen.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVAddNhomQuyen.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVAddNhomQuyen.AllowUserToAddRows = false;      // chặn thêm dòng
            //DGVAddNhomQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVAddNhomQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVAddNhomQuyen.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVAddNhomQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVAddNhomQuyen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            DGVAddNhomQuyen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; // Chặn kéo cột rowheader
            DGVAddNhomQuyen.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVAddNhomQuyen.ShowCellErrors = false;
            DGVAddNhomQuyen.ShowRowErrors = false;
            // Tắt hết border
            DGVAddNhomQuyen.BorderStyle = BorderStyle.None;
            DGVAddNhomQuyen.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DGVAddNhomQuyen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVAddNhomQuyen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            // Thêm 5 cột
            DataGridViewCheckBoxColumn chkThem = new DataGridViewCheckBoxColumn();
            chkThem.HeaderText = "Thêm";
            chkThem.Name = "Create";
            DGVAddNhomQuyen.Columns.Add(chkThem);
            DGVAddNhomQuyen.Columns["Create"].Width = 70;

            DataGridViewCheckBoxColumn chkSua = new DataGridViewCheckBoxColumn();
            chkSua.HeaderText = "Sửa";
            chkSua.Name = "Update";
            DGVAddNhomQuyen.Columns.Add(chkSua);
            DGVAddNhomQuyen.Columns["Update"].Width = 70;

            DataGridViewCheckBoxColumn chkXoa = new DataGridViewCheckBoxColumn();
            chkXoa.HeaderText = "Xóa";
            chkXoa.Name = "Remove";
            DGVAddNhomQuyen.Columns.Add(chkXoa);
            DGVAddNhomQuyen.Columns["Remove"].Width = 70;

            DataGridViewCheckBoxColumn chkXem = new DataGridViewCheckBoxColumn();
            chkXem.HeaderText = "Xem";
            chkXem.Name = "Detail";
            DGVAddNhomQuyen.Columns.Add(chkXem);

            DataGridViewCheckBoxColumn chkThemNhanh = new DataGridViewCheckBoxColumn();
            chkThemNhanh.HeaderText = "Thêm/ Bỏ nhanh";
            chkThemNhanh.Name = "Fast";
            DGVAddNhomQuyen.Columns.Add(chkThemNhanh);
            DGVAddNhomQuyen.Columns["Fast"].Width = 120;

            DGVAddNhomQuyen.RowHeadersWidth = 120;
            DGVAddNhomQuyen.RowTemplate.Height = 30;

        }


        private void DetailNhomQuyenForm_Load(object sender, EventArgs e)
        {
            // Thêm các checkbok là false hết
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);
            DGVAddNhomQuyen.Rows.Add(false, false, false, false, false);


            // Đặt tên cho rowheader
            DGVAddNhomQuyen.Rows[0].HeaderCell.Value = "Tồn kho";
            DGVAddNhomQuyen.Rows[1].HeaderCell.Value = "Nhập hàng";
            DGVAddNhomQuyen.Rows[2].HeaderCell.Value = "Xuất hàng";
            DGVAddNhomQuyen.Rows[3].HeaderCell.Value = "Thông tin";
            DGVAddNhomQuyen.Rows[4].HeaderCell.Value = "Khách hàng";
            DGVAddNhomQuyen.Rows[5].HeaderCell.Value = "Nhân viên";
            DGVAddNhomQuyen.Rows[6].HeaderCell.Value = "Kiểm kê";
            DGVAddNhomQuyen.Rows[7].HeaderCell.Value = "Báo cáo";
            DGVAddNhomQuyen.Rows[8].HeaderCell.Value = "Tài Khoản";
            DGVAddNhomQuyen.Rows[9].HeaderCell.Value = "Phân quyền";

            // Đặt tag cho rowheader
            DGVAddNhomQuyen.Rows[0].Tag = "tonkho";
            DGVAddNhomQuyen.Rows[1].Tag = "nhaphang";
            DGVAddNhomQuyen.Rows[2].Tag = "xuathang";
            DGVAddNhomQuyen.Rows[3].Tag = "thongtin";
            DGVAddNhomQuyen.Rows[4].Tag = "khachhang";
            DGVAddNhomQuyen.Rows[5].Tag = "nhanvien";
            DGVAddNhomQuyen.Rows[6].Tag = "kiemke";
            DGVAddNhomQuyen.Rows[7].Tag = "baocao";
            DGVAddNhomQuyen.Rows[8].Tag = "taikhoan";
            DGVAddNhomQuyen.Rows[9].Tag = "phanquyen";

            // Chặn 1 số cột
            ChanCacOKhongDung(1, "No", "Yes", "Yes");
        }

        private void ChanCacOKhongDung(int indexRow, string Them = "No",string Sua="No", string Xoa="No")
        { // yes là chặn
            if (Them == "Yes")
                ReplaceCheckboxByTextbox(indexRow, "Create");

            if (Sua == "Yes")
                ReplaceCheckboxByTextbox(indexRow, "Update");

            if (Xoa == "Yes")
                ReplaceCheckboxByTextbox(indexRow, "Remove");
        }
        private void ReplaceCheckboxByTextbox(int row, string col)
        {
            DataGridViewTextBoxCell tb = new DataGridViewTextBoxCell();
            tb.Value = ""; // Ô trống
            tb.Style.BackColor = Color.LightGray;
            tb.Style.SelectionBackColor = Color.LightGray;

            DGVAddNhomQuyen.Rows[row].Cells[col] = tb;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVAddNhomQuyen.Columns["Fast"].Index && e.RowIndex >= 0)
            {
                DGVAddNhomQuyen.CommitEdit(DataGridViewDataErrorContexts.Commit); //Cập nhật giá trị khi vừa tác động
                Boolean TichNhanh = Convert.ToBoolean(DGVAddNhomQuyen.Rows[e.RowIndex].Cells["Fast"].Value);
                foreach (DataGridViewCell cell in DGVAddNhomQuyen.Rows[e.RowIndex].Cells)
                {
                    if (cell.OwningColumn.Name == "Fast") continue;
                    cell.Value = TichNhanh;
                }

            }

        }

        private void DGVAddNhomQuyen_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private List<ChiTietQuyenDTO> getListChiTietQuyen(int manhomquyen)
        {
            List<ChiTietQuyenDTO> result = new List<ChiTietQuyenDTO>();
            for (int i = 0; i < DGVAddNhomQuyen.Rows.Count; i++)
            {
                for (int j = 0; j < DGVAddNhomQuyen.Columns.Count - 1; j++)
                {
                    bool isChecked = Convert.ToBoolean(DGVAddNhomQuyen.Rows[i].Cells[j].Value);
                    if (isChecked) // Nếu đc check thì thêm vào
                    {
                        string CRUD = DGVAddNhomQuyen.Columns[j].HeaderText.ToString();

                        ChiTietQuyenDTO ctqNew = new ChiTietQuyenDTO
                        {
                            Manhomquyen = manhomquyen,
                            Machucnang = dmcnBUS.getIdByNameCN(DGVAddNhomQuyen.Rows[i].Tag.ToString()),
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
                if(ListQuyen.Any(q => q.Tennhomquyen == txtName.Text))
                {
                    MessageBox.Show(
                                "Tên nhóm quyền đã tồn tại",
                                "Lỗi dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                    return;
                }
                int maQuyenTiepTheo = nqBUS.getAutoMaNQ();
                
                string TenQuyen = txtName.Text.ToString();
                ListCTQuyen = getListChiTietQuyen(maQuyenTiepTheo);
                BindingList<ChiTietQuyenDTO> LCTQ = new BindingList<ChiTietQuyenDTO>(ListCTQuyen);
                nqBUS.addNhomQuyen(maQuyenTiepTheo, TenQuyen, LCTQ);
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
    }
}
