using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.Helper;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.DAO
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
    }
}