USE [master]
GO
/****** Object:  Database [StudentManagement]    Script Date: 11/11/2020 04:30:22 ******/
CREATE DATABASE [StudentManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudentManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StudentManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StudentManagement_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StudentManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [StudentManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StudentManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StudentManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StudentManagement]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 11/11/2020 04:30:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[AnswerID] [uniqueidentifier] NOT NULL CONSTRAINT [DF__Answer__AnswerID__108B795B]  DEFAULT (newsequentialid()),
	[AnswerTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[File] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Mark] [real] NULL,
	[Status] [int] NOT NULL,
	[StudentID] [nvarchar](50) NULL,
	[TestID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Class]    Script Date: 11/11/2020 04:30:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[ClassName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[TeacherID] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassStudent]    Script Date: 11/11/2020 04:30:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassStudent](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ClassStudent_ID]  DEFAULT (newsequentialid()),
	[ClassID] [uniqueidentifier] NOT NULL,
	[StudentID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ClassStudent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 11/11/2020 04:30:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test]    Script Date: 11/11/2020 04:30:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestID] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[TestTitle] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TeacherID] [nvarchar](50) NULL,
	[ClassID] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Test] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Answer] ([AnswerID], [AnswerTitle], [Description], [File], [CreateDate], [Mark], [Status], [StudentID], [TestID]) VALUES (N'65ee24e4-a521-eb11-80b6-34e6d743f8ac', N'abc', N'Description here', NULL, CAST(N'2020-11-02 00:00:00.000' AS DateTime), 9, 0, N'phuongpt', N'10471630-ec1f-eb11-80b6-34e6d743f8ac')
INSERT [dbo].[Answer] ([AnswerID], [AnswerTitle], [Description], [File], [CreateDate], [Mark], [Status], [StudentID], [TestID]) VALUES (N'd9600b4e-8122-4689-84c3-a50a638d7a91', N'PE_PTP', N'Here', N'Student.png', CAST(N'2020-11-11 04:23:08.500' AS DateTime), 8, 0, N'phuongpt', N'1d92fd24-d0a3-45d3-ac10-ebcc6c6feb76')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'00000000-0000-0000-0000-000000000000', N'absd', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-12 00:00:00.000' AS DateTime), 0, N'hieuntt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'182d6a0b-3706-42e7-9b7b-29d134b5b606', N'hiuhiu', CAST(N'2020-11-10 00:00:00.000' AS DateTime), CAST(N'2020-11-26 00:00:00.000' AS DateTime), 0, N'hieuntt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'517fd601-251d-eb11-80b6-34e6d743f8ac', N'ABC', CAST(N'2020-10-10 00:00:00.000' AS DateTime), CAST(N'2020-11-02 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'5e18aa1e-251d-eb11-80b6-34e6d743f8ac', N'XZZ', CAST(N'2020-10-20 00:00:00.000' AS DateTime), CAST(N'2020-11-10 00:00:00.000' AS DateTime), 0, N'tramdbt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'bc8f062e-251d-eb11-80b6-34e6d743f8ac', N'BNM', CAST(N'2020-10-03 00:00:00.000' AS DateTime), CAST(N'2020-11-20 00:00:00.000' AS DateTime), 0, N'hieuntt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'a70bb01e-4f1f-eb11-80b6-34e6d743f8ac', N'EDNabcdefg', CAST(N'2020-10-10 00:00:00.000' AS DateTime), CAST(N'2020-11-20 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', N'TYU', CAST(N'2020-10-05 00:00:00.000' AS DateTime), CAST(N'2020-11-22 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'f92a9f64-ece2-43db-8291-39014cb14b31', N'ahihihuhu', CAST(N'2020-10-28 00:00:00.000' AS DateTime), CAST(N'2020-11-20 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'8fef08f7-1d38-45da-a5f4-7ebce58f18af', N'absd', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-09 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'f322bbd3-3179-480a-a795-af9cad464fa6', N'ddfgf', CAST(N'2020-10-28 00:00:00.000' AS DateTime), CAST(N'2020-11-21 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'dc9321c2-7c99-4443-b1e3-b9a9c6f4a5e1', N'Java', CAST(N'2020-11-11 00:00:00.000' AS DateTime), CAST(N'2020-11-13 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[Class] ([ClassID], [ClassName], [StartDate], [EndDate], [Status], [TeacherID]) VALUES (N'd42e783e-1abf-46bb-b1ca-dd6e50a2532d', N'ABC', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-09 00:00:00.000' AS DateTime), 0, N'phuongptt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'4518745f-3ecb-4291-8133-0624240e5db8', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', N'phuongptse140910')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'bc5b5743-ab1d-eb11-80b6-34e6d743f8ac', N'517fd601-251d-eb11-80b6-34e6d743f8ac', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'bd5b5743-ab1d-eb11-80b6-34e6d743f8ac', N'bc8f062e-251d-eb11-80b6-34e6d743f8ac', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'844fbe4c-ab1d-eb11-80b6-34e6d743f8ac', N'bc8f062e-251d-eb11-80b6-34e6d743f8ac', N'hieunt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'854fbe4c-ab1d-eb11-80b6-34e6d743f8ac', N'5e18aa1e-251d-eb11-80b6-34e6d743f8ac', N'hieunt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'85818e57-ab1d-eb11-80b6-34e6d743f8ac', N'5e18aa1e-251d-eb11-80b6-34e6d743f8ac', N'tramdb')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'142a9967-ab1d-eb11-80b6-34e6d743f8ac', N'5e18aa1e-251d-eb11-80b6-34e6d743f8ac', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'019e60e9-4202-43d0-8f27-3e76f6b232a6', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', N'tramdb')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'd5c685f6-3d75-4fca-80a8-4d4ef0a1c372', N'f92a9f64-ece2-43db-8291-39014cb14b31', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'c209d907-742a-45aa-a124-4f9674d1835f', N'8fef08f7-1d38-45da-a5f4-7ebce58f18af', N'phuongptse140910')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'725a9e4c-a745-4000-838e-5ef433f56f5d', N'8fef08f7-1d38-45da-a5f4-7ebce58f18af', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'372574ef-4b5e-48e8-b365-619e3569d8bc', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', N'hieunt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'135800df-a47b-455a-8cbe-64be99ec3e7a', N'dc9321c2-7c99-4443-b1e3-b9a9c6f4a5e1', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'df81f7df-e05e-4bac-9fa7-89da7cd5967c', N'8fef08f7-1d38-45da-a5f4-7ebce58f18af', N'hieunt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'd11b8cab-28d7-4bb2-8bec-924166349266', N'182d6a0b-3706-42e7-9b7b-29d134b5b606', N'hieunt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'96354b43-fbc7-491c-8b3d-c0bd474123b1', N'a70bb01e-4f1f-eb11-80b6-34e6d743f8ac', N'hieunt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'98f299bc-b3c9-49d6-be97-c8fd54f87f36', N'182d6a0b-3706-42e7-9b7b-29d134b5b606', N'tramdb')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'2014ed2c-0742-44f0-a2f9-fa2c03abc138', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', N'phuongpt')
INSERT [dbo].[ClassStudent] ([ID], [ClassID], [StudentID]) VALUES (N'1fbd5615-3712-431b-a027-fc3b3b23f432', N'a70bb01e-4f1f-eb11-80b6-34e6d743f8ac', N'phuongptse140910')
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'abc', N'123456', N'Pham Thanh Phuong', 1, N'0354003757', N'TP HCM', N'Teacher', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'hieunt', N'123456', N'Nguyễn Thị Hiếu', 0, N'0123456789', N'TP HCM', N'Student', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'hieuntmg', N'123456', N'Nguyễn Thị Hiếu', 0, N'0123456789', N'TP HCM', N'Manager', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'hieuntt', N'123456', N'Nguyễn Thị Hiếu', 1, N'0123456789', N'HN', N'Teacher', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'phuongpt', N'123456', N'Phạm Thanh Phương', 0, N'0123456789', N'TP HCM', N'Student', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'phuongptmg', N'phuongpt', N'Phương PTP', 1, N'0123456789', N'Lam Dong', N'Manager', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'phuongptse140910', N'123456', N'Pham Thanh Phuong', 1, N'0354003757', N'TP HCM', N'Student', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'phuongptt', N'123456', N'Phạm Thanh Phương', 1, N'0123456789', N'TP HCM', N'Teacher', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'tramdb', N'123456', N'Đào Bảo Trâm', 1, N'0123456789', N'TP HCM', N'Student', NULL, 0)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'tramdbt', N'123456', N'Đào Bảo Trâm', 0, N'0123456789', N'TP HCM', N'Teacher', NULL, 1)
INSERT [dbo].[Person] ([Username], [Password], [Fullname], [Gender], [Phone], [Address], [Discriminator], [Image], [Status]) VALUES (N'tramdbtmg', N'123456', N'Đào Bảo Trâm', 0, N'0123456789', N'TP HCM', N'Manager', NULL, 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'8b5ff061-ec54-421f-b205-14f44cff5405', N'Ahihi', N'ádasda', CAST(N'2020-11-04 00:00:00.000' AS DateTime), CAST(N'2020-11-09 00:00:00.000' AS DateTime), N'phuongptt', N'00000000-0000-0000-0000-000000000000', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'b1fd24de-241f-43ad-ae7c-1e3d43626c02', N'Ahihi', N'adasd', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-14 00:00:00.000' AS DateTime), N'phuongptt', N'00000000-0000-0000-0000-000000000000', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'10471630-ec1f-eb11-80b6-34e6d743f8ac', N'Test title here', N'Test Description here', CAST(N'2020-10-10 00:00:00.000' AS DateTime), CAST(N'2020-11-02 00:00:00.000' AS DateTime), N'phuongptt', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'9d18cb44-ec1f-eb11-80b6-34e6d743f8ac', N'xczxc', N'asdas', CAST(N'2020-10-03 00:00:00.000' AS DateTime), CAST(N'2020-11-20 00:00:00.000' AS DateTime), N'phuongptt', N'517fd601-251d-eb11-80b6-34e6d743f8ac', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'11479bcc-a512-40d4-bc3e-5f53d8756f7f', N'Hieeu khung', N'bi khung', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-01 00:00:00.000' AS DateTime), N'phuongptt', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'f0d804fa-412b-4fdd-87a3-6cfc7769871f', N'asdad', N'asdasd', CAST(N'2020-11-10 00:00:00.000' AS DateTime), CAST(N'2020-11-29 00:00:00.000' AS DateTime), N'phuongptt', N'8fef08f7-1d38-45da-a5f4-7ebce58f18af', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'180f9ca8-1ba2-4b8b-97e2-850185ce5ffa', N'Ahihi', N'huhuhu', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-09 00:00:00.000' AS DateTime), N'phuongptt', N'00000000-0000-0000-0000-000000000000', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'e1b44004-978f-40a1-9823-a25963667c5e', N'Ahihi', N'dasdasd', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-13 00:00:00.000' AS DateTime), N'phuongptt', N'00000000-0000-0000-0000-000000000000', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'f5d20386-5948-4581-a23d-bad52c6a65df', N'asdad', N'qweqweq', CAST(N'2020-11-09 00:00:00.000' AS DateTime), CAST(N'2020-11-12 00:00:00.000' AS DateTime), N'phuongptt', N'00000000-0000-0000-0000-000000000000', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'e34be3f7-a3e9-49df-b98c-c0600e916292', N'hihi', N'hihi', CAST(N'2020-11-05 00:00:00.000' AS DateTime), CAST(N'2020-11-19 00:00:00.000' AS DateTime), N'phuongptt', N'a56ecf2e-4f1f-eb11-80b6-34e6d743f8ac', 0)
INSERT [dbo].[Test] ([TestID], [TestTitle], [Description], [CreateDate], [EndDate], [TeacherID], [ClassID], [Status]) VALUES (N'1d92fd24-d0a3-45d3-ac10-ebcc6c6feb76', N'Practical Exam', NULL, CAST(N'2020-11-11 00:00:00.000' AS DateTime), CAST(N'2020-11-14 00:00:00.000' AS DateTime), N'phuongptt', N'dc9321c2-7c99-4443-b1e3-b9a9c6f4a5e1', 0)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_StudentID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_StudentID] ON [dbo].[Answer]
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_TestID] ON [dbo].[Answer]
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TeacherID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_TeacherID] ON [dbo].[Class]
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_ClassID] ON [dbo].[ClassStudent]
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_StudentID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_StudentID] ON [dbo].[ClassStudent]
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_ClassID] ON [dbo].[Test]
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TeacherID]    Script Date: 11/11/2020 04:30:22 ******/
CREATE NONCLUSTERED INDEX [IX_TeacherID] ON [dbo].[Test]
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Answer_dbo.Person_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Person] ([Username])
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_dbo.Answer_dbo.Person_StudentID]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Answer_dbo.Test_TestID] FOREIGN KEY([TestID])
REFERENCES [dbo].[Test] ([TestID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_dbo.Answer_dbo.Test_TestID]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Class_dbo.Person_TeacherID] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Person] ([Username])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_dbo.Class_dbo.Person_TeacherID]
GO
ALTER TABLE [dbo].[ClassStudent]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassStudent_dbo.Class_ClassID] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassStudent] CHECK CONSTRAINT [FK_dbo.ClassStudent_dbo.Class_ClassID]
GO
ALTER TABLE [dbo].[ClassStudent]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClassStudent_dbo.Person_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Person] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassStudent] CHECK CONSTRAINT [FK_dbo.ClassStudent_dbo.Person_StudentID]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Test_dbo.Class_ClassID] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_dbo.Test_dbo.Class_ClassID]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Test_dbo.Person_TeacherID] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Person] ([Username])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_dbo.Test_dbo.Person_TeacherID]
GO
USE [master]
GO
ALTER DATABASE [StudentManagement] SET  READ_WRITE 
GO
