using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class ChiTietPhieuXuatDTO
    {
        private int maphieuxuat;
        private int masp;
        private int soluong;
        private int dongia;
        private int trangThaiHoanHang;
        private string tensp;

        public ChiTietPhieuXuatDTO() { }

        public ChiTietPhieuXuatDTO(int _maphieuxuat, int _masp, int _soluong, int _dongia, int trangThaiHoanHang, string tensp)
        {
            maphieuxuat = _maphieuxuat;
            masp = _masp;
            soluong = _soluong;
            dongia = _dongia;
            this.trangThaiHoanHang = trangThaiHoanHang;
            this.tensp= tensp;

        }

        public int Maphieuxuat
        {
            get { return maphieuxuat; }
            set { maphieuxuat = value; }
        }

        public int Masp
        {
            get { return masp; }
            set { masp = value; }
        }

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        public int TrangTHaiHoanHang
        {
            get { return  trangThaiHoanHang; }
            set { trangThaiHoanHang = value; }
        }
        public string TenSP
        {
            get { return tensp; }
            set { tensp = value; }
        }
    }
}
