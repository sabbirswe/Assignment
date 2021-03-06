USE [master]
GO
/****** Object:  Database [Assignment]    Script Date: 6/14/2021 5:43:58 PM ******/
CREATE DATABASE [Assignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assignment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Assignment.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Assignment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Assignment_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Assignment] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Assignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assignment] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Assignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assignment] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Assignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assignment] SET  MULTI_USER 
GO
ALTER DATABASE [Assignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assignment] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Assignment] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Assignment]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/14/2021 5:43:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 6/14/2021 5:43:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/14/2021 5:43:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[RefID] [nvarchar](50) NOT NULL,
	[PoNo] [nvarchar](50) NOT NULL,
	[PoDate] [datetime2](7) NOT NULL,
	[ExpectedDate] [datetime2](7) NULL,
	[Remark] [nvarchar](250) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 6/14/2021 5:43:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Rate] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6/14/2021 5:43:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210612100815_InitializeDB', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210613063311_updateOrder', N'5.0.7')
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (1, N'Item A')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (2, N'Item B')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (3, N'Item C')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (9, N'Item D')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (10, N'Item E')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (11, N'Item F')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (12, N'Item G')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (13, N'Item H')
INSERT [dbo].[Item] ([ItemId], [ItemName]) VALUES (14, N'Item I')
SET IDENTITY_INSERT [dbo].[Item] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [SupplierId], [RefID], [PoNo], [PoDate], [ExpectedDate], [Remark]) VALUES (1, 1, N'001', N'12', CAST(N'2021-06-13 20:18:26.7140000' AS DateTime2), CAST(N'2021-06-21 20:18:22.0000000' AS DateTime2), N'test')
INSERT [dbo].[Order] ([OrderId], [SupplierId], [RefID], [PoNo], [PoDate], [ExpectedDate], [Remark]) VALUES (2, 1, N'002', N'23', CAST(N'2021-06-14 09:29:04.4980000' AS DateTime2), CAST(N'2021-06-24 09:22:56.0000000' AS DateTime2), NULL)
INSERT [dbo].[Order] ([OrderId], [SupplierId], [RefID], [PoNo], [PoDate], [ExpectedDate], [Remark]) VALUES (3, 1, N'003', N'Sabbir', CAST(N'2021-06-14 09:49:42.0150000' AS DateTime2), NULL, NULL)
INSERT [dbo].[Order] ([OrderId], [SupplierId], [RefID], [PoNo], [PoDate], [ExpectedDate], [Remark]) VALUES (4, 3, N'004', N'99', CAST(N'2021-06-13 03:52:34.3450000' AS DateTime2), CAST(N'2021-06-24 03:52:29.0000000' AS DateTime2), N'222')
INSERT [dbo].[Order] ([OrderId], [SupplierId], [RefID], [PoNo], [PoDate], [ExpectedDate], [Remark]) VALUES (5, 2, N'005', N'123', CAST(N'2021-06-14 04:50:27.2270000' AS DateTime2), CAST(N'2021-06-22 04:50:24.0000000' AS DateTime2), N'TEST')
INSERT [dbo].[Order] ([OrderId], [SupplierId], [RefID], [PoNo], [PoDate], [ExpectedDate], [Remark]) VALUES (7, 3, N'006', N'123', CAST(N'2021-06-14 11:03:08.1100000' AS DateTime2), CAST(N'2021-06-15 10:57:00.0000000' AS DateTime2), N'TEST')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (3, 3, 1, 23, 10)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (4, 1, 2, 10, 2)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (5, 3, 2, 5, 8)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (6, 2, 3, 1, 2)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (18, 3, 4, 66, 0.5)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (19, 1, 4, 1, 10)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (24, 9, 7, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [ItemId], [OrderId], [Qty], [Rate]) VALUES (29, 9, 5, 2, 1)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierId], [SupplierName]) VALUES (1, N'Supplier A')
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName]) VALUES (2, N'Supplier B')
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName]) VALUES (3, N'Supplier C')
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName]) VALUES (4, N'Supplier D')
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName]) VALUES (5, N'Supplier E')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
/****** Object:  Index [IX_Order_SupplierId]    Script Date: 6/14/2021 5:43:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_SupplierId] ON [dbo].[Order]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ItemId]    Script Date: 6/14/2021 5:43:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ItemId] ON [dbo].[OrderDetails]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_OrderId]    Script Date: 6/14/2021 5:43:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Supplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([SupplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Supplier_SupplierId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([ItemId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Item_ItemId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order_OrderId]
GO
USE [master]
GO
ALTER DATABASE [Assignment] SET  READ_WRITE 
GO
