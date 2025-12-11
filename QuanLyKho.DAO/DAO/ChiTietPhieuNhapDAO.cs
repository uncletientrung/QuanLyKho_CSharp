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
    public class ChiTietPhieuNhapDAO : ChiTietInterface<ChiTietPhieuNhapDTO>
    {
        public static ChiTietPhieuNhapDAO getInstance()
        {
            return new ChiTietPhieuNhapDAO();
        }

        // Triển khai phương thức từ ChiTietInterface
        public int Insert(BindingList<ChiTietPhieuNhapDTO> list)
        {
            int totalAffected = 0;
            try
            {
                foreach (ChiTietPhieuNhapDTO ctpn in list)
                {
                    string sql = $"INSERT INTO ctphieunhap(maphieunhap, masp, soluong, dongia,tensp) " +
                                $"VALUES ({ctpn.Maphieunhap}, {ctpn.Masp}, {ctpn.Soluong}, {ctpn.Dongia} ,'{ctpn.Tensp.Replace("'", "''")}')";
                    int result = ConnectionHelper.getExecuteNonQuery(sql);
                    if (result > 0)
                    {
                        totalAffected++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chèn chi tiết phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return totalAffected;
        }

        public int Delete(int maPhieuNhap)
        {
            int result = 0;
            string sql = $"DELETE FROM ctphieunhap WHERE maphieunhap = {maPhieuNhap}";
            result = ConnectionHelper.getExecuteNonQuery(sql);
            return result;
        }

        public int Update(BindingList<ChiTietPhieuNhapDTO> list, int maPhieuNhap)
        {
            int totalAffected = 0;

            // Xóa tất cả chi tiết cũ
            Delete(maPhieuNhap);

            // Thêm lại chi tiết mới
            totalAffected = Insert(list);

            return totalAffected;
        }

        public BindingList<ChiTietPhieuNhapDTO> SelectAll(int maPhieuNhap)
        {
            BindingList<ChiTietPhieuNhapDTO> result = new BindingList<ChiTietPhieuNhapDTO>();
            try
            {
                string sql = $"SELECT * FROM ctphieunhap WHERE maphieunhap = {maPhieuNhap}";
                DataTable dt = ConnectionHelper.getDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO
                    {
                        Maphieunhap = Convert.ToInt32(row["maphieunhap"]),
                        Masp = Convert.ToInt32(row["masp"]),
                        Soluong = Convert.ToInt32(row["soluong"]),
                        Dongia = Convert.ToInt32(row["dongia"]),
                        Tensp = Convert.ToString(row["tensp"])
                    };
                    result.Add(ctpn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc chi tiết phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        // Các phương thức bổ sung để hỗ trợ
        public int InsertSingle(ChiTietPhieuNhapDTO ctpn)
        {
            string sql = $"INSERT INTO ctphieunhap(maphieunhap, masp, soluong, dongia) " +
                        $"VALUES ({ctpn.Maphieunhap}, {ctpn.Masp}, {ctpn.Soluong}, {ctpn.Dongia})";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public int UpdateSingle(ChiTietPhieuNhapDTO ctpn)
        {
            string sql = $"UPDATE ctphieunhap SET soluong = {ctpn.Soluong}, dongia = {ctpn.Dongia} " +
                        $"WHERE maphieunhap = {ctpn.Maphieunhap} AND masp = {ctpn.Masp}";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public int DeleteByMaPhieuNhapAndMaSP(int maPhieuNhap, int maSP)
        {
            string sql = $"DELETE FROM ctphieunhap WHERE maphieunhap = {maPhieuNhap} AND masp = {maSP}";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public BindingList<ChiTietPhieuNhapDTO> SelectAll()
        {
            BindingList<ChiTietPhieuNhapDTO> result = new BindingList<ChiTietPhieuNhapDTO>();
            try
            {
                string sql = "SELECT * FROM ctphieunhap";
                DataTable dt = ConnectionHelper.getDataTable(sql);

                foreach (DataRow row in dt.Rows)
                {
                    ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO
                    {
                        Maphieunhap = Convert.ToInt32(row["maphieunhap"]),
                        Masp = Convert.ToInt32(row["masp"]),
                        Soluong = Convert.ToInt32(row["soluong"]),
                        Dongia = Convert.ToInt32(row["dongia"])
                    };
                    result.Add(ctpn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu chi tiết phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}