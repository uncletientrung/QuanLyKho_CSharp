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
    public class NhomQuyenDAO : DAOInterface<NhomQuyenDTO>
    {
        public static NhomQuyenDAO getInstance()
        {
            return new NhomQuyenDAO();
        }
        public int Delete(int t)
        {
            throw new NotImplementedException();
        }

        public int GetAutoIncrement()
        {
            throw new NotImplementedException();
        }

        public int Insert(NhomQuyenDTO t)
        {
            throw new NotImplementedException();
        }

        public BindingList<NhomQuyenDTO> SelectAll()
        {
            BindingList<NhomQuyenDTO> result = new BindingList<NhomQuyenDTO>();
            try
            {
                string sql = "SELECT * FROM nhomquyen";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NhomQuyenDTO nv = new NhomQuyenDTO
                        {
                            Manhomquyen = reader.GetInt32("manhomquyen"),
                            Tennhomquyen = reader.GetString("tennhomquyen"),
                            Trangthai = reader.GetInt32("trangthai")

                        };
                        result.Add(nv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public NhomQuyenDTO SelectById(int t)
        {
            NhomQuyenDTO result= new NhomQuyenDTO();
            try
            {
                string sql = $"SELECT * FROM nhomquyen WHERE manhomquyen = {t}";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Manhomquyen = reader.GetInt32("manhomquyen");
                    result.Tennhomquyen = reader.GetString("tennhomquyen");
                    result.Trangthai = reader.GetInt32("trangthai");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public int Update(NhomQuyenDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
