using Org.BouncyCastle.Asn1.X509;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.BUS
{
    public class LoaiBUS
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
            if (loai == null) 
            {
                return "Không xác định";
            }
            return loai.Tenloai.ToString();
        }

        public int LayMaLoai(string tenLoai)
        {
            if (string.IsNullOrEmpty(tenLoai) || tenLoai == "Tất cả loại")
            {
                return 0; 
            }

            LoaiDTO loai = loaiList.FirstOrDefault(l => l.Tenloai == tenLoai);
            if (loai == null)
            {
                return 0; 
            }

            return loai.Maloai;
        }

        public LoaiDTO getLoaiById(int maLoai)
        {
            return loaiDAO.SelectById(maLoai);
        }

        public int getAutoMaLoai()
        {
            return loaiDAO.GetAutoIncrement();
        }

        public Boolean insertLoai(LoaiDTO Loai)
        {
            Boolean result = loaiDAO.Insert(Loai) != 0;
            if (result)
            {
                loaiList.Add(Loai);
            }
            return result; 
        }

        public Boolean removeLoai(int maLoai)
        {
            LoaiDTO loaiXoa = loaiDAO.SelectById(maLoai);
            Boolean result = loaiDAO.Delete(maLoai) != 0;
            if (result)
            {
                loaiList.Remove(loaiXoa);
            }
            return result;
        }

        public Boolean updateLoai(LoaiDTO loaiSua)
        {
            Boolean result = loaiDAO.Update(loaiSua) != 0;
            if (result)
            {
                LoaiDTO loai = loaiList.FirstOrDefault(x => x.Maloai == loaiSua.Maloai);
                if(loai != null)
                {
                    loai.Tenloai = loaiSua.Tenloai;
                    return result;
                }
            }
            return result;
        }
        
        public BindingList<LoaiDTO> SearchLoai(string search)
        {
            List<LoaiDTO> result = loaiList.Where(loai =>
                                        loai.Tenloai.ToLower().Contains(search.ToLower()) || // Tìm theo Tên Loại (không phân biệt chữ hoa/thường)
                                        loai.Maloai.ToString().Contains(search)).ToList();    // Tìm theo Mã Loại

            return new BindingList<LoaiDTO>(result);
        }



    }
}
