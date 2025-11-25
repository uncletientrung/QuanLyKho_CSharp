using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.BUS
{
    public class DanhMucChucNangBUS
    {
        public readonly DanhMucChucNangDAO dmcnDAO = DanhMucChucNangDAO.getInstance();
        private BindingList<DanhMucChucNangDTO> listDMCN;
        public DanhMucChucNangBUS()
        {
            listDMCN = dmcnDAO.SelectAll();
        }
        public BindingList<DanhMucChucNangDTO> getListDMCN()
        {
            return listDMCN;
        }
        public int getIdByNameCN(string nameCN)
        {
            int result = 0;
            listDMCN = dmcnDAO.SelectAll();
            foreach(DanhMucChucNangDTO item in listDMCN)
            {
                if (item.Tenchucnang.Equals(nameCN))
                {
                    result = item.Machucnang;
                    break;
                }
            }
            return result;
        }
        public string getNameById(int id)
        {
            string result = "";
            listDMCN = dmcnDAO.SelectAll();
            foreach (DanhMucChucNangDTO item in listDMCN)
            {
                if (item.Machucnang == id)
                {
                    result = item.Tenchucnang;
                    break;
                }
            }
            return result;
        }

    }
}
