using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DTO;
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

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class AddPhieuNhapForm : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private PhieuNhapBUS pnBUS = new PhieuNhapBUS();
        private BindingList<SanPhamDTO> listSP;
        private BindingList<SanPhamDTO> listSPDuocThem;

        public AddPhieuNhapForm()
        {
            InitializeComponent();
            SetupDataGridViews();
            LoadData();
            UpdateButtonStates();
        }

        private void SetupDataGridViews()
        {
            // Cấu hình dgvSPtrongKho
            dgvSPtrongKho.ClearSelection();
            dgvSPtrongKho.RowHeadersVisible = false;
            dgvSPtrongKho.AllowUserToResizeRows = false;
            dgvSPtrongKho.AllowUserToAddRows = false;
            dgvSPtrongKho.ReadOnly = true;
            dgvSPtrongKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPtrongKho.MultiSelect = false;
            dgvSPtrongKho.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPtrongKho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cấu hình dgvSPduocThem
            dgvSPduocThem.ClearSelection();
            dgvSPduocThem.RowHeadersVisible = false;
            dgvSPduocThem.AllowUserToResizeRows = false;
            dgvSPduocThem.AllowUserToAddRows = false;
            dgvSPduocThem.ReadOnly = true;
            dgvSPduocThem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSPduocThem.MultiSelect = false;
            dgvSPduocThem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSPduocThem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Khởi tạo danh sách sản phẩm được thêm
            listSPDuocThem = new BindingList<SanPhamDTO>();
        }
        private Image LoadImageSafe(string relativePath)
        {
            try
            {
                if (string.IsNullOrEmpty(relativePath))
                {
                    // Trả về ảnh mặc định nếu không có đường dẫn
                    return CreateEmptyImage();
                }

                string path = Path.Combine(Application.StartupPath, relativePath.Replace("/", "\\"));

                if (!File.Exists(path))
                {
                    // Thử tìm theo đường dẫn khác
                    string alt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", relativePath.Replace("/", "\\"));
                    alt = Path.GetFullPath(alt);
                    if (File.Exists(alt))
                    {
                        path = alt;
                    }
                    else
                    {
                        Console.WriteLine($"File không tồn tại: {path}");
                        return CreateEmptyImage();
                    }
                }

                byte[] bytes = File.ReadAllBytes(path);
                using (var ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải ảnh {relativePath}: {ex.Message}");
                return CreateEmptyImage();
            }
        }

        private Image CreateEmptyImage()
        {
            // Tạo ảnh trống màu trắng
            Bitmap emptyImage = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(emptyImage))
            {
                g.Clear(Color.White);
            }
            return emptyImage;
        }
        private void LoadData()
        {
            listSP = spBUS.getListSP();
            boxMaPhieu.Text = pnBUS.getAutoMaPhieuNhap().ToString();
            boxNVnhap.Text = "admin"; // để tạm thui nha
            LoadSPTrongKho();
        }

        private void LoadSPTrongKho()
        {
            dgvSPtrongKho.Columns.Clear();
            dgvSPtrongKho.Rows.Clear();

            dgvSPtrongKho.Columns.Add("MaSP", "Mã SP");
            dgvSPtrongKho.Columns.Add("TenSP", "Tên sản phẩm");

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.Name = "HinhAnh";
            imgCol.HeaderText = "Ảnh";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvSPtrongKho.Columns.Add(imgCol);

            dgvSPtrongKho.Columns.Add("DonGia", "Đơn giá");
            dgvSPtrongKho.Columns.Add("SoLuong", "Số lượng");

            foreach (DataGridViewColumn column in dgvSPtrongKho.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvSPtrongKho.Columns["MaSP"].FillWeight = 10;      // 10%
            dgvSPtrongKho.Columns["TenSP"].FillWeight = 40;     // 40%
            dgvSPtrongKho.Columns["HinhAnh"].FillWeight = 15;   // 15%
            dgvSPtrongKho.Columns["DonGia"].FillWeight = 20;    // 20%
            dgvSPtrongKho.Columns["SoLuong"].FillWeight = 15;   // 15%

            dgvSPtrongKho.RowTemplate.Height = 40; // set height

            // Thêm dữ liệu
            if (listSP != null && listSP.Count > 0)
            {
                foreach (SanPhamDTO sp in listSP)
                {
                Image productImage = LoadImageSafe(sp.Hinhanh); // truyền đối tượng ko phải string
                    dgvSPtrongKho.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        productImage,
                        sp.Dongia,
                        sp.Soluong
                    );
                }
            }

            dgvSPtrongKho.ClearSelection();
        }

        private void LoadSPDuocThem()
        {
            dgvSPduocThem.Columns.Clear();
            dgvSPduocThem.Rows.Clear();

            dgvSPduocThem.Columns.Add("STT", "STT");
            dgvSPduocThem.Columns.Add("MaSP", "Mã SP");
            dgvSPduocThem.Columns.Add("TenSP", "Tên sản phẩm");
            dgvSPduocThem.Columns.Add("DonGia", "Đơn giá");
            dgvSPduocThem.Columns.Add("SoLuong", "Số lượng");
            dgvSPduocThem.Columns.Add("ThanhTien", "Thành tiền");

            foreach (DataGridViewColumn column in dgvSPduocThem.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvSPduocThem.Columns["STT"].FillWeight = 8;        // 8%
            dgvSPduocThem.Columns["MaSP"].FillWeight = 12;      // 12%
            dgvSPduocThem.Columns["TenSP"].FillWeight = 35;     // 35%
            dgvSPduocThem.Columns["DonGia"].FillWeight = 15;    // 15%
            dgvSPduocThem.Columns["SoLuong"].FillWeight = 15;   // 15%
            dgvSPduocThem.Columns["ThanhTien"].FillWeight = 15; // 15%

            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
            {
                int stt = 1;
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    decimal thanhTien = sp.Dongia * sp.Soluong;
                    dgvSPduocThem.Rows.Add(
                        stt++,
                        sp.Masp,
                        sp.Tensp,
                        sp.Dongia,
                        sp.Soluong,
                        $"{thanhTien:N0}đ"
                    );
                }
            }

            dgvSPduocThem.ClearSelection();
            UpdateTongTien();
            UpdateButtonStates();
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;
            if (listSPDuocThem != null && listSPDuocThem.Count > 0)
            {
                foreach (SanPhamDTO sp in listSPDuocThem)
                {
                    tongTien += sp.Dongia * sp.Soluong;
                }
            }
            labelPrice.Text = $"{tongTien:N0}đ";
        }

        private void UpdateButtonStates()
        {
            // Chỉ enable nút Sửa và Xóa khi có sản phẩm trong danh sách được thêm
            bool hasProducts = listSPDuocThem != null && listSPDuocThem.Count > 0;
            buttonSuaSP.Enabled = hasProducts;
            buttonXoaSP.Enabled = hasProducts;
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchString))
            {
                LoadSPTrongKho();
                return;
            }

            // Tìm kiếm theo mã hoặc tên sản phẩm
            var filteredList = listSP.Where(sp =>
                sp.Masp.ToString().Contains(searchString) ||
                sp.Tensp.ToLower().Contains(searchString.ToLower())
            ).ToList();

            dgvSPtrongKho.Rows.Clear();

            if (filteredList.Count > 0)
            {
                foreach (SanPhamDTO sp in filteredList)
                {

                    Image productImage = LoadImageSafe(sp.Hinhanh); // truyền đối tượng ko phải string
                    dgvSPtrongKho.Rows.Add(
                        sp.Masp,
                        sp.Tensp,
                        productImage,
                        sp.Dongia,
                        sp.Soluong
                    );
                }
            }

            dgvSPtrongKho.ClearSelection();
        }

        private void buttonThemSP_Click(object sender, EventArgs e)
        {
            if (dgvSPtrongKho.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSPtrongKho.SelectedRows[0];
                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());

                // Tìm sản phẩm trong danh sách
                SanPhamDTO spToAdd = listSP.FirstOrDefault(sp => sp.Masp == maSP);

                if (spToAdd != null)
                {
                    // Kiểm tra xem sản phẩm đã có trong danh sách chưa
                    SanPhamDTO existingSP = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);

                    if (existingSP != null)
                    {
                        // Nếu đã có, tăng số lượng lên 1
                        existingSP.Soluong += 1;
                    }
                    else
                    {
                        // Nếu chưa có, thêm sản phẩm mới với số lượng = 1
                        SanPhamDTO newSP = new SanPhamDTO
                        {
                            Masp = spToAdd.Masp,
                            Tensp = spToAdd.Tensp,
                            Dongia = spToAdd.Dongia,
                            Soluong = 1 // Mặc định thêm 1 sản phẩm
                        };
                        listSPDuocThem.Add(newSP);
                    }

                    LoadSPDuocThem();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để thêm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvSPduocThem.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSPduocThem.SelectedRows[0];
                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());

                // Tạo form nhập số lượng đơn giản thay vì dùng InputBox
                using (var inputForm = new InputQuantityForm())
                {
                    // Ép kiểu an toàn từ object sang int
                    object soLuongValue = selectedRow.Cells["SoLuong"].Value;
                    int currentQuantity = soLuongValue != null ? Convert.ToInt32(soLuongValue) : 1;

                    inputForm.Quantity = currentQuantity;
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        int newQuantity = inputForm.Quantity;
                        if (newQuantity > 0)
                        {
                            // Cập nhật số lượng
                            SanPhamDTO spToUpdate = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);
                            if (spToUpdate != null)
                            {
                                spToUpdate.Soluong = newQuantity;
                                LoadSPDuocThem();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSPduocThem.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSPduocThem.SelectedRows[0];
                int maSP = int.Parse(selectedRow.Cells["MaSP"].Value.ToString());

                // Xác nhận xóa
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa sản phẩm này khỏi danh sách?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa sản phẩm
                    SanPhamDTO spToRemove = listSPDuocThem.FirstOrDefault(sp => sp.Masp == maSP);
                    if (spToRemove != null)
                    {
                        listSPDuocThem.Remove(spToRemove);
                        LoadSPDuocThem();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonNhapHang_Click(object sender, EventArgs e)
        {
            if (listSPDuocThem == null || listSPDuocThem.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý mã nhà cung cấp - để tạm 0 nếu không có
            int maNCC = 0;
            if (!string.IsNullOrEmpty(comboBoxNCC.Text) && int.TryParse(comboBoxNCC.Text, out int tempNCC))
            {
                maNCC = tempNCC;
            }

            PhieuNhapDTO newPhieuNhap = new PhieuNhapDTO
            {
                Maphieu = int.Parse(boxMaPhieu.Text),
                Manv = 1, // Mặc định admin
                Mancc = maNCC, // Đã xử lý ở trên
                Thoigiantao = DateTime.Now,
                Tongtien = (int)CalculateTongTien(),
                Trangthai = 1
            };

            // Lưu phiếu nhập
            if (pnBUS.insertPhieuNhap(newPhieuNhap))
            {
                MessageBox.Show("Nhập hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi nhập hàng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateTongTien()
        {
            decimal tongTien = 0;
            foreach (SanPhamDTO sp in listSPDuocThem)
            {
                tongTien += sp.Dongia * sp.Soluong;
            }
            return tongTien;
        }

        private void buttonNhapExcel_Click(object sender, EventArgs e)
        {
            // Tạm thời để trống, có thể triển khai sau
            MessageBox.Show("Chức năng nhập Excel sẽ được triển khai sau!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AddPhieuNhapForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvSPduocThem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // Form phụ để nhập số lượng
    // Từ từ chỉnh sau ^^
    public class InputQuantityForm : Form
    {
        private NumericUpDown numericUpDown;
        private Button btnOK;
        private Button btnCancel;

        public int Quantity { get; set; }

        public InputQuantityForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Chỉnh sửa số lượng";
            this.Size = new Size(350, 180); 
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Tạo controls với kích thước lớn hơn
            var label = new Label()
            {
                Text = "Nhập số lượng mới:",
                Location = new Point(20, 20),
                Size = new Size(300, 25),
                Font = new Font("Microsoft Sans Serif", 12F), 
                TextAlign = ContentAlignment.MiddleLeft
            };

            numericUpDown = new NumericUpDown()
            {
                Location = new Point(20, 50),
                Size = new Size(300, 35),
                Minimum = 1,
                Maximum = 100000,
                Value = 1,
                Font = new Font("Microsoft Sans Serif", 12F),
                TextAlign = HorizontalAlignment.Center
            };

            btnOK = new Button()
            {
                Text = "OK",
                Location = new Point(20, 100),
                Size = new Size(140, 35),
                DialogResult = DialogResult.OK,
                Font = new Font("Microsoft Sans Serif", 11F)
            };

            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(180, 100),
                Size = new Size(140, 35),
                DialogResult = DialogResult.Cancel,
                Font = new Font("Microsoft Sans Serif", 11F)
            };

            this.Controls.AddRange(new Control[] { label, numericUpDown, btnOK, btnCancel });

            btnOK.Click += (s, e) => { Quantity = (int)numericUpDown.Value; };
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;

            this.Shown += (s, e) => {
                numericUpDown.Select();
                numericUpDown.Select(0, numericUpDown.Text.Length);
            };
        }
    }
}