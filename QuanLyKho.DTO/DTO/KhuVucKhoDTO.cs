using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class KhuVucKhoDTO
    {
        private int makhuvuc;
        private string tenkhuvuc;

        public KhuVucKhoDTO() { }

        public KhuVucKhoDTO(int _makhuvuc, string _tenkhuvuc)
        {
            makhuvuc = _makhuvuc;
            tenkhuvuc = _tenkhuvuc;
        }

        public int Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
        }

        public string Tenkhuvuc
        {
            get { return tenkhuvuc; }
            set { tenkhuvuc = value; }
        }

    }
}
