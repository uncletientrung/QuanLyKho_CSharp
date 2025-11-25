using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class ChiTietPhieuNhapDTO
    {
        private int maphieunhap;
        private int masp;
        private int soluong;
        private int dongia;

        public ChiTietPhieuNhapDTO() { }

        public ChiTietPhieuNhapDTO(int _maphieunhap, int _masp, int _soluong, int _dongia)
        {
            maphieunhap = _maphieunhap;
            masp = _masp;
            soluong = _soluong;
            dongia = _dongia;
        }

        public int Maphieunhap
        {
            get { return maphieunhap; }
            set { maphieunhap = value; }
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
    }
}
