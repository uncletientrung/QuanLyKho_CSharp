using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using QuanLyKho.DTO;

using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class PhieuHoanHangDAO : DAOInterface<PhieuHoanHangDTO>
    {
        public static PhieuHoanHangDAO getInstance() => new PhieuHoanHangDAO();

        public int Insert(PhieuHoanHangDTO t) { return 0; }
        public int Update(PhieuHoanHangDTO t) { return 0; }
        public int Delete(string t) { return 0; }

        public BindingList<PhieuHoanHangDTO> SelectAll()
        {
            BindingList<PhieuHoanHangDTO> result = new BindingList<PhieuHoanHangDTO>();
            return result;
        }

        public PhieuHoanHangDTO SelectById(string t) { return null; }
        public int GetAutoIncrement() { return 0; }

        public int Delete(int t)
        {
            throw new NotImplementedException();
        }

        public PhieuHoanHangDTO SelectById(int t)
        {
            throw new NotImplementedException();
        }

        // KHÔNG CẦN phương thức GetTongSoLuongHoanHang nữa
    }
}