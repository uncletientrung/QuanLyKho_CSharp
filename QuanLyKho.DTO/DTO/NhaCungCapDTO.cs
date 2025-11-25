using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class NhaCungCapDTO
    {
        private int mancc;
        private string tenncc;
        private string diachincc;
        private string sdt;
        private string email;
        private int trangthai;


        public NhaCungCapDTO()
        {

        }

        public NhaCungCapDTO(int _mancc, string _tenncc, string _diachincc, string _sdt, string _email, int _trangthai)
        {
            mancc = _mancc;
            tenncc = _tenncc;
            diachincc = _diachincc;
            sdt = _sdt;
            email = _email;
            trangthai = _trangthai;
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

        public string Diachincc
        {
            get { return diachincc; }
            set { diachincc = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
