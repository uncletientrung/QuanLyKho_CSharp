using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho.DTO;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class PhieuNhapDAO : DAOInterface<PhieuNhapDTO>
    {
        public static PhieuNhapDAO getInstance()
        {
            return new PhieuNhapDAO();
        }

        public int Insert(PhieuNhapDTO t)
        {
            int result = 0;
            string sql = $"INSERT INTO phieunhap(manv, thoigiantao, tongtien, trangthai, mancc) " +
                        $"values ({t.Manv}, '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', {t.Tongtien}, {t.Trangthai}, {t.Mancc})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(PhieuNhapDTO t)
        {
            int result = 0;
            string sql = $"UPDATE phieunhap SET manv = {t.Manv}, thoigiantao = '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', " +
                        $"tongtien = {t.Tongtien}, trangthai = {t.Trangthai}, mancc = {t.Mancc} " +
                        $"WHERE maphieunhap = {t.Maphieu}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Delete(int t)
        {
            int result = 0;
            string sql = $"UPDATE phieunhap SET trangthai = 0 WHERE maphieunhap = {t}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<PhieuNhapDTO> SelectAll()
{
    BindingList<PhieuNhapDTO> result = new BindingList<PhieuNhapDTO>();
    try
    {
        string sql = "SELECT * FROM phieunhap WHERE trangthai = 1";
        
        // Sử dụng ConnectionHelper.getDataTable thay vì tự mở kết nối
        DataTable dt = ConnectionHelper.getDataTable(sql);
        
        foreach (DataRow row in dt.Rows)
        {
            PhieuNhapDTO phieuNhap = new PhieuNhapDTO
            {
                Maphieu = Convert.ToInt32(row["maphieunhap"]),
                Manv = Convert.ToInt32(row["manv"]),
                Thoigiantao = Convert.ToDateTime(row["thoigiantao"]),
                Tongtien = Convert.ToInt32(row["tongtien"]),
                Trangthai = Convert.ToInt32(row["trangthai"]),
                Mancc = Convert.ToInt32(row["mancc"])
            };
            result.Add(phieuNhap);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    return result;
}

        public PhieuNhapDTO SelectById(int t)
        {
            PhieuNhapDTO result = new PhieuNhapDTO();
            try
            {
                string sql = $"SELECT * FROM phieunhap WHERE maphieunhap = {t}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.Maphieu = reader.GetInt32("maphieunhap");
                        result.Manv = reader.GetInt32("manv");
                        result.Thoigiantao = reader.GetDateTime("thoigiantao");
                        result.Tongtien = reader.GetInt32("tongtien");
                        result.Trangthai = reader.GetInt32("trangthai");
                        result.Mancc = reader.GetInt32("mancc");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ConnectionHelper.closeConnection();
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
                             "AND TABLE_NAME = 'phieunhap'";

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
            finally
            {
                ConnectionHelper.closeConnection();
            }
            return result;
        }
    }
}