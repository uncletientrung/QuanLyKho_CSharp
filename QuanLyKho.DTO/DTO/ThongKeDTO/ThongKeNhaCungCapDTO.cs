using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO.ThongKeDTO
{
    public class ThongKeNhaCungCapDTO
    {
        private int mancc;
        private string tenncc;
        private int soluong;
        private int tongtien;
        private int stt;

        public ThongKeNhaCungCapDTO() { }

        public ThongKeNhaCungCapDTO(int _stt,int _mancc, string _tenncc, int _soluong, int _tongtien)
        {
            stt = _stt;
            mancc = _mancc;
            tenncc = _tenncc;
            soluong = _soluong;
            tongtien = _tongtien;
        }

        public int Mancc
        {
            get { return mancc; }
            set { mancc = value; }
        }

        public string Tenncc
        {
            get { return tenncc; }
            set { tenncc = value; }
        }

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }
    }
}
