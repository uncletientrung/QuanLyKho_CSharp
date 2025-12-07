using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class PhieuKiemKeDTO
    {
        private int maphieukiemke;
        private DateTime thoigiantao;
        private DateTime thoigiancanbang;
        private string trangthai;
        private string ghichu;
        private int makhuvuc;
        private int manhanvientao;
        private int manhanvienkiem;

        // thêm tên kho và tên nhân viên để hiển thị trong CTPhieuKiemKe không cần tạo thêm thằng cu CTPhieuKiemKeDTO
        //private string tenkho;
        //private string tennhanvienta;
        //private string tennhanvienkiem;

        public PhieuKiemKeDTO() { }

        public PhieuKiemKeDTO(
            int _maphieukiemke,
            DateTime _thoigiantao,
            DateTime _thoigiancanbang,
            string _trangthai,
            string _ghichu,
            int _makhuvuc,
            int _manhanvientao,
            int _manhanvienkiem)
        {
            maphieukiemke = _maphieukiemke;
            thoigiantao = _thoigiantao;
            thoigiancanbang= _thoigiancanbang;
            trangthai = _trangthai;
            ghichu = _ghichu;
            makhuvuc = _makhuvuc;
            manhanvientao = _manhanvientao;
            manhanvienkiem = _manhanvienkiem;
        }

        public int Maphieukiemke
        {
            get { return maphieukiemke; }
            set { maphieukiemke = value; }
        }

        public DateTime Thoigiantao
        {
            get { return thoigiantao; }
            set { thoigiantao = value; }
        }
        public DateTime Thoigiancanbang
        {
            get { return thoigiancanbang; }
            set { thoigiancanbang = value; }
        }

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        public int Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
        }

        public int Manhanvientao
        {
            get { return manhanvientao; }
            set { manhanvientao = value; }
        }

        public int Manhanvienkiem
        {
            get { return manhanvienkiem; }
            set { manhanvienkiem = value; }
        }

        //public string TenKho
        //{
        //    get { return tenkho; }
        //    set { tenkho = value; }
        //}

        //public string TenNhanVienTao
        //{
        //    get { return tennhanvienta; }
        //    set { tennhanvienta = value; }
        //}

        //public string TenNhanVienKiem
        //{
        //    get { return tennhanvienkiem; }
        //    set { tennhanvienkiem = value; }
        //}
    }
}