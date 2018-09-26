USE [master]
GO
/****** Object:  Database [CAFETERIAUNAPEC]    Script Date: 26/09/2018 21:01:40 ******/
CREATE DATABASE [CAFETERIAUNAPEC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CAFETERIAUNAPEC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CAFETERIAUNAPEC.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CAFETERIAUNAPEC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CAFETERIAUNAPEC_log.ldf' , SIZE = 1600KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CAFETERIAUNAPEC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET ARITHABORT OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET RECOVERY FULL 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET  MULTI_USER 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CAFETERIAUNAPEC]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ARTICULO]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARTICULO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[IDMARCA] [int] NULL,
	[IDPROVEEDOR] [int] NULL,
	[COSTO] [decimal](18, 0) NOT NULL,
	[EXISTENCIA] [int] NOT NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__ARTICULO__3214EC274515CDC4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAFETERIA]    Script Date: 26/09/2018 21:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAFETERIA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[ENCARGADO] [nvarchar](50) NOT NULL,
	[IDCAMPUS] [int] NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__CAFETERI__3214EC2772A7EB6A] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAFETERIAEMPLEADO]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAFETERIAEMPLEADO](
	[IDEMPLEADO] [int] NULL,
	[ID] [int] NOT NULL,
	[IDCAFETERIA] [int] NULL,
 CONSTRAINT [PK_CAFETERIAEMPLEADO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAFETERIARTICULO]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAFETERIARTICULO](
	[IDARTICULO] [int] NULL,
	[IDCAFETERIA] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CAFETERIARTICULO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAMPUS]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAMPUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__CAMPUS__3214EC27580CDDA6] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detallefactura]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallefactura](
	[idDetalleFactura] [int] IDENTITY(1,1) NOT NULL,
	[idArticulo] [int] NULL,
	[idFactura] [int] NULL,
	[unidades] [int] NULL,
 CONSTRAINT [PK__detallef__DFF3825228464C1C] PRIMARY KEY CLUSTERED 
(
	[idDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDTANDALABOR] [int] NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[CEDULA] [nvarchar](11) NOT NULL,
	[COMISION] [decimal](18, 0) NOT NULL,
	[FECHAREGISTRO] [date] NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__EMPLEADO__3214EC273F66566D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[factura]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[factura](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](30) NOT NULL,
	[modoPago] [varchar](30) NULL,
	[idUsuario] [int] NULL,
	[idEmpleado] [int] NULL,
	[montoTotal] [decimal](16, 2) NULL,
	[idCafeteria] [int] NOT NULL,
 CONSTRAINT [PK__factura__3CD5687E787A1109] PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FACTURACION_ARTICULOS]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FACTURACION_ARTICULOS](
	[NoFactura] [int] IDENTITY(1,1) NOT NULL,
	[Unidades] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdArticulo] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaVenta] [date] NOT NULL,
	[MontoArticulo] [numeric](18, 2) NOT NULL,
	[Comentario] [varchar](30) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK__FACTURAC__365D8BFBA5A168A8] PRIMARY KEY CLUSTERED 
(
	[NoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FACTURACIONARTICULO]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURACIONARTICULO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEMPLEADO] [int] NULL,
	[IDARTICULO] [int] NULL,
	[IDUSUARIO] [int] NULL,
	[FECHAREGISTRO] [datetime2](7) NULL,
	[MONTO] [decimal](18, 0) NOT NULL,
	[UNIDADVENDIDA] [int] NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__FACTURAC__3214EC27E3BE8804] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOGIN_USERS]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOGIN_USERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USUARIO] [varchar](50) NOT NULL,
	[CONTRASEÑA] [varchar](50) NOT NULL,
	[TIPO_DE_USUARIO] [varchar](50) NOT NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_LOGIN_USERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__MARCA__3214EC270733D9A8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[RNC] [nvarchar](10) NOT NULL,
	[FECHAREGISTRO] [date] NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__PROVEEDO__3214EC27341C99EE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TANDALABOR]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TANDALABOR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TANDA] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK__TANDALAB__3214EC273A88108B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPOUSUARIO]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOUSUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__TIPOUSUA__3214EC27A44879C0] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[CEDULA] [nvarchar](11) NOT NULL,
	[IDTIPOUSUARIO] [int] NULL,
	[LIMITECREDITO] [numeric](9, 2) NULL,
	[FECHAREGISTRO] [varchar](50) NULL,
	[ESTADO] [nchar](15) NULL,
 CONSTRAINT [PK__USUARIO__3214EC27EC2C4F47] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[DetalleFactura_View]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DetalleFactura_View]
AS
SELECT UNIDADES, FACTURA.IDFACTURA, ARTICULO.DESCRIPCION, COSTO FROM detallefactura 
INNER JOIN ARTICULO ON ARTICULO.ID = detallefactura.idArticulo
INNER JOIN factura ON FACTURA.idFactura = detallefactura.idFactura

GO
/****** Object:  View [dbo].[MontoTotal]    Script Date: 26/09/2018 21:01:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MontoTotal]
AS
SELECT idfactura, MONTOTOTAL FROM FACTURA;

GO
SET IDENTITY_INSERT [dbo].[ARTICULO] ON 

INSERT [dbo].[ARTICULO] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [ESTADO]) VALUES (48, N'COCA COLA LIGHT', 9, 8, CAST(25 AS Decimal(18, 0)), 0, N'ACTIVO         ')
INSERT [dbo].[ARTICULO] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [ESTADO]) VALUES (49, N'PASTA DENTAL COLGATE', 10, 8, CAST(50 AS Decimal(18, 0)), 0, N'ACTIVO         ')
INSERT [dbo].[ARTICULO] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [ESTADO]) VALUES (50, N'PAPITAS ', 9, 7, CAST(25 AS Decimal(18, 0)), 0, N'ACTIVO         ')
INSERT [dbo].[ARTICULO] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [ESTADO]) VALUES (51, N'JABON', 9, 8, CAST(20 AS Decimal(18, 0)), 50, N'ACTIVO         ')
INSERT [dbo].[ARTICULO] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [ESTADO]) VALUES (52, N'DORITOS', 9, 7, CAST(30 AS Decimal(18, 0)), 10, N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[ARTICULO] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Consultor')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0b0923c4-3464-4d00-a36a-6c1cabb2c0ca', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6ddb75d1-ae4c-4d3b-a63e-5bc360aa6dab', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'48111759-48e2-49b7-8ab7-36c957f1aa04', N'2')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0b0923c4-3464-4d00-a36a-6c1cabb2c0ca', N'ing.valen0421@hotmail.com', 0, N'AHBwN6TeOBVGk4CWE7uRf5Xx0SPlpfuWOrtdRm8h5nCO2pvTSP06tbp/A4PP7GH3AQ==', N'aeab982e-55e5-44ac-bd3f-18ffd2748555', NULL, 0, 0, NULL, 1, 0, N'ing.valen0421@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'48111759-48e2-49b7-8ab7-36c957f1aa04', N'enmanuel54sk8@gmail.com', 0, N'AMP8k3VBm6q1Srlc1FbHkMbNN7+0dJsvTthomrAZzxG5J5OUuoOjDm2Cs5tjGtkVAg==', N'276ec17a-ef7b-47ce-adc3-eb0c4678b2cf', NULL, 0, 0, NULL, 1, 0, N'enmanuel54sk8@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6ddb75d1-ae4c-4d3b-a63e-5bc360aa6dab', N'zoruark06@gmail.com', 0, N'AKgSb176gbkM88g6eiv9MOEhUrVt9q+V7QcBf8bztrg6YHXDN6EcIZ7Be2+wnWMVtg==', N'7691da73-732d-44eb-b981-2ba5a9fbaa83', NULL, 0, 0, NULL, 1, 0, N'zoruark06@gmail.com')
SET IDENTITY_INSERT [dbo].[CAFETERIA] ON 

INSERT [dbo].[CAFETERIA] ([ID], [NOMBRE], [DESCRIPCION], [ENCARGADO], [IDCAMPUS], [ESTADO]) VALUES (34, N'CAFETERIA GREENPOINT', N'CAFETERIA DE UNAPEC', N'CARLOS TORRES', 15, N'ACTIVO         ')
INSERT [dbo].[CAFETERIA] ([ID], [NOMBRE], [DESCRIPCION], [ENCARGADO], [IDCAMPUS], [ESTADO]) VALUES (35, N'CELINES', N'CELINES CAFETERIA', N'CELINES TORRES', 17, N'ACTIVO         ')
INSERT [dbo].[CAFETERIA] ([ID], [NOMBRE], [DESCRIPCION], [ENCARGADO], [IDCAMPUS], [ESTADO]) VALUES (36, N'MANON', N'CAFETERIA DE UNAPEC', N'LUIS RAFAEL GERALDO', 15, N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[CAFETERIA] OFF
SET IDENTITY_INSERT [dbo].[CAMPUS] ON 

INSERT [dbo].[CAMPUS] ([ID], [NOMBRE], [DESCRIPCION], [ESTADO]) VALUES (15, N'FERNANDO ARTURO', N'CAMPUS DE LA GOMEZ', N'ACTIVO         ')
INSERT [dbo].[CAMPUS] ([ID], [NOMBRE], [DESCRIPCION], [ESTADO]) VALUES (17, N'CAFAM', N'CAMPUS DE INGENIERIA', N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[CAMPUS] OFF
SET IDENTITY_INSERT [dbo].[detallefactura] ON 

INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (75, 51, NULL, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (76, 51, NULL, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (77, 48, NULL, 300)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (78, 50, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (79, 50, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (80, 48, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (81, 51, NULL, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (82, 51, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (83, 51, NULL, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (84, 51, NULL, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (85, 50, NULL, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (86, 51, NULL, 3)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (87, 51, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (88, 48, NULL, 99)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (89, 48, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (90, 48, NULL, 20)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (91, 48, NULL, 100)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (92, 48, NULL, 333)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (93, 48, NULL, 46)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (94, 48, NULL, 4)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (95, 48, NULL, 6)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (96, 48, NULL, 3)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (97, 48, NULL, 7)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (98, 48, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (99, 48, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (100, 48, NULL, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (101, 48, NULL, 1)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (102, 48, NULL, 8)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (103, 48, NULL, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (104, 48, 15, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (105, 50, 15, 4)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (106, 51, 15, 4)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (107, 51, 16, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (108, 48, NULL, 2)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (109, 50, NULL, 4)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (110, 48, NULL, 3)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (111, 48, NULL, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (112, 51, 17, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (113, 48, 17, 5)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (114, 48, 17, 3)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (115, 48, 18, 3)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (116, 48, 18, 7)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (117, 48, NULL, 3)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (118, 48, NULL, 19)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (119, 48, 21, 90)
INSERT [dbo].[detallefactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (120, 52, 21, 5)
SET IDENTITY_INSERT [dbo].[detallefactura] OFF
SET IDENTITY_INSERT [dbo].[EMPLEADO] ON 

INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [ESTADO]) VALUES (17, 1, N'Jose Garrido', N'99', CAST(4 AS Decimal(18, 0)), CAST(N'2018-07-27' AS Date), N'1              ')
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [ESTADO]) VALUES (19, 2, N'Carlos Torres', N'12345', CAST(54 AS Decimal(18, 0)), CAST(N'2018-07-27' AS Date), N'ACTIVO         ')
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [ESTADO]) VALUES (26, 2, N'Luis Rafael Geraldo', N'1000000', CAST(54 AS Decimal(18, 0)), NULL, N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[EMPLEADO] OFF
SET IDENTITY_INSERT [dbo].[factura] ON 

INSERT [dbo].[factura] ([idFactura], [fecha], [modoPago], [idUsuario], [idEmpleado], [montoTotal], [idCafeteria]) VALUES (15, N'5/8/2018 12:00:00 a. m.', N'AL CONTADO', 8, 17, CAST(4180.00 AS Decimal(16, 2)), 35)
INSERT [dbo].[factura] ([idFactura], [fecha], [modoPago], [idUsuario], [idEmpleado], [montoTotal], [idCafeteria]) VALUES (16, N'5/8/2018 12:00:00 a. m.', N'AL CONTADO', 8, 17, CAST(3950.00 AS Decimal(16, 2)), 36)
INSERT [dbo].[factura] ([idFactura], [fecha], [modoPago], [idUsuario], [idEmpleado], [montoTotal], [idCafeteria]) VALUES (17, N'7/8/2018 12:00:00 a. m.', N'AL CONTADO', 8, 19, CAST(3300.00 AS Decimal(16, 2)), 34)
INSERT [dbo].[factura] ([idFactura], [fecha], [modoPago], [idUsuario], [idEmpleado], [montoTotal], [idCafeteria]) VALUES (18, N'7/8/2018 12:00:00 a. m.', N'AL CONTADO', 8, 19, CAST(3225.00 AS Decimal(16, 2)), 34)
INSERT [dbo].[factura] ([idFactura], [fecha], [modoPago], [idUsuario], [idEmpleado], [montoTotal], [idCafeteria]) VALUES (20, N'7/8/2018 12:00:00 a. m.', N'AL CONTADO', 8, 17, CAST(2400.00 AS Decimal(16, 2)), 34)
INSERT [dbo].[factura] ([idFactura], [fecha], [modoPago], [idUsuario], [idEmpleado], [montoTotal], [idCafeteria]) VALUES (21, N'7/8/2018 12:00:00 a. m.', N'AL CONTADO', 8, 17, CAST(2430.00 AS Decimal(16, 2)), 34)
SET IDENTITY_INSERT [dbo].[factura] OFF
SET IDENTITY_INSERT [dbo].[LOGIN_USERS] ON 

INSERT [dbo].[LOGIN_USERS] ([ID], [USUARIO], [CONTRASEÑA], [TIPO_DE_USUARIO], [idUsuario]) VALUES (1, N'admin', N'12345', N'admin', 1)
INSERT [dbo].[LOGIN_USERS] ([ID], [USUARIO], [CONTRASEÑA], [TIPO_DE_USUARIO], [idUsuario]) VALUES (2, N'luis', N'luis', N'usuario', 17)
INSERT [dbo].[LOGIN_USERS] ([ID], [USUARIO], [CONTRASEÑA], [TIPO_DE_USUARIO], [idUsuario]) VALUES (3, N'carlos', N'123321', N'admin', 19)
INSERT [dbo].[LOGIN_USERS] ([ID], [USUARIO], [CONTRASEÑA], [TIPO_DE_USUARIO], [idUsuario]) VALUES (4, N'LuisRafael', N'12345', N'admin', 26)
SET IDENTITY_INSERT [dbo].[LOGIN_USERS] OFF
SET IDENTITY_INSERT [dbo].[MARCA] ON 

INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [ESTADO]) VALUES (9, N'PEPSI', N'MARCA DE REFREZCO', N'ACTIVO         ')
INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [ESTADO]) VALUES (10, N'COLGATE', N'MARCA DE PASTA DENTAL', N'ACTIVO         ')
INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [ESTADO]) VALUES (20, N'COCA COLA', N'MARCA DE REFRESCOS', N'ACTIVO         ')
INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [ESTADO]) VALUES (21, N'Frito Lays', N'Empresa de papitas', N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[MARCA] OFF
SET IDENTITY_INSERT [dbo].[TANDALABOR] ON 

INSERT [dbo].[TANDALABOR] ([ID], [TANDA]) VALUES (1, N'MATUTINA')
INSERT [dbo].[TANDALABOR] ([ID], [TANDA]) VALUES (2, N'VESPERTINA')
INSERT [dbo].[TANDALABOR] ([ID], [TANDA]) VALUES (3, N'NOCTURNA')
INSERT [dbo].[TANDALABOR] ([ID], [TANDA]) VALUES (4, N'MIXTA')
SET IDENTITY_INSERT [dbo].[TANDALABOR] OFF
SET IDENTITY_INSERT [dbo].[TIPOUSUARIO] ON 

INSERT [dbo].[TIPOUSUARIO] ([ID], [DESCRIPCION], [ESTADO]) VALUES (1, N'ESTUDIANTE', N'ACTIVO         ')
INSERT [dbo].[TIPOUSUARIO] ([ID], [DESCRIPCION], [ESTADO]) VALUES (2, N'DOCENTE', N'ACTIVO         ')
INSERT [dbo].[TIPOUSUARIO] ([ID], [DESCRIPCION], [ESTADO]) VALUES (3, N'ADMINISTRADOR', N'ACTIVO         ')
INSERT [dbo].[TIPOUSUARIO] ([ID], [DESCRIPCION], [ESTADO]) VALUES (6, N'GENERICO
', N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[TIPOUSUARIO] OFF
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [ESTADO]) VALUES (8, N'Al CONTADO', N'00000000000', 6, NULL, NULL, N'ACTIVO         ')
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 26/09/2018 21:01:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 26/09/2018 21:01:43 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 26/09/2018 21:01:43 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 26/09/2018 21:01:43 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 26/09/2018 21:01:43 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 26/09/2018 21:01:43 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[factura] ADD  CONSTRAINT [DF_factura_montoTotal]  DEFAULT ((0)) FOR [montoTotal]
GO
ALTER TABLE [dbo].[ARTICULO]  WITH CHECK ADD  CONSTRAINT [FK_MARCA] FOREIGN KEY([IDMARCA])
REFERENCES [dbo].[MARCA] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ARTICULO] CHECK CONSTRAINT [FK_MARCA]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CAFETERIA]  WITH CHECK ADD  CONSTRAINT [FK_CAMPUS] FOREIGN KEY([IDCAMPUS])
REFERENCES [dbo].[CAMPUS] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CAFETERIA] CHECK CONSTRAINT [FK_CAMPUS]
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_CAFETERIAC] FOREIGN KEY([IDCAFETERIA])
REFERENCES [dbo].[CAFETERIA] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO] CHECK CONSTRAINT [FK_CAFETERIAC]
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADOC] FOREIGN KEY([IDEMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO] CHECK CONSTRAINT [FK_EMPLEADOC]
GO
ALTER TABLE [dbo].[CAFETERIARTICULO]  WITH CHECK ADD  CONSTRAINT [FK_ARTICULOC] FOREIGN KEY([IDARTICULO])
REFERENCES [dbo].[ARTICULO] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CAFETERIARTICULO] CHECK CONSTRAINT [FK_ARTICULOC]
GO
ALTER TABLE [dbo].[CAFETERIARTICULO]  WITH CHECK ADD  CONSTRAINT [FK_CAFETERIAC1] FOREIGN KEY([IDCAFETERIA])
REFERENCES [dbo].[CAFETERIA] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CAFETERIARTICULO] CHECK CONSTRAINT [FK_CAFETERIAC1]
GO
ALTER TABLE [dbo].[detallefactura]  WITH CHECK ADD  CONSTRAINT [fk_Articulo] FOREIGN KEY([idArticulo])
REFERENCES [dbo].[ARTICULO] ([ID])
GO
ALTER TABLE [dbo].[detallefactura] CHECK CONSTRAINT [fk_Articulo]
GO
ALTER TABLE [dbo].[detallefactura]  WITH CHECK ADD  CONSTRAINT [fk_factura] FOREIGN KEY([idFactura])
REFERENCES [dbo].[factura] ([idFactura])
GO
ALTER TABLE [dbo].[detallefactura] CHECK CONSTRAINT [fk_factura]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_TANDALABOR] FOREIGN KEY([IDTANDALABOR])
REFERENCES [dbo].[TANDALABOR] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_TANDALABOR]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [fk_cliente] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [fk_cliente]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [fk_empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[EMPLEADO] ([ID])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [fk_empleado]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_CAFETERIA] FOREIGN KEY([idCafeteria])
REFERENCES [dbo].[CAFETERIA] ([ID])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_factura_CAFETERIA]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [Fk_ArticuloF] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[ARTICULO] ([ID])
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [Fk_ArticuloF]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [Fk_EmpleadoF] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[EMPLEADO] ([ID])
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [Fk_EmpleadoF]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [Fk_UsuarioF] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [Fk_UsuarioF]
GO
ALTER TABLE [dbo].[LOGIN_USERS]  WITH CHECK ADD  CONSTRAINT [FK_LOGIN_USERS_LOGIN_USERS] FOREIGN KEY([ID])
REFERENCES [dbo].[LOGIN_USERS] ([ID])
GO
ALTER TABLE [dbo].[LOGIN_USERS] CHECK CONSTRAINT [FK_LOGIN_USERS_LOGIN_USERS]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_TIPOUSUARIO] FOREIGN KEY([IDTIPOUSUARIO])
REFERENCES [dbo].[TIPOUSUARIO] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_TIPOUSUARIO]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [CK_FACTURACION_ARTICULOS] CHECK  (([Unidades]>=(0)))
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [CK_FACTURACION_ARTICULOS]
GO
ALTER TABLE [dbo].[TANDALABOR]  WITH CHECK ADD  CONSTRAINT [CK__TANDALABO__TANDA__5DCAEF64] CHECK  (([TANDA]='MATUTINA' OR [TANDA]='VESPERTINA' OR [TANDA]='NOCTURNA' OR [TANDA]='MIXTA'))
GO
ALTER TABLE [dbo].[TANDALABOR] CHECK CONSTRAINT [CK__TANDALABO__TANDA__5DCAEF64]
GO
ALTER TABLE [dbo].[TANDALABOR]  WITH CHECK ADD  CONSTRAINT [CK__TANDALABO__TANDA__73BA3083] CHECK  (([TANDA]='MATUTINA' OR [TANDA]='VESPERTINA' OR [TANDA]='NOCTURNA' OR [TANDA]='MIXTA'))
GO
ALTER TABLE [dbo].[TANDALABOR] CHECK CONSTRAINT [CK__TANDALABO__TANDA__73BA3083]
GO
/****** Object:  Trigger [dbo].[ACTUALIZAR_MONTO]    Script Date: 26/09/2018 21:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ACTUALIZAR_MONTO]
     ON [dbo].[detallefactura]
     FOR INSERT
     AS
	 DECLARE @MONTO_ARTICULO_NUEVO DECIMAL
	 DECLARE @IDFACTURA INT
     
	 SELECT @MONTO_ARTICULO_NUEVO = COSTO, @IDFACTURA = idFactura FROM INSERTED INNER JOIN ARTICULO ON inserted.idArticulo = ARTICULO.ID
		
	UPDATE FACTURA SET montoTotal = montoTotal + @MONTO_ARTICULO_NUEVO 
		WHERE factura.idFactura = @IDFACTURA
 

GO
/****** Object:  Trigger [dbo].[CalcularMonto]    Script Date: 26/09/2018 21:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[CalcularMonto]
on [dbo].[detallefactura]
for insert 
as
declare @costo_articulo decimal;
declare @unidades int;
select @costo_articulo = (select COSTO from ARTICULO 
inner join INSERTED on ARTICULO.ID = inserted.IDARTICULO);
UPDATE factura
		SET montoTotal = montoTotal + (@costo_articulo * inserted.Unidades) from inserted inner join 
		ARTICULO on inserted.IDARTICULO = ARTICULO.ID where ARTICULO.ID = inserted.IdArticulo;

GO
/****** Object:  Trigger [dbo].[RestarArticulo2]    Script Date: 26/09/2018 21:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RestarArticulo2]
     ON [dbo].[detallefactura]
     AFTER INSERT
     AS
     DECLARE @UNIDADES int;
     
	 SELECT @UNIDADES = (SELECT EXISTENCIA FROM ARTICULO inner join INSERTED on ARTICULO.ID = inserted.IDARTICULO)
     IF (@UNIDADES = 0)
	    ROLLBACK;
	
     ELSE
		
		UPDATE ARTICULO
		SET EXISTENCIA = (ARTICULO.EXISTENCIA - inserted.Unidades) from inserted inner join 
		ARTICULO on inserted.IDARTICULO = ARTICULO.ID where ARTICULO.ID = inserted.IdArticulo;

GO
/****** Object:  Trigger [dbo].[RestarArticulo]    Script Date: 26/09/2018 21:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RestarArticulo]
     ON [dbo].[FACTURACION_ARTICULOS]
     AFTER INSERT
     AS
     DECLARE @UNIDADES int;
     
	 SELECT @UNIDADES = (SELECT EXISTENCIA FROM ARTICULO inner join INSERTED on ARTICULO.ID = inserted.IDARTICULO)
     IF (@UNIDADES = 0)
	    ROLLBACK;
     ELSE
		
		UPDATE ARTICULO
		SET EXISTENCIA = (ARTICULO.EXISTENCIA - inserted.Unidades) from inserted inner join 
		ARTICULO on inserted.IDARTICULO = ARTICULO.ID where ARTICULO.ID = inserted.IdArticulo;

GO
USE [master]
GO
ALTER DATABASE [CAFETERIAUNAPEC] SET  READ_WRITE 
GO
