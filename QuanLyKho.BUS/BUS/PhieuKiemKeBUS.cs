using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuanLyKho.BUS
{
    public class PhieuKiemKeBUS
    {
        private PhieuKiemKeDAO pkkDAO= PhieuKiemKeDAO.getInstance();
        private ChiTietKiemKeDAO ctkkDAO = ChiTietKiemKeDAO.getInstance();
        private BindingList<PhieuKiemKeDTO> listPKK;
        private BindingList<ChiTietKiemKeDTO> listCTKKById;

        public PhieuKiemKeBUS()
        {
            listPKK = pkkDAO.SelectAll();
        }
        public BindingList<PhieuKiemKeDTO> getListPKK()
        {
            return listPKK;
        }

        public PhieuKiemKeDTO getPKKById(int id)
        {
            PhieuKiemKeDTO result = new PhieuKiemKeDTO();
            return getListPKK().FirstOrDefault(pkk => pkk.Maphieukiemke == id);
        }

        public Boolean Delete(int mapkk)
        {
            Boolean result = pkkDAO.Delete(mapkk) !=0;
            return result;
        }
        public BindingList<ChiTietKiemKeDTO> getlistCTKKById(int mapkk)
        {
            listCTKKById = ctkkDAO.SelectAll(mapkk);
            return listCTKKById;
        }
        public int getMaTiepTheo() { return pkkDAO.GetAutoIncrement(); }
        public Boolean insertPKK(PhieuKiemKeDTO pkk, BindingList<ChiTietKiemKeDTO> listctpkk)
        {
            Boolean result = pkkDAO.Insert(pkk) != 0;
            if(result)
            {
                listPKK.Add(pkk);
                ctkkDAO.Insert(listctpkk);
                listCTKKById = listctpkk;
            }
            return result;
        }

        public Boolean updateTrangThai(PhieuKiemKeDTO pkk)
        {
            Boolean result  = pkkDAO.Update(pkk) != 0;
            if (result)
            {
                var pkkSua = listPKK.FirstOrDefault(pk => pk.Maphieukiemke == pkk.Maphieukiemke);
                pkkSua.Thoigiancanbang = pkk.Thoigiancanbang;
                pkkSua.Trangthai = pkk.Trangthai;
            }
            return result;
        }



    }
}