-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 13, 2025 lúc 03:30 AM
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
  `tonthucte` int(50) NOT NULL DEFAULT 0,
  `ghichu` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `tensp` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `ctkiemke`
--

INSERT INTO `ctkiemke` (`maphieukiemke`, `masp`, `tonchinhanh`, `tonthucte`, `ghichu`, `tensp`) VALUES
(39, 13, 878, 1, 'Thiếu sản phâm', 'Áo polo ARGENTBLUE'),
(40, 29, 0, 1, 'Thừa sản phẩm', 'a'),
(41, 22, 200, 200, 'Đủ hàng', ' Quần jeans ADORE'),
(41, 24, 900, 900, 'Đủ hàng', ' Quần GRACEFUL'),
(42, 11, 119, 118, 'Thiếu sản phâm', 'Áo I HAVE LOVELY'),
(43, 16, 350, 350, 'Đủ hàng', 'Áo hoodie IMPRESSION'),
(43, 17, 480, 480, 'Đủ hàng', 'Áo hoodie CARAMEL'),
(43, 18, 256, 250, 'Thiếu sản phâm', 'Áo hoodie FOSSIL'),
(44, 22, 200, 10, 'Thiếu sản phâm', ' Quần jeans ADORE'),
(44, 23, 250, 2, 'Thiếu sản phâm', 'Quần jeans LUSTRE'),
(45, 13, 878, 1, 'Thiếu sản phâm', 'Áo polo ARGENTBLUE');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieunhap`
--

CREATE TABLE `ctphieunhap` (
  `maphieunhap` int(11) NOT NULL,
  `masp` int(11) DEFAULT NULL,
  `soluong` int(11) NOT NULL DEFAULT 0,
  `dongia` int(11) NOT NULL DEFAULT 0,
  `tensp` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieunhap`
--

INSERT INTO `ctphieunhap` (`maphieunhap`, `masp`, `soluong`, `dongia`, `tensp`) VALUES
(79, 13, 1000, 299000, 'Áo polo ARGENTBLUE'),
(79, 14, 200, 399000, 'Áo sơ mi PRD WORK'),
(79, 15, 100, 349000, 'Áo polo LEGECY'),
(80, 16, 100, 529000, 'Áo hoodie IMPRESSION'),
(80, 17, 390, 499000, 'Áo hoodie CARAMEL'),
(80, 18, 200, 429000, 'Áo hoodie FOSSIL'),
(80, 20, 100, 389000, 'Áo RED SUN'),
(81, 19, 100, 399000, 'Áo sweater BABY LABEL '),
(81, 24, 1000, 196000, ' Quần GRACEFUL'),
(81, 21, 2000, 289000, 'Áo GLEEFUL '),
(82, 22, 200, 589000, ' Quần jeans ADORE'),
(82, 23, 130, 569000, 'Quần jeans LUSTRE'),
(83, 25, 230, 79000, 'Quần VIBRANT COTTON'),
(83, 26, 112, 259000, 'HADES BERMUDE WASH'),
(84, 27, 110, 129000, 'HADES ENLISTED HOODIE'),
(84, 28, 100, 899, 'HADES BACKSPIKE PANTS'),
(84, 19, 200, 399000, 'Áo sweater BABY LABEL '),
(85, 18, 100, 429000, 'Áo hoodie FOSSIL'),
(85, 17, 120, 499000, 'Áo hoodie CARAMEL'),
(85, 19, 1000, 399000, 'Áo sweater BABY LABEL '),
(86, 27, 230, 129000, 'HADES ENLISTED HOODIE'),
(86, 16, 300, 529000, 'Áo hoodie IMPRESSION'),
(86, 15, 123, 349000, 'Áo polo LEGECY'),
(87, 26, 230, 259000, 'HADES BERMUDE WASH'),
(87, 20, 120, 389000, 'Áo RED SUN'),
(88, 28, 300, 899, 'HADES BACKSPIKE PANTS'),
(88, 11, 30, 250000, 'Áo I HAVE LOVELY'),
(89, 23, 120, 569000, 'Quần jeans LUSTRE'),
(90, 11, 10, 250000, 'Áo I HAVE LOVELY'),
(90, 13, 10, 299000, 'Áo polo ARGENTBLUE'),
(90, 14, 10, 399000, 'Áo sơ mi PRD WORK'),
(90, 15, 10, 349000, 'Áo polo LEGECY'),
(90, 16, 10, 529000, 'Áo hoodie IMPRESSION'),
(90, 17, 10, 499000, 'Áo hoodie CARAMEL'),
(90, 18, 10, 429000, 'Áo hoodie FOSSIL'),
(90, 19, 10, 399000, 'Áo sweater BABY LABEL '),
(90, 20, 10, 389000, 'Áo RED SUN'),
(90, 21, 10, 289000, 'Áo GLEEFUL '),
(90, 22, 10, 589000, ' Quần jeans ADORE'),
(90, 23, 10, 569000, 'Quần jeans LUSTRE'),
(90, 24, 10, 196000, ' Quần GRACEFUL'),
(91, 14, 100, 399000, 'Áo sơ mi PRD WORK'),
(92, 14, 1, 399000, 'Áo sơ mi PRD WORK'),
(92, 16, 10, 529000, 'Áo hoodie IMPRESSION'),
(93, 30, 10, 123, 'áo test');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieuxuat`
--

CREATE TABLE `ctphieuxuat` (
  `maphieuxuat` int(11) NOT NULL,
  `masp` int(11) DEFAULT NULL,
  `soluong` int(11) NOT NULL DEFAULT 0,
  `dongia` int(11) NOT NULL DEFAULT 0,
  `trangThaiHoanHang` tinyint(4) NOT NULL DEFAULT 1 COMMENT '1 là đang hoạt động, 2 là đã hoàn hàng, 0 là hủy',
  `tensp` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieuxuat`
--

INSERT INTO `ctphieuxuat` (`maphieuxuat`, `masp`, `soluong`, `dongia`, `trangThaiHoanHang`, `tensp`) VALUES
(239, 19, 10, 399000, 1, 'Áo sweater BABY LABEL '),
(239, 20, 20, 389000, 1, 'Áo RED SUN'),
(239, 21, 10, 289000, 1, 'Áo GLEEFUL '),
(240, 18, 20, 429000, 1, 'Áo hoodie FOSSIL'),
(240, 19, 20, 399000, 1, 'Áo sweater BABY LABEL '),
(241, 21, 100, 289000, 1, 'Áo GLEEFUL '),
(241, 19, 80, 399000, 2, 'Áo sweater BABY LABEL '),
(241, 24, 90, 196000, 1, ' Quần GRACEFUL'),
(242, 26, 13, 259000, 1, 'HADES BERMUDE WASH'),
(242, 28, 13, 899, 1, 'HADES BACKSPIKE PANTS'),
(242, 18, 13, 429000, 2, 'Áo hoodie FOSSIL'),
(243, 25, 100, 79000, 1, 'Quần VIBRANT COTTON'),
(243, 13, 90, 299000, 1, 'Áo polo ARGENTBLUE'),
(244, 26, 29, 259000, 1, 'HADES BERMUDE WASH'),
(244, 21, 10, 289000, 1, 'Áo GLEEFUL '),
(245, 25, 10, 79000, 1, 'Quần VIBRANT COTTON'),
(246, 16, 23, 529000, 2, 'Áo hoodie IMPRESSION'),
(247, 15, 37, 349000, 1, 'Áo polo LEGECY'),
(248, 21, 10, 289000, 1, 'Áo GLEEFUL '),
(248, 13, 10, 299000, 1, 'Áo polo ARGENTBLUE'),
(248, 16, 11, 529000, 1, 'Áo hoodie IMPRESSION'),
(249, 21, 10, 289000, 2, 'Áo GLEEFUL '),
(249, 22, 10, 589000, 1, ' Quần jeans ADORE'),
(249, 23, 10, 569000, 1, 'Quần jeans LUSTRE'),
(250, 13, 10, 299000, 2, 'Áo polo ARGENTBLUE'),
(251, 15, 10, 349000, 1, 'Áo polo LEGECY'),
(252, 13, 1, 299000, 1, 'Áo polo ARGENTBLUE'),
(253, 16, 10, 529000, 1, 'Áo hoodie IMPRESSION'),
(254, 11, 1, 250000, 2, 'Áo I HAVE LOVELY'),
(254, 13, 1, 299000, 1, 'Áo polo ARGENTBLUE'),
(255, 14, 10, 399000, 1, 'Áo sơ mi PRD WORK'),
(256, 14, 1, 399000, 1, 'Áo sơ mi PRD WORK'),
(257, 14, 10, 399000, 1, 'Áo sơ mi PRD WORK'),
(257, 18, 1, 429000, 1, 'Áo hoodie FOSSIL'),
(258, 11, 1, 250000, 1, 'Áo I HAVE LOVELY'),
(259, 30, 2, 123, 2, 'áo test'),
(260, 15, 10, 349000, 1, 'Áo polo LEGECY'),
(260, 18, 10, 429000, 1, 'Áo hoodie FOSSIL'),
(260, 20, 10, 389000, 1, 'Áo RED SUN'),
(260, 23, 10, 569000, 1, 'Quần jeans LUSTRE');

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
(1, 1, 'Xem', 1),
(1, 1, 'Xóa', 1),
(1, 2, 'Sửa', 1),
(1, 2, 'Thêm', 1),
(1, 2, 'Xem', 1),
(1, 2, 'Xóa', 1),
(1, 3, 'Sửa', 1),
(1, 3, 'Thêm', 1),
(1, 3, 'Xem', 1),
(1, 3, 'Xóa', 1),
(1, 4, 'Sửa', 1),
(1, 4, 'Thêm', 1),
(1, 4, 'Xem', 1),
(1, 4, 'Xóa', 1),
(1, 5, 'Sửa', 1),
(1, 5, 'Thêm', 1),
(1, 5, 'Xem', 1),
(1, 5, 'Xóa', 1),
(1, 6, 'Sửa', 1),
(1, 6, 'Thêm', 1),
(1, 6, 'Xem', 1),
(1, 6, 'Xóa', 1),
(1, 7, 'Sửa', 1),
(1, 7, 'Thêm', 1),
(1, 7, 'Xem', 1),
(1, 7, 'Xóa', 1),
(1, 8, 'Xem', 1),
(1, 9, 'Sửa', 1),
(1, 9, 'Thêm', 1),
(1, 9, 'Xem', 1),
(1, 9, 'Xóa', 1),
(1, 10, 'Sửa', 1),
(1, 10, 'Thêm', 1),
(1, 10, 'Xem', 1),
(1, 10, 'Xóa', 1),
(2, 2, 'Sửa', 1),
(2, 2, 'Thêm', 1),
(2, 2, 'Xem', 1),
(2, 4, 'Sửa', 1),
(2, 4, 'Thêm', 1),
(2, 4, 'Xem', 1),
(2, 5, 'Thêm', 1),
(2, 5, 'Xem', 1),
(2, 6, 'Sửa', 1),
(2, 6, 'Thêm', 1),
(2, 6, 'Xem', 1),
(2, 7, 'Thêm', 1),
(2, 7, 'Xem', 1),
(3, 3, 'Xóa', 1),
(3, 4, 'Xem', 1),
(3, 5, 'Xem', 1),
(3, 6, 'Xem', 1),
(4, 1, 'Xem', 1),
(4, 2, 'Xem', 1),
(4, 3, 'Xem', 1),
(4, 4, 'Xem', 1),
(4, 5, 'Xem', 1),
(4, 6, 'Xem', 1),
(4, 7, 'Xem', 1),
(4, 8, 'Xem', 1),
(4, 9, 'Xem', 1),
(4, 10, 'Xem', 1),
(5, 1, 'Sửa', 1),
(5, 1, 'Thêm', 1),
(5, 1, 'Xem', 1),
(5, 2, 'Sửa', 1),
(5, 2, 'Thêm', 1),
(5, 2, 'Xem', 1),
(5, 2, 'Xóa', 1),
(5, 3, 'Sửa', 1),
(5, 3, 'Thêm', 1),
(5, 3, 'Xem', 1),
(5, 3, 'Xóa', 1),
(5, 4, 'Sửa', 1),
(5, 4, 'Thêm', 1),
(5, 4, 'Xem', 1),
(5, 4, 'Xóa', 1),
(5, 5, 'Thêm', 1),
(5, 5, 'Xem', 1),
(5, 5, 'Xóa', 1),
(5, 6, 'Sửa', 1),
(5, 6, 'Thêm', 1),
(5, 6, 'Xem', 1),
(5, 6, 'Xóa', 1),
(5, 7, 'Thêm', 1),
(5, 7, 'Xem', 1),
(5, 7, 'Xóa', 1),
(5, 8, 'Xem', 1),
(31, 8, 'Xem', 1);

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
(35, 'Nguyễn Minh Khôi', 'minhkhoi.nguyen@gmail.com', '1995-04-10', '0905123456', 1),
(36, 'Trần Thị Thu Hà', 'thuhatran@yahoo.com', '1993-09-22', '0916234988', 1),
(37, 'Lê Anh Tuấn', 'tuan.le@hotmail.com', '1988-12-05', '0987651123', 1),
(38, 'Phạm Ngọc Mai', 'ngocmai.pham@gmail.com', '2000-06-17', '0934112233', 1),
(39, 'Đỗ Quốc Huy', 'quochuy.do@gmail.com', '1997-02-14', '0907556677', 1),
(40, 'Võ Thị Mỹ Linh', 'mylinh.vo@gmail.com', '1999-11-03', '0945332211', 1),
(41, 'Bùi Hoàng Phúc', 'hoangphuc.bui@gmail.com', '1994-08-29', '0908776655', 1),
(42, 'Hoàng Ngọc Trâm', 'ngoctram.hoang@yahoo.com', '1996-03-11', '0984115599', 1),
(43, 'Ngô Minh Tâm', 'minhtam.ngo@gmail.com', '1989-10-09', '0912663344', 1),
(44, 'Phan Thị Thanh Hằng', 'thanhhang.phan@gmail.com', '1998-07-25', '0935778899', 1),
(45, 'Nguyễn Hoài Nam', 'hoainam.nguyen@gmail.com', '1992-01-20', '0909443322', 1),
(46, 'Trương Mỹ Duyên', 'myduyen.truong@hotmail.com', '2001-05-19', '0946221144', 1),
(47, 'Lâm Quốc Toàn', 'quoctoan.lam@gmail.com', '1990-11-30', '0905889944', 1),
(48, 'Đặng Thị Kiều Oanh', 'kieuanh.dang@gmail.com', '1997-09-08', '0917334455', 1),
(49, 'Huỳnh Gia Bảo', 'giabao.huynh@gmail.com', '1999-04-27', '0988112233', 1);

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
(1, 'Khu B', '123 Đường Lê Lợi, Quận 1, TP.HCM', '02812345678', 'trungtam@kho.com'),
(2, 'Khu C', '456 Đường Hoàng Hoa Thám, Hà Nội', '02487654321', 'mienbac@kho.com'),
(3, 'Khu A1', '789 Đường Trần Hưng Đạo, Cần Thơ', '02921234567', 'miennam@kho.com'),
(4, 'Khu A2', '12 Đường Nguyễn Huệ, Đà Nẵng', '02363891234', 'khohoahoc@kho.com'),
(5, 'Khu D', '99 Đường Phạm Văn Đồng, Bình Dương', '02743876543', 'duphong@kho.com'),
(6, 'Khu A3', '', '', '');

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
(15, 'Áo thun');

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
(17, 'Công ty TNHH May Mặc Thịnh Phát', '123 Lê Lợi, Q1, TP.HCM', '0909123456', 'contact@thinhphat.com', 1),
(18, 'Công ty Cổ phần Thời Trang Sài Gòn', '456 Nguyễn Trãi, Q5, TP.HCM', '0912345678', 'info@saigonfashion.vn', 1),
(19, 'Công ty TNHH Vải & Phụ Kiện Đông Phương', '789 Trần Hưng Đạo, Q1, TP.HCM', '0987654321', 'sales@dongphuongfabric.com', 1),
(20, 'Công ty TNHH May Mặc Hùng Vương', '321 Phan Đình Phùng, Q3, TP.HCM', '0933111222', 'support@hungvuongclothing.com', 1),
(21, 'Công ty TNHH Thời Trang Vina', '654 Nguyễn Văn Cừ, Q5, TP.HCM', '0911222333', 'info@vinafashion.vn', 1),
(22, 'Công ty TNHH Sản Xuất Thời Trang GreenStyle', '987 Lý Thường Kiệt, Q10, TP.HCM', '0944556677', 'contact@greenstyle.com', 1),
(23, 'Công ty Cổ phần May Mặc TechWear', '135 Pasteur, Q3, TP.HCM', '0909888777', 'support@techwear.vn', 1);

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
(6, 'Trung testy', 1, '0352447642', '2025-11-04', 1),
(7, 'test_nhân_viên', 1, '0352447642', '2000-01-01', 1),
(8, 'test_qlKho', 1, '0334212476', '1995-12-09', 1);

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
(2, 'Nhân viên', 1),
(3, 'test', 1),
(4, 'test3', 1),
(5, 'Quản lý kho', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieukiemke`
--

CREATE TABLE `phieukiemke` (
  `maphieukiemke` int(11) NOT NULL,
  `thoigiantao` datetime NOT NULL DEFAULT current_timestamp(),
  `thoigiancanbang` datetime DEFAULT NULL,
  `trangthai` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ghichu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `makhuvuc` int(11) DEFAULT NULL,
  `manhanvientao` int(11) DEFAULT NULL,
  `manhanvienkiem` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `phieukiemke`
--

INSERT INTO `phieukiemke` (`maphieukiemke`, `thoigiantao`, `thoigiancanbang`, `trangthai`, `ghichu`, `makhuvuc`, `manhanvientao`, `manhanvienkiem`) VALUES
(28, '2025-12-12 06:43:44', '2025-12-12 06:43:44', 'Đã xóa', 'Đủ ', NULL, 6, 6),
(29, '2025-12-12 06:44:04', '2025-12-12 06:44:04', 'Đã xóa', 'đủ', NULL, 6, 6),
(30, '2025-12-12 06:45:09', '0001-01-01 00:00:00', 'Đã xóa', 'đủ', NULL, 6, 6),
(31, '2025-12-12 06:46:53', '0001-01-01 00:00:00', 'Đã xóa', 'thiếu', NULL, 6, 6),
(32, '2025-12-12 06:49:09', '0001-01-01 00:00:00', 'Đã xóa', 'a', NULL, 6, 6),
(33, '2025-12-12 06:50:30', '0001-01-01 00:00:00', 'Đã xóa', 'a', NULL, 6, 6),
(34, '2025-12-12 06:52:10', '0001-01-01 00:00:00', 'Đã xóa', 'a', NULL, 6, 6),
(35, '2025-12-12 06:54:40', '0001-01-01 00:00:00', 'Đã xóa', '', NULL, 6, 6),
(36, '2025-12-12 14:42:30', '2025-12-12 14:42:30', 'Đã xóa', 'kiểm tra quần ', NULL, 6, 6),
(37, '2025-12-12 14:43:22', '0001-01-01 00:00:00', 'Đã xóa', 'áo', NULL, 6, 6),
(38, '2025-12-12 16:01:48', '0001-01-01 00:00:00', 'Đã xóa', 'lỗi ', NULL, 6, 6),
(39, '2025-12-12 16:02:34', '0001-01-01 00:00:00', 'Đã xóa', 'lỗi ', NULL, 6, 6),
(40, '2025-12-12 16:06:50', '0001-01-01 00:00:00', 'Đã xóa', 'test bug', NULL, 6, 6),
(41, '2025-12-13 04:26:30', '2025-12-13 04:26:30', 'Đã cân bằng', 'kiểm tra quần ', NULL, 6, 6),
(42, '2025-12-13 04:27:15', '2025-12-13 04:29:52', 'Đã cân bằng', 'thiếu áo love', NULL, 6, 6),
(43, '2025-12-13 05:32:01', '0001-01-01 00:00:00', 'Chưa cân bằng', 'thiếu áo hoodie', NULL, 6, 6),
(44, '2025-12-13 05:43:20', '0001-01-01 00:00:00', 'Chưa cân bằng', 'thiếu quá nhiều', NULL, 6, 4),
(45, '2025-12-13 05:44:29', '0001-01-01 00:00:00', 'Chưa cân bằng', '', NULL, 6, 4);

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
(45, 6, 23, '2025-12-12 06:00:25', 477700000, 0),
(46, 6, 23, '2025-12-12 06:02:28', 477700000, 0),
(47, 6, 23, '2025-12-12 06:06:16', 723000000, 0),
(48, 6, 23, '2025-12-12 06:10:02', 299000000, 0),
(49, 6, 23, '2025-12-12 06:10:33', 299000000, 0),
(50, 6, 23, '2025-12-12 06:12:25', 250000, 0),
(51, 6, 22, '2025-12-12 06:13:46', 250000, 0),
(52, 6, 21, '2025-12-12 06:14:51', 250000, 0),
(53, 6, 21, '2025-12-12 06:16:26', 314800000, 0),
(54, 6, 21, '2025-12-12 06:16:35', 250000000, 0),
(55, 6, 22, '2025-12-12 06:18:02', 250000, 0),
(56, 6, 22, '2025-12-12 06:18:39', 250000, 0),
(57, 6, 23, '2025-12-12 06:26:33', 319800000, 0),
(58, 6, 23, '2025-12-12 06:29:59', 250000, 0),
(59, 6, 23, '2025-12-12 06:30:52', 250000, 0),
(60, 6, 21, '2025-12-12 06:34:51', 250000, 0),
(61, 6, 21, '2025-12-12 06:37:13', 250000, 0),
(62, 6, 23, '2025-12-12 06:37:31', 299000, 0),
(63, 6, 23, '2025-12-12 06:37:41', 250000, 0),
(64, 6, 22, '2025-12-12 06:38:00', 349000, 0),
(65, 6, 23, '2025-12-12 06:38:21', 349000, 0),
(66, 6, 22, '2025-12-12 06:39:51', 250000, 0),
(67, 6, 22, '2025-12-12 06:39:56', 250000, 0),
(68, 6, 22, '2025-12-12 06:39:59', 649000, 0),
(69, 6, 23, '2025-12-12 06:40:23', 25000000, 0),
(70, 6, 22, '2025-12-12 06:42:28', 250000, 0),
(71, 6, 22, '2025-12-12 06:42:47', 363900000, 0),
(72, 6, 23, '2025-12-01 00:00:00', 34900000, 0),
(73, 6, 21, '2025-12-12 06:55:00', 299000, 0),
(74, 6, 21, '2025-12-12 07:14:51', 49900000, 0),
(75, 6, 20, '2025-12-12 07:15:10', 52900000, 0),
(76, 6, 23, '2025-12-12 13:32:16', 2500000, 0),
(77, 6, 23, '2025-12-12 13:33:07', 7980000, 0),
(78, 6, 23, '2025-12-12 13:37:54', 25000000, 0),
(79, 6, 22, '2025-12-12 13:39:08', 413700000, 1),
(80, 6, 23, '2025-12-12 13:39:52', 372210000, 1),
(81, 6, 23, '2025-12-10 00:00:00', 813900000, 1),
(82, 6, 18, '2025-12-12 13:40:49', 191770000, 1),
(83, 6, 23, '2025-11-03 00:00:00', 47178000, 1),
(84, 6, 20, '2025-12-12 13:42:25', 94079900, 1),
(85, 6, 22, '2025-10-23 00:00:00', 501780000, 1),
(86, 6, 20, '2025-08-25 00:00:00', 231297000, 1),
(87, 6, 21, '2025-12-12 13:43:46', 106250000, 1),
(88, 6, 22, '2025-07-29 00:00:00', 7769700, 1),
(89, 6, 21, '2024-02-12 00:00:00', 68280000, 1),
(90, 6, 22, '2025-12-12 13:45:37', 51850000, 1),
(91, 6, 22, '2025-12-03 00:00:00', 39900000, 1),
(92, 6, 22, '2025-12-12 14:28:50', 5689000, 1),
(93, 6, 21, '2025-12-13 05:40:54', 1230, 1);

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
(237, 6, 48, '2025-12-12 13:52:36', 81214000, 0),
(238, 6, 48, '2025-12-12 13:52:44', 81214000, 0),
(239, 6, 48, '2025-12-12 13:53:03', 14660000, 1),
(240, 6, 48, '2025-12-12 13:53:46', 16560000, 1),
(241, 6, 48, '2025-12-12 13:54:02', 78460000, 2),
(242, 6, 45, '2025-12-12 13:55:13', 8955687, 2),
(243, 6, 45, '2025-12-12 13:55:26', 34810000, 1),
(244, 6, 45, '2025-12-12 13:55:38', 10401000, 1),
(245, 6, 37, '2025-12-12 13:55:46', 790000, 1),
(246, 6, 48, '2025-12-12 13:55:54', 12167000, 3),
(247, 6, 48, '2025-12-12 13:56:02', 12913000, 1),
(248, 6, 48, '2025-12-12 13:56:15', 11699000, 1),
(249, 6, 47, '2025-12-12 13:56:27', 14470000, 2),
(250, 6, 45, '2025-12-12 13:57:46', 2990000, 3),
(251, 6, 45, '2025-12-12 13:58:11', 3490000, 1),
(252, 6, 48, '2025-12-12 14:03:24', 299000, 1),
(253, 6, 38, '2025-12-12 14:03:41', 5290000, 1),
(254, 6, 49, '2025-12-12 14:06:00', 549000, 2),
(255, 6, 48, '2025-12-12 14:13:01', 3990000, 1),
(256, 6, 48, '2025-12-12 14:14:47', 399000, 1),
(257, 6, 49, '2025-12-12 14:17:18', 4419000, 1),
(258, 6, 48, '2025-12-13 03:48:49', 250000, 1),
(259, 6, 48, '2025-12-13 05:41:17', 246, 0),
(260, 6, 49, '2025-12-13 05:47:20', 17360000, 1);

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
  `TrangThai` tinyint(1) NOT NULL DEFAULT 1,
  `tenloai` varchar(255) DEFAULT '',
  `tenkhuvuc` varchar(255) DEFAULT '',
  `tenchatlieu` varchar(255) DEFAULT '',
  `tensize` varchar(255) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO `sanpham` (`masp`, `tensp`, `hinhanh`, `soluong`, `dongia`, `machatlieu`, `maloai`, `makhuvuc`, `masize`, `TrangThai`, `tenloai`, `tenkhuvuc`, `tenchatlieu`, `tensize`) VALUES
(9, 'Áo cugi', 'images/stocks/Bảng màu_639011058952048588.png', 0, 123, 2, 5, 2, 2, 0, 'Quần jeans', 'Kho Miền Bắc', 'Polyester', 'S'),
(10, 'a', 'images/stocks/Bảng màu_639011059352560857.png', 0, 123, 2, 4, 2, 1, 0, 'Áo len', 'Kho Miền Bắc', 'Polyester', 'XS'),
(11, 'Áo I HAVE LOVELY', 'images/stocks/den-_e42e1b262fb443208fbf929ba64b9e2e-21-510x510_639011141703246282.jpg', 119, 250000, 7, 15, 3, 1, 1, 'Áo thun', 'Khu A1', 'Nỉ', 'XS'),
(12, 'Áo thun dài AT4P1009', 'images/stocks/te10004_hfwkm5ol-1-nlqx-hinh_mat_truoc-0_6faa7fe51d6b4e679b8b6fb8f4f6b4e9-7-510x510_639011142595765540.jpg', 0, 269000, 7, 2, 3, 4, 0, 'Áo sơ mi', 'Khu A1', 'Nỉ', 'L'),
(13, 'Áo polo ARGENTBLUE', 'images/stocks/TA9102_LCR2YPDV-1-V6IX-hinh_mat_truoc-0-fotor-20250805171759-510x510_639011143207229712.jpg', 888, 299000, 5, 2, 3, 4, 1, 'Áo sơ mi', 'Khu A1', 'Lụa', 'L'),
(14, 'Áo sơ mi PRD WORK', 'images/stocks/SM5P0713-4-fotor-20250905142558-510x504_639011143467152295.jpg', 90, 399000, 12, 2, 3, 5, 1, 'Áo sơ mi', 'Khu A1', 'Vải kaki', 'XL'),
(15, 'Áo polo LEGECY', 'images/stocks/TA9102_LCR2YPDV-1-O0B9-hinh_mat_truoc-0-fotor-20250805172639-510x510_639011144034800219.jpg', 170, 349000, 7, 4, 3, 5, 1, 'Áo len', 'Khu A1', 'Nỉ', 'XL'),
(16, 'Áo hoodie IMPRESSION', 'images/stocks/kem-1_b10c1a5991454534a29da7f04670bec1-2_639011144926603164.jpg', 373, 529000, 6, 10, 1, 2, 1, 'Áo hoodie', 'Khu B', 'Vải bố', 'S'),
(17, 'Áo hoodie CARAMEL', 'images/stocks/kem-_79e7c7b2f5d24a37938c3e96f8da1a14-19_639011147702835128.jpg', 480, 499000, 1, 10, 1, 6, 1, 'Áo hoodie', 'Khu B', 'Cotton', 'XXL'),
(18, 'Áo hoodie FOSSIL', 'images/stocks/den-_fd6eb68d78a74ea49edc42f6e8b6a1e1-19-510x510_639011148634194385.jpg', 259, 429000, 6, 10, 1, 4, 1, 'Áo hoodie', 'Khu B', 'Vải bố', 'L'),
(19, 'Áo sweater BABY LABEL ', 'images/stocks/ST5T0601-front-1536x1536_639011149230046723.jpg', 1280, 399000, 6, 10, 1, 3, 1, 'Áo hoodie', 'Khu B', 'Vải bố', 'M'),
(20, 'Áo RED SUN', 'images/stocks/AK5P0404-front-510x510_639011150336018499.jpg', 140, 389000, 7, 11, 1, 7, 1, 'Áo khoác gió', 'Khu B', 'Nỉ', 'XXXL'),
(21, 'Áo GLEEFUL ', 'images/stocks/xanh-_ba3bbb63785944f496f449690f629128-1-510x510_639011150661057581.jpg', 1880, 289000, 2, 11, 1, 3, 1, 'Áo khoác gió', 'Khu B', 'Polyester', 'M'),
(22, ' Quần jeans ADORE', 'images/stocks/den-_ad749f515bb542c6b15a2d1ee684f8f2-6-510x510_639011151266283225.jpg', 200, 589000, 4, 5, 2, 4, 1, 'Quần jeans', 'Khu C', 'Jean', 'L'),
(23, 'Quần jeans LUSTRE', 'images/stocks/kem-_96532d95fee740d1a638661418a44f76-6-510x510_639011152090764382.jpg', 240, 569000, 4, 5, 2, 5, 1, 'Quần jeans', 'Khu C', 'Jean', 'XL'),
(24, ' Quần GRACEFUL', 'images/stocks/quan_tay_c45e807b86b140bc9d24070b10a16bf4-10-510x510_639011153099665753.jpg', 900, 196000, 4, 5, 2, 5, 1, 'Quần jeans', 'Khu C', 'Jean', 'XL'),
(25, 'Quần VIBRANT COTTON', 'images/stocks/Quần ngắn dù ParadoxCOLLEGIATE – QS5T0502_639011154149079456.jpg', 120, 79000, 1, 12, 4, 3, 1, 'Quần short', 'Khu A2', 'Cotton', 'M'),
(26, 'HADES BERMUDE WASH', 'images/stocks/dsc03116_large_5a43f0478dc74eb49b48b090be289ae6_639011155661463857.jpeg', 300, 259000, 4, 5, 4, 3, 1, 'Quần jeans', 'Khu A2', 'Jean', 'M'),
(27, 'HADES ENLISTED HOODIE', 'images/stocks/dsc03398_large_dc9e5b1ba24f47a388972419fce06db3_639011156125024463.jpeg', 340, 129000, 11, 10, 1, 5, 1, 'Áo hoodie', 'Khu B', 'Vải thun Spandex', 'XL'),
(28, 'HADES BACKSPIKE PANTS', 'images/stocks/_dsf7779_large_745ca06946c54eabb047e750cd7b41a4_639011157205079796.jpeg', 387, 900, 4, 5, 5, 5, 1, 'Quần jeans', 'Khu D', 'Jean', 'XL'),
(29, 'a', 'images/stocks/AK5P0404-front-510x510_639011522794567033.jpg', 0, 123, 3, 3, 3, 3, 0, 'Áo khoác', 'Khu A1', 'Len', 'M'),
(30, 'áo test', 'images/stocks/AK5P0404-front-510x510_639012012255784251.jpg', 10, 123, 2, 3, 2, 2, 1, 'Áo khoác', 'Khu C', 'Polyester', 'S');

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
(6, 'admin', '123', 1, 1),
(7, 'nv', '123', 2, 1),
(8, 'qlk', '123', 5, 1);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `chatlieu`
--
ALTER TABLE `chatlieu`
  ADD PRIMARY KEY (`machatlieu`);

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
  ADD KEY `FK_phieukiemke_nhanvien` (`manhanvienkiem`);

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
  MODIFY `makh` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT cho bảng `khuvuckho`
--
ALTER TABLE `khuvuckho`
  MODIFY `makhuvuc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `loai`
--
ALTER TABLE `loai`
  MODIFY `maloai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT cho bảng `nhacungcap`
--
ALTER TABLE `nhacungcap`
  MODIFY `mancc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT cho bảng `nhanvien`
--
ALTER TABLE `nhanvien`
  MODIFY `manv` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT cho bảng `nhomquyen`
--
ALTER TABLE `nhomquyen`
  MODIFY `manhomquyen` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `phieukiemke`
--
ALTER TABLE `phieukiemke`
  MODIFY `maphieukiemke` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT cho bảng `phieunhap`
--
ALTER TABLE `phieunhap`
  MODIFY `maphieunhap` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=94;

--
-- AUTO_INCREMENT cho bảng `phieuxuat`
--
ALTER TABLE `phieuxuat`
  MODIFY `maphieuxuat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=261;

--
-- AUTO_INCREMENT cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `masp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

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
  ADD CONSTRAINT `FK_phieukiemke_nhanvien` FOREIGN KEY (`manhanvienkiem`) REFERENCES `nhanvien` (`manv`) ON DELETE SET NULL;

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
