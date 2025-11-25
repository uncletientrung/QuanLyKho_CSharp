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
    public class KhuVucKhoDAO:DAOInterface<KhuVucKhoDTO>

    {

        public static KhuVucKhoDAO getInstance()
        {
            return new KhuVucKhoDAO();
        }
        public int Insert(KhuVucKhoDTO t)
        {
            int result = 0;
            string sql = $"INSERT into khuvuckho(tenkhuvuc, diachi, sdt, email) " +
                    $"values ('{t.Tenkhuvuc}', '{t.Diachi}','{t.Sdt}'," +
                    $"'{t.Email}')";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(KhuVucKhoDTO t)
        {
            int result = 0;
            string sql = $"UPDATE khuvuckho Set tenkhuvuc= '{t.Tenkhuvuc}', diachi= '{t.Diachi}'," +
                   $" sdt='{t.Sdt}', email ='{t.Email}' WHERE makhuvuc={t.Makhuvuc}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Delete(int t)
        {
            int result = 0;
            string sql = $"DELETE FROM khuvuckho WHERE makhuvuc={t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<KhuVucKhoDTO> SelectAll()
        {
            BindingList<KhuVucKhoDTO> result = new BindingList<KhuVucKhoDTO>();
            try {
                string sql = "select * from khuvuckho";
                //mo ket noi 
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KhuVucKhoDTO kv = new KhuVucKhoDTO
                    {
                        Makhuvuc = reader.GetInt32("makhuvuc"),
                        Tenkhuvuc = reader.GetString("tenkhuvuc"),
                        Diachi = reader.GetString("diachi"),
                        Sdt = reader.GetString("sdt"),
                        Email = reader.GetString("email"),
                    };
                    result.Add(kv);
                }
                ConnectionHelper.closeConnection();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public KhuVucKhoDTO SelectById(int t)
        {
            KhuVucKhoDTO result = new KhuVucKhoDTO();
            try
            {
                string sql = $"SELECT * FROM khuvuckho WHERE makhuvuc={t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Makhuvuc = reader.GetInt32("makhuvuc");
                        result.Tenkhuvuc = reader.GetString("tenkhuvuc");
                        result.Diachi = reader.GetString("diachi");
                        result.Sdt = reader.GetString("sdt");
                        result.Email = reader.GetString("email");
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
                             "AND TABLE_NAME = 'khuvuckho';";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
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
                MessageBox.Show("Lỗi khi lấy AUTO_INCREMENT: " + ex.Message);
            }
            return result;
        }
    }
}
