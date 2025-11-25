using MySql.Data.MySqlClient;
using QuanLyKho.DTO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class TaiKhoanDAO : DAOInterface<TaiKhoanDTO>
    {
        public static TaiKhoanDAO getInstance()
        {
            return new TaiKhoanDAO();
        }
        public TaiKhoanDTO checkLogin(string username, string password)
        {
            TaiKhoanDTO result = new TaiKhoanDTO();
            try
            {
                string sql = $"SELECT * FROM taikhoan " +
                    $"WHERE tendangnhap={username} and matkhau={password}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Manv = reader.GetInt32("manv");
                        result.Tendangnhap = reader.GetString("tendangnhap");
                        result.Matkhau = reader.GetString("matkhau");
                        result.Manhomquyen = reader.GetInt32("manhomquyen");
                        result.Trangthai = reader.GetInt32("trangthai");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;

        }

        public int Delete(int t)
        {
            int result = 0;
            string sql = $"UPDATE taikhoan Set trangthai= 0 WHERE manv={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Insert(TaiKhoanDTO t)
        {
            int result = 0;
            string sql = $"INSERT into taikhoan(manv, tendangnhap, matkhau, manhomquyen, trangthai) " +
                    $"values ({t.Manv},'{t.Tendangnhap}', '{t.Matkhau}',{t.Manhomquyen}," +
                    $"{t.Trangthai})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<TaiKhoanDTO> SelectAll()
        {
            BindingList<TaiKhoanDTO> result = new BindingList<TaiKhoanDTO>();
            try
            {
                string sql = "SELECT * FROM taikhoan";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TaiKhoanDTO nv = new TaiKhoanDTO
                        {
                            Manv = reader.GetInt32("manv"),
                            Tendangnhap = reader.GetString("tendangnhap"),
                            Matkhau = reader.GetString("matkhau"),
                            Manhomquyen = reader.GetInt32("manhomquyen"),
                            Trangthai = reader.GetInt32("trangthai")

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
        public int Update(TaiKhoanDTO t)
        {
            int result = 0;
            string sql = $"UPDATE taikhoan Set tendangnhap= '{t.Tendangnhap}', matkhau= '{t.Matkhau}'," +
                   $" manhomquyen={t.Manhomquyen}, trangthai={t.Trangthai} WHERE manv={t.Manv}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public TaiKhoanDTO SelectById(int t)
        {
            TaiKhoanDTO result = new TaiKhoanDTO();
            try
            {
                string sql = $"SELECT * FROM taikhoan WHERE manv = {t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Manv = reader.GetInt32("manv");
                        result.Tendangnhap = reader.GetString("tendangnhap");
                        result.Matkhau = reader.GetString("matkhau");
                        result.Manhomquyen = reader.GetInt32("manhomquyen");
                        result.Trangthai = reader.GetInt32("trangthai");
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
                string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'quanlikhoquanaom' " +
                             "AND TABLE_NAME = 'taikhoan'";

                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                {
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = Convert.ToInt32(value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy AUTO_INCREMENT: " + ex.Message);
            }
            return result;
        }
    }

}
