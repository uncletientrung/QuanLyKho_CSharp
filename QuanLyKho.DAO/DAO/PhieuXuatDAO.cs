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
    public class PhieuXuatDAO : DAOInterface<PhieuXuatDTO>
    {
        public static PhieuXuatDAO getInstance()
        {
            return new PhieuXuatDAO();
        }

        public int Insert(PhieuXuatDTO t)
        {
            int result = 0;
            string sql = $"INSERT INTO phieuxuat(manv, thoigiantao, tongtien, trangthai, makh) " +
                        $"VALUES ({t.Manv}, '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', {t.Tongtien}, {t.Trangthai}, {t.Makh})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(PhieuXuatDTO t)
        {
            int result = 0;
            string sql = $"UPDATE phieuxuat SET manv = {t.Manv}, thoigiantao = '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', " +
                        $"tongtien = {t.Tongtien}, trangthai = {t.Trangthai}, makh = {t.Makh} " +
                        $"WHERE maphieuxuat = {t.Maphieu}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Delete(int t)
        {
            int result = 0;
            string sql = $"UPDATE phieuxuat SET trangthai = 0 WHERE maphieuxuat = {t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<PhieuXuatDTO> SelectAll()
        {
            BindingList<PhieuXuatDTO> result = new BindingList<PhieuXuatDTO>();
            try
            {
                string sql = "SELECT * FROM phieuxuat";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhieuXuatDTO phieuXuat = new PhieuXuatDTO
                        {
                            Maphieu = reader.GetInt32("maphieuxuat"),
                            Manv = reader.GetInt32("manv"),
                            Thoigiantao = reader.GetDateTime("thoigiantao"),
                            Tongtien = reader.GetInt32("tongtien"),
                            Trangthai = reader.GetInt32("trangthai"),
                            Makh = reader.GetInt32("makh")
                        };
                        result.Add(phieuXuat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public PhieuXuatDTO SelectById(int t)
        {
            PhieuXuatDTO result = new PhieuXuatDTO();
            try
            {
                string sql = $"SELECT * FROM phieuxuat WHERE maphieuxuat = {t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Maphieu = reader.GetInt32("maphieuxuat");
                        result.Manv = reader.GetInt32("manv");
                        result.Thoigiantao = reader.GetDateTime("thoigiantao");
                        result.Tongtien = reader.GetInt32("tongtien");
                        result.Trangthai = reader.GetInt32("trangthai");
                        result.Makh = reader.GetInt32("makh");
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
                string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'quanlikhoquanaom' " +
                             "AND TABLE_NAME = 'phieuxuat'";

                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                {
                    object value = cmd.ExecuteScalar();
                    if (value != null && value != DBNull.Value)
                    {
                        result = Convert.ToInt32(value);
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