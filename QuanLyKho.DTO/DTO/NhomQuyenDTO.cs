using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class NhomQuyenDTO
    {
        private int manhomquyen;
        private string tennhomquyen;
        private int trangthai;

        public NhomQuyenDTO() { }

        public NhomQuyenDTO(int _manhomquyen, string _tennhomquyen, int _trangthai)
        {
            manhomquyen = _manhomquyen;
            tennhomquyen = _tennhomquyen;
            trangthai = _trangthai;
        }

        public int Manhomquyen
        {
            get { return manhomquyen; }
            set { manhomquyen = value; }
        }

        public string Tennhomquyen
        {
            get { return tennhomquyen; }
            set { tennhomquyen = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
