using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.DTO
{
    public class PhieuKiemKeDTO
    {
        private int maphieukiemke;
        private string trangthai;
        private string ghichu;
        private DateTime thoigiantao;
        private DateTime thoigiancanbang;
        private int makhuvuc;
        private int manhanvientao;
        private int manhanvien;

        public PhieuKiemKeDTO() { }

        public PhieuKiemKeDTO(int _maphieukiemke, string _trangthai, string _ghichu, DateTime _thoigiantao,
                              DateTime _thoigiancanbang, int _makhuvuc, int _manhanvientao, int _manhanvien)
        {
            maphieukiemke = _maphieukiemke;
            trangthai = _trangthai;
            ghichu = _ghichu;
            thoigiantao = _thoigiantao;
            thoigiancanbang = _thoigiancanbang;
            makhuvuc = _makhuvuc;
            manhanvientao = _manhanvientao;
            manhanvien = _manhanvien;
        }

        public int Maphieukiemke
        {
            get { return maphieukiemke; }
            set { maphieukiemke = value; }
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

        public int Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }
    }
}
