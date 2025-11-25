using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class SanPhamDTO
    {
        private int masp;
        private string tensp;
        private string hinhanh;
        private int soluong;
        private int dongia;
        private int machatlieu;
        private int maloai;
        private int makhuvuc;
        private int masize;

        public SanPhamDTO() { }

        public SanPhamDTO(int _masp, string _tensp, string _hinhanh, int _soluong, int _dongia,
                          int _machatlieu, int _maloai, int _makhuvuc, int _masize)
        {
            masp = _masp;
            tensp = _tensp;
            hinhanh = _hinhanh;
            soluong = _soluong;
            dongia = _dongia;
            machatlieu = _machatlieu;
            maloai = _maloai;
            makhuvuc = _makhuvuc;
            masize = _masize;
        }

        public int Masp
        {
            get { return masp; }
            set { masp = value; }
        }

        public string Tensp
        {
            get { return tensp; }
            set { tensp = value; }
        }

        public string Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; }
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

        public int Machatlieu
        {
            get { return machatlieu; }
            set { machatlieu = value; }
        }

        public int Maloai
        {
            get { return maloai; }
            set { maloai = value; }
        }

        public int Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
        }

        public int Masize
        {
            get { return masize; }
            set { masize = value; }
        }
    }
}
