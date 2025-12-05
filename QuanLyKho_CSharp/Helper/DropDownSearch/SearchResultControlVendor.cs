using QuanLyKho.BUS;
using QuanLyKho.DTO;
using QuanLyKho_CSharp.GUI.ThongKe.giaoDienTK;
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
    public partial class SearchResultControlVendor : UserControl
    {
        private NhaCungCapDTO nccDTO;
        private static readonly NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        public event EventHandler<NhaCungCapDTO> OnCustomerSelected;
        public SearchResultControlVendor()
        {
            InitializeComponent();
        }
        public void BindData(NhaCungCapDTO ncc)
        {
            nccDTO = ncc;
            lbName.Text = $"{ncc.Mancc} - {ncc.Tenncc}";
            lbSDT.Text = $"SDT: {ncc.Sdt}";
        }
        public static BindingList<NhaCungCapDTO> TimKiem(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
                return new BindingList<NhaCungCapDTO>();
            return nccBUS.searchNhaCungCap(key) ?? new BindingList<NhaCungCapDTO>();
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
            OnCustomerSelected?.Invoke(this, nccDTO);
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
