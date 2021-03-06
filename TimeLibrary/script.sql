USE [master]
GO
/****** Object:  Database [DateTimeDatabase]    Script Date: 8/14/2020 6:43:18 AM ******/
CREATE DATABASE [DateTimeDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DateTimeDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DateTimeDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DateTimeDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DateTimeDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DateTimeDatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DateTimeDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DateTimeDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DateTimeDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DateTimeDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DateTimeDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DateTimeDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DateTimeDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [DateTimeDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DateTimeDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DateTimeDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DateTimeDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DateTimeDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DateTimeDatabase] SET QUERY_STORE = OFF
GO
USE [DateTimeDatabase]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 8/14/2020 6:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 8/14/2020 6:43:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Duration] [time](7) NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 8/14/2020 6:43:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [int] NULL,
	[StartDate] [datetime2](7) NULL,
	[StartTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 8/14/2020 6:43:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (1, CAST(N'2017-01-01T06:34:12.000' AS DateTime), CAST(N'2007-01-01T12:45:34.000' AS DateTime))
INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (2, CAST(N'2017-01-02T09:23:08.000' AS DateTime), CAST(N'2007-01-02T09:45:34.000' AS DateTime))
INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (3, CAST(N'2017-01-03T09:30:08.000' AS DateTime), CAST(N'2007-01-02T13:45:34.000' AS DateTime))
INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (4, CAST(N'2017-01-04T11:02:00.000' AS DateTime), CAST(N'2007-01-04T14:53:21.000' AS DateTime))
INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (5, CAST(N'2017-01-05T07:52:55.000' AS DateTime), CAST(N'2007-01-05T09:08:48.000' AS DateTime))
INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (6, CAST(N'2017-01-06T19:59:11.000' AS DateTime), CAST(N'2007-01-07T01:23:11.000' AS DateTime))
INSERT [dbo].[Events] ([EventID], [StartDate], [EndDate]) VALUES (7, CAST(N'2017-01-07T03:12:23.000' AS DateTime), CAST(N'2007-01-07T20:02:25.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Events] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([Id], [Duration], [Title]) VALUES (1, CAST(N'03:30:00' AS Time), N'Aliens extended')
INSERT [dbo].[Movies] ([Id], [Duration], [Title]) VALUES (2, CAST(N'00:45:00' AS Time), N'Second movie')
INSERT [dbo].[Movies] ([Id], [Duration], [Title]) VALUES (3, CAST(N'01:20:00' AS Time), N'Third movie')
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomIdentifier], [Identifier], [StartDate], [StartTime]) VALUES (1, 100, CAST(N'2020-04-19T04:49:36.0000000' AS DateTime2), CAST(N'2020-04-19T04:49:36.0000000' AS DateTime2))
INSERT [dbo].[Room] ([RoomIdentifier], [Identifier], [StartDate], [StartTime]) VALUES (2, 100, CAST(N'2020-06-01T12:00:00.0000000' AS DateTime2), CAST(N'2020-06-01T12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Room] ([RoomIdentifier], [Identifier], [StartDate], [StartTime]) VALUES (3, 100, CAST(N'2020-06-01T13:00:00.0000000' AS DateTime2), CAST(N'2020-06-01T13:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[TimeTable] ON 

INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (1, N'Jeanine', N'Abbott', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (2, N'Lester', N'Lam', CAST(N'08:00:00' AS Time), CAST(N'11:00:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (3, N'Claire', N'Cowan', CAST(N'15:45:00' AS Time), CAST(N'19:45:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (4, N'Shannon', N'Bentley', CAST(N'00:30:00' AS Time), CAST(N'08:30:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (5, N'Valerie', N'Berger', CAST(N'03:00:00' AS Time), CAST(N'04:15:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (6, N'Ty', N'Keith', CAST(N'12:45:00' AS Time), CAST(N'16:00:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (7, N'Roy', N'Finley', CAST(N'06:15:00' AS Time), CAST(N'05:15:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (8, N'Ashley', N'Howard', CAST(N'13:00:00' AS Time), CAST(N'13:45:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (9, N'Forrest', N'Rich', CAST(N'17:00:00' AS Time), CAST(N'17:30:00' AS Time))
INSERT [dbo].[TimeTable] ([id], [FirstName], [LastName], [StartTime], [EndTime]) VALUES (10, N'Ron', N'Martin', CAST(N'08:00:00' AS Time), CAST(N'07:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
USE [master]
GO
ALTER DATABASE [DateTimeDatabase] SET  READ_WRITE 
GO
