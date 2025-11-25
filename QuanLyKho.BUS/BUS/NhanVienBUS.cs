using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BUS
{
    public class NhanVienBUS
    {
        public readonly NhanVienDAO nvDAO=NhanVienDAO.getInstance();
        private BindingList<NhanVienDTO> listNV;

        public BindingList<NhanVienDTO> getListNV()
        {
            listNV = nvDAO.SelectAll();
            return listNV;
        }
        public NhanVienBUS()
        {
            listNV=nvDAO.SelectAll();
        }
        public string getNamebyID(int maNV)
        {
            NhanVienDTO nv = listNV.FirstOrDefault(x => x.Manv == maNV);

            if (nv != null)
            {
                return nv.Tennv;
            }

            return "Không tìm thấy";
        }


        // thêm hàm lấy mã nhân viên từ tên nhân viên để sử lý logic riêng trong HoanHangGUI
        public int GetMaNVByTenNV(string tenNV)
        {
            if (string.IsNullOrWhiteSpace(tenNV))
                return -1;

            // Đảm bảo listNV đã được load
            if (listNV == null || listNV.Count == 0)
            {
                try
                {
                    listNV = nvDAO.SelectAll();
                }
                catch
                {
                    return -1;
                }
            }
            var nv = listNV.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Tennv) && x.Tennv.Trim().Equals(tenNV.Trim(), StringComparison.OrdinalIgnoreCase));

            if (nv != null)
                return nv.Manv;  

            return -1;
        }



        public Boolean removeNhanVien(int maNV) // Xóa trong database trước rồi xóa list
        {
            NhanVienDTO nvXoa=nvDAO.SelectById(maNV);
            Boolean result = nvDAO.Delete(maNV) !=0;
            if (result)
            {
                listNV.Remove(nvXoa);
            }
            return result;
        }
        public Boolean insertNhanVien(NhanVienDTO NV)
        {
            Boolean result = nvDAO.Insert(NV) !=0;
            if (result)
            {
                listNV.Add(NV);
            }
            return true;
        }
        public int getAutoMaNV()
        {
            return nvDAO.GetAutoIncrement();
        }
        public NhanVienDTO getNVById(int maNV)
        {
            NhanVienDTO nv = nvDAO.SelectById(maNV);
            return nv;
        }
        public Boolean updateNhanVien(NhanVienDTO nvSua)
        {
            Boolean result= nvDAO.Update(nvSua) !=0;
            if (result)
            {
                NhanVienDTO nv= listNV.FirstOrDefault(x => x.Manv ==  nvSua.Manv);
                if (nv != null)
                {
                    nv.Tennv = nvSua.Tennv;
                    nv.Gioitinh = nvSua.Gioitinh;
                    nv.Sdt = nvSua.Sdt;
                    nv.Ngaysinh = nvSua.Ngaysinh;
                    return result;
                }

            }
            return result;
        }
        public BindingList<NhanVienDTO> SearchNhanVien(string search)
        {
            List<NhanVienDTO> result = listNV.Where( nv => nv.Tennv.ToLower().Contains(search.ToLower()) ||
                                        nv.Manv.ToString().Contains(search) ||
                                        nv.Sdt.ToLower().Contains(search.ToLower())).ToList();
            return new BindingList<NhanVienDTO>(result);
        }
    }
}
