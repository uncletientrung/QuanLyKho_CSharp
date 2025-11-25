using MySql.Data.MySqlClient;
using QuanLyKho.DTO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.DAO
{
    public class ChiTietPhieuXuatDAO : ChiTietInterface<ChiTietPhieuXuatDTO>
    {
        public static ChiTietPhieuXuatDAO getInstance()
        {
            return new ChiTietPhieuXuatDAO();
        }

        public int Insert(BindingList<ChiTietPhieuXuatDTO> list)
        {
            int totalAffected = 0;
            try
            {
                foreach (ChiTietPhieuXuatDTO ctpx in list)
                {
                    string sql = $"INSERT INTO ctphieuxuat(maphieuxuat, masp, soluong, dongia) " +
                                $"VALUES ({ctpx.Maphieuxuat}, {ctpx.Masp}, {ctpx.Soluong}, {ctpx.Dongia})";
                    int result = ConnectionHelper.getExecuteNonQuery(sql);
                    if (result > 0)
                    {
                        totalAffected++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chèn chi tiết phiếu xuất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return totalAffected;
        }

        public int Delete(int maPhieuXuat)
        {
            int result = 0;
            string sql = $"DELETE FROM ctphieuxuat WHERE maphieuxuat = {maPhieuXuat}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(BindingList<ChiTietPhieuXuatDTO> list, int maPhieuXuat)
        {
            int totalAffected = 0;

            // Xóa tất cả chi tiết cũ
            Delete(maPhieuXuat);

            // Thêm lại chi tiết mới
            totalAffected = Insert(list);

            return totalAffected;
        }

        public BindingList<ChiTietPhieuXuatDTO> SelectAll(int maPhieuXuat)
        {
            BindingList<ChiTietPhieuXuatDTO> result = new BindingList<ChiTietPhieuXuatDTO>();
            try
            {
                string sql = $"SELECT * FROM ctphieuxuat WHERE maphieuxuat = {maPhieuXuat}";
                DataTable dt = ConnectionHelper.getDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietPhieuXuatDTO ctpx = new ChiTietPhieuXuatDTO
                    {
                        Maphieuxuat = Convert.ToInt32(row["maphieuxuat"]),
                        Masp = Convert.ToInt32(row["masp"]),
                        Soluong = Convert.ToInt32(row["soluong"]),
                        Dongia = Convert.ToInt32(row["dongia"])
                    };
                    result.Add(ctpx);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc chi tiết phiếu xuất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        // Các phương thức bổ sung để hỗ trợ
        public int InsertSingle(ChiTietPhieuXuatDTO ctpx)
        {
            string sql = $"INSERT INTO ctphieuxuat(maphieuxuat, masp, soluong, dongia) " +
                        $"VALUES ({ctpx.Maphieuxuat}, {ctpx.Masp}, {ctpx.Soluong}, {ctpx.Dongia})";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public int UpdateSingle(ChiTietPhieuXuatDTO ctpx)
        {
            string sql = $"UPDATE ctphieuxuat SET soluong = {ctpx.Soluong}, dongia = {ctpx.Dongia} " +
                        $"WHERE maphieuxuat = {ctpx.Maphieuxuat} AND masp = {ctpx.Masp}";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public int DeleteByMaPhieuXuatAndMaSP(int maPhieuXuat, int maSP)
        {
            string sql = $"DELETE FROM ctphieuxuat WHERE maphieuxuat = {maPhieuXuat} AND masp = {maSP}";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public BindingList<ChiTietPhieuXuatDTO> SelectAll()
        {
            BindingList<ChiTietPhieuXuatDTO> result = new BindingList<ChiTietPhieuXuatDTO>();
            try
            {
                string sql = "SELECT * FROM ctphieuxuat";
                DataTable dt = ConnectionHelper.getDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietPhieuXuatDTO ctpx = new ChiTietPhieuXuatDTO
                    {
                        Maphieuxuat = Convert.ToInt32(row["maphieuxuat"]),
                        Masp = Convert.ToInt32(row["masp"]),
                        Soluong = Convert.ToInt32(row["soluong"]),
                        Dongia = Convert.ToInt32(row["dongia"])
                    };
                    result.Add(ctpx);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu chi tiết phiếu xuất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}