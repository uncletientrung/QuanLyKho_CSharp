﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using QuanLyKho_CSharp.DTO;
using QuanLyKho_CSharp.GUI;
using QuanLyKho_CSharp.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho_CSharp.DAO
{
    public class SanPhamDAO : DAOInterface<SanPhamDTO>


    {
        public static SanPhamDAO getInstance()
        {
            return new SanPhamDAO();
        }

        public int Insert(SanPhamDTO sp)
        {


            string sql = $"INSERT into sanpham(tensp,hinhanh,soluong,dongia,machatlieu,maloai,makhuvuc,masize)"
                + $"VALUES ('{sp.Tensp}','{sp.Hinhanh}','{sp.Soluong}','{sp.Dongia}','{sp.Machatlieu}','{sp.Maloai}','{sp.Makhuvuc}','{sp.Masize}')";
            return ConnectionHelper.getExecuteNonQuery(sql);// tra ve so luong dong anh huong
        }

        public int Update(SanPhamDTO sp)
        {
            string sql = $"UPDATE sanpham SET " +
                         $"tensp='{sp.Tensp}',hinhanh='{sp.Hinhanh}',soluong='{sp.Soluong}',dongia='{sp.Dongia}',machatlieu='{sp.Machatlieu}',maloai='{sp.Maloai}',makhuvuc='{sp.Makhuvuc}',masize='{sp.Masize}'" +
                         $"WHERE masp='{sp.Masp}'";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }
        public int Delete(int masp)
        {
            string sql = $"DELETE from sanpham Where masp={masp}";
            return ConnectionHelper.getExecuteNonQuery(sql);
        }

        public SanPhamDTO SelectById(int masp)
        {
            SanPhamDTO sanPhamResult = new SanPhamDTO();
            try
            {
                string sql = $"select * from sanpham where masp={masp}";
                ConnectionHelper.getConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sanPhamResult.Masp = reader.GetInt32("masp");
                        sanPhamResult.Tensp = reader.GetString("tensp");
                        sanPhamResult.Hinhanh = reader.GetString("hinhanh");
                        sanPhamResult.Soluong = reader.GetInt32("soluong");
                        sanPhamResult.Dongia = reader.GetInt32("dongia");
                        sanPhamResult.Machatlieu = reader.GetInt32("machatlieu");
                        sanPhamResult.Maloai = reader.GetInt32("maloai");
                        sanPhamResult.Makhuvuc = reader.GetInt32("makhuvuc");
                        sanPhamResult.Masize = reader.GetInt32("masize");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sanPhamResult;
        }
        public BindingList<SanPhamDTO> SelectAll()
        {
            BindingList<SanPhamDTO> listResult = new BindingList<SanPhamDTO>();
            try
            {
                string sql = "select * from sanpham";
                ConnectionHelper.getConnection();
                //tao reader de doc du lieu
                using (MySqlCommand cmd = new MySqlCommand(sql, ConnectionHelper.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //doc tung dong, hkoi tao 1 sp de luu gia tri
                        SanPhamDTO sanPham = new SanPhamDTO
                        {
                            Masp = reader.GetInt32("masp"),
                            Tensp = reader.GetString("tensp"),
                            Hinhanh = reader.GetString("hinhanh"),
                            Soluong = reader.GetInt32("soluong"),
                            Dongia = reader.GetInt32("dongia"),
                            Machatlieu = reader.GetInt32("machatlieu"),
                            Maloai = reader.GetInt32("maloai"),
                            Makhuvuc = reader.GetInt32("makhuvuc"),
                            Masize = reader.GetInt32("masize")

                        };
                        //add sp sau khi doc
                        listResult.Add(sanPham);



                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tra ve ds spham
            return listResult;

        }

        public int GetAutoIncrement()
        {
            string sql = "SELECT AUTO_INCREMENT FROM information_schema.TABLES " +
                         "WHERE TABLE_SCHEMA='quanlikhoquanaom' AND TABLE_NAME='sanpham'";
            DataTable dt = ConnectionHelper.getDataTable(sql);
            return (dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0]["AUTO_INCREMENT"]) : 0;
        }




    }
}
