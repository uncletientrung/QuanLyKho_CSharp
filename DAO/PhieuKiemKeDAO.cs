using MySql.Data.MySqlClient;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.DAO
{
    public class PhieuKiemKeDAO
    {
        public static PhieuKiemKeDAO getInstance()
        {
            return new PhieuKiemKeDAO();
        }

        public int Insert(PhieuKiemKeDTO t)
        {
            int result = 0;
            string sql = $"INSERT INTO phieukiemke(maphieukiemke, thoigiantao, trangthai, ghichu, makhuvuc, manhanvientao, manhanvienkiem) " +
                         $"VALUES ({t.Maphieukiemke}, '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', '{t.Trangthai}', '{t.Ghichu}', {t.Makhuvuc}, {t.Manhanvientao}, {t.Manhanvienkiem})";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(PhieuKiemKeDTO t)
        {
            int result = 0;
            string sql = $"UPDATE phieukiemke SET " +
                         $"thoigiantao = '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', " +
                         $"trangthai = '{t.Trangthai}', " +
                         $"ghichu = '{t.Ghichu}', " +
                         $"makhuvuc = {t.Makhuvuc}, " +
                         $"manhanvientao = {t.Manhanvientao}, " +
                         $"manhanvienkiem = {t.Manhanvienkiem} " +
                         $"WHERE maphieukiemke = {t.Maphieukiemke}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            string sql = $"DELETE FROM phieukiemke WHERE maphieukiemke = {id}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<PhieuKiemKeDTO> SelectAll()
        {
            BindingList<PhieuKiemKeDTO> result = new BindingList<PhieuKiemKeDTO>();
            try
            {
                string sql = "SELECT * FROM phieukiemke";
                DataTable dt = ConnectionHelper.getDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    PhieuKiemKeDTO item = new PhieuKiemKeDTO
                    {
                        Maphieukiemke = Convert.ToInt32(row["maphieukiemke"]),
                        Thoigiantao = Convert.ToDateTime(row["thoigiantao"]),
                        Trangthai = row["trangthai"].ToString(),
                        Ghichu = row["ghichu"].ToString(),
                        Makhuvuc = Convert.ToInt32(row["makhuvuc"]),
                        Manhanvientao = Convert.ToInt32(row["manhanvientao"]),
                        Manhanvienkiem = Convert.ToInt32(row["manhanvienkiem"])
                    };
                    result.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public PhieuKiemKeDTO SelectById(int id)
        {
            PhieuKiemKeDTO result = null;
            try
            {
                string sql = $"SELECT * FROM phieukiemke WHERE maphieukiemke = {id}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new PhieuKiemKeDTO
                        {
                            Maphieukiemke = reader.GetInt32("maphieukiemke"),
                            Thoigiantao = reader.GetDateTime("thoigiantao"),
                            Trangthai = reader.GetString("trangthai"),
                            Ghichu = reader.GetString("ghichu"),
                            Makhuvuc = reader.GetInt32("makhuvuc"),
                            Manhanvientao = reader.GetInt32("manhanvientao"),
                            Manhanvienkiem = reader.GetInt32("manhanvienkiem")
                        };
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

        public DataTable SelectAllWithColumnOrder()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT " +
                            "maphieukiemke AS 'Mã phiếu kiểm kê', " +
                            "thoigiantao AS 'Thời gian tạo', " +
                            "trangthai AS 'Trạng thái', " +
                            "ghichu AS 'Ghi chú', " +
                            "makhuvuc AS 'Mã khu vực', " +
                            "manhanvientao AS 'Mã nhân viên tạo', " +
                            "manhanvienkiem AS 'Mã nhân viên kiểm' " +
                            "FROM phieukiemke " +
                            "ORDER BY maphieukiemke DESC";

                dt = ConnectionHelper.getDataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}