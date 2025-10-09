using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
using QuanLyKho_CSharp.GUI.ThongTin.NhaCungCap;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKho_CSharp.GUI.ThongTin.Loai
{
    public partial class LoaiGUI : Form
    {

        private LoaiBUS loaiBUS = new LoaiBUS();
        private BindingList<LoaiDTO> listLoai;

        public LoaiGUI()
        {
            InitializeComponent();
        }

        private void DGVLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DGVLoai_Painting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
