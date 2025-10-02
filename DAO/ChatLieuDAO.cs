using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.Helper;
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

namespace QuanLyKho_CSharp.DAO
{
    internal class ChatLieuDAO : DAOInterface<ChatLieuDTO>

    {

        public static ChatLieuDAO getInstance()
        {
            return new ChatLieuDAO();
        }


        public BindingList<ChatLieuDTO> selectAll()
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
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public int Insert(ChatLieuDTO t)
        {
            throw new NotImplementedException();
        }

        public System.ComponentModel.BindingList<ChatLieuDTO> SelectAll()
        {
            throw new NotImplementedException();
        }

        public ChatLieuDTO SelectById(int t)
        {
            throw new NotImplementedException();
        }

        public int Update(ChatLieuDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
