using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho.BUS;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using QuanLyKho_CSharp.GUI.SanPham;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKho_CSharp.GUI
{
    public partial class SanPhamGUI : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private KhuVucKhoBUS khuVucKhoBUS = new KhuVucKhoBUS();
        private ChatLieuBUS chatLieuBUS = new ChatLieuBUS();
        private SizeBUS sizeBUS = new SizeBUS();
        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<KhuVucKhoDTO> listKV;
        private BindingList<ChatLieuDTO> listCL;
        private BindingList<SizeDTO> listSize;
        private BindingList<LoaiDTO> listLoai;
        public SanPhamGUI()
        {
            InitializeComponent();
            listSP = spBUS.getListSP();
            listKV = khuVucKhoBUS.getKhuVucKhoList();
            listLoai = loaiBUS.getLoaiList();
            listCL = chatLieuBUS.getChatLieuList();
            listSize = sizeBUS.getSizeList();

            ConfigureDataGridView();
            setUpBoxTimKiem();
            LoadDataToGrid(spBUS.getListSP());
        }

        private void ConfigureDataGridView() // Setting cho DGV
        {
            dgvSanPham.ClearSelection();
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.AllowUserToResizeRows = false;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.MultiSelect = false;
            dgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSanPham.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(17, 155, 248);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(17, 155, 248);
            headerStyle.SelectionForeColor = Color.White;

            dgvSanPham.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvSanPham.ColumnHeadersHeight = 30;
            dgvSanPham.RowHeadersDefaultCellStyle = headerStyle;
            dgvSanPham.DefaultCellStyle.Font = new Font("Bahnschrift", 9F, FontStyle.Bold);
        }


        public void setUpBoxTimKiem()
        {
            cbbLoai.Items.Clear();
            cbbLoai.Items.Add("Tất cả loại");
            foreach (LoaiDTO loai in listLoai)
                cbbLoai.Items.Add(loai.Tenloai);
            cbbLoai.SelectedIndex = 0;

            cbbChatLieu.Items.Clear();
            cbbChatLieu.Items.Add("Tất cả chất liệu");
            foreach (ChatLieuDTO cl in listCL)
                cbbChatLieu.Items.Add(cl.Tenchatlieu);
            cbbChatLieu.SelectedIndex = 0;


            cbbKhuVuc.Items.Clear();
            cbbKhuVuc.Items.Add("Tất cả khu vực");
            foreach (KhuVucKhoDTO kv in listKV)
                cbbKhuVuc.Items.Add(kv.Tenkhuvuc);
            cbbKhuVuc.SelectedIndex = 0;

            cbbSize.Items.Clear();
            cbbSize.Items.Add("Tất cả size");
            foreach (SizeDTO s in listSize)
                cbbSize.Items.Add(s.Tensize);
            cbbSize.SelectedIndex = 0;

            //gan sk de khi thay doi no tim luon
            //txtTimKiem.TextChanged += (s, ev) => Filter();
            //cboChatLieu.SelectedIndexChanged += (s, ev) => Filter();
            //cboLoai.SelectedIndexChanged += (s, ev) => Filter();
            //cboKhuVuc.SelectedIndexChanged += (s, ev) => Filter();
            //cboSize.SelectedIndexChanged += (s, ev) => Filter();

            // Gọi Filter() để hiển thị dữ liệu ban đầu
            //Filter();
        }
        private void LoadDataToGrid(BindingList<SanPhamDTO> newList)
        {
            try
            {
                dgvSanPham.Rows.Clear();

                if (listSP == null || listSP.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Debug - No Data");
                    return;
                }
                foreach (SanPhamDTO sp in listSP)
                {
                    Image productImage = AddPhieuXuatForm.LoadImageSafe(sp.Hinhanh);
                    String tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
                    String tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
                    String tenLoai = loaiBUS.LayTenLoai(sp);
                    String tenSize = sizeBUS.LayTenSize(sp);
                    dgvSanPham.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        productImage,
                        sp.Soluong,
                        sp.Dongia,
                        tenChatLieu,
                        tenLoai,
                        tenKhuVuc,
                        tenSize
                    );
                }

                dgvSanPham.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selectedRow = dgvSanPham.CurrentRow;
            int masp =int.Parse(selectedRow.Cells["masp"].Value.ToString());
            SanPhamDTO spDuocChon = spBUS.getSPById(masp);
            if (spDuocChon == null) MessageBox.Show($"Sản phẩm không tồn tại");
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "detail")
            {
                DetailSanPhamForm detailForm = new DetailSanPhamForm(spDuocChon);
                detailForm.ShowDialog();
                if(detailForm.DialogResult == DialogResult.OK)
                {
                    new AddSuccessNotification().Show();
                    LoadDataToGrid(spBUS.getListSP());
                }
            }if(dgvSanPham.Columns[e.ColumnIndex].Name == "edit")
            {
                UpdateSanPhamForm updateForm = new UpdateSanPhamForm(spDuocChon);
                updateForm.ShowDialog();
                if (updateForm.DialogResult == DialogResult.OK)
                {
                    new UpdateSuccessNotification().Show();
                    LoadDataToGrid(spBUS.getListSP());
                }
            }
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "remove")
            {
                UpdateSanPhamForm updateForm = new UpdateSanPhamForm(spDuocChon);
                updateForm.ShowDialog();
                if (updateForm.DialogResult == DialogResult.OK)
                {
                    new DeleteSuccessNotification().Show();
                    LoadDataToGrid(spBUS.getListSP());
                }
            }
        }

        //        private void LoadDataToGridFind(BindingList<SanPhamDTO> newList)
        //        {
        //            try
        //            {
        //                dgvSanPham.Rows.Clear();

        //                if (listSP == null || listSP.Count == 0)
        //                {
        //                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Debug - No Data");
        //                    return;
        //                }

        //                foreach (SanPhamDTO sp in newList)
        //                {
        //                    Image img = LoadImageSafe(sp.Hinhanh);
        //                    String tenKhuVuc = khuVucKhoBUS.LayTenKhuVuc(sp);
        //                    String tenChatLieu = chatLieuBUS.LayTenChatLieu(sp);
        //                    String tenLoai = loaiBUS.LayTenLoai(sp);
        //                    String tenSize = sizeBUS.LayTenSize(sp);

        //                    dgvSanPham.Rows.Add(
        //                        sp.Masp,
        //                        sp.Tensp,
        //                        img,
        //                        sp.Soluong,
        //                        sp.Dongia,
        //                        tenChatLieu,
        //                        tenLoai,
        //                        tenKhuVuc,
        //                        tenSize
        //                    );
        //                }

        //                dgvSanPham.ClearSelection();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Lỗi trong LoadDataToGrid: {ex.Message}\n{ex.StackTrace}", "Debug Error");
        //            }
        //        }

        //        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        //        {
        //            //string searchString = txtTimKiem.Text.Trim();
        //            //BindingList<SanPhamDTO> listSP = spBUS.TimkiemSanPham(searchString);
        //            //LoadDataToGridFind(listSP);
        //        }

        //        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        {

        //        }

        //        private void btnThem_Click(object sender, EventArgs e)
        //        {

        //            AddSanPhamForm addSP = new AddSanPhamForm();
        //            addSP.ShowDialog();
        //            if(addSP.DialogResult == DialogResult.OK)
        //            {
        //                LoadDataToGrid();
        //                AddSuccessNotification tb = new AddSuccessNotification();
        //                tb.Show();
        //            }
        //        }

        //        private void groupBox1_Enter(object sender, EventArgs e)
        //        {

        //        }


        //        private void Filter()
        //        {
        //            string keyword = txtTimKiem.Text.Trim().ToLower();
        //            string chatLieu = cboChatLieu.SelectedItem?.ToString();
        //            string loai = cboLoai.SelectedItem?.ToString();
        //            string khuVuc = cboKhuVuc.SelectedItem?.ToString();
        //            string size = cboSize.SelectedItem?.ToString();

        //            int maLoai = loaiBUS.LayMaLoai(loai);
        //            int makv = khuVucKhoBUS.LayMaKhuVuc(khuVuc);
        //            int maCl = chatLieuBUS.LayMaChatLieu(chatLieu);
        //            int maSize = sizeBUS.LayMaSize(size); 

        //            var filtered = spBUS.getListSP().Where(sp =>
        //                (string.IsNullOrEmpty(keyword) || sp.Tensp.ToLower().Contains(keyword)) &&
        //                (chatLieu == "Tất cả" || maCl == 0 || sp.Machatlieu == maCl) &&
        //                (loai == "Tất cả" || maLoai == 0 || sp.Maloai == maLoai) &&
        //                (khuVuc == "Tất cả" || makv == 0 || sp.Makhuvuc == makv) &&
        //                (size == "Tất cả" || maSize == 0 || sp.Masize == maSize)
        //            ).ToList();

        //            BindingList<SanPhamDTO> filteredList = new BindingList<SanPhamDTO>(filtered);
        //            LoadDataToGridFind(filteredList);
        //        }

        //        private void btnLamMoi_Click(object sender, EventArgs e)
        //        {
        //            cboChatLieu.SelectedIndex = 0;
        //            cboKhuVuc.SelectedIndex = 0;
        //            cboLoai.SelectedIndex = 0;
        //            cboSize.SelectedIndex = 0;
        //            txtTimKiem.Text= string.Empty;

        //        }

        //        private void button2_Click(object sender, EventArgs e)
        //        {
        //            Excel.Application excelApp = new Excel.Application();
        //            excelApp.Application.Workbooks.Add(Type.Missing);

        //            Excel._Worksheet worksheet = (Excel._Worksheet)excelApp.ActiveSheet;
        //            worksheet.Name = "SanPham";//tạo 1 workshet 

        //            int colIndex = 1;

        //            worksheet.Cells[1, 1] = "DANH SÁCH SẢN PHẨM";
        //            Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgvSanPham.Columns.Count - 2]];
        //            titleRange.Merge(); 
        //            titleRange.Font.Size = 16;
        //            titleRange.Font.Bold = true;
        //            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


        //            for (int i = 0; i < dgvSanPham.Columns.Count; i++)
        //            {
        //                if (i == 2 || i == 9) continue; 

        //                worksheet.Cells[2, colIndex] = dgvSanPham.Columns[i].HeaderText;
        //                colIndex++;
        //            }

        //            // định dạng tiêu đề cột
        //            Excel.Range tieuDeCot = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, colIndex - 1]];
        //            tieuDeCot.Font.Bold = true;
        //            tieuDeCot.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
        //            tieuDeCot.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //            // ghi du lieu vô 
        //            int rowIndex = 3;
        //            foreach (DataGridViewRow row in dgvSanPham.Rows)
        //            {
        //                if (!row.IsNewRow)
        //                {
        //                    colIndex = 1;
        //                    for (int i = 0; i < dgvSanPham.Columns.Count; i++)
        //                    {
        //                        if (i == 2 || i == 9) continue; 
        //                        worksheet.Cells[rowIndex, colIndex] = row.Cells[i].Value?.ToString();
        //                        colIndex++;
        //                    }
        //                    rowIndex++;
        //                }
        //            }


        //            worksheet.Columns.AutoFit();// dùng để chỉnh cột cho vừa vặn với nooij dung

        //            excelApp.Visible = true;
        //        }
    }
}