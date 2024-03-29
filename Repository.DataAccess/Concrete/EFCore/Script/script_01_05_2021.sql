USE [master]
GO
/****** Object:  Database [Mimar-Soft-Database-06ST8W-TT41]    Script Date: 1.05.2021 14:23:07 ******/
CREATE DATABASE [Mimar-Soft-Database-06ST8W-TT41]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mimar-Soft-Database-06ST8W-TT41', FILENAME = N'C:\Users\AKR3P\Mimar-Soft-Database-06ST8W-TT41.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mimar-Soft-Database-06ST8W-TT41_log', FILENAME = N'C:\Users\AKR3P\Mimar-Soft-Database-06ST8W-TT41_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mimar-Soft-Database-06ST8W-TT41].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET  MULTI_USER 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET QUERY_STORE = OFF
GO
USE [Mimar-Soft-Database-06ST8W-TT41]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Mimar-Soft-Database-06ST8W-TT41]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1.05.2021 14:23:07 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRole]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRole](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MobileNumber] [varchar](10) NULL,
	[IsMobileNumberConfirmed] [bit] NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[AccountCreated] [datetime] NULL,
	[LastLogin] [datetime] NULL,
	[Status] [bit] NULL,
	[IsBlocked] [bit] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[ParentId] [smallint] NULL,
	[Name] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DealerPersonels]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DealerPersonels](
	[AspNetUserId] [nvarchar](450) NOT NULL,
	[Date_Register] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DealerId] [int] NOT NULL,
	[Phone_Mobile] [varchar](10) NULL,
 CONSTRAINT [PK_DealerPersonels] PRIMARY KEY CLUSTERED 
(
	[AspNetUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealers]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUserId] [nvarchar](450) NOT NULL,
	[Title] [varchar](128) NULL,
	[Phone_Mobile] [varchar](10) NULL,
	[WebURL] [varchar](256) NULL,
	[Email] [varchar](64) NULL,
	[Address] [varchar](256) NULL,
	[City] [varchar](32) NULL,
	[Status] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Dealers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealers_To_Producers]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealers_To_Producers](
	[ProducerId] [smallint] NOT NULL,
	[DealerId] [int] NOT NULL,
 CONSTRAINT [PK_Dealers_To_Producers] PRIMARY KEY CLUSTERED 
(
	[ProducerId] ASC,
	[DealerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(-2147483648,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductPartId] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Size] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProducerId] [smallint] NOT NULL,
	[DealerId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProducerPersonels]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProducerPersonels](
	[AspNetUserId] [nvarchar](450) NOT NULL,
	[ProducerId] [smallint] NOT NULL,
	[Date_Register] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Phone_Mobile] [varchar](10) NULL,
 CONSTRAINT [PK_ProducerPersonels] PRIMARY KEY CLUSTERED 
(
	[AspNetUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[AspNetUserId] [nvarchar](450) NOT NULL,
	[Title] [varchar](128) NULL,
	[Phone_Mobile] [varchar](10) NULL,
	[WebURL] [varchar](256) NULL,
	[Email] [varchar](64) NULL,
	[Address] [varchar](256) NULL,
	[City] [varchar](32) NULL,
	[Status] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Producers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductParts]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductParts](
	[Id] [int] IDENTITY(-2147483648,1) NOT NULL,
	[CategoryId] [smallint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Name] [varchar](128) NOT NULL,
 CONSTRAINT [PK_ProductParts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductParts_To_Producers]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductParts_To_Producers](
	[ProducerId] [smallint] NOT NULL,
	[ProductPartId] [int] NOT NULL,
 CONSTRAINT [PK_Products_To_Producers] PRIMARY KEY CLUSTERED 
(
	[ProducerId] ASC,
	[ProductPartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [tinyint] NOT NULL,
	[DealerId] [int] NOT NULL,
	[Name] [varchar](128) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 1.05.2021 14:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](64) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1.05.2021 14:23:07 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1.05.2021 14:23:07 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1.05.2021 14:23:07 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1.05.2021 14:23:07 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRole_RoleId]    Script Date: 1.05.2021 14:23:07 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRole_RoleId] ON [dbo].[AspNetUserRole]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1.05.2021 14:23:07 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1.05.2021 14:23:07 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Dealers] ADD  CONSTRAINT [DF_Dealers_IsDeleted]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Producers] ADD  CONSTRAINT [DF_Producers_IsDeleted]  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRole]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRole_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRole] CHECK CONSTRAINT [FK_AspNetUserRole_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRole]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRole_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRole] CHECK CONSTRAINT [FK_AspNetUserRole_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[DealerPersonels]  WITH CHECK ADD  CONSTRAINT [FK_DealerPersonels_AspNetUsers] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[DealerPersonels] CHECK CONSTRAINT [FK_DealerPersonels_AspNetUsers]
GO
ALTER TABLE [dbo].[DealerPersonels]  WITH CHECK ADD  CONSTRAINT [FK_DealerPersonels_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[DealerPersonels] CHECK CONSTRAINT [FK_DealerPersonels_Dealers]
GO
ALTER TABLE [dbo].[Dealers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_AspNetUsers] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Dealers] CHECK CONSTRAINT [FK_Dealers_AspNetUsers]
GO
ALTER TABLE [dbo].[Dealers_To_Producers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_To_Producers_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[Dealers_To_Producers] CHECK CONSTRAINT [FK_Dealers_To_Producers_Dealers]
GO
ALTER TABLE [dbo].[Dealers_To_Producers]  WITH CHECK ADD  CONSTRAINT [FK_Dealers_To_Producers_Producers] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
ALTER TABLE [dbo].[Dealers_To_Producers] CHECK CONSTRAINT [FK_Dealers_To_Producers_Producers]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_ProductParts] FOREIGN KEY([ProductPartId])
REFERENCES [dbo].[ProductParts] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_ProductParts]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Dealers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Producers] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Producers]
GO
ALTER TABLE [dbo].[ProducerPersonels]  WITH CHECK ADD  CONSTRAINT [FK_ProducerPersonels_AspNetUsers] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ProducerPersonels] CHECK CONSTRAINT [FK_ProducerPersonels_AspNetUsers]
GO
ALTER TABLE [dbo].[ProducerPersonels]  WITH CHECK ADD  CONSTRAINT [FK_ProducerPersonels_Producers] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
ALTER TABLE [dbo].[ProducerPersonels] CHECK CONSTRAINT [FK_ProducerPersonels_Producers]
GO
ALTER TABLE [dbo].[Producers]  WITH CHECK ADD  CONSTRAINT [FK_Producers_AspNetUsers] FOREIGN KEY([AspNetUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Producers] CHECK CONSTRAINT [FK_Producers_AspNetUsers]
GO
ALTER TABLE [dbo].[ProductParts]  WITH CHECK ADD  CONSTRAINT [FK_ProductParts_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[ProductParts] CHECK CONSTRAINT [FK_ProductParts_Categories]
GO
ALTER TABLE [dbo].[ProductParts]  WITH CHECK ADD  CONSTRAINT [FK_ProductParts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductParts] CHECK CONSTRAINT [FK_ProductParts_Products]
GO
ALTER TABLE [dbo].[ProductParts_To_Producers]  WITH CHECK ADD  CONSTRAINT [FK_ProductParts_To_Producers_Producers] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
ALTER TABLE [dbo].[ProductParts_To_Producers] CHECK CONSTRAINT [FK_ProductParts_To_Producers_Producers]
GO
ALTER TABLE [dbo].[ProductParts_To_Producers]  WITH CHECK ADD  CONSTRAINT [FK_ProductParts_To_Producers_ProductParts] FOREIGN KEY([ProductPartId])
REFERENCES [dbo].[ProductParts] ([Id])
GO
ALTER TABLE [dbo].[ProductParts_To_Producers] CHECK CONSTRAINT [FK_ProductParts_To_Producers_ProductParts]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Dealers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes]
GO
USE [master]
GO
ALTER DATABASE [Mimar-Soft-Database-06ST8W-TT41] SET  READ_WRITE 
GO
