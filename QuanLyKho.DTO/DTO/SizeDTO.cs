using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class SizeDTO
    {
        private int masize;
        private string tensize;
        private string ghichu;

        public SizeDTO() { }

        public SizeDTO(int _masize, string _tensize, string _ghichu)
        {
            masize = _masize;
            tensize = _tensize;
            ghichu = _ghichu;
        }

        public int Masize
        {
            get { return masize; }
            set { masize = value; }
        }

        public string Tensize
        {
            get { return tensize; }
            set { tensize = value; }
        }

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
    }
}
