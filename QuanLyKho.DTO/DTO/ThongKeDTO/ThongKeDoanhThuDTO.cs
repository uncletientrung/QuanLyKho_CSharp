using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO.ThongKeDTO
{
    public class ThongKeDoanhThuDTO // Dùng để thống kê theo quý, năm
    {
        private int thoigian;
        private double von;
        private double doanhthu;
        private double loinhuan;

        public ThongKeDoanhThuDTO() { }

        public ThongKeDoanhThuDTO(int _thoigian, double _von, double _doanhthu, double _loinhuan)
        {
            thoigian = _thoigian;
            von = _von;
            doanhthu = _doanhthu;
            loinhuan = _loinhuan;
        }

        public int Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }

        public double Von
        {
            get { return von; }
            set { von = value; }
        }

        public double Doanhthu
        {
            get { return doanhthu; }
            set { doanhthu = value; }
        }

        public double Loinhuan
        {
            get { return loinhuan; }
            set { loinhuan = value; }
        }
    }
}
