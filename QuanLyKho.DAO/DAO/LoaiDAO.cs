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
    public class LoaiDAO : DAOInterface<LoaiDTO>
    {

        public static LoaiDAO getInstance()
        {
            return new LoaiDAO();
        }
        public int Delete(int t)
        {
            int result = 0;
            string sql = $"DELETE FROM loai WHERE maloai={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);

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
                             "AND TABLE_NAME = 'loai';";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader.GetInt32("AUTO_INCREMENT");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy AUTO_INCREMENT: " + ex.Message);
            }

            return result;
        }

        public int Insert(LoaiDTO t)
        {

            int result = 0;
            string sql = $"INSERT into loai(tenloai) " +
                    $"values ('{t.Tenloai}')";
            result = ConnectionHelper.getExecuteNonQuery(sql);

            return result;
        }

        public BindingList<LoaiDTO> SelectAll()
        {
            BindingList<LoaiDTO> result = new BindingList<LoaiDTO>();
            try
            {
                String sql = "SELECT * FROM loai";
                //mo ket noi
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LoaiDTO loai = new LoaiDTO()
                    {
                        Maloai = reader.GetInt32("maloai"),
                        Tenloai = reader.GetString("tenloai")
                    };
                    result.Add(loai);
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public LoaiDTO SelectById(int t)
        {
            LoaiDTO result = new LoaiDTO();
            try
            {
                string sql = $"SELECT * FROM loai WHERE maloai={t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.Maloai = reader.GetInt32("maloai");
                            result.Tenloai = reader.GetString("tenloai");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public int Update(LoaiDTO t)
        {
            int result = 0;
            string sql = $"UPDATE loai Set tenloai= '{t.Tenloai}' WHERE maloai={t.Maloai}";
            result = ConnectionHelper.getExecuteNonQuery(sql);

            return result;
        }
    }
}
