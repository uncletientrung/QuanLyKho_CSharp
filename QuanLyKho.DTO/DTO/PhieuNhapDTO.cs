using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class PhieuNhapDTO : PhieuDTO
    {
        private int mancc;

        public PhieuNhapDTO() : base() { }

        public PhieuNhapDTO(int _maphieu, int _manv, DateTime _thoigiantao, int _tongtien, int _trangthai, int _mancc)
            : base(_maphieu, _manv, _thoigiantao, _tongtien, _trangthai)
        {
            mancc = _mancc;
        }

        public int Mancc
        {
            get { return mancc; }
            set { mancc = value; }
        }
    }
}
