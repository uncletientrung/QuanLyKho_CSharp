using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class ChiTietHoanHangDTO
    {
        // contructor
        public ChiTietHoanHangDTO() {}

        public ChiTietHoanHangDTO(int _maphieuhoan, int _masanpham, string _lydo, int _soluong, int _trangthai, decimal _thanhtien)
        {
            maphieuhoan = _maphieuhoan;
            masanpham = _masanpham;
            lydo = _lydo;
            soluong = _soluong;
            trangthai = _trangthai;
            thanhtien = _thanhtien;
        }

        // get-set
        public int maphieuhoan { get; set; }
        public int masanpham { get; set; }
        public string lydo { get; set; }
        public int soluong { get; set; }
        public int trangthai { get; set; }
        public decimal thanhtien { get; set; }
    }
}