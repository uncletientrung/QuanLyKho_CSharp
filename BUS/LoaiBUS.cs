using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.BUS
{
    internal class LoaiBUS
    {
        private readonly LoaiDAO loaiDAO = LoaiDAO.getInstance();
        private BindingList<LoaiDTO> loaiList;
    

        public LoaiBUS()
        {
                loaiList = loaiDAO.SelectAll();
        }

        public BindingList<LoaiDTO> getLoaiList()
        {
                loaiList = loaiDAO.SelectAll();
                return loaiList;
        }

        public String LayTenLoai(SanPhamDTO sp)
        {
            LoaiDTO loai;
            loai = loaiList.FirstOrDefault(l=> l.Maloai== sp.Maloai);
            return loai.Tenloai.ToString();
        }


    } 
}
