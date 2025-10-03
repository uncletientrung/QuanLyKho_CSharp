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
    internal class SizeDAO : DAOInterface<SizeDTO>
    {

        public static SizeDAO getInstance() {
            return new SizeDAO();
        }
        public int Delete(int t)
        {
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public int Insert(SizeDTO t)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int Update(SizeDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
