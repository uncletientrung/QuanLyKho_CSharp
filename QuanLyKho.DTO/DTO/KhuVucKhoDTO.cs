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
        private string diachi;
        private string sdt;
        private string email;

        public KhuVucKhoDTO() { }

        public KhuVucKhoDTO(int _makhuvuc, string _tenkhuvuc, string _diachi, string _sdt, string _email)
        {
            makhuvuc = _makhuvuc;
            tenkhuvuc = _tenkhuvuc;
            diachi = _diachi;
            sdt = _sdt;
            email = _email;
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

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
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
    }
}
