using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper
{
    public partial class SearchResultControl : UserControl
    {
        private SanPhamDTO _sp;
        private static readonly SanPhamBUS spBUS = new SanPhamBUS();
        public event EventHandler<SanPhamDTO> OnProductSelected;

        public SearchResultControl()
        {
            InitializeComponent();
        }

        public void BindData(SanPhamDTO sp)
        {
            _sp = sp;
            lbNameProduct.Text = $"{sp.Masp} - {sp.Tensp}";
            lbQuantity.Text = $"SL: {sp.Soluong} | Giá: {sp.Dongia:N0}đ";
            image.Image = AddPhieuXuatForm.LoadImageSafe(sp.Hinhanh);
        }
        public static BindingList<SanPhamDTO> TimKiem(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return spBUS.getListSP() ?? new BindingList<SanPhamDTO>();

            return spBUS.TimkiemSanPham(key) ?? new BindingList<SanPhamDTO>();
        }

        private void SearchResultControl_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(230, 245, 255);
        }

        private void SearchResultControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void SearchResultControl_Click(object sender, EventArgs e)
        {
            OnProductSelected?.Invoke(this, _sp);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (Control c in Controls)
            {
                c.Click += (s, args) => SearchResultControl_Click(this, EventArgs.Empty);
            }
        }
    }
}