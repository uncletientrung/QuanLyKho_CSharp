using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO.ThongKeDTO
{
    public class ThongKeKhachHangDTO
    {
        private int makh;
        private string tenkh;
        private int soluongphieu;
        private int tongtien;
        private int tongsanpham;
        private int stt;

        public ThongKeKhachHangDTO() { }

        public ThongKeKhachHangDTO(int _stt,int _makh, string _tenkh, int _soluongphieu, int _tongsanpham, int _tongtien )
        {
            makh = _makh;
            tenkh = _tenkh;
            soluongphieu = _soluongphieu;
            tongtien = _tongtien;
            tongsanpham = _tongsanpham;
            stt = _stt;
        }

        public int Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        public string Tenkh
        {
            get { return tenkh; }
            set { tenkh = value; }
        }

        public int Soluongphieu
        {
            get { return soluongphieu; }
            set { soluongphieu = value; }
        }

        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public int Tongsanpham
        {
            get { return tongsanpham; }
            set { tongsanpham = value; }
        }

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
    }
}
