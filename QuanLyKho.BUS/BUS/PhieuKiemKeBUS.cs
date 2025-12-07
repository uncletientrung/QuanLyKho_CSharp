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
        private static PhieuKiemKeBUS instance;
        private PhieuKiemKeDAO pkkDAO= PhieuKiemKeDAO.getInstance();
        public static PhieuKiemKeBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuKiemKeBUS();
                return instance;
            }
        }

        public BindingList<PhieuKiemKeDTO> getListPKK()
        {
            return PhieuKiemKeDAO.getInstance().SelectAll();
        }

        public PhieuKiemKeDTO getPKKById(int id)
        {
            PhieuKiemKeDTO result = new PhieuKiemKeDTO();
            return getListPKK().FirstOrDefault(pkk => pkk.Manhanvienkiem == id);
        }

        public int Insert(PhieuKiemKeDTO dto)
        {
            return PhieuKiemKeDAO.getInstance().Insert(dto);
        }

        public int Update(PhieuKiemKeDTO dto)
        {
            return PhieuKiemKeDAO.getInstance().Update(dto);
        }

        public Boolean Delete(int mapkk)
        {
            Boolean result = pkkDAO.Delete(mapkk) !=0;
            return result;
        }


    }
}