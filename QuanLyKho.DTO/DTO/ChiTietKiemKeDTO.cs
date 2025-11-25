using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class ChiTietKiemKeDTO
    {
        private int maphieukiemke;
        private int masp;
        private int tonchinhanh;
        private int tonthucte;
        private string ghichu;

        public ChiTietKiemKeDTO() { }

        public ChiTietKiemKeDTO(int _maphieukiemke, int _masp, int _tonchinhanh, int _tonthucte, string _ghichu)
        {
            maphieukiemke = _maphieukiemke;
            masp = _masp;
            tonchinhanh = _tonchinhanh;
            tonthucte = _tonthucte;
            ghichu = _ghichu;
        }

        public int Maphieukiemke
        {
            get { return maphieukiemke; }
            set { maphieukiemke = value; }
        }

        public int Masp
        {
            get { return masp; }
            set { masp = value; }
        }

        public int Tonchinhanh
        {
            get { return tonchinhanh; }
            set { tonchinhanh = value; }
        }

        public int Tonthucte
        {
            get { return tonthucte; }
            set { tonthucte = value; }
        }

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        // Lech tính toán dựa trên tonthucte và tonchinhanh, chỉ đọc
        public int Lech
        {
            get { return tonthucte - tonchinhanh; }
        }
    }
}
