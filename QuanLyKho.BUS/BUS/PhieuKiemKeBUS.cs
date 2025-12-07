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
            return getListPKK().FirstOrDefault(pkk => pkk.Manhanvienkiem == id);
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



    }
}