USE [master]
GO
/****** Object:  Database [CafeteriaUnapec]    Script Date: 27/11/2018 3:08:00 ******/
CREATE DATABASE [CafeteriaUnapec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CafeteriaUnapec', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CafeteriaUnapec.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CafeteriaUnapec_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CafeteriaUnapec_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CafeteriaUnapec] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CafeteriaUnapec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CafeteriaUnapec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET ARITHABORT OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CafeteriaUnapec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CafeteriaUnapec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CafeteriaUnapec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CafeteriaUnapec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CafeteriaUnapec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CafeteriaUnapec] SET  MULTI_USER 
GO
ALTER DATABASE [CafeteriaUnapec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CafeteriaUnapec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CafeteriaUnapec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CafeteriaUnapec] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CafeteriaUnapec] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CafeteriaUnapec]
GO
/****** Object:  UserDefinedFunction [dbo].[calcularTotal]    Script Date: 27/11/2018 3:08:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[calcularTotal](@producto varchar(30)) returns int
	
  begin
	
	declare @total int;

	set @total = (select SUM(unidades) from DetalleFactura 
	inner join Articulos on Articulos.ID = DetalleFactura.idArticulo 
	where descripcion = @producto);
	
	return @total;
  
  end;
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 27/11/2018 3:08:02 ******/
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
/****** Object:  Table [dbo].[Articulos]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[IDMARCA] [int] NULL,
	[IDPROVEEDOR] [int] NULL,
	[COSTO] [decimal](18, 0) NOT NULL,
	[EXISTENCIA] [int] NOT NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27/11/2018 3:08:03 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27/11/2018 3:08:03 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27/11/2018 3:08:03 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27/11/2018 3:08:03 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27/11/2018 3:08:03 ******/
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
/****** Object:  Table [dbo].[CAFETERIA]    Script Date: 27/11/2018 3:08:03 ******/
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
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAFETERIAEMPLEADO]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAFETERIAEMPLEADO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEMPLEADO] [int] NULL,
	[IDCAFETERIA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAFETERIARTICULO]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAFETERIARTICULO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDARTICULO] [int] NULL,
	[IDCAFETERIA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAMPUS]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAMPUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[idDetalleFactura] [int] IDENTITY(1,1) NOT NULL,
	[idArticulo] [int] NULL,
	[idFactura] [int] NULL,
	[unidades] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 27/11/2018 3:08:03 ******/
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
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESTADO]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ESTADO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [varchar](30) NOT NULL,
	[modoPago] [varchar](30) NULL,
	[montoTotal] [decimal](16, 2) NULL,
	[idUsuario] [int] NULL,
	[idEmpleado] [int] NULL,
	[idCafeteria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FACTURACION_ARTICULOS]    Script Date: 27/11/2018 3:08:03 ******/
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
PRIMARY KEY CLUSTERED 
(
	[NoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[RNC] [varchar](50) NULL,
	[FECHAREGISTRO] [date] NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TANDALABOR]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TANDALABOR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TANDA] [nvarchar](30) NOT NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPOUSUARIO]    Script Date: 27/11/2018 3:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOUSUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [nvarchar](50) NOT NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 27/11/2018 3:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](30) NOT NULL,
	[CEDULA] [nvarchar](11) NOT NULL,
	[IDTIPOUSUARIO] [int] NULL,
	[LIMITECREDITO] [numeric](9, 2) NULL,
	[FECHAREGISTRO] [date] NULL,
	[Estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[DetalleFactura_View]    Script Date: 27/11/2018 3:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DetalleFactura_View]
AS
SELECT UNIDADES, Factura.ID, Articulos.DESCRIPCION, COSTO FROM detallefactura 
INNER JOIN ARTICULOS ON Articulos.ID = detallefactura.idArticulo
INNER JOIN Factura ON Factura.ID = detallefactura.idFactura;

GO
/****** Object:  View [dbo].[Historial Unidades Vendidas por Producto]    Script Date: 27/11/2018 3:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE VIEW [dbo].[Historial Unidades Vendidas por Producto] AS
  SELECT SUM(D.unidades) AS Total, A.DESCRIPCION
  FROM DetalleFactura D
  INNER JOIN Factura F ON D.idFactura = F.ID
  INNER JOIN Articulos A ON D.idArticulo = A.ID
  GROUP BY A.DESCRIPCION;
GO
/****** Object:  View [dbo].[MontoTotal]    Script Date: 27/11/2018 3:08:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MontoTotal]
AS
SELECT id, MONTOTOTAL FROM Factura;

GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [Estado]) VALUES (1, N'Sazon Super Completo', 3, 12, CAST(50 AS Decimal(18, 0)), 110, 5)
INSERT [dbo].[Articulos] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [Estado]) VALUES (2, N'Sopitas', 4, 12, CAST(25 AS Decimal(18, 0)), 61, 5)
INSERT [dbo].[Articulos] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [Estado]) VALUES (3, N'Mayonesa', 3, 12, CAST(80 AS Decimal(18, 0)), -1, 5)
INSERT [dbo].[Articulos] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [Estado]) VALUES (4, N'COCA COLA ', 5, 12, CAST(25 AS Decimal(18, 0)), 100, 5)
INSERT [dbo].[Articulos] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [Estado]) VALUES (5, N'MAMMUT', 3, 12, CAST(10 AS Decimal(18, 0)), 42, 5)
INSERT [dbo].[Articulos] ([ID], [DESCRIPCION], [IDMARCA], [IDPROVEEDOR], [COSTO], [EXISTENCIA], [Estado]) VALUES (6, N'Luis', 4, 12, CAST(2000 AS Decimal(18, 0)), 1, 5)
SET IDENTITY_INSERT [dbo].[Articulos] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'AAPWgGITGZLuQgvvJjqzmXBJX/kMJHWTNxu1QZOwJF5XvpQL3oJAuMQYZZsMG2JYpw==', N'Consulta')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'18e000ca-0c43-4244-aad4-bf10ec8c829d', N'ing.valen0421@hotmail.com', 0, N'AC/Bhnazf1ggW6vxCsgWPdycDWmtp1X3PfsNOnxO4VVO+PGVFDmj/A6sQU2QAE9DWw==', N'a202c06c-0ceb-4473-98ff-2120caae2b10', NULL, 0, 0, NULL, 1, 0, N'ing.valen0421@hotmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c9355557-f9c5-4d75-bc3a-4f57e72c9fa6', N'carlostorresapec@hotmail.com', 0, N'AAPWgGITGZLuQgvvJjqzmXBJX/kMJHWTNxu1QZOwJF5XvpQL3oJAuMQYZZsMG2JYpw==', N'121553ea-3070-4163-b436-3f753a32add4', NULL, 0, 0, NULL, 1, 0, N'carlostorresapec@hotmail.com')
SET IDENTITY_INSERT [dbo].[CAFETERIA] ON 

INSERT [dbo].[CAFETERIA] ([ID], [NOMBRE], [DESCRIPCION], [ENCARGADO], [IDCAMPUS], [Estado]) VALUES (2, N'Green Point', N'Ecology', N'Luis Rafael ', 1, 5)
SET IDENTITY_INSERT [dbo].[CAFETERIA] OFF
SET IDENTITY_INSERT [dbo].[CAMPUS] ON 

INSERT [dbo].[CAMPUS] ([ID], [NOMBRE], [DESCRIPCION], [Estado]) VALUES (1, N'UNAPEC 1', N'Fernando Arturo de Meriño', NULL)
INSERT [dbo].[CAMPUS] ([ID], [NOMBRE], [DESCRIPCION], [Estado]) VALUES (2, N'Unapec #2', N'CAFAM', 5)
SET IDENTITY_INSERT [dbo].[CAMPUS] OFF
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 

INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (8, 1, 7, 20)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (9, 2, 7, 20)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (10, 3, 7, 5)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (11, 5, 8, 8)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (12, 4, 8, 50)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (13, 6, 8, 1)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (14, 2, 9, 10)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (15, 1, 9, 10)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (16, 1, 9, 20)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (17, 1, 9, 30)
INSERT [dbo].[DetalleFactura] ([idDetalleFactura], [idArticulo], [idFactura], [unidades]) VALUES (18, 2, 10, 1)
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
SET IDENTITY_INSERT [dbo].[EMPLEADO] ON 

INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (4, 7, N'CarlosTorres', N'40215563657', CAST(2 AS Decimal(18, 0)), CAST(N'2018-11-01' AS Date), 5)
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (5, 6, N'Eduardo Emmanuel', N'40215563657', CAST(45 AS Decimal(18, 0)), CAST(N'2018-11-13' AS Date), 6)
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (6, 4, N'yocasta Romero', N'40215563657', CAST(65 AS Decimal(18, 0)), CAST(N'2018-11-13' AS Date), 5)
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (7, 4, N'djfnfsdjSDJDVCN', N'40215563657', CAST(4 AS Decimal(18, 0)), CAST(N'2018-11-22' AS Date), 5)
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (8, 4, N'Josue Romero', N'40215563657', CAST(25 AS Decimal(18, 0)), CAST(N'2018-11-23' AS Date), 5)
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (9, 4, N'Ramon Valenzuela', N'40215563657', CAST(578 AS Decimal(18, 0)), CAST(N'2018-11-13' AS Date), 5)
INSERT [dbo].[EMPLEADO] ([ID], [IDTANDALABOR], [NOMBRE], [CEDULA], [COMISION], [FECHAREGISTRO], [Estado]) VALUES (10, 6, N'Carlos Torres Petit', N'40215563657', CAST(5 AS Decimal(18, 0)), CAST(N'2018-11-20' AS Date), 5)
SET IDENTITY_INSERT [dbo].[EMPLEADO] OFF
SET IDENTITY_INSERT [dbo].[ESTADO] ON 

INSERT [dbo].[ESTADO] ([Id], [Estado]) VALUES (5, N'Activo')
INSERT [dbo].[ESTADO] ([Id], [Estado]) VALUES (6, N'Inactivo')
SET IDENTITY_INSERT [dbo].[ESTADO] OFF
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([ID], [fecha], [modoPago], [montoTotal], [idUsuario], [idEmpleado], [idCafeteria]) VALUES (7, N'2018-11-19', N'Credito', CAST(8505.00 AS Decimal(16, 2)), 5, 4, 2)
INSERT [dbo].[Factura] ([ID], [fecha], [modoPago], [montoTotal], [idUsuario], [idEmpleado], [idCafeteria]) VALUES (8, N'2018-11-20', N'Credito', CAST(6605.00 AS Decimal(16, 2)), 12, 5, 2)
INSERT [dbo].[Factura] ([ID], [fecha], [modoPago], [montoTotal], [idUsuario], [idEmpleado], [idCafeteria]) VALUES (9, N'2018-11-20', N'Contado', CAST(3275.00 AS Decimal(16, 2)), 5, 4, 2)
INSERT [dbo].[Factura] ([ID], [fecha], [modoPago], [montoTotal], [idUsuario], [idEmpleado], [idCafeteria]) VALUES (10, N'01/01/1999', N'Credito', CAST(25.00 AS Decimal(16, 2)), 5, 4, 2)
SET IDENTITY_INSERT [dbo].[Factura] OFF
SET IDENTITY_INSERT [dbo].[MARCA] ON 

INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [Estado]) VALUES (3, N'BALDOM', N'sazon ', 6)
INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [Estado]) VALUES (4, N'MAGGI', N'sopitas', 5)
INSERT [dbo].[MARCA] ([ID], [NOMBRE], [DESCRIPCION], [Estado]) VALUES (5, N'BESPENSA', N'DISTRIBUIDORES DE REFRESCOS', 5)
SET IDENTITY_INSERT [dbo].[MARCA] OFF
SET IDENTITY_INSERT [dbo].[PROVEEDOR] ON 

INSERT [dbo].[PROVEEDOR] ([ID], [NOMBRE], [RNC], [FECHAREGISTRO], [Estado]) VALUES (12, N'CESAR IGLESIAS', N'131346626', CAST(N'2018-05-01' AS Date), 5)
SET IDENTITY_INSERT [dbo].[PROVEEDOR] OFF
SET IDENTITY_INSERT [dbo].[TANDALABOR] ON 

INSERT [dbo].[TANDALABOR] ([ID], [TANDA], [Estado]) VALUES (4, N'Vespertina', 5)
INSERT [dbo].[TANDALABOR] ([ID], [TANDA], [Estado]) VALUES (5, N'Matutina', 5)
INSERT [dbo].[TANDALABOR] ([ID], [TANDA], [Estado]) VALUES (6, N'Nocturna', 5)
INSERT [dbo].[TANDALABOR] ([ID], [TANDA], [Estado]) VALUES (7, N'Mixta', 5)
SET IDENTITY_INSERT [dbo].[TANDALABOR] OFF
SET IDENTITY_INSERT [dbo].[TIPOUSUARIO] ON 

INSERT [dbo].[TIPOUSUARIO] ([ID], [DESCRIPCION], [Estado]) VALUES (3, N'Al Contado', 5)
INSERT [dbo].[TIPOUSUARIO] ([ID], [DESCRIPCION], [Estado]) VALUES (4, N'A Credito', 5)
SET IDENTITY_INSERT [dbo].[TIPOUSUARIO] OFF
SET IDENTITY_INSERT [dbo].[USUARIO] ON 

INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (5, N'Ivan Navarro', N'40215563657', 4, CAST(5000.00 AS Numeric(9, 2)), CAST(N'2018-12-05' AS Date), 6)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (6, N'Navarro', N'40237109513', 4, CAST(100000.00 AS Numeric(9, 2)), CAST(N'2018-01-05' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (7, N'Jose Angel', N'40215563657', 3, CAST(52.00 AS Numeric(9, 2)), CAST(N'2018-11-07' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (8, N'Juan Angel Vidal Encarnacion', N'40237109513', 4, CAST(3000.00 AS Numeric(9, 2)), CAST(N'2018-09-20' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (9, N'LALALLA YAYAYYAYA', N'40215563657', 3, CAST(57.00 AS Numeric(9, 2)), CAST(N'2018-11-03' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (10, N'lalalala sds', N'40215563657', 3, CAST(76.00 AS Numeric(9, 2)), CAST(N'2018-11-30' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (11, N'Ramonsito Leonardo', N'40215563657', 3, CAST(65.00 AS Numeric(9, 2)), CAST(N'2018-11-24' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (12, N'Jean Carlos Petit ', N'40236433625', 3, CAST(2000.00 AS Numeric(9, 2)), CAST(N'2018-11-07' AS Date), 5)
INSERT [dbo].[USUARIO] ([ID], [NOMBRE], [CEDULA], [IDTIPOUSUARIO], [LIMITECREDITO], [FECHAREGISTRO], [Estado]) VALUES (13, N'skfdnkjsdn', N'40215563657', 3, CAST(200.00 AS Numeric(9, 2)), CAST(N'2018-10-30' AS Date), 5)
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 27/11/2018 3:08:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/11/2018 3:08:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/11/2018 3:08:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 27/11/2018 3:08:05 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 27/11/2018 3:08:05 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 27/11/2018 3:08:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Marca] FOREIGN KEY([IDMARCA])
REFERENCES [dbo].[MARCA] ([ID])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_Articulo_Marca]
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Proveedor] FOREIGN KEY([IDPROVEEDOR])
REFERENCES [dbo].[PROVEEDOR] ([ID])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_Articulo_Proveedor]
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
ALTER TABLE [dbo].[CAFETERIA]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[CAFETERIA]  WITH CHECK ADD  CONSTRAINT [FK_Campus] FOREIGN KEY([IDCAMPUS])
REFERENCES [dbo].[CAMPUS] ([ID])
GO
ALTER TABLE [dbo].[CAFETERIA] CHECK CONSTRAINT [FK_Campus]
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_cafeteria_empleado1] FOREIGN KEY([IDEMPLEADO])
REFERENCES [dbo].[EMPLEADO] ([ID])
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO] CHECK CONSTRAINT [FK_cafeteria_empleado1]
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_cafeteria_empleado2] FOREIGN KEY([IDCAFETERIA])
REFERENCES [dbo].[CAFETERIA] ([ID])
GO
ALTER TABLE [dbo].[CAFETERIAEMPLEADO] CHECK CONSTRAINT [FK_cafeteria_empleado2]
GO
ALTER TABLE [dbo].[CAFETERIARTICULO]  WITH CHECK ADD  CONSTRAINT [FK_cafeteria_articulo1] FOREIGN KEY([IDARTICULO])
REFERENCES [dbo].[Articulos] ([ID])
GO
ALTER TABLE [dbo].[CAFETERIARTICULO] CHECK CONSTRAINT [FK_cafeteria_articulo1]
GO
ALTER TABLE [dbo].[CAFETERIARTICULO]  WITH CHECK ADD  CONSTRAINT [FK_cafeteria_articulo2] FOREIGN KEY([IDCAFETERIA])
REFERENCES [dbo].[CAFETERIA] ([ID])
GO
ALTER TABLE [dbo].[CAFETERIARTICULO] CHECK CONSTRAINT [FK_cafeteria_articulo2]
GO
ALTER TABLE [dbo].[CAMPUS]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_articulo] FOREIGN KEY([idArticulo])
REFERENCES [dbo].[Articulos] ([ID])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_detalle_articulo]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_detalle_factura] FOREIGN KEY([idFactura])
REFERENCES [dbo].[Factura] ([ID])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_detalle_factura]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_TandaLabor] FOREIGN KEY([IDTANDALABOR])
REFERENCES [dbo].[TANDALABOR] ([ID])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_TandaLabor]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cafeteria] FOREIGN KEY([idCafeteria])
REFERENCES [dbo].[CAFETERIA] ([ID])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Usuario_Cafeteria]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[EMPLEADO] ([ID])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Usuario_Empleado]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Factura] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Usuario_Factura]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_articulo] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulos] ([ID])
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [FK_facturacion_articulo]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_empleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[EMPLEADO] ([ID])
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [FK_facturacion_empleado]
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([ID])
GO
ALTER TABLE [dbo].[FACTURACION_ARTICULOS] CHECK CONSTRAINT [FK_facturacion_usuario]
GO
ALTER TABLE [dbo].[MARCA]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[PROVEEDOR]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[TANDALABOR]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[TIPOUSUARIO]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[ESTADO] ([Id])
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Usuario] FOREIGN KEY([IDTIPOUSUARIO])
REFERENCES [dbo].[TIPOUSUARIO] ([ID])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_Tipo_Usuario]
GO
/****** Object:  Trigger [dbo].[ACTUALIZAR_MONTO]    Script Date: 27/11/2018 3:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ACTUALIZAR_MONTO]
     ON [dbo].[DetalleFactura]
     FOR INSERT
     AS

	 DECLARE @MONTO_ARTICULO_NUEVO DECIMAL
	 DECLARE @IDFACTURA INT
     
	 SELECT @MONTO_ARTICULO_NUEVO = COSTO, @IDFACTURA = ID FROM INSERTED INNER JOIN Articulos ON inserted.idArticulo = ARTICULOS.ID
		
	UPDATE FACTURA SET montoTotal = montoTotal + @MONTO_ARTICULO_NUEVO 
		WHERE Factura.ID = @IDFACTURA
 

GO
/****** Object:  Trigger [dbo].[CalcularMonto]    Script Date: 27/11/2018 3:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[CalcularMonto]
on [dbo].[DetalleFactura]
for insert 
as

declare @costo_articulo decimal;
declare @unidades int;

select @costo_articulo = (select COSTO from ARTICULOS
inner join INSERTED on ARTICULOS.ID = inserted.IDARTICULO);

UPDATE factura
		SET montoTotal = montoTotal + (@costo_articulo * inserted.Unidades) from inserted inner join 
		Articulos on inserted.IDARTICULO = ARTICULOS.ID where ARTICULOS.ID = inserted.IdArticulo;

GO
/****** Object:  Trigger [dbo].[RestarArticulo2]    Script Date: 27/11/2018 3:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RestarArticulo2]
     ON [dbo].[DetalleFactura]
     AFTER INSERT
     AS

     DECLARE @UNIDADES int;
     
	 SELECT @UNIDADES = (SELECT EXISTENCIA FROM ARTICULOS inner join INSERTED on ARTICULOS.ID = inserted.IDARTICULO)

     IF (@UNIDADES = 0)


	    ROLLBACK;
	
     ELSE
		
		UPDATE ARTICULOS
		SET EXISTENCIA = (ARTICULOS.EXISTENCIA - inserted.Unidades) from inserted inner join 
		ARTICULOS on inserted.IDARTICULO = ARTICULOS.ID where ARTICULOS.ID = inserted.IdArticulo;

GO
/****** Object:  Trigger [dbo].[RestarArticulo]    Script Date: 27/11/2018 3:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RestarArticulo]
     ON [dbo].[FACTURACION_ARTICULOS]
     AFTER INSERT
     AS

     DECLARE @UNIDADES int;
     
	 SELECT @UNIDADES = (SELECT EXISTENCIA FROM ARTICULOS inner join INSERTED on ARTICULOS.ID = inserted.IDARTICULO)

     IF (@UNIDADES = 0)

	    ROLLBACK;

     ELSE
		
		UPDATE ARTICULO
		SET EXISTENCIA = (ARTICULOS.EXISTENCIA - inserted.Unidades) from inserted inner join 
		ARTICULOS on inserted.IDARTICULO = ARTICULOS.ID where ARTICULOS.ID = inserted.IdArticulo;

GO
USE [master]
GO
ALTER DATABASE [CafeteriaUnapec] SET  READ_WRITE 
GO
