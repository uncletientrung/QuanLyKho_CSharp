using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
    public class SizeDAO : DAOInterface<SizeDTO>
    {

        public static SizeDAO getInstance() {
            return new SizeDAO();
        }
        public int Delete(int t)
        {
            int result = 0; 
            string sql = $"DELETE FROM size WHERE masize={t}";
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
                             "AND TABLE_NAME = 'size';";

                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if ( reader.Read() )
                {
                    result = reader.GetInt32("AUTO_INCREMENT");
                }
                reader.Close(); 
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy AUTO_INCREMENT: " + ex.Message);
            }
            return result;
        }

        public int Insert(SizeDTO t)
        {
            int result = 0;
                        string sql = $"INSERT into size(tensize, ghichu) " +
                                $"values ('{t.Tensize}', '{t.Ghichu}')";
            result = ConnectionHelper.getExecuteNonQuery(sql);

            return result;
        }

        public BindingList<SizeDTO> SelectAll()
        {
            BindingList<SizeDTO> result = new BindingList<SizeDTO>();

            try
            {
                String sql = "SELECT * FROM size";
                //mo ket noi
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SizeDTO size = new SizeDTO
                    {
                        Masize = reader.GetInt32("masize"),
                        Tensize = reader.GetString("tensize"),
                        Ghichu = reader.GetString("ghichu")
                    };
                    result.Add(size);

                }

                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }


        public SizeDTO SelectById(int t)
        {
            SizeDTO result = new SizeDTO();
            try
            {
                string sql = $"SELECT * FROM size WHERE masize = {t}";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = new SizeDTO
                    {
                        Masize = reader.GetInt32("masize"),
                        Tensize = reader.GetString("tensize"),
                        Ghichu = reader.GetString("ghichu")
                    };
                }

                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public int Update(SizeDTO t)
        {
            int result = 0;
            string sql = $"UPDATE size Set tensize= '{t.Tensize}', ghichu= '{t.Ghichu}'" +
                   $" WHERE masize={t.Masize}";
            result = ConnectionHelper.getExecuteNonQuery(sql);

            return result;
        }
    }
}
