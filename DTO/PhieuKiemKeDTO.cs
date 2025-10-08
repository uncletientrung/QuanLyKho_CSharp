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
        private DateTime thoigiantao;
        private string nhanvientao;
        private int manhanvientao;
        private int makhuvuc;
        private string trangthai;
        private string ghichu;

        public PhieuKiemKeDTO() { }

        public PhieuKiemKeDTO(int _maphieukiemke, DateTime _thoigiantao, string _nhanvientao, int _manhanvientao, int _makhuvuc, string _trangthai, string _ghichu)
        {
            maphieukiemke = _maphieukiemke;
            thoigiantao = _thoigiantao;
            nhanvientao = _nhanvientao;
            manhanvientao = _manhanvientao;
            makhuvuc = _makhuvuc;
            trangthai = _trangthai;
            ghichu = _ghichu;
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

        public string Nhanvientao
        {
            get { return nhanvientao; }
            set { nhanvientao = value; }
        }

        public int Manhanvientao
        {
            get { return manhanvientao; }
            set { manhanvientao = value; }
        }

        public int Makhuvuc
        {
            get { return makhuvuc; }
            set { makhuvuc = value; }
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

    }


}