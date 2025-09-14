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
    public class NhanVienDAO : DAOInterface<NhanVienDTO>
    {
        public static NhanVienDAO getInstance()
        {
            return new NhanVienDAO();
        }
        public int Insert(NhanVienDTO t) { /* code */ return 0; }
        public int Update(NhanVienDTO t) { return 0; }
        public int Delete(string t) { return 0; }
        public BindingList<NhanVienDTO> SelectAll() {
            BindingList<NhanVienDTO> result = new BindingList<NhanVienDTO>();
            try
            {
                string sql = "SELECT * FROM nhanvien";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NhanVienDTO nv = new NhanVienDTO
                        {
                            Manv = reader.GetInt32("manv"),
                            Tennv = reader.GetString("tennv"),
                            Gioitinh = reader.GetInt32("gioitinh"),
                            Sdt = reader.GetString("sdt"),
                            Ngaysinh = reader.GetDateTime("ngaysinh"),
                            Trangthai = reader.GetInt32("trangthai"),

                        };
                        result.Add(nv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return result;
        }
        public NhanVienDTO SelectById(string t) { return null; }
        public int GetAutoIncrement() { return 0; }
    }
}