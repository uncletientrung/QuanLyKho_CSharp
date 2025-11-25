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
        private int von;
        private int doanhthu;
        private int loinhuan;

        public ThongKeDoanhThuDTO() { }

        public ThongKeDoanhThuDTO(int _thoigian, int _von, int _doanhthu, int _loinhuan)
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

        public int Von
        {
            get { return von; }
            set { von = value; }
        }

        public int Doanhthu
        {
            get { return doanhthu; }
            set { doanhthu = value; }
        }

        public int Loinhuan
        {
            get { return loinhuan; }
            set { loinhuan = value; }
        }
    }
}
