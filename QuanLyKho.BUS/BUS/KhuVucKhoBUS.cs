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
    public class KhuVucKhoBUS
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

            if (string.IsNullOrEmpty(tenkv) || tenkv == "Tất cả khu vực")
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

        public int getAutoMaKVK()
        {
            return khuVucKhoDAO.GetAutoIncrement();
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

        public Boolean insertKhuVuc(KhuVucKhoDTO kvk)
        {
            Boolean result = khuVucKhoDAO.Insert(kvk) != 0;
            if (result)
            {
                listKVK.Add(kvk);
            }
            return result;
        }

        public Boolean removeKhuVuc(int maKho)
        {
            KhuVucKhoDTO kvkXoa = khuVucKhoDAO.SelectById(maKho);
            Boolean result = khuVucKhoDAO.Delete(maKho) != 0;
            if (result)
            {
                listKVK.Remove(kvkXoa);
            }
            return result;
        }

        public Boolean updateKhuVuc(KhuVucKhoDTO kvk)
        {
            Boolean result = khuVucKhoDAO.Update(kvk) != 0;
            if (result)
            {
                KhuVucKhoDTO kvkCapNhat = listKVK.FirstOrDefault(k => k.Makhuvuc == kvk.Makhuvuc);
                if (kvkCapNhat != null)
                {
                    kvkCapNhat.Tenkhuvuc = kvk.Tenkhuvuc;
                    kvkCapNhat.Diachi = kvk.Diachi;
                    kvkCapNhat.Sdt = kvk.Sdt;
                    kvkCapNhat.Email = kvk.Email;
                }
            }
            return result;
        }

        public KhuVucKhoDTO getKVKById(int maKho)
        {
            return khuVucKhoDAO.SelectById(maKho);
        }


    }
}
