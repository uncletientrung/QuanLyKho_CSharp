using Google.Protobuf.Collections;
using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.BUS
{
    internal class SizeBUS
    {

        private readonly SizeDAO sizeDAO = SizeDAO.getInstance();
        private BindingList<SizeDTO> sizeList;


        public SizeBUS()
        {
            sizeList = sizeDAO.SelectAll();
        }


        public BindingList<SizeDTO> getSizeList()
        {
            sizeList = sizeDAO.SelectAll();
            return sizeList;
        }


        public String LayTenSize(SanPhamDTO sp)
        {
            SizeDTO sizeDTO;
            sizeDTO = sizeList.FirstOrDefault(s => s.Masize == sp.Masize);
            return sizeDTO.Tensize.ToString();
        }
    }
}
