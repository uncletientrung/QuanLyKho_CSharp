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
    public class ChiTietQuyenDAO : ChiTietInterface<ChiTietQuyenDTO>
    {
        public static ChiTietQuyenDAO getInstance()
        {
            return new ChiTietQuyenDAO();
        }
        public int Delete(int manhomquyen)
        {
            int result = 0;
            string sql = $"DELETE FROM ctquyen WHERE manhomquyen = {manhomquyen}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Insert(BindingList<ChiTietQuyenDTO> listCTNQ)
        {
            int result = 0;
            foreach(ChiTietQuyenDTO ct in listCTNQ)
            {
                string sql = $"INSERT INTO ctquyen(manhomquyen, machucnang, hanhdong, trangthai) " +
                         $"VALUES ({ct.Manhomquyen}, {ct.Machucnang}, " +
                         $"'{ct.Hanhdong}', {ct.Trangthai}) ";
                result=ConnectionHelper.getExecuteNonQuery(sql);
            }
            return result;
        }

        public BindingList<ChiTietQuyenDTO> SelectAll(int ma) // Lấy bằng mã nhóm quyền
        {
            BindingList<ChiTietQuyenDTO> result= new BindingList<ChiTietQuyenDTO> ();
            try
            {
                string sql = $"SELECT * FROM ctquyen WHERE manhomquyen= {ma}";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietQuyenDTO ctQuyen = new ChiTietQuyenDTO
                    {
                        Manhomquyen = reader.GetInt32("manhomquyen"),
                        Machucnang = reader.GetInt32("machucnang"),
                        Hanhdong = reader.GetString("hanhdong"),
                        Trangthai = reader.GetInt32("trangthai")
                    };
                    result.Add(ctQuyen);
                }
                ConnectionHelper.closeConnection();
            }
            catch(Exception ex) 
            {
                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                return result;
        }
        public BindingList<ChiTietQuyenDTO> SelectAllByMaChucNang(int ma) // Lấy bằng mã chức năng
        {
            BindingList<ChiTietQuyenDTO> result = new BindingList<ChiTietQuyenDTO>();
            try
            {
                string sql = $"SELECT * FROM ctquyen WHERE machucnang= {ma}";
                ConnectionHelper.getConnection();
                MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietQuyenDTO ctQuyen = new ChiTietQuyenDTO
                    {
                        Manhomquyen = reader.GetInt32("manhomquyen"),
                        Machucnang = reader.GetInt32("machucnang"),
                        Hanhdong = reader.GetString("hanhdong"),
                        Trangthai = reader.GetInt32("trangthai")
                    };
                    result.Add(ctQuyen);
                }
                ConnectionHelper.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public int Update(BindingList<ChiTietQuyenDTO> listCTNQ, int maNhomQuyen)
        {
            int result = this.Delete(maNhomQuyen);
            if(result != 0)
            {
                result = this.Insert(listCTNQ);
            }
            return result;
        }
    }
}
