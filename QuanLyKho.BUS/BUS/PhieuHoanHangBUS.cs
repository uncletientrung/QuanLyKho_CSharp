using QuanLyKho.DAO;
using QuanLyKho.DTO;
using System;

namespace QuanLyKho.BUS
{
    public class PhieuHoanHangBUS
    {
        public void CapNhatTrangThaiPhieuXuat(int maPhieuXuat, int soLuongDaHoan = 0, int tongSoLuongXuat = 0)
        {
            try
            {
                int trangThaiMoi = 1; 

                if (soLuongDaHoan > 0)
                {
                    if (soLuongDaHoan >= tongSoLuongXuat)
                    {
                        trangThaiMoi = 3; 
                    }
                    else
                    {
                        trangThaiMoi = 2; 
                    }
                }

                // Cập nhật trạng thái vào database
                var pxDAO = PhieuXuatDAO.getInstance();
                var phieuXuat = pxDAO.SelectById(maPhieuXuat);
                if (phieuXuat != null)
                {
                    phieuXuat.Trangthai = trangThaiMoi;
                    pxDAO.Update(phieuXuat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái phiếu xuất: {ex.Message}");
            }
        }
    }
}