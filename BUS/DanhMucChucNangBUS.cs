using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.BUS
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

    }
}
