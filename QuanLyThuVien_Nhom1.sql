USE [master]
GO
/****** Object:  Database [QuanLyThuVien]    Script Date: 12/05/2023 13:41:33 ******/
CREATE DATABASE [QuanLyThuVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyThuVien', FILENAME = N'E:\Đồ án 1_ Nhóm 1\QuanLyThuVien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyThuVien_log', FILENAME = N'E:\Đồ án 1_ Nhóm 1\QuanLyThuVien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyThuVien] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyThuVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyThuVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyThuVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyThuVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyThuVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyThuVien] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyThuVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyThuVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyThuVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyThuVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyThuVien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyThuVien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyThuVien] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyThuVien] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyThuVien]
GO
/****** Object:  Table [dbo].[BanDoc]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanDoc](
	[MaBanDoc] [nchar](10) NOT NULL,
	[TenBanDoc] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_BanDoc] PRIMARY KEY CLUSTERED 
(
	[MaBanDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCC] [nchar](10) NOT NULL,
	[TenNhaCC] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNhaCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[MaPhieuMuon] [nchar](10) NOT NULL,
	[MaBanDoc] [nchar](10) NULL,
	[NgayMuon] [datetime] NULL,
	[NgayTra] [datetime] NULL,
 CONSTRAINT [PK_PhieuMuon] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon_Sach]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon_Sach](
	[MaPhieuMuon] [nchar](10) NOT NULL,
	[MaSach] [nchar](10) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_PhieuMuon_Sach] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [nchar](10) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaNhaCC] [nchar](10) NULL,
	[MaNV] [nchar](10) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap_Sach]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap_Sach](
	[MaPhieuNhap] [nchar](10) NOT NULL,
	[MaSach] [nchar](10) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_PhieuNhap_Sach] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 12/05/2023 13:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nchar](10) NOT NULL,
	[TenSach] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BanDoc] ([MaBanDoc], [TenBanDoc], [DiaChi]) VALUES (N'2010135   ', N'Vũ Hoài Ngọc', N'Hà Nội')
INSERT [dbo].[BanDoc] ([MaBanDoc], [TenBanDoc], [DiaChi]) VALUES (N'2010414   ', N'Lê Ngọc Ánh', N'Thanh Hóa	')
INSERT [dbo].[BanDoc] ([MaBanDoc], [TenBanDoc], [DiaChi]) VALUES (N'2010456   ', N'Trần Thị Bông', N'Phú Thọ')
INSERT [dbo].[BanDoc] ([MaBanDoc], [TenBanDoc], [DiaChi]) VALUES (N'2010552   ', N'Vũ Như Dương', N'Nam Định	')
INSERT [dbo].[BanDoc] ([MaBanDoc], [TenBanDoc], [DiaChi]) VALUES (N'2010923   ', N'Đặng Thu Hà', N'Hà Tĩnh')
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCC], [TenNhaCC]) VALUES (N'ADV       ', N'Nhà sách An Dương Vương')
INSERT [dbo].[NhaCungCap] ([MaNhaCC], [TenNhaCC]) VALUES (N'FTU       ', N'Đại học Ngoại Thương')
INSERT [dbo].[NhaCungCap] ([MaNhaCC], [TenNhaCC]) VALUES (N'Hust      ', N'Đại học Bách Khoa Hà Nội')
INSERT [dbo].[NhaCungCap] ([MaNhaCC], [TenNhaCC]) VALUES (N'NSHL      ', N'Nhà sách Hải Lan')
INSERT [dbo].[NhaCungCap] ([MaNhaCC], [TenNhaCC]) VALUES (N'Rose      ', N'Nhà sách Hoa Hồng')
INSERT [dbo].[NhaCungCap] ([MaNhaCC], [TenNhaCC]) VALUES (N'Uneti     ', N'Đại học Kinh tế Kĩ Thuật Công nghiệp')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV]) VALUES (N'NV01      ', N'Nguyễn Cao Thắng')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV]) VALUES (N'NV02      ', N'Lê Thị Liên')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV]) VALUES (N'NV03      ', N'Trần Huy Nam')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV]) VALUES (N'NV04      ', N'Trần Thu Minh')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV]) VALUES (N'NV05      ', N'Nguyễn Thị Tuyết')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV]) VALUES (N'NV07      ', N'Nguyễn Minh Châu')
GO
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [MaBanDoc], [NgayMuon], [NgayTra]) VALUES (N'M01       ', N'2010135   ', CAST(N'2022-02-22T10:38:58.000' AS DateTime), CAST(N'2022-03-05T10:38:58.000' AS DateTime))
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [MaBanDoc], [NgayMuon], [NgayTra]) VALUES (N'M02       ', N'2010552   ', CAST(N'2022-02-11T10:38:58.000' AS DateTime), CAST(N'2022-02-16T10:38:58.000' AS DateTime))
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [MaBanDoc], [NgayMuon], [NgayTra]) VALUES (N'M03       ', N'2010414   ', CAST(N'2022-02-11T10:38:58.000' AS DateTime), CAST(N'2022-02-20T10:38:58.000' AS DateTime))
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [MaBanDoc], [NgayMuon], [NgayTra]) VALUES (N'M04       ', N'2010923   ', CAST(N'2023-05-11T10:38:39.000' AS DateTime), CAST(N'2023-05-22T10:38:39.000' AS DateTime))
INSERT [dbo].[PhieuMuon] ([MaPhieuMuon], [MaBanDoc], [NgayMuon], [NgayTra]) VALUES (N'M05       ', N'2010135   ', CAST(N'2023-10-24T10:38:39.000' AS DateTime), CAST(N'2023-10-30T10:38:39.000' AS DateTime))
GO
INSERT [dbo].[PhieuMuon_Sach] ([MaPhieuMuon], [MaSach], [SoLuong]) VALUES (N'M01       ', N'D11       ', 7)
INSERT [dbo].[PhieuMuon_Sach] ([MaPhieuMuon], [MaSach], [SoLuong]) VALUES (N'M02       ', N'B01       ', 1)
INSERT [dbo].[PhieuMuon_Sach] ([MaPhieuMuon], [MaSach], [SoLuong]) VALUES (N'M02       ', N'C12       ', 2)
INSERT [dbo].[PhieuMuon_Sach] ([MaPhieuMuon], [MaSach], [SoLuong]) VALUES (N'M03       ', N'B01       ', 2)
INSERT [dbo].[PhieuMuon_Sach] ([MaPhieuMuon], [MaSach], [SoLuong]) VALUES (N'M04       ', N'D11       ', 4)
INSERT [dbo].[PhieuMuon_Sach] ([MaPhieuMuon], [MaSach], [SoLuong]) VALUES (N'M05       ', N'B01       ', 5)
GO
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhaCC], [MaNV]) VALUES (N'M102      ', CAST(N'2022-02-11T00:37:06.000' AS DateTime), N'Rose      ', N'NV01      ')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhaCC], [MaNV]) VALUES (N'M104      ', CAST(N'2023-12-12T00:37:06.000' AS DateTime), N'Hust      ', N'NV03      ')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayLap], [MaNhaCC], [MaNV]) VALUES (N'M105      ', CAST(N'2022-01-12T00:37:06.000' AS DateTime), N'ADV       ', N'NV05      ')
GO
INSERT [dbo].[PhieuNhap_Sach] ([MaPhieuNhap], [MaSach], [SoLuong]) VALUES (N'M102      ', N'A10       ', 2)
INSERT [dbo].[PhieuNhap_Sach] ([MaPhieuNhap], [MaSach], [SoLuong]) VALUES (N'M105      ', N'C22       ', 4)
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'A10       ', N'Xác suất thống kê')
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'A11       ', N'Công nghệ Java')
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'A21       ', N'Lập trình.NET')
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'B01       ', N'Quản trị nhân sự')
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'C12       ', N'Vật lý')
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'C22       ', N'Lập trình Web')
INSERT [dbo].[Sach] ([MaSach], [TenSach]) VALUES (N'D11       ', N'Tư tưởng Hồ Chí Minh')
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_BanDoc] FOREIGN KEY([MaBanDoc])
REFERENCES [dbo].[BanDoc] ([MaBanDoc])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_BanDoc]
GO
ALTER TABLE [dbo].[PhieuMuon_Sach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_Sach_PhieuMuon] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
GO
ALTER TABLE [dbo].[PhieuMuon_Sach] CHECK CONSTRAINT [FK_PhieuMuon_Sach_PhieuMuon]
GO
ALTER TABLE [dbo].[PhieuMuon_Sach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_Sach_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[PhieuMuon_Sach] CHECK CONSTRAINT [FK_PhieuMuon_Sach_Sach]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNhaCC])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap_Sach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_Sach_PhieuNhap1] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[PhieuNhap_Sach] CHECK CONSTRAINT [FK_PhieuNhap_Sach_PhieuNhap1]
GO
ALTER TABLE [dbo].[PhieuNhap_Sach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_Sach_Sach1] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[PhieuNhap_Sach] CHECK CONSTRAINT [FK_PhieuNhap_Sach_Sach1]
GO
USE [master]
GO
ALTER DATABASE [QuanLyThuVien] SET  READ_WRITE 
GO
