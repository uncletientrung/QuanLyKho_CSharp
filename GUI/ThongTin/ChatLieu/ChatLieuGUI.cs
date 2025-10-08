using Google.Protobuf.Collections;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using QuanLyKho_CSharp.BUS;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI.NhanVien;
using QuanLyKho_CSharp.GUI.ThongTin.ChatLieu;
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

namespace QuanLyKho_CSharp.GUI.ThongTin.ChatLieu
{
    public partial class ChatLieuGUI : Form
    {
        private ChatLieuBUS clBUS = new ChatLieuBUS();
        private BindingList<ChatLieuDTO> listCL;
        public ChatLieuGUI()
        {
            InitializeComponent();
            txSearch.Text = "Nhập mã, tên chất liệu để tìm";
            txSearch.ForeColor = Color.Gray;
            DGVChatLieu.ClearSelection();
            DGVChatLieu.RowHeadersVisible = false; // Tắt cột header
            DGVChatLieu.AllowUserToResizeRows = false; // Chặn kéo dài row
            DGVChatLieu.AllowUserToResizeColumns = false; // chặn thay đổi kích thước cột
            DGVChatLieu.AllowUserToAddRows = false;      // chặn thêm dòng
            DGVChatLieu.ReadOnly = true;                // chặn chỉnh sửa dữ liệu
            DGVChatLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bôi full row
            DGVChatLieu.MultiSelect = false; // Nếu muốn chỉ chọn 1 row tại 1 thời điểm
            DGVChatLieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Text columnheader ở giữa
            DGVChatLieu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Dữ liệu các cột canh giũa

            listCL = clBUS.getChatLieuList();
        }

        private void lblDanhSachChatLieu_Click(object sender, EventArgs e)
        {

        }

        private void ChatLieuGUI_Load(object sender, EventArgs e)
        {
            DGVChatLieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGVChatLieu.Columns.Add("Mã chất liệu", "Mã chất liệu");
            DGVChatLieu.Columns["Mã chất liệu"].FillWeight = 100;

            DGVChatLieu.Columns.Add("Tên chất liệu", "Tên chất liệu");
            DGVChatLieu.Columns["Tên chất liệu"].FillWeight = 250;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn(); 
            btn.HeaderText = "Nút";
            btn.Name = "Actions";
            btn.Text = "Hit me";
            btn.UseColumnTextForButtonValue = true; // Hiện text trên button
            DGVChatLieu.Columns.Add(btn);
            
            // Load dữ liệu ban đầu
            refreshDataGridView(listCL);
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (txSearch.Text != "Nhập mã hoặc tên chất liệu để tìm kiếm")
            {
               string keyword = txSearch.Text.Trim().ToLower();
                BindingList<ChatLieuDTO> listSearch = clBUS.SearchChatLieu(keyword);
                refreshDataGridView(listSearch); 
            }
        }

        private void txSearch_Enter(object sender, EventArgs e)
        {
            if (txSearch.Text == "Nhập mã hoặc tên chất liệu để tìm kiếm")
            {
                txSearch.Text = "";
                txSearch.ForeColor = Color.Black;
            }
        }

        private void txSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txSearch.Text))
            {
                txSearch.ForeColor = Color.Gray;
                txSearch.Text = "Nhập mã hoặc tên chất liệu để tìm kiếm";
            }
        }

        private void refreshDataGridView(BindingList<ChatLieuDTO> list)
        {
            DGVChatLieu.Rows.Clear();
            foreach (ChatLieuDTO cl in list)
            {
                DGVChatLieu.Rows.Add(cl.Machatlieu, cl.Tenchatlieu);
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            AddChatLieuForm addCL = new AddChatLieuForm();
            addCL.ShowDialog();

            if (addCL.DialogResult == DialogResult.OK)
            {
                refreshDataGridView(clBUS.getChatLieuList()); // load lại danh sách chất liệu
                AddSuccessNotification tb = new AddSuccessNotification();
                tb.Show();
            }
        }
    }
}
