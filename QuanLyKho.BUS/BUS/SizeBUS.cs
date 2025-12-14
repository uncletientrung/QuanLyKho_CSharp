using Google.Protobuf.Collections;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BUS
{
    public class SizeBUS
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

        public int LayMaSize(String tenMA)
        {
            if (string.IsNullOrEmpty(tenMA) || tenMA == "Tất cả size")
            {
                return 0;
            }
            SizeDTO sizeDTO;
            sizeDTO = sizeList.FirstOrDefault(s => s.Tensize ==tenMA);
            if (sizeDTO == null)
            {
                return 0;
            }
            return sizeDTO.Masize;
        }

        public SizeDTO getSizeById(int maSize)
        {
            return sizeDAO.SelectById(maSize);
        }

        //public SizeDTO getSizeById(int maSize)
        //{
        //    return sizeDTO.SelectById(maSize);
        //}

        public Boolean insertSize(SizeDTO size)
        {
            Boolean result = sizeDAO.Insert(size) != 0;
            if (result)
            {
                sizeList.Add(size);
            }
            return result; 
        }

        public Boolean removeSize(int maSize)
        {
            SizeDTO sizeXoa = sizeDAO.SelectById(maSize);
            Boolean result = sizeDAO.Delete(maSize) != 0;
            if (result)
            {
                sizeList.Remove(sizeXoa);
            }
            return result; 
        }

        public Boolean updateSize(SizeDTO sizeSua)
        {
            Boolean result = sizeDAO.Update(sizeSua) != 0;
            if (result)
            {
                SizeDTO size = sizeList.FirstOrDefault(x => x.Masize == sizeSua.Masize);
                if (size != null)
                {
                    size.Tensize = sizeSua.Tensize;
                    size.Ghichu = sizeSua.Ghichu;
                    return result;
                }
            }
            return result;
        }

        public BindingList<SizeDTO> SearchSize(string search)
        {
            List<SizeDTO> result = sizeList.Where(size =>
                                        size.Tensize.ToLower().Contains(search.ToLower()) || // Tìm theo Tên Loại (không phân biệt chữ hoa/thường)
                                        size.Masize.ToString().Contains(search)).ToList();    // Tìm theo Mã Loại

            return new BindingList<SizeDTO>(result);
        }
        public int getAuto()
        {
            return sizeDAO.GetAutoIncrement();
        }

    }
}
