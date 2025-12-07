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

namespace QuanLyKho_CSharp.Helper.DropDownSearch
{
    public partial class SearchResultControlStaff : UserControl
    {
        private NhanVienDTO NhanVien;
        private static readonly NhanVienBUS nvBUS = new NhanVienBUS();
        public event EventHandler<NhanVienDTO> OnStaffSelected;
        public SearchResultControlStaff()
        {
            InitializeComponent();
        }
        public void BindData(NhanVienDTO nv)
        {
            NhanVien = nv;
            lbName.Text = $"{nv.Manv} - {nv.Tennv}";
            lbSDT.Text = $"SDT: {nv.Sdt}";
        }
        public static BindingList<NhanVienDTO> TimKiem(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
                return new BindingList<NhanVienDTO>();
            return nvBUS.SearchNhanVien(key) ?? new BindingList<NhanVienDTO>();
        }

        private void SearchResultControl_MouseHover(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(230, 245, 255);
            this.BackColor = Color.LightCoral;
        }

        private void SearchResultControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void SearchResultControl_Click(object sender, EventArgs e)
        {
            OnStaffSelected?.Invoke(this, NhanVien);
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
