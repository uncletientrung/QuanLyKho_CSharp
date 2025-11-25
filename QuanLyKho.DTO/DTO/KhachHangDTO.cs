using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class KhachHangDTO
    {
        private int makh;
        private string tenkhachhang;
        private string email;
        private DateTime ngaysinh;
        private string sdt;
        private int trangthai;

        public KhachHangDTO() { }

        public KhachHangDTO(int _makh, string _tenkhachhang, string _email, DateTime _ngaysinh, string _sdt, int _trangthai)
        {
            makh = _makh;
            tenkhachhang = _tenkhachhang;
            email = _email;
            ngaysinh = _ngaysinh;
            sdt = _sdt;
            trangthai = _trangthai;
        }

        public int Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        public string Tenkhachhang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        override public string ToString()
        {
            return $"ID: {Makh}, Tên: {Tenkhachhang}, SĐT: {Sdt}, Email: {email} Ngày sinh: {Ngaysinh:dd/MM/yyyy}, Trạng thái: {Trangthai}";
        }
    }
}
