using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class ChatLieuDTO
    {
        private int machatlieu;
        private string tenchatlieu;

        public ChatLieuDTO() { }

        public ChatLieuDTO(int _machatlieu, string _tenchatlieu)
        {
            machatlieu = _machatlieu;
            tenchatlieu = _tenchatlieu;
        }

        public int Machatlieu
        {
            get { return machatlieu; }
            set { machatlieu = value; }
        }

        public string Tenchatlieu
        {
            get { return tenchatlieu; }
            set { tenchatlieu = value; }
        }
    }
}
