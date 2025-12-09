using Org.BouncyCastle.Crypto.Parameters;
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
    public partial class DetailNhomQuyenForm : Form
    {
        private NhomQuyenDTO nq;
        private BindingList<ChiTietQuyenDTO> ListCTNQ;
        private NhomQuyenBUS nqBUS=new NhomQuyenBUS();
        private DanhMucChucNangBUS dmncBUS= new DanhMucChucNangBUS();
        public DetailNhomQuyenForm(NhomQuyenDTO _nq)
        {
            InitializeComponent();
            nq = _nq;
                
            txtName.Text = nq.Tennhomquyen;
            DGVDetailNhomQuyen.ClearSelection();
            //DGVDetailNhomQuyen.RowHeadersVisible = false; // Tắt cột header
            DGVDetailNhomQuyen.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVDetailNhomQuyen.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVDetailNhomQuyen.AllowUserToAddRows = false;      // chặn thêm dòng
            //DGVDetailNhomQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVDetailNhomQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVDetailNhomQuyen.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVDetailNhomQuyen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVDetailNhomQuyen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa
            DGVDetailNhomQuyen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing; // Chặn kéo cột rowheader
            DGVDetailNhomQuyen.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVDetailNhomQuyen.ShowCellErrors = false;
            DGVDetailNhomQuyen.ShowRowErrors = false;
            // Tắt hết border
            DGVDetailNhomQuyen.BorderStyle = BorderStyle.None;
            DGVDetailNhomQuyen.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DGVDetailNhomQuyen.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVDetailNhomQuyen.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            txtName.Enabled = false;


            // Thêm 5 cột
            DataGridViewCheckBoxColumn chkThem = new DataGridViewCheckBoxColumn();
            chkThem.HeaderText = "Thêm";
            chkThem.Name = "Create";
            DGVDetailNhomQuyen.Columns.Add(chkThem);
            DGVDetailNhomQuyen.Columns["Create"].Width = 100;

            DataGridViewCheckBoxColumn chkSua = new DataGridViewCheckBoxColumn();
            chkSua.HeaderText = "Sửa";
            chkSua.Name = "Update";
            DGVDetailNhomQuyen.Columns.Add(chkSua);
            DGVDetailNhomQuyen.Columns["Update"].Width = 100;

            DataGridViewCheckBoxColumn chkXoa = new DataGridViewCheckBoxColumn();
            chkXoa.HeaderText = "Xóa";
            chkXoa.Name = "Remove";
            DGVDetailNhomQuyen.Columns.Add(chkXoa);
            DGVDetailNhomQuyen.Columns["Remove"].Width = 100;

            DataGridViewCheckBoxColumn chkXem = new DataGridViewCheckBoxColumn();
            chkXem.HeaderText = "Xem";
            chkXem.Name = "Detail";
            DGVDetailNhomQuyen.Columns.Add(chkXem);
            DGVDetailNhomQuyen.Columns["Detail"].Width = 135;

            DGVDetailNhomQuyen.RowHeadersWidth = 120;
            DGVDetailNhomQuyen.RowTemplate.Height = 30;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DetailNhomQuyenForm_Load(object sender, EventArgs e)
        {
            // Thêm các checkbok là false hết
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);
            DGVDetailNhomQuyen.Rows.Add(false, false, false, false);


            // Đặt tên cho rowheader
            DGVDetailNhomQuyen.Rows[0].HeaderCell.Value = "Tồn kho";
            DGVDetailNhomQuyen.Rows[1].HeaderCell.Value = "Nhập hàng";
            DGVDetailNhomQuyen.Rows[2].HeaderCell.Value = "Xuất hàng";
            DGVDetailNhomQuyen.Rows[3].HeaderCell.Value = "Thông tin";
            DGVDetailNhomQuyen.Rows[4].HeaderCell.Value = "Khách hàng";
            DGVDetailNhomQuyen.Rows[5].HeaderCell.Value = "Nhân viên";
            DGVDetailNhomQuyen.Rows[6].HeaderCell.Value = "Kiểm kê";
            DGVDetailNhomQuyen.Rows[7].HeaderCell.Value = "Báo cáo";
            DGVDetailNhomQuyen.Rows[8].HeaderCell.Value = "Tài Khoản";
            DGVDetailNhomQuyen.Rows[9].HeaderCell.Value = "Phân quyền";

            // Đặt tag cho rowheader
            DGVDetailNhomQuyen.Rows[0].Tag = "tonkho";
            DGVDetailNhomQuyen.Rows[1].Tag = "nhaphang";
            DGVDetailNhomQuyen.Rows[2].Tag = "xuathang";
            DGVDetailNhomQuyen.Rows[3].Tag = "thongtin";
            DGVDetailNhomQuyen.Rows[4].Tag = "khachhang";
            DGVDetailNhomQuyen.Rows[5].Tag = "nhanvien";
            DGVDetailNhomQuyen.Rows[6].Tag = "kiemke";
            DGVDetailNhomQuyen.Rows[7].Tag = "baocao";
            DGVDetailNhomQuyen.Rows[8].Tag = "taikhoan";
            DGVDetailNhomQuyen.Rows[9].Tag = "phanquyen";

            // Hiển thị các checkbox được chọn
            ListCTNQ = nqBUS.getListCTNQByIdNQ(nq.Manhomquyen);
            ShowDetail(ListCTNQ);
           
        }

        private void DGVDetailNhomQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ShowDetail(BindingList<ChiTietQuyenDTO> ListCT)
        {
            for(int i=0; i< DGVDetailNhomQuyen.Rows.Count; i++)
            {
                for (int j=0; j< DGVDetailNhomQuyen.Columns.Count; j++)
                {
                    foreach( ChiTietQuyenDTO ctq in ListCT)
                    {
                        string nameChucNang = dmncBUS.getNameById(ctq.Machucnang).ToLower();
                        string tagRow= DGVDetailNhomQuyen.Rows[i].Tag.ToString().ToLower();
                        string headerCRUD = DGVDetailNhomQuyen.Columns[j].HeaderText.ToLower().ToLower();
                        if(nameChucNang.Equals(tagRow) && 
                           ctq.Hanhdong.ToLower().Equals(headerCRUD)) // Nếu chi tiết = hanhdong 
                        {
                            DGVDetailNhomQuyen.Rows[i].Cells[j].Value = true;
                        }
                    }
                }
            }
            //DGVDetailNhomQuyen.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVDetailNhomQuyen.ClearSelection();
            DGVDetailNhomQuyen.Enabled = false;
        }
    }
}
