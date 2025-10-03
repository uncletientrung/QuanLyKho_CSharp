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
    internal class LoaiDAO : DAOInterface<LoaiDTO>
    {

        public static LoaiDAO getInstance()
        {
            return new LoaiDAO();
        }
        public int Delete(int t)
        {
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public int Insert(LoaiDTO t)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public int Update(LoaiDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
