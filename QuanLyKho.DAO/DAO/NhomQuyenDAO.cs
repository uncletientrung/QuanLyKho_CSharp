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
    public class NhomQuyenDAO : DAOInterface<NhomQuyenDTO>
    {
        public static NhomQuyenDAO getInstance()
        {
            return new NhomQuyenDAO();
        }
        public int Delete(int t)
        {
            int result = 0;
            string sql = $"UPDATE nhomquyen Set trangthai= 0 WHERE manhomquyen={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int GetAutoIncrement()
        {
            int result = 0;
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'quanlikhoquanaom' " +
                             "AND TABLE_NAME = 'nhomquyen'";

                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                {
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = Convert.ToInt32(value);
                    }
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy AUTO_INCREMENT: " + ex.Message);
            }
            return result;
        }

        public int Insert(NhomQuyenDTO t)
        {
            int result = 0;
            string sql = $"INSERT into nhomquyen(tennhomquyen, trangthai) " +
                    $"values ('{t.Tennhomquyen}',{t.Trangthai})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<NhomQuyenDTO> SelectAll()
        {
            BindingList<NhomQuyenDTO> result = new BindingList<NhomQuyenDTO>();
            try
            {
                string sql = "SELECT * FROM nhomquyen";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NhomQuyenDTO nv = new NhomQuyenDTO
                        {
                            Manhomquyen = reader.GetInt32("manhomquyen"),
                            Tennhomquyen = reader.GetString("tennhomquyen"),
                            Trangthai = reader.GetInt32("trangthai")

                        };
                        result.Add(nv);
                    }
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public NhomQuyenDTO SelectById(int t)
        {
            NhomQuyenDTO result= new NhomQuyenDTO();
            try
            {
                string sql = $"SELECT * FROM nhomquyen WHERE manhomquyen = {t}";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Manhomquyen = reader.GetInt32("manhomquyen");
                    result.Tennhomquyen = reader.GetString("tennhomquyen");
                    result.Trangthai = reader.GetInt32("trangthai");
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public int Update(NhomQuyenDTO t)
        {
            int result = 0;
           string sql = $"UPDATE nhomquyen SET tennhomquyen = '{t.Tennhomquyen}', trangthai = {t.Trangthai} " +
             $"WHERE manhomquyen = {t.Manhomquyen}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
    }
}
