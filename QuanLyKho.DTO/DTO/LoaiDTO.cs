using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class LoaiDTO
    {
        private int maloai;
        private string tenloai;

        public LoaiDTO() { }

        public LoaiDTO(int _maloai, string _tenloai)
        {
            maloai = _maloai;
            tenloai = _tenloai;
        }

        public int Maloai
        {
            get { return maloai; }
            set { maloai = value; }
        }

        public string Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }
    }
}
