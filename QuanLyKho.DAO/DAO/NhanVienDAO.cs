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
    public class NhanVienDAO : DAOInterface<NhanVienDTO>
    {
        public static NhanVienDAO getInstance()
        {
            return new NhanVienDAO();
        }
        public int Insert(NhanVienDTO t) { 
            int result = 0;
            string sql = $"INSERT into nhanvien(tennv, gioitinh, sdt, ngaysinh, trangthai) " +
                    $"values ('{t.Tennv}', {t.Gioitinh},'{t.Sdt}'," +
                    $"'{t.Ngaysinh:yyyy-MM-dd}',{t.Trangthai})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public int Update(NhanVienDTO t)
        {
            int result = 0;
            string sql = $"UPDATE nhanvien Set tennv= '{t.Tennv}', gioitinh= {t.Gioitinh}," +
                   $" sdt='{t.Sdt}', ngaysinh='{t.Ngaysinh:yyyy-MM-dd}' WHERE manv={t.Manv}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public int Delete(int t) {
            int result = 0;
            string sql = $"UPDATE nhanvien Set trangthai= 0 WHERE manv={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
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
        public NhanVienDTO SelectById(int t) {
            NhanVienDTO result = new NhanVienDTO();
            try
            {
                string sql = $"SELECT * FROM nhanvien WHERE manv = {t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Manv = reader.GetInt32("manv");
                        result.Tennv = reader.GetString("tennv");
                        result.Sdt = reader.GetString("sdt");
                        result.Ngaysinh = reader.GetDateTime("ngaysinh");
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
                             "AND TABLE_NAME = 'nhanvien'";

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


        // thêm hàm lấy ra mã nhân viên theo tên đăng nhập
        public int GetMaNhanVienByUserName(string userName)
        {
            int manv = 0;
            try
            {
                string sql = @"
                    SELECT manv 
                    FROM taikhoan 
                    WHERE tendangnhap = @username AND trangthai = 1
                    LIMIT 1;
                ";

                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        manv = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã nhân viên từ tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return manv;
        }



    }
}