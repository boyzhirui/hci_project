USE [hci]
GO
/****** Object:  Table [dbo].[degree_levels]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[events]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[group_memberships]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[groups]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[majors]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[meeting_attenders]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[meetings]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[rel_groups_studyfields]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[requests]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[schedules]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[study_fields]    Script Date: 11/9/2014 10:59:55 PM ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 11/9/2014 10:59:55 PM ******/
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
