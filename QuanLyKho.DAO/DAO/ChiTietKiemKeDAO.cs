using MySql.Data.MySqlClient;
using QuanLyKho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class ChiTietKiemKeDAO : ChiTietInterface<ChiTietKiemKeDTO>
    {
        private static ChiTietKiemKeDAO instance;

        public static ChiTietKiemKeDAO getInstance()
        {
            if (instance == null)
                instance = new ChiTietKiemKeDAO();
            return instance;
        }

        private ChiTietKiemKeDAO() { }

        public int Insert(BindingList<ChiTietKiemKeDTO> list)
        {
            int totalAffected = 0;
            try
            {
                foreach (ChiTietKiemKeDTO ct in list)
                {
                    string sql = $@"
                        INSERT INTO ctkiemke(maphieukiemke, masp, tonchinhanh, tonthucte, ghichu) 
                        VALUES ({ct.Maphieukiemke}, {ct.Masp}, {ct.Tonchinhanh}, {ct.Tonthucte}, 
                        '{ct.Ghichu}')";

                    int result = ConnectionHelper.getExecuteNonQuery(sql);
                    if (result > 0)
                        totalAffected++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm chi tiết kiểm kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return totalAffected;
        }

        public int Delete(int maPhieuKiemKe)
        {
            string sql = $"DELETE FROM ctkiemke WHERE maphieukiemke = {maPhieuKiemKe}";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public int Update(BindingList<ChiTietKiemKeDTO> list, int maPhieuKiemKe)
        {
            Delete(maPhieuKiemKe);
            return Insert(list);
        }

        public BindingList<ChiTietKiemKeDTO> SelectAll(int maPhieuKiemKe)
        {
            BindingList<ChiTietKiemKeDTO> result = new BindingList<ChiTietKiemKeDTO>();
            try
            {
                string sql = $"SELECT * FROM ctkiemke WHERE maphieukiemke = {maPhieuKiemKe}";
                DataTable dt = ConnectionHelper.getDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietKiemKeDTO ct = new ChiTietKiemKeDTO
                    {
                        Maphieukiemke = Convert.ToInt32(row["maphieukiemke"]),
                        Masp = Convert.ToInt32(row["masp"]),
                        Tonchinhanh = Convert.ToInt32(row["tonchinhanh"]),
                        Tonthucte = Convert.ToInt32(row["tonthucte"]),
                        Ghichu = row["ghichu"] == DBNull.Value ? "" : row["ghichu"].ToString()
                    };
                    result.Add(ct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc chi tiết kiểm kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

    }
}