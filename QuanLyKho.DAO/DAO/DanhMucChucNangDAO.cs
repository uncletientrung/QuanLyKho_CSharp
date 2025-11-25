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
    public class DanhMucChucNangDAO : DAOInterface<DanhMucChucNangDTO>
    {
        public static DanhMucChucNangDAO getInstance()
        {
            return new DanhMucChucNangDAO();
        }
        public int Delete(int t)
        {
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public int Insert(DanhMucChucNangDTO t)
        {
            throw new NotImplementedException();
        }

        public BindingList<DanhMucChucNangDTO> SelectAll()
        {
            BindingList<DanhMucChucNangDTO> result = new BindingList<DanhMucChucNangDTO> ();
            try
            {
                string sql = "SELECT * FROM danhmucchucnang";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DanhMucChucNangDTO dmcn = new DanhMucChucNangDTO
                    {
                        Machucnang = reader.GetInt32("machucnang"),
                        Tenchucnang = reader.GetString("tenchucnang"),
                        Trangthai = reader.GetInt32("trangthai")
                    };
                    result.Add(dmcn);
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;  
        }

        public DanhMucChucNangDTO SelectById(int t)
        {
            DanhMucChucNangDTO result = new DanhMucChucNangDTO();
            try
            {
                string sql = $"SELECT * FROM danhmucchucnang WHERE machucnang= {t}";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Machucnang = reader.GetInt32("machucnang");
                    result.Tenchucnang = reader.GetString("tenchucnang");
                    result.Trangthai = reader.GetInt32("trangthai");
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public int Update(DanhMucChucNangDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
