using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho.DTO;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyKho.DAO
{
    public class ChatLieuDAO : DAOInterface<ChatLieuDTO>

    {

        public static ChatLieuDAO getInstance()
        {
            return new ChatLieuDAO();
        }


        public BindingList<ChatLieuDTO> SelectAll()
        {
            BindingList<ChatLieuDTO> result = new BindingList<ChatLieuDTO>();
            try
            {
                string sql = "Select * from chatlieu";
                //mo ket noi
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    ChatLieuDTO chatLieu = new ChatLieuDTO
                    {
                        Machatlieu = reader.GetInt32("machatlieu"),
                        Tenchatlieu = reader.GetString("tenchatlieu")
                    };
                    result.Add(chatLieu);
                }
                ConnectionHelper.closeConnection();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public int Delete(int t)
        {
            int result = 0;
            string sql = $"DELETE FROM chatlieu WHERE machatlieu={t}";
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
                             "AND TABLE_NAME = 'chatlieu';";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader.GetInt32("AUTO_INCREMENT");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy AUTO_INCREMENT: " + ex.Message);
            }
            return result;
        }

        public int Insert(ChatLieuDTO t)
        {
            int result = 0;
            string sql = $"INSERT into chatlieu(tenchatlieu) " +
                    $"values ('{t.Tenchatlieu}')";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public ChatLieuDTO SelectById(int t)
        {
            ChatLieuDTO result = new ChatLieuDTO();
            try
            {
                string sql = $"SELECT * FROM chatlieu WHERE machatlieu={t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Machatlieu = reader.GetInt32("machatlieu");
                        result.Tenchatlieu = reader.GetString("tenchatlieu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public int Update(ChatLieuDTO t)
        {
            int result = 0;
            string sql = $"UPDATE chatlieu Set tenchatlieu= '{t.Tenchatlieu}' WHERE machatlieu={t.Machatlieu}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
            
        }
    }
}
