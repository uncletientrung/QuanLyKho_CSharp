using MySql.Data.MySqlClient;
using QuanLyKho.DTO;

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class PhieuKiemKeDAO : DAOInterface<PhieuKiemKeDTO>
    {
        private static PhieuKiemKeDAO instance;
        public static PhieuKiemKeDAO getInstance()
        {
            if (instance == null)
                instance = new PhieuKiemKeDAO();
            return instance;
        }

        public int Insert(PhieuKiemKeDTO t)
        {
            int result = 0;
            string sql = $"INSERT INTO phieukiemke(manhanvientao, manhanvienkiem, thoigiantao, makhuvuc, ghichu, trangthai) " +
                         $"VALUES ({t.Manhanvientao}, {t.Manhanvienkiem}, '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', {t.Makhuvuc}, '{t.Ghichu}', '{t.Trangthai}')";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(PhieuKiemKeDTO t)
        {
            int result = 0;
            string sql = $"UPDATE phieukiemke SET manhanvientao = {t.Manhanvientao}, manhanvienkiem = {t.Manhanvienkiem}, " +
                         $"thoigiantao = '{t.Thoigiantao:yyyy-MM-dd HH:mm:ss}', makhuvuc = {t.Makhuvuc}, ghichu = '{t.Ghichu}', trangthai = '{t.Trangthai}' " +
                         $"WHERE maphieukiemke = {t.Maphieukiemke}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Delete(int mapkk)
        {
            int result = 0;
            string sql = $"UPDATE phieukiemke SET trangthai = 'Đã xóa' WHERE maphieukiemke = {mapkk}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public BindingList<PhieuKiemKeDTO> SelectAll()
        {
            BindingList<PhieuKiemKeDTO> result = new BindingList<PhieuKiemKeDTO>();
            try
            {
                string sql = "SELECT * FROM phieukiemke";
                // Mở kết nối
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn)) // conn phải public hoặc tạo getter
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhieuKiemKeDTO nv = new PhieuKiemKeDTO
                        {
                            Maphieukiemke = reader.GetInt32("maphieukiemke"),
                            Thoigiantao = reader.GetDateTime("thoigiantao"),
                            Thoigiancanbang = reader.GetDateTime("thoigiancanbang"),
                            Trangthai = reader.GetString("trangthai"),
                            Ghichu = reader.GetString("ghichu"),
                            Makhuvuc = -1,
                            Manhanvientao = reader.GetInt32("manhanvientao"),
                            Manhanvienkiem = reader.GetInt32("manhanvienkiem")
                        };
                        result.Add(nv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConnectionHelper.closeConnection();
            return result;
        }

        public PhieuKiemKeDTO SelectById(int t)
        {
            //PhieuKiemKeDTO result = new PhieuKiemKeDTO();
            //try
            //{
            //    string sql = $@"
            //    SELECT pk.*, 
            //           k.tenkhuvuc, 
            //           nv1.tennv AS tennhanvienta, 
            //           nv2.tennv AS tennhanvienkiem
            //    FROM phieukiemke pk
            //    LEFT JOIN khuvuckho k ON pk.makhuvuc = k.makhuvuc
            //    LEFT JOIN nhanvien nv1 ON pk.manhanvientao = nv1.manv
            //    LEFT JOIN nhanvien nv2 ON pk.manhanvienkiem = nv2.manv
            //    WHERE pk.maphieukiemke = {t}";
            //    ConnectionHelper.getConnection();
            //    using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
            //    using (MySqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            result.Maphieukiemke = reader.GetInt32("maphieukiemke");
            //            result.Manhanvientao = reader.GetInt32("manhanvientao");
            //            result.Manhanvienkiem = reader.GetInt32("manhanvienkiem");
            //            result.Thoigiantao = reader.GetDateTime("thoigiantao");
            //            result.Makhuvuc = reader.GetInt32("makhuvuc");
            //            result.Ghichu = reader["ghichu"]?.ToString();
            //            result.Trangthai = reader["trangthai"]?.ToString();
            //            if (reader.HasRows)
            //            {
            //                if (reader.GetOrdinal("tenkhuvuc") >= 0) result.TenKho = reader["tenkhuvuc"]?.ToString();
            //                if (reader.GetOrdinal("tennhanvienta") >= 0) result.TenNhanVienTao = reader["tennhanvienta"]?.ToString();
            //                if (reader.GetOrdinal("tennhanvienkiem") >= 0) result.TenNhanVienKiem = reader["tennhanvienkiem"]?.ToString();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    ConnectionHelper.closeConnection();
            //}
            //return result;
            return null;
        }

        public int GetAutoIncrement()
        {
            int result = 0;
            try
            {
                string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                             "WHERE TABLE_SCHEMA = 'quanlikhoquanaom' " +
                             "AND TABLE_NAME = 'phieukiemke'";

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

        // Lấy tất cả chi tiết phiếu kiểm kê theo mã phiếu kiểm kê
       
    }
}