USE [master]
GO
/****** Object:  Database [hci]    Script Date: 11/9/2014 11:02:44 PM ******/
CREATE DATABASE [hci]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hci', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\hci.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'hci_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\hci_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [hci] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hci].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hci] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hci] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hci] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hci] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hci] SET ARITHABORT OFF 
GO
ALTER DATABASE [hci] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hci] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hci] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hci] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hci] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hci] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hci] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hci] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hci] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hci] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hci] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hci] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hci] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hci] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hci] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hci] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hci] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hci] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hci] SET  MULTI_USER 
GO
ALTER DATABASE [hci] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hci] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hci] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hci] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [hci] SET DELAYED_DURABILITY = DISABLED 
GO
USE [hci]
GO
/****** Object:  User [hci]    Script Date: 11/9/2014 11:02:44 PM ******/
CREATE USER [hci] FOR LOGIN [hci] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [hci]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [hci]
GO
ALTER ROLE [db_datareader] ADD MEMBER [hci]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [hci]
GO
/****** Object:  Table [dbo].[degree_levels]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[degree_levels](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[degree_level_desc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_degree_levels] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[events]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[schedule_id] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[interval_type] [varchar](50) NOT NULL,
	[occur_day] [varchar](500) NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
 CONSTRAINT [PK_events] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[group_memberships]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[group_memberships](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_group_memberships] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[groups]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[groups](
	[id] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[owner_id] [int] NOT NULL,
	[description] [varchar](1000) NOT NULL,
	[course_no] [varchar](50) NULL,
	[is_closed] [int] NOT NULL,
	[max_member_number] [int] NOT NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[majors]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[majors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[major_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_majors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[meeting_attenders]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meeting_attenders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[meeting_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_meeting_attenders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[meetings]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[meetings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[group_id] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[interval_type] [varchar](50) NOT NULL,
	[occur_day] [varchar](500) NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
 CONSTRAINT [PK_meetings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rel_groups_studyfields]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_groups_studyfields](
	[id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[study_field_id] [int] NOT NULL,
 CONSTRAINT [PK_rel_groups_studyfields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[requests]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[requests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[sender_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[schedules]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[schedules](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NULL,
 CONSTRAINT [PK_class_schedules] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[study_fields]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[study_fields](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_study_fields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 11/9/2014 11:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[addr] [nvarchar](max) NULL,
	[degree_level_id] [int] NULL,
	[schedule_id] [int] NOT NULL,
	[photo] [image] NULL,
	[major_id] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UIX_majors_01]    Script Date: 11/9/2014 11:02:44 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UIX_majors_01] ON [dbo].[majors]
(
	[major_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UIX_study_fields_01]    Script Date: 11/9/2014 11:02:44 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UIX_study_fields_01] ON [dbo].[study_fields]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_schedules] FOREIGN KEY([schedule_id])
REFERENCES [dbo].[schedules] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_schedules]
GO
ALTER TABLE [dbo].[group_memberships]  WITH CHECK ADD  CONSTRAINT [FK_groupmemberships_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[group_memberships] CHECK CONSTRAINT [FK_groupmemberships_groups]
GO
ALTER TABLE [dbo].[group_memberships]  WITH CHECK ADD  CONSTRAINT [FK_groupmemberships_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[group_memberships] CHECK CONSTRAINT [FK_groupmemberships_users]
GO
ALTER TABLE [dbo].[groups]  WITH CHECK ADD  CONSTRAINT [FK_groups_users] FOREIGN KEY([owner_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[groups] CHECK CONSTRAINT [FK_groups_users]
GO
ALTER TABLE [dbo].[meeting_attenders]  WITH CHECK ADD  CONSTRAINT [FK_meetingattenders_meetings] FOREIGN KEY([meeting_id])
REFERENCES [dbo].[meetings] ([id])
GO
ALTER TABLE [dbo].[meeting_attenders] CHECK CONSTRAINT [FK_meetingattenders_meetings]
GO
ALTER TABLE [dbo].[meeting_attenders]  WITH CHECK ADD  CONSTRAINT [FK_meetingattenders_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[meeting_attenders] CHECK CONSTRAINT [FK_meetingattenders_users]
GO
ALTER TABLE [dbo].[meetings]  WITH CHECK ADD  CONSTRAINT [FK_meetings_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[meetings] CHECK CONSTRAINT [FK_meetings_groups]
GO
ALTER TABLE [dbo].[rel_groups_studyfields]  WITH CHECK ADD  CONSTRAINT [FK_rel_groupsstudyfields_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[rel_groups_studyfields] CHECK CONSTRAINT [FK_rel_groupsstudyfields_groups]
GO
ALTER TABLE [dbo].[rel_groups_studyfields]  WITH CHECK ADD  CONSTRAINT [FK_rel_groupsstudyfields_studyfields] FOREIGN KEY([study_field_id])
REFERENCES [dbo].[study_fields] ([id])
GO
ALTER TABLE [dbo].[rel_groups_studyfields] CHECK CONSTRAINT [FK_rel_groupsstudyfields_studyfields]
GO
ALTER TABLE [dbo].[requests]  WITH CHECK ADD  CONSTRAINT [FK_requests_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[requests] CHECK CONSTRAINT [FK_requests_groups]
GO
ALTER TABLE [dbo].[requests]  WITH CHECK ADD  CONSTRAINT [FK_requests_senderusers] FOREIGN KEY([sender_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[requests] CHECK CONSTRAINT [FK_requests_senderusers]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_classschedules] FOREIGN KEY([schedule_id])
REFERENCES [dbo].[schedules] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_classschedules]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_degreelevels] FOREIGN KEY([degree_level_id])
REFERENCES [dbo].[degree_levels] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_degreelevels]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_majors] FOREIGN KEY([major_id])
REFERENCES [dbo].[majors] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_majors]
GO
USE [master]
GO
ALTER DATABASE [hci] SET  READ_WRITE 
GO
