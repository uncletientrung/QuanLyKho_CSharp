using ComponentFactory.Krypton.Toolkit;
using Guna.UI2.WinForms;
using MySqlX.XDevAPI.Common;
using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.BUS
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

        // Lấy chi tiết quyền bằng mã nhóm quyền
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
        // Sửa nhóm quyền
        public Boolean UpdateNhomQuyen(NhomQuyenDTO NQ, BindingList<ChiTietQuyenDTO> listCTQ)
        {
            Boolean result = nqDAO.Update(NQ) != 0;
            if(result) // sửa trên database được thì sửa vào list rồi sửa chi tiết
            {
                NhomQuyenDTO nqCheck =listNQ.FirstOrDefault(x => x.Manhomquyen == NQ.Manhomquyen);
                if(nqCheck != null)
                {
                    nqCheck.Tennhomquyen = NQ.Tennhomquyen;
                    nqCheck.Trangthai= NQ.Trangthai;
                    ctnqDAO.Update(listCTQ, NQ.Manhomquyen);
                }
            }   
            return result;
        }

        public BindingList<NhomQuyenDTO> searchNhomQuyen(string text){
            var result = listNQ.Where(
                        item => item.Tennhomquyen.ToString().ToLower().Contains(text.ToLower()) ||
                                item.Manhomquyen.ToString().Contains(text.ToLower())).ToList();
            return new BindingList<NhomQuyenDTO>(result);

        }
        public BindingList<Guna2Button> GetAllButtons(Control parent)
        {
            List<Guna2Button> result= parent.Controls
                         .Cast<Control>() // Ép về IEnumerable<Control>
                         .SelectMany(ctrl => ctrl.HasChildren
                                              ? GetAllButtons(ctrl)
                                              : Enumerable.Empty<Guna2Button>())
                         .Concat(parent.Controls.OfType<Guna2Button>())
                         .ToList();

            return new BindingList<Guna2Button>(result);
        }



    }
}
