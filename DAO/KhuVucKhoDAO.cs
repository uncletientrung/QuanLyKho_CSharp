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
    internal class KhuVucKhoDAO:DAOInterface<KhuVucKhoDTO>

    {
//lồn tùng  buôn mê thuột làm lẹ mấy cái trong thông tin chung lẹ cho bố

        public static KhuVucKhoDAO getInstance()
        {
            return new KhuVucKhoDAO();
        }
        public int Insert(KhuVucKhoDTO t)
        {
            throw new NotImplementedException();
        }

        public int Update(KhuVucKhoDTO t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int t)
        {
            throw new NotImplementedException();
        }

        public BindingList<KhuVucKhoDTO> SelectAll()
        {
            BindingList<KhuVucKhoDTO> result = new BindingList<KhuVucKhoDTO>;
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
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public 
    }
}
