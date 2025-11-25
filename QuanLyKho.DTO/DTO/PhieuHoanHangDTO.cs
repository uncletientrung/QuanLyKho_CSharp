using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class PhieuHoanHangDTO
    {
        // contructor
        public PhieuHoanHangDTO() { }
        public PhieuHoanHangDTO(int _maphieuhoan, int _maphieuxuat, int _manhanvien, decimal _tongtien, DateTime _thoigian)
        {
            maphieuhoan = _maphieuhoan;
            maphieuxuat = _maphieuxuat;
            manhanvien = _manhanvien;
            tongtien = _tongtien;
            thoigian = _thoigian;
        }
        
        // get-set
        public int maphieuhoan { get; set; }
        public int maphieuxuat { get; set; }
        public int manhanvien { get; set; }
        public decimal tongtien { get; set; }
        public DateTime thoigian { get; set; }
    }
}