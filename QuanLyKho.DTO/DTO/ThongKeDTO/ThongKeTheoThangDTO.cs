using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO.ThongKeDTO
{
    public class ThongKeTheoThangDTO
    {
        private int thang;
        private int chiphi;
        private int doanhthu;
        private int loinhuan;

        public ThongKeTheoThangDTO() { }

        public ThongKeTheoThangDTO(int _thang, int _chiphi, int _doanhthu, int _loinhuan)
        {
            thang = _thang;
            chiphi = _chiphi;
            doanhthu = _doanhthu;
            loinhuan = _loinhuan;
        }

        public int Thang
        {
            get { return thang; }
            set { thang = value; }
        }

        public int Chiphi
        {
            get { return chiphi; }
            set { chiphi = value; }
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
