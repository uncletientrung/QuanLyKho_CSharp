using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho.DTO;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class NhaCungCapDAO : DAOInterface<NhaCungCapDTO>
    {
        public static NhaCungCapDAO getInstance()
        {
            return new NhaCungCapDAO();
        }
        public int Insert(NhaCungCapDTO t)
        {
            int result = 0;
            string sql = $"INSERT into nhacungcap(tenncc, diachincc, sdt, email, trangthai) " +
                    $"values ('{t.Tenncc}', '{t.Diachincc}','{t.Sdt}'," +
                    $"'{t.Email}',{t.Trangthai})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public int Update(NhaCungCapDTO t)
        {
            int result = 0;
            string sql = $"UPDATE nhacungcap Set tenncc= '{t.Tenncc}', diachincc= '{t.Diachincc}'," +
                   $" sdt='{t.Sdt}', email ='{t.Email}' WHERE mancc={t.Mancc}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public int Delete(int t)
        {
            int result = 0;
            string sql = $"UPDATE nhacungcap Set trangthai= 0 WHERE mancc={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }
        public BindingList<NhaCungCapDTO> SelectAll()
        {
            BindingList<NhaCungCapDTO> result = new BindingList<NhaCungCapDTO>();
            try
            {
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM nhacungcap", ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NhaCungCapDTO ncc = new NhaCungCapDTO
                        {
                            Mancc = reader.GetInt32("mancc"),
                            Tenncc = reader.GetString("tenncc"),
                            Diachincc = reader.GetString("diachincc"),
                            Sdt = reader.GetString("sdt"),
                            Email = reader.GetString("email"),
                            Trangthai = reader.GetInt32("trangthai")
                        };
                        result.Add(ncc);
                    }
                }
            }
                        catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public NhaCungCapDTO SelectById(int t)
        {
            NhaCungCapDTO ncc = null;
            try
            {
                string sql = $"SELECT * FROM nhacungcap WHERE mancc={t}";
                // Mở kết nối
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    ncc = new NhaCungCapDTO
                    {
                        Mancc = reader.GetInt32("mancc"),
                        Tenncc = reader.GetString("tenncc"),
                        Diachincc = reader.GetString("diachincc"),
                        Sdt = reader.GetString("sdt"),
                        Email = reader.GetString("email"),
                        Trangthai = reader.GetInt32("trangthai")
                    };
                }
                
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ncc;
        }

        public int GetAutoIncrement()
        {
            int result = 0;
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'quanlikhoquanaom' " +
                             "AND TABLE_NAME = 'nhacungcap'";

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

