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
    internal class KhuVucKhoBUS
    {
        public readonly KhuVucKhoDAO khuVucKhoDAO = KhuVucKhoDAO.getInstance();
        private BindingList<KhuVucKhoDTO> listKVK;


        public BindingList<KhuVucKhoDTO> getKhuVucKhoList()
        {
            listKVK = khuVucKhoDAO.SelectAll();
            return listKVK;
        }

        public KhuVucKhoBUS() {
            listKVK = khuVucKhoDAO.SelectAll();
        }

        public String LayTenKhuVuc(SanPhamDTO sp)
        {


            KhuVucKhoDTO khuVucDTO;
            khuVucDTO = listKVK.FirstOrDefault(kv => kv.Makhuvuc == sp.Makhuvuc);//tra ve doi tượng đầu tiên đúng ddieuf kiện
            return khuVucDTO.Tenkhuvuc.ToString();

        }

        public int LayMaKhuVuc(String tenkv)
        {

            if (string.IsNullOrEmpty(tenkv) || tenkv == "Tất cả")
            {
                return 0;
            }
            KhuVucKhoDTO khuVucDTO;
            khuVucDTO = listKVK.FirstOrDefault(kv => kv.Tenkhuvuc == tenkv);//tra ve doi tượng đầu tiên đúng ddieuf kiện
            if(khuVucDTO == null)
            {
                return 0;
            }    
            return khuVucDTO.Makhuvuc;

        }

        public BindingList<KhuVucKhoDTO> SearchKho(string search)
        {
            List<KhuVucKhoDTO> result = listKVK.Where(kvk =>
                kvk.Makhuvuc.ToString().ToLower().Contains(search) ||
                kvk.Tenkhuvuc.ToLower().Contains(search) ||
                kvk.Diachi.ToLower().Contains(search) ||
                kvk.Sdt.ToLower().Contains(search) ||
                kvk.Email.ToLower().Contains(search)
            ).ToList();

            return new BindingList<KhuVucKhoDTO>(result);
        }


    }
}
