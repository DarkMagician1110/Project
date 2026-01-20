USE [master]
GO
/****** Object:  Database [QLTV]    Script Date: 20/1/2026 7:51:30 PM ******/
CREATE DATABASE [QLTV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLTV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLTV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLTV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QLTV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLTV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLTV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLTV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLTV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLTV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLTV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLTV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLTV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLTV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLTV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLTV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLTV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLTV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLTV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLTV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLTV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLTV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLTV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLTV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLTV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLTV] SET RECOVERY FULL 
GO
ALTER DATABASE [QLTV] SET  MULTI_USER 
GO
ALTER DATABASE [QLTV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLTV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLTV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLTV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLTV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLTV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLTV', N'ON'
GO
ALTER DATABASE [QLTV] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLTV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLTV]
GO
/****** Object:  Table [dbo].[DAUSACH]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DAUSACH](
	[IDSach] [varchar](10) NOT NULL,
	[TenSach] [nvarchar](200) NOT NULL,
	[TheLoai] [nvarchar](100) NULL,
	[TacGia] [nvarchar](150) NULL,
	[NhaXuatBan] [nvarchar](150) NULL,
	[NamXuatBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCGIA]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCGIA](
	[MaKH] [varchar](10) NOT NULL,
	[HoTen] [nvarchar](150) NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SoDienThoai] [varchar](15) NULL,
	[Email] [varchar](150) NULL,
	[NgayDangKy] [date] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUMUON]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUON](
	[MaPhieu] [int] IDENTITY(1,1) NOT NULL,
	[AccessionNo] [varchar](15) NOT NULL,
	[MaKH] [varchar](10) NOT NULL,
	[IDNV] [varchar](10) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[HanTra] [date] NULL,
	[NgayTra] [date] NULL,
	[PhiPhat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[AccessionNo] [varchar](15) NOT NULL,
	[IDSach] [varchar](10) NOT NULL,
	[TinhTrang] [tinyint] NOT NULL,
	[NgayNhap] [date] NULL,
	[GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccessionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUTHU]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUTHU](
	[MaNV] [varchar](10) NOT NULL,
	[HoTen] [nvarchar](150) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[TrangThai] [bit] NULL,
	[VaiTro] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV001', N'MIND MAP Hack 3000 Từ Vựng Tiếng Anh ', N'Tiếng Anh', N'Huyền Windy', N'NXB Hồng Đức', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV002', N'Destination Grammar & Vocabulary B1', N'Tiếng Anh', NULL, N'NXB Hồng Đức', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV003', N'Destination Grammar & Vocabulary B2', N'Tiếng Anh', NULL, N'NXB Hồng Đức', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV004', N'Destination Grammar & Vocabulary C1&C2', N'Tiếng Anh', N'', N'NXB Hồng Đức', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV005', N'Cambridge IELTS Academic 19', N'Tiếng Anh', N'Cambridge ', N' Cambridge University', 2024)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV006', N'Cambridge IELTS Academic 20', N'Tiếng Anh', N'Canbridge', N'Canbridge University', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV007', N'Chấp Bút 1000 Câu Writing – 30 Ngày Gieo Trồng Tư Duy Writing', N'Tiếng Anh', NULL, N'NXB Đồng Nai', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'AV008', N'Cambridge IELTS Academic 21', N'Tiếng Anh', N'Canbridge', N'Canbridge University', 2026)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'CT001', N'Tấm Lòng Với Đất Nước', N'Chính trị', N'Nguyễn Thị Bình', N'NXB Chính trị QG Sự thật', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'CT002', N'Hành Trình Theo Chân Bác', N'Chính trị', N'Trần Đức Tuấn', N'NXB Trẻ', 2021)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'CT003', N'Tổng Hành Dinh Trong Mùa Xuân Toàn Thắng', N'Chính trị', N'Đại tướng Võ Nguyên Giáp', N'NXB Chính trị QG Sự thật', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'CT004', N'Sự thật về nạn đói năm 1945', N'Chính trị', N'Nguyễn Quang Ân', N'NXB Chính trị QG Sự thật', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'CT005', N'Nhập Môn Triết Học Chính Trị ', N'Chính trị', N'Jonathan Wolff', N'NXB ĐHQG Hà Nội', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT001', N'Giáo Trình NGÔN NGỮ LẬP TRÌNH C++', N'Công nghệ Thông tin', N'Vũ Việt Vũ', N'NXB KH và KT', 2006)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT002', N'An Toàn Mạng', N'Công nghệ Thông tin', N'Cấn Thị Phượng ', N'NXB KH và KT', 2024)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT003', N'Bài tập nhập môn lập trình', N'Công nghệ Thông tin', N'Lê Thị Thùy Dương', N'NXB KH và KT', 2020)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT004', N'Điện toán đám mây', N'Công nghệ Thông tin', N'Huỳnh Quyết Thắng', N'NXB Bách Khoa HN', 2020)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT005', N'Nhập môn Linux và phần mềm mã nguồn mở', N'Công nghệ Thông tin', N'Hà Quốc Trung', N'NXB Bách Khoa HN', 2018)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT006', N'Bài tập lập trình Pascal', N'Công nghệ Thông tin', N'Hoàng Trung Sơn', N'NX KH và KT', 2006)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'IT007', N'Cuộc Cách Mạng Blockchain', N'Công nghệ Thông tin', N'Don & Alex Tapscott', N'NXB ĐH Kinh tế Quốc dân', 2018)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT001', N'Kinh doanh - Khái lược những tư tưởng lớn', N'Kinh tế', N'DK', N'NXB Dân trí', 2019)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT002', N'Kinh tế Marketing - 101 ý tưởng marketing trong bán hàng', N'Kinh tế', N'Nguyễn Anh Dũng', N'NXB Thế giới', 2020)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT003', N'Khởi Nghiệp Kinh Doanh Online - Bán Hàng Hiệu Quả Trên Shopee', N'Kinh tế', N'Nguyễn Trí Long', N'NXB Đà Nẵng', 2022)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT004', N'Giải Mã Marketing Hiện Đại - Những Khám Phá Mới Nhất Về Khoa Học Marketing', N'Kinh tế', N'Trần Vũ Hiệp', N'NXB Thế giới', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT005', N'Kế Toán Vỉa Hè - Thực Hành Báo Cáo Tài Chính Căn Bản Từ Quầy Bán Nước Chanh', N'Kinh tế', N'Darrell Mullis & Judith Orloff', N'NXB Thế giới', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT006', N'Kinh Doanh Thời Trang - 8 Bước Xây Dựng, Vận Hành Và Phát Triển Shop Quần Áo Của Bạn', N'Kinh tế', N'Trần Viết Hưng ', N'NXB Thế giới', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT007', N'Bán Lẻ Hợp Kênh Omnichannel - Bùng nổ doanh số - Tăng trưởng bền vững - Trải nghiệm vượt trội', N'Kinh tế', N'
Nguyễn Quốc Tuấn', N'NXB Thế giới', 2024)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT008', N'Sổ Tay Kế Hoạch Kinh Doanh - Cuốn Sách Cho Người Khởi Nghiệp', N'Kinh tế', N'Collin Barrow - Paul Barrow - Robert Brown', N'NXB Thanh niên', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'KT010', N'Điểm Mù Trong Kinh Doanh - Đổi Mới Và Duy Trì Mối Quan Hệ Với Khách Hàng', N'Kinh tế', N'Steve Diller - Nathan Shedroff - Sean Sauber', N'NXB Phụ nữ Việt Nam', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'MT001', N'Bảo vệ và quản lý tài nguyên nước', N'Môi trường', N'Trần Đức Hạ', N'NXB KH và KT', 2016)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'MT002', N'Biến đổi khí hậu và tài nguyên môi trường', N'Môi trường', N'TS. Nguyễn Thị Hà; PGS.TS. Trần Quang Bảo; TS.Lã Nguyên Khang', N'NXB KH và KT', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'MT003', N'Chất thải nhựa tại một số khu bảo tồn biển Việt Nam – ô nhiễm và hệ luỵ
', N'Môi trường', N'Lê Thị Trinh, Phạm Thị Mai Thảo, Mai Hương Lam', N'NXB KH và KT', 2024)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'MT004', N'Điều tra, giám sát tài nguyên rừng bằng ứng dụng di động', N'Môi trường', N'Bùi Mạnh Hưng; Nguyễn Thị Bích Phượng', N'NXB KH và KT', NULL)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TL001', N'Giáo Trình Tâm Lí Học Đại Cương', N'Tâm lý', N'Nguyễn Quang Uẩn', N'NXB ĐH Sư Phạm', NULL)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TL002', N'Thao Túng Tâm Lý Đám Đông', N'Tâm Lý', N'Dale Carnegie', N'NXB Văn học', 2023)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TL003', N'Phi Lý Trí - Khám phá những động lực vô hình ẩn sau quyết định của con người ', N'Tâm lý', N'Dan Ariely', N'NXB Lao động', 2021)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT001', N'Sherlock Holmes', N'Tiểu thuyết', N'Sir Arthur Conan Doyle', N'NXB Văn học', 2024)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT002', N'Cuộc Thám Hiểm Vào Lòng Đất ', N'Tiểu thuyết', N'Jules Verne', N'NXB Văn học', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT003', N'Bá tước Monte Cristo', N'Tiểu thuyết', N'Alexandre Dumas', N'NXB Văn học', 2025)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT004', N'Ông Già Và Biển Cả', N'Tiểu thuyết', N'Ernest Hemingway', N'NXB Văn học', 2020)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT005', N'Nhà Giả Kim', N'Tiểu thuyết', N'Paulo Coelho', N'NXB Văn học', 2020)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT006', N'Cuộc phiêu lưu của Tom Sawyer', N'Tiểu thuyết', N'Mark Twain', N'NXB Văn học', 2019)
GO
INSERT [dbo].[DAUSACH] ([IDSach], [TenSach], [TheLoai], [TacGia], [NhaXuatBan], [NamXuatBan]) VALUES (N'TT007', N'Sự Im Lặng Của Bầy', N'Lãng Mạn', N'Thomas Harris', N'NXB Văn học', 2019)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH001', N'Huỳnh Gia Thịnh', NULL, NULL, NULL, CAST(N'2025-10-12' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH002', N'Nguyễn Quốc Thắng', NULL, NULL, NULL, CAST(N'2025-10-12' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH003', N'Lê Hữu Trung', NULL, NULL, NULL, CAST(N'2025-10-12' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH004', N'Nguyễn Văn A', NULL, NULL, NULL, CAST(N'2025-10-15' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH005', N'Lê Thị B', NULL, NULL, NULL, CAST(N'2025-10-15' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH006', N'Nguyễn Thị C', NULL, NULL, NULL, CAST(N'2025-10-14' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH007', N'Trần Việt D', NULL, NULL, NULL, CAST(N'2025-10-16' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH008', N'Huỳnh Mạnh E', NULL, NULL, NULL, CAST(N'2025-10-14' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH009', N'Lâm Nguyễn F', NULL, NULL, NULL, CAST(N'2025-10-17' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH010', N'Trần Văn G', NULL, NULL, NULL, CAST(N'2025-10-17' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH011', N'Mai Văn K', NULL, NULL, NULL, CAST(N'2025-10-15' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH012', N'Đỗ Cường M', NULL, NULL, NULL, CAST(N'2025-10-22' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH013', N'Phan Cường O', NULL, NULL, NULL, CAST(N'2025-10-25' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH014', N'Phạm Tấn P', NULL, NULL, NULL, CAST(N'2025-10-25' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH015', N'Đặng Nguyễn Trần Q', NULL, NULL, NULL, CAST(N'2025-11-02' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH016', N'Trương Quốc R', NULL, NULL, NULL, CAST(N'2025-11-02' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH017', N'Bùi Minh N', NULL, NULL, NULL, CAST(N'2025-11-02' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH018', N'Huỳnh Tấn T', NULL, NULL, NULL, CAST(N'2025-11-05' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH019', N'Nguyễn Mạnh S', NULL, NULL, NULL, CAST(N'2025-11-03' AS Date), 1)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH020', N'Lê Diễm U', NULL, NULL, NULL, CAST(N'2025-11-04' AS Date), 0)
GO
INSERT [dbo].[DOCGIA] ([MaKH], [HoTen], [DiaChi], [SoDienThoai], [Email], [NgayDangKy], [TrangThai]) VALUES (N'KH021', N'Huynh Gia Thinh', N'', N'', N'', CAST(N'2026-01-18' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[PHIEUMUON] ON 
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (1, N'TV003', N'KH001', N'NV001', CAST(N'2025-11-10' AS Date), CAST(N'2025-12-10' AS Date), CAST(N'2025-12-27' AS Date), 340000)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (2, N'TV004', N'KH004', N'NV001', CAST(N'2025-11-20' AS Date), CAST(N'2025-12-20' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (3, N'TV006', N'KH004', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), CAST(N'2026-01-02' AS Date), 440000)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (4, N'TV008', N'KH004', N'NV001', CAST(N'2025-12-02' AS Date), CAST(N'2026-01-01' AS Date), CAST(N'2026-01-02' AS Date), 20000)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (5, N'TV010', N'KH005', N'NV001', CAST(N'2025-11-15' AS Date), CAST(N'2025-12-15' AS Date), CAST(N'2026-01-02' AS Date), 360000)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (6, N'TV011', N'KH006', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (7, N'TV012', N'KH005', N'NV001', CAST(N'2025-11-20' AS Date), CAST(N'2025-12-20' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (8, N'TV014', N'KH006', N'NV001', CAST(N'2025-11-18' AS Date), CAST(N'2025-12-18' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (9, N'TV015', N'KH001', N'NV001', CAST(N'2025-11-18' AS Date), CAST(N'2025-12-18' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (10, N'TV016', N'KH007', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), CAST(N'2026-01-02' AS Date), 440000)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (11, N'TV017', N'KH008', N'NV001', CAST(N'2025-11-15' AS Date), CAST(N'2025-12-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (12, N'TV019', N'KH008', N'NV001', CAST(N'2025-11-15' AS Date), CAST(N'2025-12-15' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (13, N'TV020', N'KH009', N'NV001', CAST(N'2025-12-02' AS Date), CAST(N'2026-01-01' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (14, N'TV023', N'KH007', N'NV001', CAST(N'2025-12-02' AS Date), CAST(N'2026-01-01' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (15, N'TV027', N'KH011', N'NV001', CAST(N'2025-10-15' AS Date), CAST(N'2025-11-14' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (16, N'TV030', N'KH010', N'NV001', CAST(N'2025-11-10' AS Date), CAST(N'2025-12-10' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (17, N'TV032', N'KH010', N'NV001', CAST(N'2025-10-30' AS Date), CAST(N'2025-11-29' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (18, N'TV034', N'KH003', N'NV001', CAST(N'2025-10-30' AS Date), CAST(N'2025-11-29' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (19, N'TV036', N'KH014', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (20, N'TV037', N'KH014', N'NV001', CAST(N'2025-11-21' AS Date), CAST(N'2025-12-21' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (21, N'TV041', N'KH015', N'NV001', CAST(N'2025-11-21' AS Date), CAST(N'2025-12-21' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (22, N'TV042', N'KH015', N'NV001', CAST(N'2025-10-21' AS Date), CAST(N'2025-11-20' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (23, N'TV043', N'KH016', N'NV001', CAST(N'2025-11-21' AS Date), CAST(N'2025-12-21' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (24, N'TV045', N'KH017', N'NV001', CAST(N'2025-12-10' AS Date), CAST(N'2026-01-09' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (25, N'TV053', N'KH018', N'NV001', CAST(N'2025-11-18' AS Date), CAST(N'2025-12-18' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (26, N'TV054', N'KH018', N'NV001', CAST(N'2025-11-30' AS Date), CAST(N'2025-12-30' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (27, N'TV057', N'KH019', N'NV001', CAST(N'2025-11-12' AS Date), CAST(N'2025-12-12' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (28, N'TV059', N'KH019', N'NV001', CAST(N'2025-11-12' AS Date), CAST(N'2025-12-12' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (29, N'TV060', N'KH003', N'NV001', CAST(N'2025-11-12' AS Date), CAST(N'2025-12-12' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (30, N'TV063', N'KH002', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (31, N'TV064', N'KH003', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (32, N'TV065', N'KH020', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (33, N'TV067', N'KH020', N'NV001', CAST(N'2025-11-11' AS Date), CAST(N'2025-12-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (34, N'TV074', N'KH002', N'NV001', CAST(N'2025-11-01' AS Date), CAST(N'2025-12-01' AS Date), CAST(N'2026-01-20' AS Date), 1000000)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (41, N'TV062', N'KH003', N'NV002', CAST(N'2025-12-27' AS Date), CAST(N'2026-01-27' AS Date), CAST(N'2026-01-18' AS Date), 0)
GO
INSERT [dbo].[PHIEUMUON] ([MaPhieu], [AccessionNo], [MaKH], [IDNV], [NgayMuon], [HanTra], [NgayTra], [PhiPhat]) VALUES (42, N'TV073', N'KH001', N'NV001', CAST(N'2026-01-01' AS Date), CAST(N'2026-02-01' AS Date), CAST(N'2026-01-02' AS Date), 0)
GO
SET IDENTITY_INSERT [dbo].[PHIEUMUON] OFF
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV001', N'AV001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV002', N'AV001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV003', N'AV001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV004', N'AV002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV005', N'AV002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV006', N'AV003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV007', N'AV003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV008', N'AV004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV009', N'AV004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV010', N'AV005', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV011', N'AV005', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV012', N'AV006', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV013', N'AV006', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV014', N'AV007', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV015', N'CT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV016', N'CT001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV017', N'CT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV018', N'CT001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV019', N'CT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV020', N'CT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV021', N'CT002', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV022', N'CT002', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV023', N'CT003', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV024', N'CT003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV025', N'CT004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV026', N'CT004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV027', N'CT005', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV028', N'CT005', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV029', N'CT005', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV030', N'IT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV031', N'IT001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV032', N'IT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV033', N'IT002', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV034', N'IT003', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV035', N'IT003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV036', N'IT004', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV037', N'IT005', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV038', N'IT005', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV039', N'IT006', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV040', N'IT007', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV041', N'KT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV042', N'KT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV043', N'KT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV044', N'KT002', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV045', N'KT003', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV046', N'KT003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV047', N'KT004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV048', N'KT005', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV049', N'KT006', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV050', N'KT007', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV051', N'KT008', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV052', N'KT010', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV053', N'MT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV054', N'MT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV055', N'MT003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV056', N'MT004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV057', N'TL001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV058', N'TL001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV059', N'TL002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV060', N'TL002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV061', N'TL003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV062', N'TL003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV063', N'TT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV064', N'TT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV065', N'TT001', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV066', N'TT001', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV067', N'TT002', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Đang được mượn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV068', N'TT003', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV069', N'TT004', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV070', N'TT005', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV071', N'TT006', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV072', N'TT007', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV073', N'TT007', 1, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV074', N'TT007', 0, CAST(N'2025-12-27' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV075', N'TT006', 3, CAST(N'2026-01-19' AS Date), N'Tình trạng: Mất')
GO
INSERT [dbo].[SACH] ([AccessionNo], [IDSach], [TinhTrang], [NgayNhap], [GhiChu]) VALUES (N'TV076', N'TT007', 0, CAST(N'2026-01-20' AS Date), N'Tình trạng: Có sẵn')
GO
INSERT [dbo].[THUTHU] ([MaNV], [HoTen], [Username], [Password], [TrangThai], [VaiTro]) VALUES (N'NV001', N'Huỳnh Gia Thịnh', N'admin', N'123456', 1, N'ADMIN')
GO
INSERT [dbo].[THUTHU] ([MaNV], [HoTen], [Username], [Password], [TrangThai], [VaiTro]) VALUES (N'NV002', N'HGT', N'HuynhGiaThinh', N'123456', 1, N'THUTHU')
GO
INSERT [dbo].[THUTHU] ([MaNV], [HoTen], [Username], [Password], [TrangThai], [VaiTro]) VALUES (N'NV005', N'LHT', N'LeHuuTrung', N'123456', 1, N'THUTHU')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THUTHU__536C85E42DC5E7D4]    Script Date: 20/1/2026 7:51:31 PM ******/
ALTER TABLE [dbo].[THUTHU] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DOCGIA] ADD  DEFAULT (getdate()) FOR [NgayDangKy]
GO
ALTER TABLE [dbo].[DOCGIA] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PHIEUMUON] ADD  DEFAULT (getdate()) FOR [NgayMuon]
GO
ALTER TABLE [dbo].[PHIEUMUON] ADD  DEFAULT ((0)) FOR [PhiPhat]
GO
ALTER TABLE [dbo].[SACH] ADD  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[SACH] ADD  DEFAULT (getdate()) FOR [NgayNhap]
GO
ALTER TABLE [dbo].[THUTHU] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_PM_KH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[DOCGIA] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [FK_PM_KH]
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_PM_NV] FOREIGN KEY([IDNV])
REFERENCES [dbo].[THUTHU] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [FK_PM_NV]
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_PM_SACH] FOREIGN KEY([AccessionNo])
REFERENCES [dbo].[SACH] ([AccessionNo])
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [FK_PM_SACH]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_DAUSACH] FOREIGN KEY([IDSach])
REFERENCES [dbo].[DAUSACH] ([IDSach])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_DAUSACH]
GO
ALTER TABLE [dbo].[DAUSACH]  WITH CHECK ADD CHECK  (([NamXuatBan]>=(0)))
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [CK_PM_TRA] CHECK  (([NgayTra] IS NULL OR [NgayTra]>=[NgayMuon]))
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [CK_PM_TRA]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [CK_SACH_TINHTRANG] CHECK  (([TinhTrang]=(4) OR [TinhTrang]=(3) OR [TinhTrang]=(2) OR [TinhTrang]=(1) OR [TinhTrang]=(0)))
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [CK_SACH_TINHTRANG]
GO
/****** Object:  Trigger [dbo].[TRG_TINH_PHI_PHAT]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_TINH_PHI_PHAT]
ON [dbo].[PHIEUMUON]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE PM
    SET PhiPhat =
        CASE
            WHEN I.NgayTra IS NULL THEN 0
            WHEN I.NgayTra <= I.HanTra THEN 0
            ELSE DATEDIFF(DAY, I.HanTra, I.NgayTra) * 20000
        END
    FROM PHIEUMUON PM
    JOIN inserted I ON PM.MaPhieu = I.MaPhieu
    JOIN deleted  D ON D.MaPhieu = I.MaPhieu
    WHERE D.NgayTra IS NULL
      AND I.NgayTra IS NOT NULL;
END;
GO
ALTER TABLE [dbo].[PHIEUMUON] ENABLE TRIGGER [TRG_TINH_PHI_PHAT]
GO
/****** Object:  Trigger [dbo].[TRG_SET_GHICHU_SACH]    Script Date: 20/1/2026 7:51:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TRG_SET_GHICHU_SACH]
ON [dbo].[SACH]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE S
    SET GhiChu =
        CASE S.TinhTrang
            WHEN 0 THEN N'Tình trạng: Có sẵn'
            WHEN 1 THEN N'Tình trạng: Đang được mượn'
            WHEN 2 THEN N'Tình trạng: Hư hỏng'
            WHEN 3 THEN N'Tình trạng: Mất'
        END
    FROM SACH S
    JOIN inserted I ON S.AccessionNo = I.AccessionNo;
END;
GO
ALTER TABLE [dbo].[SACH] ENABLE TRIGGER [TRG_SET_GHICHU_SACH]
GO
USE [master]
GO
ALTER DATABASE [QLTV] SET  READ_WRITE 
GO
