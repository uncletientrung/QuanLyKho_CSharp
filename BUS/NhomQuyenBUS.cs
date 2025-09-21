using MySqlX.XDevAPI.Common;
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
    public class NhomQuyenBUS
    {
        private readonly NhomQuyenDAO nqDAO= NhomQuyenDAO.getInstance();
        private readonly ChiTietQuyenDAO ctnqDAO = ChiTietQuyenDAO.getInstance();
        private BindingList<NhomQuyenDTO> listNQ;
        
        public NhomQuyenBUS()
        {
            listNQ=nqDAO.SelectAll();
        }
        public BindingList<NhomQuyenDTO> getListNQ()
        {
            listNQ = nqDAO.SelectAll();
            return listNQ;
        }
        public NhomQuyenDTO getNQById(int id)
        {
            NhomQuyenDTO result = new NhomQuyenDTO();
            result=nqDAO.SelectById(id);
            return result;
        }
        public int getAutoMaNQ()
        {

            return nqDAO.GetAutoIncrement();
        }
        
        public Boolean addCTNhomQuyen(BindingList<ChiTietQuyenDTO> listCTQ)
        {
            bool result = ctnqDAO.Insert(listCTQ) !=0;
            return result;
        }
        public Boolean addNhomQuyen(int maNQ,string TenNQ, BindingList<ChiTietQuyenDTO> listCTQ)
        {
            NhomQuyenDTO nq = new NhomQuyenDTO(maNQ, TenNQ, 1);
            Boolean result= nqDAO.Insert(nq) !=0;
            if (result)
            {
                listNQ.Add(nq);
                addCTNhomQuyen(listCTQ);
            }
            return result;
        }
        public BindingList<ChiTietQuyenDTO> getListCTNQByIdNQ(int manhomquyen)
        {
            BindingList<ChiTietQuyenDTO> result = new BindingList<ChiTietQuyenDTO>();
            result= ctnqDAO.SelectAll(manhomquyen);
            return result;
        }
        public Boolean DeleteNhomQuyen(int manhomquyen)
        {
            Boolean result= nqDAO.Delete(manhomquyen) !=0;
            if(result) // Xoa được trong db rồi xóa trong list
            {
                NhomQuyenDTO nqXoa = this.getNQById(manhomquyen);
                listNQ.Remove(nqXoa);
                // Xóa hẳn chi tiết
                ctnqDAO.Delete(manhomquyen);
            }
            return result;
        }

        

    }
}
