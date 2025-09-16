using MySql.Data.MySqlClient;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.DAO
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
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public int Insert(TaiKhoanDTO t)
        {
            throw new NotImplementedException();
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

        public TaiKhoanDTO SelectById(int t)
        {
            throw new NotImplementedException();
        }

        public int Update(TaiKhoanDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
