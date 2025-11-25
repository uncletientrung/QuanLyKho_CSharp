using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class NhanVienDTO
    {
        private int manv;
        private string tennv;
        private int gioitinh;
        private string sdt;
        private DateTime ngaysinh;
        private int trangthai;

        public NhanVienDTO() { }

        public NhanVienDTO(int _manv, string _tennv, int _gioitinh, string _sdt, DateTime _ngaysinh, int _trangthai)
        {
            manv = _manv;
            tennv = _tennv;
            gioitinh = _gioitinh;
            sdt = _sdt;
            ngaysinh = _ngaysinh;
            trangthai = _trangthai;
        }

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        public string Tennv
        {
            get { return tennv; }
            set { tennv = value; }
        }

        public int Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public override string ToString()
        {
            return $"ID: {Manv}, Tên: {Tennv}, SĐT: {Sdt}, Ngày sinh: {Ngaysinh:dd/MM/yyyy}, Trạng thái: {Trangthai}";
        }
    }
}
