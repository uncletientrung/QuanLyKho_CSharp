using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO.ThongKeDTO
{
    public class ThongKeTonKhoDTO
    {
        private int masp;
        private string tensp;
        private int stt;
        private int tonDauKy;
        private int tonCuoiKy;
        private int nhapTrongKy;
        private int xuatTrongKy;

        public ThongKeTonKhoDTO() { }

        public ThongKeTonKhoDTO(int _stt, int _masp, string _tensp,  int _tondauky, int _nhaptrongky, int _xuatTrongKy, int _tonCuoiKy)
        {
            masp = _masp;
            tensp = _tensp;
            stt = _stt;
            tonDauKy = _tondauky;
            nhapTrongKy= _nhaptrongky;
            xuatTrongKy = _xuatTrongKy;
            tonCuoiKy = _tonCuoiKy;
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


        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }

        public int TonDauKy
        {
            get { return tonDauKy; }
            set { tonDauKy = value; }
        }

        public int NhapTrongKy
        {
            get { return nhapTrongKy; }
            set { nhapTrongKy = value; }
        }

        public int XuatTrongKy
        {
            get { return xuatTrongKy; }
            set { xuatTrongKy = value; }
        }

        public int TonCuoiKy
        {
            get { return tonCuoiKy; }
            set { tonCuoiKy = value; }
        }


    }
}
