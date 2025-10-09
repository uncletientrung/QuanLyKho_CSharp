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

namespace QuanLyKho_CSharp.GUI.PhieuXuat
{
    public partial class DetailPhieuXuatForm : Form
    {
        private PhieuXuatDTO _phieuXuat;

        // Constructor mới nhận tham số PhieuXuatDTO
        public DetailPhieuXuatForm(PhieuXuatDTO phieuXuat)
        {
            InitializeComponent();
            _phieuXuat = phieuXuat;
            LoadDataToForm();
        }

        public DetailPhieuXuatForm()
        {
            InitializeComponent();
        }

        private void LoadDataToForm()
        {
            if (_phieuXuat != null)
            {

            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
