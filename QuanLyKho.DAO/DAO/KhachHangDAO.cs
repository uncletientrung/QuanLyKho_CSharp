using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho.DTO;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class KhachHangDAO : DAOInterface<KhachHangDTO>
    {
        public static KhachHangDAO getInstance()
        {
            return new KhachHangDAO();
        }
        public int Insert(KhachHangDTO t)
        {
            int result = 0;
            string sql = $"INSERT into khachhang(tenkhachhang, email, ngaysinh, sdt, trangthai) " +
                    $"values ('{t.Tenkhachhang}', '{t.Email}','{t.Ngaysinh:yyyy-MM-dd}','{t.Sdt}',{t.Trangthai})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public int Update(KhachHangDTO t)
        {
            int result = 0;
            string sql = $"UPDATE khachhang Set tenkhachhang= '{t.Tenkhachhang}', email= '{t.Email}'," +
                   $" sdt='{t.Sdt}', ngaysinh='{t.Ngaysinh:yyyy-MM-dd}' WHERE makh={t.Makh}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public int Delete(int t)
        {
            int result = 0;
            string sql = $"UPDATE khachhang Set trangthai= 0 WHERE makh={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public BindingList<KhachHangDTO> SelectAll()
        {
            BindingList<KhachHangDTO> result = new BindingList<KhachHangDTO>();
            try
            {
                string sql = "SELECT * FROM khachhang";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhachHangDTO kh = new KhachHangDTO
                        {
                            Makh = reader.GetInt32("makh"),
                            Tenkhachhang = reader.GetString("tenkhachhang"),
                            Email = reader.GetString("email"),
                            Ngaysinh = reader.GetDateTime("ngaysinh"),
                            Sdt = reader.GetString("sdt"),
                            Trangthai = reader.GetInt32("trangthai")
                        };
                        result.Add(kh);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        
        public KhachHangDTO SelectById(int t)
        {
            KhachHangDTO result = new KhachHangDTO();
            try
            {
                string sql = $"SELECT * FROM khachhang WHERE makh={t}";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new KhachHangDTO
                        {
                            Makh = reader.GetInt32("makh"),
                            Tenkhachhang = reader.GetString("tenkhachhang"),
                            Email = reader.GetString("email"),
                            Ngaysinh = reader.GetDateTime("ngaysinh"),
                            Sdt = reader.GetString("sdt"),
                            Trangthai = reader.GetInt32("trangthai")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public int GetAutoIncrement()
        {
            int result = 0;
            try
            {
                string sql = "SELECT AUTO_INCREMENT " +
                    "FROM information_schema.TABLES " +
                    "WHERE TABLE_SCHEMA = 'quanlikhoquanaom' " +
                    "AND TABLE_NAME = 'khachhang';";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader.GetInt32("AUTO_INCREMENT");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

    }
}
