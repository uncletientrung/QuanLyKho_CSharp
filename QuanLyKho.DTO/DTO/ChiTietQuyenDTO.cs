using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class ChiTietQuyenDTO
    {
        private int manhomquyen;
        private int machucnang;
        private string hanhdong;
        private int trangthai;

        public ChiTietQuyenDTO() { }

        public ChiTietQuyenDTO(int _manhomquyen, int _machucnang, string _hanhdong, int _trangthai)
        {
            manhomquyen = _manhomquyen;
            machucnang = _machucnang;
            hanhdong = _hanhdong;
            trangthai = _trangthai;
        }

        public int Manhomquyen
        {
            get { return manhomquyen; }
            set { manhomquyen = value; }
        }

        public int Machucnang
        {
            get { return machucnang; }
            set { machucnang = value; }
        }

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
