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

        public KhuVucKhoDTO getKVKById(int maKVK)
        {
            return khuVucKhoDAO.SelectById(maKVK);
        }

        public Boolean updateKhuVuc(KhuVucKhoDTO kvkSua)
        {
            Boolean result = khuVucKhoDAO.Update(kvkSua) != 0;
            if (result)
            {
                KhuVucKhoDTO kvk = listKVK.FirstOrDefault(x => x.Makhuvuc == kvkSua.Makhuvuc);
                if (kvk != null)
                {
                    kvk.Tenkhuvuc = kvkSua.Tenkhuvuc;
                    kvk.Diachi = kvkSua.Diachi;
                    kvk.Sdt = kvkSua.Sdt;
                    kvk.Email = kvkSua.Email;
                }
            }
            return result;
        }

        public Boolean removeKhuVuc(int maKVK)
        {
            KhuVucKhoDTO kvkXoa = khuVucKhoDAO.SelectById(maKVK);
            Boolean result = khuVucKhoDAO.Delete(maKVK) != 0;
            if (result)
            {
                listKVK.Remove(kvkXoa);
            }
            return result;
        }
    }
}
