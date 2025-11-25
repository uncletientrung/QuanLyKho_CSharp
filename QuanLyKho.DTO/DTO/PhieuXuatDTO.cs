using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class PhieuXuatDTO : PhieuDTO
    {
        private int makh;

        public PhieuXuatDTO() : base() { }

        public PhieuXuatDTO(int _maphieu, int _manv, DateTime _thoigiantao, int _tongtien, int _trangthai, int _makh)
            : base(_maphieu, _manv, _thoigiantao, _tongtien, _trangthai)
        {
            makh = _makh;
        }

        public int Makh
        {
            get { return makh; }
            set { makh = value; }
        }
    }
}
