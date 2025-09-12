using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.DTO.ThongKeDTO
{
    public class ThongKeTonKhoDTO
    {
        private int masp;
        private string tensp;
        private string hinhanh;
        private int maloai;
        private int masize;
        private int makhuvuc;
        private int machatlieu;
        private int soluongton;
        private int dongia;
        private int stt;

        public ThongKeTonKhoDTO() { }

        public ThongKeTonKhoDTO(int _masp, string _tensp, string _hinhanh, int _maloai, int _masize,
                                int _makhuvuc, int _machatlieu, int _soluongton, int _dongia, int _stt)
        {
            masp = _masp;
            tensp = _tensp;
            hinhanh = _hinhanh;
            maloai = _maloai;
            masize = _masize;
            makhuvuc = _makhuvuc;
            machatlieu = _machatlieu;
            soluongton = _soluongton;
            dongia = _dongia;
            stt = _stt;
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

        public int Maloai
        {
            get { return maloai; }
            set { maloai = value; }
        }

        public int Masize
        {
            get { return masize; }
            set { masize = value; }
        }

        public int Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
        }

        public int Machatlieu
        {
            get { return machatlieu; }
            set { machatlieu = value; }
        }

        public int Soluongton
        {
            get { return soluongton; }
            set { soluongton = value; }
        }

        public int Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
    }
}
