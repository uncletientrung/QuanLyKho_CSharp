using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class SanPhamDTO
    {
        private int masp;
        private string tensp;
        private string hinhanh;
        private int soluong;
        private int dongia;
        private int machatlieu;
        private int maloai;
        private int makhuvuc;
        private int masize;
        private int trangthai;
        private string tenloai;
        private string tenkhuvuc;
        private string tenchatlieu;
        private string tensize;


        public SanPhamDTO() { }

        public SanPhamDTO(int _masp, string _tensp, string _hinhanh, int _soluong, int _dongia,
                          int _machatlieu, int _maloai, int _makhuvuc, int _masize, int trangthai,
                          string _tenloai, string _tenkhuvuc, string _tenchatlieu, string _tensize)
        {
            masp = _masp;
            tensp = _tensp;
            hinhanh = _hinhanh;
            soluong = _soluong;
            dongia = _dongia;
            machatlieu = _machatlieu;
            maloai = _maloai;
            makhuvuc = _makhuvuc;
            masize = _masize;
            this.trangthai = trangthai;
            this.tenloai = _tenloai;
            this.tenkhuvuc = _tenkhuvuc;
            this.tenchatlieu = _tenchatlieu;
            this.tensize = _tensize;

        }

        public int Masp
        {
            get { return masp; }
            set { masp = value; }
        }

        public string Tensp
        {
            get { return tensp; }
            set { tensp = value; }
        }

        public string Hinhanh
        {
            get { return hinhanh; }
            set { hinhanh = value; }
        }

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public int Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        public int Machatlieu
        {
            get { return machatlieu; }
            set { machatlieu = value; }
        }

        public int Maloai
        {
            get { return maloai; }
            set { maloai = value; }
        }

        public int Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
        }

        public int Masize
        {
            get { return masize; }
            set { masize = value; }
        }
        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public string Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }

        public string Tenkhuvuc
        {
            get { return tenkhuvuc; }
            set { tenkhuvuc = value; }
        }

        public string Tenchatlieu
        {
            get { return tenchatlieu; }
            set { tenchatlieu = value; }
        }

        public string Tensize
        {
            get { return tensize; }
            set { tensize = value; }
        }
        public override string ToString()
        {
            return
                $"Mã SP: {masp}\n" +
                $"Tên SP: {tensp}\n" +
                $"Hình ảnh: {hinhanh}\n" +
                $"Số lượng: {soluong}\n" +
                $"Đơn giá: {dongia}\n" +
                $"Mã chất liệu: {machatlieu}\n" +
                $"Mã loại: {maloai}\n" +
                $"Mã khu vực: {makhuvuc}\n" +
                $"Mã size: {masize}\n" +
                $"Trạng thái: {trangthai}";
        }
    }
}
