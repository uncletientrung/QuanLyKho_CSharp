using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DTO
{
    public class DanhMucChucNangDTO
    {
        private int machucnang;
        private string tenchucnang;
        private int trangthai;

        public DanhMucChucNangDTO() { }

        public DanhMucChucNangDTO(int _machucnang, string _tenchucnang, int _trangthai)
        {
            machucnang = _machucnang;
            tenchucnang = _tenchucnang;
            trangthai = _trangthai;
        }

        public int Machucnang
        {
            get { return machucnang; }
            set { machucnang = value; }
        }

        public string Tenchucnang
        {
            get { return tenchucnang; }
            set { tenchucnang = value; }
        }

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
    }
}
