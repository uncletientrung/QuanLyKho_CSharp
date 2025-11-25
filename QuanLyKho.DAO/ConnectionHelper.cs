using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace QuanLyKho.DAO
{
    public class ConnectionHelper
    {
        private static string connStr = "server=localhost;" +
                                "user=root;" +
                                "database=quanlikhoquanaom;" +
                                "password=;";
        public static MySqlConnection conn;

        public static void getConnection() // Lấy kết nối 
        {
            if(conn == null) conn = new MySqlConnection(connStr);
            if(conn.State == ConnectionState.Closed) conn.Open();
        }
        public static void closeConnection() // Đóng kết nối
        {
            if (conn != null && conn.State == ConnectionState.Open) conn.Close();
        }

        #region Trả về dataTable
        public static DataTable getDataTable(string query) // thực hiện lệnh Select
        {
            DataTable result = new DataTable();
            try
            {
                getConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Dùng using để giải phóng tài nguyên đỡ lag
                using (MySqlDataReader reader= cmd.ExecuteReader())
                {
                    result.Load(reader); // Load vào result sau khi đọc xong
                }
            }catch (Exception ex)
            {
                throw new Exception($"Lỗi Select: {ex.Message}");
            }
            finally
            {
                closeConnection();
            }
            return result;
        }
        #endregion

        public static int getExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                getConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    result = cmd.ExecuteNonQuery(); // Lấy số kết quả thực thi thành công   
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thực thi: {ex.Message}");
            }
            finally { closeConnection(); }
            return result ;
        }
        
    }
}
