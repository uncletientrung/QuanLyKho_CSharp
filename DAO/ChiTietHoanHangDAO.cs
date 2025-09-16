using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.DAO
{
    public class ChiTietHoanHangDAO : DAOInterface<ChiTietHoanHangDTO>, ChiTietInterface<ChiTietHoanHangDTO>
    {
        public static ChiTietHoanHangDAO getInstance() => new ChiTietHoanHangDAO();

        public int Insert(ChiTietHoanHangDTO t) { return 0; }
        public int Update(ChiTietHoanHangDTO t) { return 0; }
        public int Delete(string t) { return 0; }
        public BindingList<ChiTietHoanHangDTO> SelectAll()
        {
            BindingList<ChiTietHoanHangDTO> result = new BindingList<ChiTietHoanHangDTO>();
            // ...code lấy danh sách...
            return result;
        }
        public ChiTietHoanHangDTO SelectById(string t) { return null; }
        public int GetAutoIncrement() { return 0; }
    }
}