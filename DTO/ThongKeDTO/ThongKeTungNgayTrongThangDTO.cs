﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.DTO.ThongKeDTO
{
    public class ThongKeTungNgayTrongThangDTO
    {
        private DateTime ngay;
        private int chiphi;
        private int doanhthu;
        private int loinhuan;

        public ThongKeTungNgayTrongThangDTO() { }

        public ThongKeTungNgayTrongThangDTO(DateTime _ngay, int _chiphi, int _doanhthu, int _loinhuan)
        {
            ngay = _ngay;
            chiphi = _chiphi;
            doanhthu = _doanhthu;
            loinhuan = _loinhuan;
        }

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
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
