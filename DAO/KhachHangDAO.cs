using MySql.Data.MySqlClient;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.DAO
{
    public class KhachHangDAO : DAOInterface<KhachHangDTO>
    {
        public static KhachHangDAO getInstance()
        {
            return new KhachHangDAO();
        }

        // Thêm khách hàng
        public int Insert(KhachHangDTO kh)
        {
            int result = 0;
            string sql = $"INSERT INTO khachhang(tenkhachhang, email, ngaysinh, sdt, trangthai) " +
                         $"VALUES ('{kh.Tenkhachhang}', '{kh.Email}', '{kh.Ngaysinh:yyyy-MM-dd}', '{kh.Sdt}', {kh.Trangthai})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        // Sửa khách hàng
        public int Update(KhachHangDTO kh)
        {
            int result = 0;
            string sql = $"UPDATE khachhang SET tenkhachhang='{kh.Tenkhachhang}', email='{kh.Email}', " +
                         $"ngaysinh='{kh.Ngaysinh:yyyy-MM-dd}', sdt='{kh.Sdt}' " +
                         $"WHERE makh={kh.Makh}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        // Xóa (mềm) khách hàng
        public int Delete(int makh)
        {
            int result = 0;
            string sql = $"UPDATE khachhang SET trangthai=0 WHERE makh={makh}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        // Lấy tất cả khách hàng
        public BindingList<KhachHangDTO> SelectAll()
        {
            BindingList<KhachHangDTO> result = new BindingList<KhachHangDTO>();
            try
            {
                string sql = "SELECT * FROM khachhang";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
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
                MessageBox.Show("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
            }
            return result;
        }

        // Lấy khách hàng theo ID
        public KhachHangDTO SelectById(int makh)
        {
            KhachHangDTO kh = new KhachHangDTO();
            try
            {
                string sql = $"SELECT * FROM khachhang WHERE makh={makh}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        kh.Makh = reader.GetInt32("makh");
                        kh.Tenkhachhang = reader.GetString("tenkhachhang");
                        kh.Email = reader.GetString("email");
                        kh.Ngaysinh = reader.GetDateTime("ngaysinh");
                        kh.Sdt = reader.GetString("sdt");
                        kh.Trangthai = reader.GetInt32("trangthai");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy khách hàng theo ID: " + ex.Message);
            }
            return kh;
        }

        // Lấy AUTO_INCREMENT tiếp theo
        public int GetAutoIncrement()
        {
            int result = 0;
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'your_database_name' " +
                             "AND TABLE_NAME = 'khachhang'";

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
