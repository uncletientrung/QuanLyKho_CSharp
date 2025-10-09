using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.GUI.PhieuNhap
{
    public partial class DetailPhieuNhapForm : Form
    {
        private PhieuNhapDTO _phieuNhap;

        // Constructor mới nhận tham số PhieuXuatDTO
        public DetailPhieuNhapForm(PhieuNhapDTO phieuNhap)
        {
            InitializeComponent();
            _phieuNhap = phieuNhap;
            LoadDataToForm();
        }

        public DetailPhieuNhapForm()
        {
            InitializeComponent();
        }

        private void LoadDataToForm()
        {
            if (_phieuNhap != null)
            {

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
