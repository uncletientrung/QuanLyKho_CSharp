using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class TaiKhoanDTO
    {
        private int manv { get; set; }
        private string tendangnhap { get; set; }
        private string matkhau { get; set; }
        private int manhomquyen { get; set; }
        private int trangthai { get; set; }

        public TaiKhoanDTO() { }

        public TaiKhoanDTO(int _manv, string _tendangnhap, string _matkhau, int _manhomquyen, int _trangthai)
        {
            manv = _manv;
            tendangnhap = _tendangnhap;
            matkhau = _matkhau;
            manhomquyen = _manhomquyen;
            trangthai = _trangthai;
        }
        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }

        public string Matkhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }

        public int Manhomquyen
        {
            get { return manhomquyen; }
            set { manhomquyen = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

    }
}
