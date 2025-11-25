using System;

namespace QuanLyKho_CSharp.DTO
{
    public class DanhSachKiemKeDTO
    {
        // contructor
        public DanhSachKiemKeDTO() { }

        public DanhSachKiemKeDTO(int maphieukiemke, DateTime ngaynhap, string nhacungcap,
            string tenmathang, int soluongbaocao, int soluongthucnhap, string ghichu)
        {
            Maphieukiemke = maphieukiemke;
            Ngaynhap = ngaynhap;
            Nhacungcap = nhacungcap;
            Tenmathang = tenmathang;
            Soluongbaocao = soluongbaocao;
            Soluongthucnhap = soluongthucnhap;
            Ghichu = ghichu;
        }

        // get-set
        public int Maphieukiemke { get; set; }      
        public DateTime Ngaynhap { get; set; }      
        public string Nhacungcap { get; set; }      
        public string Tenmathang { get; set; }      
        public int Soluongbaocao { get; set; }      
        public int Soluongthucnhap { get; set; }    
        public int Chenhlech                        
        {
            get { return Soluongthucnhap - Soluongbaocao; }
        }
        public string Ghichu { get; set; }          
        
    }
}
