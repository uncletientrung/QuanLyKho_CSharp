using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.PhieuXuat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.Helper.DropDownSearch
{
    public partial class SearchResultControlCustomer : UserControl
    {
        private KhachHangDTO KhachHang;
        private static readonly KhachHangBUS khBUS = new KhachHangBUS();
        public event EventHandler<KhachHangDTO> OnCustomerSelected;
        public SearchResultControlCustomer()
        {
            InitializeComponent();
        }
        public void BindData(KhachHangDTO kh)
        {
            KhachHang = kh;
            lbName.Text = $"{kh.Makh} - {kh.Tenkhachhang}";
            lbSDT.Text = $"SDT: {kh.Sdt}";
        }
        public static BindingList<KhachHangDTO> TimKiem(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
                return new BindingList<KhachHangDTO>();
            return khBUS.SearchKhachHang(key) ?? new BindingList<KhachHangDTO>();
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
            OnCustomerSelected?.Invoke(this, KhachHang);
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
