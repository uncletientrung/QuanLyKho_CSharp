using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace QuanLyKho.BUS
{
    public class PhieuKiemKeBUS
    {
        private static PhieuKiemKeBUS instance;
        public static PhieuKiemKeBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuKiemKeBUS();
                return instance;
            }
        }

        public BindingList<PhieuKiemKeDTO> GetAll()
        {
            return PhieuKiemKeDAO.getInstance().SelectAll();
        }

        public PhieuKiemKeDTO GetById(int id)
        {
            return PhieuKiemKeDAO.getInstance().SelectById(id);
        }

        public int Insert(PhieuKiemKeDTO dto)
        {
            return PhieuKiemKeDAO.getInstance().Insert(dto);
        }

        public int Update(PhieuKiemKeDTO dto)
        {
            return PhieuKiemKeDAO.getInstance().Update(dto);
        }

        public int Delete(int id)
        {
            return PhieuKiemKeDAO.getInstance().Delete(id);
        }


        public int GetNextId()
        {
            var all = GetAll();
            if (all.Count == 0) return 1;
            return all[all.Count - 1].Maphieukiemke + 1;
        }
    }
}