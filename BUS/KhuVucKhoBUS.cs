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
            khuVucDTO = listKVK.FirstOrDefault(kv => kv.Makhuvuc == sp.Makhuvuc);
            return khuVucDTO.Tenkhuvuc.ToString();

           


        }


    }
}
