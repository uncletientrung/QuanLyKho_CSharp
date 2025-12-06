-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 06, 2025 lúc 12:16 PM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlikhoquanaom`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chatlieu`
--

CREATE TABLE `chatlieu` (
  `machatlieu` int(11) NOT NULL,
  `tenchatlieu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `chatlieu`
--

INSERT INTO `chatlieu` (`machatlieu`, `tenchatlieu`) VALUES
(1, 'Cotton'),
(2, 'Polyester'),
(3, 'Len'),
(4, 'Jean'),
(5, 'Lụa'),
(6, 'Vải bố'),
(7, 'Nỉ'),
(8, 'Vải lanh'),
(9, 'Denim'),
(10, 'Nhung'),
(11, 'Vải thun Spandex'),
(12, 'Vải kaki');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctkiemke`
--

CREATE TABLE `ctkiemke` (
  `maphieukiemke` int(11) NOT NULL,
  `masp` int(11) DEFAULT NULL,
  `tonchinhanh` int(50) NOT NULL DEFAULT 0,
  `tonthucthe` int(50) NOT NULL DEFAULT 0,
  `ghichu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieunhap`
--

CREATE TABLE `ctphieunhap` (
  `maphieunhap` int(11) NOT NULL,
  `masp` int(11) DEFAULT NULL,
  `soluong` int(11) NOT NULL DEFAULT 0,
  `dongia` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieunhap`
--

INSERT INTO `ctphieunhap` (`maphieunhap`, `masp`, `soluong`, `dongia`) VALUES
(35, 1, 1000, 80000),
(36, 2, 50, 60000),
(36, 3, 10, 67000),
(37, 2, 20, 60000),
(37, 3, 20, 67000),
(38, 3, 1, 67000),
(38, 2, 1, 60000),
(39, 1, 1, 80000),
(40, 6, 1, 123);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieuxuat`
--

CREATE TABLE `ctphieuxuat` (
  `maphieuxuat` int(11) NOT NULL,
  `masp` int(11) DEFAULT NULL,
  `soluong` int(11) NOT NULL DEFAULT 0,
  `dongia` int(11) NOT NULL DEFAULT 0,
  `trangThaiHoanHang` tinyint(4) NOT NULL DEFAULT 1 COMMENT '1 là đang hoạt động, 2 là đã hoàn hàng, 0 là hủy'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieuxuat`
--

INSERT INTO `ctphieuxuat` (`maphieuxuat`, `masp`, `soluong`, `dongia`, `trangThaiHoanHang`) VALUES
(199, 2, 1, 60000, 1),
(199, 1, 1, 80000, 1),
(200, 3, 100, 67000, 1),
(201, 1, 1, 80000, 1),
(201, 3, 57, 67000, 1),
(202, 3, 1, 67000, 1),
(203, 3, 1, 67000, 1),
(204, 3, 1, 67000, 2),
(205, 2, 1, 60000, 1),
(205, 3, 1, 67000, 1),
(206, 2, 1, 60000, 1),
(206, 3, 1, 67000, 1),
(207, 3, 1, 67000, 1),
(208, 1, 1, 80000, 1),
(209, 2, 7, 60000, 1),
(209, 3, 1, 67000, 1),
(210, 5, 1, 1, 1),
(211, 2, 1, 60000, 2),
(211, 1, 1, 80000, 2),
(211, 3, 1, 67000, 2),
(212, 1, 1, 80000, 2),
(212, 2, 1, 60000, 2),
(212, 3, 1, 67000, 2),
(213, 1, 10, 80000, 2),
(214, 1, 1, 80000, 2),
(214, 3, 1, 67000, 2),
(214, 2, 1, 60000, 2),
(215, 6, 1, 123, 2),
(216, 2, 1, 60000, 2),
(217, 1, 1, 80000, 2),
(217, 2, 1, 60000, 2),
(217, 3, 1, 67000, 2),
(218, 1, 1, 80000, 2),
(218, 2, 1, 60000, 2),
(219, 1, 20, 80000, 2),
(219, 2, 1, 60000, 2),
(220, 1, 20, 80000, 2),
(220, 2, 1, 60000, 2);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctquyen`
--

CREATE TABLE `ctquyen` (
  `manhomquyen` int(11) NOT NULL,
  `machucnang` int(11) NOT NULL,
  `hanhdong` varchar(255) NOT NULL,
  `trangthai` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctquyen`
--

INSERT INTO `ctquyen` (`manhomquyen`, `machucnang`, `hanhdong`, `trangthai`) VALUES
(1, 1, 'Sửa', 1),
(1, 1, 'Thêm', 1),
(1, 1, 'Xem chi tiết', 1),
(1, 1, 'Xóa', 1),
(1, 2, 'Sửa', 1),
(1, 2, 'Thêm', 1),
(1, 2, 'Xem chi tiết', 1),
(1, 2, 'Xóa', 1),
(1, 3, 'Sửa', 1),
(1, 3, 'Thêm', 1),
(1, 3, 'Xem chi tiết', 1),
(1, 3, 'Xóa', 1),
(1, 4, 'Sửa', 1),
(1, 4, 'Thêm', 1),
(1, 4, 'Xem chi tiết', 1),
(1, 4, 'Xóa', 1),
(1, 5, 'Sửa', 1),
(1, 5, 'Thêm', 1),
(1, 5, 'Xem chi tiết', 1),
(1, 5, 'Xóa', 1),
(1, 6, 'Sửa', 1),
(1, 6, 'Thêm', 1),
(1, 6, 'Xem chi tiết', 1),
(1, 6, 'Xóa', 1),
(1, 7, 'Sửa', 1),
(1, 7, 'Thêm', 1),
(1, 7, 'Xem chi tiết', 1),
(1, 7, 'Xóa', 1),
(1, 8, 'Xem chi tiết', 1),
(1, 9, 'Sửa', 1),
(1, 9, 'Thêm', 1),
(1, 9, 'Xem chi tiết', 1),
(1, 9, 'Xóa', 1),
(1, 10, 'Sửa', 1),
(1, 10, 'Thêm', 1),
(1, 10, 'Xem chi tiết', 1),
(1, 10, 'Xóa', 1),
(2, 2, 'Sửa', 1),
(2, 2, 'Thêm', 1),
(2, 2, 'Xem chi tiết', 1),
(2, 2, 'Xóa', 1),
(2, 3, 'Xem chi tiết', 1),
(2, 4, 'Sửa', 1),
(2, 4, 'Thêm', 1),
(2, 4, 'Xem chi tiết', 1),
(2, 4, 'Xóa', 1),
(2, 5, 'Sửa', 1),
(2, 5, 'Thêm', 1),
(2, 5, 'Xem chi tiết', 1),
(2, 5, 'Xóa', 1),
(2, 6, 'Sửa', 1),
(2, 6, 'Thêm', 1),
(2, 6, 'Xem chi tiết', 1),
(2, 6, 'Xóa', 1),
(31, 8, 'Xem chi tiết', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `danhmucchucnang`
--

CREATE TABLE `danhmucchucnang` (
  `machucnang` int(11) NOT NULL,
  `tenchucnang` varchar(255) NOT NULL,
  `trangthai` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `danhmucchucnang`
--

INSERT INTO `danhmucchucnang` (`machucnang`, `tenchucnang`, `trangthai`) VALUES
(1, 'nhanvien', 1),
(2, 'khachhang', 1),
(3, 'thongtin', 1),
(4, 'tonkho', 1),
(5, 'nhaphang', 1),
(6, 'xuathang', 1),
(7, 'kiemke', 1),
(8, 'baocao', 1),
(9, 'taikhoan', 1),
(10, 'phanquyen', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khachhang`
--

CREATE TABLE `khachhang` (
  `makh` int(11) NOT NULL,
  `tenkhachhang` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `ngaysinh` date DEFAULT NULL,
  `sdt` varchar(50) DEFAULT NULL,
  `trangthai` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `khachhang`
--

INSERT INTO `khachhang` (`makh`, `tenkhachhang`, `email`, `ngaysinh`, `sdt`, `trangthai`) VALUES
(1, 'An', 'an.nguyen@example.com', '1996-05-14', '0912345678', 1),
(2, 'Bình', 'binh.tran@example.com', '1988-10-22', '0987654321', 1),
(3, 'Cường', 'cuong.le@example.com', '1995-07-30', '0909876543', 1),
(4, 'Dung', 'dung.pham@example.com', '2000-03-15', '0965123456', 1),
(5, 'Đức', 'duc.dang@example.com', '1985-08-05', '0978456123', 1),
(6, 'Hương	', 'huong.ho@example.com', '1993-11-25', '0911122233', 1),
(7, 'Hòa', 'hoa.bui@example.com', '1998-06-18', '0922233344', 1),
(8, 'Khang', 'khang.vo@example.com', '1987-09-12', '0933344455', 1),
(9, 'Linh', 'linh.nguyen@example.com', '1996-04-07', '0944455566', 1),
(10, 'Minh', 'minh.trinh@example.com', '2002-02-28', '0955566677', 1),
(11, 'Nam', 'nam.duong@example.com', '1990-12-01', '0966677788', 1),
(12, 'Quân', 'quan.phan@example.com	', '1989-07-19', '0977788899', 1),
(13, 'Trang', 'trang.luong@example.com', '1997-01-23', '0988899000', 1),
(14, 'Thuận', 'thihachcf@gmail.com', '2005-01-01', '0352447642', 1),
(15, 'Trung', 'thihahcf@gmail.com', '2022-11-11', '0352447642', 1),
(16, 'Văn Luyện', 'thi@gmail.com', '2005-12-12', '0987654321', 1),
(17, 'testPX', 'thihachcf@gmail.com', '2025-01-06', '0352447642', 1),
(18, 'test', 'thihachcf@gmail.com', '2025-12-02', '0352447642', 1),
(19, 'Bro dductws', 'thihachcf@gmail.com', '2025-12-01', '0352447642', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khuvuckho`
--

CREATE TABLE `khuvuckho` (
  `makhuvuc` int(11) NOT NULL,
  `tenkhuvuc` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `diachi` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `sdt` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `khuvuckho`
--

INSERT INTO `khuvuckho` (`makhuvuc`, `tenkhuvuc`, `diachi`, `sdt`, `email`) VALUES
(1, 'Kho Trung Tâm', '123 Đường Lê Lợi, Quận 1, TP.HCM', '02812345678', 'trungtam@kho.com'),
(2, 'Kho Miền Bắc', '456 Đường Hoàng Hoa Thám, Hà Nội', '02487654321', 'mienbac@kho.com'),
(3, 'Kho Miền Nam', '789 Đường Trần Hưng Đạo, Cần Thơ', '02921234567', 'miennam@kho.com'),
(4, 'Kho Hàng Hóa Nhỏ', '12 Đường Nguyễn Huệ, Đà Nẵng', '02363891234', 'khohoahoc@kho.com'),
(5, 'Kho Dự Phòng', '99 Đường Phạm Văn Đồng, Bình Dương', '02743876543', 'duphong@kho.com');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `loai`
--

CREATE TABLE `loai` (
  `maloai` int(11) NOT NULL,
  `tenloai` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `loai`
--

INSERT INTO `loai` (`maloai`, `tenloai`) VALUES
(1, 'Áo thun'),
(2, 'Áo sơ mi'),
(3, 'Áo khoác'),
(4, 'Áo len'),
(5, 'Quần jeans'),
(6, 'Quần tây'),
(7, 'Chân váy'),
(8, 'Váy liền'),
(9, 'Đầm maxi'),
(10, 'Áo hoodie'),
(11, 'Áo khoác gió'),
(12, 'Quần short'),
(13, 'Áo ba lỗ'),
(14, 'Áo polo');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhacungcap`
--

CREATE TABLE `nhacungcap` (
  `mancc` int(11) NOT NULL,
  `tenncc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `diachincc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `sdt` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `trangthai` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhacungcap`
--

INSERT INTO `nhacungcap` (`mancc`, `tenncc`, `diachincc`, `sdt`, `email`, `trangthai`) VALUES
(9, 'Fashion Global Ltd', '10 Downing Street, London, UK', '+44 20 7946 0958', 'contact@fashionglobal.com', 1),
(10, 'Textile World Inc', '500 Fifth Avenue, New York, USA', '+1 212 555 0199', 'sales@textileworld.com', 1),
(11, 'Euro Fabrics GmbH', 'Kaiserstraße 45, Berlin, Germany', '+49 30 12345678', 'info@eurofabrics.de', 1),
(12, 'Silk Route Co', '1 Rue de la Paix, Paris, France', '+33 1 23456789', 'support@silkroute.fr', 1),
(13, 'Shenzhen Textile Co', 'No. 88, Futian Rd, Shenzhen, China', '+86 755 1234 5678', 'contact@sztextile.cn', 1),
(14, 'Beijing Fashion Importers', 'No. 10, Wangfujing Street, Beijing, China', '+86 10 8765 4321', 'sales@bjfashion.cn', 1),
(15, 'testNCCPX', '99 ADV KTX', '0352447642', 'thihachcf@gmail.com', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhanvien`
--

CREATE TABLE `nhanvien` (
  `manv` int(11) NOT NULL,
  `tennv` varchar(255) NOT NULL,
  `gioitinh` tinyint(4) NOT NULL,
  `sdt` varchar(50) NOT NULL,
  `ngaysinh` date NOT NULL,
  `trangthai` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `nhanvien`
--

INSERT INTO `nhanvien` (`manv`, `tennv`, `gioitinh`, `sdt`, `ngaysinh`, `trangthai`) VALUES
(1, 'Nguyễn Tiến Trungg', 1, '0352447642', '2000-03-15', 1),
(2, 'Nguyễn Minh Thuận', 1, '0909669035', '2005-04-06', 1),
(3, 'nguyen minh thuan', 1, '0909666666', '2025-08-31', 1),
(4, 'Nguyễn Minh Thuận', 1, '0909669035', '2005-04-06', 1),
(5, 'aaa', 1, '0352447642', '2025-10-06', 1),
(6, 'Trung testy', 1, '0352447642', '2025-11-04', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhomquyen`
--

CREATE TABLE `nhomquyen` (
  `manhomquyen` int(11) NOT NULL,
  `tennhomquyen` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `trangthai` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhomquyen`
--

INSERT INTO `nhomquyen` (`manhomquyen`, `tennhomquyen`, `trangthai`) VALUES
(1, 'Quản lý', 1),
(2, 'Nhân viên', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieukiemke`
--

CREATE TABLE `phieukiemke` (
  `maphieukiemke` int(11) NOT NULL,
  `thoigiantao` datetime NOT NULL DEFAULT current_timestamp(),
  `thoigiancanbang` datetime NOT NULL DEFAULT current_timestamp(),
  `trangthai` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ghichu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `makhuvuc` int(11) DEFAULT NULL,
  `manhanvientao` int(11) DEFAULT NULL,
  `manhanvienkiem` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieunhap`
--

CREATE TABLE `phieunhap` (
  `maphieunhap` int(11) NOT NULL,
  `manv` int(11) DEFAULT NULL,
  `mancc` int(11) DEFAULT NULL,
  `thoigiantao` datetime DEFAULT current_timestamp(),
  `tongtien` bigint(20) NOT NULL DEFAULT 0,
  `trangthai` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieunhap`
--

INSERT INTO `phieunhap` (`maphieunhap`, `manv`, `mancc`, `thoigiantao`, `tongtien`, `trangthai`) VALUES
(35, 6, 14, '2025-10-02 16:53:55', 80000000, 1),
(36, 6, 11, '2025-10-02 16:57:59', 3670000, 1),
(37, 6, 13, '2025-10-02 16:57:59', 2540000, 1),
(38, 6, 14, '2025-12-05 15:47:19', 127000, 1),
(39, 6, 15, '2025-12-05 15:47:54', 80000, 1),
(40, 6, 15, '2025-12-05 16:20:27', 123, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieuxuat`
--

CREATE TABLE `phieuxuat` (
  `maphieuxuat` int(11) NOT NULL,
  `manv` int(11) DEFAULT NULL,
  `makh` int(11) DEFAULT NULL,
  `thoigiantao` datetime NOT NULL DEFAULT current_timestamp(),
  `tongtien` bigint(20) DEFAULT 0,
  `trangthai` tinyint(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieuxuat`
--

INSERT INTO `phieuxuat` (`maphieuxuat`, `manv`, `makh`, `thoigiantao`, `tongtien`, `trangthai`) VALUES
(199, 6, 1, '2025-10-02 16:35:46', 140000, 1),
(200, 6, 3, '2025-10-02 16:38:23', 6700000, 1),
(201, 6, 2, '2025-10-02 16:39:57', 3899000, 1),
(202, 6, 13, '2025-12-04 22:47:25', 67000, 1),
(203, 6, 13, '2025-12-04 22:48:03', 67000, 1),
(204, 6, 13, '2025-12-04 22:48:16', 67000, 3),
(205, 6, 13, '2025-12-04 23:10:04', 127000, 0),
(206, 6, 13, '2025-12-04 23:13:59', 127000, 0),
(207, 6, 19, '2025-12-04 23:15:11', 67000, 0),
(208, 6, 13, '2025-12-03 00:00:00', 80000, 0),
(209, 6, 7, '2025-12-04 23:30:25', 487000, 0),
(210, 6, 13, '2025-12-05 14:19:41', 1, 0),
(211, 6, 13, '2025-12-06 16:36:23', 207000, 3),
(212, 6, 11, '2025-12-06 16:53:58', 207000, 3),
(213, 6, 13, '2025-12-06 17:01:41', 800000, 3),
(214, 6, 13, '2025-12-06 17:12:39', 207000, 3),
(215, 6, 13, '2025-12-06 17:21:31', 123, 3),
(216, 6, 11, '2025-12-06 17:29:28', 60000, 3),
(217, 6, 13, '2025-12-06 17:46:48', 207000, 3),
(218, 6, 13, '2025-12-06 17:50:53', 140000, 3),
(219, 6, 14, '2025-12-06 17:53:13', 1660000, 3),
(220, 6, 11, '2025-12-06 17:53:48', 1660000, 3);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sanpham`
--

CREATE TABLE `sanpham` (
  `masp` int(11) NOT NULL,
  `tensp` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `hinhanh` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `soluong` int(11) DEFAULT 0,
  `dongia` int(50) DEFAULT 0,
  `machatlieu` int(11) DEFAULT NULL,
  `maloai` int(11) DEFAULT NULL,
  `makhuvuc` int(11) DEFAULT NULL,
  `masize` int(11) DEFAULT NULL,
  `TrangThai` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO `sanpham` (`masp`, `tensp`, `hinhanh`, `soluong`, `dongia`, `machatlieu`, `maloai`, `makhuvuc`, `masize`, `TrangThai`) VALUES
(1, 'Áo Lovepik', 'images/stocks/ao1.png', 1001, 80000, 1, 1, 1, 3, 1),
(2, 'áo thun trắng', 'images/stocks/ao2.png', 68, 60000, 1, 2, 1, 5, 1),
(3, 'áo da bò', 'images/stocks/ao3.png', 31, 67000, 2, 1, 1, 5, 1),
(5, 'ssss', 'images/stocks/shirt_plusIcon.png', 0, 1, 3, 3, 1, 5, 1),
(6, 'Áo lót', 'images/stocks/bus_7828520_639005483916817061.png', 125, 123, 2, 1, 3, 1, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `size`
--

CREATE TABLE `size` (
  `masize` int(11) NOT NULL,
  `tensize` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ghichu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `size`
--

INSERT INTO `size` (`masize`, `tensize`, `ghichu`) VALUES
(1, 'XS', '40–45kg, 150–155cm'),
(2, 'S', '45–50kg, 155–160cm'),
(3, 'M', '50–60kg, 160–165cm'),
(4, 'L', '60–70kg, 165–170cm'),
(5, 'XL', '70–80kg, 170–175cm'),
(6, 'XXL', '80–90kg, 175–180cm'),
(7, 'XXXL', '90–100kg, 180–185cm');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `taikhoan`
--

CREATE TABLE `taikhoan` (
  `manv` int(11) NOT NULL,
  `tendangnhap` varchar(255) NOT NULL,
  `matkhau` varchar(255) NOT NULL,
  `manhomquyen` int(11) NOT NULL,
  `trangthai` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `taikhoan`
--

INSERT INTO `taikhoan` (`manv`, `tendangnhap`, `matkhau`, `manhomquyen`, `trangthai`) VALUES
(1, 'trung123', '12345', 2, 1),
(2, 'test', '123', 2, 1),
(6, 'admin', '12345', 1, 1);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `chatlieu`
--
ALTER TABLE `chatlieu`
  ADD PRIMARY KEY (`machatlieu`);

--
-- Chỉ mục cho bảng `ctkiemke`
--
ALTER TABLE `ctkiemke`
  ADD KEY `FK_ctkiemke_phieukiemke` (`maphieukiemke`),
  ADD KEY `FK_ctkiemke_sanpham` (`masp`);

--
-- Chỉ mục cho bảng `ctphieunhap`
--
ALTER TABLE `ctphieunhap`
  ADD KEY `FK_ctphieunhap_phieunhap` (`maphieunhap`),
  ADD KEY `FK_ctphieunhap_sanpham` (`masp`);

--
-- Chỉ mục cho bảng `ctphieuxuat`
--
ALTER TABLE `ctphieuxuat`
  ADD KEY `FK_ctphieuxuat_sanpham` (`masp`),
  ADD KEY `FK_ctphieuxuat_phieuxuat` (`maphieuxuat`);

--
-- Chỉ mục cho bảng `ctquyen`
--
ALTER TABLE `ctquyen`
  ADD PRIMARY KEY (`manhomquyen`,`machucnang`,`hanhdong`);

--
-- Chỉ mục cho bảng `danhmucchucnang`
--
ALTER TABLE `danhmucchucnang`
  ADD PRIMARY KEY (`machucnang`);

--
-- Chỉ mục cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`makh`);

--
-- Chỉ mục cho bảng `khuvuckho`
--
ALTER TABLE `khuvuckho`
  ADD PRIMARY KEY (`makhuvuc`);

--
-- Chỉ mục cho bảng `loai`
--
ALTER TABLE `loai`
  ADD PRIMARY KEY (`maloai`);

--
-- Chỉ mục cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  ADD PRIMARY KEY (`mancc`);

--
-- Chỉ mục cho bảng `nhanvien`
--
ALTER TABLE `nhanvien`
  ADD PRIMARY KEY (`manv`);

--
-- Chỉ mục cho bảng `nhomquyen`
--
ALTER TABLE `nhomquyen`
  ADD PRIMARY KEY (`manhomquyen`);

--
-- Chỉ mục cho bảng `phieukiemke`
--
ALTER TABLE `phieukiemke`
  ADD PRIMARY KEY (`maphieukiemke`),
  ADD KEY `FK_phieukiemke_khuvuc` (`makhuvuc`),
  ADD KEY `FK_phieukiemke_nhanvien` (`manhanvienkiem`),
  ADD KEY `FK_phieukiemke_taikhoan` (`manhanvientao`);

--
-- Chỉ mục cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  ADD PRIMARY KEY (`maphieunhap`),
  ADD KEY `FK_phieunhap_nhacungcap` (`mancc`),
  ADD KEY `FK_phieunhap_taikhoan` (`manv`);

--
-- Chỉ mục cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  ADD PRIMARY KEY (`maphieuxuat`),
  ADD KEY `FK_phieuxuat_khachhang` (`makh`),
  ADD KEY `FK_phieuxuat_taikhoan` (`manv`);

--
-- Chỉ mục cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`masp`),
  ADD KEY `FK_sanpham_chatlieu` (`machatlieu`),
  ADD KEY `FK_sanpham_loai` (`maloai`),
  ADD KEY `FK_sanpham_size` (`masize`),
  ADD KEY `FK_sanpham_khucvuc` (`makhuvuc`);

--
-- Chỉ mục cho bảng `size`
--
ALTER TABLE `size`
  ADD PRIMARY KEY (`masize`);

--
-- Chỉ mục cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`manv`),
  ADD KEY `FK_taikhoan_nhomquyen` (`manhomquyen`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `chatlieu`
--
ALTER TABLE `chatlieu`
  MODIFY `machatlieu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT cho bảng `danhmucchucnang`
--
ALTER TABLE `danhmucchucnang`
  MODIFY `machucnang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT cho bảng `khachhang`
--
ALTER TABLE `khachhang`
  MODIFY `makh` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT cho bảng `khuvuckho`
--
ALTER TABLE `khuvuckho`
  MODIFY `makhuvuc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `loai`
--
ALTER TABLE `loai`
  MODIFY `maloai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  MODIFY `mancc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT cho bảng `nhanvien`
--
ALTER TABLE `nhanvien`
  MODIFY `manv` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `nhomquyen`
--
ALTER TABLE `nhomquyen`
  MODIFY `manhomquyen` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `phieukiemke`
--
ALTER TABLE `phieukiemke`
  MODIFY `maphieukiemke` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  MODIFY `maphieunhap` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  MODIFY `maphieuxuat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=221;

--
-- AUTO_INCREMENT cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `masp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `size`
--
ALTER TABLE `size`
  MODIFY `masize` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `ctkiemke`
--
ALTER TABLE `ctkiemke`
  ADD CONSTRAINT `FK_ctkiemke_phieukiemke` FOREIGN KEY (`maphieukiemke`) REFERENCES `phieukiemke` (`maphieukiemke`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ctkiemke_sanpham` FOREIGN KEY (`masp`) REFERENCES `sanpham` (`masp`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `ctphieunhap`
--
ALTER TABLE `ctphieunhap`
  ADD CONSTRAINT `FK_ctphieunhap_phieunhap` FOREIGN KEY (`maphieunhap`) REFERENCES `phieunhap` (`maphieunhap`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ctphieunhap_sanpham` FOREIGN KEY (`masp`) REFERENCES `sanpham` (`masp`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `ctphieuxuat`
--
ALTER TABLE `ctphieuxuat`
  ADD CONSTRAINT `FK_ctphieuxuat_phieuxuat` FOREIGN KEY (`maphieuxuat`) REFERENCES `phieuxuat` (`maphieuxuat`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ctphieuxuat_sanpham` FOREIGN KEY (`masp`) REFERENCES `sanpham` (`masp`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `phieukiemke`
--
ALTER TABLE `phieukiemke`
  ADD CONSTRAINT `FK_phieukiemke_khuvuc` FOREIGN KEY (`makhuvuc`) REFERENCES `khuvuckho` (`makhuvuc`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_phieukiemke_nhanvien` FOREIGN KEY (`manhanvienkiem`) REFERENCES `nhanvien` (`manv`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_phieukiemke_taikhoan` FOREIGN KEY (`manhanvientao`) REFERENCES `taikhoan` (`manv`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  ADD CONSTRAINT `FK_phieunhap_nhacungcap` FOREIGN KEY (`mancc`) REFERENCES `nhacungcap` (`mancc`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_phieunhap_taikhoan` FOREIGN KEY (`manv`) REFERENCES `taikhoan` (`manv`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  ADD CONSTRAINT `FK_phieuxuat_khachhang` FOREIGN KEY (`makh`) REFERENCES `khachhang` (`makh`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_phieuxuat_taikhoan` FOREIGN KEY (`manv`) REFERENCES `taikhoan` (`manv`) ON DELETE SET NULL;

--
-- Các ràng buộc cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD CONSTRAINT `FK_sanpham_chatlieu` FOREIGN KEY (`machatlieu`) REFERENCES `chatlieu` (`machatlieu`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_sanpham_khucvuc` FOREIGN KEY (`makhuvuc`) REFERENCES `khuvuckho` (`makhuvuc`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_sanpham_loai` FOREIGN KEY (`maloai`) REFERENCES `loai` (`maloai`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_sanpham_size` FOREIGN KEY (`masize`) REFERENCES `size` (`masize`) ON DELETE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
