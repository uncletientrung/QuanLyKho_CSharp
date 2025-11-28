//using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class PhieuDTO
    {
        private int maphieu;
        private int manv;
        private DateTime thoigiantao;
        private int tongtien;
        private int trangthai;

        public PhieuDTO() { }

        public PhieuDTO(int _maphieu, int _manv, DateTime _thoigiantao, int _tongtien, int _trangthai)
        {
            maphieu = _maphieu;
            manv = _manv;
            thoigiantao = _thoigiantao;
            tongtien = _tongtien;
            trangthai = _trangthai;
        }

        public int Maphieu
        {
            get { return maphieu; }
            set { maphieu = value; }
        }

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        public DateTime Thoigiantao
        {
            get { return thoigiantao; }
            set { thoigiantao = value; }
        }

        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
